using LibreHardwareMonitor.Hardware;
namespace MyTool.Monitor
{
    /// <summary>
    /// 单张网卡监视器
    /// </summary>
    public class NetAdapterMonitor
    {
        private readonly IHardware _networkAdapter;

        /// <summary>
        /// 更新传感器各项数据<br/>
        /// 与其他监视器不同,网卡更新后需一段时间获取值,具体时间未试出,暂定为100毫秒
        /// </summary>
        /// <param name="milionSecond"></param>
        public void Update(int milionSecond = 100)
        {

            lock (_networkAdapter)
            {
                _networkAdapter.Update();
                Thread.Sleep(milionSecond);

                //TotalDownloaded += Downloaded!.Value;
                //TotalUploaded += Uploaded!.Value;
            }
        }

        /// <summary>
        /// (暂时废弃)前次<see cref="WatchFor(int)"/>后上传数据量,单位:字节
        /// </summary>
        internal ISensor? Uploaded { get; init; }

        /// <summary>
        /// (暂时废弃)前次<see cref="WatchFor(int)"/>后下载数据量,单位:字节
        /// </summary>
        internal ISensor? Downloaded { get; init; }

        /// <summary>
        /// (暂时废弃)总上传量,单位:字节
        /// </summary>
        internal float? TotalDownloaded = 0f;

        /// <summary>
        /// (暂时废弃)总下载量,单位:字节
        /// </summary>
        internal float? TotalUploaded = 0f;

        /// <summary>
        /// 网卡名
        /// </summary>
        public readonly string Name;
        
        /// <summary>
        /// 上传速度,单位:字节/秒
        /// </summary>
        public ISensor? UploadSpeed { get; init; }
        
        /// <summary>
        /// 上传速度,单位:字节/秒
        /// </summary>
        public ISensor? DownloadSpeed { get; init; }
        
        /// <summary>
        /// 占用率,单位:%
        /// </summary>
        public ISensor? Usage { get; init; }

        public NetAdapterMonitor(IHardware networkAdapter)
        {
            Name = networkAdapter.Name;
            _networkAdapter = networkAdapter;
            foreach (var sensor in _networkAdapter.Sensors)
            {
                if (sensor.SensorType == SensorType.Data && sensor.Name == "Data Uploaded")
                    Uploaded = sensor;
                else if (sensor.SensorType == SensorType.Data && sensor.Name == "Data Downloaded")
                    Downloaded = sensor;
                else if (sensor.SensorType == SensorType.Throughput && sensor.Name == "Upload Speed")
                    UploadSpeed = sensor;
                else if (sensor.SensorType == SensorType.Throughput && sensor.Name == "Download Speed")
                    DownloadSpeed = sensor;
                else if (sensor.SensorType == SensorType.Load && sensor.Name == "Network Utilization")
                    Usage = sensor;
            }
        }
    }
}
