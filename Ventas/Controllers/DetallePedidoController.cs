
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ventas.Data;
using Ventas.Models;

public class DetallePedidoController : Controller
{
    private readonly ApplicationDbContext _context;

    public DetallePedidoController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: DETALLEPEDIDOMODELS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.DetallePedido.ToListAsync());
    }

    // GET: DETALLEPEDIDOMODELS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var detallepedidomodel = await _context.DetallePedido
            .FirstOrDefaultAsync(m => m.Detalle_Id == id);
        if (detallepedidomodel == null)
        {
            return NotFound();
        }

        return View(detallepedidomodel);
    }

    public IActionResult Create()
    {    
       
        ViewBag.ListaPedidos = new SelectList(_context.Pedido, "Pedido_Id", "Pedido_Id");
        ViewBag.ListaProductos = new SelectList(_context.ProductoModel, "Producto_Id", "Nombre");

        return View();
    }

    // POST: DetallePedido/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Detalle_Id,Cantidad,Precio,PedidoModelId,ProductoModelId")] DetallePedidoModel detallePedidoModel)
    {
        
        ModelState.Remove("Pedido");
        ModelState.Remove("Producto");

        if (ModelState.IsValid)
        {
            _context.Add(detallePedidoModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        
        ViewBag.ListaPedidos = new SelectList(_context.Pedido, "Pedido_Id", "Pedido_Id", detallePedidoModel.PedidoModelId);
        ViewBag.ListaProductos = new SelectList(_context.ProductoModel, "Producto_Id", "Nombre", detallePedidoModel.ProductoModelId);

        return View(detallePedidoModel);
    }

    // GET: DETALLEPEDIDOMODELS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var detallepedidomodel = await _context.DetallePedido.FirstOrDefaultAsync(m => m.Detalle_Id == id);
        if (detallepedidomodel == null)
        {
            return NotFound();
        }
        
        ViewBag.ListaPedidos = new SelectList(_context.Pedido, "Pedido_Id", "Pedido_Id", detallepedidomodel.PedidoModelId);
        ViewBag.ListaProductos = new SelectList(_context.ProductoModel, "Producto_Id", "Nombre", detallepedidomodel.ProductoModelId);

        return View(detallepedidomodel);
    }

    // POST: DetallePedido/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Detalle_Id,Cantidad,Precio,PedidoModelId,ProductoModelId")] DetallePedidoModel detallepedidomodel)
    {
        if (id != detallepedidomodel.Detalle_Id)
        {
            return NotFound();        }

        
        ModelState.Remove("Pedido");
        ModelState.Remove("Producto");

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(detallepedidomodel);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetallePedidoModelExists(detallepedidomodel.Detalle_Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));        }

       
        ViewBag.ListaPedidos = new SelectList(_context.Pedido, "Pedido_Id", "Pedido_Id", detallepedidomodel.PedidoModelId);
        ViewBag.ListaProductos = new SelectList(_context.ProductoModel, "Producto_Id", "Nombre", detallepedidomodel.ProductoModelId);

        return View(detallepedidomodel);
    }








    // GET: DETALLEPEDIDOMODELS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var detallepedidomodel = await _context.DetallePedido
            .FirstOrDefaultAsync(m => m.Detalle_Id == id);
        if (detallepedidomodel == null)
        {
            return NotFound();
        }

        return View(detallepedidomodel);
    }

    // POST: DETALLEPEDIDOMODELS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var detallepedidomodel = await _context.DetallePedido.FindAsync(id);
        if (detallepedidomodel != null)
        {
            _context.DetallePedido.Remove(detallepedidomodel);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool DetallePedidoModelExists(int? id)
    {
        return _context.DetallePedido.Any(e => e.Detalle_Id == id);
    }
}
