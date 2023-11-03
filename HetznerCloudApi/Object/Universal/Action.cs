using Newtonsoft.Json;
using System.Collections.Generic;
using System;

namespace HetznerCloudApi.Object.Universal
{
    public class Action
    {
        [JsonProperty("command", NullValueHandling = NullValueHandling.Ignore)]
        public string Command { get; set; }

        [JsonProperty("finished", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime Finished { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public int Id { get; set; }

        [JsonProperty("progress", NullValueHandling = NullValueHandling.Ignore)]
        public int Progress { get; set; }

        [JsonProperty("resources", NullValueHandling = NullValueHandling.Ignore)]
        public List<Resource> Resources { get; set; }

        [JsonProperty("started", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime Started { get; set; }

        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }
    }

    public class Resource
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public int Id { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }
    }
}
