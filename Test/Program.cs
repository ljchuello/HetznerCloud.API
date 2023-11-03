using HetznerCloudApi;
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

                List<Location> listLocation = await hetznerCloudClient.Location.Get();

                long LocationId = 2;

                Location location = await hetznerCloudClient.Location.Get(LocationId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.ReadLine();
            }
        }
    }
}