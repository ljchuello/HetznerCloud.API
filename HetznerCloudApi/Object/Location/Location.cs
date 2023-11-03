using Newtonsoft.Json;

namespace HetznerCloudApi.Object.Location
{
    public class Location
    {
        /// <summary>
        /// City the Location is closest to
        /// </summary>
        [JsonProperty("city", NullValueHandling = NullValueHandling.Ignore)]
        public string City { get; set; } = string.Empty;

        /// <summary>
        /// ISO 3166-1 alpha-2 code of the country the Location resides in
        /// </summary>
        [JsonProperty("country", NullValueHandling = NullValueHandling.Ignore)]
        public string Country { get; set; } = string.Empty;

        /// <summary>
        /// Description of the Location
        /// </summary>
        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// ID of the Location
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long Id { get; set; } = 0;

        /// <summary>
        /// Latitude of the city closest to the Location
        /// </summary>
        [JsonProperty("latitude", NullValueHandling = NullValueHandling.Ignore)]
        public double Latitude { get; set; } = 0;

        /// <summary>
        /// Longitude of the city closest to the Location
        /// </summary>
        [JsonProperty("longitude", NullValueHandling = NullValueHandling.Ignore)]
        public double Longitude { get; set; }= 0;

        /// <summary>
        /// Unique identifier of the Location
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Name of network zone this Location resides in
        /// </summary>
        [JsonProperty("network_zone", NullValueHandling = NullValueHandling.Ignore)]
        public string NetworkZone { get; set; } = string.Empty;
    }
}
