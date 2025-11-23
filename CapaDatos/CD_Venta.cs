using CapaEntidad;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Collections.Generic;

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
       
        public List<Venta> ListarCabeceras(int max = 300)
        {
            var lista = new List<Venta>();

            string sql = @"
                SELECT 
                    v.id                           AS venta_id,
                    v.tipodocumento,
                    v.numerodocumento,
                    v.fecharegistro,
                    v.montototal,
                    v.montopago,
                    v.montocambio,
                    c.id            AS cliente_id,
                    c.dni           AS cliente_dni,
                    c.nombre        AS cliente_nombre,
                    c.apellido      AS cliente_apellido,
                    u.idusuario     AS usuario_id,
                    u.nombre        AS usuario_nombre,
                    u.apellido      AS usuario_apellido
                FROM venta v
                LEFT JOIN cliente c  ON c.id = v.cliente_id
                INNER JOIN usuario u ON u.idusuario = v.empleado_id
                ORDER BY v.fecharegistro DESC, v.id DESC
                LIMIT @max;";

            using (var cn = new MySqlConnection(Conexion.cadena))
            using (var cmd = new MySqlCommand(sql, cn))
            {
                cmd.Parameters.AddWithValue("@max", max);
                cmd.CommandType = CommandType.Text;

                cn.Open();
                using (var dr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    int iVentaId = dr.GetOrdinal("venta_id");
                    int iTipoDoc = dr.GetOrdinal("tipodocumento");
                    int iNumDoc = dr.GetOrdinal("numerodocumento");
                    int iFecha = dr.GetOrdinal("fecharegistro");
                    int iTotal = dr.GetOrdinal("montototal");
                    int iPago = dr.GetOrdinal("montopago");
                    int iCambio = dr.GetOrdinal("montocambio");

                    int iCliId = dr.GetOrdinal("cliente_id");
                    int iCliDni = dr.GetOrdinal("cliente_dni");
                    int iCliNom = dr.GetOrdinal("cliente_nombre");
                    int iCliApe = dr.GetOrdinal("cliente_apellido");

                    int iUsrId = dr.GetOrdinal("usuario_id");
                    int iUsrNom = dr.GetOrdinal("usuario_nombre");
                    int iUsrApe = dr.GetOrdinal("usuario_apellido");

                    while (dr.Read())
                    {
                        var venta = new Venta
                        {
                            VentaId = dr.IsDBNull(iVentaId) ? 0 : dr.GetInt32(iVentaId),
                            TipoDocumento = dr.IsDBNull(iTipoDoc) ? "" : dr.GetString(iTipoDoc),
                            NumeroDocumento = dr.IsDBNull(iNumDoc) ? "" : dr.GetString(iNumDoc),
                            FechaRegistro = dr.IsDBNull(iFecha) ? (DateTime?)null : dr.GetDateTime(iFecha),
                            MontoTotal = dr.IsDBNull(iTotal) ? 0m : dr.GetDecimal(iTotal),
                            MontoPago = dr.IsDBNull(iPago) ? 0m : dr.GetDecimal(iPago),
                            MontoCambio = dr.IsDBNull(iCambio) ? 0m : dr.GetDecimal(iCambio),

                            oCliente = new Cliente
                            {
                                id = dr.IsDBNull(iCliId) ? 0 : dr.GetInt32(iCliId),
                                dni = dr.IsDBNull(iCliDni) ? "" : dr.GetString(iCliDni),
                                nombre = dr.IsDBNull(iCliNom) ? "" : dr.GetString(iCliNom),
                                apellido = dr.IsDBNull(iCliApe) ? "" : dr.GetString(iCliApe)
                            },

                            oEmpleado = new Usuario
                            {
                                idusuario = dr.IsDBNull(iUsrId) ? 0 : dr.GetInt32(iUsrId),
                                nombre = dr.IsDBNull(iUsrNom) ? "" : dr.GetString(iUsrNom),
                                apellido = dr.IsDBNull(iUsrApe) ? "" : dr.GetString(iUsrApe)
                            }
                        };

                        lista.Add(venta);
                    }
                }
            }

            return lista;
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

        public bool Registrar(Venta obj, DataTable detalleVenta, string medioPago, out string mensaje)
        {
            mensaje = string.Empty;

            var items = detalleVenta.AsEnumerable().Select(r => new {
                producto_id = Convert.ToInt32(r["producto_id"]),
                cantidad = Convert.ToInt32(r["cantidad"]),
                // CORRECCIÓN CLAVE: 
                // 1. Convertir a cadena
                // 2. Reemplazar "," por "." para asegurar el formato SQL/JSON
                // 3. Parsear como decimal usando InvariantCulture (que usa el punto).
                precio_unitario = Decimal.Parse(
                    r["precio_unitario"].ToString().Replace(",", "."),
                    NumberStyles.AllowDecimalPoint,
                    CultureInfo.InvariantCulture
                )
        }).ToArray();

            string jsonDetalle = JsonConvert.SerializeObject(items, new JsonSerializerSettings { Culture = CultureInfo.InvariantCulture });

            using (var cn = new MySqlConnection(Conexion.cadena))
            using (var cmd = new MySqlCommand("SP_RegistrarVenta", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 60;

                cmd.Parameters.AddWithValue("p_IdUsuario", obj.EmpleadoId);
                cmd.Parameters.AddWithValue("p_ClienteId", obj.ClienteId);              // 👈 NUEVO
                cmd.Parameters.AddWithValue("p_MedioPago", medioPago);                  // 👈 NUEVO
                cmd.Parameters.AddWithValue("p_TipoDocumento", obj.TipoDocumento ?? "");
                cmd.Parameters.AddWithValue("p_NumeroDocumento", obj.NumeroDocumento ?? "");
                cmd.Parameters.AddWithValue("p_NombreCliente", obj.NombreCliente ?? "");
                cmd.Parameters.AddWithValue("p_MontoPago", obj.MontoPago);
                // Añadir el MontoTotal
                // cmd.Parameters.AddWithValue("p_MontoTotal", obj.MontoTotal);
                cmd.Parameters.Add(new MySqlParameter("p_DetalleVenta", MySqlDbType.JSON) { Value = jsonDetalle });

                var pRes = new MySqlParameter("resultado", MySqlDbType.Byte) { Direction = ParameterDirection.Output };
                var pMsg = new MySqlParameter("mensaje", MySqlDbType.VarChar, 250) { Direction = ParameterDirection.Output };
                cmd.Parameters.Add(pRes);
                cmd.Parameters.Add(pMsg);

                try
                {
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    bool ok = Convert.ToInt32(pRes.Value) == 1;
                    mensaje = pMsg.Value?.ToString() ?? "";
                    return ok;
                }
                catch (Exception ex)
                {
                    mensaje = "Error al registrar la venta: " + ex.Message;
                    return false;
                }
            }
        }

        public Venta ObtenerVenta(string numero)
        {
            Venta obj = null;

            const string sql = @"
                SELECT
                  v.id                        AS venta_id,
                  v.empleado_id               AS empleado_id,
                  v.cliente_id                AS cliente_id,
                  v.tipodocumento             AS tipodocumento,
                  v.numerodocumento           AS numerodocumento,
                  COALESCE(c.nombre, 'Consumidor Final') AS cliente_nombre,
                  COALESCE(c.apellido, '')    AS cliente_apellido,
                  COALESCE(c.dni, '')         AS cliente_dni,
                  u.nombre                    AS empleado_nombre,
                  v.montopago                 AS montopago,
                  v.montocambio               AS montocambio,
                  v.montototal                AS montototal,
                  v.fecharegistro             AS fecharegistro
                FROM venta v
                LEFT JOIN cliente c ON c.id = v.cliente_id
                LEFT JOIN usuario u  ON u.idusuario = v.empleado_id
                WHERE v.numerodocumento = @numero;";

            using (var cn = new MySqlConnection(Conexion.cadena))
            using (var cmd = new MySqlCommand(sql, cn))
            {
                cmd.Parameters.AddWithValue("@numero", numero);

                try
                {
                    cn.Open();
                    using (var dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            int Ord(string col) => dr.GetOrdinal(col);
                            bool IsN(string col) => dr.IsDBNull(Ord(col));
                            int GetInt(string col) => IsN(col) ? 0 : dr.GetInt32(Ord(col));
                            string GetStr(string col) => IsN(col) ? "" : dr.GetString(Ord(col));
                            decimal GetDec(string col) => IsN(col) ? 0m : dr.GetDecimal(Ord(col));
                            DateTime? GetDtN(string col) => IsN(col) ? (DateTime?)null : dr.GetDateTime(Ord(col));

                            obj = new Venta
                            {
                                VentaId = GetInt("venta_id"),
                                EmpleadoId = GetInt("empleado_id"),
                                ClienteId = GetInt("cliente_id"),
                                TipoDocumento = GetStr("tipodocumento"),
                                NumeroDocumento = GetStr("numerodocumento"),
                                MontoPago = GetDec("montopago"),
                                MontoCambio = GetDec("montocambio"),
                                MontoTotal = GetDec("montototal"),
                                FechaRegistro = GetDtN("fecharegistro"),
                                NombreCliente = (GetStr("cliente_nombre") + " " + GetStr("cliente_apellido")).Trim(),
                                DocumentoCliente = GetStr("cliente_dni"),
                                oEmpleado = new Usuario { nombre = GetStr("empleado_nombre") },
                                oCliente = new Cliente
                                {
                                    nombre = GetStr("cliente_nombre"),
                                    apellido = GetStr("cliente_apellido"),
                                    dni = GetStr("cliente_dni")
                                }
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener la venta", ex);
                }
            }

            // Cargar detalle si existe venta real
            if (obj != null && obj.VentaId != 0)
            {
                obj.oDetalle_Venta = ObtenerDetalleVenta(obj.VentaId);
            }

            return obj ?? new Venta();
        }

        public List<detalle_venta> ObtenerDetalleVenta(int idventa)
        {
            var lista = new List<detalle_venta>();

            const string sql = @"
                SELECT 
                    dv.id,
                    dv.venta_id,
                    dv.producto_id,
                    dv.cantidad,
                    dv.precio_unitario,
                    p.nombre    AS producto_nombre,
                    COALESCE(p.descripcion, '') AS producto_descripcion
                FROM detalle_venta dv
                INNER JOIN producto p ON p.id = dv.producto_id
                WHERE dv.venta_id = @idventa;";

            using (var cn = new MySqlConnection(Conexion.cadena))
            using (var cmd = new MySqlCommand(sql, cn))
            {
                cmd.Parameters.AddWithValue("@idventa", idventa);

                try
                {
                    cn.Open();
                    using (var dr = cmd.ExecuteReader())
                    {
                        int Ord(string c) => dr.GetOrdinal(c);
                        bool IsN(string c) => dr.IsDBNull(Ord(c));
                        int GetInt(string c) => IsN(c) ? 0 : dr.GetInt32(Ord(c));
                        decimal GetDec(string c) => IsN(c) ? 0m : dr.GetDecimal(Ord(c));
                        string GetStr(string c) => IsN(c) ? "" : dr.GetString(Ord(c));

                        while (dr.Read())
                        {
                            var det = new detalle_venta
                            {
                                id = GetInt("id"),
                                VentaId = GetInt("venta_id"),
                                ProductoId = GetInt("producto_id"),
                                cantidad = GetInt("cantidad"),
                                precio_unitario = GetDec("precio_unitario"),
                                oproducto = new Producto
                                {
                                    Id = GetInt("producto_id"),
                                    nombre = GetStr("producto_nombre"),
                                    descripcion = GetStr("producto_descripcion")
                                }
                            };
                            lista.Add(det);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener el detalle de la venta: " + ex.Message, ex);
                }

            }

            return lista;
        }
       
        public bool RegistrarMedioPago(int ventaId, string medio, decimal monto, out string mensaje)
        {
            mensaje = "";
            try
            {
                using (var cn = new MySqlConnection(Conexion.cadena))
                using (var cmd = new MySqlCommand(
                    "INSERT INTO venta_mediopago (venta_id, medio_pago, monto) VALUES (@v,@m,@mon);", cn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@v", ventaId);
                    cmd.Parameters.AddWithValue("@m", medio);      // 'Efectivo','Tarjeta','Billetera Virtual','CuentaCorriente'
                    cmd.Parameters.AddWithValue("@mon", monto);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                return false;
            }
        }

        
    }
}
