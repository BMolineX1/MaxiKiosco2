using System;
using System.Data;
using System.Globalization;
using System.Collections.Generic;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Venta
    {
        private readonly CD_Venta _datos = new CD_Venta();

        // === Constantes de medios (alineadas con tu ENUM/BD) ===
        public const string MEDIO_EFECTIVO = "Efectivo";
        public const string MEDIO_TARJETA_CREDITO = "Credito";
        public const string MEDIO_TARJETA_DEBITO = "Debito";
        public const string MEDIO_TRANSFERENCIA = "Transferencia";
        public const string MEDIO_CUENTA_CORRIENTE = "CuentaCorriente";

        // === Utilidades ===
        public int ObtenerCorrelativo() => _datos.ObtenerCorrelativo();

        public bool RestarStock(int idproducto, int cantidad, out string mensaje)
            => _datos.RestarStock(idproducto, cantidad, out mensaje);

        public bool SumarStock(int idproducto, int cantidad, out string mensaje)
            => _datos.SumarStock(idproducto, cantidad, out mensaje);

        public string GenerarNumeroDocumento(string serie = "0001")
        {
            int corr = ObtenerCorrelativo();
            return $"{(string.IsNullOrWhiteSpace(serie) ? "0001" : serie)}-{corr.ToString("00000000", CultureInfo.InvariantCulture)}";
        }

        /// <summary>DataTable detalle con columnas: producto_id(int), cantidad(int), precio_unitario(decimal)</summary>
        public DataTable CrearDetalleSchema()
        {
            var dt = new DataTable();
            dt.Columns.Add("producto_id", typeof(int));
            dt.Columns.Add("cantidad", typeof(int));
            dt.Columns.Add("precio_unitario", typeof(decimal));
            return dt;
        }

        private void ValidarDetalle(DataTable detalle)
        {
            if (detalle == null || detalle.Rows.Count == 0)
                throw new ArgumentException("El detalle de la venta está vacío.");

            string[] req = { "producto_id", "cantidad", "precio_unitario" };
            foreach (var c in req)
                if (!detalle.Columns.Contains(c))
                    throw new ArgumentException($"Falta la columna requerida '{c}' en el detalle.");

            foreach (DataRow r in detalle.Rows)
            {
                int prod = Convert.ToInt32(r["producto_id"]);
                int cant = Convert.ToInt32(r["cantidad"]);
                decimal pu = Convert.ToDecimal(r["precio_unitario"], CultureInfo.InvariantCulture);

                if (prod <= 0) throw new ArgumentException("Hay un producto_id inválido (<= 0).");
                if (cant <= 0) throw new ArgumentException("Todas las cantidades deben ser > 0.");
                if (pu <= 0) throw new ArgumentException("Todos los precios unitarios deben ser > 0.");
            }
        }
        public List<Venta> ListarCabeceras(int max = 300)
        {
            return _datos.ListarCabeceras(max);
        }
        public decimal CalcularSubTotal(DataTable detalle)
        {
            ValidarDetalle(detalle);
            decimal total = 0m;
            foreach (DataRow r in detalle.Rows)
            {
                int cant = Convert.ToInt32(r["cantidad"]);
                decimal pu = Convert.ToDecimal(r["precio_unitario"], CultureInfo.InvariantCulture);
                total += cant * pu;
            }
            return total;
        }

        // ========= Registro de venta =========

        /// <summary>
        /// Registrar venta contra SP nuevo (con medio de pago).
        /// medioPago: "Efectivo","Debito","Credito","Transferencia","CuentaCorriente".
        /// </summary>
        public bool Registrar(Venta venta, DataTable detalle, string medioPago, out string mensaje)
        {
            mensaje = string.Empty;

            if (venta == null) { mensaje = "La venta no puede ser nula."; return false; }

            try
            {
                if (venta.EmpleadoId <= 0) throw new ArgumentException("Id de usuario inválido.");
                if (string.IsNullOrWhiteSpace(venta.TipoDocumento)) throw new ArgumentException("Tipo de documento requerido.");
                if (string.IsNullOrWhiteSpace(venta.NumeroDocumento)) throw new ArgumentException("Número de documento requerido.");
                if (venta.MontoPago < 0) throw new ArgumentException("El monto de pago no puede ser negativo.");
                if (string.IsNullOrWhiteSpace(medioPago)) throw new ArgumentException("Medio de pago requerido.");

                venta.NombreCliente ??= "";
                ValidarDetalle(detalle);

                // Llama a CD_Venta.Registrar(venta, detalle, medioPago, out mensaje)
                return _datos.Registrar(venta, detalle, medioPago, out mensaje);
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Overload legacy SIN medioPago (compatibilidad). Usa Efectivo por defecto.
        /// </summary>
        public bool Registrar(Venta venta, DataTable detalle, out string mensaje)
        {
            return Registrar(venta, detalle, MEDIO_EFECTIVO, out mensaje);
        }

        /// <summary>
        /// Registra la venta y devuelve el ID generado buscando por NumeroDocumento.
        /// </summary>
        public int RegistrarVenta(Venta venta, DataTable detalle, decimal totalPagar, string medioPago, out string mensaje)
        {
            // (opcional) venta.MontoTotal = totalPagar;

            bool ok = this.Registrar(venta, detalle, medioPago, out string msg);
            if (!ok)
            {
                mensaje = msg;
                return 0;
            }

            // Recuperar el ID real
            var v = this.ObtenerVenta(venta.NumeroDocumento);
            if (v == null || v.VentaId == 0)
            {
                mensaje = "Venta registrada, pero no se pudo recuperar el ID.";
                return 0;
            }

            mensaje = "OK";
            return v.VentaId;
        }

        // ========= Consultas =========
        public Venta ObtenerVenta(string numero)
        {
            Venta oVenta = _datos.ObtenerVenta(numero);
            if (oVenta.VentaId != 0)
            {
                List<detalle_venta> oDetalleVenta = _datos.ObtenerDetalleVenta(oVenta.VentaId);
                oVenta.oDetalle_Venta = oDetalleVenta;
            }
            return oVenta;
        }

        public List<detalle_venta> ObtenerDetalleVenta(int idventa)
            => _datos.ObtenerDetalleVenta(idventa);

        // ========= Medio de pago (tabla venta_mediopago) =========
        public bool RegistrarMedioPago(int ventaId, string medio, decimal monto, out string mensaje)
            => _datos.RegistrarMedioPago(ventaId, medio, monto, out mensaje);
    }
}
