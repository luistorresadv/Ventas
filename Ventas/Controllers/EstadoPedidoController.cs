
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ventas.Models;
using Ventas.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

public class EstadoPedidoController : Controller
{
    private readonly ApplicationDbContext _context;

    public EstadoPedidoController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: ESTADOPEDIDOMODELS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.EstadoPedido.ToListAsync());
    }

    // GET: ESTADOPEDIDOMODELS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var estadopedidomodel = await _context.EstadoPedido
            .FirstOrDefaultAsync(m => m.Estado_Id == id);
        if (estadopedidomodel == null)
        {
            return NotFound();
        }

        return View(estadopedidomodel);
    }

    // GET: ESTADOPEDIDOMODELS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: ESTADOPEDIDOMODELS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Estado_Id,NombreEstado,Descripcion,CodigoColor,Activo")] EstadoPedidoModel estadopedidomodel)
    {
        if (ModelState.IsValid)
        {
            _context.Add(estadopedidomodel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(estadopedidomodel);
    }

    // GET: ESTADOPEDIDOMODELS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var estadopedidomodel = await _context.EstadoPedido.FindAsync(id);
        if (estadopedidomodel == null)
        {
            return NotFound();
        }
        return View(estadopedidomodel);
    }

    // POST: ESTADOPEDIDOMODELS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Estado_Id,NombreEstado,Descripcion,CodigoColor,Activo")] EstadoPedidoModel estadopedidomodel)
    {
        if (id != estadopedidomodel.Estado_Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(estadopedidomodel);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstadoPedidoModelExists(estadopedidomodel.Estado_Id))
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
        return View(estadopedidomodel);
    }

    // GET: ESTADOPEDIDOMODELS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var estadopedidomodel = await _context.EstadoPedido
            .FirstOrDefaultAsync(m => m.Estado_Id == id);
        if (estadopedidomodel == null)
        {
            return NotFound();
        }

        return View(estadopedidomodel);
    }

    // POST: ESTADOPEDIDOMODELS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var estadopedidomodel = await _context.EstadoPedido.FindAsync(id);
        if (estadopedidomodel != null)
        {
            _context.EstadoPedido.Remove(estadopedidomodel);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool EstadoPedidoModelExists(int? id)
    {
        return _context.EstadoPedido.Any(e => e.Estado_Id == id);
    }
}
