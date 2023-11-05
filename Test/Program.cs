using System.Data;
using HetznerCloudApi;
using HetznerCloudApi.Object.SshKey;
using Action = HetznerCloudApi.Object.Action.Action;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MainAsync().Wait();
        }

        static async Task MainAsync()
        {
            try
            {
HetznerCloudClient hetznerCloudClient = new HetznerCloudClient("ApiKey");
hetznerCloudClient = new HetznerCloudClient(await File.ReadAllTextAsync("D:\\HetznerApiKey.txt"));

// Get
SshKey sshKey = await hetznerCloudClient.SshKey.Get(16725981);

// You can delete it by passing the Volume as a parameter
await hetznerCloudClient.SshKey.Delete(sshKey);

// You can also delete it by passing the Volume ID as a parameter.
await hetznerCloudClient.SshKey.Delete(16725981);


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.ReadLine();
            }
        }
    }
}