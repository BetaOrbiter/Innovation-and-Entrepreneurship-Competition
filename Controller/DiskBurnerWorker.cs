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

        private static readonly List<string> testFilePath = new();
        private static readonly List<string> entityDisks = new();
        public static void Work()
        {
            //读取硬盘和盘符
            GetDiskVolumes();
            InitUI(entityDisks, 60);
            //开启硬盘压力测试
            //一半时间高读写量测试
            MyTool.DiskStresser diskStresser = new(@"C:\Users\刘星辰\Desktop\服创大赛\x64\diskspd.exe", testFilePath, 30, 4 * 1024 * 1024);
            //diskStresser.Start();
            //diskStresser.WaitForExit();
            //一半时间高IOPS测试
            diskStresser = new(@"C:\Users\刘星辰\Desktop\服创大赛\x64\diskspd.exe", testFilePath, 30, 4 * 1024);
            //diskStresser.Start();
            //diskStresser.WaitForExit();
            Thread.Sleep(3000);
            UpdateResultUI();
        }
        private static void GetDiskVolumes()
        {
            //读取物理硬盘和盘符
            HardwareInformation info = new();
            info.RefreshDriveList();
            int index = 0;
            foreach (var disk in info.DriveList)
            {
                foreach (var part in disk.PartitionList)
                {
                    bool flag = false;
                    foreach (var volume in part.VolumeList)
                    {
                        index++;
                        flag = true;
                        testFilePath.Add(volume.Name.TrimEnd() + "/testfile" + index + ".dat");
                    
                        entityDisks.Add(disk.Model.TrimEnd());
                        break;
                    }
                    if (flag) break;
                }
            }
            
        }
    }
}
