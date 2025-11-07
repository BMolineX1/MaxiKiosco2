using CapaEntidad;
using CapaNegocio;
using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace MaxiKiosco
{
    public partial class frmCajasMaestroDetalle : Form
    {
        private readonly CN_ReportesCaja _rep = new CN_ReportesCaja();
        private readonly CN_Caja _caja = new CN_Caja();

        public frmCajasMaestroDetalle()
        {
            InitializeComponent();

            // Wire de eventos (por si el Designer se pierde referencias)
            this.Load += frmCajasMaestroDetalle_Load;
            btnBuscar.Click += btnBuscar_Click;
            dgvAperturas.SelectionChanged += dgvAperturas_SelectionChanged;
            btnCerrarCaja.Click += btnCerrarCaja_Click;
        }

        /* ======================
         *  Load + Filtros
         * ====================== */
        private void frmCajasMaestroDetalle_Load(object sender, EventArgs e)
        {
            var hoy = DateTime.Now.Date;
            dtpDesde.Value = hoy.AddDays(-7);
            dtpHasta.Value = hoy;

            btnBuscar.PerformClick();
            if (dgvAperturas.Rows.Count > 0)
                dgvAperturas.Rows[0].Selected = true;
        }

        private int? EmpleadoFilter()
            => int.TryParse(txtEmpleadoId.Text, out var id) ? id : (int?)null;

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                var dt = _rep.Aperturas(dtpDesde.Value.Date, dtpHasta.Value.Date, EmpleadoFilter());
                dgvAperturas.DataSource = dt;

                // Encabezados más amigables
                if (dgvAperturas.Columns.Contains("apertura_id")) dgvAperturas.Columns["apertura_id"].HeaderText = "Apertura";
                if (dgvAperturas.Columns.Contains("empleado_id")) dgvAperturas.Columns["empleado_id"].HeaderText = "Empleado";
                if (dgvAperturas.Columns.Contains("monto_inicial")) dgvAperturas.Columns["monto_inicial"].HeaderText = "Inicial";
                if (dgvAperturas.Columns.Contains("abierta")) dgvAperturas.Columns["abierta"].HeaderText = "Abierta";
                if (dgvAperturas.Columns.Contains("abierto_en")) dgvAperturas.Columns["abierto_en"].HeaderText = "Abierto";
                if (dgvAperturas.Columns.Contains("cerrado_en")) dgvAperturas.Columns["cerrado_en"].HeaderText = "Cerrado";

                // Limpiar detalle si no hay filas
                if (dt.Rows.Count == 0)
                {
                    LimpiarDetalle();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar aperturas: " + ex.Message);
            }
        }

        /* ======================
         *  Maestro -> Detalle
         * ====================== */
        private void dgvAperturas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAperturas.CurrentRow == null || dgvAperturas.CurrentRow.DataBoundItem is not DataRowView drv)
                return;

            try
            {
                // Datos base de la fila seleccionada
                int aperturaId = Convert.ToInt32(drv["apertura_id"]);
                DateTime fecha = Convert.ToDateTime(drv["fecha"]);
                bool abierta = Convert.ToBoolean(drv["abierta"]);

                // ===== Resumen (una sola fila)
                var dtResumen = _rep.ResumenPorAperturaId(aperturaId);
                if (dtResumen.Rows.Count == 1)
                {
                    var r = dtResumen.Rows[0];

                    decimal inicial = GetDec(r, "monto_inicial");
                    decimal efe = GetDec(r, "ventas_efectivo");
                    decimal tar = GetDec(r, "ventas_tarjeta");
                    decimal cta = GetDec(r, "ventas_ctacte");
                    decimal reti = GetDec(r, "retiros_total");

                    decimal esperado = inicial + efe - reti;

                    bool tieneSR = r.Table.Columns.Contains("saldo_real") && !r.IsNull("saldo_real");
                    decimal saldoReal = tieneSR ? Convert.ToDecimal(r["saldo_real"]) : 0m;

                    bool tieneDif = r.Table.Columns.Contains("diferencia") && !r.IsNull("diferencia");
                    decimal difCalc = tieneSR ? (saldoReal - esperado) : 0m;
                    decimal difVista = tieneDif ? Convert.ToDecimal(r["diferencia"]) : difCalc;

                    lblInicial.Text = inicial.ToString("N2");
                    lblEfectivo.Text = efe.ToString("N2");
                    lblTarjeta.Text = tar.ToString("N2");
                    lblCtaCte.Text = cta.ToString("N2");
                    lblRetiros.Text = reti.ToString("N2");
                    lblTotal.Text = (efe + tar + cta).ToString("N2");
                    lblEsperado.Text = esperado.ToString("N2");
                    lblSaldoReal.Text = tieneSR ? saldoReal.ToString("N2") : "-";
                    lblDiferencia.Text = tieneSR ? difVista.ToString("N2") : "-";
                }
                else
                {
                    LimpiarResumen();
                }

                // ===== Ventas / Retiros de la APERTURA seleccionada
                dgvVentas.DataSource = _rep.VentasPorApertura(aperturaId);
                dgvRetiros.DataSource = _rep.RetirosPorApertura(aperturaId);
                dgvVentas.Refresh();
                dgvRetiros.Refresh();

                // ===== Cierre (estado visual + habilitar botón)
                lblEstadoApertura.Text = abierta
                    ? $"ABIERTA (ID {aperturaId}, {fecha:dd/MM/yyyy})"
                    : $"CERRADA (ID {aperturaId}, {fecha:dd/MM/yyyy})";
                btnCerrarCaja.Enabled = abierta;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar detalle: " + ex.Message);
            }
        }

        /* ======================
         *  Cerrar caja
         * ====================== */
        private void btnCerrarCaja_Click(object sender, EventArgs e)
        {
            if (dgvAperturas.CurrentRow == null || dgvAperturas.CurrentRow.DataBoundItem is not DataRowView drv)
                return;

            try
            {
                DateTime fecha = Convert.ToDateTime(drv["fecha"]);

                if (Usuario.Actual == null)
                {
                    MessageBox.Show("No hay usuario en sesión.");
                    return;
                }

                if (!decimal.TryParse(txtSaldoReal.Text, NumberStyles.Number, new CultureInfo("es-AR"), out var saldoReal) &&
                    !decimal.TryParse(txtSaldoReal.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out saldoReal))
                {
                    MessageBox.Show("Saldo real inválido.");
                    txtSaldoReal.Focus();
                    return;
                }

                string obs = txtObsCierre.Text?.Trim() ?? "";
                if (_caja.CerrarCaja(fecha.Date, Usuario.UsuarioId(), saldoReal, obs, out string msg))
                {
                    MessageBox.Show(string.IsNullOrWhiteSpace(msg) ? "Caja cerrada correctamente." : msg,
                        "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Refrescar maestro + vuelve a cargar detalle
                    btnBuscar.PerformClick();
                }
                else
                {
                    MessageBox.Show(string.IsNullOrWhiteSpace(msg) ? "No se pudo cerrar la caja." : msg,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cerrar caja: " + ex.Message);
            }
        }

        /* ======================
         *  Helpers UI
         * ====================== */
        private static decimal GetDec(DataRow r, string col)
            => r.Table.Columns.Contains(col) && !r.IsNull(col) ? Convert.ToDecimal(r[col]) : 0m;

        private void LimpiarResumen()
        {
            lblInicial.Text = "-";
            lblEfectivo.Text = "-";
            lblTarjeta.Text = "-";
            lblCtaCte.Text = "-";
            lblRetiros.Text = "-";
            lblTotal.Text = "-";
            lblEsperado.Text = "-";
            lblSaldoReal.Text = "-";
            lblDiferencia.Text = "-";
            lblEstadoApertura.Text = "Estado: -";
        }

        private void LimpiarDetalle()
        {
            LimpiarResumen();
            dgvVentas.DataSource = null;
            dgvRetiros.DataSource = null;
        }
    }
}
