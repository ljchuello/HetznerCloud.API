using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;
using HetznerCloudApi.Object.Volume;
using HetznerCloudApi.Object.Volume.Get;

namespace HetznerCloudApi.Client
{
    public class VolumeClient
    {
        private readonly string _token;

        public VolumeClient(string token)
        {
            _token = token;
        }

        /// <summary>
        /// Gets all existing Volumes that you have available
        /// </summary>
        /// <returns></returns>
        public async Task<List<Volume>> Get()
        {
            List<Volume> list = new List<Volume>();
            long page = 0;
            while (true)
            {
                // Nex
                page++;

                // Get list
                Response response = JsonConvert.DeserializeObject<Response>(await Core.SendGetRequest(_token, $"/volumes?page={page}&per_page={Core.PerPage}")) ?? new Response();

                // Run
                foreach (Volume row in response.Volumes)
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
        /// Gets a specific Volume object
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Volume> Get(long id)
        {
            // Get list
            string json = await Core.SendGetRequest(_token, $"/volumes/{id}");

            // Set
            JObject result = JObject.Parse(json);
            Volume volume = JsonConvert.DeserializeObject<Volume>($"{result["volume"]}") ?? new Volume();

            // Return
            return volume;
        }

        /// <summary>
        /// Create a Volume
        /// </summary>
        /// <param name="name">Name of the volume</param>
        /// <param name="size">Size of the Volume in GB</param>
        /// <param name="volumeFormat">Filesystem of the Volume if formatted on creation, null if not formatted on creation</param>
        /// <param name="locationId">Location to create the Volume</param>
        /// <returns></returns>
        public async Task<Volume> Create(string name, long size, VolumeFormat volumeFormat, long locationId)
        {
            // Preparing raw
            string raw = $"{{\"automount\":false,\"format\":\"{volumeFormat}\",\"location\":{locationId},\"name\":\"{name}\",\"size\":{size}}}";

            // Send post
            string jsonResponse = await Core.SendPostRequest(_token, "/volumes", raw);

            // Return
            JObject result = JObject.Parse(jsonResponse);
            return JsonConvert.DeserializeObject<Volume>($"{result["volume"]}") ?? new Volume();
        }

        /// <summary>
        /// Updates the Volume properties
        /// </summary>
        /// <param name="volume"></param>
        /// <returns></returns>
        public async Task<Volume> Update(Volume volume)
        {
            // Preparing raw
            string raw = $"{{\"name\":\"{volume.Name}\"}}";

            // Send post
            string jsonResponse = await Core.SendPutRequest(_token, $"/volumes/{volume.Id}", raw);

            // Return
            JObject result = JObject.Parse(jsonResponse);
            return JsonConvert.DeserializeObject<Volume>($"{result["volume"]}") ?? new Volume();
        }

        /// <summary>
        /// Deletes a volume. All Volume data is irreversibly destroyed. The Volume must not be attached to a Server and it must not have delete protection enabled.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task Delete(long id)
        {
            // Send post
            await Core.SendDeleteRequest(_token, $"/volumes/{id}");
        }

        /// <summary>
        /// Deletes a volume. All Volume data is irreversibly destroyed. The Volume must not be attached to a Server and it must not have delete protection enabled.
        /// </summary>
        /// <param name="volume"></param>
        /// <returns></returns>
        public async Task Delete(Volume volume)
        {
            // Send post
            await Delete(volume.Id);
        }

        //public class Action
        //{
        //    public async Task Attach(Volume volume, long serverId, bool autoMount = true)
        //    {
        //        // Raw
        //        string rawJson = $"{{\"server\":{serverId},\"automount\":{(autoMount ? "true" : "false")}}}";

        //        // Send post
        //        await ApiCore.SendPostRequest($"/volumes/{volume.Id}/actions/attach", rawJson);
        //    }

        //    public async Task Detach(Volume volume)
        //    {
        //        // Send post
        //        await ApiCore.SendPostRequest($"/volumes/{volume.Id}/actions/detach", "{}");
        //    }

        //    public async Task Resize(Volume volume, int size)
        //    {
        //        // Raw
        //        string rawJson = $"{{\"size\":{size}}}";

        //        // Send post
        //        await ApiCore.SendPostRequest($"/volumes/{volume.Id}/actions/resize", rawJson);
        //    }
        //}
    }
}
