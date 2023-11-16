using HetznerCloudApi.Object.Universal;
using Newtonsoft.Json;
using System.Collections.Generic;
using System;

namespace HetznerCloudApi.Object.Server
{
    public class Server
    {
        /// <summary>
        /// ID of the Resource
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long Id { get; set; } = 0;

        /// <summary>
        /// Name of the Server (must be unique per Project and a valid hostname as per RFC 1123)
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Status of the Server
        /// </summary>
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; } = string.Empty;

        /// <summary>
        /// Point in time when the Resource was created
        /// </summary>
        [JsonProperty("created", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime Created { get; set; } = new DateTime(1900, 01, 01);

        /// <summary>
        /// Public network information. The Server's IPv4 address can be found in public_net->ipv4->ip
        /// </summary>
        [JsonProperty("public_net", NullValueHandling = NullValueHandling.Ignore)]
        public PublicNet PublicNet { get; set; } = new PublicNet();

        /// <summary>
        /// Private networks information
        /// </summary>
        [JsonProperty("private_net", NullValueHandling = NullValueHandling.Ignore)]
        public List<PrivateNet> PrivateNet { get; set; } = new List<PrivateNet>();

        /// <summary>
        /// Type of Server - determines how much ram, disk and cpu a Server has
        /// </summary>
        [JsonProperty("server_type", NullValueHandling = NullValueHandling.Ignore)]
        public ServerType.ServerType ServerType { get; set; } = new ServerType.ServerType();

        /// <summary>
        /// Datacenter this Resource is located at
        /// </summary>
        [JsonProperty("datacenter", NullValueHandling = NullValueHandling.Ignore)]
        public Datacenter.Datacenter Datacenter { get; set; } = new Datacenter.Datacenter();

        /// <summary>
        /// Image
        /// </summary>
        [JsonProperty("image", NullValueHandling = NullValueHandling.Ignore)]
        public Image.Image Image { get; set; } = new Image.Image();

        //[JsonProperty("iso", NullValueHandling = NullValueHandling.Ignore)]
        //public object Iso { get; set; }

        /// <summary>
        /// True if rescue mode is enabled. Server will then boot into rescue system on next reboot
        /// </summary>
        [JsonProperty("rescue_enabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool RescueEnabled { get; set; } = false;

        /// <summary>
        /// True if Server has been locked and is not available to user
        /// </summary>
        [JsonProperty("locked", NullValueHandling = NullValueHandling.Ignore)]
        public bool Locked { get; set; } = false;

        //[JsonProperty("backup_window", NullValueHandling = NullValueHandling.Ignore)]
        //public object BackupWindow { get; set; }

        /// <summary>
        /// Outbound Traffic for the current billing period in bytes
        /// </summary>
        [JsonProperty("outgoing_traffic", NullValueHandling = NullValueHandling.Ignore)]
        public long OutgoingTraffic { get; set; }

        /// <summary>
        /// Inbound Traffic for the current billing period in bytes
        /// </summary>
        [JsonProperty("ingoing_traffic", NullValueHandling = NullValueHandling.Ignore)]
        public long IngoingTraffic { get; set; } = 0;

        /// <summary>
        /// Free Traffic for the current billing period in bytes
        /// </summary>
        [JsonProperty("included_traffic", NullValueHandling = NullValueHandling.Ignore)]
        public long IncludedTraffic { get; set; } = 0;

        /// <summary>
        /// Protection configuration for the Server
        /// </summary>
        [JsonProperty("protection", NullValueHandling = NullValueHandling.Ignore)]
        public Protection Protection { get; set; } = new Protection();

        //[JsonProperty("labels", NullValueHandling = NullValueHandling.Ignore)]
        //public Labels Labels { get; set; }

        /// <summary>
        /// IDs of Volumes assigned to this Server
        /// </summary>
        [JsonProperty("volumes", NullValueHandling = NullValueHandling.Ignore)]
        public List<long> Volumes { get; set; } = new List<long>();

        /// <summary>
        /// Array of integers (int64)
        /// </summary>
        [JsonProperty("load_balancers", NullValueHandling = NullValueHandling.Ignore)]
        public List<long> LoadBalancers { get; set; } = new List<long>();

        /// <summary>
        /// Size of the primary Disk
        /// </summary>
        [JsonProperty("primary_disk_size", NullValueHandling = NullValueHandling.Ignore)]
        public long PrimaryDiskSize { get; set; } = 0;

        /// <summary>
        /// Placement Group
        /// </summary>
        [JsonProperty("placement_group", NullValueHandling = NullValueHandling.Ignore)]
        public PlacementGroup.PlacementGroup PlacementGroup { get; set; } = new PlacementGroup.PlacementGroup();
    }

    public class Ipv4
    {
        [JsonProperty("ip", NullValueHandling = NullValueHandling.Ignore)]
        public string Ip { get; set; } = string.Empty;

        [JsonProperty("blocked", NullValueHandling = NullValueHandling.Ignore)]
        public bool Blocked { get; set; } = false;

        [JsonProperty("dns_ptr", NullValueHandling = NullValueHandling.Ignore)]
        public string DnsPtr { get; set; } = string.Empty;

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long Id { get; set; } = 0;
    }

    public class Ipv6
    {
        [JsonProperty("ip", NullValueHandling = NullValueHandling.Ignore)]
        public string Ip { get; set; } = string.Empty;

        [JsonProperty("blocked", NullValueHandling = NullValueHandling.Ignore)]
        public bool Blocked { get; set; } = false;

        //[JsonProperty("dns_ptr", NullValueHandling = NullValueHandling.Ignore)]
        //public string DnsPtr { get; set; } = string.Empty;

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long Id { get; set; } = 0;
    }

    public class PublicNet
    {
        [JsonProperty("ipv4", NullValueHandling = NullValueHandling.Ignore)]
        public Ipv4 Ipv4 { get; set; } = new Ipv4();

        [JsonProperty("ipv6", NullValueHandling = NullValueHandling.Ignore)]
        public Ipv6 Ipv6 { get; set; } = new Ipv6();

        [JsonProperty("floating_ips", NullValueHandling = NullValueHandling.Ignore)]
        public List<long> FloatingIps { get; set; } = new List<long>();

        [JsonProperty("firewalls", NullValueHandling = NullValueHandling.Ignore)]
        public List<Firewall.Firewall> Firewalls { get; set; } = new List<Firewall.Firewall>();
    }

    public class PrivateNet
    {
        [JsonProperty("network", NullValueHandling = NullValueHandling.Ignore)]
        public long Network { get; set; } = 0;

        [JsonProperty("ip", NullValueHandling = NullValueHandling.Ignore)]
        public string Ip { get; set; } = string.Empty;

        //[JsonProperty("alias_ips", NullValueHandling = NullValueHandling.Ignore)]
        //public List<object> AliasIps { get; set; }

        [JsonProperty("mac_address", NullValueHandling = NullValueHandling.Ignore)]
        public string MacAddress { get; set; } = string.Empty;
    }
}
