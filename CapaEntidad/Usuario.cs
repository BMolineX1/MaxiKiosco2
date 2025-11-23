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
        public bool EsCliente { get; set; }
        public bool EsProveedor { get; set; }

        // Propiedad para recibir el valor CALCULADO del SP
        public string TipoRolCalculado { get; set; }

        public static Usuario Actual { get; private set; }

        public static void Iniciar(Usuario u)
        {
            if (u == null) throw new ArgumentNullException(nameof(u));
            Actual = u;
        }

        public static void Cerrar() => Actual = null;

        public static int UsuarioId()
        {
            if (Actual == null) throw new InvalidOperationException("No hay usuario en sesión.");
            return Actual.idusuario;
        }
    }
}
