using System.Net;
using System.Net.Sockets;
using Profile;

var setting = System.Configuration.ConfigurationManager.AppSettings;

//获取App.config中的各项配置
IPAddress remoteIp = IPAddress.Parse(setting["listenIp"]!);
int[] ports = { int.Parse(setting["mainPort"]!),  int.Parse(setting["cpuPort"]!),
                int.Parse(setting["memPort"]!),   int.Parse(setting["diskPort"]!),
                int.Parse(setting["profilePort"]!)};
string[] names = { setting["mainPath"]!,    setting["cpuPath"]!,
                   setting["memPath"]!,     setting["diskPath"]!,
                   setting["profilePath"]!};

Task[] tasks = new Task[5];
//开启五个线程分别下载主程序、处理器烤机、内存烤机、硬盘烤机、配置文件
for (int i = 0; i < 5; i++)
    tasks[i] = Task.Factory.StartNew(DownloadTask, (ports[i], names[i]));
//等待全部完成
foreach (var task in tasks)
    task.Wait();

//修改配置文件中的一些路径
var profile =  Configuration.GetInstance(names[4]);
profile.Cpu_burnerPath = names[1];
profile.Memory_burnerPath = names[2];
profile.DiskspdPath = names[3];
using var stream = new StreamWriter(names[4]);
profile.Print(stream);

System.Diagnostics.Process.Start(names[0]);

//下载一个文件的线程
void DownloadTask(object? obj)
{
    var config = (ValueTuple<int, string>)obj;
    byte[] buffer = new byte[1500];
    using var stream = File.Create(config.Item2, buffer.Length, FileOptions.SequentialScan);
    using var socket = new Socket(SocketType.Stream, ProtocolType.Tcp);

    socket.Connect(remoteIp, config.Item1);
    int read;
    while ((read = socket.Receive(buffer)) != 0)
        stream.Write(buffer, 0, read);
    socket.Shutdown(SocketShutdown.Both);
}