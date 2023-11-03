using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using HetznerCloudApi.Object.Location;
using HetznerCloudApi.Object.Location.Get;
using Newtonsoft.Json.Linq;

namespace HetznerCloudApi.Client
{
    public class LocationClient
    {
        private readonly string _token;

        public LocationClient(string token)
        {
            _token = token;
        }

        /// <summary>
        /// Returns all Locations objects.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Location>> Get()
        {
            List<Location> listImage = new List<Location>();
            long page = 0;
            while (true)
            {
                // Nex
                page++;

                // Get list
                Response response = JsonConvert.DeserializeObject<Response>(await Core.SendGetRequest(_token, $"/locations?page={page}&per_page={Core.PerPage}")) ?? new Response();

                // Run
                foreach (Location row in response.Locations)
                {
                    listImage.Add(row);
                }

                // Finish?
                if (response.Meta.Pagination.NextPage == 0)
                {
                    // Yes, finish
                    return listImage;
                }
            }
        }

        /// <summary>
        /// Returns a specific Location object
        /// </summary>
        /// <param name="id">ID of the Location</param>
        /// <returns></returns>
        public async Task<Location> Get(long id)
        {
            // Get list
            string json = await Core.SendGetRequest(_token, $"/locations/{id}");

            // Set
            JObject result = JObject.Parse(json);
            Location location = JsonConvert.DeserializeObject<Location>($"{result["location"]}") ?? new Location();

            // Return
            return location;
        }
    }
}
