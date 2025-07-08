using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;
namespace CapaNegocio
{
    public class CN_Usuario
    {
        private CD_Usuario object_usuario = new CD_Usuario();

        public List<Usuario> Listar()
        {
            return object_usuario.Listar();
        }
        //traemos registrar de CN_Usuario
        public int Registrar(Usuario obj, out string Mensaje)
        {
            //el mensaje va a ir como vacio
            Mensaje = string.Empty;
            if (obj.nombre == "" && obj.apellido == "")
            {
                Mensaje += "Es necesario el nombre y apellido del usuario\n";
            }
            if (obj.dni == "")
            {
                Mensaje += "Es necesario agregar el dni del usuario\n";
            }
            if (obj.contrasena == "")
            {
                Mensaje += "Es necesario agregar la clave del usuario\n";
            }
            if (obj.cuenta_usuario == "")
            {
                Mensaje += "Es necesario agregar el nombre de usuario\n";
            }
            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return object_usuario.Registrar(obj, out Mensaje);
            }
        }


        //traemos editar de CN_Usuario
        public bool Editar(Usuario obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (obj.nombre == "" && obj.apellido == "")
            {
                Mensaje += "Es necesario el nombre y apellido del usuario\n";
            }
            if (obj.dni == "")
            {
                Mensaje += "Es necesario agregar el dni del usuario\n";
            }
            if (obj.contrasena == "")
            {
                Mensaje += "Es necesario agregar la clave del usuario\n";
            }
            if (obj.cuenta_usuario == "")
            {
                Mensaje += "Es necesario agregar el nombre de usuario\n";
            }
            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return object_usuario.Editar(obj, out Mensaje);
            }
            
        }
        //traemos eliminar de CN_Usuario
        public bool Eliminar(Usuario obj, out string Mensaje)
        {
            return object_usuario.Eliminar(obj, out Mensaje);
        }
    }
}
