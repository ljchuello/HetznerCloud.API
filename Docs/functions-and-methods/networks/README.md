# 🌐 Networks

Networks is a private networks feature. These Networks are optional and they coexist with the public network that every Server has by default.

They allow Servers to talk to each other over a dedicated network interface using private IP addresses not available publicly.

The IP addresses are allocated and managed via the API, they must conform to [RFC1918](https://tools.ietf.org/html/rfc1918#section-3) standard. IPs and network interfaces defined under Networks do not provide public internet connectivity, you will need to use the already existing public network interface for that.

Each network has a user selected `ip_range` which defines all available IP addresses which can be used for Subnets within the Network.

To assign individual IPs to Servers you will need to create Network Subnets, described below.

Currently Networks support IPv4 only.

## Get all Networks

Gets all existing networks that you have available.

```csharp
HetznerCloudClient hetznerCloudClient = new HetznerCloudClient("apiKey");

List<Network> list = await hetznerCloudClient.Network.Get();
```

## Get a Network

Gets a specific network object.

```csharp
HetznerCloudClient hetznerCloudClient = new HetznerCloudClient("apiKey");

long networkId = 3545643;

Network network = await hetznerCloudClient.Network.Get(networkId);
```

## Create a Network

Creates a network with the specified ip\_range.

```csharp
HetznerCloudClient hetznerCloudClient = new HetznerCloudClient("apiKey");

Network network = await hetznerCloudClient.Network.Create("network-name", "192.168.0.0/16");
```

## Update a Network

Updates the network properties.

```csharp
HetznerCloudClient hetznerCloudClient = new HetznerCloudClient("apiKey");

// Get one
Network network = await hetznerCloudClient.Network.Get(3550103);

// Edit name
network.Name = $"new-name";

// Update
network = await hetznerCloudClient.Network.Update(network);
```

## Delete a Network

Deletes a network. If there are Servers attached they will be detached in the background.

```csharp
HetznerCloudClient hetznerCloudClient = new HetznerCloudClient("ApiKey");

// Get one
Network network = await hetznerCloudClient.Network.Get(3550103);

// You can delete it by passing the object as a parameter
await hetznerCloudClient.Network.Delete(network);

// You can also delete it by passing the ID as a parameter.
await hetznerCloudClient.Network.Delete(3550103);
```

## **JSON**

```json
{
    "network": {
        "id": 3550135,
        "name": "network",
        "ip_range": "192.168.0.0/16",
        "subnets": [
            {
                "type": "cloud",
                "ip_range": "192.168.0.0/20",
                "network_zone": "eu-central",
                "vswitch_id": null,
                "gateway": "192.168.0.1"
            },
            {
                "type": "cloud",
                "ip_range": "192.168.16.0/20",
                "network_zone": "eu-central",
                "vswitch_id": null,
                "gateway": "192.168.0.1"
            }
        ],
        "routes": [
            {
                "destination": "192.168.32.0/24",
                "gateway": "192.168.16.1"
            }
        ],
        "servers": [
            39271989
        ],
        "load_balancers": [
            1535492
        ],
        "protection": {
            "delete": false
        },
        "labels": {},
        "created": "2023-11-12T16:25:32+00:00",
        "expose_routes_to_vswitch": false
    }
}
```
