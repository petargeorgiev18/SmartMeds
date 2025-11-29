using SmartMeds.Data.Entities;
using SmartMeds.Data.Enums;

namespace SmartMeds.Core.Interfaces
{
    public interface IRequestService
    {
        Task<IEnumerable<Request>> GetAllRequestsAsync();
        Task<Request?> GetRequestByIdAsync(Guid id);
        Task<IEnumerable<Request>> GetRequestsByStatusAsync(RequestStatus status);
        Task<IEnumerable<Request>> GetRequestsForHospitalAsync(Guid hospitalId);
        Task<IEnumerable<Request>> GetPendingRequestsForHospitalAsync(Guid hospitalId);
    }
}
