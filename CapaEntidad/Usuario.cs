using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Usuario
    {
        public int idusuario { get; set; }
        public  string nombre { get; set; }
        public  string apellido { get; set; }
        public string email { get; set; }
        public  string cuenta_usuario { get; set; }
        public string contrasena { get; set; }
        public string telefono { get; set; }
        public string dni { get; set; }
        public Rol oRol { get; set; } = new Rol();
        public bool estado { get; set; }
    }
}
