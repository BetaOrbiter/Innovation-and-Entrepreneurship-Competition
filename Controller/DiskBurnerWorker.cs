using Hardware.Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public static class DiskBurnerWorker
    {
        public static Action<List<string>, int> InitUI;

        public static Action UpdateResultUI;

        public static Action<TestType> StepBack;

        private static readonly List<string> testFilePath = new();
        private static readonly List<string> entityDisks = new();

        private static Timer timer;
        private static DateTime timeStart;
        private static TimeSpan duration;
        private static MyTool.DiskStresser diskStresser;
        private static int stressTime;
        private static TestModel testModel;
        public static ManualResetEvent stopSignal;
        public static bool hasStresser { get; set; } = false;

        public static void Work(object? _testModel)
        {
            //获取测试模式
            testModel = (TestModel)_testModel!;
            //读取硬盘和盘符
            GetDiskVolumes();
            if (testModel == TestModel.Comprehensive)
            {
                stressTime = Profile.Configuration.GetInstance().DiskStressTime; 
            }
            else
            {
                stressTime = Profile.Configuration.GetInstance().QuickDiskStressTime;
            }
            _ = stopSignal.WaitOne();
            InitUI(entityDisks, stressTime + 4);
            //启动定时器
            timer = new Timer(
                new TimerCallback(OnTimer)
                , null
                , 1000
                , 1000
                );
            timeStart = DateTime.Now;
            //开启硬盘压力测试
            //一半时间高读写量测试
            var profile = Profile.Configuration.GetInstance();
            diskStresser = new(profile.DiskspdPath, 
                testFilePath, stressTime, 4 * 1024 * 1024);
            hasStresser = true;

            _ = stopSignal.WaitOne();
            diskStresser.Start();
            diskStresser.WaitForExit();
            if (hasStresser)
            {
                diskStresser.Kill();
            }
            diskStresser.Dispose();
            for(int i=0;i< entityDisks.Count; i++)
            {
                MyTool.Log.GetInstance().Record(MyTool.LogType.Success, $"硬盘{i} {entityDisks[i]}压力测试通过");
            }
            foreach(var path in testFilePath)
            {
                File.Delete(path);
            }
            Thread.Sleep(5000);
            timer.Change(-1, -1);
            _ = stopSignal.WaitOne();
            timer.Dispose();
            UpdateResultUI();
        }

        public static void Kill() 
        {
            StepBack(TestType.DiskBurnerTest);
            hasStresser = false;
            if(timer!=null)
               timer.Change(-1, -1);
            diskStresser.Kill(); 
        }

        private static void GetDiskVolumes()
        {
            //读取物理硬盘和盘符
            HardwareInformation info = new();
            info.RefreshDriveList();
            int index = 0;
            foreach (var disk in info.DiskList)
            {
                foreach (var part in disk.PartitionList)
                {
                    bool flag = false;
                    foreach (var volume in part.VolumeList)
                    {
                        index++;
                        flag = true;
                        testFilePath.Add(volume.Name.TrimEnd() + $"/testfile{index}.dat");
                        entityDisks.Add(disk.Model.TrimEnd());
                        break;
                    }
                    if (flag) break;
                }
            }
            
        }
        //更新总测试进度
        private static void OnTimer(object state)
        {
            duration = DateTime.Now - timeStart;
            ProgressChanger.Update(TestType.DiskBurnerTest,(int)duration.TotalSeconds, stressTime + 4);
        }
    }
}
