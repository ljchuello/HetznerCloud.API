using Newtonsoft.Json;
using System.Collections.Generic;

namespace HetznerCloudApi.Object.Image.Response
{
    public class Response
    {
        [JsonProperty("images")]
        public List<Image> Images { get; set; } = new List<Image>();

        [JsonProperty("meta")]
        public Meta Meta { get; set; } = new Meta();
    }
}
