using Hardware.Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Controller
{
    public static class NetworkChecker
    {
        public static Action<List<Tuple<string,string,bool>>> UpdateMACCheckUI;

        public static Action UpadteNetPortCheckUI;

        public static Action UpdateResultUI;
       

        public static void Work()
        {
            //网口数据测试
            Ping ping = new();
            for(int i = 1; i <= 5; i++)
            {
                Thread.Sleep(1000);
                var reply = ping.Send(IPAddress.Loopback);
                UpadteNetPortCheckUI();
                
            }
          
            Thread.Sleep(3000);

            //读取MAC地址并进行标准检查
            HardwareInformation info = new();
            info.RefreshNetworkAdapterList();
            List<Tuple<string, string, bool>> netIterms=new();
            
            foreach (var net in info.NetworkAdapterList)
            {
                netIterms.Add(new(
                     net.Name
                    ,net.MACAddress.Replace(":", "-")
                    ,MacCheck(net.MACAddress.Replace(":", "-"))
                    )
                   );
            }
            UpdateMACCheckUI(netIterms);
            Thread.Sleep(5000);
            UpdateResultUI();
        }
        
        private static bool MacCheck(string macAddress)
        {
            Regex r = new Regex(@"^([0-9A-F][0-9A-F]-[0-9A-F][0-9A-F]-[0-9A-F][0-9A-F]-[0-9A-F][0-9A-F]-[0-9A-F][0-9A-F]-[0-9A-F][0-9A-F])$");
            return r.IsMatch(macAddress);
        }
    }
}
