using LibreHardwareMonitor.Hardware;

namespace MyTool.Monitor
{
    /// <summary>
    /// 单个处理器监视器
    /// </summary>
    public class CpuMonitor
    {
        private readonly IHardware _cpu;

        /// <summary>
        /// 更新传感器各项数据
        /// </summary>
        public void Update()
        {
            lock (_cpu)
            {
                _cpu.Update();
            }
        }

        /// <summary>
        /// 处理器名字
        /// </summary>
        public readonly string Name;
        
        /// <summary>
        /// 使用率,单位:%
        /// </summary>
        public ISensor? Usage { get; init; }
        
        /// <summary>
        /// 各核心时钟频率,单位:兆赫兹
        /// </summary>
        public List<ISensor> Clocks { get; init; }
        
        /// <summary>
        /// 最高核心温度,单位:摄氏度
        /// </summary>
        public ISensor? MaxTemperature { get; init; }
        
        /// <summary>
        /// 处理器总功耗,单位:瓦
        /// </summary>
        public ISensor? Power { get; init; }

        
        internal CpuMonitor(IHardware cpu)
        {
            Name = cpu.Name;
            _cpu = cpu;
            Clocks = new();
            foreach(var sensor in _cpu.Sensors)
            {
                if (sensor.SensorType == SensorType.Load && sensor.Name == "CPU Total")
                    Usage = sensor;
                else if (sensor.SensorType == SensorType.Temperature && sensor.Name == "Core Max")
                    MaxTemperature = sensor;
                else if (sensor.SensorType == SensorType.Clock && sensor.Name.ToLower().Contains("core")) 
                    Clocks.Add(sensor);
                else if (sensor.SensorType == SensorType.Power && sensor.Name == "CPU Package")
                    Power = sensor;
            }
        }
    }
}
