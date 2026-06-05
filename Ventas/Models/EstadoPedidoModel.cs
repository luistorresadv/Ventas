using Microsoft.CodeAnalysis;
using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;


namespace Ventas.Models
{
    public class EstadoPedidoModel
    {
        [Key]
        public int Estado_Id { get; set; }
        [Required(ErrorMessage = "El campo es Requerido")]
        public string NombreEstado { get; set; } = string.Empty;
        [Required(ErrorMessage = "El campo es Requerido")]
        public string Descripcion { get; set; } = string.Empty;
        [Required(ErrorMessage = "El campo es Requerido")]
        public decimal CodigoColor { get; set; }
        [Required(ErrorMessage = "El campo es Requerido")]
        public bool Activo { get; set; }       


    }
}
