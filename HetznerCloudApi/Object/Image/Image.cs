using System;
using Newtonsoft.Json;

namespace HetznerCloudApi.Object.Image
{
    public class Image
    {
        /// <summary>
        /// ID of the Image
        /// </summary>
        [JsonProperty("id")]
        public long Id { get; set; } = 0;

        /// <summary>
        /// Type of the Image
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; } = string.Empty;

        /// <summary>
        /// Whether the Image can be used or if it's still being created or unavailable
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; } = string.Empty;

        /// <summary>
        /// Unique identifier of the Image. This value is only set for system Images.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Description of the Image
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; } = string.Empty;

        //[JsonProperty("image_size")]
        //public object ImageSize { get; set; }

        /// <summary>
        /// Size of the disk contained in the Image in GB
        /// </summary>
        [JsonProperty("disk_size")]
        public long DiskSize { get; set; } = 0;

        /// <summary>
        /// Point in time when the Resource was created
        /// </summary>
        [JsonProperty("created")]
        public DateTime Created { get; set; } = new DateTime();

        //[JsonProperty("created_from")]
        //public object CreatedFrom { get; set; }

        //[JsonProperty("bound_to")]
        //public object BoundTo { get; set; }

        /// <summary>
        /// Flavor of operating system contained in the Image
        /// </summary>
        [JsonProperty("os_flavor")]
        public string OsFlavor { get; set; } = string.Empty;

        /// <summary>
        /// Operating system version
        /// </summary>
        [JsonProperty("os_version")]
        public string OsVersion { get; set; } = string.Empty;

        /// <summary>
        /// Indicates that rapid deploy of the Image is available
        /// </summary>
        [JsonProperty("rapid_deploy")]
        public bool RapidDeploy { get; set; } = false;

        //[JsonProperty("protection")]
        //public Protection Protection { get; set; }

        //[JsonProperty("deprecated")]
        //public object Deprecated { get; set; }

        //[JsonProperty("labels")]
        //public Labels Labels { get; set; }

        //[JsonProperty("deleted")]
        //public object Deleted { get; set; }

        /// <summary>
        /// Type of cpu architecture this image is compatible with.
        /// </summary>
        [JsonProperty("architecture")]
        public string Architecture { get; set; } = string.Empty;
    }
}
