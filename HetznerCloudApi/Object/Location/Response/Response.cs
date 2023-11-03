using HetznerCloudApi.Object.Universal;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace HetznerCloudApi.Object.Location.Response
{
    public class Response
    {
        [JsonProperty("locations")]
        public List<Location> Locations { get; set; } = new List<Location>();
        
        [JsonProperty("meta")]
        public Meta Meta { get; set; } = new Meta();
    }
}
