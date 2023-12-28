# Firewalls Actions

Firewalls can limit the network access to or from your resources.

* When applying a firewall with no in rule all inbound traffic will be dropped. The default for in is DROP.
* When applying a firewall with no out rule all outbound traffic will be accepted. The default for out is ACCEPT.

### Apply to Resources

Applies one Firewall to multiple resources.

```csharp
HetznerCloudClient hetznerCloudClient = new HetznerCloudClient("ApiKey");

// Get
Firewall firewall = await hetznerCloudClient.Firewall.Get(1012861);

long serverId = 38976603;

// Apply to resources
List<Action> listAcionAction = await hetznerCloudClient.FirewallAction.ApplyToResources(firewall.Id, serverId);
```

### Remove from Resources

Removes one Firewall from multiple resources.

```csharp
HetznerCloudClient hetznerCloudClient = new HetznerCloudClient("ApiKey");

// Get
Firewall firewall = await hetznerCloudClient.Firewall.Get(1012861);

long serverId = 38976603;

// Remove from Resources
List<Action> listAcionAction = await hetznerCloudClient.FirewallAction.RemoveFromResources(firewall.Id, serverId);
```

### Set Rules

Sets the rules of a Firewall.

To establish the rules it is important to take into account that;

1. Rules are not removed, they are replaced
2. The rules cannot be obtained directly, the rules are obtained from the Rules property of the Firewall object
3. If there are no ingress rules, it will allow all incoming traffic
4. If there are no outbound rules, it will allow all outbound traffic

For the first example we are going to allow access to ports 80 and 22

```csharp
HetznerCloudClient hetznerCloudClient = new HetznerCloudClient("ApiKey");

// Get the object
Firewall firewall = await hetznerCloudClient.Firewall.Get(1012861);

// List rules
List<Rule> listRules = new List<Rule>();

// Enable port 80 / tcp / in / All traffic ipv4 and ipv6
listRules.Add(new Rule
{
    Direction = Direction.@in,
    Protocol = Protocol.tcp,
    Port = "80",
    Description = "Port 80 for http",
    SourceIps = new List<string> { "0.0.0.0/0", "::/0" }
});

// Enable port 22 / tcp / in / All traffic ipv4 and ipv6
listRules.Add(new Rule
{
    Direction = Direction.@in,
    Protocol = Protocol.tcp,
    Port = "22",
    Description = "Port 22 for https",
    SourceIps = new List<string> { "0.0.0.0/0", "::/0" }
});

// Send rules
List<Action> listAction = await hetznerCloudClient.FirewallAction.SetRulesTask(firewall, listRules);
```

Now, we are going to allow all outgoing traffic (although it is redundant because not specifying this will allow all traffic)

Notice how we use `List<Rule> listRules = firewall.Rules;` this is to keep the current rules and add a new one. If we don't do this, we would be replacing the existing rules with the new ones.

In other words, if we don't do this, the new rules will replace the old ones, and the old ones will be deleted.

```csharp
// Get the object
Firewall firewall = await hetznerCloudClient.Firewall.Get(1012861);

// Get pre-existing rules
List<Rule> listRules = firewall.Rules;

//Add new rule
listRules.Add(new Rule()
{
    Direction = Direction.@out,
    Protocol = Protocol.tcp,
    Port = "any",
    Description = "All port out open",
    DestinationIps = new List<string> { "0.0.0.0/0", "::/0" }
});

// Set rules
List<Action> listAction = await hetznerCloudClient.FirewallAction.SetRules(firewall, listRules);
```

### Get all Actions for a Firewall

Returns all Action objects for a Firewall.

```csharp
HetznerCloudClient hetznerCloudClient = new HetznerCloudClient("ApiKey");

long firewallId = 1012861;

List<Action> list = await hetznerCloudClient.FirewallAction.GetAllActions(firewallId);
```

### Get an Action for a Firewall

Returns a specific Action for a Firewall.

```csharp
HetznerCloudClient hetznerCloudClient = new HetznerCloudClient("ApiKey");
             
long firewallId = 1012861;
long actionId = 1124587761;

Action action = await hetznerCloudClient.FirewallAction.GetAction(firewallId, actionId);
```

### Get all Actions

Returns all Action objects.

```csharp
HetznerCloudClient hetznerCloudClient = new HetznerCloudClient("ApiKey");

List<Action> list = await hetznerCloudClient.FirewallAction.GetAllActions();
```

### Get an Action

Returns a specific Action.

```csharp
HetznerCloudClient hetznerCloudClient = new HetznerCloudClient("ApiKey");

long actionId = 1124587761;

Action action = await hetznerCloudClient.FirewallAction.GetAction(actionId);
```
