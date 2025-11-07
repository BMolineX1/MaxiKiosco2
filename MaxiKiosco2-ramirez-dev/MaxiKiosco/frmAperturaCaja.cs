using System;
using System.Globalization;
using System.Windows.Forms;
using CapaNegocio;
using CapaEntidad;

namespace MaxiKiosco
{
    public partial class frmAperturaCaja : Form
    {
        public frmAperturaCaja()
        {
            InitializeComponent();
        }

        private void frmAperturaCaja_Load(object sender, EventArgs e)
        {
            // Fecha hoy
            dtpFecha.Format = DateTimePickerFormat.Custom;
            dtpFecha.CustomFormat = "dd/MM/yyyy";
            dtpFecha.Value = DateTime.Now.Date;

            // Defaults
            if (string.IsNullOrWhiteSpace(txtMontoInicial.Text))
                txtMontoInicial.Text = "0,00";
            txtObsApertura.MaxLength = 255;

            // Re-enganchar por las dudas
            btnAbrirCaja.Click -= btnAbrirCaja_Click;
            btnAbrirCaja.Click += btnAbrirCaja_Click;

            lblEstadoApertura.Text = "";
            lblEstadoAperturas.Text = "";
        }

        private void btnAbrirCaja_Click(object sender, EventArgs e)
        {
            try
            {
                if (Usuario.Actual == null)
                {
                    MessageBox.Show("No hay usuario en sesión.");
                    return;
                }

                if (!decimal.TryParse(txtMontoInicial.Text, NumberStyles.Number, new CultureInfo("es-AR"), out var monto) &&
                    !decimal.TryParse(txtMontoInicial.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out monto))
                {
                    MessageBox.Show("Monto inicial inválido.");
                    txtMontoInicial.Focus();
                    return;
                }

                int empleadoId = Usuario.UsuarioId();
                var fecha = dtpFecha.Value.Date;
                var cn = new CN_Caja();

                // ✅ validar si ya hay APERTURA ABIERTA para este empleado AHORA (turno)
                int apIdExistente = cn.GetAperturaAbiertaIdPorEmpleado(DateTime.Now, empleadoId);
                if (apIdExistente > 0)
                {
                    var apYa = cn.GetAperturaAbierta(DateTime.Now, empleadoId);
                    lblEstadoApertura.Text = $"Ya está ABIERTA (ID {apYa?.Id})";
                    if (apYa != null)
                        lblEstadoAperturas.Text = $"Fecha {apYa.Fecha:dd/MM/yyyy} – Monto inicial {apYa.MontoInicial:n2}";
                    MessageBox.Show("Ya existe una apertura de caja ABIERTA para tu turno.");
                    return;
                }

                string obs = txtObsApertura.Text?.Trim() ?? "";

                // Abrir caja (SP_AbrirCaja)
                if (cn.AbrirCaja(fecha, empleadoId, monto, obs, out string msg))
                {
                    // Recuperar la apertura abierta ahora por empleado
                    var ap = cn.GetAperturaAbierta(DateTime.Now, empleadoId);
                    if (ap != null)
                    {
                        CajaRuntime.AperturaActualId = ap.Id;
                        CajaRuntime.AperturaFecha = ap.Fecha;

                        lblEstadoApertura.Text = $"ABIERTA (ID {ap.Id})";
                        lblEstadoAperturas.Text = $"Fecha {ap.Fecha:dd/MM/yyyy} – Monto inicial {ap.MontoInicial:n2}";
                    }

                    MessageBox.Show(string.IsNullOrWhiteSpace(msg) ? "Caja abierta correctamente." : msg,
                        "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                }
                else
                {
                    MessageBox.Show(string.IsNullOrWhiteSpace(msg) ? "No se pudo abrir la caja." : msg,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir caja: " + ex.Message,
                    "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    // Guarda en memoria el turno actual (podés usarlo en ventas para setear apertura_id)
    public static class CajaRuntime
    {
        public static int? AperturaActualId { get; set; }
        public static DateTime? AperturaFecha { get; set; }
    }
}
