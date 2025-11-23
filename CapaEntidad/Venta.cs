using CapaEntidad;

public class Venta
{
    public int VentaId { get; set; }          // PK
    public int EmpleadoId { get; set; }       // FK empleado
    public int ClienteId { get; set; }        // FK cliente (nuevo agregado)

    public string TipoDocumento { get; set; }
    public string NumeroDocumento { get; set; }

    public decimal MontoTotal { get; set; }
    public decimal MontoPago { get; set; }
    public decimal MontoCambio { get; set; }

    public string NombreCliente { get; set; }    // snapshot/join
    public string DocumentoCliente { get; set; } // snapshot/join
    public DateTime? FechaRegistro { get; set; } // nullable

    public Cliente oCliente { get; set; } = new Cliente();
    public Usuario oEmpleado { get; set; } = new Usuario();

    public List<detalle_venta> oDetalle_Venta { get; set; } = new List<detalle_venta>();

    public int Id { get; set; }
}