using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;
using HetznerCloudApi.Object.Volume;

namespace HetznerCloudApi.Client
{
    public class VolumeClient
    {
        private readonly string _token;

        public VolumeClient(string token)
        {
            _token = token;
        }

        //public static async Task<List<Volume>> Get()
        //{
        //    List<Volume> list = new List<Volume>();
        //    long page = 0;
        //    while (true)
        //    {
        //        // Nex
        //        page++;

        //        // Get list
        //        Objects.Volume.Get.Response response = JsonConvert.DeserializeObject<Objects.Volume.Get.Response>(await ApiCore.SendGetRequest($"/volumes?page={page}&per_page=25")) ?? new Objects.Volume.Get.Response();

        //        // Run
        //        foreach (Volume row in response.Volumes)
        //        {
        //            list.Add(row);
        //        }

        //        // Finish?
        //        if (response.Meta.Pagination.NextPage == null)
        //        {
        //            // Yes, finish
        //            return list;
        //        }
        //    }
        //}

        //public static async Task<Volume> Get(long id)
        //{
        //    // Get list
        //    Objects.Volume.GetOne.Response response = JsonConvert.DeserializeObject<Objects.Volume.GetOne.Response>(await ApiCore.SendGetRequest($"/volumes/{id}")) ?? new Objects.Volume.GetOne.Response();

        //    // Return
        //    return response.Volume;
        //}

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

        //public static async Task<Volume> Update(Volume volume)
        //{
        //    // Preparing raw
        //    string raw = $"{{\"name\":\"{volume.Name}\"}}";

        //    // Send post
        //    string jsonResponse = await ApiCore.SendPutRequest($"/volumes/{volume.Id}", raw);

        //    // Return
        //    JObject result = JObject.Parse(jsonResponse);
        //    return JsonConvert.DeserializeObject<Volume>($"{result["volume"]}") ?? new Volume();
        //}

        //public static async Task Delete(Volume volume)
        //{
        //    // Send post
        //    await ApiCore.SendDeleteRequest($"/volumes/{volume.Id}");
        //}

        //public class Action
        //{
        //    public static async Task Attach(Volume volume, long serverId, bool autoMount = true)
        //    {
        //        // Raw
        //        string rawJson = $"{{\"server\":{serverId},\"automount\":{(autoMount ? "true" : "false")}}}";

        //        // Send post
        //        await ApiCore.SendPostRequest($"/volumes/{volume.Id}/actions/attach", rawJson);
        //    }

        //    public static async Task Detach(Volume volume)
        //    {
        //        // Send post
        //        await ApiCore.SendPostRequest($"/volumes/{volume.Id}/actions/detach", "{}");
        //    }

        //    public static async Task Resize(Volume volume, int size)
        //    {
        //        // Raw
        //        string rawJson = $"{{\"size\":{size}}}";

        //        // Send post
        //        await ApiCore.SendPostRequest($"/volumes/{volume.Id}/actions/resize", rawJson);
        //    }
        //}
    }
}
