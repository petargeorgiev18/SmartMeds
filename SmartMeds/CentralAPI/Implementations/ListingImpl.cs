using CentralAPI.Interfaces;
using Newtonsoft.Json;
using SmartMeds.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CentralAPI.Implementations
{
    public class ListingImpl : IListings
    {
        const string BASE_URL = "localhost:8080/listings";
        private readonly HttpClient _httpClient;

        public ListingImpl(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        public async Task<bool> Create(long hospitalId, double price, DateTime expirationDate, int quantity, long medicineFK)
        {
            var body = new
            {
                price = price,
                expirationDate = expirationDate,
                quantity = quantity,
                medicineFK = medicineFK
            };
            var json = JsonConvert.SerializeObject(body);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(BASE_URL + "/create", content);
            response.EnsureSuccessStatusCode();
            return true;
        }

        public Task<bool> Delete(long hospitalId, long listingId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Listing>> GetMyListings(long hospitalId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Listing>> GetOtherListings(long hospitalId)
        {
            var response = await _httpClient.GetAsync(BASE_URL + "/get-not-by-hospital/" + hospitalId);
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();

            return new List<Listing>();
        }
    }
}
