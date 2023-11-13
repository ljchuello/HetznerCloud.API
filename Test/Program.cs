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

                long netoworkId = 3553797;
                string ipRange = "192.168.32.0/20";

                Action action = await hetznerCloudClient.NetworkAction.ChangeProtection(netoworkId, false);


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.ReadLine();
            }
        }
    }
}