// CapaNegocio/CN_Reporte.cs
using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace CapaNegocio
{
    public class CN_Reporte
    {
        private readonly IReporteRepository _reporteRepository;

        // Constructor por defecto (para la UI) => usa CD_Reporte real
        public CN_Reporte()
            : this(new CD_Reporte())
        {
        }

        // Constructor con inyección de dependencia (para tests)
        public CN_Reporte(IReporteRepository reporteRepository)
        {
            _reporteRepository = reporteRepository ?? throw new ArgumentNullException(nameof(reporteRepository));
        }

        /* =========================
           COMPRAS
           ========================= */

        // MANTENEMOS LA FIRMA QUE USA LA UI
        public List<ReporteCompra> Compra(string fechainicio, string fechafin, int idproveedor)
        {
            string _; // descartamos mensaje
            return Compra(fechainicio, fechafin, idproveedor, out _);
        }

        // NUEVA SOBRELOAD CON MENSAJE PARA TESTS
        public List<ReporteCompra> Compra(string fechainicio, string fechafin, int idproveedor, out string mensaje)
        {
            mensaje = string.Empty;
            var listaVacia = new List<ReporteCompra>();

            // 1) Validar que haya fechas
            if (string.IsNullOrWhiteSpace(fechainicio) || string.IsNullOrWhiteSpace(fechafin))
            {
                mensaje = "Las fechas de inicio y fin son obligatorias.";
                return listaVacia;
            }

            // 2) Validar formato de fecha (yyyy-MM-dd)
            if (!DateTime.TryParseExact(fechainicio, "yyyy-MM-dd", CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out DateTime fi) ||
                !DateTime.TryParseExact(fechafin, "yyyy-MM-dd", CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out DateTime ff))
            {
                mensaje = "El formato de fecha debe ser yyyy-MM-dd.";
                return listaVacia;
            }

            // 3) Validar rango lógico
            if (fi.Date > ff.Date)
            {
                mensaje = "La fecha de inicio no puede ser mayor que la fecha de fin.";
                return listaVacia;
            }

            // 4) Validar proveedor (0 = TODOS, <0 inválido)
            if (idproveedor < 0)
            {
                mensaje = "El proveedor seleccionado no es válido.";
                return listaVacia;
            }

            // 5) Llamar al repositorio
            var lista = _reporteRepository.Compra(fechainicio, fechafin, idproveedor) ?? new List<ReporteCompra>();

            // 6) Mensaje si no hay datos
            if (lista.Count == 0)
            {
                mensaje = "No se encontraron compras en el rango indicado.";
            }

            return lista;
        }

        /* =========================
           VENTAS
           ========================= */

        // MANTENEMOS LA FIRMA QUE USA LA UI
        public List<ReporteVenta> Venta(string fechainicio, string fechafin)
        {
            string _; // descartamos mensaje
            return Venta(fechainicio, fechafin, out _);
        }

        // NUEVA SOBRELOAD CON MENSAJE PARA TESTS
        public List<ReporteVenta> Venta(string fechainicio, string fechafin, out string mensaje)
        {
            mensaje = string.Empty;
            var listaVacia = new List<ReporteVenta>();

            // 1) Validar que haya fechas
            if (string.IsNullOrWhiteSpace(fechainicio) || string.IsNullOrWhiteSpace(fechafin))
            {
                mensaje = "Las fechas de inicio y fin son obligatorias.";
                return listaVacia;
            }

            // 2) Validar formato de fecha (yyyy-MM-dd)
            if (!DateTime.TryParseExact(fechainicio, "yyyy-MM-dd", CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out DateTime fi) ||
                !DateTime.TryParseExact(fechafin, "yyyy-MM-dd", CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out DateTime ff))
            {
                mensaje = "El formato de fecha debe ser yyyy-MM-dd.";
                return listaVacia;
            }

            // 3) Validar rango lógico
            if (fi.Date > ff.Date)
            {
                mensaje = "La fecha de inicio no puede ser mayor que la fecha de fin.";
                return listaVacia;
            }

            // 4) Llamar al repositorio
            var lista = _reporteRepository.Venta(fechainicio, fechafin) ?? new List<ReporteVenta>();

            // 5) Mensaje si no hay datos
            if (lista.Count == 0)
            {
                mensaje = "No se encontraron ventas en el rango indicado.";
            }

            return lista;
        }

        /* =========================
           DETALLE VENTA POR NÚMERO
           (no lo pediste, pero lo dejamos prolijo)
           ========================= */

        public List<ReporteVentaDetalle> DetalleVentaPorNumero(string numeroDocumento)
        {
            string _; // descartamos mensaje
            return DetalleVentaPorNumero(numeroDocumento, out _);
        }

        public List<ReporteVentaDetalle> DetalleVentaPorNumero(string numeroDocumento, out string mensaje)
        {
            mensaje = string.Empty;

            if (string.IsNullOrWhiteSpace(numeroDocumento))
            {
                mensaje = "El número de documento es obligatorio.";
                return new List<ReporteVentaDetalle>();
            }

            var lista = _reporteRepository.DetalleVentaPorNumero(numeroDocumento) ?? new List<ReporteVentaDetalle>();

            if (lista.Count == 0)
            {
                mensaje = "No se encontró detalle para el número de documento indicado.";
            }

            return lista;
        }
    }
}
