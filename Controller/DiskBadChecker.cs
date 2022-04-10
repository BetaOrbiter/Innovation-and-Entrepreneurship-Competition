using Hardware.Info;
using System.Diagnostics;

namespace Controller
{
    //硬盘坏道检测总控线程类

    public static class DiskBadChecker
    {

        public static Action<List<Tuple<string,ulong>>> InitUI;

        public static Action<bool> UpdateProgressUI;

        public static Action UpdateResultUI;

        private static readonly List<Tuple<string, string>> disks = new();
        private static readonly List<Tuple<string, ulong>> entityDisks = new();
        public static void Work()
        {
            //读取物理硬盘和盘符
            GetDiskVolumes();
           
            //运行坏道测试
            Process program = new();
            foreach(var disk in disks)
            {
                program.StartInfo.FileName = @"C:\Windows\System32\chkdsk.exe";
                program.StartInfo.Arguments = disk.Item2;
                program.StartInfo.CreateNoWindow = true;

                //program.Start();
                //program.WaitForExit();
                UpdateProgressUI(true);
                //if (program.ExitCode == 0)
                //{
                //    UpdateProgressUI(true);
                //}
                //else
                //{
                //    UpdateProgressUI(false);
                //}
                Thread.Sleep(2000);
            }
            UpdateResultUI();

        }
        private static void GetDiskVolumes()
        {
            //读取物理硬盘和盘符
            HardwareInformation info = new();
            info.RefreshDriveList();
            foreach (var disk in info.DriveList)
            {
                foreach (var part in disk.PartitionList)
                {
                    bool flag = false;
                    foreach (var volume in part.VolumeList)
                    {
                        flag = true;
                        disks.Add(new(disk.Model.TrimEnd(), volume.Name.TrimEnd()));
                        entityDisks.Add(new(disk.Model.TrimEnd(), disk.Size / (1024 * 1024 * 1024)));
                        break;
                    }
                    if (flag) break;
                }
            }
            InitUI(entityDisks);
        }
    }
}
