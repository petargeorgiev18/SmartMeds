using BarcodeAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BarcodeAPI.Implementation
{
    internal class BarcodeEncoder : IBarcodeEncoder
    {
        private readonly HttpClient _httpClient;

        public BarcodeEncoder(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetTitleByBarcode(string imageUrl)
        {
            var requestBody = new
            {
                imageUrl
            };

            var json = JsonSerializer.Serialize(requestBody);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("https://localhost:3600/decode", content);

            try
            {
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException e)
            {
                throw new Exception("Error calling barcode decoding service", e);
            }

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<bool> CheckHealth()
        {
            var response = await _httpClient.GetAsync("https://localhost:3600/health");

            return response.IsSuccessStatusCode;
        }
    }
}
