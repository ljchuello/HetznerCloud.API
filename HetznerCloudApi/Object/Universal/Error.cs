using Newtonsoft.Json;

namespace HetznerCloudApi.Object.Universal
{
    public class Error
    {
        [JsonProperty("message")]
        public string Message { get; set; } = string.Empty;

        [JsonProperty("code")]
        public string Code { get; set; } = string.Empty;

        //[JsonProperty("details")]
        //public object Details { get; set; }
    }
}
