using Hardware.Info;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject
{
    [TestClass]
    public class HardwareInfoTest
    {
        const string cpuName = "Intel(R) Core(TM) i7-9750H CPU @ 2.60GHz";
        const int cpuNumber = 1;
        const uint corePerCpu = 6;
        const uint logicPerCpu = 12;

        const int memoryNumber = 2;
        readonly string[] memoryModel = { "KHX2666C15S4/8G     ", "HMA81GS6JJR8N-VK    " };
        readonly string[] memoryManufacturer = { "01980000830B", "80AD000080AD" };
        readonly uint[] memSpeed = {2667, 2667};
        readonly ulong[] memeCapacity = { 8589934592, 8589934592 };
        const FormFactor form = FormFactor.SODIMM;

        const int gpuNumber = 2;
        readonly string[] gpuName = { "Intel(R) UHD Graphics 630", "NVIDIA GeForce GTX 1050" };
        readonly uint[] gpuRam = { 1073741824 , 3221225472 };
        readonly string[] gpuManufacturer = { "Intel Corporation", "NVIDIA" };

        [TestMethod]
        public void TestCPU()
        {
            HardwareInformation info = new();
            info.RefreshCPUList(false);

            Assert.AreEqual(cpuNumber, info.CpuList.Count);

            var cpu = info.CpuList[0];
            Assert.AreEqual(cpuName, cpu.Name);
            Assert.AreEqual(corePerCpu, cpu.NumberOfCores);
            Assert.AreEqual(logicPerCpu, cpu.NumberOfLogicalProcessors);
        }
        [TestMethod]
        public void ReadCPU()
        {
            HardwareInformation info = new();
            info.RefreshCPUList(false);

            Assert.AreEqual(cpuNumber, info.CpuList.Count);

            var cpu = info.CpuList[0];
            Console.WriteLine(cpu);
        }
        [TestMethod]
        public void TestMemeory()
        {
            HardwareInformation info = new();
            info.RefreshMemoryList();

            var mems = info.MemoryList;
            Assert.AreEqual(memoryNumber, mems.Count);
            int i = 0;
            foreach(var mem in mems)
            {
                Assert.AreEqual(form, mem.FormFactor);
                Assert.AreEqual(memoryModel[i], mem.PartNumber);
                Assert.AreEqual(memSpeed[i], mem.Speed);
                Assert.AreEqual(memeCapacity[i], mem.Capacity);
                Assert.AreEqual(memoryManufacturer[i], mem.Manufacturer);
                i++;
            }
        }
        [TestMethod]
        public void ReadMem()
        {
            HardwareInformation info = new();
            info.RefreshMemoryList();

            var mems = info.MemoryList;
            //Assert.AreEqual(memoryNumber, mems.Count);
            int i = 0;
            foreach (var mem in mems)
            {
                Console.WriteLine(mem.PartNumber);
                //Assert.AreEqual(form, mem.FormFactor);
                //Assert.AreEqual(memoryModel[i], mem.PartNumber);
                //Assert.AreEqual(memSpeed[i], mem.Speed);
                //Assert.AreEqual(memeCapacity[i], mem.Capacity);
                //Assert.AreEqual(memoryManufacturer[i], mem.Manufacturer);
                i++;
            }
        }

        [TestMethod]
        public void ReadDrive()
        {
            HardwareInformation info = new();
            info.RefreshDriveList();
            //info.DriveList.Sort((Drive a, Drive b) => { return string.Compare(a.Model, b.Model); });

            Console.WriteLine("Drive list");
            foreach (var disk in info.DriveList)
            {
                
                Console.WriteLine(disk.Model);
                Console.WriteLine(disk.Size);
                foreach (var part in disk.PartitionList)
                {
                    bool flag = false;
                    foreach (var volume in part.VolumeList)
                    {
                        Console.WriteLine(volume.Name);
                        flag = true;
                        break;
                    }
                    if (flag) break;
                }
            }

            Console.WriteLine("usb list");
            foreach (var disk in info.UsbDsikList)
                Console.WriteLine(disk.Model);
            
            Console.WriteLine("disk list");
            foreach (var disk in info.DiskList)
                Console.WriteLine(disk.Model);
            
            Console.WriteLine("smart list");
            foreach (var disk in info.DrivesSMARTs!)
                Console.WriteLine(disk.Model);
        }

        [TestMethod]
        public void TestGpu()
        {
            HardwareInformation info = new();
            info.RefreshVideoControllerList();
            Assert.AreEqual(gpuNumber, info.VideoControllerList.Count);

            int i = 0;
            foreach (var gpu in info.VideoControllerList)
            {
                Assert.AreEqual(gpuName[i], gpu.Name);
                Assert.AreEqual(gpuRam[i], gpu.AdapterRAM);
                Assert.AreEqual(gpuManufacturer[i], gpu.Manufacturer);

                //Console.WriteLine(gpu.Name);
                //Console.WriteLine(gpu.AdapterRAM);
                //Console.WriteLine(gpu.Manufacturer);
                i++;
            }
        }

        [TestMethod]
        public void ReadGpu()
        {
            HardwareInformation info = new();
            info.RefreshVideoControllerList();
            //Assert.AreEqual(gpuNumber, info.VideoControllerList.Count);

            int i = 0;
            foreach (var gpu in info.VideoControllerList)
            {
                Console.WriteLine(gpu.Name);
                i++;
            }
         }
        [TestMethod]
        public void ReadMac()
        {
            HardwareInformation info = new();
            info.RefreshNetworkAdapterList();

            foreach (var net in info.NetworkAdapterList)
            {
                Console.WriteLine(net.Name);
                Console.WriteLine(net.MACAddress);
            }
        }

        [TestMethod]
        public void ReadSmarts()
        {
            HardwareInformation info = new();
            foreach (var drive in info.DrivesSMARTs!)
            {
                Console.WriteLine(drive.Model);
                foreach (var arr in drive.SmartAttributes)
                {
                    Console.WriteLine("\t{0}:{1}", arr.Name, arr.Data);
                }
            }
        }
    }
}