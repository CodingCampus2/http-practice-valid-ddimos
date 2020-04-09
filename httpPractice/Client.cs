using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace httpPractice
{
    class Client
    {
        private HttpClient m_httpClient;
        public Client()
        {
            m_httpClient = new HttpClient();
        }
        public void Init(string baseAddress)
        {
            m_httpClient.BaseAddress = new Uri(baseAddress);
            m_httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public void AddHeader(string key, string value)
        {
            m_httpClient.DefaultRequestHeaders.Add(key, value);
        }
        public async Task GetAll(bool isSorted)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "");
            request.Properties["sorted"] = isSorted ? "True" : "False";
            HttpResponseMessage response = await m_httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var resp = await response.Content.ReadAsStringAsync();
                List<Data> dataList = JsonConvert.DeserializeObject<List<Data>>(resp);
                dataList.ForEach(Console.WriteLine);
            }
            else
            {
                Console.WriteLine(response.StatusCode);
            };
        }
        public async Task GetOne(string id)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, id);
            HttpResponseMessage response = await m_httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var resp = await response.Content.ReadAsStringAsync();
                Data data = JsonConvert.DeserializeObject<Data>(resp);
                Console.WriteLine(data);
            }
            else
            {
                Console.WriteLine(response.StatusCode);
            }
        }

        public async Task Post(Data data)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "");
            request.Content = new StringContent(JsonConvert.SerializeObject(data), System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = await m_httpClient.SendAsync(request);

            Console.WriteLine(response.StatusCode);
        }

        public async Task Put(Data data, string id)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, $"{id}");
            request.Content = new StringContent(JsonConvert.SerializeObject(data), System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = await m_httpClient.SendAsync(request);

            Console.WriteLine(response.StatusCode);
        }
        public async Task Delete(string id)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Delete, $"{id}");
            HttpResponseMessage response = await m_httpClient.SendAsync(request);

            Console.WriteLine(response.StatusCode);
        }
    }
}
