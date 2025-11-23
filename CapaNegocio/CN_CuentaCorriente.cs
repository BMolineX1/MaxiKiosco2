using CapaDatos;
using CapaEntidad;
using System.Data;

public class CN_CuentaCorriente
{
    private readonly CD_CuentaCorriente _cd = new CD_CuentaCorriente();

    public bool RegistrarVentaFiada(int clienteId, int ventaId, decimal monto, int usuarioId, out string mensaje)
        => _cd.RegistrarVentaFiada(clienteId, ventaId, monto, usuarioId, out mensaje);

    public bool RegistrarPago(int clienteId, decimal monto, int usuarioId, string concepto, out string mensaje)
        => _cd.RegistrarPago(clienteId, monto, usuarioId, concepto, out mensaje);

    public CuentaCorrienteCliente ObtenerEstado(int clienteId)
        => _cd.ObtenerEstado(clienteId);

    public List<CCMovimiento> ListarMovimientos(int clienteId, DateTime? desde, DateTime? hasta)
        => _cd.ListarMovimientos(clienteId, desde, hasta);

    public DataTable ListarCuentas()
        => _cd.ListarCuentas();

    public bool AumentarImpagosGlobal(decimal porcentaje, int? clienteId, out string msg)
        => _cd.AumentarImpagosGlobal(porcentaje, clienteId, out msg);

    public bool PagarPorItems(int clienteId, int ventaId, int productoId, int cantidad, int usuarioId, out string msg)
        => _cd.PagarPorItems(clienteId, ventaId, productoId, cantidad, usuarioId, out msg);

    public DataTable ListarPendientesConPrecio(int clienteId)
        => _cd.ListarPendientesConPrecio(clienteId);

    public bool PagarProducto(int idCliente, int idArticulo, int cantidad, int idUsuario, out string mensaje)
        => _cd.CCPagarProducto(idCliente, idArticulo, cantidad, idUsuario, out mensaje);

    // 🔹 ESTE ES EL IMPORTANTE PARA LA REVALUACIÓN
    public bool RevaluarPendientes(int clienteId, int usuarioId, out string mensaje)
    => _cd.RevaluarPendientes(clienteId, usuarioId, out mensaje);

}
