using Newtonsoft.Json;

namespace Client.Model
{
    public class BackendInfo
    {
        public string Hostname { get; set; }
        [JsonProperty("LocalIP")]
        public string IPAddress { get; set; }
    }
}