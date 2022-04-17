using Newtonsoft.Json;

namespace 下载器
{
    public class DownloaderSetting
    {
        [JsonProperty(PropertyName = "remoteIp")]
        public string RemoteIP { get; set; }

        [JsonProperty(PropertyName = "mainPort")]
        public int MainPort { get; set; }

        [JsonProperty(PropertyName = "cpuBurnerPort")]
        public int CpuStresserPort { get; set; }

        [JsonProperty(PropertyName = "memBurnerPort")]
        public int MemStresserPort { get; set; }

        [JsonProperty(PropertyName = "diskBurnerPort")]
        public int DiskBurnerPort { get; set; }

        [JsonProperty(PropertyName = "profilePort")]
        public int ProfilePort { get; set; }

        [JsonProperty(PropertyName = "mainName")]
        public string MainName { get; set; }

        [JsonProperty(PropertyName = "cpuBurnerName")]
        public string CpuStresserName { get; set; }

        [JsonProperty(PropertyName = "memBurnerName")]
        public string MemStresserName { get; set; }

        [JsonProperty(PropertyName = "diskBurnerName")]
        public string DiskStresserName { get; set; }

        [JsonProperty(PropertyName = "profileName")]
        public string ProfileName { get; set; }

        [JsonProperty(PropertyName = "autoExecute")]
        public bool AutoExecute { get; set; }

        public static DownloaderSetting uniqueInstance = JsonConvert.DeserializeObject<DownloaderSetting>(File.ReadAllText("DownloaderSetting.json"));

        public static DownloaderSetting GetInstance() => uniqueInstance;
    }
}
