using System.ComponentModel.DataAnnotations;

namespace Ventas.Models
{
    public class ClienteModel
    {
        [Key]
        public int Cliente_Id { get; set; }
        [Required(ErrorMessage = "El nombre es Requerido")]
        public string Nombre { get; set; } = string.Empty;
        [Required(ErrorMessage = "El número de identidad es Requerido")]
        [MaxLength(13, ErrorMessage = "El número máximo de caracteres es 13")]
        public string Cedula { get; set; } = string.Empty;
        [Required(ErrorMessage = "El correo es Requerido")]
        [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido")]
        public string correo { get; set; }= string.Empty;
        [Required(ErrorMessage = "El telefono es Requerido")]
        [MaxLength(10, ErrorMessage = "El número máximo de caracteres es 10")]
        public string telefono { get; set; } = string.Empty;
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaRegistro { get; set; }


    }
}
