using CapaEntidad;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace CapaDatos
{
    public class CD_Retiro
    {
        public int Registrar(Retiro r, out string mensaje)
        {
            mensaje = "";
            int idGenerado = 0;

            var ts = r.FechaHora == default ? DateTime.Now : r.FechaHora;

            // Buscar apertura abierta del empleado en ese momento
            var cdCaja = new CD_Caja();
            int apId = cdCaja.GetAperturaAbiertaIdPorEmpleado(ts, r.EmpleadoId);
            if (apId == 0)
            {
                mensaje = "No hay APERTURA ABIERTA para este empleado en este horario.";
                return 0;
            }

            const string sql = @"
        INSERT INTO retiros (empleado_id, monto, fecha_hora, motivo, referencia, apertura_id)
        VALUES (@emp, @monto, @fh, @motivo, @ref, @ap);
        SELECT LAST_INSERT_ID();";

            using var cn = new MySqlConnection(Conexion.cadena);
            using var cmd = new MySqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@emp", r.EmpleadoId);
            cmd.Parameters.AddWithValue("@monto", r.Monto);
            cmd.Parameters.AddWithValue("@fh", ts);
            cmd.Parameters.AddWithValue("@motivo", (object)r.Motivo ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ref", (object)r.Referencia ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ap", apId);

            try
            {
                cn.Open();
                idGenerado = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (MySqlException ex)
            {
                mensaje = ex.Message;
            }
            return idGenerado;
        }

        public List<Retiro> Listar(DateTime? desde, DateTime? hasta)
        {
            var lista = new List<Retiro>();
            string sql = @"SELECT id, empleado_id, monto, fecha_hora, motivo, referencia
                           FROM retiros
                           WHERE (@d IS NULL OR DATE(fecha_hora) >= @d)
                             AND (@h IS NULL OR DATE(fecha_hora) <= @h)
                           ORDER BY fecha_hora DESC";

            using (var cn = new MySqlConnection(Conexion.cadena))
            using (var cmd = new MySqlCommand(sql, cn))
            {
                cmd.Parameters.AddWithValue("@d", (object)desde?.Date ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@h", (object)hasta?.Date ?? DBNull.Value);
                cn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Retiro
                        {
                            Id = dr.GetInt32("id"),
                            EmpleadoId = dr.GetInt32("empleado_id"),
                            Monto = dr.GetDecimal("monto"),
                            FechaHora = dr.GetDateTime("fecha_hora"),
                            Motivo = dr["motivo"] as string,
                            Referencia = dr["referencia"] as string
                        });
                    }
                }
            }
            return lista;
        }
    }
}
