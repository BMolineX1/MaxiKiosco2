using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;
using CapaEntidad;
using CapaEntidad.Interfaces;

namespace MaxiKiosco.UnitTests.Fakes //Necesario el .Fakes indica la carpeta 
{
    // Esta clase implementa el contrato, pero usa datos en memoria
    public class FakeUsuarioRepository : IUsuarioRepository
    {
        // ----------------------------------------------------
        // Implementación del método Listar() para el Test de Login
        // ----------------------------------------------------
        public List<Usuario> Listar()
        {
            // Devolvemos una lista de usuarios "quemados" (hardcodeados) para la prueba
            return new List<Usuario>()
            {
                new Usuario() { cuenta_usuario = "admin", contrasena = "12345", esAdmin = true },
                new Usuario() { cuenta_usuario = "user", contrasena = "pass", esAdmin = false },
                new Usuario() { cuenta_usuario = "inactivo", contrasena = "123", esAdmin = false }
            };
        }

        // ----------------------------------------------------
        // Implementación de otros métodos (necesarios para que compile el CN_Usuario)
        // ----------------------------------------------------
        public int Registrar(Usuario obj, out string Mensaje)
        {
            Mensaje = "Fake: Usuario registrado.";
            return 1; // Devolvemos un ID ficticio
        }

        public bool Editar(Usuario obj, out string Mensaje)
        {
            Mensaje = "Fake: Usuario editado.";
            return true;
        }

        public bool Eliminar(Usuario obj, out string Mensaje)
        {
            Mensaje = "Fake: Usuario eliminado.";
            return true;
        }
    }
}