using Newtonsoft.Json;
using System.Collections.Generic;

namespace HetznerCloudApi.Object.Datacenter
{
    public class Datacenter
    {
        /// <summary>
        /// Description of the Datacenter
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// ID of the Resource
        /// </summary>
        [JsonProperty("id")]
        public long Id { get; set; } = 0;

        /// <summary>
        /// Location
        /// </summary>
        [JsonProperty("location")]
        public Location.Location Location { get; set; } = new Location.Location();

        /// <summary>
        /// Unique identifier of the Datacenter
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The Server types the Datacenter can handle
        /// </summary>
        [JsonProperty("server_types")]
        public ServerTypes ServerTypes { get; set; } = new ServerTypes();
    }

    public class ServerTypes
    {
        [JsonProperty("available")]
        public List<long> Available { get; set; } = new List<long>();

        [JsonProperty("available_for_migration")]
        public List<long> AvailableForMigration { get; set; } = new List<long>();

        [JsonProperty("supported")]
        public List<long> Supported { get; set; } = new List<long>();
    }
}
