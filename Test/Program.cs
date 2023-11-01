using HetznerCloudApi;
using HetznerCloudApi.Object.Image;

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

                // 67794396

                Image a = await hetznerCloudClient.Image.Get(123);
                var b = await hetznerCloudClient.Image.Get();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.ReadLine();
            }
        }
    }
}