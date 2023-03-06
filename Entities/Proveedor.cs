using System.ComponentModel.DataAnnotations;

namespace Control_Stock.Entities
{
    public class Proveedor
    {
        [Key]
        public int IdProveedor { get; set; }
        [Required]
        public string? NombreProveedor { get; set; }
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
        public string? Descripcion { get; set; }
        public string? UrlLogo { get; set; }
    }
}
