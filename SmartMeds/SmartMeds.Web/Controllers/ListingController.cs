using Microsoft.AspNetCore.Mvc;
using SmartMeds.Core.Interfaces;

namespace SmartMeds.Web.Controllers
{
    public class ListingController : Controller
    {
        private readonly IListingService _listingService;

        public ListingController(IListingService listingService)
        {
            _listingService = listingService;
        }

        public async Task<IActionResult> Index()
        {
            var listings = await _listingService.GetAllListingsAsync();
            return View(listings);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var listing = await _listingService.GetListingByIdAsync(id);
            if (listing == null)
                return NotFound();

            return View(listing);
        }

        public async Task<IActionResult> ByMedicine(Guid medicineId)
        {
            var listings = await _listingService.GetListingsByMedicineIdAsync(medicineId);
            return View(listings);
        }
    }
}