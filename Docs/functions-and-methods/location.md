# 🗺️ Location

Datacenters are organized by Locations. Datacenters in the same Location are connected with very low latency links.

## Get all Locations

Returns all Location objects.

```csharp
HetznerCloudClient hetznerCloudClient = new HetznerCloudClient("apiKey");

// Get All
List<Location> listLocation = await hetznerCloudClient.Location.Get();
```

## Get a Location

Returns a specific Location object.

```csharp
HetznerCloudClient hetznerCloudClient = new HetznerCloudClient("apiKey");

// Set ID
long LocationId = 2;

// Get
Location location = await hetznerCloudClient.Location.Get(LocationId);
```

## eDataCenter

The `eDataCenter` enum has also been created for the purpose of standardizing resource creation

| Datacenter ID | Location ID | Name | Ciudad        | Network Zone |
| ------------- | ----------- | ---- | ------------- | ------------ |
| 4             | 1           | fsn1 | Falkenstein   | eu-central   |
| 2             | 2           | nbg1 | Nuremberg     | eu-central   |
| 3             | 3           | hel1 | Helsinki      | eu-central   |
| 5             | 4           | ash  | Ashburn, VA   | us-east      |
| 6             | 5           | hil  | Hillsboro, OR | us-west      |

## **JSON**

```json
{
    "location": {
        "city": "Nuremberg",
        "country": "DE",
        "description": "Nuremberg DC Park 1",
        "id": 2,
        "latitude": 49.452102,
        "longitude": 11.076665,
        "name": "nbg1",
        "network_zone": "eu-central"
    }
}
```
