using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Tennisclub.WPF
{
    public static class HelperAPI
    {
        private static readonly string BaseUrl = ConfigurationManager.AppSettings["TennisclubApiUrl"];

        public static readonly HttpClient Client = new HttpClient();

        public static async Task<T> Get<T>(string path) where T : class
        {
            var url = $"{BaseUrl}{path}";
            var response = await Client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return null;

            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(json);
        }
        public static async Task<string> Post<TCreateDto>(string path, TCreateDto item)
            where TCreateDto : class
        {
            var url = $"{BaseUrl}{path}";
            var response = await Client.PostAsync(url,
                new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json"));

            var json = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                return json.ToString();

            return null;
        }

        public static async Task<string> Update<TUpdateDto>(string url, TUpdateDto item)
            where TUpdateDto : class
        {
                string apiUrl = BaseUrl + url;
                var response = await Client.PutAsJsonAsync(apiUrl, item);

            var json = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                return json.ToString();

            return null;
        }
        public static async Task SoftDelete(string path)
        {
            var url = $"{BaseUrl}{path}";
            await Client.DeleteAsync(url);
        }

        public static async Task Delete(string path)
        {
            var url = $"{BaseUrl}{path}";
            await Client.DeleteAsync(url);
        }
        public static async Task Save(string path)
        {
            var url = $"{BaseUrl}{path}/save";
            await Client.PostAsync(url, null);
        }
    }
}
