using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using HetznerCloudApi.Object.Firewall;
using HetznerCloudApi.Object.Firewall.Get;
using Newtonsoft.Json.Linq;

namespace HetznerCloudApi.Client
{
    public class FirewallClient
    {
        private readonly string _token;

        public FirewallClient(string token)
        {
            _token = token;
        }

        /// <summary>
        /// Returns all Firewall objects.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Firewall>> Get()
        {
            List<Firewall> list = new List<Firewall>();
            long page = 0;
            while (true)
            {
                // Nex
                page++;

                // Get list
                Response response = JsonConvert.DeserializeObject<Response>(await Core.SendGetRequest(_token, $"/firewalls?page={page}&per_page={Core.PerPage}")) ?? new Response();

                // Run
                foreach (Firewall row in response.Firewalls)
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
        /// Gets a specific Firewall object.
        /// </summary>
        /// <param name="id">ID of the resource</param>
        /// <returns></returns>
        public async Task<Firewall> Get(long id)
        {
            // Get list
            string json = await Core.SendGetRequest(_token, $"/firewalls/{id}");

            // Set
            JObject result = JObject.Parse(json);
            Firewall firewall = JsonConvert.DeserializeObject<Firewall>($"{result["firewall"]}") ?? new Firewall();

            // Return
            return firewall;
        }

        /// <summary>
        /// Creates a new Firewall.
        /// </summary>
        /// <param name="name">Name of the Firewall</param>
        /// <returns></returns>
        public async Task<Firewall> Create(string name)
        {
            // Preparing raw
            string raw = $"{{ \"name\": \"{name}\" }}";

            // Send post
            string jsonResponse = await Core.SendPostRequest(_token, "/firewalls", raw);

            // Return
            JObject result = JObject.Parse(jsonResponse);
            return JsonConvert.DeserializeObject<Firewall>($"{result["firewall"]}") ?? new Firewall();
        }

        /// <summary>
        /// Updates the Firewall.
        /// </summary>
        /// <param name="firewall"></param>
        /// <returns></returns>
        public async Task<Firewall> Update(Firewall firewall)
        {
            // Preparing raw
            string raw = $"{{\"name\":\"{firewall.Name}\"}}";

            // Send update
            string jsonResponse = await Core.SendPutRequest(_token, $"/firewalls/{firewall.Id}", raw);

            // Return
            JObject result = JObject.Parse(jsonResponse);
            return JsonConvert.DeserializeObject<Firewall>($"{result["firewall"]}") ?? new Firewall();
        }

        /// <summary>
        /// Deletes a Firewall.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task Delete(long id)
        {
            await Core.SendDeleteRequest(_token, $"/firewalls/{id}");
        }

        /// <summary>
        /// Deletes a Firewall.
        /// </summary>
        /// <param name="firewall"></param>
        /// <returns></returns>
        public async Task Delete(Firewall firewall)
        {
            await Delete(firewall.Id);
        }
    }
}
