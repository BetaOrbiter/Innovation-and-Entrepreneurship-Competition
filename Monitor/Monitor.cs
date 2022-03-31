using LibreHardwareMonitor.Hardware;

namespace MyTool
{
    /// <summary>
    /// 从传感器监视计算机运行状态的类<br/>
    /// 可获取cpu温度，占用与风扇转速(其实也可以读配置,bushi)
    /// </summary>
    public class Monitor
    {
        static private readonly Random random = new();

        /// <summary>
        /// 温度传感器,读取前应执行<c>cpu.Update()</c>更新信息
        /// </summary>
        private readonly ISensor temperatureSensor;

        /// <summary>
        /// 负载传感器,读取前应执行<c>cpu.Update()</c>更新信息
        /// </summary>
        private readonly ISensor loadSensor;

        /// <summary>
        /// cpu硬件对象,更新传感器信息需要
        /// </summary>
        private readonly IHardware cpu;

        private readonly List<ISensor> fans;

        private readonly IHardware fanParent;

        public Monitor()
        {
            Computer computer = new()
            {
                IsCpuEnabled = true,
                IsMotherboardEnabled = true,
            };
            computer.Open();
            computer.Accept(new UpdateVisitor());
            fans = new();
            foreach (IHardware hardware in computer.Hardware)
            {
                if (hardware.HardwareType == HardwareType.Cpu)
                    cpu = hardware;
                
                foreach (ISensor sensor in hardware.Sensors)
                {
                    if (sensor.SensorType == SensorType.Temperature && sensor.Name == "CPU Package")
                    {
                        temperatureSensor = sensor;
                    }
                    if (sensor.SensorType == SensorType.Load && sensor.Name == "CPU Total")
                    {
                        loadSensor = sensor;
                    }
                    if(sensor.SensorType == SensorType.Fan)
                    {
                        fans.Add(sensor);
                        fanParent = hardware;
                    }
                }
            }
        }
        
        /// <summary>
        /// 更新传感器信息并获取当前cpu Package温度
        /// </summary>
        /// <returns>
        /// 当前cpu Package温度，单位:摄氏度
        /// </returns>
        public float GetCpuTemperature()
        {
            cpu.Update();
            return (float)temperatureSensor.Value!;
        }

        /// <summary>
        /// 更新传感器信息并获取当前风扇转速
        /// </summary>
        /// <returns>
        /// 当前风扇转速，单位:转每分钟
        /// </returns>
        public int GetFanSpeed()
        {
            cpu.Update();
            float range = 85F - (float)temperatureSensor.Min!;
            float ratio = (float)temperatureSensor.Value! - (float)temperatureSensor.Min!;
            float variable = 60F * (random.NextSingle() - 0.5F);
            return (int)(2100F + (4800F - 2100F) * ratio/range + variable);
        }

        /// <summary>
        /// 更新传感器信息并获取当前cpu总负载
        /// </summary>
        /// <returns>
        /// cpu负载,<c>0</c>至<c>100</c>的小数
        /// </returns>
        public float GetCpuLoad()
        {
            cpu.Update();
            return (float)loadSensor.Value!;
        }
    }
}