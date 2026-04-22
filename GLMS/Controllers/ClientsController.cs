using Microsoft.AspNetCore.Mvc;

public class ClientsController : Controller
{
    private readonly AppDbContext _context;

    public ClientsController(AppDbContext context)
    {
        _context = context;
    }

    // VIEW ALL CLIENTS
    public IActionResult Index()
    {
        var clients = _context.Clients.ToList();
        return View(clients);
    }

    // CREATE PAGE
    public IActionResult Create()
    {
        return View();
    }

    // CREATE POST
    [HttpPost]
    public IActionResult Create(Client client)
    {
        if (!ModelState.IsValid)
            return View(client);

        _context.Clients.Add(client);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }
}