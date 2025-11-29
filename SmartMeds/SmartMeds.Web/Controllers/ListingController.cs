using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SmartMeds.Core.Interfaces;
using SmartMeds.Data.Entities;
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
            var listings = await _listingService.GetAllListingsAsync();

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

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var listings = await _listingService.GetAllListingsAsync();

            var medicines = listings
                .Select(l => l.Medicine)
                .Where(m => m != null)
                .Distinct()
                .ToList();

            var model = new CreateListingViewModel
            {
                MedicineOptions = medicines
                    .Select(m => new SelectListItem
                    {
                        Value = m!.Id.ToString(),
                        Text = m.ExternalMedicineId
                    })
                    .ToList()
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateListingViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var listings = await _listingService.GetAllListingsAsync();
                var medicines = listings
                    .Select(l => l.Medicine)
                    .Where(m => m != null)
                    .Distinct()
                    .ToList();

                model.MedicineOptions = medicines
                    .Select(m => new SelectListItem
                    {
                        Value = m!.Id.ToString(),
                        Text = m.ExternalMedicineId
                    })
                    .ToList();

                return View(model);
            }

            var listing = new Listing
            {
                Id = Guid.NewGuid(),
                MedicineId = model.MedicineId,
                Price = model.Price
            };

            await _listingService.CreateListingAsync(listing);
            return RedirectToAction(nameof(Index));
        }
    }
}
