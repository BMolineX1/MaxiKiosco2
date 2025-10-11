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
            if (string.IsNullOrEmpty(objcliente.nombre) || string.IsNullOrEmpty(objcliente.apellido))
            {
                Mensaje = "Debe ingresar su nombre completo";
            }
            if (string.IsNullOrEmpty(objcliente.dni))
            {
                Mensaje = "Debe ingresar su dni";
            }
            if (string.IsNullOrEmpty(objcliente.domicilio))
            {
                Mensaje = "Debe ingresar su domicilio";
            }
            if (string.IsNullOrEmpty(objcliente.telefono))
            {
                Mensaje = "Debe ingresar su numero de telefono";
            }
            // --- VALIDACIONES FISCALES (NUEVO) ---
            // Si el cliente NO es Consumidor Final, requiere CUIT y Razón Social.
            if (objcliente.condicion_iva != "Consumidor Final")
            {
                if (string.IsNullOrEmpty(objcliente.cuit) || objcliente.cuit.Length < 11)
                {
                    // Nota: Aquí podrías validar un formato de CUIT más estricto si lo deseas.
                    Mensaje = "El CUIT es obligatorio y debe ser válido para esta Condición IVA.\n";
                }
                if (string.IsNullOrEmpty(objcliente.razonsocial))
                {
                    Mensaje += "La Razón Social es obligatoria para esta Condición IVA.";
                }
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
            // --- VALIDACIONES BÁSICAS EXISTENTES ---
            if (string.IsNullOrEmpty(objcliente.nombre) || string.IsNullOrEmpty(objcliente.apellido))
            {
                Mensaje = "Debe ingresar datos en el campo Nombre y Apellido";
            }
            if (string.IsNullOrEmpty(objcliente.dni))
            {
                Mensaje = "Debe ingresar el DNI del cliente";
            }
            if (string.IsNullOrEmpty(objcliente.domicilio))
            {
                Mensaje = "Debe ingresar el domicilio del cliente";
            }
            if (string.IsNullOrEmpty(objcliente.telefono))
            {
                Mensaje = "Debe ingresar el numero de telefono del cliente";
            }
            // --- VALIDACIONES FISCALES (NUEVO) ---
            // Si el cliente NO es Consumidor Final, requiere CUIT y Razón Social.
            if (objcliente.condicion_iva != "Consumidor Final")
            {
                if (string.IsNullOrEmpty(objcliente.cuit) || objcliente.cuit.Length < 11)
                {
                    Mensaje = "El CUIT es obligatorio y debe ser válido para esta Condición IVA.\n";
                }
                if (string.IsNullOrEmpty(objcliente.razonsocial))
                {
                    Mensaje += "La Razón Social es obligatoria para esta Condición IVA.";
                }
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
