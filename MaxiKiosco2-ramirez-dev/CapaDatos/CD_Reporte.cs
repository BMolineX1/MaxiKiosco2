using CapaEntidad;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;

namespace CapaDatos
{
    public class CD_Reporte
    {
        /* =========================
           Helpers seguros de lectura
           ========================= */
        private static bool HasColumn(IDataRecord r, string name)
        {
            for (int i = 0; i < r.FieldCount; i++)
                if (string.Equals(r.GetName(i), name, StringComparison.OrdinalIgnoreCase))
                    return true;
            return false;
        }

        private static int OrdinalOf(IDataRecord r, params string[] candidates)
        {
            foreach (var c in candidates)
            {
                for (int i = 0; i < r.FieldCount; i++)
                    if (string.Equals(r.GetName(i), c, StringComparison.OrdinalIgnoreCase))
                        return i;
            }
            return -1;
        }

        private static DateTime GetDateTimeOr(IDataRecord r, DateTime fallback, params string[] names)
        {
            int i = OrdinalOf(r, names);
            if (i < 0 || r.IsDBNull(i)) return fallback;

            // Si el tipo ya es DateTime:
            if (r.GetFieldType(i) == typeof(DateTime))
                return r.GetDateTime(i);

            // Si vino como string/objeto, intentar parsear:
            var s = Convert.ToString(r.GetValue(i));
            return DateTime.TryParse(s, out var dt) ? dt : fallback;
        }

        private static string GetStringOr(IDataRecord r, string fallback, params string[] names)
        {
            int i = OrdinalOf(r, names);
            if (i < 0 || r.IsDBNull(i)) return fallback;
            return Convert.ToString(r.GetValue(i)) ?? fallback;
        }

        private static decimal GetDecimalOr(IDataRecord r, decimal fallback, params string[] names)
        {
            int i = OrdinalOf(r, names);
            if (i < 0 || r.IsDBNull(i)) return fallback;

            try
            {
                var val = r.GetValue(i);
                if (val is decimal d) return d;
                if (val is double db) return (decimal)db;
                if (val is float f) return (decimal)f;
                if (val is long l) return l;
                if (val is int ii) return ii;
                if (val is string s && decimal.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out var dec)) return dec;
                if (val is string s2 && decimal.TryParse(s2, NumberStyles.Any, CultureInfo.CurrentCulture, out dec)) return dec;
                return Convert.ToDecimal(val, CultureInfo.InvariantCulture);
            }
            catch { return fallback; }
        }

        /* =========================
           COMPRAS
           ========================= */
        public List<ReporteCompra> Compra(string fechainicio, string fechafin, int idproveedor)
        {
            var lista = new List<ReporteCompra>();

            using (var conexion = new MySqlConnection(Conexion.cadena))
            {
                DateTime inicio = DateTime.ParseExact(fechainicio, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                DateTime fin = DateTime.ParseExact(fechafin, "yyyy-MM-dd", CultureInfo.InvariantCulture);

                using (var cmd = new MySqlCommand("SP_ReporteCompras", conexion))
                {
                    // Podés usar StoredProcedure (recomendado) en vez de "CALL ...":
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("p_fechainicio", MySqlDbType.Date).Value = inicio.Date;
                    cmd.Parameters.Add("p_fechafin", MySqlDbType.Date).Value = fin.Date;

                    var pProv = cmd.Parameters.Add("p_idproveedor", MySqlDbType.Int32);
                    pProv.Value = (idproveedor == 0) ? (object)DBNull.Value : idproveedor;

                    conexion.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var item = new ReporteCompra
                            {
                                // Alias tolerados: "fecharegistro", "FechaRegistro", "fecha_registro", "fecha"
                                FechaRegistro = GetDateTimeOr(reader, DateTime.MinValue, "fecharegistro", "FechaRegistro", "fecha_registro", "fecha"),

                                // Campos texto con alias habituales
                                TipoDocumento = GetStringOr(reader, "", "tipodocumento", "TipoDocumento", "tipo_documento"),
                                NumeroDocumento = GetStringOr(reader, "", "numerodocumento", "NumeroDocumento", "numero_documento"),

                                // Números
                                MontoTotal = GetDecimalOr(reader, 0m, "montototal", "MontoTotal", "monto_total"),

                                // Usuario que registró (según SP puede venir como nombrecompletousuario/usuario etc.)
                                UsuarioRegistro = GetStringOr(reader, "",
                                    "nombrecompletousuario", "NombreCompletoUsuario", "usuario", "usuario_registro"),

                                // Proveedor
                                DocumentoProveedor = GetStringOr(reader, "", "documentoproveedor", "DocumentoProveedor", "cuit", "doc_proveedor"),
                                RazonSocial = GetStringOr(reader, "", "razonsocial", "RazonSocial", "razon_social"),

                                // Producto
                                CodigoProducto = GetStringOr(reader, "", "codigoproduct", "CodigoProduct", "codigo_producto", "codigo"),
                                NombreProducto = GetStringOr(reader, "", "nombre", "Nombre", "producto"),
                                Categoria = GetStringOr(reader, "", "nombre_categoria", "categoria", "Categoria"),

                                // Precios y cantidades
                                PrecioCompra = GetDecimalOr(reader, 0m, "preciocompra", "PrecioCompra", "precio_compra"),
                                PrecioVenta = GetDecimalOr(reader, 0m, "precioventa", "PrecioVenta", "precio_venta"),
                                Cantidad = GetDecimalOr(reader, 0m, "cantidad", "Cantidad"),
                                SubTotal = GetDecimalOr(reader, 0m, "subtotal", "SubTotal", "sub_total")
                            };

                            lista.Add(item);
                        }
                    }
                }
            }

            return lista;
        }

        /* =========================
           VENTAS
           ========================= */
        public List<ReporteVenta> Venta(string fechainicio, string fechafin)
        {
            var lista = new List<ReporteVenta>();

            using (var conexion = new MySqlConnection(Conexion.cadena))
            {
                DateTime inicio = DateTime.ParseExact(fechainicio, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                DateTime fin = DateTime.ParseExact(fechafin, "yyyy-MM-dd", CultureInfo.InvariantCulture);

                using (var cmd = new MySqlCommand("SP_ReporteVentas", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("p_fechainicio", MySqlDbType.Date).Value = inicio.Date;
                    cmd.Parameters.Add("p_fechafin", MySqlDbType.Date).Value = fin.Date;

                    conexion.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var item = new ReporteVenta
                            {
                                // Fecha
                                FechaRegistro = GetDateTimeOr(reader, DateTime.MinValue, "fecharegistro", "FechaRegistro", "fecha_registro", "fecha"),

                                // Cabecera venta
                                TipoDocumento = GetStringOr(reader, "", "tipodocumento", "TipoDocumento", "tipo_documento"),
                                NumeroDocumento = GetStringOr(reader, "", "numerodocumento", "NumeroDocumento", "numero_documento"),
                                MontoTotal = GetDecimalOr(reader, 0m, "montototal", "MontoTotal", "monto_total"),

                                // Usuario
                                UsuarioRegistro = GetStringOr(reader, "",
                                    "nombrecompletousuario", "NombreCompletoUsuario", "usuario", "usuario_registro"),

                                // Cliente
                                DocumentoCliente = GetStringOr(reader, "", "documentocliente", "DocumentoCliente", "dni", "doc_cliente"),
                                NombreCliente = GetStringOr(reader, "", "nombrecompletocliente", "NombreCompletoCliente", "cliente"),

                                // Producto
                                CodigoProducto = GetStringOr(reader, "", "codigoproduct", "CodigoProduct", "codigo_producto", "codigo"),
                                NombreProducto = GetStringOr(reader, "", "nombre", "Nombre", "producto"),
                                Categoria = GetStringOr(reader, "", "nombre_categoria", "categoria", "Categoria"),

                                // Detalle (si el SP los devuelve)
                                PrecioVenta = GetDecimalOr(reader, 0m, "precioventa", "PrecioVenta", "precio_venta"),
                                Cantidad = GetDecimalOr(reader, 0m, "cantidad", "Cantidad"),
                                SubTotal = GetDecimalOr(reader, 0m, "subtotal", "SubTotal", "sub_total")
                            };

                            lista.Add(item);
                        }
                    }
                }
            }

            return lista;
        }
    }
}
