using Hardware.Info;

namespace Controller
{
    //配置信息检验总控线程类
    //调用并执行tasks，随时报告进度，提醒UI更新，返回结果
    public static class ConfigChecker
    {
        public static Action<int, List<string>, List<string>, bool> UpdateProgressUI;

        public static Action UpdateResultUI;
       
        const string excepterCPUName = "Intel(R) Core(TM) i7-9750H CPU @ 2.60GHz";
        
        static readonly List<string> memoryModel =new() { "M471A1K43CB1-CTD    ", "M471A1K43CB1-CTD    " };
        
        static readonly List<string> gpuName =new() { "NVIDIA GeForce RTX 2060" };
        
        static readonly List<string> diskName =new() { "Samsung SSD 870 EVO 500GB", "SAMSUNG MZVLB512HAJQ-000H1" };

        public static void Work()
        {
            //读取配置文件
            ReadConfig();
            //配置校验
            HardwareInformation info = new();
            //CPU配置信息检验
            info.RefreshCPUList(false);
            var terminalCPU = info.CpuList[0];
            CPUCheck(terminalCPU);
            Thread.Sleep(2000);
            //内存配置信息检验
            info.RefreshMemoryList();
            var terminalMemorys = info.MemoryList;
            MemorysCheck(terminalMemorys);
            Thread.Sleep(2000);
            //显卡配置信息检验
            info.RefreshVideoControllerList();
            var terminalGPU = info.VideoControllerList;
            GPUCheck(terminalGPU);
            Thread.Sleep(2000);
            //硬盘配置信息检验
            info.RefreshDriveList();
            var terminalDisks = info.DriveList;
            
            DiskCheck(terminalDisks);
            Thread.Sleep(2000);
            //硬盘Smart信息检查
            var diskSmarts = info.DrivesSMARTs;
            DiskSmartCheck(diskSmarts);
            Thread.Sleep(1000);
            UpdateResultUI();
        }
        private static void CPUCheck(CPU terminalCPU)
        {
            UpdateProgressUI(
                1,
                new List<string> { terminalCPU.Name.TrimEnd() }, //因为可能会有后导white space,所以用TrimEnd(),去除
                new List<string> { excepterCPUName.TrimEnd() },
                terminalCPU.Name.TrimEnd().Equals(excepterCPUName.TrimEnd())
            );
            
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
     
            UpdateProgressUI(2, memoryNames, memoryModel, 
                memoryNames.SequenceEqual(memoryModel));

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
            UpdateProgressUI(3,gpuNames, gpuName, gpuNames.SequenceEqual(gpuName));
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
            UpdateProgressUI(4, diskNames, diskName, diskNames.SequenceEqual(diskName));
        }

        private static void DiskSmartCheck(Krugertech.IO.Smart.DriveCollection diskSmarts)
        {
            foreach (var diskSmart in diskSmarts!)
            {
                Console.WriteLine(diskSmart.Model);
                foreach (var arr in diskSmart.SmartAttributes)
                {
                    Console.WriteLine("\t{0}:{1}", arr.Name, arr.Data);
                }
            }
        }
       private static void ReadConfig()
        {

        }
    }
}