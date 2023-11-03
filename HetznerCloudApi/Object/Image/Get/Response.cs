using System.Collections.Generic;
using HetznerCloudApi.Object.Universal;
using Newtonsoft.Json;

namespace HetznerCloudApi.Object.Image.Get
{
    public class Response
    {
        [JsonProperty("images", NullValueHandling = NullValueHandling.Ignore)]
        public List<Image> Images { get; set; } = new List<Image>();

        [JsonProperty("meta", NullValueHandling = NullValueHandling.Ignore)]
        public Meta Meta { get; set; } = new Meta();
    }
}
