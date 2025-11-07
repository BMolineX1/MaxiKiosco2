using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaEntidad;
using CapaEntidad.Interfaces;

namespace MaxiKiosco.UnitTests.Fakes
{
    public class FakeClienteRepository : IClienteRepository
    {
        private List<Cliente> _clientes = new List<Cliente>()
        {
            // Cliente 1: Activo, DNI normal
            new Cliente() { id_cliente = 1, dni = "10000000", nombre_completo = "Juan Pérez", estado = true },
            // Cliente 2: Inactivo, DNI para test de búsqueda
            new Cliente() { id_cliente = 2, dni = "20000000", nombre_completo = "Ana Gómez", estado = false }, 
            // Cliente 3: Activo, Nombre para test de edición
            new Cliente() { id_cliente = 3, dni = "30000000", nombre_completo = "Carlos Ruiz", estado = true }
        };

        public List<Cliente> Listar() => _clientes;

        public int Registrar(Cliente obj, out string Mensaje)
        {
            Mensaje = "Fake: Cliente registrado.";
            // Si tiene DNI inválido, simulamos fallo en CN
            if (string.IsNullOrEmpty(obj.dni)) { Mensaje = "DNI es obligatorio"; return 0; }
            return 4; // Devuelve ID ficticio para éxito
        }

        public bool EditarCliente(Cliente obj, out string Mensaje)
        {
            // CORRECCIÓN: Simular el fallo si intentamos editar un ID inexistente
            if (obj.id_cliente == 999)
            {
                Mensaje = "Fake: No se encontró el cliente con ese ID.";
                return false; // Devuelve FALSE para que el test pase.
            }

            Mensaje = "Fake: Cliente editado.";
            return true;
        }

        public bool EliminarCliente(Cliente obj, out string Mensaje) { Mensaje = "Fake: Cliente eliminado."; return true; }
    }
}