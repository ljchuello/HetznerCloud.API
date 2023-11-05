using HetznerCloudApi.Object.Universal;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace HetznerCloudApi.Object.Firewall.Get
{
    public class Response
    {
        [JsonProperty("firewalls", NullValueHandling = NullValueHandling.Ignore)]
        public List<Firewall> Firewalls { get; set; } = new List<Firewall>();

        [JsonProperty("meta", NullValueHandling = NullValueHandling.Ignore)]
        public Meta Meta { get; set; } = new Meta(); 
    }
}
