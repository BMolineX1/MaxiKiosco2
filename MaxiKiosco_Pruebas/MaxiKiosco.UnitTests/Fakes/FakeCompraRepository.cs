using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaEntidad;
using CapaEntidad.Interfaces;

namespace MaxiKiosco.UnitTests.Fakes
{
    public class FakeCompraRepository : ICompraRepository
    {
        public int ObtenerCorrelativo() => 10;

        // 1. REGISTRAR: Simula un registro exitoso o un fallo de BD (no de negocio/CN)
        public bool Registrar(Compra obj, DataTable DetalleCompra, out List<string> errores, out string mensaje)
        {
            errores = new List<string>();
            mensaje = "Fake: Compra registrada con éxito y stock actualizado.";

            // Simulación de fallo de BD (ej. el documento ya existe o problema de Stock/ID)
            if (obj.numerodocumento == "9999-999999")
            {
                mensaje = "Error de BD: El documento ya existe en la base de datos.";
                return false;
            }

            return true; // Éxito
        }

        // 2. OBTENER COMPRA: Se mantiene con out string mensaje
        public Compra ObtenerCompra(string numero, out string mensaje)
        {
            mensaje = string.Empty;
            if (numero == "0001-000005")
                return new Compra() { id = 5, numerodocumento = "0001-000005" };
            return null;
        }

        // 3. OBTENER DETALLE: ¡CORREGIDO! Ya NO usa out string mensaje
        public List<detalle_compra> ObtenerDetalleCompra(int idCompra)
        {
            // La lógica interna ya no necesita manejar el out string mensaje
            if (idCompra == 5)
            {
                return new List<detalle_compra>()
        {
            new detalle_compra() { id = 1, nombreProducto = "Azúcar", cantidad = 10 }
        };
            }
            return new List<detalle_compra>();
        }
    }
}