using HetznerCloudApi;
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
                HetznerCloudClient hetznerCloudClient = new HetznerCloudClient("ApiKey");
                
                hetznerCloudClient = new HetznerCloudClient(await File.ReadAllTextAsync("D:\\HetznerApiKey.txt"));

                Volume volume = await hetznerCloudClient.Volume.Get(100051904);

                await hetznerCloudClient.Volume.Delete(volume);

                await hetznerCloudClient.Volume.Delete(100051904);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.ReadLine();
            }
        }
    }
}