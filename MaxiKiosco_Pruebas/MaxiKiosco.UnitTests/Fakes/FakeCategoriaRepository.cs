using CapaEntidad;
using CapaEntidad.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MaxiKiosco.UnitTests.Fakes
{
    public class FakeCategoriaRepository : ICategoriaRepository
    {
        // Lista de datos para simular la base de datos
        private List<Categoria> _categorias = new List<Categoria>()
        {
            new Categoria() { id_categoria = 1, nombre_categoria = "Bebidas", estado = true, p_aumento = 10.00m },
            new Categoria() { id_categoria = 2, nombre_categoria = "Panificados", estado = false, p_aumento = 30.00m }, // Inactiva
            new Categoria() { id_categoria = 3, nombre_categoria = "Fiambreria", estado = true, p_aumento = 29.00m },
            new Categoria() { id_categoria = 4, nombre_categoria = "Lacteos", estado = false, p_aumento = 12.00m } // Inactiva
        };

        // ----------------------------------------------------
        // MÉTODOS DE LECTURA (Listar)
        // ----------------------------------------------------
        public List<Categoria> Listar()
        {
            // Simula traer TODAS las categorías (Activas e Inactivas)
            return _categorias;
        }

        public List<Categoria> ListarActivos()
        {
            // Simula el filtro para Combobox o vistas (ListarActivos es la que usamos en la CN)
            return _categorias.Where(c => c.estado == true).ToList();
        }

        // ----------------------------------------------------
        // MÉTODOS CRUD (Respuestas Ficticias)
        // ----------------------------------------------------
        public int Registrar(Categoria obj, out string Mensaje)
        {
            // Simula el éxito de la BD
            Mensaje = "Fake: Categoría registrada.";
            return _categorias.Max(c => c.id_categoria) + 1; // Devuelve un ID ficticio
        }

        public bool Editar(Categoria obj, out string Mensaje)
        {

            if (obj.p_aumento < 0)
            {
                Mensaje = "Fake: Error en BD. El porcentaje no puede ser negativo.";
                return false; // Simula que la Base de Datos o la CN falló.
            }

            Mensaje = "Fake: Categoría editada.";
            return true;
           
        }

        public bool Eliminar(Categoria obj, out string Mensaje)
        {
            // Asumimos que los IDs reales son menores a 100.
            if (obj.id_categoria > 100)
            {
                Mensaje = "Fake: Error en BD. No se encontró la categoría para eliminar.";
                return false; // Simula que la Base de Datos o la CN falló.
            }

            Mensaje = "Fake: Categoría eliminada.";
            return true;
        }


    }
}
