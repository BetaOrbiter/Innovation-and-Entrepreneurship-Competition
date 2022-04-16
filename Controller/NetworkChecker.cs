using Hardware.Info;
using System.Net;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;

namespace Controller
{
    public static class NetworkChecker
    {
        public static Action<List<Tuple<string,string,bool>>> UpdateMACCheckUI;

        public static Action UpadteNetPortCheckUI;

        public static Action UpdateResultUI;

        public static MyTool.Log logger = MyTool.Log.GetInstance();

        private static Dictionary<TestType, bool> testTypes;

        public static ManualResetEvent stopSignal;

        public static void Work(object? _testTypes)
        {
            testTypes = (Dictionary<TestType, bool>)_testTypes;
            //网口数据测试
            if (testTypes[TestType.NetworkPortTest])
            {
                Ping ping = new();
                ProgressChanger.Update(TestType.NetworkPortTest, 0, 5);
                for (int i = 1; i <= 5; i++)
                {
                    Thread.Sleep(1200);
                    _ = stopSignal.WaitOne();
                    var reply = ping.Send(IPAddress.Loopback);
                    UpadteNetPortCheckUI();
                    ProgressChanger.Update(TestType.NetworkPortTest, i, 5);
                }
                logger.Record(MyTool.LogType.Success, "网口数据测试通过");
                Thread.Sleep(3000);
                _ = stopSignal.WaitOne();
            }

            //读取MAC地址并进行标准检查
            if (testTypes[TestType.MACAddressTest])
            {
                HardwareInformation info = new();
                _ = stopSignal.WaitOne();
                info.RefreshNetworkAdapterList();
                List<Tuple<string, string, bool>> netIterms = new();
                int index = 0;
                ProgressChanger.Update(TestType.MACAddressTest, index, info.NetworkAdapterList.Count);
                foreach (var net in info.NetworkAdapterList)
                {
                    var flag = MacCheck(net.MACAddress.Replace(":", "-"));
                    if (flag)
                    {
                        logger.Record(MyTool.LogType.Success, $"网卡{index} {net.Name}MAC地址测试通过");
                    }
                    else
                    {
                        logger.Record(MyTool.LogType.Error, $"网卡{index} {net.Name}MAC地址测试未通过");
                    }
                    netIterms.Add(new(
                         net.Name
                        , net.MACAddress.Replace(":", "-")
                        , flag
                        )
                       );
                    _ = stopSignal.WaitOne();
                    index++;
                    ProgressChanger.Update(TestType.NetworkPortTest, index, info.NetworkAdapterList.Count);
                }
                UpdateMACCheckUI(netIterms);
                Thread.Sleep(5000);
                _ = stopSignal.WaitOne();
            }
                
            UpdateResultUI();
        }
        
        private static bool MacCheck(string macAddress)
        {
            Regex r = new(@"^([0-9A-F][0-9A-F]-[0-9A-F][0-9A-F]-[0-9A-F][0-9A-F]-[0-9A-F][0-9A-F]-[0-9A-F][0-9A-F]-[0-9A-F][0-9A-F])$");
            return r.IsMatch(macAddress);
        }
        
    }
}
