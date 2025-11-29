using Microsoft.AspNetCore.Mvc;
using SmartMeds.Core.Interfaces;

namespace SmartMeds.Web.Controllers
{
    public class HospitalController : Controller
    {
        private readonly IHospitalService _hospitalService;

        public HospitalController(IHospitalService hospitalService)
        {
            _hospitalService = hospitalService;
        }

        // GET: /Hospital/
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var hospitals = await _hospitalService.GetAllHospitalsAsync();
            return View(hospitals);
        }

        // GET: /Hospital/Details/{id}
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var hospital = await _hospitalService.GetHospitalWithRequestsAsync(id);
            if (hospital == null)
                return NotFound();

            return View(hospital);
        }
    }
}