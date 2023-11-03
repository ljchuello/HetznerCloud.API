using Newtonsoft.Json;

namespace HetznerCloudApi.Object.Universal
{
    public class Meta
    {
        [JsonProperty("pagination", NullValueHandling = NullValueHandling.Ignore)]
        public Pagination Pagination { get; set; } = new Pagination();
    }

    public class Pagination
    {
        [JsonProperty("page", NullValueHandling = NullValueHandling.Ignore)]
        public long Page { get; set; } = 0;

        [JsonProperty("per_page", NullValueHandling = NullValueHandling.Ignore)]
        public long PerPage { get; set; } = 0;

        [JsonProperty("previous_page", NullValueHandling = NullValueHandling.Ignore)]
        public long PreviousPage { get; set; } = 0;

        [JsonProperty("next_page", NullValueHandling = NullValueHandling.Ignore)]
        public long NextPage { get; set; } = 0;

        [JsonProperty("last_page", NullValueHandling = NullValueHandling.Ignore)]
        public long LastPage { get; set; } = 0;

        [JsonProperty("total_entries", NullValueHandling = NullValueHandling.Ignore)]
        public long TotalEntries { get; set; } = 0;
    }
}
