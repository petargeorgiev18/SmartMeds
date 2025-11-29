using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartMeds.Core.Interfaces;
using SmartMeds.Data.Entities;
using SmartMeds.Data;
using Microsoft.EntityFrameworkCore;

namespace SmartMeds.Core.Implementation
{
    public class MedicineService : IMedicineService
    {
        private readonly SmartMedsDbContext _context;

        public MedicineService(SmartMedsDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Medicine>> GetAllMedicinesAsync()
        {
            return await _context.Medicines
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Medicine?> GetMedicineByIdAsync(Guid id)
        {
            return await _context.Medicines
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<Medicine>> GetMedicinesCloseToExpirationAsync(int daysThreshold = 30)
        {
            var today = DateTime.Today;

            return await _context.Medicines
                .AsNoTracking()
                .Where(m => (m.ExpirationDate - today).TotalDays <= daysThreshold && m.ExpirationDate >= today)
                .ToListAsync();
        }
    }
}
