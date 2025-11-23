using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class ReporteCompra
    {
        public DateTime FechaRegistro { get; set; }
        public string FechaFormateada => FechaRegistro.ToString("dd/MM/yyyy HH:mm:ss");

        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }

        // NUEVO: lo devuelve c.montototal en el SP
        public decimal MontoTotal { get; set; }

        public string UsuarioRegistro { get; set; }
        public string DocumentoProveedor { get; set; }
        public string RazonSocial { get; set; }

        public string CodigoProducto { get; set; }
        public string NombreProducto { get; set; }
        public string Categoria { get; set; }

        // Renombrado para que matchee con la columna de la grilla
        public decimal PrecioCompra { get; set; }
        public decimal PrecioVenta { get; set; }
        public decimal Cantidad { get; set; }
        public decimal SubTotal { get; set; }
    }
}
