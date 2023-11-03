using HetznerCloudApi.Object.Universal;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace HetznerCloudApi.Object.Location.Response
{
    public class Response
    {
        [JsonProperty("locations", NullValueHandling = NullValueHandling.Ignore)]
        public List<Location> Locations { get; set; } = new List<Location>();
        
        [JsonProperty("meta", NullValueHandling = NullValueHandling.Ignore)]
        public Meta Meta { get; set; } = new Meta();
    }
}
