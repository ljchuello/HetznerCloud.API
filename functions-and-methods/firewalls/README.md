# 🚧 Firewalls

Firewalls can limit the network access to or from your resources.

* When applying a firewall with no in rule all inbound traffic will be dropped. The default for in is DROP.
* When applying a firewall with no out rule all outbound traffic will be accepted. The default for out is ACCEPT.

### Get all Firewalls

Returns all Firewall objects.

```csharp
HetznerCloudClient hetznerCloudClient = new HetznerCloudClient("apiKey");

List<Firewall> list = await hetznerCloudClient.Firewall.Get();
```

### Get a Firewall

Gets a specific Firewall object.

```csharp
HetznerCloudClient hetznerCloudClient = new HetznerCloudClient("apiKey");

Firewall firewall = await hetznerCloudClient.Firewall.Get(1012861);
```

### Create a Firewall

Creates a new Firewall.

Once created, you can start managing the rules in the 'Firewall Actions' section.

```csharp
HetznerCloudClient hetznerCloudClient = new HetznerCloudClient("apiKey");

// Create
Firewall firewall = await hetznerCloudClient.Firewall.Create("firewall example");
```

### Update a Firewall

Updates the Firewall.

```csharp
HetznerCloudClient hetznerCloudClient = new HetznerCloudClient("apiKey");

// Get
Firewall firewall = await hetznerCloudClient.Firewall.Get(1012861);

// Change
firewall.Name = "cyberpanel";

// Update
firewall = await hetznerCloudClient.Firewall.Update(firewall);
```

### Delete a Firewall

Deletes a Firewall.

```csharp
HetznerCloudClient hetznerCloudClient = new HetznerCloudClient("apiKey");

// Get
Firewall firewall = await hetznerCloudClient.Firewall.Get(1012861);

// You can delete it by passing the Firewall as a parameter
await hetznerCloudClient.Firewall.Delete(firewall);

// You can also delete it by passing the Firewall ID as a parameter.
await hetznerCloudClient.Firewall.Delete(1012861);
```

#### JSON

```json
{
    "firewall": {
        "id": 1112794,
        "name": "firewall-example",
        "labels": {},
        "created": "2023-11-05T19:40:21.506374+00:00",
        "rules": [
            {
                "direction": "in",
                "protocol": "tcp",
                "port": "80",
                "source_ips": [
                    "0.0.0.0/0",
                    "::/0"
                ],
                "destination_ips": [],
                "description": null
            },
            {
                "direction": "in",
                "protocol": "tcp",
                "port": "443",
                "source_ips": [
                    "0.0.0.0/0",
                    "::/0"
                ],
                "destination_ips": [],
                "description": null
            },
            {
                "direction": "in",
                "protocol": "tcp",
                "port": "15-20",
                "source_ips": [
                    "0.0.0.0/0",
                    "::/0"
                ],
                "destination_ips": [],
                "description": null
            },
            {
                "direction": "out",
                "protocol": "tcp",
                "port": "any",
                "source_ips": [],
                "destination_ips": [
                    "0.0.0.0/0",
                    "::/0"
                ],
                "description": null
            }
        ],
        "applied_to": [
            {
                "type": "server",
                "server": {
                    "id": 38976603
                }
            }
        ]
    }
}
```
