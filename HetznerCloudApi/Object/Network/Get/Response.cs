using HetznerCloudApi.Object.Universal;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace HetznerCloudApi.Object.Network.Get
{
    public class Response
    {
        [JsonProperty("networks", NullValueHandling = NullValueHandling.Ignore)]
        public List<Network> Networks { get; set; } = new List<Network>();

        [JsonProperty("meta", NullValueHandling = NullValueHandling.Ignore)]
        public Meta Meta { get; set; } = new Meta();
    }
}
