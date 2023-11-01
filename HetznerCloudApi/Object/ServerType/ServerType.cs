using Newtonsoft.Json;
using System.Collections.Generic;

namespace HetznerCloudApi.Object.ServerType
{
    public class ServerType
    {
        /// <summary>
        /// ID of the Server type
        /// </summary>
        [JsonProperty("id")]
        public long Id { get; set; } = 0;

        /// <summary>
        /// Unique identifier of the Server type
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Description of the Server type
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Number of cpu cores a Server of this type will have
        /// </summary>
        [JsonProperty("cores")]
        public long Cores { get; set; } = 0;

        /// <summary>
        /// Memory a Server of this type will have in GB
        /// </summary>
        [JsonProperty("memory")]
        public double Memory { get; set; } = 0;

        /// <summary>
        /// Disk size a Server of this type will have in GB
        /// </summary>
        [JsonProperty("disk")]
        public long Disk { get; set; } = 0;

        /// <summary>
        /// This field is deprecated. Use the deprecation object instead
        /// </summary>
        [JsonProperty("deprecated")]
        public bool Deprecated { get; set; } = false;

        /// <summary>
        /// Prices in different Locations
        /// </summary>
        [JsonProperty("prices")]
        public List<Price> Prices { get; set; } = new List<Price>();

        /// <summary>
        /// Possible enum values:
        /// localnetwork
        /// Type of Server boot drive. Local has higher speed. Network has better availability.
        /// </summary>
        [JsonProperty("storage_type")]
        public string StorageType { get; set; } = string.Empty;

        /// <summary>
        /// Possible enum values:
        /// shareddedicated
        /// Type of cpu
        /// </summary>
        [JsonProperty("cpu_type")]
        public string CpuType { get; set; } = string.Empty;

        /// <summary>
        /// Possible enum values:
        /// x86arm
        /// Type of cpu architecture
        /// </summary>
        [JsonProperty("architecture")]
        public string Architecture { get; set; } = string.Empty;

        /// <summary>
        /// Free traffic per month in bytes
        /// </summary>
        [JsonProperty("included_traffic")]
        public double IncludedTraffic { get; set; }

        //[JsonProperty("deprecation")]
        //public object Deprecation { get; set; }

        public class Price
        {
            /// <summary>
            /// Name of the Location the price is for
            /// </summary>
            [JsonProperty("location")]
            public string Location { get; set; } = string.Empty;

            /// <summary>
            /// Hourly costs for a Server type in this Location
            /// </summary>
            [JsonProperty("price_hourly")]
            public PriceHourly PriceHourly { get; set; } = new PriceHourly();

            [JsonProperty("price_monthly")]
            public PriceMonthly PriceMonthly { get; set; } = new PriceMonthly();
        }

        public class PriceHourly
        {
            /// <summary>
            /// Price without VAT
            /// </summary>
            [JsonProperty("net")]
            public string Net { get; set; } = string.Empty;

            /// <summary>
            /// Price with VAT added
            /// </summary>
            [JsonProperty("gross")]
            public string Gross { get; set; } = string.Empty;
        }

        public class PriceMonthly
        {
            /// <summary>
            /// Price without VAT
            /// </summary>
            [JsonProperty("net")]
            public string Net { get; set; } = string.Empty;

            /// <summary>
            /// Price with VAT added
            /// </summary>
            [JsonProperty("gross")]
            public string Gross { get; set; } = string.Empty;
        }
    }
}
