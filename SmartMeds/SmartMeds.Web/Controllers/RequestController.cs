using Microsoft.AspNetCore.Mvc;
using SmartMeds.Core.Interfaces;
using SmartMeds.Data.Enums;
using SmartMeds.Web.Models;

namespace SmartMeds.Web.Controllers
{
    public class RequestController : Controller
    {
        private readonly IRequestService _requestService;

        public RequestController(IRequestService requestService)
        {
            _requestService = requestService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var requests = await _requestService.GetAllRequestsAsync();

            var vm = requests.Select(r => new RequestViewModel
            {
                Id = r.Id,
                FromHospitalId = r.FromHospitalId,
                FromHospitalName = r.FromHospital.Name,
                ToHospitalId = r.ToHospitalId,
                ToHospitalName = r.ToHospital.Name,
                MedicineName = r.Name, 
                Status = r.Status,
                CreatedOn = r.PostedAt
            });

            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Pending(long? hospitalId = null)
        {
            IEnumerable<Data.Entities.Request> requests;

            if (hospitalId.HasValue)
            {
                requests = await _requestService.GetPendingRequestsForHospitalAsync(hospitalId.Value);
            }
            else
            {
                requests = await _requestService.GetRequestsByStatusAsync(RequestStatus.Pending);
            }

            var vm = requests.Select(r => new RequestViewModel
            {
                Id = r.Id,
                FromHospitalId = r.FromHospitalId,
                FromHospitalName = r.FromHospital.Name,
                ToHospitalId = r.ToHospitalId,
                ToHospitalName = r.ToHospital.Name,
                MedicineName = r.Name, 
                Status = r.Status,
                CreatedOn = r.PostedAt
            });

            return View(vm);
        }

    }
}