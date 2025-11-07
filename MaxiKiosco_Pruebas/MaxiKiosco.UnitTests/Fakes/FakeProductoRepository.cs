using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaEntidad;
using CapaEntidad.Interfaces;

namespace MaxiKiosco.UnitTests.Fakes
{
    public class FakeProductoRepository : IProductoRepository
    {
        private List<Producto> _productos = new List<Producto>()
        {
            // Producto 1: Activo, Stock OK, Código Externo
            new Producto() { id_producto = 1, codigo = "111101101", nombre = "Coca-cola", stock = 10, p_compra = 2000.10m, p_venta = 3000.00m, oCategoria = new Categoria() { nombre_categoria = "Bebidas" }, estado = true },
            // Producto 2: Inactivo, Stock Cero, Código Interno
            new Producto() { id_producto = 2, codigo = "INT-10", nombre = "Bolsa de Pan", stock = 0, p_compra = 100.00m, p_venta = 150.00m, oCategoria = new Categoria() { nombre_categoria = "Panificados" }, estado = false }, 
            // Producto 3: Activo, Stock Bajo, Precio Cero (Para test de error)
            new Producto() { id_producto = 3, codigo = "INT-11", nombre = "Alfajor", stock = 2, p_compra = 0.00m, p_venta = 10.00m, oCategoria = new Categoria() { nombre_categoria = "Golosinas" }, estado = true }
        };

        public List<Producto> Listar() => _productos;

        // Simula la obtención de un ID o 0 si falla la validación
        public int Registrar(Producto obj, out string Mensaje)
        {
            Mensaje = "Fake: Producto registrado.";
            // Simula un ID devuelto
            return 4;
        }

        // Simula la edición exitosa o no
        public bool Editar(Producto obj, out string Mensaje)
        {
            Mensaje = "Fake: Producto editado.";
            // Simula falla si intentamos editar un producto inexistente
            if (obj.id_producto == 999) return false;
            return true;
        }

        // Simula la eliminación exitosa
        public bool Eliminar(Producto obj, out string Mensaje)
        {
            Mensaje = "Fake: Producto eliminado.";
            return true;
        }

        // Simula el código de GenerarCodigoInternoUnico() de la CD
        public string GenerarCodigoInternoUnico()
        {
            // El último código en el fake es "INT-11", por lo que el siguiente es "INT-12".
            return "INT-12";
        }
    }
}