using HetznerCloudApi.Object.Universal;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace HetznerCloudApi.Object.Action
{
    public class Response
    {
        [JsonProperty("actions", NullValueHandling = NullValueHandling.Ignore)]
        public List<Universal.Action> Actions { get; set; } = new List<Universal.Action>();

        [JsonProperty("meta", NullValueHandling = NullValueHandling.Ignore)]
        public Meta Meta { get; set; } = new Meta();
    }
}
