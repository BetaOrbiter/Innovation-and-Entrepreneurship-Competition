using Newtonsoft.Json;

namespace Profile
{
    public sealed class MemoryConfiguration
    {
        [JsonProperty(PropertyName = "num")]
        public uint Number { get; set; }

        [JsonProperty(PropertyName = "name")]
        public IList<string> Names;

        [JsonProperty(PropertyName = "size")]
        public IList<ulong> Size;
    }
}
