using Microsoft.AspNetCore.Mvc;
using SmartMeds.Core.Interfaces;
using SmartMeds.Web.Models;

namespace SmartMeds.Web.Controllers
{
    public class ListingController : Controller
    {
        private readonly IListingService _listingService;

        public ListingController(IListingService listingService)
        {
            _listingService = listingService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //var listings = await _listingService.GetAllListingsAsync();
            var listings = await _listingService.FetchMyListingsAsync();

            var model = listings.Select(l => new ListingViewModel
            {
                Id = l.Id,
                MedicineId = l.MedicineId,
                MedicineName = l.Medicine?.ExternalMedicineId ?? "N/A",
                Price = l.Price
            });

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var listing = await _listingService.GetListingByIdAsync(id);
            if (listing == null)
                return NotFound();

            var model = new ListingViewModel
            {
                Id = listing.Id,
                MedicineId = listing.MedicineId,
                MedicineName = listing.Medicine?.ExternalMedicineId ?? "N/A",
                Price = listing.Price
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> ByMedicine(Guid medicineId)
        {
            var listings = await _listingService.GetListingsByMedicineIdAsync(medicineId);

            var model = listings.Select(l => new ListingViewModel
            {
                Id = l.Id,
                MedicineId = l.MedicineId,
                MedicineName = l.Medicine?.ExternalMedicineId ?? "N/A",
                Price = l.Price
            });

            return View(model);
        }
    }
}
