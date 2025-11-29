using Microsoft.EntityFrameworkCore;
using SmartMeds.Core.Interfaces;
using SmartMeds.Data;
using SmartMeds.Data.Entities;

namespace SmartMeds.Core.Implementation
{
    public class ListingService : IListingService
    {
        private readonly SmartMedsDbContext _context;

        public ListingService(SmartMedsDbContext context)
        {
            _context = context;
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

        public async Task CreateListingAsync(Listing listing)
        {
            _context.Listings.Add(listing);
            await _context.SaveChangesAsync();
        }
    }
}