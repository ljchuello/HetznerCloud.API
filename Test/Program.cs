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

                for (int i = 1; i <= 100; i++)
                {
                    Console.WriteLine(i);
                    Volume volume = await hetznerCloudClient.Volume.Create($"{Guid.NewGuid()}", 10, VolumeFormat.xfs, 3);
                    await hetznerCloudClient.Volume.Delete(volume);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.ReadLine();
            }
        }
    }
}