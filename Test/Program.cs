using HetznerCloudApi;
using HetznerCloudApi.Client;
using HetznerCloudApi.Object.Datacenter;
using HetznerCloudApi.Object.Location;
using HetznerCloudApi.Object.Volume;

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
                HetznerCloudClient hetznerCloudClient = new HetznerCloudClient(await File.ReadAllTextAsync("D:\\HetznerApiKey.txt"));

                var a = await hetznerCloudClient.Volume.Create("abc123", 10, VolumeFormat.xfs, 5);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.ReadLine();
            }
        }
    }
}