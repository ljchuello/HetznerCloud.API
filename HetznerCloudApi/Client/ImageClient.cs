using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using HetznerCloudApi.Object.Image;
using HetznerCloudApi.Object.Image.Response;
using Newtonsoft.Json.Linq;

namespace HetznerCloudApi.Client
{
    public class ImageClient
    {
        private readonly string _token;

        public ImageClient(string token)
        {
            _token = token;
        }

        /// <summary>
        /// Returns all Image objects.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Image>> Get()
        {
            List<Image> listImage = new List<Image>();
            long page = 0;
            while (true)
            {
                // Nex
                page++;

                // Get list
                Response response = JsonConvert.DeserializeObject<Response>(await Core.SendGetRequest(_token, $"/images?page={page}&per_page=25")) ?? new Response();

                // Run
                foreach (Image row in response.Images)
                {
                    listImage.Add(row);
                }

                // Finish?
                if (response.Meta.Pagination.NextPage == null)
                {
                    // Yes, finish
                    return listImage;
                }
            }
        }

        /// <summary>
        /// Returns a specific Image object
        /// </summary>
        /// <param name="id">ID of the Image</param>
        /// <returns></returns>
        public async Task<Image> Get(long id)
        {
            // Get list
            string json = await Core.SendGetRequest(_token, $"/images/{id}");

            // Set
            JObject result = JObject.Parse(json);
            Image image = JsonConvert.DeserializeObject<Image>($"{result["image"]}") ?? new Image();

            // Return
            return image;
        }
    }
}
