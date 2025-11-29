using Microsoft.AspNetCore.Mvc;
using SmartMeds.Core.Interfaces;
using SmartMeds.Web.Models;

namespace SmartMeds.Web.Controllers
{
    public class MedicineController : Controller
    {
        private readonly IMedicineService _medicineService;

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
                ExternalMedicineId = m.ExternalMedicineId,
                Quantity = m.Quantity,
                ExpirationDate = m.ExpirationDate,
                Status = m.Status
            });

            ViewBag.DaysThreshold = days;

            return View(model);
        }
    }
}