using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13
{
    internal class Client
    {
        private readonly HttpClient _httpClient = new HttpClient();

        public async Task<T> GetRequest<T>(string url)
        {
            string responseString = null;
            using (var client = new HttpClient())
            {
                try
                {
                    responseString = await client.GetStringAsync(url);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            var data = JsonConvert.DeserializeObject<T>(responseString);
            return data;
        }

        public async Task<T> PostRequest<T>(string url, T type)
        {
            var jsonContent = JsonConvert.SerializeObject(type);
            using (var client = new HttpClient())
            {
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                HttpResponseMessage response;
                try
                {
                    response = await client.PostAsync(url, content);

                    if (!response.IsSuccessStatusCode)
                    {
                        var error = await response.Content.ReadAsStringAsync();
                        Console.WriteLine($"❌ ERROR {response.StatusCode}: {error}");
                        throw new Exception($"POST failed: {response.StatusCode} — {error}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"❌ Exception during POST: {ex.Message}");
                    throw;
                }

                var serializedData = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<T>(serializedData);
                return data;
            }
        }


        public async Task DeleteRequest(string url)
        {
            var response = await _httpClient.DeleteAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                var err = await response.Content.ReadAsStringAsync();
                throw new Exception($"HTTP {(int)response.StatusCode}: {err}");
            }
        }

        public async Task PutRequest(string url, object value)
        {
            var json = JsonConvert.SerializeObject(value);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync(url, content);

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"❌ ERROR {response.StatusCode}: {error}");
                throw new Exception($"Failed to PUT: {error}");
            }
        }
    }
}
