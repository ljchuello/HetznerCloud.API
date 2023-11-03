using Newtonsoft.Json;
using System.Collections.Generic;
using System;

namespace HetznerCloudApi.Object.Action
{
    public class Action
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long Id { get; set; } = 0;

        [JsonProperty("command", NullValueHandling = NullValueHandling.Ignore)]
        public string Command { get; set; } = string.Empty;

        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; } = string.Empty;

        [JsonProperty("progress", NullValueHandling = NullValueHandling.Ignore)]
        public long Progress { get; set; } = 0;

        [JsonProperty("started", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime Started { get; set; } = new DateTime(1900, 01, 01);

        [JsonProperty("finished", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime Finished { get; set; } = new DateTime(1900, 01, 01);

        [JsonProperty("resources", NullValueHandling = NullValueHandling.Ignore)]
        public List<Resource> Resources { get; set; } = new List<Resource>();

        //[JsonProperty("error", NullValueHandling = NullValueHandling.Ignore)]
        //public Error Error { get; set; } = new Error();
    }

    public class Resource
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long Id { get; set; } = 0;

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; } = string.Empty;
    }
}
