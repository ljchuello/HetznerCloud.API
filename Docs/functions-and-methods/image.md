# 📸 Image

The images are blueprints for your VM disks. They can be of different types: system images, snapshot images, or backup images.

## Get all Images

Returns all Image objects.

```csharp
HetznerCloudClient hetznerCloudClient = new HetznerCloudClient("apiKey");

List<Image> listImage = await hetznerCloudClient.Image.Get();
```

## Get an Image

Returns a specific Image object.

```csharp
HetznerCloudClient hetznerCloudClient = new HetznerCloudClient("apiKey");

Image image = await hetznerCloudClient.Image.Get(123);
```

## **JSON**

```json
{
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
    }
}
```
