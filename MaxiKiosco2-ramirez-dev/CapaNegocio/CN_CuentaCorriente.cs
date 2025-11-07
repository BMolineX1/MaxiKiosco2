using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;

namespace CapaNegocio
{
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

        /* NUEVO: para llenar el grid izquierdo */
        public DataTable ListarCuentas()
            => _cd.ListarCuentas();
    }
}
