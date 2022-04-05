using LibreHardwareMonitor.Hardware;

namespace MyTool.Monitor
{
    /// <summary>
    /// 内存监视器(全体内存卡被视为单个设备)
    /// </summary>
    public class MemoryMonitor
    {
        private readonly IHardware _memory;

        /// <summary>
        /// 更新传感器各项数据
        /// </summary>
        public void Update()
        {
            lock (_memory)
            {
                _memory.Update();
            }
        }

        /// <summary>
        /// 内存设备名
        /// </summary>
        public readonly string Name;

        /// <summary>
        /// 内存占用率,单位:%
        /// </summary>
        public ISensor? Usage{ get; init; }

        internal MemoryMonitor(IHardware memory)
        {
            Name = memory.Name;
            _memory = memory;
            foreach(var sensor in _memory.Sensors)
                if (sensor.SensorType == SensorType.Load && sensor.Name == "Memory")
                    Usage = sensor;
        }
    }
}
