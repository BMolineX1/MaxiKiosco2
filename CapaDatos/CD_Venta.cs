using CapaEntidad;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Data;
using System.Globalization;
using System.Linq;

namespace CapaDatos
{
    public class CD_Venta
    {
        public int ObtenerCorrelativo()
        {
            int correlativo = 0;
            using (var cn = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    const string sql = "SELECT COUNT(*) + 1 FROM venta";
                    using (var cmd = new MySqlCommand(sql, cn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cn.Open();
                        correlativo = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                catch
                {
                    correlativo = 0;
                }
            }
            return correlativo;
        }

        // Disponibles para otros usos, no se usan en frmVentas actual
        public bool RestarStock(int idproducto, int cantidad, out string error)
        {
            error = string.Empty;

            using (var cn = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    cn.Open();

                    using (var check = new MySqlCommand(
                        "SELECT stock FROM producto WHERE id = @id", cn))
                    {
                        check.Parameters.AddWithValue("@id", idproducto);
                        object o = check.ExecuteScalar();
                        if (o == null)
                        {
                            error = $"No existe producto id={idproducto}.";
                            return false;
                        }

                        int stockActual = Convert.ToInt32(o);
                        if (stockActual < cantidad)
                        {
                            error = $"Stock insuficiente. Actual={stockActual}, solicitado={cantidad}.";
                            return false;
                        }
                    }

                    using (var cmd = new MySqlCommand(
                        @"UPDATE producto 
                          SET stock = stock - @cant 
                          WHERE id = @id AND stock >= @cant;", cn))
                    {
                        cmd.Parameters.AddWithValue("@cant", cantidad);
                        cmd.Parameters.AddWithValue("@id", idproducto);

                        int rows = cmd.ExecuteNonQuery();
                        if (rows == 0)
                        {
                            error = "No se afectó ninguna fila.";
                            return false;
                        }
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    error = ex.Message;
                    return false;
                }
            }
        }

        public bool SumarStock(int idproducto, int cantidad, out string error)
        {
            error = string.Empty;

            using (var cn = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    cn.Open();

                    using (var cmd = new MySqlCommand(
                        @"UPDATE producto 
                          SET stock = stock + @cant 
                          WHERE id = @id;", cn))
                    {
                        cmd.Parameters.AddWithValue("@cant", cantidad);
                        cmd.Parameters.AddWithValue("@id", idproducto);

                        int rows = cmd.ExecuteNonQuery();
                        if (rows == 0)
                        {
                            error = $"No existe producto id={idproducto}.";
                            return false;
                        }
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    error = ex.Message;
                    return false;
                }
            }
        }

        /// <summary>
        /// Alineado a tu SP_RegistrarVenta:
        /// (IN p_IdUsuario, IN p_TipoDocumento, IN p_NumeroDocumento, IN p_NombreCliente, IN p_MontoPago, IN p_DetalleVenta JSON, OUT resultado, OUT mensaje)
        /// </summary>
        public bool Registrar(Venta obj, DataTable detalleVenta, out string mensaje)
        {
            mensaje = string.Empty;

            // Serializar a JSON con punto decimal (invariant)
            var items = detalleVenta.AsEnumerable().Select(r => new
            {
                producto_id = Convert.ToInt32(r["producto_id"]),
                cantidad = Convert.ToInt32(r["cantidad"]),
                // Asegurar decimales con invariant
                precio_unitario = Convert.ToDecimal(r["precio_unitario"], CultureInfo.InvariantCulture)
            }).ToArray();

            // Configuración de serialización para usar punto decimal
            var jsonSettings = new JsonSerializerSettings
            {
                Culture = CultureInfo.InvariantCulture,
                FloatFormatHandling = FloatFormatHandling.String // opcional
            };
            string jsonDetalle = JsonConvert.SerializeObject(items, jsonSettings);

            using (var cn = new MySqlConnection(Conexion.cadena))
            using (var cmd = new MySqlCommand("SP_RegistrarVenta", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 60;

                // === NOMBRES EXACTOS SEGÚN TU SP ===
                cmd.Parameters.AddWithValue("p_IdUsuario", obj.EmpleadoId);
                cmd.Parameters.AddWithValue("p_TipoDocumento", obj.TipoDocumento ?? "");
                cmd.Parameters.AddWithValue("p_NumeroDocumento", obj.NumeroDocumento ?? "");
                cmd.Parameters.AddWithValue("p_NombreCliente", obj.NombreCliente ?? "");
                cmd.Parameters.AddWithValue("p_MontoPago", obj.MontoPago);

                var pJson = new MySqlParameter("p_DetalleVenta", MySqlDbType.JSON) { Value = jsonDetalle };
                cmd.Parameters.Add(pJson);

                var pRes = new MySqlParameter("resultado", MySqlDbType.Byte) { Direction = ParameterDirection.Output };
                var pMsg = new MySqlParameter("mensaje", MySqlDbType.VarChar, 250) { Direction = ParameterDirection.Output };
                cmd.Parameters.Add(pRes);
                cmd.Parameters.Add(pMsg);

                try
                {
                    cn.Open();
                    cmd.ExecuteNonQuery();

                    bool ok = Convert.ToInt32(pRes.Value) == 1;
                    mensaje = pMsg.Value?.ToString() ?? string.Empty;
                    return ok;
                }
                catch (Exception ex)
                {
                    mensaje = "Error al registrar la venta: " + ex.Message;
                    return false;
                }
            }
        }
    }
}
