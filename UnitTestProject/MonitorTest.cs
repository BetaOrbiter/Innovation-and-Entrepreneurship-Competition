using LibreHardwareMonitor.Hardware;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyTool.Monitor;
using System;

namespace UnitTestProject
{
    [TestClass]
    public class MonitorTest
    {
        private const int cpuNumber = 1;
        private const int corePerCpu = 6;
        private const int DriveNumber = 1;
        private const int fanNumber = 1;
        private const int networkNumber = 2;

        [TestMethod]
        public void TestNetAdapterMonitor()
        {
            Assert.IsNotNull(ComputerMonitor.NetAdapterMonitorList);
            foreach (var i in ComputerMonitor.NetAdapterMonitorList)
                Console.WriteLine(i.Name);
            Assert.AreEqual(networkNumber, ComputerMonitor.NetAdapterMonitorList.Count);
            foreach (var network in ComputerMonitor.NetAdapterMonitorList)
            {
                Assert.IsNotNull(network);
                Assert.IsNotNull(network.Name);
                Assert.IsNotNull(network.Downloaded);
                Assert.IsNotNull(network.Uploaded);
                Assert.IsNotNull(network.DownloadSpeed);
                Assert.IsNotNull(network.UploadSpeed);
                Assert.IsNotNull(network.Usage);
            }
        }

        [TestMethod]
        public void TestCpuMonitor()
        {
            Assert.IsNotNull(ComputerMonitor.CpuMonitorList);
            Assert.AreEqual(cpuNumber, ComputerMonitor.CpuMonitorList.Count);

            foreach (var cpu in ComputerMonitor.CpuMonitorList)
            {
                Assert.IsNotNull(cpu);
                Assert.IsNotNull(cpu.Name);
                Assert.IsNotNull(cpu.Clocks);
                Assert.IsNotNull(cpu.Power);
                Assert.IsNotNull(cpu.MaxTemperature);
                Assert.IsNotNull(cpu.Usage);

                Assert.AreEqual(corePerCpu, cpu.Clocks.Count);
                foreach (var core in cpu.Clocks)
                    Assert.IsNotNull(core);
            }
        }

        [TestMethod]
        public void TestFanMonitor()
        {
            Assert.IsNotNull(ComputerMonitor.FanMonitorList);
            Assert.AreEqual(fanNumber, ComputerMonitor.FanMonitorList.Count);
            foreach (var fan in ComputerMonitor.FanMonitorList)
            {
                Assert.IsNotNull(fan);
                Assert.IsNotNull(fan.Speed);
            }
        }

        [TestMethod]
        public void TestMemoryMonitor()
        {
            Assert.IsNotNull(ComputerMonitor.MemoryMonitor);
            var mem = ComputerMonitor.MemoryMonitor;
            Assert.IsNotNull(mem);
            Assert.IsNotNull(mem.Name);
            Assert.IsNotNull(mem.Usage);
            mem.Update();
            Console.WriteLine(mem.Name);
            Console.WriteLine(mem.Usage.Value);
        }

        [TestMethod]
        public void TestDriveMonitor()
        {
            Assert.IsNotNull(ComputerMonitor.DriveMonitorList);
            Assert.AreEqual(DriveNumber, ComputerMonitor.DriveMonitorList.Count);
            foreach (var drive in ComputerMonitor.DriveMonitorList)
            {
                Assert.IsNotNull(drive);
                Assert.IsNotNull(drive.Usage);
                Assert.IsNotNull(drive.WriteActivity);
                Assert.IsNotNull(drive.TotalActivity);
                Assert.IsNotNull(drive.ReadRate);
                Assert.IsNotNull(drive.WriteRate);
            }
        }

        [TestMethod]
        public void ReadAllData()
        {
            //System.Threading.Thread.Sleep(4000);
            const string format = "\t{0}:{1}";
            //读取cpu
            Console.WriteLine("CPU:");
            foreach (var cpu in ComputerMonitor.CpuMonitorList)
            {
                cpu.Update();
                Console.WriteLine(cpu.Name);
                Console.WriteLine(format, cpu.Usage!.Name, cpu.Usage!.Value);

                Console.WriteLine("\tClocks:");
                foreach (var core in cpu.Clocks)
                    Console.WriteLine("\t\t{0}:{1}", core.Name, core.Value);

                Console.WriteLine(format, cpu.Power!.Name, cpu.Power!.Value);
                Console.WriteLine(format, cpu.MaxTemperature!.Name, cpu.MaxTemperature!.Value);
            }

            //读取硬盘
            Console.WriteLine("Drive:");
            foreach (var drive in ComputerMonitor.DriveMonitorList)
            {
                drive.Update();
                Console.WriteLine(drive.Name);
                Console.WriteLine(format, drive.Usage!.Name, drive.Usage!.Value);
                Console.WriteLine(format, drive.WriteActivity!.Name, drive.WriteActivity!.Value);
                Console.WriteLine(format, drive.TotalActivity!.Name, drive.TotalActivity!.Value);
                Console.WriteLine(format, drive.WriteRate!.Name, drive.WriteRate!.Value);
                Console.WriteLine(format, drive.ReadRate!.Name, drive.ReadRate!.Value);
            }

            //读取风扇
            Console.WriteLine("Fan:");
            foreach (var fan in ComputerMonitor.FanMonitorList)
            {
                fan.Update();
                Console.WriteLine("\t{0}", fan.Speed!.Value);
            }

            //读取内存
            Console.WriteLine("Memory:");
            var mem = ComputerMonitor.MemoryMonitor!;
            mem.Update();
            Console.WriteLine(format, mem.Usage!.Name, mem.Usage.Value);

            //读取网卡
            Console.WriteLine("network:");
            foreach (var net in ComputerMonitor.NetAdapterMonitorList)
            {
                //if (!net.Name.Equals("WLAN"))
                //    continue;
                net.Update();
                Console.WriteLine(net.Name);
                Console.WriteLine(format, net.Usage!.Name, net.Usage!.Value);
                Console.WriteLine(format, net.UploadSpeed!.Name, net.UploadSpeed!.Value);
                Console.WriteLine(format, net.DownloadSpeed!.Name, net.DownloadSpeed!.Value);
            }
        }

        /// <summary>
        /// 输出本机能获取的所有传感器，必须单独进行
        /// </summary>
        //[TestMethod]
        public void GetAllSensor()
        {
            Computer computer = new()
            {
                IsCpuEnabled = true,
                IsGpuEnabled = true,
                IsMemoryEnabled = true,
                IsMotherboardEnabled = true,
                IsControllerEnabled = true,
                IsNetworkEnabled = true,
                IsStorageEnabled = true,
                IsPsuEnabled = true
            };

            computer.Open();
            computer.Accept(new UpdateVisitor());

            foreach (IHardware hardware in computer.Hardware)
            {
                Console.WriteLine("Hardware: {0}", hardware.Name);

                foreach (IHardware subhardware in hardware.SubHardware)
                {
                    Console.WriteLine("\tSubhardware: {0}", subhardware.Name);
                    subhardware.Update();
                    foreach (ISensor sensor in subhardware.Sensors)
                    {
                        Console.WriteLine("\t\tSensor: {0}, Type: {1}, Value: {2}", sensor.Name, sensor.SensorType.ToString(), sensor.Value);
                    }
                }
                hardware.Update();
                foreach (ISensor sensor in hardware.Sensors)
                {
                    Console.WriteLine("\tSensor: {0},  Type: {1}, Value: {2}", sensor.Name, sensor.SensorType.ToString(), sensor.Value);
                }
            }

            computer.Close();
        }
    }
}
