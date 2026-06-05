using System;
using System.ComponentModel.DataAnnotations;

namespace Ventas.Models
{
    public class PedidoModel
    {
        [Key]
        public int Pedido_Id { get; set; }
        [Required(ErrorMessage = "El campo es Requerido")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaPedido { get; set; }
       

        [Required(ErrorMessage = "El campo es Requerido")]
        public decimal Total { get; set; }

        public int ClienteModelID { get; set; }
        public ClienteModel Cliente { get; set; } = default!;

        public int EstadoPedidoModelId { get; set; }
        public EstadoPedidoModel EstadoPedido { get; set; } = default!;
    }
}