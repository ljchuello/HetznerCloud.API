using Newtonsoft.Json;
using System;
using HetznerCloudApi.Object.Universal;

namespace HetznerCloudApi.Object.Volume
{
    public class Volume
    {
        /// <summary>
        /// Point in time when the Resource was created
        /// </summary>
        [JsonProperty("created", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime Created { get; set; } = new DateTime(1900, 01, 01);

        /// <summary>
        /// Filesystem of the Volume if formatted on creation, null if not formatted on creation
        /// </summary>
        [JsonProperty("format", NullValueHandling = NullValueHandling.Ignore)]
        public string Format { get; set; } = string.Empty;

        /// <summary>
        /// ID of the Resource
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long Id { get; set; } = 0;

        //[JsonProperty("labels")]
        //public Labels Labels { get; set; }

        /// <summary>
        /// Device path on the file system for the Volume
        /// </summary>
        [JsonProperty("linux_device", NullValueHandling = NullValueHandling.Ignore)]
        public string LinuxDevice { get; set; } = string.Empty;

        /// <summary>
        /// Location of the Volume. Volume can only be attached to Servers in the same Location.
        /// </summary>
        [JsonProperty("location", NullValueHandling = NullValueHandling.Ignore)]
        public Location.Location Location { get; set; } = new Location.Location();

        /// <summary>
        /// Name of the Resource. Must be unique per Project.
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Protection configuration for the Resource
        /// </summary>
        [JsonProperty("protection", NullValueHandling = NullValueHandling.Ignore)]
        public Protection Protection { get; set; } = new Protection();

        /// <summary>
        /// ID of the Server the Volume is attached to, null if it is not attached at all
        /// </summary>
        [JsonProperty("server", NullValueHandling = NullValueHandling.Ignore)]
        public long Server { get; set; } = 0;

        /// <summary>
        /// Size in GB of the Volume
        /// </summary>
        [JsonProperty("size", NullValueHandling = NullValueHandling.Ignore)]
        public long Size { get; set; } = 0;

        /// <summary>
        /// Current status of the Volume
        /// </summary>
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; } = string.Empty;
    }

    public enum VolumeFormat
    {
        ext4,
        xfs,
    }
}
