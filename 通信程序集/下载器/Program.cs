using System.Net;
using System.Net.Sockets;

var setting = System.Configuration.ConfigurationManager.AppSettings;

//获取App.config中的各项配置
IPAddress remoteIp = IPAddress.Parse(setting["listenIp"]!);
int[] ports = { int.Parse(setting["mainPort"]!),  int.Parse(setting["cpuPort"]!),
                int.Parse(setting["memPort"]!),   int.Parse(setting["diskPort"]!),
                int.Parse(setting["profilePort"]!)};
string[] names = { setting["mainName"]!,    setting["cpuName"]!,
                   setting["memName"]!,     setting["diskName"]!,
                   setting["profileName"]!};
Task[] tasks = new Task[5];

//开启五个线程分别下载主程序、处理器烤机、内存烤机、硬盘烤机、配置文件
Config config;
for (int i = 0; i < 5; i++)
{
    config.Port = ports[i];
    config.Name = names[i];
    tasks[i] = Task.Factory.StartNew(DownloadTask, (object)config);
}
//等待全部完成
foreach (var task in tasks)
    task.Wait();

//下载一个文件的线程
void DownloadTask(object? obj)
{
    Config config = (Config)obj!;
    byte[] buffer = new byte[1500];
    using var stream = File.Create(config.Name, buffer.Length, FileOptions.SequentialScan);
    using var socket = new Socket(SocketType.Stream, ProtocolType.Tcp);

    socket.Connect(remoteIp, config.Port);
    int read;
    while ((read = socket.Receive(buffer)) != 0)
        stream.Write(buffer, 0, read);
    socket.Shutdown(SocketShutdown.Both);
}
struct Config
{
    internal int Port;
    internal string Name;
};