using Hardware.Info;
using System.IO.Ports;

namespace Controller
{
    public static class USBAndSerialPortChecker
    {
        public static Action<List<Tuple<string,ulong>>> InitUSBUI;

        public static Action<List<string>> InitSerialPortUI;

        public static Action<bool> UpdateProgressUI;

        public static Action UpdateResultUI;

        public static readonly List<string> usbVolumes = new();
        public static int usbNumber;
        public static List<string> serialPortNames;
        private static Dictionary<TestType, bool> testTypes;
        private static readonly List<Tuple<string, ulong>> entityUsb = new();

        public static ManualResetEvent stopSignal;

        private const long magicNumber = 0x3f3f3f3f3f3f3f3f;
        public static void Work(object? _testTypes)
        {
            testTypes = (Dictionary<TestType, bool>)_testTypes;
            //usb接口测试
            if (testTypes[TestType.USBTest])
            {
                //获取物理U盘
                GetUSBVolumes();
                //if (Profile.Configuration.GetInstance().UsbNumber == usbNumber) ;
                InitUSBUI(entityUsb);
                int index = 0;
                //开始测试
                if (usbVolumes.Count > 0)
                    ProgressChanger.Update(TestType.USBTest, index, usbVolumes.Count);
                foreach (var usbVolume in usbVolumes)
                {
                    var flag = UsbPortCheck(usbVolume);
                    LogRecord(1, index, flag);
                    index++;
                    UpdateProgressUI(flag);
                    ProgressChanger.Update(TestType.USBTest, index, usbVolumes.Count);
                    Thread.Sleep(2000);
                    _ = stopSignal.WaitOne();
                }
                Thread.Sleep(3000);
                _ = stopSignal.WaitOne();
            }
            //串口测试
            if (testTypes[TestType.SerialPortTest])
            {
                //获取串口
                GetSerialPort();
                //if (Profile.Configuration.GetInstance().SerialPortNumber == serialPortNames.Count) ;

                InitSerialPortUI(serialPortNames);
                int index = 0;
                if (serialPortNames.Count > 0)
                    ProgressChanger.Update(TestType.SerialPortTest, index, serialPortNames.Count);
                //开始测试
                foreach (var serialPortName in serialPortNames)
                {
                    var flag = SerialPortCheck(serialPortName);
                    LogRecord(2, index, flag);
                    index++;
                    UpdateProgressUI(flag);
                    ProgressChanger.Update(TestType.SerialPortTest, index, serialPortNames.Count);
                    Thread.Sleep(2000);
                    _ = stopSignal.WaitOne();
                }
                Thread.Sleep(3000);
                _ = stopSignal.WaitOne();
            }
            UpdateResultUI();
        }
        private static bool UsbPortCheck(string volume)
        {
            for(int i = 1; i <= 5; i++)
            {
                var writeStream = File.OpenWrite(Path.Combine(volume, "test.dat"));
                writeStream.Write(BitConverter.GetBytes(magicNumber));
                writeStream.Dispose();

                var bytes = File.ReadAllBytes(Path.Combine(volume, "test.dat"));
                File.Delete(Path.Combine(volume, "test.dat"));
                if (magicNumber != BitConverter.ToInt64(bytes))
                    return false;
                Thread.Sleep(1000);
            }
            return true;
        }
        private static void GetUSBVolumes()
        {
            //读取物理硬盘和盘符
            HardwareInformation info = new();
            info.RefreshDriveList();
            usbNumber = info.UsbDsikList.Count;
            foreach (var usb in info.UsbDsikList)
            {
                foreach (var part in usb.PartitionList)
                {
                    bool flag = false;
                    foreach (var volume in part.VolumeList)
                    {
                        flag = true;
                        usbVolumes.Add(volume.Name.TrimEnd());
                        entityUsb.Add(new(usb.Model.TrimEnd(), usb.Size / (1024 * 1024 * 1024)));
                        break;
                    }
                    if (flag) break;
                }
            }
        }
        private static void GetSerialPort()
        {
            serialPortNames = SerialPort.GetPortNames().ToList();
        }
        private static bool SerialPortCheck(string serialPortName)
        {
          SerialPort serialPort = new(serialPortName, 57600, Parity.None, 8, StopBits.One);
            if (!serialPort.IsOpen)
                serialPort.Open();
          for(int i = 1; i <= 5; i++)
            {
                serialPort.WriteLine(magicNumber.ToString());
                if (serialPort.ReadLine() != magicNumber.ToString())
                    return false;
                Thread.Sleep(1000);
            }
          if(serialPort.IsOpen)
            serialPort.Close();
            return true;
        }

        private static void LogRecord(int step,int index,bool flag)
        {
            if (flag)
            {
                MyTool.Log.GetInstance().Record(MyTool.LogType.Success, $"{(step == 1 ? "USB接口" : "串口")}{index}测试通过");
            }
            else
            {
                MyTool.Log.GetInstance().Record(MyTool.LogType.Error, $"{(step == 1 ? "USB接口" : "串口")}{index}测试通过");
            }
        }
    }
}
