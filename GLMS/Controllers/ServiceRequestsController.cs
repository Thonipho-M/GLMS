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

        public IActionResult Create(int contractId)
        {
            return View(new CreateServiceRequestViewModel
            {
                ContractId = contractId
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