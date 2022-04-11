using Newtonsoft.Json;

namespace Profile
{
    public class DriveConfiguration
    {
        [JsonProperty(PropertyName = "num")]
        public uint Number { get; set; }

        [JsonProperty(PropertyName = "name")]
        public IList<string> Names { get; set; }
    }
}
