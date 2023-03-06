using System.ComponentModel.DataAnnotations;

namespace Control_Stock.Models.DtoProveedor
{
    public class ProveedorDTO
    {
        public int IdProveedor { get; set; }
        public string? NombreProveedor { get; set; }
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
        public string? Descripcion { get; set; }
        public string? UrlLogo { get; set; }
    }
}
