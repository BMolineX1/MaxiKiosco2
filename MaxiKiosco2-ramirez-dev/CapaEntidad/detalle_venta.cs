using CapaEntidad;

public class detalle_venta
{
    public int id { get; set; }                 // PK
    public int VentaId { get; set; }            // FK a Venta
    public int ProductoId { get; set; }         // FK a Producto
    public Venta oventa { get; set; }           // Relación con Venta
    public Producto oproducto { get; set; } = new Producto(); // Relación con Producto
    public int cantidad { get; set; }
    public decimal precio_unitario { get; set; }

    // Calculado, útil para UI
    public decimal subtotal => cantidad * precio_unitario;
}