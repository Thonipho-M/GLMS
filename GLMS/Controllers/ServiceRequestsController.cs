using Microsoft.AspNetCore.Mvc;

public class ServiceRequestsController : Controller
{
    private readonly AppDbContext _context;
    private readonly ServiceRequestService _service;
    private readonly CurrencyService _currencyService;

    public ServiceRequestsController(
        AppDbContext context,
        ServiceRequestService service,
        CurrencyService currencyService)
    {
        _context = context;
        _service = service;
        _currencyService = currencyService;
    }

    // GET: Create
    public async Task<IActionResult> Create()
    {
        ViewBag.Contracts = _context.Contracts.ToList();
        ViewBag.Rate = await _currencyService.GetUsdToZarRateAsync();

        return View();
    }

    // POST: Create
    [HttpPost]
    public async Task<IActionResult> Create(ServiceRequest request, decimal usdAmount)
    {
        var contract = _context.Contracts.Find(request.ContractId);

        if (!_service.CanCreateServiceRequest(contract.Status))
        {
            ModelState.AddModelError("", "Cannot create request for expired/on hold contract");
            return View(request);
        }

        var rate = await _currencyService.GetUsdToZarRateAsync();
        request.CostZAR = _currencyService.ConvertUsdToZar(usdAmount, rate);

        _context.ServiceRequests.Add(request);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }
}