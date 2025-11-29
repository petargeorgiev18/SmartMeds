using SmartMeds.Data.Entities;

namespace SmartMeds.Core.Interfaces
{
    public interface IListingService
    {
        Task<IEnumerable<Listing>> GetAllListingsAsync();
        Task<Listing?> GetListingByIdAsync(Guid id);
        Task<IEnumerable<Listing>> GetListingsByMedicineIdAsync(Guid medicineId);
    }
}
