using LibreHardwareMonitor.Hardware;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("UnitTestProject")]
namespace MyTool.Monitor
{
    /// <summary>
    /// 从传感器监视计算机运行状态的类<br/>
    /// 可获取处理器、内存、硬盘等硬件的运行情况(其实也可以读配置,bushi)<br/>
    /// 使用者必须持有<see cref="ComputerMonitor"/>对象，否则各成员传感器将随本对象一并析构!!<br/>
    /// 是<see cref="LibreHardwareMonitor.Hardware">的wrapper
    /// </summary>
    public static class ComputerMonitor
    {
        public static readonly List<CpuMonitor> CpuMonitorList;
        public static readonly MemoryMonitor? MemoryMonitor;//所有内存被视为一个整体
        public static readonly List<DriveMonitor> DriveMonitorList;
        public static readonly List<FanMonitor> FanMonitorList;
        public static readonly List<NetAdapterMonitor> NetAdapterMonitorList;

        private static readonly Computer computer;

        static ComputerMonitor()
        {
            computer = new()
            {
                IsCpuEnabled = true,
                IsMemoryEnabled = true,
                IsStorageEnabled = true,
                IsControllerEnabled = true,
                IsMotherboardEnabled = true,
                IsNetworkEnabled = true
            };

            CpuMonitorList = new();
            DriveMonitorList = new();
            FanMonitorList = new();
            NetAdapterMonitorList = new();
            MemoryMonitor = null;

            computer.Open();
            computer.Accept(new UpdateVisitor());

            IHardware? motherboard = null;
            foreach (var hardware in computer.Hardware)
            {
                if (hardware.HardwareType == HardwareType.Cpu)
                    CpuMonitorList.Add(new(hardware));
                else if (hardware.HardwareType == HardwareType.Memory)
                    MemoryMonitor = new(hardware);
                else if (hardware.HardwareType == HardwareType.Storage)
                    DriveMonitorList.Add(new(hardware));
                else if (hardware.HardwareType == HardwareType.Motherboard)
                    motherboard = hardware;
                else if (hardware.HardwareType == HardwareType.Network)
                    NetAdapterMonitorList.Add(new(hardware));
            }

            FanMonitorList.Add(new FanMonitor(motherboard!, CpuMonitorList[0]));

        }
    }
}