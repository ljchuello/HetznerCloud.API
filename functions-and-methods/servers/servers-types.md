# Servers Types

Server types define kinds of Servers offered. Each type has an hourly and a monthly cost. You will pay whichever cost is lower for your usage of this specific Server. Costs may differ between Locations.

Currency for all amounts is €. All prices exclude VAT.

### Get all Server Types

Gets all Server type objects.

```csharp
HetznerCloudClient hetznerCloudClient = new HetznerCloudClient("apiKey");

// Get All
List<ServerType> listServerTypes = await hetznerCloudClient.ServerType.Get();
```

### Get a Server Type

Gets a specific Server type object.

```csharp
HetznerCloudClient hetznerCloudClient = new HetznerCloudClient("apiKey");

// Set ID
long serverTypeId = 15,

// Get
ServerType serverType = await hetznerCloudClient.ServerType.Get(serverTypeId);
```

#### JSON

```json
{
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
    }
}
```
