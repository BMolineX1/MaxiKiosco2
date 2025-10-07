using System;
using System.Data;
using System.Globalization;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Venta
    {
        private readonly CD_Venta _datos = new CD_Venta();

        public int ObtenerCorrelativo()
        {
            return _datos.ObtenerCorrelativo();
        }

        // Métodos de stock quedan disponibles por si los usás en otros flujos,
        // pero en este formulario NO se llaman.
        public bool RestarStock(int idproducto, int cantidad, out string mensaje)
        {
            return _datos.RestarStock(idproducto, cantidad, out mensaje);
        }
        public bool SumarStock(int idproducto, int cantidad, out string mensaje)
        {
            return _datos.SumarStock(idproducto, cantidad, out mensaje);
        }

        public string GenerarNumeroDocumento(string serie = "0001")
        {
            int corr = ObtenerCorrelativo();
            return $"{(string.IsNullOrWhiteSpace(serie) ? "0001" : serie)}-{corr.ToString("00000000", CultureInfo.InvariantCulture)}";
        }

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

        /// <summary>
        /// Alineado al SP_RegistrarVenta(p_IdUsuario, p_TipoDocumento, p_NumeroDocumento, p_NombreCliente, p_MontoPago, p_DetalleVenta, OUT ...)
        /// </summary>
        public bool Registrar(Venta venta, DataTable detalle, out string mensaje)
        {
            mensaje = string.Empty;

            if (venta == null)
            {
                mensaje = "La venta no puede ser nula.";
                return false;
            }

            try
            {
                if (venta.EmpleadoId <= 0)
                    throw new ArgumentException("Id de usuario inválido.");
                if (string.IsNullOrWhiteSpace(venta.TipoDocumento))
                    throw new ArgumentException("Tipo de documento requerido.");
                if (string.IsNullOrWhiteSpace(venta.NumeroDocumento))
                    throw new ArgumentException("Número de documento requerido.");
                if (venta.MontoPago < 0)
                    throw new ArgumentException("El monto de pago no puede ser negativo.");

                // NombreCliente puede ser vacío según tu negocio; lo normal es enviar algo.
                venta.NombreCliente ??= "";

                ValidarDetalle(detalle);

                // Delego a CapaDatos (SP_RegistrarVenta alineado)
                return _datos.Registrar(venta, detalle, out mensaje);
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                return false;
            }
        }
    }
}
