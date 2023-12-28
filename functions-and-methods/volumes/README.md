# 📦 Volumes

A Volume is a highly-available, scalable, and SSD-based block storage for Servers.

Pricing for Volumes depends on the Volume size and Location, not the actual used storage.

Please see [Hetzner Docs](https://docs.hetzner.com/cloud/#Volumes) for more details about Volumes.

### Get all Volumes

Gets all existing Volumes that you have available.

```csharp
HetznerCloudClient hetznerCloudClient = new HetznerCloudClient("ApiKey");

// Get All
List<Volume> listVolume = await hetznerCloudClient.Volume.Get();
```

### Get a Volume

Gets a specific Volume object.

```csharp
HetznerCloudClient hetznerCloudClient = new HetznerCloudClient("ApiKey");

long volumeId = 100051904;

// Get
Volume volume = await hetznerCloudClient.Volume.Get(volumeId);
```

### Update a Volume

Updates the Volume properties.

```csharp
HetznerCloudClient hetznerCloudClient = new HetznerCloudClient("ApiKey");

// Get
Volume volume = await hetznerCloudClient.Volume.Get(100051904);

// Change name
volume.Name = "new-name";

// Set
volume = await hetznerCloudClient.Volume.Update(volume);
```

### Delete a Volume

Deletes a volume. All Volume data is irreversibly destroyed. The Volume must not be attached to a Server and it must not have delete protection enabled.

```csharp
HetznerCloudClient hetznerCloudClient = new HetznerCloudClient("ApiKey");

// Get
Volume volume = await hetznerCloudClient.Volume.Get(100051904);

// You can delete it by passing the Volume as a parameter
await hetznerCloudClient.Volume.Delete(volume);

// You can also delete it by passing the Volume ID as a parameter.
await hetznerCloudClient.Volume.Delete(100051904);
```

#### JSON

```json
{
    "volume": {
        "created": "2023-11-05T14:36:19Z",
        "format": "ext4",
        "id": 100056342,
        "labels": {},
        "linux_device": "/dev/disk/by-id/scsi-0HC_Volume_100056342",
        "location": {
            "city": "Ashburn, VA",
            "country": "US",
            "description": "Ashburn, VA",
            "id": 4,
            "latitude": 39.045821,
            "longitude": -77.487073,
            "name": "ash",
            "network_zone": "us-east"
        },
        "name": "volume-ash-1",
        "protection": {
            "delete": false
        },
        "server": 38976603,
        "size": 101,
        "status": "available"
    }
}
```
