using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using HetznerCloudApi.Object.Action;
using HetznerCloudApi.Object.Action.Get;

namespace HetznerCloudApi.Client
{
    public class ActionClient
    {
        private readonly string _token;

        public ActionClient(string token)
        {
            _token = token;
        }

        /// <summary>
        /// Get all Actions
        /// </summary>
        /// <returns></returns>
        public async Task<List<Action>> Get()
        {
            List<Action> list = new List<Action>();
            long page = 0;
            while (true)
            {
                // Nex
                page++;

                // Get list
                Response response = JsonConvert.DeserializeObject<Response>(await Core.SendGetRequest(_token, $"/actions?page={page}&per_page={Core.PerPage}")) ?? new Response();

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
        /// Returns a specific Action object.
        /// </summary>
        /// <param name="actionId">ID of the Resource</param>
        /// <returns></returns>
        public async Task<Action> Get(long actionId)
        {
            // Get list
            string json = await Core.SendGetRequest(_token, $"/actions/{actionId}");

            // Set
            JObject result = JObject.Parse(json);
            Action action = JsonConvert.DeserializeObject<Action>($"{result["action"]}") ?? new Action();

            // Return
            return action;
        }
    }
}
