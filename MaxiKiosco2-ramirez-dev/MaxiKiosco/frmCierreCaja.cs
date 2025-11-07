using CapaEntidad;
using CapaNegocio;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace MaxiKiosco
{
    public partial class frmCierreCaja : Form
    {
        public frmCierreCaja()
        {
            InitializeComponent();

            // Forzar cableado por código
            this.Load += frmCierreCaja_Load;
            this.btnCerrarCaja.Click += btnCerrarCaja_Click;
        }

        private void frmCierreCaja_Load(object sender, EventArgs e)
        {
            dtpFecha.Format = DateTimePickerFormat.Custom;
            dtpFecha.CustomFormat = "dd/MM/yyyy";
            dtpFecha.Value = DateTime.Now.Date;

            txtSaldoReal.Text = "0,00";
            txtObservaciones.MaxLength = 255;
        }

        private void btnCerrarCaja_Click(object sender, EventArgs e)
        {
            // 1) Usuario en sesión
            if (Usuario.Actual == null)
            {
                MessageBox.Show("No hay usuario en sesión.");
                return;
            }
            int empleadoId = Usuario.UsuarioId();

            // 2) Saldo contado válido
            if (!decimal.TryParse(txtSaldoReal.Text, NumberStyles.Any, CultureInfo.CurrentCulture, out var saldoReal) &&
                !decimal.TryParse(txtSaldoReal.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out saldoReal))
            {
                MessageBox.Show("Saldo contado inválido.");
                txtSaldoReal.Focus();
                return;
            }

            // 3) Verificar que exista una apertura ABIERTA para ese empleado/fecha
            var fecha = dtpFecha.Value.Date;
            var cdCaja = new CapaDatos.CD_Caja();

            // Usamos el helper por empleado + timestamp (más robusto que por fecha suelta)
            int apId = cdCaja.GetAperturaAbiertaIdPorEmpleado(DateTime.Now, empleadoId);
            if (apId == 0)
            {
                MessageBox.Show("No hay apertura de caja ABIERTA para este empleado. No se puede cerrar.");
                return;
            }

            // 4) Ejecutar cierre
            var cn = new CN_Caja();
            string obs = txtObservaciones.Text?.Trim() ?? "";

            if (cn.CerrarCaja(fecha, empleadoId, saldoReal, obs, out string msg))
            {
                MessageBox.Show(string.IsNullOrWhiteSpace(msg) ? "Cierre de caja generado." : msg,
                    "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show(string.IsNullOrWhiteSpace(msg) ? "No se pudo cerrar la caja." : msg,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
