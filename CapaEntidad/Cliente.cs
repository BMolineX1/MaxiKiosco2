using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Cliente
    {  
        public int id {  get; set; }
        public string nombre { get; set; }
        public string apellido {  get; set; }
        public string telefono { get; set; }
        public string domicilio { get; set; }
        public string dni {  get; set; }
        public string cuit { get; set;  }
        public string email { get; set; }
        public bool estado { get; set; }
    }
}
