using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using HetznerCloudApi.Object.Action;
using Newtonsoft.Json.Linq;
using HetznerCloudApi.Object.Action.Get;

namespace HetznerCloudApi.Client
{
    public class VolumeActionClient
    {
        private readonly string _token;

        public VolumeActionClient(string token)
        {
            _token = token;
        }

        /// <summary>
        /// Get all Actions for a Volume
        /// </summary>
        /// <param name="volumeId">ID of the Volume</param>
        /// <returns></returns>
        public async Task<List<Action>> GetAllActions(long volumeId)
        {
            List<Action> list = new List<Action>();
            long page = 0;
            while (true)
            {
                // Nex
                page++;

                // Get list
                Response response = JsonConvert.DeserializeObject<Response>(await Core.SendGetRequest(_token, $"/volumes/{volumeId}/actions?page={page}&per_page={Core.PerPage}")) ?? new Response();

                // Run
                foreach (Action row in response.Actions)
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
        /// Get an Action for a Volume
        /// </summary>
        /// <param name="volumeId">ID of the Volume</param>
        /// <param name="actionId">ID of the Action</param>
        /// <returns></returns>
        public async Task<Action> GetAction(long volumeId, long actionId)
        {
            // Get list
            string json = await Core.SendGetRequest(_token, $"/volumes/{volumeId}/actions/{actionId}");

            // Set
            JObject result = JObject.Parse(json);
            Action action = JsonConvert.DeserializeObject<Action>($"{result["action"]}") ?? new Action();

            // Return
            return action;
        }

        /// <summary>
        /// Attaches a Volume to a Server. Works only if the Server is in the same Location as the Volume.
        /// </summary>
        /// <param name="volumeId">ID of the Volume</param>
        /// <param name="serverId">ID of the Server the Volume will be attached to</param>
        /// <param name="automount">Auto-mount the Volume after attaching it</param>
        /// <returns></returns>
        public async Task<Action> Attach(long volumeId, long serverId, bool automount = true)
        {
            // Preparing raw
            string raw = $"{{ \"automount\": {(automount ? "true" : "false")}, \"server\": {serverId} }}";

            // Send post
            string jsonResponse = await Core.SendPostRequest(_token, $"/volumes/{volumeId}/actions/attach", raw);

            // Return
            JObject result = JObject.Parse(jsonResponse);
            return JsonConvert.DeserializeObject<Action>($"{result["action"]}") ?? new Action();
        }

        /// <summary>
        /// Detaches a Volume from the Server it’s attached to. You may attach it to a Server again at a later time.
        /// </summary>
        /// <param name="volumeId"></param>
        /// <returns></returns>
        public async Task<Action> Detach(long volumeId)
        {
            // Send post
            string jsonResponse = await Core.SendPostRequest(_token, $"/volumes/{volumeId}/actions/detach");

            // Return
            JObject result = JObject.Parse(jsonResponse);
            return JsonConvert.DeserializeObject<Action>($"{result["action"]}") ?? new Action();
        }

        /// <summary>
        /// Changes the protection configuration of a Volume.
        /// </summary>
        /// <param name="volumeId">ID of the Volume</param>
        /// <param name="protection">If true, prevents the Volume from being deleted</param>
        /// <returns></returns>
        public async Task<Action> ChangeProtection(long volumeId, bool protection)
        {
            // Preparing raw
            string raw = $"{{ \"delete\": {(protection ? "true" : "false")} }}";

            // Send post
            string jsonResponse = await Core.SendPostRequest(_token, $"/volumes/{volumeId}/actions/change_protection", raw);

            // Return
            JObject result = JObject.Parse(jsonResponse);
            return JsonConvert.DeserializeObject<Action>($"{result["action"]}") ?? new Action();
        }

        /// <summary>
        /// Changes the size of a Volume. Note that downsizing a Volume is not possible.
        /// </summary>
        /// <param name="volumeId"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public async Task<Action> Resize(long volumeId, long size)
        {
            // Preparing raw
            string raw = $"{{ \"size\": {size} }}";

            // Send post
            string jsonResponse = await Core.SendPostRequest(_token, $"/volumes/{volumeId}/actions/resize", raw);

            // Return
            JObject result = JObject.Parse(jsonResponse);
            return JsonConvert.DeserializeObject<Action>($"{result["action"]}") ?? new Action();
        }

        /// <summary>
        /// Returns all Action objects
        /// </summary>
        /// <returns></returns>
        public async Task<List<Action>> GetAllActions()
        {
            List<Action> list = new List<Action>();
            long page = 0;
            while (true)
            {
                // Nex
                page++;

                // Get list
                Response response = JsonConvert.DeserializeObject<Response>(await Core.SendGetRequest(_token, $"/volumes/actions?page={page}&per_page={Core.PerPage}")) ?? new Response();

                // Run
                foreach (Action row in response.Actions)
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
        /// Returns a specific Action object
        /// </summary>
        /// <param name="actionId">ID of the Resource</param>
        /// <returns></returns>
        public async Task<Action> GetAction(long actionId)
        {
            // Get list
            string json = await Core.SendGetRequest(_token, $"/volumes/actions/{actionId}");

            // Set
            JObject result = JObject.Parse(json);
            Action action = JsonConvert.DeserializeObject<Action>($"{result["action"]}") ?? new Action();

            // Return
            return action;
        }
    }
}
