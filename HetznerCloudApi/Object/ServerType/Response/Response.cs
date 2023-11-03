using HetznerCloudApi.Object.Universal;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace HetznerCloudApi.Object.ServerType.Response
{
    public class Response
    {
        [JsonProperty("server_types", NullValueHandling = NullValueHandling.Ignore)]
        public List<ServerType> ServerTypes { get; set; } = new List<ServerType>();

        [JsonProperty("meta", NullValueHandling = NullValueHandling.Ignore)]
        public Meta Meta { get; set; } = new Meta();
    }
}
