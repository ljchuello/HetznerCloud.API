using HetznerCloudApi;
using HetznerCloudApi.Object.Firewall;

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

                // Get
                Firewall firewall = await hetznerCloudClient.Firewall.Get(1012861);

                // You can delete it by passing the Firewall as a parameter
                await hetznerCloudClient.Firewall.Delete(firewall);

                // You can also delete it by passing the Firewall ID as a parameter.
                await hetznerCloudClient.Firewall.Delete(1012861);

                Console.WriteLine();

                //// Set object
                //Firewall firewall = new Firewall();

                //// Set name
                //firewall.Name = "Firewal Example";

                //// NOTE: If an inbound rule is not specified, by default, everything can enter.

                //// 80 tcp in | all ipv4 / all ipv6
                //firewall.Rules.Add(new Rule
                //{
                //    Description = "80 in",
                //    SourceIps = new List<string> { "0.0.0.0/0", "::/0" },
                //    Direction = Direction.@in,
                //    Port = "80",
                //    Protocol = Protocol.tcp,
                //});

                //// 443 tcp in | all ipv4 / all ipv6
                //firewall.Rules.Add(new Rule
                //{
                //    Description = "443 in",
                //    SourceIps = new List<string> { "0.0.0.0/0", "::/0" },
                //    Direction = Direction.@in,
                //    Port = "443",
                //    Protocol = Protocol.tcp,
                //});

                //// 22 tcp in | ipv4 => 200.44.32.12
                //firewall.Rules.Add(new Rule
                //{
                //    Description = "22 in",
                //    SourceIps = new List<string> { "200.44.32.12/32" },
                //    Direction = Direction.@in,
                //    Port = "22",
                //    Protocol = Protocol.tcp,
                //});

                //// NOTE: If an outbound rule is not specified, by default, everything can exit.

                //// 80 tcp out | all ipv4 / all ipv6
                //firewall.Rules.Add(new Rule
                //{
                //    Description = "80 out",
                //    DestinationIps = new List<string> { "0.0.0.0/0", "::/0" },
                //    Direction = Direction.@out,
                //    Port = "80",
                //    Protocol = Protocol.tcp,
                //});

                //// 443 tcp out | all ipv4 / all ipv6
                //firewall.Rules.Add(new Rule
                //{
                //    Description = "443 out",
                //    DestinationIps = new List<string> { "0.0.0.0/0", "::/0" },
                //    Direction = Direction.@out,
                //    Port = "443",
                //    Protocol = Protocol.tcp,
                //});


                //// 22 tcp out | all ipv4 / all ipv6
                //firewall.Rules.Add(new Rule
                //{
                //    Description = "22 out",
                //    DestinationIps = new List<string> { "0.0.0.0/0", "::/0" },
                //    Direction = Direction.@out,
                //    Port = "22",
                //    Protocol = Protocol.tcp,
                //});

                //// NOTE: A recommendation would be to finely tune the inbound rules, allowing only what's necessary, and keeping the outbound rules empty.

                //// Create
                //firewall = await hetznerCloudClient.Firewall.Create(firewall);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.ReadLine();
            }
        }
    }
}