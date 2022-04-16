using Newtonsoft.Json;

namespace Server
{
    public class ServerSetting
    {
        [JsonProperty(PropertyName = "listenIp")]
        public string ListenIP { get; set; }

        [JsonProperty(PropertyName = "mainPort")]
        public int MainPort { get; set; }

        [JsonProperty(PropertyName = "cpuBurnerPort")]
        public int CpuStresserPort { get; set; }

        [JsonProperty(PropertyName = "memBurnerPort")]
        public int MemStresserPort { get; set; }

        [JsonProperty(PropertyName = "diskBurnerPort")]
        public int DiskStresserPort { get; set; }

        [JsonProperty(PropertyName = "profilePort")]
        public int ProfilePort { get; set; }

        [JsonProperty(PropertyName = "rtcPort")]
        public int RtcPort { get; set; }

        [JsonProperty(PropertyName = "logPort")]
        public int LogPort { get; set; }

        [JsonProperty(PropertyName = "mainPath")]
        public string mainPath { get; set; }

        [JsonProperty(PropertyName = "cpuBurnerPath")]
        public string CpuStresserPath { get; set; }

        [JsonProperty(PropertyName = "memBurnerPath")]
        public string MemStresserPath { get; set; }

        [JsonProperty(PropertyName = "diskBurnerPath")]
        public string DiskStresserPath { get; set; }

        [JsonProperty(PropertyName = "profilePath")]
        public string ProfilePath { get; set; }

        [JsonProperty(PropertyName = "logFolder")]
        public string LogFolder { get; set; }

        public static ServerSetting uniqueInstance = JsonConvert.DeserializeObject<ServerSetting>(File.ReadAllText("ServerSetting.json"));

        public static ServerSetting GetInstance() => uniqueInstance;
    }
}
