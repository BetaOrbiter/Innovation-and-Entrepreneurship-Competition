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
            program.StartInfo.FileName = @"C:\Windows\System32\chkdsk.exe";
            program.StartInfo.CreateNoWindow = true;

            int index = 0;
            ProgressChanger.Update(TestType.DiskBadTest, index, disks.Count);
            foreach (var disk in disks)
            {
                program.StartInfo.Arguments = disk.Item2;
                //UpdateProgressUI(true);

                program.Start();
                program.WaitForExit();
                
                if (program.ExitCode == 0)
                {
                    MyTool.Log.GetInstance().Record(MyTool.LogType.Success, $"硬盘{index} {entityDisks[index].Item1}无坏道");
                    UpdateProgressUI(true);
                    ProgressChanger.Update(TestType.DiskBadTest, index+1, disks.Count);
                }
                else
                {
                    MyTool.Log.GetInstance().Record(MyTool.LogType.Error, $"硬盘{index} {entityDisks[index].Item1}有坏道");
                    UpdateProgressUI(false);
                    ProgressChanger.Update(TestType.DiskBadTest, index+1, disks.Count);
                }
                index++;
                Thread.Sleep(1500);
            }
            Thread.Sleep(3000);
            program.Dispose();
            UpdateResultUI();
            
        }
        private static void GetDiskVolumes()
        {
            //读取物理硬盘和盘符
            HardwareInformation info = new();
            info.RefreshDriveList();
            foreach (var disk in info.DiskList)
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
