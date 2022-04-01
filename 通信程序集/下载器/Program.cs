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
                   setting["profileName"]!, setting["indexName"]!};

//开启四个线程分别下载主程序、处理器烤机、内存烤机、硬盘烤机
Config config;
for (int i = 0; i < 4; i++)
{
    Thread thread = new(DownloadTask);
    config.Port = ports[i];
    config.Name = names[i];
    DownloadTask(config);
}


//配置文件需要特殊处理(包头有待测机编号)
using Socket socket = new(SocketType.Stream, ProtocolType.Tcp);
socket.Connect(remoteIp, ports[4]);

//接受包头文件编号
byte[] indexByte = new byte[sizeof(int)];
int byteRead = 0;
do{
    byteRead += socket.Receive(indexByte, byteRead, indexByte.Length - byteRead, SocketFlags.Peek);
} while (byteRead < indexByte.Length);
//写入编号文件(我知道这很丑但我摆烂了。。。。)
using var indexFile = File.Create(names[5], indexByte.Length, FileOptions.WriteThrough);
indexFile.Write(indexByte);

//接收配置文件
using var output = File.Create(names[4]);
var buffer = new byte[1500];
while ((byteRead = socket.Receive(buffer)) > 0)
{
    output.Write(buffer, 0, byteRead);
}

socket.Shutdown(SocketShutdown.Both);



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