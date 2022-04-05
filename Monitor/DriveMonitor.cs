using LibreHardwareMonitor.Hardware;

namespace MyTool.Monitor
{
    /// <summary>
    /// 单块硬盘监视器
    /// </summary>
    public class DriveMonitor
    {
        private readonly IHardware _drive;

        /// <summary>
        /// 更新传感器各项数据
        /// </summary>
        public void Update()
        {
            lock (_drive)
            {
                _drive.Update();
            }
        }

        /// <summary>
        /// 磁盘驱动器名字
        /// </summary>
        public readonly string Name;
        
        /// <summary>
        /// 存储空间使用率,单位:%
        /// </summary>
        public ISensor? Usage { get; init; }

        /// <summary>
        /// 硬盘写占用率,单位:%
        /// </summary>
        public ISensor? WriteActivity { get; init; }

        /// <summary>
        /// 硬盘总占用率,单位:%
        /// </summary>
        public ISensor? TotalActivity { get; init; }

        /// <summary>
        /// 当前读速,单位:字节/秒
        /// </summary>
        public ISensor? ReadRate { get; init; }

        /// <summary>
        /// 当前写速,单位:字节/秒
        /// </summary>
        public ISensor? WriteRate { get; init; }
        
        internal DriveMonitor(IHardware drive)
        {
            Name = drive.Name;
            _drive = drive;
            foreach (var sensor in _drive.Sensors)
            {
                if (sensor.SensorType == SensorType.Load && sensor.Name == "Used Space")
                    Usage = sensor;
                else if (sensor.SensorType == SensorType.Load && sensor.Name == "Write Activity")
                    WriteActivity = sensor;
                else if (sensor.SensorType == SensorType.Load && sensor.Name == "Total Activity")
                    TotalActivity = sensor;
                else if (sensor.SensorType == SensorType.Throughput && sensor.Name == "Read Rate")
                    ReadRate = sensor;
                else if (sensor.SensorType == SensorType.Throughput && sensor.Name == "Write Rate")
                    WriteRate = sensor;
            }
        }
    }
}
