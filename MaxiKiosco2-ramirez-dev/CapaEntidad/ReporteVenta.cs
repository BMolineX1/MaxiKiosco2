using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class ReporteVenta
    {
        public DateTime FechaRegistro { get; set; }          // Fecha real para lógica
        public string FechaFormateada => FechaRegistro.ToString("dd/MM/yyyy HH:mm:ss");
        public string NumeroDocumento { get; set; }
        public string TipoDocumento { get; set; }
        public string DocumentoCliente { get; set; }         // DNI como string
        public string NombreCliente { get; set; }
        public string UsuarioRegistro { get; set; }
        public string CodigoProducto { get; set; }
        public string NombreProducto { get; set; }
        public string Categoria { get; set; }
        public decimal PrecioVenta { get; set; }             // decimal, no string
        public decimal Cantidad { get; set; }                // decimal si aplica
        public decimal SubTotal { get; set; }   
        public decimal MontoTotal { get; set; }// decimal
    }
}
