using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using HetznerCloudApi.Object.Universal;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Linq;

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
                    throw new Exception($"{error.Code} - {error.Message}");
                }
            }

            return json;
        }

        public static async Task<string> SendPostRequest(string token, string url, string content)
        {
            HttpResponseMessage httpResponseMessage;
            using (HttpClient httpClient = new HttpClient())
            {
                using (HttpRequestMessage httpRequestMessage = new HttpRequestMessage(new HttpMethod("POST"), $"{ApiServer}{url}"))
                {
                    httpRequestMessage.Headers.TryAddWithoutValidation("Authorization", $"Bearer {token}");
                    httpRequestMessage.Content = new StringContent(content);
                    httpRequestMessage.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                    httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
                }
            }

            // Response
            string json = await httpResponseMessage.Content.ReadAsStringAsync();

            switch (httpResponseMessage.StatusCode)
            {
                case HttpStatusCode.Created:
                    break;

                default:
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
                        throw new Exception($"{error.Code} - {error.Message}");
                    }
                    break;
            }

            return json;
        }

        //static string RemoveNullProperties(string json)
        //{
        //    // Check
        //    if (string.IsNullOrWhiteSpace(json) || json == "{}")
        //    {
        //        return json;
        //    }

        //    // Set
        //    JObject jObject = JObject.Parse(json);

        //    // List
        //    List<JToken> propertiesToRemove = jObject.Descendants().Where(j => j.Type == JTokenType.Property && j.First == null).ToList();

        //    // foreach
        //    foreach (JToken row in propertiesToRemove)
        //    {
        //        row.Remove();
        //    }

        //    // Retur
        //    json = jObject.ToString();
        //    return json;
        //}
    }
}
