using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using HetznerCloudApi.Object.ServerType;

namespace HetznerCloudApi.Client
{
    public class ServerTypeClient
    {
        private readonly string _token;

        public ServerTypeClient(string token)
        {
            _token = token;
        }

        public async Task<List<ServerType>> Get()
        {
            List<ServerType> listServerType = new List<ServerType>();
            long page = 0;
            while (true)
            {
                // Nex
                page++;

                // Get list
                Response response = JsonConvert.DeserializeObject<Response>(await Core.SendGetRequest(_token, $"/server_types?page={page}&per_page={Core.PerPage}")) ?? new Response();

                // Run
                foreach (ServerType row in response.ServerTypes)
                {
                    listServerType.Add(row);
                }

                // Finish?
                if (response.Meta.Pagination.NextPage == null)
                {
                    // Yes, finish
                    return listServerType;
                }
            }
        }

        public async Task<ServerType> Get(long id)
        {
            // Get list
            string json = await Core.SendGetRequest(_token, $"/server_types/{id}");

            // Set
            JObject result = JObject.Parse(json);
            ServerType serverType = JsonConvert.DeserializeObject<ServerType>($"{result["server_type"]}") ?? new ServerType();

            // Return
            return serverType;
        }
    }
}
