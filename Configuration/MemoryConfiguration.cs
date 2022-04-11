using Newtonsoft.Json;

namespace Profile
{
    public class MemoryConfiguration
    {
        [JsonProperty(PropertyName = "num")]
        public uint Number { get; set; }

        [JsonProperty(PropertyName = "name")]
        public IList<string> Names;
    }
}
