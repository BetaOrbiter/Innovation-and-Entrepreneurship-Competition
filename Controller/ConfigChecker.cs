using Hardware.Info;
using System.Net.Sockets;

namespace Controller
{
    //配置信息检验总控线程类
    //调用并执行tasks，随时报告进度，提醒UI更新，返回结果
    public static class ConfigChecker
    {
        public static Action<TestType, List<string>, List<string>, bool> UpdateProgressUI;

        public static Action<DateTime, DateTime, bool> UpdateRtcUI;

        public static Action<List<Tuple<string, int, int, int, int, bool>>> UpdateDiskSmartUI;

        public static Action UpdateResultUI;

        static readonly string excepterCPUName;
        
        static readonly List<string> memoryModel;
        
        static readonly List<string> gpuName;
        
        static readonly List<string> diskName;

        private static readonly MyTool.Log logger = MyTool.Log.GetInstance();

        private static Dictionary<TestType, bool> testTypes;

        public static ManualResetEvent stopSignal;

        static ConfigChecker()
        {
            var profile = Profile.Configuration.GetInstance();

            excepterCPUName = profile.CPUConfig.Names[0];
            memoryModel = profile.MemoryConfig.Names.ToList();
            gpuName = profile.GpuConfig.Names.ToList();
            diskName = profile.DriveConfig.Names.ToList();
        }

        public static void Work(object? _testTypes)
        {
            testTypes = (Dictionary<TestType, bool>)_testTypes;
            //RTC测试
            if (testTypes[TestType.RTCTest])
            {
                RTCCheck();
            }
            //配置校验
            _ = stopSignal.WaitOne();
            HardwareInformation info = new();

            //CPU配置信息检验
            _ = stopSignal.WaitOne();
            if (testTypes[TestType.CPUConfigCheck])
            {
                info.RefreshCPUList(false);
                var terminalCPU = info.CpuList[0];
                _ = stopSignal.WaitOne();
                CPUCheck(terminalCPU);
            }

            //内存配置信息检验
            _ = stopSignal.WaitOne();
            if (testTypes[TestType.MemoryConfigCheck])
            {
                info.RefreshMemoryList();
                var terminalMemorys = info.MemoryList;
                _ = stopSignal.WaitOne();
                MemorysCheck(terminalMemorys);
            }

            //显卡配置信息检验
            _ = stopSignal.WaitOne();
            if (testTypes[TestType.GPUConfigCheck])
            {
                info.RefreshVideoControllerList();
                var terminalGPU = info.VideoControllerList;
                _ = stopSignal.WaitOne();
                GPUCheck(terminalGPU);
            }

            //硬盘配置信息检验
            _ = stopSignal.WaitOne();
            if (testTypes[TestType.DiskConfigCheck])
            {
                info.RefreshDriveList();
                var terminalDisks = info.DiskList;
                _ = stopSignal.WaitOne();
                DiskCheck(terminalDisks);
            }
               

            //硬盘Smart信息检查
            
            _ = stopSignal.WaitOne();
            if (testTypes[TestType.DiskSmartTest])
            {
                var diskSmarts = info.DrivesSMARTs;
                DiskSmartCheck(diskSmarts);
            }
            Thread.Sleep(5000);
            _ = stopSignal.WaitOne();
            UpdateResultUI();
        }
        private static void RTCCheck()
        {
            var profile = Profile.Configuration.GetInstance();
            using Socket socket = new(SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(profile.RemoteIP, profile.RtcPort);
            byte[] rtcByte = new byte[sizeof(double)];
            int byteRead = 0;
            do
            {
                byteRead += socket.Receive(rtcByte, byteRead, rtcByte.Length - byteRead, SocketFlags.Partial);
            } while (byteRead < rtcByte.Length);
            double rtc = BitConverter.ToDouble(rtcByte);
            TimeSpan diff = DateTime.UtcNow - DateTime.UnixEpoch;
            DateTime serverTime =DateTime.UnixEpoch.AddSeconds(rtc);
            if (Math.Abs(rtc - diff.TotalSeconds) < profile.RtcTolerance)
            {
                logger.Record(MyTool.LogType.Success, $"RTC测试通过 server:{serverTime} ternimal:{DateTime.UtcNow}");
                UpdateRtcUI(serverTime, DateTime.UtcNow, true);
            }
            else
            {   
                logger.Record(MyTool.LogType.Success, $"RTC测试未通过 server:{serverTime} ternimal:{DateTime.UtcNow}");
                UpdateRtcUI(serverTime, DateTime.UtcNow, false);
            }
            ProgressChanger.Update(TestType.RTCTest, 0, 1);
            Thread.Sleep(1500);
            ProgressChanger.Update(TestType.RTCTest, 1, 1);
            Thread.Sleep(1500);
        }
        private static void CPUCheck(CPU terminalCPU)
        {
            bool flag = terminalCPU.Name.TrimEnd().Equals(excepterCPUName.TrimEnd());
            if (flag)
            {
                logger.Record(MyTool.LogType.Success,"CPU配置校验通过");
            }
            else
            {
                logger.Record(MyTool.LogType.Error, "CPU配置校验未通过");
            }
            UpdateProgressUI(
                TestType.CPUConfigCheck,
                new List<string> { terminalCPU.Name.TrimEnd() }, //因为可能会有后导white space,所以用TrimEnd(),去除
                new List<string> { excepterCPUName.TrimEnd() },
                flag
            );

            ProgressChanger.Update(TestType.CPUConfigCheck, 0, 1);
            Thread.Sleep(1500);
            ProgressChanger.Update(TestType.CPUConfigCheck, 1, 1);
            Thread.Sleep(1500);
        }
        private static void MemorysCheck(List<Memory> memories)
        {
            List<string> memoryNames = new();
            foreach (var memory in memories)
                memoryNames.Add(memory.PartNumber.TrimEnd());
            for (int i = 0; i < memoryModel.Count; i++)
                memoryModel[i] = memoryModel[i].TrimEnd();
            memoryModel.Sort();
            memoryNames.Sort();
            var flag = memoryNames.SequenceEqual(memoryModel);
            if (flag)
            {
                logger.Record(MyTool.LogType.Success, "内存配置校验通过");
            }
            else
            {
                logger.Record(MyTool.LogType.Error, "内存配置校验未通过");
            }
            UpdateProgressUI(TestType.MemoryConfigCheck, memoryNames, memoryModel, flag);
            ProgressChanger.Update(TestType.MemoryConfigCheck, 0, 1);
            Thread.Sleep(1500);
            ProgressChanger.Update(TestType.MemoryConfigCheck, 1, 1);
            Thread.Sleep(1500);
        }
        private static void GPUCheck(List<VideoController> terminalGPU)
        {
            List<string> gpuNames = new();
            foreach (var gpu in terminalGPU)
                gpuNames.Add(gpu.Name.TrimEnd());
            for (int i = 0; i < gpuName.Count; i++)
                gpuName[i] = gpuName[i].TrimEnd();
            
            gpuName.Sort();
            gpuNames.Sort();
            var flag = gpuNames.SequenceEqual(gpuName);
            if (flag)
            {
                logger.Record(MyTool.LogType.Success, "显卡配置校验通过");
            }
            else
            {
                logger.Record(MyTool.LogType.Error, "显卡配置校验未通过");
            }
            UpdateProgressUI(TestType.GPUConfigCheck, gpuNames, gpuName, flag);
            ProgressChanger.Update(TestType.GPUConfigCheck, 0, 1);
            Thread.Sleep(1500);
            ProgressChanger.Update(TestType.GPUConfigCheck, 1, 1);
            Thread.Sleep(1500);
        }
        private static void DiskCheck(List<Drive> terminalDisks)
        {
            List<string> diskNames = new ();

            foreach (var disk in terminalDisks)
               diskNames.Add(disk.Model.TrimEnd());
            
            for(int i=0;i<diskName.Count;i++)
                diskName[i] = diskName[i].TrimEnd();
            diskNames.Sort();
            diskName.Sort();
            var flag = diskNames.SequenceEqual(diskName);
            if (flag)
            {
                logger.Record(MyTool.LogType.Success, "硬盘配置校验通过");
            }
            else
            {
                logger.Record(MyTool.LogType.Error, "硬盘配置校验未通过");
            }
            UpdateProgressUI(TestType.DiskConfigCheck, diskNames, diskName, flag);
            ProgressChanger.Update(TestType.DiskConfigCheck, 0, 1);
            Thread.Sleep(1500);
            ProgressChanger.Update(TestType.DiskConfigCheck, 1, 1);
            Thread.Sleep(1500);
        }

        private static void DiskSmartCheck(Krugertech.IO.Smart.DriveCollection? diskSmarts)
        {
            List<Tuple<string, int, int, int, int, bool>> _diskSmarts=new List<Tuple<string, int, int, int, int, bool>>();
            int count = 0;
            foreach (var diskSmart in diskSmarts!)
            {
                Console.WriteLine(diskSmart.Model);
                string name = diskSmart.Model;
                int PowerOnHours = 0, PowerCount = 0, WritesCount = 0, UncorrectableErrorCount = 0;
                foreach (var arr in diskSmart.SmartAttributes)
                {
                    if (arr.Name == "Power-on hours count") PowerOnHours = arr.Data;
                    if (arr.Name == "Power cycle count") PowerCount = arr.Data;
                    if (arr.Name == "Life time writes") WritesCount = arr.Data/(1024*1024*1024);
                    if (arr.Name == "Uncorrectable error count") UncorrectableErrorCount = arr.Data;
                    
                }
                Tuple<string, int, int, int, int, bool> tuple = new(name, PowerCount, PowerOnHours, WritesCount, UncorrectableErrorCount, diskSmart.IsOK);
                _diskSmarts.Add(tuple);
                if (diskSmart.IsOK)
                {
                    logger.Record(MyTool.LogType.Success, $"硬盘{count} {name}Smart传感器信息无报错");
                }
                else
                {
                    logger.Record(MyTool.LogType.Error, $"硬盘{count} {name}Smart传感器信息报错");
                }
                count++;
            }
            ProgressChanger.Update(TestType.DiskSmartTest, 0, 1);
            UpdateDiskSmartUI(_diskSmarts);
            Thread.Sleep(1500);
            ProgressChanger.Update(TestType.DiskSmartTest, 1, 1);
            Thread.Sleep(1500);
        }
    }
}