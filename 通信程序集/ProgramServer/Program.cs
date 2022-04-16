//主程序，共七个线程监听测试程序请求，配置请求，rtc请求，上传结果请求
using Server;
using System.Net;

namespace Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var setting = ServerSetting.GetInstance();
            IPAddress listenIp = IPAddress.Parse(setting.ListenIP);

            Thread mainServer = new(new FileServer(listenIp, setting.MainPort, setting.mainPath).Listen);
            mainServer.Start();
            Thread cpuServer = new(new FileServer(listenIp, setting.CpuStresserPort, setting.CpuStresserPath).Listen);
            cpuServer.Start();
            Thread memServer = new(new FileServer(listenIp, setting.MemStresserPort, setting.MemStresserPath).Listen);
            memServer.Start();
            Thread diskServer = new(new FileServer(listenIp, setting.DiskStresserPort, setting.DiskStresserPath).Listen);
            diskServer.Start();

            Thread rtcServer = new(new RtcServer(listenIp, setting.RtcPort).Listen);
            rtcServer.Start();

            Thread profileServer = new(new ProfileServer(listenIp, setting.ProfilePort, setting.ProfilePath, setting.RtcPort, setting.LogPort).Listen);
            profileServer.Start();

            LogServer logServer = new(listenIp, setting.LogPort, setting.LogFolder);
            logServer.Listen();

        }
    }
}