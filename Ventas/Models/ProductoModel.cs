using Microsoft.CodeAnalysis;
using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;

namespace Ventas.Models
{
    public class ProductoModel
    {
        [Key]
        public int Producto_Id { get; set; }
        [Required(ErrorMessage = "El campo es Requerido")]       
        public string Nombre { get; set; } = string.Empty;
        [Required(ErrorMessage = "El campo es Requerido")]
        public decimal Precio { get; set; }
        [Required(ErrorMessage = "El campo es Requerido")]
        public decimal Stock { get; set; }
        [Required(ErrorMessage = "El campo es Requerido")]
        public string Categoria { get; set; } = string.Empty;

    }
}
