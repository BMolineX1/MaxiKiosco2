using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Producto
    {  
        private CD_Producto object_producto = new CD_Producto();

        public List<Producto> Listar()
        {
            return object_producto.Listar();
        }
        //traemos registrar de CN_Producto
        public int Registrar(Producto obj, out string Mensaje)
        {
            //el mensaje va a ir como vacio
            Mensaje = string.Empty;
            if (obj.nombre == "")
            {
                Mensaje += "Es necesario el nombre del Producto\n";
            }
            if (obj.codigo == "")
            {
                Mensaje += "Es necesario agregar el codigo del Producto\n";
            }
            if (obj.descripcion == "")
            {
                Mensaje += "Es necesario agregar la descripcion del Producto\n";
            }
            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return object_producto.Registrar(obj, out Mensaje);
            }
        }


        //traemos editar de CN_Producto
        public bool Editar(Producto obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (obj.nombre == "")
            {
                Mensaje += "Es necesario el nombre del Producto\n";
            }
            if (obj.codigo == "")
            {
                Mensaje += "Es necesario agregar el codigo del Producto\n";
            }
            if (obj.descripcion == "")
            {
                Mensaje += "Es necesario agregar la descripcion del Producto\n";
            }
            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return object_producto.Editar(obj, out Mensaje);
            }

        }
        //traemos eliminar de CN_Producto
        public bool Eliminar(Producto obj, out string Mensaje)
        {
            return object_producto.Eliminar(obj, out Mensaje);
        }
    }
}
