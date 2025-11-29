using Microsoft.AspNetCore.Mvc;
using SmartMeds.Core.Interfaces;

namespace SmartMeds.Web.Controllers
{
    public class MedicineController : Controller
    {
        private readonly IMedicineService _medicineService;

        public MedicineController(IMedicineService medicineService)
        {
            _medicineService = medicineService;
        }

        // GET: /Medicine/
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var medicines = await _medicineService.GetAllMedicinesAsync();
            return View(medicines);
        }

        // GET: /Medicine/Details/{id}
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var medicine = await _medicineService.GetMedicineByIdAsync(id);
            if (medicine == null)
                return NotFound();

            return View(medicine);
        }

        // GET: /Medicine/CloseToExpiration
        [HttpGet]
        public async Task<IActionResult> CloseToExpiration(int days = 30)
        {
            var medicines = await _medicineService.GetMedicinesCloseToExpirationAsync(days);
            ViewBag.DaysThreshold = days;
            return View(medicines);
        }
    }
}