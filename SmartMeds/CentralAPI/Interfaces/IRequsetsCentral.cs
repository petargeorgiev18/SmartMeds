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
        List<Request> GetAllAsync(long hospitalId);
        List<Request> GetAllPendingAsync(long hospitalId);
        Request GetByIdAsync(long id);
        List<Request> GetByStatusAsync(long hospitalId, string status);
        List<Request> GetRequestsForHospitalAsync(long hospitalId, long targetHospitalId);
    }
}
