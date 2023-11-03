using System.Collections.Generic;
using HetznerCloudApi.Object.Universal;
using Newtonsoft.Json;

namespace HetznerCloudApi.Object.Location.Get
{
    public class Response
    {
        [JsonProperty("locations", NullValueHandling = NullValueHandling.Ignore)]
        public List<Location> Locations { get; set; } = new List<Location>();
        
        [JsonProperty("meta", NullValueHandling = NullValueHandling.Ignore)]
        public Meta Meta { get; set; } = new Meta();
    }
}
