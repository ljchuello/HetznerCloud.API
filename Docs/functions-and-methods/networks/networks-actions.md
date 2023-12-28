# Networks Actions

## Add a subnet to a Network

Adds a new subnet object to the Network. If you do not specify an ip\_range for the subnet we will automatically pick the first available /24 range for you if possible.

```csharp
HetznerCloudClient hetznerCloudClient = new HetznerCloudClient("ApiKey");

long networkId = 3553797;
string ipRange = "192.168.32.0/20";
string networkZone = "eu-central";

Action action = await hetznerCloudClient.NetworkAction.AddSubnetToNetwork(networkId, ipRange, networkZone);
```

## Delete a subnet from a Network

Deletes a single subnet entry from a Network. You cannot delete subnets which still have Servers attached. If you have Servers attached you first need to detach all Servers that use IPs from this subnet before you can delete the subnet.

```csharp
HetznerCloudClient hetznerCloudClient = new HetznerCloudClient("ApiKey");

long networkId = 3553797;
string ipRange = "192.168.32.0/20";

Action action = await hetznerCloudClient.NetworkAction.DeleteSubnetFromNetwork(networkId, ipRange);
```

## Change NetworkProtection

Changes the protection configuration of a Network.

```csharp
HetznerCloudClient hetznerCloudClient = new HetznerCloudClient("ApiKey");

long networkId = 2446116;
bool protection = true; // True => Enable protection | False => Disable protection
Action action = await hetznerCloudClient.NetworkAction.ChangeProtection(networkId, protection);
```

## Get all Actions for a Network

Returns all Action objects for a Network.

```csharp
HetznerCloudClient hetznerCloudClient = new HetznerCloudClient("ApiKey");

long networkId = 100051962;

List<Action> list = await hetznerCloudClient.NetworkAction.GetAllActions(networkId);
```

## Get an Action for a Network

Returns a specific Action for a Network.

```csharp
HetznerCloudClient hetznerCloudClient = new HetznerCloudClient("ApiKey");

long networkId = 100051962;
long actionId = 1236866267;

Action action = await hetznerCloudClient.NetworkAction.GetAction(networkId, actionId);
```

## Get all Actions

Returns all Action objects.

```csharp
HetznerCloudClient hetznerCloudClient = new HetznerCloudClient("ApiKey");

List<Action> list = await hetznerCloudClient.NetworkAction.GetAllActions();
```

## Get an Action

Returns a specific Action.

```csharp
HetznerCloudClient hetznerCloudClient = new HetznerCloudClient("ApiKey");

long actionId = 1236866267;

Action action = await hetznerCloudClient.NetworkAction.GetAction(actionId);
```
