using CapaEntidad;
using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_Cliente
    {
        private CD_Cliente objeto_cliente = new CD_Cliente();

        public List<Cliente> Listar()
        {
            return objeto_cliente.Listar();
        }

        public int Registrar(Cliente objcliente, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (objcliente.nombre == "" && objcliente.apellido == "")
            {
                Mensaje = "Debe ingresar su nombre completo";
            }
            if (objcliente.dni == "")
            {
                Mensaje = "Debe ingresar su dni";
            }
            if (objcliente.domicilio == "")
            {
                Mensaje = "Debe ingresar su domicilio";
            }
            if (objcliente.telefono == "")
            {
                Mensaje = "Debe ingresar su numero de telefono";
            }
            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objeto_cliente.Registrar(objcliente,out Mensaje);
            }           
        }
        public bool EditarCliente(Cliente objcliente, out string Mensaje) 
        { 
            Mensaje= string.Empty;
            if (objcliente.nombre == "" && objcliente.apellido == "")
            {
                Mensaje = "Debe ingresar datos en el campo Nombre y Apellido";
            }
            if (objcliente.dni == "")
            {
                Mensaje = "Debe ingresar el DNI del cliente";
            }
            if (objcliente.domicilio == "")
            {
                Mensaje = "Debe ingresar el domicilio del cliente";
            }
            if (objcliente.telefono == "")
            {
                Mensaje = "Debe ingresar el numero de telefono del cliente";
            }
            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objeto_cliente.EditarCliente(objcliente,out Mensaje); 
            }
        }

        public bool EliminarCliente(Cliente objcliente,out string Mensaje)
        {
            return objeto_cliente.EliminarCliente(objcliente,out Mensaje);
        }
    }
}
