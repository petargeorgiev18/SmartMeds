using Microsoft.EntityFrameworkCore;
using SmartMeds.Core.Interfaces;
using SmartMeds.Data;
using SmartMeds.Data.Entities;
using SmartMeds.Data.Enums;

namespace SmartMeds.Core.Implementation
{
    public class RequestService : IRequestService
    {
        private readonly SmartMedsDbContext _context;

        public RequestService(SmartMedsDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Request>> GetAllRequestsAsync()
        {
            return await _context.Requests
                .Include(r => r.FromHospital)
                .Include(r => r.ToHospital)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Request?> GetRequestByIdAsync(long id)
        {
            return await _context.Requests
                .Include(r => r.FromHospital)
                .Include(r => r.ToHospital)
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<IEnumerable<Request>> GetRequestsByStatusAsync(RequestStatus status)
        {
            return await _context.Requests
                .Include(r => r.FromHospital)
                .Include(r => r.ToHospital)
                .Where(r => r.Status == status)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Request>> GetRequestsForHospitalAsync(long hospitalId)
        {
            return await _context.Requests
                .Include(r => r.FromHospital)
                .Include(r => r.ToHospital)
                .Where(r => r.FromHospitalId == hospitalId || r.ToHospitalId == hospitalId)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Request>> GetPendingRequestsForHospitalAsync(long hospitalId)
        {
            return await _context.Requests
                .Include(r => r.FromHospital)
                .Include(r => r.ToHospital)
                .Where(r => (r.FromHospitalId == hospitalId || r.ToHospitalId == hospitalId)
                            && r.Status == RequestStatus.Pending)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
