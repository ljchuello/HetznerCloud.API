# 🌎 Datacenter

Each Datacenter represents a virtual Datacenter which is made up of possible many physical Datacenters where Servers are hosted.

### Get all Datacenters

Returns all Datacenter objects.

```csharp
HetznerCloudClient hetznerCloudClient = new HetznerCloudClient("apiKey");

// Get All
List<Datacenter> listDatacenters = await hetznerCloudClient.Datacenter.Get();
```

### Get a Datacenter

Returns a specific Datacenter object.

```csharp
HetznerCloudClient hetznerCloudClient = new HetznerCloudClient("apiKey");

// Set ID
long DatacenterId = 3;

// Get
Datacenter datacenter = await hetznerCloudClient.Datacenter.Get(DatacenterId);
```

### eDataCenter

The `eDataCenter` enum has also been created for the purpose of standardizing resource creation

| Datacenter ID | Location ID | Name | Ciudad        | Network Zone |
| ------------- | ----------- | ---- | ------------- | ------------ |
| 4             | 1           | fsn1 | Falkenstein   | eu-central   |
| 2             | 2           | nbg1 | Nuremberg     | eu-central   |
| 3             | 3           | hel1 | Helsinki      | eu-central   |
| 5             | 4           | ash  | Ashburn, VA   | us-east      |
| 6             | 5           | hil  | Hillsboro, OR | us-west      |

#### JSON

```json
{
    "datacenter": {
        "description": "Helsinki 1 virtual DC 2",
        "id": 3,
        "location": {
            "city": "Helsinki",
            "country": "FI",
            "description": "Helsinki DC Park 1",
            "id": 3,
            "latitude": 60.169855,
            "longitude": 24.938379,
            "name": "hel1",
            "network_zone": "eu-central"
        },
        "name": "hel1-dc2",
        "server_types": {
            "available": [
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
            "available_for_migration": [
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
            "supported": [
                9,
                7,
                5,
                3,
                1,
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
            ]
        }
    }
}
```
