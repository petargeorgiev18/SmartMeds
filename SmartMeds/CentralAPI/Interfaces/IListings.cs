using SmartMeds.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralAPI.Interfaces
{
    public interface IListings
    {
        public Task<bool> Create(long hospitalId, double price, DateTime expirationDate, int quantity, long medicineFK);
        public Task<List<Listing>> GetMyListings(long hospitalId);
        public Task<List<Listing>> GetOtherListings(long hospitalId);
        public Task<bool> Delete(long hospitalId, long listingId);
        public Task<Listing> GetById(long id);
    }
}
