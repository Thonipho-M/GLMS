using GLMS.Models.ViewModels;
using GLMS.Shared.Requests;
using Microsoft.AspNetCore.Mvc;

public class ClientsController : Controller
{
    private readonly ClientApiService _service;

    public ClientsController(ClientApiService service)
    {
        _service = service;
    }

    // GET: Clients
    public async Task<IActionResult> Index()
    {
        var clientsDto = await _service.GetClients();

        var viewModel = clientsDto.Select(c => new ClientViewModel
        {
            Id = c.Id,
            Name = c.Name,
            Email = c.Email
        }).ToList();

        return View(viewModel);
    }

    // GET: Create
    public IActionResult Create()
    {
        return View(new ClientViewModel());
    }

    // POST: Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ClientViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var request = new CreateClientRequest
        {
            Name = model.Name,
            Email = model.Email
        };

        await _service.CreateClient(request);

        return RedirectToAction("Index");
    }
}