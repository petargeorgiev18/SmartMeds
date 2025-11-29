using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartMeds.Data.Entities;

namespace SmartMeds.Core.Interfaces
{
    public interface IMedicineService
    {
        Task<IEnumerable<Medicine>> GetAllMedicinesAsync();
        Task<Medicine?> GetMedicineByIdAsync(Guid id);
        Task<IEnumerable<Medicine>> GetMedicinesCloseToExpirationAsync(int daysThreshold = 30);
    }
}
