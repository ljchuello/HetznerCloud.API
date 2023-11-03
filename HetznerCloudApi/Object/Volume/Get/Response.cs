using HetznerCloudApi.Object.Universal;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace HetznerCloudApi.Object.Volume.Get
{
    public class Response
    {
        [JsonProperty("volumes", NullValueHandling = NullValueHandling.Ignore)]
        public List<Volume> Volumes { get; set; } = new List<Volume>();

        [JsonProperty("meta", NullValueHandling = NullValueHandling.Ignore)]
        public Meta Meta { get; set; } = new Meta();
    }
}
