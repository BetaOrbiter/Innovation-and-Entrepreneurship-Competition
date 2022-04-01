//主程序，共七个线程监听测试程序请求，配置请求，rtc请求，上传结果请求
using Server;
using System.Net;
using System.Configuration;

//读取App.config配置文件
var setting = ConfigurationManager.AppSettings;

IPAddress listenIp = IPAddress.Parse(setting["listenIp"]!);
int mainPort = int.Parse(setting["mainPort"]!);
int cpuPort = int.Parse(setting["cpuPort"]!);
int memPort = int.Parse(setting["memPort"]!);
int diskPort = int.Parse(setting["diskPort"]!);
int profilePort = int.Parse(setting["profilePort"]!);
int rtcPort = int.Parse(setting["rtcPort"]!);
int logPort = int.Parse(setting["logPort"]!);


Thread mainServer = new(new FileServer(listenIp, mainPort, setting["mainPath"]!).Listen);
mainServer.Start();
Thread cpuServer = new(new FileServer(listenIp, cpuPort, setting["cpuPath"]!).Listen);
cpuServer.Start();
Thread memServer = new(new FileServer(listenIp, memPort, setting["memPath"]!).Listen);
memServer.Start();
Thread diskServer = new(new FileServer(listenIp, diskPort, setting["diskPath"]!).Listen);
diskServer.Start();
Thread profileServer = new(new ProfileServer(listenIp, profilePort, setting["profilePath"]!).Listen);
profileServer.Start();

Thread rtcServer = new(new RtcServer(listenIp, rtcPort).Listen);
rtcServer.Start();

LogServer logServer = new(listenIp, logPort, setting["logFloder"]!);
logServer.Listen();