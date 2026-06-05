
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ventas.Models;
using Ventas.Data;

public class ProductoController : Controller
{
    private readonly ApplicationDbContext _context;

    public ProductoController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: PRODUCTOMODELS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.ProductoModel.ToListAsync());
    }

    // GET: PRODUCTOMODELS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var productomodel = await _context.ProductoModel
            .FirstOrDefaultAsync(m => m.Producto_Id == id);
        if (productomodel == null)
        {
            return NotFound();
        }

        return View(productomodel);
    }

    // GET: PRODUCTOMODELS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: PRODUCTOMODELS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Producto_Id,Nombre,Precio,Stock,Categoria")] ProductoModel productomodel)
    {
        if (ModelState.IsValid)
        {
            _context.Add(productomodel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(productomodel);
    }

    // GET: PRODUCTOMODELS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var productomodel = await _context.ProductoModel.FindAsync(id);
        if (productomodel == null)
        {
            return NotFound();
        }
        return View(productomodel);
    }

    // POST: PRODUCTOMODELS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Producto_Id,Nombre,Precio,Stock,Categoria")] ProductoModel productomodel)
    {
        if (id != productomodel.Producto_Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(productomodel);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductoModelExists(productomodel.Producto_Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(productomodel);
    }

    // GET: PRODUCTOMODELS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var productomodel = await _context.ProductoModel
            .FirstOrDefaultAsync(m => m.Producto_Id == id);
        if (productomodel == null)
        {
            return NotFound();
        }

        return View(productomodel);
    }

    // POST: PRODUCTOMODELS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var productomodel = await _context.ProductoModel.FindAsync(id);
        if (productomodel != null)
        {
            _context.ProductoModel.Remove(productomodel);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ProductoModelExists(int? id)
    {
        return _context.ProductoModel.Any(e => e.Producto_Id == id);
    }
}
