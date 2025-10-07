using CapaEntidad;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CapaDatos
{
    public class CD_Compra
    {
        public int ObtenerCorrelativo()
        {
            int correlativo = 0;
            using (var cn = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    const string sql = "SELECT COUNT(*) + 1 FROM compra";
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

        public bool Registrar(Compra obj, DataTable detalleCompra, out string mensaje)
        {
            mensaje = string.Empty;

            // Serializar detalle a JSON (debe coincidir con lo que espera tu SP)
            var items = detalleCompra.AsEnumerable().Select(r => new
            {
                producto_id = Convert.ToInt32(r["producto_id"]),
                preciocompra = Convert.ToDecimal(r["preciocompra"]),
                precioventa = Convert.ToDecimal(r["precioventa"]),
                cantidad = Convert.ToInt32(r["cantidad"])
            }).ToArray();

            string jsonDetalle = JsonConvert.SerializeObject(items);

            using (var cn = new MySqlConnection(Conexion.cadena))
            using (var cmd = new MySqlCommand("SP_RegistrarCompra", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 60;

                // Usar los IDs directos de la entidad (evita NRE con ousuario/oproveedor)
                cmd.Parameters.AddWithValue("p_empleado_id", obj.empleadoid);
                cmd.Parameters.AddWithValue("p_proveedor_id", obj.proveedorid);
                cmd.Parameters.AddWithValue("p_tipodocumento", obj.tipodocumento);
                cmd.Parameters.AddWithValue("p_numerodocumento", obj.numerodocumento);

                // JSON (si tu server/conector no soporta JSON, usar LongText)
                var pJson = new MySqlParameter("p_detallecompra", MySqlDbType.JSON) { Value = jsonDetalle };
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
                    mensaje = "Error al registrar la compra: " + ex.Message;
                    return false;
                }
            }
        }

        public Compra ObtenerCompra(string numero)
        {
            Compra obj = null;

            try
            {
                using (var oconexion = new MySqlConnection(Conexion.cadena))
                {
                    const string query = @"
                        SELECT 
                            c.id_compra,
                            c.fecharegistro AS fecharegistro,
                            c.tipodocumento,
                            c.numerodocumento,
                            c.montototal,
                            u.nombre,
                            u.apellido,
                            pr.cuit,
                            pr.razonsocial
                        FROM compra c
                        INNER JOIN usuario   u  ON u.idusuario = c.empleado_id
                        INNER JOIN proveedor pr ON pr.id = c.proveedor_id
                        WHERE c.numerodocumento = @numero;
                    ";

                    using (var cmd = new MySqlCommand(query, oconexion))
                    {
                        cmd.Parameters.AddWithValue("@numero", numero);
                        cmd.CommandType = CommandType.Text;

                        oconexion.Open();

                        using (var dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                obj = new Compra
                                {
                                    id = dr.GetInt32(dr.GetOrdinal("id_compra")),
                                    fecharegistro = dr.GetDateTime(dr.GetOrdinal("fecharegistro")),
                                    montototal = dr.GetDecimal(dr.GetOrdinal("montototal")),
                                    tipodocumento = dr["tipodocumento"]?.ToString() ?? "",
                                    numerodocumento = dr["numerodocumento"]?.ToString() ?? "",
                                    ousuario = new Usuario
                                    {
                                        nombre = dr["nombre"]?.ToString() ?? "",
                                        apellido = dr["apellido"]?.ToString() ?? ""
                                    },
                                    oproveedor = new Proveedor
                                    {
                                        cuit = dr["cuit"]?.ToString() ?? "",
                                        razonsocial = dr["razonsocial"]?.ToString() ?? ""
                                    }
                                };
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"[MySQL Error] {ex.Number} - {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Error general] {ex.Message}");
            }

            return obj;
        }

        public List<detalle_compra> ObtenerDetalleCompra(int idcompra)
        {
            var oList = new List<detalle_compra>();

            try
            {
                using (var conexion = new MySqlConnection(Conexion.cadena))
                {
                    conexion.Open();

                    const string query = @"
                        SELECT 
                            dc.id,
                            dc.compra_id,
                            dc.producto_id,
                            p.nombre AS producto_nombre,
                            dc.cantidad,
                            dc.preciocompra,     -- precio unitario de compra
                            dc.montototal,
                            dc.precioventa,
                            dc.fecharegistro
                        FROM detalle_compra dc
                        INNER JOIN producto p ON p.id = dc.producto_id
                        WHERE dc.compra_id = @idcompra;
                    ";

                    using (var cmd = new MySqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@idcompra", idcompra);
                        cmd.CommandType = CommandType.Text;

                        using (var dr = cmd.ExecuteReader())
                        {
                            int i_id = dr.GetOrdinal("id");
                            int i_producto_id = dr.GetOrdinal("producto_id");
                            int i_producto_nombre = dr.GetOrdinal("producto_nombre");
                            int i_cantidad = dr.GetOrdinal("cantidad");
                            int i_preciocompra = dr.GetOrdinal("preciocompra");
                            int i_montototal = dr.GetOrdinal("montototal");
                            int i_precioventa = dr.GetOrdinal("precioventa");
                            int i_fecharegistro = dr.GetOrdinal("fecharegistro");

                            while (dr.Read())
                            {
                                var det = new detalle_compra
                                {
                                    id = dr.GetInt32(i_id),

                                    ocompra = new Compra { id = idcompra },

                                    oproducto = new Producto
                                    {
                                        Id = dr.GetInt32(i_producto_id),   // usa 'id' en minúscula
                                        nombre = dr.GetString(i_producto_nombre)
                                    },

                                    cantidad = dr.GetInt32(i_cantidad),
                                    precio_compra = dr.GetDecimal(i_preciocompra),
                                    montototal = dr.GetDecimal(i_montototal),

                                    // Estos pueden venir NULL: chequear
                                    precioventa = dr.IsDBNull(i_precioventa)
                                                        ? (decimal?)null
                                                        : dr.GetDecimal(i_precioventa),

                                    fecharegistro = dr.IsDBNull(i_fecharegistro)
                                                        ? (DateTime?)null
                                                        : dr.GetDateTime(i_fecharegistro)
                                };

                                oList.Add(det);
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"[MySQL Error {ex.Number}] {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Error] {ex.Message}");
            }

            return oList;
        }
    }
}
