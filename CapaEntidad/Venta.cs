using System;

namespace CapaEntidad
{
    public class Venta
    {
        public int EmpleadoId { get; set; }              // p_IdUsuario
        public string TipoDocumento { get; set; }        // p_TipoDocumento
        public string NumeroDocumento { get; set; }      // p_NumeroDocumento
        public string NombreCliente { get; set; }        // p_NombreCliente
        public decimal MontoPago { get; set; }           // p_MontoPago

        // (opcionales según tu uso)
        public DateTime? FechaRegistro { get; set; }
        public decimal? MontoTotal { get; set; }
        public decimal? MontoCambio { get; set; }
    }
}
