using Microsoft.EntityFrameworkCore;
using SmartMeds.Core.Interfaces;
using SmartMeds.Data;
using SmartMeds.Data.Entities;
using CentralAPI;
using CentralAPI.Interfaces;

namespace SmartMeds.Core.Implementation
{
    public class ListingService : IListingService
    {
        private readonly SmartMedsDbContext _context;
        private readonly IListings _listingsAPI;

        public ListingService(SmartMedsDbContext context, IListings listings)
        {
            _context = context;
            _listingsAPI = listings;
        }

        public async Task<List<Listing>> FetchMyListingsAsync()
        {
            return await _listingsAPI.GetMyListings(1); //TODO: Change with actual hospital id
        }

        public async Task<IEnumerable<Listing>> GetAllListingsAsync()
        {
            return await _context.Listings
                .Include(l => l.Medicine)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Listing?> GetListingByIdAsync(Guid id)
        {
            return await _context.Listings
                .Include(l => l.Medicine)
                .AsNoTracking()
                .FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<IEnumerable<Listing>> GetListingsByMedicineIdAsync(Guid medicineId)
        {
            return await _context.Listings
                .Include(l => l.Medicine)
                .Where(l => l.MedicineId == medicineId)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}