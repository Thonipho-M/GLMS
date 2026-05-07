using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class ContractsController : Controller
{
    private readonly AppDbContext _context;
    private readonly FileService _fileService;

    public ContractsController(AppDbContext context, FileService fileService)
    {
        _context = context;
        _fileService = fileService;
    }

    // GET: Create
    public IActionResult Create()
    {
        var clients = _context.Clients.ToList();

        if (!clients.Any())
        {
            TempData["Error"] = "Please create a client first.";
            return RedirectToAction("Create", "Clients");
        }

        ViewBag.Clients = clients;
        return View();
    }

    // POST: Create
    [HttpPost]
    public IActionResult Create(Contract contract, IFormFile file)
    {
        if (file != null)
        {
            try
            {
                contract.FilePath = _fileService.SavePdf(file);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(contract);
            }
        }

        _context.Contracts.Add(contract);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }

    // GET: Edit
    public IActionResult Edit(int id)
    {
        var contract = _context.Contracts.Find(id);

        if (contract == null)
            return NotFound();

        ViewBag.Clients = _context.Clients.ToList();

        return View(contract);
    }

    [HttpPost]
    public IActionResult Edit(Contract contract)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Clients = _context.Clients.ToList();
            return View(contract);
        }

        var existingContract = _context.Contracts.Find(contract.Id);

        if (existingContract == null)
            return NotFound();

        existingContract.ClientId = contract.ClientId;
        existingContract.StartDate = contract.StartDate;
        existingContract.EndDate = contract.EndDate;
        existingContract.Status = contract.Status;
        existingContract.ServiceLevel = contract.ServiceLevel;

        _context.SaveChanges();

        TempData["Success"] = "Contract updated successfully";

        return RedirectToAction("Index");
    }

    // GET: Download PDF
    public IActionResult Download(int id)
    {
        var contract = _context.Contracts.Find(id);
        if (contract == null || contract.FilePath == null)
            return NotFound();

        var path = Path.Combine("wwwroot", contract.FilePath.TrimStart('/'));
        var bytes = System.IO.File.ReadAllBytes(path);

        return File(bytes, "application/pdf", "Agreement.pdf");
    }

    public IActionResult Index(string status, DateTime? startDate, DateTime? endDate)
    {
        var contracts = _context.Contracts.Include(c => c.Client).AsQueryable();

        if (!string.IsNullOrEmpty(status))
            contracts = contracts.Where(c => c.Status == status);

        if (startDate.HasValue)
            contracts = contracts.Where(c => c.StartDate >= startDate);

        if (endDate.HasValue)
            contracts = contracts.Where(c => c.EndDate <= endDate);

        return View(contracts.ToList());
    }
}