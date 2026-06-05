using Microsoft.CodeAnalysis;
using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;
namespace Ventas.Models
{
    public class DetallePedidoModel
    {
        [Key]
        public int Detalle_Id { get; set; }
        [Required(ErrorMessage = "El campo es Requerido")]
        public decimal Cantidad { get; set; }
        [Required(ErrorMessage = "El campo es Requerido")]
        public decimal Precio { get; set; }
        public int PedidoModelId { get; set; }
        public PedidoModel Pedido { get; set; }
        public int ProductoModelId { get; set; }
        public ProductoModel Producto { get; set; }


    }
}
