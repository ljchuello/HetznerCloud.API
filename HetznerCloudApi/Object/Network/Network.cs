using HetznerCloudApi.Object.Universal;
using Newtonsoft.Json;
using System.Collections.Generic;
using System;

namespace HetznerCloudApi.Object.Network
{
    public class Network
    {
        /// <summary>
        /// ID of the Network
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long Id { get; set; } = 0;

        /// <summary>
        /// Name of the Network
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// IPv4 prefix of the whole Network
        /// </summary>
        [JsonProperty("ip_range", NullValueHandling = NullValueHandling.Ignore)]
        public string IpRange { get; set; } = string.Empty;

        /// <summary>
        /// Array subnets allocated in this Network
        /// </summary>
        [JsonProperty("subnets", NullValueHandling = NullValueHandling.Ignore)]
        public List<Subnet> Subnets { get; set; } = new List<Subnet>();

        /// <summary>
        /// Array of routes set in this Network
        /// </summary>
        [JsonProperty("routes", NullValueHandling = NullValueHandling.Ignore)]
        public List<Route> Routes { get; set; } = new List<Route>();

        /// <summary>
        /// Array of IDs of Servers attached to this Network
        /// </summary>
        [JsonProperty("servers", NullValueHandling = NullValueHandling.Ignore)]
        public List<long> Servers { get; set; } = new List<long>();

        /// <summary>
        /// Array of IDs of Load Balancers attached to this Network
        /// </summary>
        [JsonProperty("load_balancers", NullValueHandling = NullValueHandling.Ignore)]
        public List<long> LoadBalancers { get; set; } = new List<long>();

        /// <summary>
        /// Protection configuration for the Network
        /// </summary>
        [JsonProperty("protection", NullValueHandling = NullValueHandling.Ignore)]
        public Protection Protection { get; set; } = new Protection();

        //[JsonProperty("labels", NullValueHandling = NullValueHandling.Ignore)]
        //public Labels Labels { get; set; }

        /// <summary>
        /// Point in time when the Network was created
        /// </summary>
        [JsonProperty("created", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime Created { get; set; } = new DateTime(1900, 01, 01);

        /// <summary>
        /// Indicates if the routes from this network should be exposed to the vSwitch connection.
        /// </summary>
        [JsonProperty("expose_routes_to_vswitch", NullValueHandling = NullValueHandling.Ignore)]
        public bool ExposeRoutesToVswitch { get; set; } = false;
    }

    public class Route
    {
        /// <summary>
        /// Destination network or host of this route. Must not overlap with an existing ip_range in any subnets or with any destinations in other routes or with the first IP of the networks ip_range or with 172.31.1.1. Must be one of the private IPv4 ranges of RFC1918.
        /// </summary>
        [JsonProperty("destination", NullValueHandling = NullValueHandling.Ignore)]
        public string Destination { get; set; } = string.Empty;

        /// <summary>
        /// Gateway for the route. Cannot be the first IP of the networks ip_range and also cannot be 172.31.1.1 as this IP is being used as a gateway for the public network interface of Servers.
        /// </summary>
        [JsonProperty("gateway", NullValueHandling = NullValueHandling.Ignore)]
        public string Gateway { get; set; } = string.Empty;
    }

    public class Subnet
    {
        /// <summary>
        /// Type of Subnetwork
        /// </summary>
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; } = string.Empty;

        /// <summary>
        /// Range to allocate IPs from. Must be a Subnet of the ip_range of the parent network object and must not overlap with any other subnets or with any destinations in routes. Minimum Network size is /30. We suggest that you pick a bigger Network with a /24 netmask.
        /// </summary>
        [JsonProperty("ip_range", NullValueHandling = NullValueHandling.Ignore)]
        public string IpRange { get; set; } = string.Empty;

        /// <summary>
        /// Name of Network zone. The Location object contains the network_zone property each Location belongs to.
        /// </summary>
        [JsonProperty("network_zone", NullValueHandling = NullValueHandling.Ignore)]
        public string NetworkZone { get; set; } = string.Empty;

        //[JsonProperty("vswitch_id", NullValueHandling = NullValueHandling.Ignore)]
        //public object VswitchId { get; set; }

        /// <summary>
        /// Gateway for Servers attached to this subnet. For subnets of type Server this is always the first IP of the network IP range.
        /// </summary>
        [JsonProperty("gateway", NullValueHandling = NullValueHandling.Ignore)]
        public string Gateway { get; set; } = string.Empty;
    }
}
