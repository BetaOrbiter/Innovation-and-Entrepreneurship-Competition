//主程序，开启四个线程监听测试程序请求，配置请求，rtc请求，上传结果请求（未完成）
using System.Net;
using System.Net.Sockets;
using MyServer;

Int32 fileServerPort = 13000;
Int32 profileServerPort = 13001;
Int32 rtcServerPort = 13002;
Int32 logServerPort = 13003;

IPAddress localIp = IPAddress.Loopback;

Thread fileThread = new(new FileServer(localIp, fileServerPort, "C:/tecent/解压密码wsl.zip").Listen);
fileThread.Start();
Thread rtcThread = new(new RtcServer(localIp, rtcServerPort).Listen);
