using Newtonsoft.Json;

namespace HetznerCloudApi.Object
{
    public class Meta
    {
        [JsonProperty("pagination")]
        public Pagination Pagination { get; set; } = new Pagination();
    }

    public class Pagination
    {
        [JsonProperty("page")]
        public long? Page { get; set; } = 0;

        [JsonProperty("per_page")]
        public long? PerPage { get; set; } = 0;

        [JsonProperty("previous_page")]
        public long? PreviousPage { get; set; } = 0;

        [JsonProperty("next_page")]
        public long? NextPage { get; set; } = 0;

        [JsonProperty("last_page")]
        public long? LastPage { get; set; } = 0;

        [JsonProperty("total_entries")]
        public long? TotalEntries { get; set; } = 0;
    }
}
