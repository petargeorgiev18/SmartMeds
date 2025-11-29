using SmartMeds.Data.Entities;

namespace SmartMeds.Core.Interfaces
{
    public interface IListingService
    {
        Task<IEnumerable<Listing>> GetAllListingsAsync();
        Task<List<Listing>> FetchMyListingsAsync();
        Task<Listing?> GetListingByIdAsync(long id);
        Task<IEnumerable<Listing>> GetListingsByMedicineIdAsync(long medicineId);
        Task CreateListingAsync(Listing listing);
    }
}
