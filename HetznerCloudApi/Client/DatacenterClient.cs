using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using HetznerCloudApi.Object.Datacenter;
using Newtonsoft.Json.Linq;
using HetznerCloudApi.Object.Datacenter.Response;

namespace HetznerCloudApi.Client
{
    public class DatacenterClient
    {
        private readonly string _token;

        public DatacenterClient(string token)
        {
            _token = token;
        }

        /// <summary>
        /// Returns all Datacenter objects.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Datacenter>> Get()
        {
            List<Datacenter> listDatacenters = new List<Datacenter>();
            long page = 0;
            while (true)
            {
                // Nex
                page++;

                // Get list
                Response response = JsonConvert.DeserializeObject<Response>(await Core.SendGetRequest(_token, $"/datacenters?page={page}&per_page={Core.PerPage}")) ?? new Response();

                // Run
                foreach (Datacenter row in response.Datacenters)
                {
                    listDatacenters.Add(row);
                }

                // Finish?
                if (response.Meta.Pagination.NextPage == 0)
                {
                    // Yes, finish
                    return listDatacenters;
                }
            }
        }

        /// <summary>
        /// Returns a specific Datacenter object
        /// </summary>
        /// <param name="id">ID of the Datacenter</param>
        /// <returns></returns>
        public async Task<Datacenter> Get(long id)
        {
            // Get list
            string json = await Core.SendGetRequest(_token, $"/datacenters/{id}");

            // Set
            JObject result = JObject.Parse(json);
            Datacenter datacenter = JsonConvert.DeserializeObject<Datacenter>($"{result["datacenter"]}") ?? new Datacenter();

            // Return
            return datacenter;
        }
    }
}
