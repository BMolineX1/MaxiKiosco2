using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace CapaDatos
{
    public partial class CD_ReportesCaja
    {
        private readonly string _cnx = Conexion.cadena;

        public DataTable ListarAperturas(DateTime desde, DateTime hasta, int? empleadoId = null)
        {
            using var cn = new MySqlConnection(_cnx);
            using var da = new MySqlDataAdapter(@"
                SELECT *
                FROM vw_aperturas_caja
                WHERE fecha BETWEEN @d AND @h
                  AND (@emp IS NULL OR empleado_id=@emp)
                ORDER BY fecha, apertura_id;", cn);
            da.SelectCommand.Parameters.AddWithValue("@d", desde.Date);
            da.SelectCommand.Parameters.AddWithValue("@h", hasta.Date);
            da.SelectCommand.Parameters.AddWithValue("@emp", (object)empleadoId ?? DBNull.Value);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable ResumenPorAperturaId(int aperturaId)
        {
            using var cn = new MySqlConnection(_cnx);
            using var da = new MySqlDataAdapter(@"
                SELECT
                    ca.id                            AS apertura_id,
                    ca.fecha                         AS fecha,
                    ca.empleado_id                   AS empleado_id,
                    ca.monto_inicial                 AS monto_inicial,
                    ca.abierta                       AS abierta,
                    ca.abierto_en                    AS abierto_en,
                    ca.cerrado_en                    AS cerrado_en,

                    -- Ventas por medio en la apertura
                    IFNULL(SUM(CASE WHEN mp.medio_pago = 'Efectivo' THEN mp.monto END), 0)                               AS ventas_efectivo,
                    IFNULL(SUM(CASE WHEN mp.medio_pago IN ('Debito','Credito','Tarjeta') THEN mp.monto END), 0)          AS ventas_tarjeta,
                    IFNULL(SUM(CASE WHEN mp.medio_pago = 'CuentaCorriente' THEN mp.monto END), 0)                         AS ventas_ctacte,

                    -- Retiros de la apertura
                    (SELECT IFNULL(SUM(r.monto),0) FROM retiros r WHERE r.apertura_id = ca.id)                             AS retiros_total,

                    -- Datos de cierre (si existe)
                    cc.saldo_real AS saldo_real,
                    cc.diferencia AS diferencia
                FROM caja_apertura ca
                LEFT JOIN venta v            ON v.apertura_id = ca.id
                LEFT JOIN venta_mediopago mp ON mp.venta_id   = v.id
                LEFT JOIN cierres_caja cc    ON cc.apertura_id = ca.id
                WHERE ca.id = @id
                GROUP BY
                    ca.id, ca.fecha, ca.empleado_id, ca.monto_inicial, ca.abierta, ca.abierto_en, ca.cerrado_en,
                    cc.saldo_real, cc.diferencia
                LIMIT 1;", cn);

            da.SelectCommand.Parameters.AddWithValue("@id", aperturaId);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        // ✅ VENTAS POR APERTURA (no por fecha)
        public DataTable ListarVentasPorApertura(int aperturaId)
        {
            using var cn = new MySqlConnection(_cnx);
            using var da = new MySqlDataAdapter(@"
                SELECT
                    v.id,
                    v.fecharegistro,
                    COALESCE(v.montototal, SUM(dv.cantidad * dv.precio_unitario)) AS total,
                    v.empleado_id,
                    v.cliente_id
                FROM venta v
                LEFT JOIN detalle_venta dv ON dv.venta_id = v.id
                WHERE v.apertura_id = @ap
                GROUP BY v.id, v.fecharegistro, v.montototal, v.empleado_id, v.cliente_id
                ORDER BY v.fecharegistro;", cn);
            da.SelectCommand.Parameters.AddWithValue("@ap", aperturaId);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        // ✅ RETIROS POR APERTURA (no por fecha)
        public DataTable ListarRetirosPorApertura(int aperturaId)
        {
            using var cn = new MySqlConnection(_cnx);
            using var da = new MySqlDataAdapter(@"
                SELECT r.id, r.fecha_hora, r.monto, r.motivo, r.referencia
                FROM retiros r
                WHERE r.apertura_id = @ap
                ORDER BY r.fecha_hora;", cn);
            da.SelectCommand.Parameters.AddWithValue("@ap", aperturaId);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        
    }
}
