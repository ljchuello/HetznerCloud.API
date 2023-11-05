using HetznerCloudApi;
using HetznerCloudApi.Object.Firewall;
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

                // Get the object
                Firewall firewall = await hetznerCloudClient.Firewall.Get(1012861);

                // Get pre-existing rules
                List<Rule> listRules = firewall.Rules;

                //Add new rule
                listRules.Add(new Rule()
                {
                    Direction = Direction.@out,
                    Protocol = Protocol.tcp,
                    Port = "any",
                    Description = "All port out open",
                    DestinationIps = new List<string> { "0.0.0.0/0", "::/0" }
                });

                // Set rules
                List<Action> listAction = await hetznerCloudClient.FirewallAction.SetRules(firewall, listRules);

                Console.WriteLine();
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