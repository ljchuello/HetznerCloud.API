using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using HetznerCloudApi.Object.Server;
using HetznerCloudApi.Object.Server.Get;

namespace HetznerCloudApi.Client
{
    public class ServerClient
    {
        private readonly string _token;

        public ServerClient(string token)
        {
            _token = token;
        }

        public async Task<List<Server>> Get()
        {
            List<Server> list = new List<Server>();
            long page = 0;
            while (true)
            {
                // Nex
                page++;

                // Get list
                Response response = JsonConvert.DeserializeObject<Response>(await Core.SendGetRequest(_token, $"/servers?page={page}&per_page={Core.PerPage}")) ?? new Response();

                // Run
                foreach (Server row in response.Servers)
                {
                    list.Add(row);
                }

                // Finish?
                if (response.Meta.Pagination.NextPage == 0)
                {
                    // Yes, finish
                    return list;
                }
            }
        }

        public async Task<Server> Get(long id)
        {
            // Get list
            string json = await Core.SendGetRequest(_token, $"/servers/{id}");

            // Set
            JObject result = JObject.Parse(json);
            Server server = JsonConvert.DeserializeObject<Server>($"{result["servers"]}") ?? new Server();

            // Return
            return server;
        }
    }
}
