using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class EstadoCuenta
{
    public int ClienteId { get; set; }
    public decimal Saldo { get; set; }
    public decimal LimiteCredito { get; set; }
    public bool Habilitada { get; set; }
}

// CapaEntidad/MovimientoCuenta.cs
public class MovimientoCuenta
{
    public DateTime FechaHora { get; set; }
    public string Tipo { get; set; }        // "DEBITO" | "CREDITO"
    public string Concepto { get; set; }
    public int? VentaId { get; set; }
    public decimal Monto { get; set; }
}
