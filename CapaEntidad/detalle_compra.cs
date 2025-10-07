using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class detalle_compra
    {
        public int id { get; set; }
        public Compra ocompra { get; set; } = new Compra();
        public Producto oproducto { get; set; } = new Producto();
        public int cantidad { get; set; }
        public decimal precio_compra { get; set; }      // mapea a preciocompra
        public decimal montototal { get; set; }           // opcional: si lo usás
        public decimal? precioventa { get; set; }         // opcional
        public DateTime? fecharegistro { get; set; }      // opcional
    }
}
