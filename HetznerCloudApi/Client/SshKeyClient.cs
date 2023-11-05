using HetznerCloudApi.Object.Volume;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using HetznerCloudApi.Object.SshKey;
using HetznerCloudApi.Object.SshKey.Get;

namespace HetznerCloudApi.Client
{
    public class SshKeyClient
    {
        private readonly string _token;

        public SshKeyClient(string token)
        {
            _token = token;
        }

        /// <summary>
        /// Returns all SSH key objects.
        /// </summary>
        /// <returns></returns>
        public async Task<List<SshKey>> Get()
        {
            List<SshKey> list = new List<SshKey>();
            long page = 0;
            while (true)
            {
                // Nex
                page++;

                // Get list
                Response response = JsonConvert.DeserializeObject<Response>(await Core.SendGetRequest(_token, $"/ssh_keys?page={page}&per_page={Core.PerPage}")) ?? new Response();

                // Run
                foreach (SshKey row in response.SshKeys)
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
        /// Returns a specific SSH key object.
        /// </summary>
        /// <param name="id">ID of the SSH key</param>
        /// <returns></returns>
        public async Task<SshKey> Get(long id)
        {
            // Get list
            string json = await Core.SendGetRequest(_token, $"/ssh_keys/{id}");

            // Set
            JObject result = JObject.Parse(json);
            SshKey sshKey = JsonConvert.DeserializeObject<SshKey>($"{result["ssh_key"]}") ?? new SshKey();

            // Return
            return sshKey;
        }

        /// <summary>
        /// Creates a new SSH key with the given name and public_key. Once an SSH key is created, it can be used in other calls such as creating Servers.
        /// </summary>
        /// <param name="name">Name of the SSH key</param>
        /// <param name="publicKey">Public key</param>
        /// <returns></returns>
        public async Task<SshKey> Create(string name, string publicKey)
        {
            // Preparing raw
            string raw = $"{{ \"name\": \"{name}\", \"public_key\": \"{publicKey}\" }}";

            // Send post
            string jsonResponse = await Core.SendPostRequest(_token, "/ssh_keys", raw);

            // Return
            JObject result = JObject.Parse(jsonResponse);
            return JsonConvert.DeserializeObject<SshKey>($"{result["ssh_key"]}") ?? new SshKey();
        }

        /// <summary>
        /// Updates an SSH key. You can update an SSH key name and an SSH key labels.
        /// </summary>
        /// <param name="sshKey">the SSH</param>
        /// <returns></returns>
        public async Task<SshKey> Update(SshKey sshKey)
        {
            // Preparing raw
            string raw = $"{{ \"name\": \"{sshKey.Name}\" }}";

            // Send post
            string jsonResponse = await Core.SendPutRequest(_token, $"/ssh_keys/{sshKey.Id}", raw);

            // Return
            JObject result = JObject.Parse(jsonResponse);
            return JsonConvert.DeserializeObject<SshKey>($"{result["ssh_key"]}") ?? new SshKey();
        }

        /// <summary>
        /// Deletes an SSH key. It cannot be used anymore.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task Delete(long id)
        {
           await Core.SendDeleteRequest(_token, $"/ssh_keys/{id}");
        }

        /// <summary>
        /// Deletes an SSH key. It cannot be used anymore.
        /// </summary>
        /// <param name="sshKey"></param>
        /// <returns></returns>
        public async Task Delete(SshKey sshKey)
        {
            await Delete(sshKey.Id);
        }
    }
}
