using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using App.Data;
using App.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;

namespace ProductosVentasApp.Controllers;

public class ProductoController : Controller
{
    private readonly AppDbContext _context;
    private readonly ILogger<CategoriaController> _logger;

    public ProductoController(AppDbContext context, ILogger<CategoriaController> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
        var productos = await _context.Productos.Include(p => p.Categoria).ToListAsync();
        return View(productos);
    }

    public IActionResult Create()
    {
        ViewData["Categorias"] = new SelectList(_context.Categorias, "CodigoCategoria", "Nombre");
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Producto producto)
    {

        _logger.LogWarning("producto recibida: Codigo={Codigo}, Nombre={Nombre}",
           producto.CodigoCategoria, producto.Nombre);
        _context.Productos.Add(producto);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));


    }

}
