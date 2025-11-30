using SmartMeds.Data.Entities;

namespace SmartMeds.Core.Interfaces
{
    public interface IMedicineService
    {
        Task<IEnumerable<Medicine>> GetAllMedicinesAsync();
        Task<Medicine?> GetMedicineByIdAsync(long id);
        Task<IEnumerable<Medicine>> GetMedicinesCloseToExpirationAsync(int daysThreshold = 30);
        Task<Medicine> AddMedicineAsync(Medicine medicine);
    }
}
