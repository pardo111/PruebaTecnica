
using App.Models;
using App.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

public class VentaController : Controller
{

    private readonly AppDbContext _context;

    public VentaController(AppDbContext context)
    {
        _context = context;
    }
public async Task<IActionResult> Index( int? categoria)
{
    ViewData["Categorias"] = new SelectList(await _context.Categorias.ToListAsync(), "CodigoCategoria", "Nombre");
    ViewData["CategoriaSeleccionada"] = categoria;

    if ( !categoria.HasValue)
    {
        return View(new List<Venta>());
    }

    var query = _context.Ventas
        .Include(v => v.Producto)
            .ThenInclude(p => p.Categoria)
        .Where(v => v.Fecha.Year == 2019 && v.Producto.CodigoCategoria == categoria.Value);

    var ventas = await query.ToListAsync();
    return View(ventas);
}

    public IActionResult Create()
    {
        ViewData["Productos"] = new SelectList(_context.Productos, "CodigoProducto", "Nombre");
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Venta venta)
    {

        _context.Ventas.Add(venta);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));

    }

}