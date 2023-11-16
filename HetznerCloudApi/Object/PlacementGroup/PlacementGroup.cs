using Newtonsoft.Json;
using System.Collections.Generic;
using System;

namespace HetznerCloudApi.Object.PlacementGroup
{
    public class PlacementGroup
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long Id { get; set; } = 0;

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; } = string.Empty;

        //[JsonProperty("labels", NullValueHandling = NullValueHandling.Ignore)]
        //public Labels Labels { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; } = string.Empty;

        [JsonProperty("created", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime Created { get; set; } = new DateTime(1900, 01, 01);

        [JsonProperty("servers", NullValueHandling = NullValueHandling.Ignore)]
        public List<long> Servers { get; set; } = new List<long>();
    }
}
