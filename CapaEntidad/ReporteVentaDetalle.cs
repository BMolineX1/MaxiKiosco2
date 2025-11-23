using System;

namespace CapaEntidad
{
    public class ReporteVentaDetalle
    {
        public int VentaId { get; set; }
        public string NumeroDocumento { get; set; }
        public string TipoDocumento { get; set; }
        public DateTime Fecha { get; set; }

        public string ClienteDni { get; set; }
        public string ClienteNombre { get; set; }
        public string ClienteCondicionIva { get; set; }

        public int ProductoId { get; set; }
        public string ProductoCodigo { get; set; }
        public string ProductoNombre { get; set; }
        public string Categoria { get; set; }

        public decimal Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }
    }
}
