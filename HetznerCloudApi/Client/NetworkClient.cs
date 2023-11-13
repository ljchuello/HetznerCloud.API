using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using HetznerCloudApi.Object.Network;
using HetznerCloudApi.Object.Network.Get;
using HetznerCloudApi.Object.SshKey;

namespace HetznerCloudApi.Client
{
    public class NetworkClient
    {
        private readonly string _token;

        public NetworkClient(string token)
        {
            _token = token;
        }

        /// <summary>
        /// Gets all existing networks that you have available.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Network>> Get()
        {
            List<Network> list = new List<Network>();
            long page = 0;
            while (true)
            {
                // Nex
                page++;

                // Get list
                Response response = JsonConvert.DeserializeObject<Response>(await Core.SendGetRequest(_token, $"/networks?page={page}&per_page={Core.PerPage}")) ?? new Response();

                // Run
                foreach (Network row in response.Networks)
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

        /// <summary>
        /// Gets a specific network object.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Network> Get(long id)
        {
            // Get list
            string json = await Core.SendGetRequest(_token, $"/networks/{id}");

            // Set
            JObject result = JObject.Parse(json);
            Network network = JsonConvert.DeserializeObject<Network>($"{result["network"]}") ?? new Network();

            // Return
            return network;
        }

        /// <summary>
        /// Creates a network with the specified ip_range.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="ipRange"></param>
        /// <returns></returns>
        public async Task<Network> Create(string name, string ipRange)
        {
            // Preparing raw
            string raw = $"{{ \"name\": \"{name}\", \"ip_range\": \"{ipRange}\" }}";

            // Send post
            string jsonResponse = await Core.SendPostRequest(_token, "/networks", raw);

            // Return
            JObject result = JObject.Parse(jsonResponse);
            return JsonConvert.DeserializeObject<Network>($"{result["network"]}") ?? new Network();
        }

        /// <summary>
        /// Update the network name.
        /// </summary>
        /// <param name="network"></param>
        /// <returns></returns>
        public async Task<Network> Update(Network network)
        {
            // Preparing raw
            string raw = $"{{ \"name\": \"{network.Name}\" }}";

            // Send post
            string jsonResponse = await Core.SendPutRequest(_token, $"/networks/{network.Id}", raw);

            // Return
            JObject result = JObject.Parse(jsonResponse);
            return JsonConvert.DeserializeObject<Network>($"{result["network"]}") ?? new Network();
        }

        /// <summary>
        /// Delete a Network
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task Delete(long id)
        {
            await Core.SendDeleteRequest(_token, $"/networks/{id}");
        }

        /// <summary>
        /// Delete a Network
        /// </summary>
        /// <param name="network"></param>
        /// <returns></returns>
        public async Task Delete(Network network)
        {
            await Delete(network.Id);
        }
    }
}
