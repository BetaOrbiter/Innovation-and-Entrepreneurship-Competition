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
        public static Action<string,int> InitUI;

        public static Action UpdateResultUI;
        public static void Work()
        {
            //读取CPU型号
            HardwareInformation info = new();
            info.RefreshCPUList(false);
            //让UI开始工作
            InitUI(info.CpuList[0].Name, 12);

            //开启CPU压力测试
            MyTool.CpuStresser cpuStresser = new(@"C:\Users\刘星辰\Desktop\服创大赛\x64\Debug\cpu_burner.exe", 10);
            cpuStresser.Start();

            cpuStresser.WaitForExit();
            Thread.Sleep(3000);
            UpdateResultUI();
        }
       
    }
}
