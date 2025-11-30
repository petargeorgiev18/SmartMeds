using SmartMeds.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralAPI.Interfaces
{
    internal interface IRequsetsCentral
    {
        Task<List<Request>> GetAllAsync(long hospitalId);
        Task<List<Request>> GetAllPendingAsync(long hospitalId);
        Task<Request> GetByIdAsync(long id);
        Task<List<Request>> GetByStatusAsync(long hospitalId, string status);
        Task<List<Request>> GetRequestsForHospitalAsync(long hospitalId, long targetHospitalId);
    }
}
