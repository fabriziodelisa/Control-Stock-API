using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Control_Stock.Entities
{
    public class Precio
    {
        [Key]
        public int IdPrecio { get; set; }
        public int PrecioProd { get; set; }
        public DateTime Fecha { get; set; }

    }
}
