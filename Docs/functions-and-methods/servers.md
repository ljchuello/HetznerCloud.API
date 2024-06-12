# 🖥️ Servers

Servers are virtual machines that can be provisioned.

## Get all Servers

Returns all existing Server objects

```csharp
HetznerCloudClient hetznerCloudClient = new HetznerCloudClient("apiKey");

// Get All
List<Server> list = await hetznerCloudClient.Server.Get();
```

## Get a Server

Returns a specific Server object. The Server must exist inside the Project

```csharp
HetznerCloudClient hetznerCloudClient = new HetznerCloudClient("apiKey");

long serverId = 39447794;

// Get One
Server server = await hetznerCloudClient.Server.Get(serverId);
```

## Create a Server (Simple)

Creates a new Server. Returns preliminary information about the Server as well as an Action that covers progress of creation.

Creating a server is pretty straightforward. We can specify the basics like name, image, location, or get more detailed, indicating whether we'll enable IPv4, IPv6, or specifying if it'll be within a private network. We can set SSH keys, decide if it should be associated with a volume, or even kick off a startup script using [Cloud config](https://community.hetzner.com/tutorials/basic-cloud-config).

The minimum required to create the server is the [location](https://github.com/ljchuello/HetznerCloud.Api/wiki/Location), the [image](https://github.com/ljchuello/HetznerCloud.Api/wiki/Image), the server name, and the [server type](https://github.com/ljchuello/HetznerCloud.Api/wiki/Servers-Types)

In this example, we'll specify the minimum to create a server.

```csharp
HetznerCloudClient hetznerCloudClient = new HetznerCloudClient("apiKey");

long datacenterId = 4; // ID of Datacenter to create Server
long imageId = 45557056; // ID or name of the Image the Server is created from
string name = "name-example"; // Name of the Server to create (must be unique per Project and a valid hostname as per RFC 1123)
long serverTypeId = 22; // ID or name of the Image the Server is created from
Server server = await hetznerCloudClient.Server.Create(datacenterId, imageId, name, serverTypeId);
```

Additionally, the [eDataCenter](https://github.com/ljchuello/HetznerCloud.Api/wiki/Datacenter#edatacenter) enum has been created, aiming to standardize resource creation throughout the Hetzner environment. It can be used for server creation as follows

```csharp
HetznerCloudClient hetznerCloudClient = new HetznerCloudClient("ApiKey");

eDataCenter eDataCenter = eDataCenter.ash; // Enum for the data center where it will be created
long imageId = 45557056; // ID or name of the Image the Server is created from
string name = "name-example"; // Name of the Server to create (must be unique per Project and a valid hostname as per RFC 1123)
long serverTypeId = 22; // ID or name of the Image the Server is created from
Server server = await hetznerCloudClient.Server.Create(eDataCenter, imageId, name, serverTypeId);
```

## Create a Server (Complete)

In addition to creating a server (simple), we can specify every detail of the server's resources. This includes indicating whether to enable IPv4, IPv6, passing a list of network IDs, SSH key IDs, specifying the volumes to mount, and even including it in a "placement group." We can also indicate the startup script with Cloud-Init scripts

```csharp
HetznerCloudClient hetznerCloudClient = new HetznerCloudClient("ApiKey");

long datacenterId = 4; // ID of Datacenter to create Server
long imageId = 45557056; // ID or name of the Image the Server is created from
string name = "name-example"; // Name of the Server to create (must be unique per Project and a valid hostname as per RFC 1123)
long serverTypeId = 22; // ID or name of the Image the Server is created from
// Optional;
List<long> privateNetoworksIds = new List<long> { 3562839 }; // List<long> containing the IDs of the private networks
List<long> sshKeysIds = new List<long> { 13121954, 16371855 }; // List<long> containing the SSH keys that the resource will use
List<long> volumesIds = new List<long> { 100090124 }; // List<long> containing the IDs of the volumes that will be attached to the server and mounted automatically
long placementGroupId = 270736; // ID or Placement Group
Server server = await hetznerCloudClient.Server.Create(
    datacenterId,
    imageId,
    name,
    serverTypeId,
    ipv4: true,
    ipv6: true,
    privateNetoworksIds: privateNetoworksIds,
    sshKeysIds: sshKeysIds,
    volumesIds: volumesIds,
    placementGroupId: placementGroupId,
    userData: "#cloud-config" +
                "\npackages:" +
                "\n- cadaver" +
                "\n- unzip" +
                "\npackage_update: true" +
                "\npackage_upgrade: true");
```

And just like in the simple creation, here you can also replace `LocationId` with `eDataCenter` to make the creation process simpler

```csharp
HetznerCloudClient hetznerCloudClient = new HetznerCloudClient("ApiKey");

eDataCenter eDataCenter = eDataCenter.ash; // Enum for the data center where it will be created
long imageId = 45557056; // ID or name of the Image the Server is created from
string name = "name-example"; // Name of the Server to create (must be unique per Project and a valid hostname as per RFC 1123)
long serverTypeId = 22; // ID or name of the Image the Server is created from
// Optional;
List<long> privateNetoworksIds = new List<long> { 3562839 }; // List<long> containing the IDs of the private networks
List<long> sshKeysIds = new List<long> { 13121954, 16371855 }; // List<long> containing the SSH keys that the resource will use
List<long> volumesIds = new List<long> { 100090124 }; // List<long> containing the IDs of the volumes that will be attached to the server and mounted automatically
long placementGroupId = 270736; // ID or Placement Group
Server server = await hetznerCloudClient.Server.Create(
    eDataCenter,
    imageId,
    name,
    serverTypeId,
    ipv4: true,
    ipv6: true,
    privateNetoworksIds: privateNetoworksIds,
    sshKeysIds: sshKeysIds,
    volumesIds: volumesIds,
    placementGroupId: placementGroupId,
    userData: "#cloud-config" +
                "\npackages:" +
                "\n- cadaver" +
                "\n- unzip" +
                "\npackage_update: true" +
                "\npackage_upgrade: true");
```

## Update a Server

Updates a Server. You can update a Server’s name.

```csharp
HetznerCloudClient hetznerCloudClient = new HetznerCloudClient("ApiKey");

// Get one server
Server server = await hetznerCloudClient.Server.Get(39706661);

// Change name
server.Name = "new-name";

// Update
server = await hetznerCloudClient.Server.Update(server);
```

## **Note:**

Person asking: Can you only modify the name in the `api.hetzner.cloud/v1/servers/{id}` endpoint?

Person answering: Yes!

Person asking: 😐

All other actions that affect or interact with the server can be found in Servers Actions.

## Delete a Server

Deletes a Server. This immediately removes the Server from your account, and it is no longer accessible. Any resources attached to the server (like Volumes, Primary IPs, Floating IPs, Firewalls, Placement Groups) are detached while the server is deleted.

```csharp
HetznerCloudClient hetznerCloudClient = new HetznerCloudClient("ApiKey");

// Get one server
Server server = await hetznerCloudClient.Server.Get(39707117);

// Delete
await hetznerCloudClient.Server.Delete(server);
```

You can also delete by passing the Server ID instead of the Server object

```csharp
HetznerCloudClient hetznerCloudClient = new HetznerCloudClient("ApiKey");

// Delete
await hetznerCloudClient.Server.Delete(39707117);
```

## **JSON**

```json
{
    "server": {
        "id": 39707330,
        "name": "debian-2gb-ash-1",
        "status": "running",
        "created": "2023-11-23T02:17:38+00:00",
        "public_net": {
            "ipv4": {
                "ip": "5.161.64.45",
                "blocked": false,
                "dns_ptr": "static.45.64.161.5.clients.your-server.de",
                "id": 44310536
            },
            "ipv6": {
                "ip": "2a01:4ff:f0:c883::/64",
                "blocked": false,
                "dns_ptr": [],
                "id": 44310537
            },
            "floating_ips": [],
            "firewalls": [
                {
                    "id": 1138264,
                    "status": "applied"
                }
            ]
        },
        "private_net": [
            {
                "network": 3588651,
                "ip": "10.0.0.2",
                "alias_ips": [],
                "mac_address": "86:00:00:68:b5:2e"
            }
        ],
        "server_type": {
            "id": 22,
            "name": "cpx11",
            "description": "CPX 11",
            "cores": 2,
            "memory": 2.0,
            "disk": 40,
            "deprecated": false,
            "prices": [
                {
                    "location": "ash",
                    "price_hourly": {
                        "net": "0.0063000000",
                        "gross": "0.0063000000000000"
                    },
                    "price_monthly": {
                        "net": "3.8500000000",
                        "gross": "3.8500000000000000"
                    }
                },
                {
                    "location": "hel1",
                    "price_hourly": {
                        "net": "0.0063000000",
                        "gross": "0.0063000000000000"
                    },
                    "price_monthly": {
                        "net": "3.8500000000",
                        "gross": "3.8500000000000000"
                    }
                },
                {
                    "location": "nbg1",
                    "price_hourly": {
                        "net": "0.0063000000",
                        "gross": "0.0063000000000000"
                    },
                    "price_monthly": {
                        "net": "3.8500000000",
                        "gross": "3.8500000000000000"
                    }
                },
                {
                    "location": "hil",
                    "price_hourly": {
                        "net": "0.0063000000",
                        "gross": "0.0063000000000000"
                    },
                    "price_monthly": {
                        "net": "3.8500000000",
                        "gross": "3.8500000000000000"
                    }
                },
                {
                    "location": "fsn1",
                    "price_hourly": {
                        "net": "0.0063000000",
                        "gross": "0.0063000000000000"
                    },
                    "price_monthly": {
                        "net": "3.8500000000",
                        "gross": "3.8500000000000000"
                    }
                }
            ],
            "storage_type": "local",
            "cpu_type": "shared",
            "architecture": "x86",
            "included_traffic": 21990232555520,
            "deprecation": null
        },
        "datacenter": {
            "id": 5,
            "name": "ash-dc1",
            "description": "Ashburn virtual DC 1",
            "location": {
                "id": 4,
                "name": "ash",
                "description": "Ashburn, VA",
                "country": "US",
                "city": "Ashburn, VA",
                "latitude": 39.045821,
                "longitude": -77.487073,
                "network_zone": "us-east"
            },
            "server_types": {
                "supported": [
                    1,
                    3,
                    5,
                    7,
                    9,
                    22,
                    23,
                    24,
                    25,
                    26,
                    45,
                    93,
                    94,
                    95,
                    96,
                    97,
                    98,
                    99,
                    100,
                    101
                ],
                "available": [
                    22,
                    23,
                    24,
                    25,
                    26,
                    96,
                    97,
                    98,
                    99,
                    100,
                    101
                ],
                "available_for_migration": [
                    22,
                    23,
                    24,
                    25,
                    26,
                    96,
                    97,
                    98,
                    99,
                    100,
                    101
                ]
            }
        },
        "image": {
            "id": 45557056,
            "type": "system",
            "status": "available",
            "name": "debian-11",
            "description": "Debian 11",
            "image_size": null,
            "disk_size": 5,
            "created": "2021-08-16T11:12:01+00:00",
            "created_from": null,
            "bound_to": null,
            "os_flavor": "debian",
            "os_version": "11",
            "rapid_deploy": true,
            "protection": {
                "delete": false
            },
            "deprecated": null,
            "labels": {},
            "deleted": null,
            "architecture": "x86"
        },
        "iso": null,
        "rescue_enabled": false,
        "locked": false,
        "backup_window": "02-06",
        "outgoing_traffic": null,
        "ingoing_traffic": null,
        "included_traffic": 21990232555520,
        "protection": {
            "delete": false,
            "rebuild": false
        },
        "labels": {},
        "volumes": [
            100110783
        ],
        "load_balancers": [],
        "primary_disk_size": 40,
        "placement_group": {
            "id": 270756,
            "name": "placement-group-1",
            "labels": {},
            "type": "spread",
            "created": "2023-11-23T02:16:36.803259+00:00",
            "servers": [
                39707330
            ]
        }
    }
}
```
