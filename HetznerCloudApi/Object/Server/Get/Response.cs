using HetznerCloudApi.Object.Universal;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace HetznerCloudApi.Object.Server.Get
{
    public class Response
    {
        [JsonProperty("servers", NullValueHandling = NullValueHandling.Ignore)]
        public List<Server> Servers { get; set; } = new List<Server>();

        [JsonProperty("meta", NullValueHandling = NullValueHandling.Ignore)]
        public Meta Meta { get; set; } = new Meta();
    }
}
