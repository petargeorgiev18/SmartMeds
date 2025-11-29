using SmartMeds.Data.Entities;

namespace SmartMeds.Core.Interfaces
{
    public interface IHospitalService
    {
        Task<IEnumerable<Hospital>> GetAllHospitalsAsync();
        Task<Hospital?> GetHospitalByIdAsync(Guid id);
        Task<Hospital?> GetHospitalWithRequestsAsync(Guid id);
    }
}
