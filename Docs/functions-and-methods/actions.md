# ⏰ Actions

## Get all Actions

Returns all Action objects.

```csharp
HetznerCloudClient hetznerCloudClient = new HetznerCloudClient("ApiKey");

List<Action> list = await hetznerCloudClient.Action.Get();
```

## Get an Action

Returns a specific Action.

```csharp
HetznerCloudClient hetznerCloudClient = new HetznerCloudClient("ApiKey");

long actionId = 1236866267;

Action action = await hetznerCloudClient.Action.Get(actionId);
```
