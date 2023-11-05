using HetznerCloudApi.Object.Universal;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace HetznerCloudApi.Object.SshKey.Get
{
    public class Response
    {
        [JsonProperty("ssh_keys", NullValueHandling = NullValueHandling.Ignore)]
        public List<SshKey> SshKeys { get; set; } = new List<SshKey>();

        [JsonProperty("meta", NullValueHandling = NullValueHandling.Ignore)]
        public Meta Meta { get; set; } = new Meta();
    }
}
