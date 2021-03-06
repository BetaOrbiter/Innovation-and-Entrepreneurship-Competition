using Newtonsoft.Json;
namespace Profile
{
    public sealed class CPUConfiguration
    {
        [JsonProperty(PropertyName = "num")]
        public uint Number { get; set; }

        [JsonProperty(PropertyName = "name")]
        public IList<string> Names { get; set; }

        private CPUConfiguration() { }
    }
}
