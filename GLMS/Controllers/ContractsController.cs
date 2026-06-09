using GLMS.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace GLMS.Web.Controllers
{
    public class ContractsController : Controller
    {
        private readonly ApiService _api;

        public ContractsController(ApiService api)
        {
            _api = api;
        }

        public async Task<IActionResult> Index()
        {
            var contracts = await _api.GetContracts();
            return View(contracts);
        }
    }
}