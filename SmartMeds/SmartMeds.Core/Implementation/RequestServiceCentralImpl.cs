using SmartMeds.Core.Interfaces;
using SmartMeds.Data.Entities;
using SmartMeds.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMeds.Core.Implementation
{
    internal class RequestServiceCentralImpl : IRequestService
    {
        public Task<IEnumerable<Request>> GetAllRequestsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Request>> GetPendingRequestsForHospitalAsync(long hospitalId)
        {
            throw new NotImplementedException();
        }

        public Task<Request?> GetRequestByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Request>> GetRequestsByStatusAsync(RequestStatus status)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Request>> GetRequestsForHospitalAsync(long hospitalId)
        {
            throw new NotImplementedException();
        }
    }
}
