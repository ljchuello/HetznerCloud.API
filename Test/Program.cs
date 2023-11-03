using HetznerCloudApi;
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

                List<Action> list = await hetznerCloudClient.VolumeAction.GetAllActions();

                long actionId = 1236866267;

                Action action = await hetznerCloudClient.VolumeAction.GetAction(actionId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.ReadLine();
            }
        }
    }
}