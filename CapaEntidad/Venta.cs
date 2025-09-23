using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Venta
    {
        public int id {  get; set; }
        public string fecha_hora { get; set; }
        public Proveedor ousuario { get; set; }
        public Cliente ocliente {  get; set; }
        public decimal total { get; set; }
        public string tipo_factura { get; set; }
    }
}
