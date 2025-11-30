using BarcodeAPI.Implementation;
using BarcodeAPI.Interfaces;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using SmartMeds.Core.Interfaces;
using SmartMeds.Data.Entities;
using SmartMeds.Web.Models;

namespace SmartMeds.Web.Controllers
{
    public class MedicineController : Controller
    {
        private readonly IMedicineService _medicineService;
        private readonly IBarcodeEncoder _barcodeEncoder;

        public MedicineController(IMedicineService medicineService)
        {
            _medicineService = medicineService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var medicines = await _medicineService.GetAllMedicinesAsync();

            var model = medicines.Select(m => new MedicineViewModel
            {
                Id = m.Id,
                Name = m.Name,
                ExternalMedicineId = m.ExternalMedicineId,
                Quantity = m.Quantity,
                ExpirationDate = m.ExpirationDate,
                Status = m.Status
            });

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(long id)
        {
            var m = await _medicineService.GetMedicineByIdAsync(id);
            if (m == null)
                return NotFound();

            var model = new MedicineViewModel
            {
                Id = m.Id,
                Name = m.Name,
                ExternalMedicineId = m.ExternalMedicineId,
                Quantity = m.Quantity,
                ExpirationDate = m.ExpirationDate,
                Status = m.Status
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> CloseToExpiration(int days = 30)
        {
            var medicines = await _medicineService.GetMedicinesCloseToExpirationAsync(days);

            var model = medicines.Select(m => new MedicineViewModel
            {
                Id = m.Id,
                Name = m.Name,
                ExternalMedicineId = m.ExternalMedicineId,
                Quantity = m.Quantity,
                ExpirationDate = m.ExpirationDate,
                Status = m.Status
            });

            ViewBag.DaysThreshold = days;

            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new AddMedicineViewModel
            {
                ExpirationDate = DateTime.Today.AddMonths(3)
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddMedicineViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var res = await _barcodeEncoder.GetTitleByBarcode(model.ImageUrl);

            var medicine = new Medicine
            {
                ExternalMedicineId = model.ExternalMedicineId,
                Quantity = model.Quantity,
                ExpirationDate = model.ExpirationDate,
                Id = res.id,
                Name = res.title
            };

            await _medicineService.AddMedicineAsync(medicine);

            return RedirectToAction("Index", "Medicines");
        }
    }
}