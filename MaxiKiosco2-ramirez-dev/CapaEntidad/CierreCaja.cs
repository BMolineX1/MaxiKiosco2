using System;

namespace CapaEntidad
{
    public class CierreCaja
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int EmpleadoId { get; set; }
        public decimal TotalVentas { get; set; }
        public decimal VentasEfectivo { get; set; }
        public decimal VentasTarjeta { get; set; }
        public decimal VentasCtaCte { get; set; }
        public decimal RetirosTotal { get; set; }
        public decimal SaldoReal { get; set; }
        public decimal Diferencia { get; set; }
        public string Observaciones { get; set; }
    }
}
