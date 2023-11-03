using System.Collections.Generic;
using HetznerCloudApi.Object.Universal;
using Newtonsoft.Json;

namespace HetznerCloudApi.Object.Datacenter.Get
{
    public class Response
    {
        [JsonProperty("datacenters", NullValueHandling = NullValueHandling.Ignore)]
        public List<Datacenter> Datacenters { get; set; } = new List<Datacenter>();

        [JsonProperty("meta", NullValueHandling = NullValueHandling.Ignore)]
        public Meta Meta { get; set; } = new Meta();
    }
}
