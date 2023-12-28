# 🔐 SSH Keys

SSH keys are public keys you provide to the cloud system. They can be injected into Servers at creation time. We highly recommend that you use keys instead of passwords to manage your Servers.

## Get all SSH keys

Returns all SSH key objects.

```csharp
HetznerCloudClient hetznerCloudClient = new HetznerCloudClient("ApiKey");

List<SshKey> list = await hetznerCloudClient.SshKey.Get();
```

## Get a SSH key

Returns a specific SSH key object.

```csharp
HetznerCloudClient hetznerCloudClient = new HetznerCloudClient("ApiKey");

long sshKeyId = 13121954;

SshKey sshKey = await hetznerCloudClient.SshKey.Get(sshKeyId);
```

## Create an SSH key

Creates a new SSH key with the given name and public\_key. Once an SSH key is created, it can be used in other calls such as creating Servers.

```csharp
HetznerCloudClient hetznerCloudClient = new HetznerCloudClient("ApiKey");

// We rely on the 'SshKeyGenerator' library to generate SSH credentials.
SshKeyGenerator.SshKeyGenerator sshKeyGenerator = new SshKeyGenerator.SshKeyGenerator(2048);

string name = $"name";
string pub = sshKeyGenerator.ToRfcPublicKey($"{Guid.NewGuid()}");

SshKey sshKey = await hetznerCloudClient.SshKey.Create(name, pub);
```

## Update an SSH key

Updates an SSH key. You can update an SSH key name and an SSH key labels.

```csharp
HetznerCloudClient hetznerCloudClient = new HetznerCloudClient("ApiKey");

// Get
SshKey sshKey = await hetznerCloudClient.SshKey.Get(16725981);

// Change name
sshKey.Name = $"new-name-{Guid.NewGuid()}";

// Update
sshKey = await hetznerCloudClient.SshKey.Update(sshKey);
```

## Delete a Volume

Deletes a volume. All Volume data is irreversibly destroyed. The Volume must not be attached to a Server and it must not have delete protection enabled.

```csharp
HetznerCloudClient hetznerCloudClient = new HetznerCloudClient("ApiKey");

// Get
SshKey sshKey = await hetznerCloudClient.SshKey.Get(16725981);

// You can delete it by passing the object as a parameter
await hetznerCloudClient.SshKey.Delete(sshKey);

// You can also delete it by passing the ID as a parameter.
await hetznerCloudClient.SshKey.Delete(16725981);
```

## **JSON**

```json
{
    "ssh_key": {
        "id": 16371855,
        "name": "MT5",
        "fingerprint": "5b:3a:fe:c9:88:24:6a:c8:ed:ff:7b:38:07:03:40:4d",
        "public_key": "ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABAQCsRjE/G6WYoLQgxjP8h00fwEowwiJ4EgB9HHrnIy3Z5JthxrKJe5RQSSUa5Qsz8+OgJtDVAKn++twM9tcF63Kna8YpEgvZSAkEEcz14a0KuuWpe/Kh4qw2jJTyuk6pmdT9+gMMq6X9IyrfkwgyPsCJEjVxsDHAWU2Ym5LA+e7WRQtoq+JNVzAJ0cNIU5/gEnYVz8KGrsUkBDCFeoBenwl8ss+nwumNo9Lnf2TCOegBFGph0m+wrRzE8Y1NnRoanuSVV0zSwZXlrhdf0Jqz8CX+cDjN9r6p0HIH+dVCY1iBQvYsE28Cs13WfpY/wfSjuKtjYE2p6jmZtrdDduXC+Qn5",
        "labels": {},
        "created": "2023-10-24T01:58:43+00:00"
    }
}
```
