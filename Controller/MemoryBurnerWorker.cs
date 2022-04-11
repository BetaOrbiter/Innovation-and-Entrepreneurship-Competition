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
        public static Action<List<string>, int> InitUI;

        public static Action UpdateResultUI;
        public static void Work()
        {
            //获取当前内存型号
            HardwareInformation info = new();
            info.RefreshMemoryList();
            List<string> memoryNames = new();
            ulong memorySize = 0;
            foreach (var memory in info.MemoryList)
            {
                memoryNames.Add(memory.PartNumber.TrimEnd());
                memorySize += memory.Capacity;
            }
            InitUI(memoryNames, 60);
            //开启内存压力测试
            MyTool.MemoryStresser memoryStresser = new(@"C:\Users\刘星辰\Desktop\服创大赛\x64\Debug\memory_burner.exe", memorySize, 60);
            memoryStresser.Start();
            memoryStresser.WaitForExit();
            UpdateResultUI();
        }
    }
}
