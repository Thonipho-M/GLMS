using Microsoft.AspNetCore.Mvc;
using GLMS.Shared.Requests;
using GLMS.Shared.DTOs;

public class ClientsController : Controller
{
    private readonly ClientApiService _service;

    public ClientsController(ClientApiService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        var clients = await _service.GetClients();
        return View(clients);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateClientRequest request)
    {
        await _service.CreateClient(request);
        return RedirectToAction("Index");
    }
}