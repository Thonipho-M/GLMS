using GLMS.Models.ViewModels;
using GLMS.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace GLMS.Web.Controllers
{
    public class ServiceRequestsController : Controller
    {
        private readonly ApiService _api;

        public ServiceRequestsController(ApiService api)
        {
            _api = api;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _api.GetServiceRequests();
            return View(data);
        }

        public async Task<IActionResult> Create()
        {
            var contracts = await _api.GetContracts();

            return View(new CreateServiceRequestViewModel
            {
                Contracts = contracts
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateServiceRequestViewModel model)
        {
            await _api.CreateServiceRequest(model);
            return RedirectToAction("Index");
        }
    }
}