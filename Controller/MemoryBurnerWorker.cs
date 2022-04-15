using Hardware.Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public static class MemoryBurnerWorker
    {
        public static Action<List<string>, ulong, int> InitUI;
        public static Action UpdateResultUI;
        public static Action<TestType> StepBack;
        private static Timer timer;
        private static DateTime timeStart;
        private static TimeSpan duration;
        private static MyTool.MemoryStresser memoryStresser;
        private static int stressTime;
        private static TestModel testModel;

        public static ManualResetEvent stopSignal;
        public static bool hasStresser { get; set; } = false;

        public static void Work(object? _testModel)
        {
            //设置测试模式
            testModel = (TestModel)_testModel;
            //获取当前内存型号
            HardwareInformation info = new();
            info.RefreshMemoryList();
            if (testModel == TestModel.Comprehensive)
            {
                stressTime = Profile.Configuration.GetInstance().MemoryStressTime;
            }
            else
            {
                stressTime = Profile.Configuration.GetInstance().QuickMemoryStressTime;
            }
            List<string> memorys = new();
            ulong memorySize = 0;
            foreach (var memory in info.MemoryList)
            {
                memorys.Add(memory.PartNumber.TrimEnd());
                memorySize += memory.Capacity;
            }
            _ = stopSignal.WaitOne();
            InitUI(memorys, memorySize / ((ulong)1024 * 1024 * 1024),
                stressTime + 4
                );
            //开启定时器
            timer = new Timer(
                new TimerCallback(OnTimer)
                , null
                , 1000
                , 1000
                );
            timeStart = DateTime.Now;
            //开启内存压力测试
            var profile = Profile.Configuration.GetInstance();
            ulong totalSize = 0;
            foreach (var size in profile.MemoryConfig.Size)
                totalSize += size;
            memoryStresser = new(profile.Memory_burnerPath, totalSize, stressTime);
            hasStresser = true;

            _ = stopSignal.WaitOne();
            memoryStresser.Start();
            memoryStresser.WaitForExit();
            if (hasStresser)
            {
                memoryStresser.Kill();
            }
            memoryStresser.Dispose();
            for (int i=0;i<memorys.Count;i++)
            {
                MyTool.Log.GetInstance().Record(MyTool.LogType.Success, $"内存{i} {memorys[i]}压力测试通过");
            }
            Thread.Sleep(5000);
            timer.Change(-1, -1);
            _ = stopSignal.WaitOne();
            timer.Dispose();
            UpdateResultUI();
        }

        public static void Kill() 
        {
            StepBack(TestType.MemoryBurnerTest);
            hasStresser = false;
            if(timer!=null)
               timer.Change(-1, -1);
            memoryStresser.Kill(); 
        }

        //更新总测试进度
        private static void OnTimer(object state)
        {
            duration = DateTime.Now - timeStart;
            ProgressChanger.Update(TestType.MemoryBurnerTest, (int)duration.TotalSeconds, stressTime + 4);
        }
    }
}
