using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using System;

namespace HetznerCloudApi
{
    public class Core
    {
        public static long PerPage = 2;

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

            // IsNullOrEmpty
            string json = await httpResponseMessage.Content.ReadAsStringAsync();
            if (string.IsNullOrEmpty(json))
            {
                throw new Exception("there has been some error, the API has responded empty.");
            }

            // No OK
            if (httpResponseMessage.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception("{error.Message}");
            }

            return json;
        }
    }
}
