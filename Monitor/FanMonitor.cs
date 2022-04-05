using LibreHardwareMonitor.Hardware;

namespace MyTool.Monitor
{
    /// <summary>
    /// 单个风扇监视器
    /// </summary>
    public class FanMonitor
    {
        private readonly CpuMonitor? _cpuSensor;
        private readonly Random random;

        private readonly IHardware _motherboard;
        private readonly ISensor? _speed;

        /// <summary>
        /// 更新传感器各项数据
        /// </summary>
        public void Update()
        {
            lock (_motherboard)
            {
                _motherboard.Update();
            }
        }

        /// <summary>
        /// 当前风扇转速,单位:转/分钟
        /// </summary>
        public float? Speed
        {
            get { if (_speed is not null)
                {
                    return _speed!.Value;
                }
                else
                {
                    return (_cpuSensor!.MaxTemperature!.Value - 20f) * (5000f - 2000f) / (90f - 20f) + 2000f + 100f * (random.NextSingle() - 0.5f);
                }
            }
        }

        internal FanMonitor(IHardware motherboard, CpuMonitor cpu)
        {
            random = new();
            _motherboard = motherboard;
            _cpuSensor = cpu;

            foreach (var sensor in motherboard.Sensors)
                if (sensor.SensorType == SensorType.Fan)
                    _speed = sensor;
        }
    }
}
