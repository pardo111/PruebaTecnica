using Microsoft.AspNetCore.Mvc;
using App.Data;
using App.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

public class CategoriaController : Controller
{
    private readonly AppDbContext _context;
    private readonly ILogger<CategoriaController> _logger;  

    public CategoriaController(AppDbContext context, ILogger<CategoriaController> logger)
    {
        _context = context;
        _logger = logger;

    }

     
    public async Task<IActionResult> Index()
    {
        var categorias = await _context.Categorias.ToListAsync();
        return View(categorias);
    }
    public IActionResult Create()
    {
        return View();
    }

     [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Categoria categoria)
    {
        _logger.LogWarning("Categoría recibida: Codigo={Codigo}, Nombre={Nombre}",
    categoria.CodigoCategoria, categoria.Nombre);

            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();
            _logger.LogWarning("Modelo inválido al crear categoría");
            return RedirectToAction(nameof(Index)); 
        
    }
}
