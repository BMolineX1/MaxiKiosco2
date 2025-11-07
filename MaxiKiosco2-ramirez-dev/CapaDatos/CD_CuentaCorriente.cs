using CapaEntidad;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace CapaDatos
{
    public class CD_CuentaCorriente
    {
        public bool RegistrarVentaFiada(int clienteId, int ventaId, decimal monto, int usuarioId, out string mensaje)
        {
            mensaje = "";
            using (var cn = new MySqlConnection(Conexion.cadena))
            using (var cmd = new MySqlCommand("SP_CC_RegistrarVentaFiada", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("p_ClienteId", clienteId);
                cmd.Parameters.AddWithValue("p_VentaId", ventaId);
                cmd.Parameters.AddWithValue("p_Monto", monto);
                cmd.Parameters.AddWithValue("p_UsuarioId", usuarioId);

                var pRes = new MySqlParameter("resultado", MySqlDbType.Byte) { Direction = ParameterDirection.Output };
                var pMsg = new MySqlParameter("mensaje", MySqlDbType.VarChar, 250) { Direction = ParameterDirection.Output };
                cmd.Parameters.Add(pRes); cmd.Parameters.Add(pMsg);

                try
                {
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    bool ok = (pRes.Value != null && pRes.Value.ToString() == "1");
                    mensaje = pMsg.Value?.ToString() ?? "";
                    return ok;
                }
                catch (MySqlException ex)
                {
                    mensaje = ex.Message;
                    return false;
                }
            }
        }

        public bool RegistrarPago(int clienteId, decimal monto, int usuarioId, string concepto, out string mensaje)
        {
            mensaje = "";
            using (var cn = new MySqlConnection(Conexion.cadena))
            using (var cmd = new MySqlCommand("SP_CC_RegistrarPago", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("p_ClienteId", clienteId);
                cmd.Parameters.AddWithValue("p_Monto", monto);
                cmd.Parameters.AddWithValue("p_UsuarioId", usuarioId);
                cmd.Parameters.AddWithValue("p_Concepto", (object)(concepto ?? ""));

                var pRes = new MySqlParameter("resultado", MySqlDbType.Byte) { Direction = ParameterDirection.Output };
                var pMsg = new MySqlParameter("mensaje", MySqlDbType.VarChar, 250) { Direction = ParameterDirection.Output };
                cmd.Parameters.Add(pRes); cmd.Parameters.Add(pMsg);

                try
                {
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    bool ok = (pRes.Value != null && pRes.Value.ToString() == "1");
                    mensaje = pMsg.Value?.ToString() ?? "";
                    return ok;
                }
                catch (MySqlException ex)
                {
                    mensaje = ex.Message;
                    return false;
                }
            }
        }

        public CuentaCorrienteCliente ObtenerEstado(int clienteId)
        {
            const string sql = @"SELECT cliente_id, saldo, limite_credito, habilitada
                                 FROM cuenta_corriente_cliente
                                 WHERE cliente_id = @id";
            using (var cn = new MySqlConnection(Conexion.cadena))
            using (var cmd = new MySqlCommand(sql, cn))
            {
                cmd.Parameters.AddWithValue("@id", clienteId);
                cn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        return new CuentaCorrienteCliente
                        {
                            ClienteId = dr.GetInt32("cliente_id"),
                            Saldo = dr.GetDecimal("saldo"),
                            LimiteCredito = dr.GetDecimal("limite_credito"),
                            Habilitada = dr.GetBoolean("habilitada")
                        };
                    }
                }
            }
            return null;
        }

        public List<CCMovimiento> ListarMovimientos(int clienteId, DateTime? desde, DateTime? hasta)
        {
            var lista = new List<CCMovimiento>();
            const string sql = @"
                SELECT id, cliente_id, fecha_hora, tipo, concepto, venta_id, monto, usuario_id
                FROM cc_movimiento
                WHERE cliente_id=@cli
                  AND (@d IS NULL OR DATE(fecha_hora) >= @d)
                  AND (@h IS NULL OR DATE(fecha_hora) <= @h)
                ORDER BY fecha_hora DESC, id DESC";
            using (var cn = new MySqlConnection(Conexion.cadena))
            using (var cmd = new MySqlCommand(sql, cn))
            {
                cmd.Parameters.AddWithValue("@cli", clienteId);
                cmd.Parameters.AddWithValue("@d", (object)desde?.Date ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@h", (object)hasta?.Date ?? DBNull.Value);
                cn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new CCMovimiento
                        {
                            Id = dr.GetInt32("id"),
                            ClienteId = dr.GetInt32("cliente_id"),
                            FechaHora = dr.GetDateTime("fecha_hora"),
                            Tipo = dr.GetString("tipo"),
                            Concepto = dr["concepto"] as string,
                            VentaId = dr["venta_id"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["venta_id"]),
                            Monto = dr.GetDecimal("monto"),
                            UsuarioId = dr.GetInt32("usuario_id")
                        });
                    }
                }
            }
            return lista;
        }

        /* NUEVO: listado para el grid de la izquierda */
        public DataTable ListarCuentas()
        {
            var dt = new DataTable();
            const string sql = @"
                SELECT 
                    cli.id AS Id,
                    COALESCE(CONCAT(cli.apellido,' ',cli.nombre), cli.razonsocial) AS Cliente,
                    ccc.saldo AS Saldo,
                    ccc.limite_credito AS Limite,
                    ccc.habilitada AS Habilitada
                FROM cuenta_corriente_cliente ccc
                LEFT JOIN cliente cli ON cli.id = ccc.cliente_id
                ORDER BY Cliente";
            using (var cn = new MySqlConnection(Conexion.cadena))
            using (var da = new MySqlDataAdapter(sql, cn))
            {
                da.Fill(dt);
            }
            return dt;
        }
    }
}
