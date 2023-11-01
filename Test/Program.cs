using HetznerCloudApi;
using HetznerCloudApi.Object.Image;
using HetznerCloudApi.Object.ServerType;

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

                //List<ServerType> a = await hetznerCloudClient.ServerType.Get();
                //ServerType b = await hetznerCloudClient.ServerType.Get(a[0].Id);
                //ServerType c = await hetznerCloudClient.ServerType.Get(5555);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.ReadLine();
            }
        }
    }
}