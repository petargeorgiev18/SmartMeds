using BarcodeAPI.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BarcodeAPI.Implementation
{
    public class BarcodeEncoder : IBarcodeEncoder
    {
        private readonly HttpClient _httpClient;

        public BarcodeEncoder(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        public async Task<BarcodeResponseFormat> GetTitleByBarcode(string imageUrl)
        {
            var requestBody = new
            {
                imageUrl
            };

            var json = JsonConvert.SerializeObject(requestBody);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("http://localhost:3600/decode", content);

            try
            {
                response.EnsureSuccessStatusCode();
                var data = await response.Content.ReadAsStringAsync();
                var deserialized = JsonConvert.DeserializeObject<BarcodeResponseFormat>(data);
                return deserialized;

            }
            catch (HttpRequestException e)
            {
                throw new Exception("Error calling barcode decoding service", e);
            }
        }

        public async Task<bool> CheckHealth()
        {
            var response = await _httpClient.GetAsync("http://localhost:3600/health");

            return response.IsSuccessStatusCode;
        }
    }
}
