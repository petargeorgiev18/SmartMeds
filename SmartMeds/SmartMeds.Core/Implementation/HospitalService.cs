using Microsoft.EntityFrameworkCore;
using SmartMeds.Core.Interfaces;
using SmartMeds.Data;
using SmartMeds.Data.Entities;

namespace SmartMeds.Core.Implementation
{
    public class HospitalService : IHospitalService
    {
        private readonly SmartMedsDbContext _context;

        public HospitalService(SmartMedsDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Hospital>> GetAllHospitalsAsync()
        {
            return await _context.Hospitals
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Hospital?> GetHospitalByIdAsync(Guid id)
        {
            return await _context.Hospitals
                .AsNoTracking()
                .FirstOrDefaultAsync(h => h.Id == id);
        }

        public async Task<Hospital?> GetHospitalWithRequestsAsync(Guid id)
        {
            return await _context.Hospitals
                .Include(h => h.SentRequests)
                .Include(h => h.ReceivedRequests)
                .AsNoTracking()
                .FirstOrDefaultAsync(h => h.Id == id);
        }
    }
}
