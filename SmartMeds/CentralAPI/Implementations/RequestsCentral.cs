using CentralAPI.DTOs;
using CentralAPI.Interfaces;
using Newtonsoft.Json;
using SmartMeds.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralAPI.Implementations
{
    internal class RequestsCentral : IRequsetsCentral
    {
        const string BASE_URL = "http://localhost:8080/requests";
        private readonly HttpClient _httpClient;

        public RequestsCentral(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        public async Task<List<Request>> GetAllAsync(long hospitalId)
        {
            var res = await _httpClient.GetAsync(BASE_URL + "/get-about-hospital/" + hospitalId);
            res.EnsureSuccessStatusCode();

            var json = await res.Content.ReadAsStringAsync();

            List<RequestDTO> requestDTOs = JsonConvert.DeserializeObject<List<RequestDTO>>(json);
            
            return requestDTOs
                .Select(x => x.toRequest())
                .ToList();
        }

        public async Task<List<Request>> GetAllPendingAsync(long hospitalId)
        {

            var res = await _httpClient.GetAsync(BASE_URL + "/get-about-hospital/" + hospitalId);
            res.EnsureSuccessStatusCode();

            var json = await res.Content.ReadAsStringAsync();

            List<RequestDTO> requestDTOs = JsonConvert.DeserializeObject<List<RequestDTO>>(json);

            return requestDTOs
                .Select(x => x.toRequest())
                .Where(x => x.Status == SmartMeds.Data.Enums.RequestStatus.Pending)
                .ToList();
        }

        public async Task<Request> GetByIdAsync(long id)
        {
            var res = await _httpClient.GetAsync(BASE_URL + "/get/" + id);
            res.EnsureSuccessStatusCode();

            var json = await res.Content.ReadAsStringAsync();

            RequestDTO requestDTOs = JsonConvert.DeserializeObject<RequestDTO>(json);

            return requestDTOs.toRequest();
        }

        async Task<List<Request>> IRequsetsCentral.GetByStatusAsync(long hospitalId, string status)
        {

            var res = await _httpClient.GetAsync(BASE_URL + $"/get-about-hospital-by-status/{hospitalId}?status={status}");
            res.EnsureSuccessStatusCode();

            var json = await res.Content.ReadAsStringAsync();

            List<RequestDTO> requestDTOs = JsonConvert.DeserializeObject<List<RequestDTO>>(json);

            return requestDTOs
                .Select(x => x.toRequest())
                .ToList();
        }

        async Task<List<Request>> IRequsetsCentral.GetRequestsForHospitalAsync(long hospitalId, long targetHospitalId)
        {
            var res = await _httpClient.GetAsync(BASE_URL + "/get-from-hospital/" + hospitalId);
            res.EnsureSuccessStatusCode();

            var json = await res.Content.ReadAsStringAsync();

            List<RequestDTO> requestDTOs = JsonConvert.DeserializeObject<List<RequestDTO>>(json);

            return requestDTOs
                .Select(x => x.toRequest())
                .Where(x => x.ToHospitalId == targetHospitalId)
                .ToList();
        }
    }
}
