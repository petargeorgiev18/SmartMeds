using Microsoft.AspNetCore.Mvc;
using SmartMeds.Core.Interfaces;
using SmartMeds.Data.Enums;

namespace SmartMeds.Web.Controllers
{
    public class RequestController : Controller
    {
        private readonly IRequestService _requestService;

        public RequestController(IRequestService requestService)
        {
            _requestService = requestService;
        }

        // GET: /Request/
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var requests = await _requestService.GetAllRequestsAsync();
            return View(requests);
        }

        // GET: /Request/Details/{id}
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var request = await _requestService.GetRequestByIdAsync(id);
            if (request == null)
                return NotFound();

            return View(request);
        }

        // GET: /Request/Pending?hospitalId={id}
        [HttpGet]
        public async Task<IActionResult> Pending(Guid? hospitalId = null)
        {
            if (hospitalId.HasValue)
            {
                var pending = await _requestService.GetPendingRequestsForHospitalAsync(hospitalId.Value);
                return View(pending);
            }

            var allPending = await _requestService.GetRequestsByStatusAsync(RequestStatus.Pending);
            return View(allPending);
        }
    }
}