using System.Net.Sockets;
using Profile;
using System.Net;


namespace 下载器
{
    public class Program
    {
        private static DownloaderSetting setting = DownloaderSetting.GetInstance();

        public static void Main(string[] args)
        {
            var setting = DownloaderSetting.GetInstance();

            Task[] tasks = new Task[5];

            //开启五个任务分别下载主程序、处理器烤机、内存烤机、硬盘烤机、配置文件
            tasks[0] = Task.Factory.StartNew(DownloadTask, (setting.MainPort, setting.MainName));
            tasks[1] = Task.Factory.StartNew(DownloadTask, (setting.CpuStresserPort, setting.CpuStresserName));
            tasks[2] = Task.Factory.StartNew(DownloadTask, (setting.MemStresserPort, setting.MemStresserName));
            tasks[3] = Task.Factory.StartNew(DownloadTask, (setting.DiskBurnerPort, setting.DiskStresserName));
            tasks[4] = Task.Factory.StartNew(DownloadTask, (setting.ProfilePort, setting.ProfileName));

            //等待全部完成
            foreach (var task in tasks)
                task.Wait();

            //修改配置文件中的一些路径
            var profile = Configuration.GetInstance(setting.ProfileName);
            profile.Cpu_burnerPath = setting.CpuStresserName;
            profile.Memory_burnerPath = setting.MemStresserName;
            profile.DiskspdPath = setting.DiskStresserName;
            using var stream = new StreamWriter(setting.ProfileName);
            profile.Print(stream);

            if(setting.AutoExecute)
            System.Diagnostics.Process.Start(setting.MainName);
        }

        /// <summary>
        /// 下载一个文件的线程
        /// </summary>
        /// <param name="obj"></param>
        private static void DownloadTask(object? obj)
        {
            var config = (ValueTuple<int, string>)obj;
            byte[] buffer = new byte[1500];
            using var stream = File.Create(config.Item2, buffer.Length, FileOptions.SequentialScan);
            using var socket = new Socket(SocketType.Stream, ProtocolType.Tcp);

            socket.Connect(setting.RemoteIP, config.Item1);
            int read;
            while ((read = socket.Receive(buffer)) != 0)
                stream.Write(buffer, 0, read);
            socket.Shutdown(SocketShutdown.Both);
        }
    }
}