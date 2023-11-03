using HetznerCloudApi;
using HetznerCloudApi.Object.Datacenter;
using HetznerCloudApi.Object.Location;

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

                List<Datacenter> listLocation = await hetznerCloudClient.Datacenter.Get();

                long LocationId = 3;

                Datacenter location = await hetznerCloudClient.Datacenter.Get(LocationId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.ReadLine();
            }
        }
    }
}