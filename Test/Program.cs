using System.Reflection.Metadata.Ecma335;
using HetznerCloudApi;
using HetznerCloudApi.Object.Firewall;
using HetznerCloudApi.Object.Network;
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

// Get one
Network network = await hetznerCloudClient.Network.Get(3550103);

// You can delete it by passing the object as a parameter
await hetznerCloudClient.Network.Delete(network);

// // You can also delete it by passing the ID as a parameter.
await hetznerCloudClient.Network.Delete(3550103);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.ReadLine();
            }
        }
    }
}