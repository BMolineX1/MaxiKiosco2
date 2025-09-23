using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Proveedor
    {
        private CD_Proveedor object_proveedor = new CD_Proveedor();

        public List<Proveedor> Listar()
        {
            return object_proveedor.Listar();
        }
        //traemos registrar de CN_Proveedor
        public int Registrar(Proveedor obj, out string Mensaje)
        {
            //el mensaje va a ir como vacio
            Mensaje = string.Empty;
            if (obj.nombre == "")
            {
                Mensaje += "Es necesario el nombre y apellido del Proveedor\n";
            }
            if (obj.cuit == "")
            {
                Mensaje += "Es necesario agregar el cuit del Proveedor\n";
            }
            if (obj.email == "")
            {
                Mensaje += "Es necesario agregar el email del Proveedor\n";
            }
            if (obj.telefono == "")
            {
                Mensaje += "Es necesario agregar el telefono del Proveedor\n";
            }


            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return object_proveedor.Registrar(obj, out Mensaje);
            }
        }


        //traemos editar de CN_Proveedor
        public bool Editar(Proveedor obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (obj.nombre == "")
            {
                Mensaje += "Es necesario el nombre y apellido del Proveedor\n";
            }
            if (obj.cuit == "")
            {
                Mensaje += "Es necesario agregar el cuit del Proveedor\n";
            }
            if (obj.email == "")
            {
                Mensaje += "Es necesario agregar el email del Proveedor\n";
            }
            if (obj.telefono == "")
            {
                Mensaje += "Es necesario agregar el telefono del Proveedor\n";
            }

            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return object_proveedor.Editar(obj, out Mensaje);
            }

        }
        //traemos eliminar de CN_Proveedor
        public bool Eliminar(Proveedor obj, out string Mensaje)
        {
            return object_proveedor.Eliminar(obj, out Mensaje);
        }
    }
}
