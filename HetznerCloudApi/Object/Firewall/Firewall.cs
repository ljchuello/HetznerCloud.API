using Newtonsoft.Json;
using System.Collections.Generic;
using System;
using Newtonsoft.Json.Converters;

namespace HetznerCloudApi.Object.Firewall
{
    public class Firewall
    {
        /// <summary>
        /// ID of the Resource
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long Id { get; set; } = 0;

        /// <summary>
        /// Name of the Resource. Must be unique per Project.
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; } = string.Empty;

        //[JsonProperty("labels", NullValueHandling = NullValueHandling.Ignore)]
        //public Labels Labels { get; set; }

        /// <summary>
        /// Point in time when the Resource was created
        /// </summary>
        [JsonProperty("created", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime Created { get; set; } = new DateTime(1900, 01, 01);

        [JsonProperty("rules", NullValueHandling = NullValueHandling.Ignore)]
        public List<Rule> Rules { get; set; } = new List<Rule>();

        [JsonProperty("applied_to", NullValueHandling = NullValueHandling.Ignore)]
        public List<AppliedTo> AppliedTo { get; set; } = new List<AppliedTo>();
    }

    public class Rule
    {
        /// <summary>
        /// Possible enum values:
        /// inout
        /// Select traffic direction on which rule should be applied. Use source_ips for direction in and destination_ips for direction out
        /// </summary>
        [JsonProperty("direction", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public Direction Direction { get; set; } = Direction.@in;

        /// <summary>
        /// Possible enum values:
        /// tcpudpicmpespgre
        /// Type of traffic to allow
        /// </summary>
        [JsonProperty("protocol", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public Protocol Protocol { get; set; } = Protocol.tcp;

        /// <summary>
        /// Port or port range to which traffic will be allowed, only applicable for protocols TCP and UDP. A port range can be specified by separating two ports with a dash, e.g 1024-5000.
        /// </summary>
        [JsonProperty("port", NullValueHandling = NullValueHandling.Ignore)]
        public string Port { get; set; } = string.Empty;

        /// <summary>
        /// List of permitted IPv4/IPv6 addresses in CIDR notation. Use 0.0.0.0/0 to allow all IPv4 addresses and ::/0 to allow all IPv6 addresses. You can specify 100 CIDRs at most.
        /// </summary>
        [JsonProperty("source_ips", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> SourceIps { get; set; } = new List<string>();

        /// <summary>
        /// List of permitted IPv4/IPv6 addresses in CIDR notation. Use 0.0.0.0/0 to allow all IPv4 addresses and ::/0 to allow all IPv6 addresses. You can specify 100 CIDRs at most.
        /// </summary>
        [JsonProperty("destination_ips", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> DestinationIps { get; set; } = new List<string>();

        /// <summary>
        /// Description of the Rule
        /// </summary>
        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; } = string.Empty;
    }

    public class AppliedTo
    {
        /// <summary>
        /// Type of resource referenced
        /// </summary>
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; } = string.Empty;

        [JsonProperty("server", NullValueHandling = NullValueHandling.Ignore)]
        public Server Server { get; set; } = new Server();
    }

    public class Server
    {
        /// <summary>
        /// ID of the Resource
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long Id { get; set; } = 0;
    }

    public enum Direction
    {
        @in,
        @out,
    }

    public enum Protocol
    {
        tcp,
        udp,
        icmp,
        esp,
        gre,
    }
}
