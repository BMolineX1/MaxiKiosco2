using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class detalle_venta
    {
        public int id {  get; set; }
        public Venta oventa {  get; set; }
        public Producto oproducto { get; set; }
        public int cantidad { get; set; }
        public decimal precio_unitario { get; set; }
    }
}
