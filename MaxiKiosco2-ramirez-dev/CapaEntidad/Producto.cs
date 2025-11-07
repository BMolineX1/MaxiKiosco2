using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Producto
    {
        public int Id { get; set; }
        public string nombre { get; set; }
        public int stock { get; set; }
        public decimal precioventa { get; set; }
        public Categoria ocategoria { get; set; }
        public decimal preciocompra { get; set; }
        public string descripcion { get; set; }
        public string fecharegistro { get; set; }
        public bool estado { get; set; }
        public string codigo {  get; set; }
    }
}
