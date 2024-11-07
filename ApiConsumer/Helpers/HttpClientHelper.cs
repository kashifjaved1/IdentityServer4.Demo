using Newtonsoft.Json;
using System.Text;

namespace ApiConsumer
{
    public static class HttpClientHelper
    {
        public static async Task<T> GetAsync<T>(HttpClient client, string uri)
        {
            using var response = await client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                var serializedResponse = await response.Content.ReadAsStringAsync();
                var tObject = JsonConvert.DeserializeObject<T>(serializedResponse);
                return tObject;
            }

            return default;
        }

        public static HttpContent GetContent<T>(T tValue)
        {
            return new StringContent(JsonConvert.SerializeObject(tValue), Encoding.UTF8, "application/json");
        }
    }
}
