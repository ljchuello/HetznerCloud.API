# Volumes Actions

### Attach Volume to a Server

Attaches a Volume to a Server. Works only if the Server is in the same Location as the Volume.

```csharp
HetznerCloudClient hetznerCloudClient = new HetznerCloudClient("ApiKey");
                
long volumeId = 100051962;
long serverId = 38911232;

Action action = await hetznerCloudClient.VolumeAction.Attach(volumeId, serverId);
```

### Detach Volume

Detaches a Volume from the Server it’s attached to. You may attach it to a Server again at a later time.

```csharp
HetznerCloudClient hetznerCloudClient = new HetznerCloudClient("ApiKey");
                
long volumeId = 100051962;

Action action = await hetznerCloudClient.VolumeAction.Detach(volumeId);
```

### Resize Volume

Changes the size of a Volume. Note that downsizing a Volume is not possible.

```csharp
HetznerCloudClient hetznerCloudClient = new HetznerCloudClient("ApiKey");
                
long volumeId = 100051962;
long size = 101; // Volume size in GB

Action action = await hetznerCloudClient.VolumeAction.Resize(volumeId, size);
```

### Change Volume Protection

Changes the protection configuration of a Volume.

```csharp
HetznerCloudClient hetznerCloudClient = new HetznerCloudClient("ApiKey");
                
long volumeId = 100051962;
bool protection = true; // True => Enable protection | False => Disable protection

Action action = await hetznerCloudClient.VolumeAction.ChangeProtection(volumeId, protection);
```

### Get all Actions for a Volume

Returns all Action objects for a Volume.

```csharp
HetznerCloudClient hetznerCloudClient = new HetznerCloudClient("ApiKey");

long volumeId = 100051962;

List<Action> list = await hetznerCloudClient.VolumeAction.GetAllActions(volumeId);
```

### Get an Action for a Volume

Returns a specific Action for a Volume.

```csharp
HetznerCloudClient hetznerCloudClient = new HetznerCloudClient("ApiKey");
             
long volumeId = 100051962;
long actionId = 1236866267;

Action action = await hetznerCloudClient.VolumeAction.GetAction(volumeId, actionId);
```

\*\*

### Get all Actions

Returns all Action objects.

```csharp
HetznerCloudClient hetznerCloudClient = new HetznerCloudClient("ApiKey");

List<Action> list = await hetznerCloudClient.VolumeAction.GetAllActions();
```

### Get an Action

Returns a specific Action.

```csharp
HetznerCloudClient hetznerCloudClient = new HetznerCloudClient("ApiKey");

long actionId = 1236866267;

Action action = await hetznerCloudClient.VolumeAction.GetAction(actionId);
```
