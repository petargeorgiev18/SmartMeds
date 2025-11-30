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

        public List<Request> GetAllPendingAsync(long hospitalId)
        {
            throw new NotImplementedException();
        }

        public Request GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public List<Request> GetByStatusAsync(long hospitalId, string status)
        {
            throw new NotImplementedException();
        }

        public List<Request> GetRequestsForHospitalAsync(long hospitalId, long targetHospitalId)
        {
            throw new NotImplementedException();
        }

        List<Request> IRequsetsCentral.GetAllAsync(long hospitalId)
        {
            throw new NotImplementedException();
        }
    }
}
