using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Negocio
    {
        private CD_Negocio object_Negocio = new CD_Negocio();

        public Negocio ObtenerDatos()
        {
            return object_Negocio.ObtenerDatos();
        }
        //traemos registrar de CN_Negocio
        public bool GuardarDatos(Negocio obj, out string Mensaje)
        {
            //el mensaje va a ir como vacio
            Mensaje = string.Empty;
            if (obj.nombre == "" )
            {
                Mensaje += "Es necesario el nombre del Negocio\n";
            }
            if (obj.ruc == "")
            {
                Mensaje += "Es necesario agregar el numero de ruc del Negocio\n";
            }
            if (obj.direccion == "")
            {
                Mensaje += "Es necesario agregar la clave del Negocio\n";
            }
            
            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return object_Negocio.GuardarDatos(obj, out Mensaje);
            }
        }
        public byte[] ObtenerLogo(out bool obtenido)
        {
            return object_Negocio.ObtenerLogo(out obtenido);
        }

        public bool ActualizarLogo(byte[] imagen, out string mensaje)
        {
            return object_Negocio.ActualizarLogo(imagen, out mensaje);
        }

    }
}
