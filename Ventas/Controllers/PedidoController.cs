
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ventas.Data;
using Ventas.Models;

public class PedidoController : Controller
{
    private readonly ApplicationDbContext _context;

    public PedidoController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: PEDIDOMODELS
    public async Task<IActionResult> Index()    
    {
        var pedidosConRelaciones = await _context.Pedido
            .Include(p => p.Cliente)
            .Include(p => p.EstadoPedido)
            .ToListAsync();
        return View(await _context.Pedido.ToListAsync());
    }

    // GET: PEDIDOMODELS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var pedidomodel = await _context.Pedido
            .FirstOrDefaultAsync(m => m.Pedido_Id == id);
        if (pedidomodel == null)
        {
            return NotFound();
        }

        return View(pedidomodel);
    }

  
    public IActionResult Create()
    {

        ViewBag.ListaCliente = new SelectList(_context.Cliente.OrderBy(p => p.Nombre), "Cliente_Id", "Nombre");
        ViewBag.ListaEstado = new SelectList(_context.EstadoPedido.OrderBy(p => p.NombreEstado), "Estado_Id", "NombreEstado");       

        return View();
    }

 
   

    // POST: PEDIDOMODELS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]

    public async Task<IActionResult> Create([Bind("Pedido_Id,FechaPedido,Total,ClienteModelID,EstadoPedidoModelId")] PedidoModel pedidomodel)
    {
       
  
        ModelState.Remove("Cliente");
        ModelState.Remove("EstadoPedido");

        if (ModelState.IsValid)
        {
            _context.Add(pedidomodel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        
        ViewBag.ListaCliente = new SelectList(_context.Cliente.OrderBy(p => p.Nombre), "Cliente_Id", "Nombre", pedidomodel.ClienteModelID);
        ViewBag.ListaEstado = new SelectList(_context.EstadoPedido.OrderBy(p => p.NombreEstado), "Estado_Id", "NombreEstado", pedidomodel.EstadoPedidoModelId);

        return View(pedidomodel);
    }



    
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    // GET: Pedido/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var pedidoModel = await _context.Pedido.FirstOrDefaultAsync(m => m.Pedido_Id == id);
        if (pedidoModel == null)
        {
            return NotFound();
        }

        ViewBag.ListaCliente = new SelectList(_context.Cliente.OrderBy(p => p.Nombre), "Cliente_Id", "Nombre", pedidoModel.ClienteModelID);
        ViewBag.ListaEstado = new SelectList(_context.EstadoPedido.OrderBy(p => p.NombreEstado), "Estado_Id", "NombreEstado", pedidoModel.EstadoPedidoModelId);

        return View(pedidoModel);
    }

    // POST: Pedido/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Pedido_Id,FechaPedido,Total,ClienteModelID,EstadoPedidoModelId")] PedidoModel pedidoModel)
    {
        if (id != pedidoModel.Pedido_Id)
        {
            return NotFound();
        }        
        ModelState.Remove("Cliente");
        ModelState.Remove("EstadoPedido");

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(pedidoModel);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PedidoExists(pedidoModel.Pedido_Id))
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
        
        ViewBag.ListaCliente = new SelectList(_context.Cliente.OrderBy(p => p.Nombre), "Cliente_Id", "Nombre", pedidoModel.ClienteModelID);
        ViewBag.ListaEstado = new SelectList(_context.EstadoPedido.OrderBy(p => p.NombreEstado), "Id", "NombreEstado", pedidoModel.EstadoPedidoModelId);

        return View(pedidoModel);
    }

    private bool PedidoExists(int id)
    {
        return _context.Pedido.Any(e => e.Pedido_Id == id);
    }

    // GET: PEDIDOMODELS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var pedidomodel = await _context.Pedido
            .FirstOrDefaultAsync(m => m.Pedido_Id == id);
        if (pedidomodel == null)
        {
            return NotFound();
        }

        return View(pedidomodel);
    }

    // POST: PEDIDOMODELS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var pedidomodel = await _context.Pedido.FindAsync(id);
        if (pedidomodel != null)
        {
            _context.Pedido.Remove(pedidomodel);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool PedidoModelExists(int? id)
    {
        return _context.Pedido.Any(e => e.Pedido_Id == id);
    }
}
