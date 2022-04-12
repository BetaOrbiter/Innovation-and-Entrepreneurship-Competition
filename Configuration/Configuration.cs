using Newtonsoft.Json;

namespace Profile
{
    public sealed class Configuration
    {
        private static Configuration? uniqueInstance;
        private static readonly object locker = new();

        public static Configuration? GetInstance(string filePath = "profile.json")
        {
            if (uniqueInstance == null)
            {
                lock (locker)
                {
                    if (uniqueInstance == null)
                        uniqueInstance = JsonConvert.DeserializeObject<Configuration>(File.ReadAllText(filePath));
                }
            }
            return uniqueInstance;
        }

        private Configuration() { }

        /// <summary>
        /// 向<paramref name="stream"/>写入格式化配置字符串
        /// </summary>
        /// <param name="stream">输出流</param>
        public void Print(StreamWriter stream) => stream.Write(JsonConvert.SerializeObject(this, Formatting.Indented));

        [JsonProperty(PropertyName = "version")]
        public string Version { get; set; }
        
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "remoteIP")]
        public string RemoteIP { get; set; }

        [JsonProperty(PropertyName = "logPort")]
        public int LogPort { get; set; }

        [JsonProperty(PropertyName = "rtcPort")]
        public int RtcPort { get; set; }

        [JsonProperty(PropertyName = "logFileName")]
        public string LogFileName { get; set; }

        [JsonProperty(PropertyName = "cpu_burnerPath")]
        public string Cpu_burnerPath { get; set; }

        [JsonProperty(PropertyName = "memory_burnerPath")]
        public string Memory_burnerPath { get; set; }

        [JsonProperty(PropertyName = "diskspdPath")]
        public string DiskspdPath { get; set; }

        [JsonProperty(PropertyName = "rtcTolerance")]
        public int RtcTolerance { get; set; }

        [JsonProperty(PropertyName ="usbNumber")]
        public int UsbNumber { get; set; }

        [JsonProperty(PropertyName = "CPUConfig")]
        public CPUConfiguration CPUConfig { get; set; }

        [JsonProperty(PropertyName = "memoryConfig")]
        public MemoryConfiguration MemoryConfig { get; set; }

        [JsonProperty(PropertyName = "DriveConfig")]
        public DriveConfiguration DriveConfig { get; set; }

        [JsonProperty(PropertyName = "gpuConfig")]
        public GPUConfiguration GpuConfig { get; set; }
    }
}