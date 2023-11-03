using Newtonsoft.Json;

namespace HetznerCloudApi.Object.Universal
{
    public class Protection
    {
        /// <summary>
        /// If true, prevents the Resource from being deleted
        /// </summary>
        [JsonProperty("delete", NullValueHandling = NullValueHandling.Ignore)]
        public bool Delete { get; set; } = false;
    }
}
