using HetznerCloudApi.Object.Universal;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace HetznerCloudApi.Object.ServerType
{
    public class Response
    {
        [JsonProperty("server_types")]
        public List<ServerType> ServerTypes { get; set; } = new List<ServerType>();

        [JsonProperty("meta")]
        public Meta Meta { get; set; } = new Meta();
    }
}
