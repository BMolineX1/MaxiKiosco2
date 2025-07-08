using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Compra
    {
        public int Id { get; set; }
        public string fecha_hora {  get; set; }
        public decimal total { get; set;}
        public Usuario ousuario { get; set; }
        public Proveedor oproveedor { get; set; }

    }
}
