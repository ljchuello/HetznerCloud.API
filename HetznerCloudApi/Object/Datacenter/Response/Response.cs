using HetznerCloudApi.Object.Universal;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace HetznerCloudApi.Object.Datacenter.Response
{
    public class Response
    {
        [JsonProperty("datacenters")]
        public List<Datacenter> Datacenters { get; set; } = new List<Datacenter>();

        [JsonProperty("meta")]
        public Meta Meta { get; set; } = new Meta();
    }
}
