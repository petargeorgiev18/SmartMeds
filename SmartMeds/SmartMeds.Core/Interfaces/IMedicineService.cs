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
