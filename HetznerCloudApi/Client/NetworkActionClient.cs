using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using HetznerCloudApi.Object.Action;
using HetznerCloudApi.Object.Action.Get;
using HetznerCloudApi.Object.Network;

namespace HetznerCloudApi.Client
{
    public class NetworkActionClient
    {
        private readonly string _token;

        public NetworkActionClient(string token)
        {
            _token = token;
        }

        /// <summary>
        /// Adds a new subnet object to the Network. If you do not specify an ip_range for the subnet we will automatically pick the first available /24 range for you if possible.
        /// </summary>
        /// <param name="networkId">ID of the Network</param>
        /// <param name="ipRange">Range to allocate IPs from. Must be a Subnet of the ip_range of the parent network object and must not overlap with any other subnets or with any destinations in routes. If the Subnet is of type vSwitch, it also can not overlap with any gateway in routes. Minimum Network size is /30. We suggest that you pick a bigger Network with a /24 netmask.</param>
        /// <param name="networkZone">Name of Network zone. The Location object contains the network_zone property each Location belongs to.</param>
        /// <returns></returns>
        public async Task<Action> AddSubnetToNetwork(long networkId, string ipRange, string networkZone)
        {
            // Preparing raw
            string raw = $"{{ \"ip_range\": \"{ipRange}\", \"network_zone\": \"{networkZone}\", \"type\": \"cloud\" }}";

            // Send
            string jsonResponse = await Core.SendPostRequest(_token, $"/networks/{networkId}/actions/add_subnet", raw);

            // Return
            JObject result = JObject.Parse(jsonResponse);
            return JsonConvert.DeserializeObject<Action>($"{result["action"]}") ?? new Action();
        }

        /// <summary>
        /// Deletes a single subnet entry from a Network. You cannot delete subnets which still have Servers attached. If you have Servers attached you first need to detach all Servers that use IPs from this subnet before you can delete the subnet.
        /// </summary>
        /// <param name="networkId">ID of the Network</param>
        /// <param name="ipRange">IP range of subnet to delete</param>
        /// <returns></returns>
        public async Task<Action> DeleteSubnetFromNetwork(long networkId, string ipRange)
        {
            // Preparing raw
            string raw = $"{{ \"ip_range\": \"{ipRange}\" }}";

            // Send
            string jsonResponse = await Core.SendPostRequest(_token, $"/networks/{networkId}/actions/delete_subnet", raw);

            // Return
            JObject result = JObject.Parse(jsonResponse);
            return JsonConvert.DeserializeObject<Action>($"{result["action"]}") ?? new Action();
        }

        /// <summary>
        /// Changes the protection configuration of a Network.
        /// </summary>
        /// <param name="networkId">ID of the Network</param>
        /// <param name="protection">If true, prevents the Network from being deleted</param>
        /// <returns></returns>
        public async Task<Action> ChangeProtection(long networkId, bool protection)
        {
            // Preparing raw
            string raw = $"{{ \"delete\": {(protection ? "true" : "false")} }}";

            // Send post
            string jsonResponse = await Core.SendPostRequest(_token, $"/networks/{networkId}/actions/change_protection", raw);

            // Return
            JObject result = JObject.Parse(jsonResponse);
            return JsonConvert.DeserializeObject<Action>($"{result["action"]}") ?? new Action();
        }

        /// <summary>
        /// Get all Actions for a Network
        /// </summary>
        /// <param name="networkId"></param>
        /// <returns></returns>
        public async Task<List<Action>> GetAllActions(long networkId)
        {
            List<Action> list = new List<Action>();
            long page = 0;
            while (true)
            {
                // Nex
                page++;

                // Get list
                Response response = JsonConvert.DeserializeObject<Response>(await Core.SendGetRequest(_token, $"/networks/{networkId}/actions?page={page}&per_page={Core.PerPage}")) ?? new Response();

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
        /// Get an Action for a Network
        /// </summary>
        /// <param name="networkId"></param>
        /// <param name="actionId"></param>
        /// <returns></returns>
        public async Task<Action> GetAction(long networkId, long actionId)
        {
            // Get list
            string json = await Core.SendGetRequest(_token, $"/networks/{networkId}/actions/{actionId}");

            // Set
            JObject result = JObject.Parse(json);
            Action action = JsonConvert.DeserializeObject<Action>($"{result["action"]}") ?? new Action();

            // Return
            return action;
        }

        /// <summary>
        /// Get all Actions
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
                Response response = JsonConvert.DeserializeObject<Response>(await Core.SendGetRequest(_token, $"/networks/actions?page={page}&per_page={Core.PerPage}")) ?? new Response();

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
        /// Get an Action
        /// </summary>
        /// <param name="actionId"></param>
        /// <returns></returns>
        public async Task<Action> GetAction(long actionId)
        {
            // Get list
            string json = await Core.SendGetRequest(_token, $"/networks/actions/{actionId}");

            // Set
            JObject result = JObject.Parse(json);
            Action action = JsonConvert.DeserializeObject<Action>($"{result["action"]}") ?? new Action();

            // Return
            return action;
        }
    }
}
