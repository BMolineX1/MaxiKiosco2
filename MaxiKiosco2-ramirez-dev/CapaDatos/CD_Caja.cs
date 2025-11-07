using System;
using System.Data;
using MySql.Data.MySqlClient;
using CapaEntidad;

namespace CapaDatos
{
    public class CD_Caja
    {
        private readonly string _cnx;

        public CD_Caja(string cadenaConexion = null)
        {
            _cnx = cadenaConexion ?? Conexion.cadena;
        }

        public bool AbrirCaja(DateTime fecha, int empleadoId, decimal montoInicial, string observaciones, out string mensaje)
        {
            mensaje = "";
            using var cn = new MySqlConnection(_cnx);
            using var cmd = new MySqlCommand("SP_AbrirCaja", cn) { CommandType = CommandType.StoredProcedure };

            cmd.Parameters.AddWithValue("p_fecha", fecha.Date);
            cmd.Parameters.AddWithValue("p_empleado_id", empleadoId);
            cmd.Parameters.AddWithValue("p_monto_inicial", montoInicial);
            cmd.Parameters.AddWithValue("p_observaciones", (object)(observaciones ?? "") ?? DBNull.Value);

            var pOk = new MySqlParameter("p_ok", MySqlDbType.Byte) { Direction = ParameterDirection.Output };
            var pMsg = new MySqlParameter("p_mensaje", MySqlDbType.VarChar, 255) { Direction = ParameterDirection.Output };
            cmd.Parameters.Add(pOk);
            cmd.Parameters.Add(pMsg);

            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();

                bool ok = Convert.ToInt32(pOk.Value) == 1;
                mensaje = pMsg.Value?.ToString() ?? "";
                return ok;
            }
            catch (MySqlException ex)
            {
                mensaje = "[MySQL] " + ex.Message;
                return false;
            }
            catch (Exception ex)
            {
                mensaje = "[Error] " + ex.Message;
                return false;
            }
        }

        // CapaDatos/CD_Caja.cs
        public AperturaCaja GetAperturaAbierta(DateTime ts, int empleadoId)
        {
            const string sql = @"
        SELECT id, fecha, empleado_id, monto_inicial, observaciones, abierto_en, cerrado_en, abierta
        FROM caja_apertura
        WHERE empleado_id = @emp
          AND abierta = 1
          AND @ts >= abierto_en
          AND (cerrado_en IS NULL OR @ts <= cerrado_en)
        ORDER BY abierto_en DESC, id DESC
        LIMIT 1;";

            using var cn = new MySqlConnection(_cnx);
            using var cmd = new MySqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@emp", empleadoId);
            cmd.Parameters.AddWithValue("@ts", ts);
            cn.Open();
            using var dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            if (!dr.Read()) return null;

            return new AperturaCaja
            {
                Id = dr.GetInt32("id"),
                Fecha = dr.GetDateTime("fecha"),
                EmpleadoId = dr.GetInt32("empleado_id"),
                MontoInicial = dr.GetDecimal("monto_inicial"),
                Observaciones = dr["observaciones"] as string ?? "",
                Estado = dr.GetBoolean("abierta") ? "ABIERTA" : "CERRADA"
            };
        }


        public bool CerrarCaja(DateTime fecha, int empleadoId, decimal saldoReal, string observaciones, out string mensaje)
        {
            mensaje = "";
            using var cn = new MySqlConnection(_cnx);
            using var cmd = new MySqlCommand("SP_CerrarCaja", cn) { CommandType = CommandType.StoredProcedure };

            cmd.Parameters.AddWithValue("p_fecha", fecha.Date);
            cmd.Parameters.AddWithValue("p_empleado_id", empleadoId);
            cmd.Parameters.AddWithValue("p_saldo_real", saldoReal);
            cmd.Parameters.AddWithValue("p_observaciones", (object)(observaciones ?? "") ?? DBNull.Value);

            var pOk = new MySqlParameter("p_ok", MySqlDbType.Byte) { Direction = ParameterDirection.Output };
            var pMsg = new MySqlParameter("p_mensaje", MySqlDbType.VarChar, 255) { Direction = ParameterDirection.Output };
            cmd.Parameters.Add(pOk);
            cmd.Parameters.Add(pMsg);

            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();

                bool ok = Convert.ToInt32(pOk.Value) == 1;
                mensaje = pMsg.Value?.ToString() ?? "";
                return ok;
            }
            catch (MySqlException ex)
            {
                mensaje = "[MySQL] " + ex.Message;
                return false;
            }
            catch (Exception ex)
            {
                mensaje = "[Error] " + ex.Message;
                return false;
            }
        }
        public int GetAperturaAbiertaIdPorEmpleado(DateTime ts, int empleadoId)
        {
            const string sql = @"
        SELECT id
        FROM caja_apertura
        WHERE empleado_id = @emp
          AND abierta = 1
          AND @ts >= abierto_en
          AND (cerrado_en IS NULL OR @ts <= cerrado_en)
        ORDER BY abierto_en DESC, id DESC
        LIMIT 1;";

            using var cn = new MySqlConnection(_cnx);
            using var cmd = new MySqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@emp", empleadoId);
            cmd.Parameters.AddWithValue("@ts", ts);
            cn.Open();
            var obj = cmd.ExecuteScalar();
            return obj == null ? 0 : Convert.ToInt32(obj);
        }
    }
}
