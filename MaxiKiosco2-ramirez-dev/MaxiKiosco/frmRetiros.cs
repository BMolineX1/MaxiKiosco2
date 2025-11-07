using CapaEntidad;
using CapaNegocio;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace MaxiKiosco
{
    // Form de retiros (el archivo/clase se llama "btnFiltrar" según tu proyecto)
    public partial class btnFiltrar : Form
    {
        public btnFiltrar()
        {
            InitializeComponent();

            // Forzar cableado por código (independiente del diseñador)
            this.Load += btnFiltrar_Load;

            // Botón "Registrar Retiro"
            this.btnGuardar.Click += btnGuardar_Click;

            // Botón "Filtrar" (ajustá el nombre si tu botón se llama btnFiltrar)
            // Si tu botón se llama exactamente btnFiltrar, dejalo así:
            // this.btnFiltrar.Click += btnFiltrar_Click;
            // Si en el diseñador se llama btnFiltrarBuscar, usá la siguiente línea:
            this.btnFiltrarBuscar.Click += btnFiltrar_Click;
        }

        private void btnFiltrar_Load(object sender, EventArgs e)
        {
            dtpDesde.Value = DateTime.Today;
            dtpHasta.Value = DateTime.Today;
            CargarRetiros();
        }

        private void CargarRetiros()
        {
            var lista = new CN_Retiro().Listar(dtpDesde.Value.Date, dtpHasta.Value.Date);

            dgvRetiros.Rows.Clear();
            foreach (var r in lista)
            {
                // Asegurate que el DataGridView tiene columnas en este orden:
                // Id, FechaHora, EmpleadoId, Monto, Motivo, Referencia
                dgvRetiros.Rows.Add(r.Id, r.FechaHora, r.EmpleadoId, r.Monto, r.Motivo, r.Referencia);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // 1) Usuario en sesión
                if (Usuario.Actual == null)
                {
                    MessageBox.Show("No hay usuario en sesión.");
                    return;
                }

                // 2) Monto válido (soporta coma o punto)
                if (!decimal.TryParse(txtMonto.Text, NumberStyles.Any, CultureInfo.CurrentCulture, out var monto) &&
                    !decimal.TryParse(txtMonto.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out monto))
                {
                    MessageBox.Show("Monto inválido.");
                    txtMonto.Focus();
                    return;
                }
                if (monto <= 0)
                {
                    MessageBox.Show("El monto debe ser mayor a 0.");
                    txtMonto.Focus();
                    return;
                }

                // 3) Verificar que exista apertura ABIERTA en este instante para el empleado
                int empleadoId = Usuario.UsuarioId();
                var ts = DateTime.Now;

                // Helper de CD_Caja (debe existir en tu CapaDatos como te pasé)
                int apId = new CapaDatos.CD_Caja().GetAperturaAbiertaIdPorEmpleado(ts, empleadoId);
                if (apId == 0)
                {
                    MessageBox.Show("Debés abrir caja antes de registrar un retiro.");
                    return;
                }

                // 4) Construir retiro
                var retiro = new Retiro
                {
                    EmpleadoId = empleadoId,
                    Monto = monto,
                    FechaHora = ts,
                    Motivo = txtMotivo.Text?.Trim(),
                    Referencia = txtReferencia.Text?.Trim()
                };

                // 5) Persistir
                btnGuardar.Enabled = false; // evita doble click
                var cn = new CN_Retiro();
                var id = cn.Registrar(retiro, out string msg);
                btnGuardar.Enabled = true;

                if (id > 0)
                {
                    MessageBox.Show("Retiro registrado.");
                    txtMonto.Clear();
                    txtMotivo.Clear();
                    txtReferencia.Clear();
                    CargarRetiros();
                }
                else
                {
                    MessageBox.Show(string.IsNullOrWhiteSpace(msg) ? "No se pudo registrar el retiro." : ("Error: " + msg));
                }
            }
            catch (Exception ex)
            {
                btnGuardar.Enabled = true;
                MessageBox.Show("Error inesperado: " + ex.Message);
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            CargarRetiros();
        }
    }
}
