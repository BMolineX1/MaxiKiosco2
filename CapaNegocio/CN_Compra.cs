// CapaNegocio/CN_Compra.cs
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Compra
    {
        private readonly CD_Compra _data = new CD_Compra();

        // Regex aceptados para numerodocumento
        // 1) AR clásico: 0001-00000001
        private static readonly Regex RxNumDocGuion = new Regex(@"^\d{4}-\d{8}$", RegexOptions.Compiled);
        // 2) Variante con espacio: 000000 000000
        private static readonly Regex RxNumDocEspacio = new Regex(@"^\d{6}\s\d{6}$", RegexOptions.Compiled);

        /// <summary>
        /// Registra una compra con validaciones de negocio.
        /// </summary>
        /// <param name="compra">Entidad con datos mínimos: empleadoid, proveedorid, tipodocumento, numerodocumento.</param>
        /// <param name="detalle">DataTable con columnas: producto_id (int), preciocompra (decimal), precioventa (decimal), cantidad (int).</param>
        /// <param name="errores">Lista de errores de validación (si los hay).</param>
        /// <param name="mensaje">Mensaje devuelto por la capa de datos / SP.</param>
        public bool Registrar(Compra compra, DataTable detalle, out List<string> errores, out string mensaje)
        {
            errores = new List<string>();
            mensaje = string.Empty;

            // -------- Validaciones de cabecera --------
            if (compra == null)
            {
                errores.Add("La compra no puede ser nula.");
                return Fallo(out mensaje, "Datos de compra inválidos.");
            }

            if (compra.empleadoid <= 0)
                errores.Add("Empleado inválido.");

            if (compra.proveedorid <= 0)
                errores.Add("Proveedor inválido.");

            if (string.IsNullOrWhiteSpace(compra.tipodocumento))
                errores.Add("Tipo de documento es obligatorio.");

            if (string.IsNullOrWhiteSpace(compra.numerodocumento))
            {
                errores.Add("Número de documento es obligatorio.");
            }
            else
            {
                // Aceptá uno u otro formato. Si usás solo uno, dejá un único regex.
                bool okFormato = RxNumDocGuion.IsMatch(compra.numerodocumento)
                                 || RxNumDocEspacio.IsMatch(compra.numerodocumento);

                if (!okFormato)
                    errores.Add("Número de documento con formato inválido. Ej: 0001-00000001 o 000000 000000.");
            }

            // -------- Validaciones de detalle --------
            if (detalle == null)
            {
                errores.Add("El detalle no puede ser nulo.");
            }
            else
            {
                // Columnas requeridas
                string[] requeridas = { "producto_id", "preciocompra", "precioventa", "cantidad" };
                foreach (var col in requeridas)
                    if (!detalle.Columns.Contains(col))
                        errores.Add($"Falta la columna '{col}' en el detalle.");

                // Filas
                if (detalle.Rows.Count == 0)
                    errores.Add("El detalle está vacío.");

                // Validar cada ítem
                if (errores.Count == 0) // solo si están las columnas
                {
                    int idx = 0;
                    foreach (DataRow r in detalle.Rows)
                    {
                        idx++;

                        if (!TryInt(r["producto_id"], out int prod) || prod <= 0)
                            errores.Add($"Fila {idx}: producto_id inválido.");

                        if (!TryInt(r["cantidad"], out int cant) || cant <= 0)
                            errores.Add($"Fila {idx}: cantidad debe ser > 0.");

                        if (!TryDecimal(r["preciocompra"], out decimal pc) || pc < 0)
                            errores.Add($"Fila {idx}: preciocompra debe ser >= 0.");

                        if (!TryDecimal(r["precioventa"], out decimal pv) || pv < 0)
                            errores.Add($"Fila {idx}: precioventa debe ser >= 0.");
                    }
                }
            }

            if (errores.Count > 0)
                return Fallo(out mensaje, string.Join(" | ", errores));

            // -------- Delegar a la capa de datos --------
            bool ok = _data.Registrar(compra, detalle, out mensaje);
            if (!ok && string.IsNullOrWhiteSpace(mensaje))
                mensaje = "No se pudo registrar la compra.";

            return ok;
        }

        /// <summary>Passthrough si seguís usando el correlativo de vista previa.</summary>
        public int ObtenerCorrelativo() => _data.ObtenerCorrelativo();

        // -------------- Helpers --------------
        private static bool TryInt(object val, out int result)
        {
            try { result = Convert.ToInt32(val); return true; }
            catch { result = 0; return false; }
        }

        private static bool TryDecimal(object val, out decimal result)
        {
            try { result = Convert.ToDecimal(val); return true; }
            catch { result = 0m; return false; }
        }

        private static bool Fallo(out string mensaje, string msg)
        {
            mensaje = msg;
            return false;
        }
        /// <summary>
        /// Obtiene la compra por número de documento con validaciones de negocio.
        /// Acepta formatos: 0001-00000001 o 000000 000000
        /// </summary>
        public Compra ObtenerCompra(string numero, out string mensaje)
        {
            mensaje = string.Empty;

            // Validación básica
            if (string.IsNullOrWhiteSpace(numero))
            {
                mensaje = "El número de documento es obligatorio.";
                return null;
            }

            // Validación de formato (reutiliza los Regex ya definidos en la clase)
            bool okFormato = RxNumDocGuion.IsMatch(numero) || RxNumDocEspacio.IsMatch(numero);
            if (!okFormato)
            {
                mensaje = "Número de documento con formato inválido. Ej: 0001-00000001 o 000000 000000.";
                return null;
            }

            try
            {
                // Delegamos a la capa de datos
                var compra = _data.ObtenerCompra(numero);

                if (compra == null)
                    mensaje = "No se encontró la compra para el número indicado.";

                return compra;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                mensaje = $"[MySQL] {ex.Number} - {ex.Message}";
                return null;
            }
            catch (Exception ex)
            {
                mensaje = $"[Error] {ex.Message}";
                return null;
            }
        }

        /// <summary>
        /// Lista el detalle de una compra por su ID con validaciones y manejo de errores.
        /// </summary>
        public List<detalle_compra> ObtenerDetalleCompra(int idcompra, out string mensaje)
        {
            mensaje = string.Empty;
            var lista = new List<detalle_compra>();

            // Validación de entrada
            if (idcompra <= 0)
            {
                mensaje = "El id de compra debe ser mayor a cero.";
                return lista;
            }

            try
            {
                lista = _data.ObtenerDetalleCompra(idcompra) ?? new List<detalle_compra>();

                if (lista.Count == 0)
                    mensaje = "La compra no tiene ítems de detalle o no existe.";

                return lista;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                mensaje = $"[MySQL] {ex.Number} - {ex.Message}";
                return new List<detalle_compra>();
            }
            catch (Exception ex)
            {
                mensaje = $"[Error] {ex.Message}";
                return new List<detalle_compra>();
            }
        }
    }
}
