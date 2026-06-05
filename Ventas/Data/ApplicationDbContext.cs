using Ventas.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Ventas.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
    {
        public DbSet<Ventas.Models.ProductoModel> ProductoModel { get; set; } = default!;
        public DbSet<ClienteModel> Cliente { get; set; }
        public DbSet<PedidoModel> Pedido { get; set; }
        public DbSet<EstadoPedidoModel>EstadoPedido { get; set; }
        public DbSet<DetallePedidoModel>DetallePedido { get; set; }


    }

}
