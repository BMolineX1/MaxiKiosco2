// CapaEntidad/CuentaCorrienteCliente.cs
namespace CapaEntidad
{
    public class CuentaCorrienteCliente
    {
        public int ClienteId { get; set; }
        public decimal Saldo { get; set; }
        public decimal LimiteCredito { get; set; }
        public bool Habilitada { get; set; }
    }
}

// CapaEntidad/CCMovimiento.cs
namespace CapaEntidad
{
    public class CCMovimiento
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public DateTime FechaHora { get; set; }
        public string Tipo { get; set; }      // 'DEBITO' | 'CREDITO'
        public string Concepto { get; set; }
        public int? VentaId { get; set; }
        public decimal Monto { get; set; }
        public int UsuarioId { get; set; }
    }
}