using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using System;
using HetznerCloudApi.Object.Universal;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace HetznerCloudApi
{
    public class Core
    {
        public static long PerPage = 5;

        private const string ApiServer = "https://api.hetzner.cloud/v1";

        public static async Task<string> SendGetRequest(string token, string url)
        {
            HttpResponseMessage httpResponseMessage;
            using (HttpClient httpClient = new HttpClient())
            {
                using (HttpRequestMessage httpRequestMessage = new HttpRequestMessage(new HttpMethod("GET"), $"{ApiServer}{url}"))
                {
                    httpRequestMessage.Headers.TryAddWithoutValidation("Authorization", $"Bearer {token}");
                    httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
                }
            }

            // Response
            string json = await httpResponseMessage.Content.ReadAsStringAsync();

            // No OK
            if (httpResponseMessage.StatusCode != HttpStatusCode.OK)
            {
                // Get Error
                JObject result = JObject.Parse(json);
                Error error = JsonConvert.DeserializeObject<Error>($"{result["error"]}") ?? new Error();

                //Check error
                if (error.Message.Contains("with ID") && error.Message.Contains("not found"))
                {
                    // The error is due to the resource not being found. Let's make it return empty instead of an error.
                    json = "{}";
                }
                else
                {
                    // If it's a genuine error
                    throw new Exception("{error.Message}");
                }
            }

            return json;
        }
    }
}
