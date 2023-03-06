using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Control_Stock.Entities
{
    public class Insumo
    {
        [Key]
        public int IdInsumo { get; set; }
        [Required]
        public string? NombreInsumo { get; set; }
        public string? Tipo { get; set; }
        public int Cantidad { get; set; }
        public string? Descripcion { get; set; }
        public string? UrlImagen { get; set; }
    }
}
