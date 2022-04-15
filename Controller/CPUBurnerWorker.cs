using Hardware.Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public static class CPUBurnerWorker
    {
        public static Action<string, int> InitUI;

        public static Action UpdateResultUI;

        public static Action<TestType> StepBack;

        private static Timer timer;
        private static DateTime timeStart;
        private static TimeSpan duration;
        private static int stressTime;
        private static MyTool.CpuStresser cpuStresser;

        public static ManualResetEvent stopSignal;
        public static bool hasStresser { get; set; } = false;
        private static TestModel testModel;
        public static void Work(object? _testModel)
        {
            //设置测试模式
            testModel = (TestModel)_testModel;
            //读取CPU型号
            HardwareInformation info = new();
            info.RefreshCPUList(false);
            //让UI开始工作
            if (testModel == TestModel.Comprehensive)
            {
                stressTime = Profile.Configuration.GetInstance().CpuStressTime; ;
            }
            else
            {
                stressTime = Profile.Configuration.GetInstance().QuickDiskStressTime;
            }
            _ = stopSignal.WaitOne();
            InitUI(info.CpuList[0].Name, stressTime + 4);
            //开启定时器
            timer = new Timer(
                new TimerCallback(OnTimer)
                , null
                , 1000
                , 1000
                );
            timeStart = DateTime.Now;
            //开启CPU压力测试
            var profile = Profile.Configuration.GetInstance();
            cpuStresser = new(profile.Cpu_burnerPath, stressTime);
            hasStresser = true;

            _ = stopSignal.WaitOne();
            cpuStresser.Start();
            cpuStresser.WaitForExit();
            if (hasStresser)
            {
                cpuStresser.Kill();
            }
            cpuStresser.Dispose();
            MyTool.Log.GetInstance().Record(MyTool.LogType.Success, $"CPU {info.CpuList[0].Name}压力测试通过");
            Thread.Sleep(5000);
            timer.Change(-1, -1);
            _ = stopSignal.WaitOne();
            timer.Dispose();
            UpdateResultUI();
            
        }

        public static void Kill() 
        {
            StepBack(TestType.CPUBurnerTest);
            hasStresser = false;
            if(timer!=null)
               timer.Change(-1, -1);
            cpuStresser.Kill(); 
        }

        //更新总测试进度
        private static void OnTimer(object state)
        {
            duration = DateTime.Now - timeStart;
            ProgressChanger.Update(TestType.CPUBurnerTest, (int)duration.TotalSeconds, stressTime + 4);
        }
    }
}
