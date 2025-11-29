using SmartMeds.Data.Entities;
using SmartMeds.Data.Enums;

namespace SmartMeds.Core.Interfaces
{
    public interface IRequestService
    {
        Task<IEnumerable<Request>> GetAllRequestsAsync();
        Task<Request?> GetRequestByIdAsync(long id);
        Task<IEnumerable<Request>> GetRequestsByStatusAsync(RequestStatus status);
        Task<IEnumerable<Request>> GetRequestsForHospitalAsync(long hospitalId);
        Task<IEnumerable<Request>> GetPendingRequestsForHospitalAsync(long hospitalId);
    }
}
