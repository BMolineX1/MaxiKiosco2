using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocio;
using FontAwesome.Sharp;

namespace MaxiKiosco
{
    public partial class Inicio : Form
    {
        private static Usuario usuarioActual;
        private static IconMenuItem MenuActivo = null;
        private static Form FormularioActivo = null;

        // Controla si el cierre viene de "Volver al login"
        public bool cerrarPorLogin = false;

        // Flag interno para permitir el cierre luego de completar el cierre de caja
        private bool _forzarCierre = false;

        public Inicio(Usuario objusuario)
        {
            usuarioActual = objusuario;
            InitializeComponent();

            titulo.Enabled = false;
            lblusuario.Enabled = false;
            lblusuario.Text = "Usuario: " + objusuario.nombre + " " + objusuario.apellido;

            // Enganchar eventos de cierre
            this.FormClosing += Inicio_FormClosing;
            this.FormClosed += Inicio_FormClosed;
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            List<Permiso> ListaPermisos = new CN_Permiso().Listar(usuarioActual.idusuario);
            foreach (IconMenuItem iconmenu in menu.Items)
            {
                bool encontrado = ListaPermisos.Any(m => m.nombremenu.Trim().ToLower() == iconmenu.Name);
                if (encontrado == false) iconmenu.Visible = false;
            }

            lblusuario.Text = usuarioActual.nombre + " " + usuarioActual.apellido;
        }

        private void AbrirFormulario(IconMenuItem menu, Form formulario)
        {
            if (MenuActivo != null) MenuActivo.BackColor = Color.White;

            menu.BackColor = Color.Silver;
            MenuActivo = menu;

            if (FormularioActivo != null) FormularioActivo.Close();

            FormularioActivo = formulario;
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            formulario.BackColor = Color.SteelBlue;
            contenedor.Controls.Add(formulario);
            formulario.Show();
        }

        private void menuusuario_Click_1(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmUsuario());
        }

        private void submenucategoria_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menumantenedor, new frmCategoria());
        }

        private void submenuproducto_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menumantenedor, new frmProducto());
        }

        private void submenuregistrarventa_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuventas, new frmVentas(usuarioActual));
        }

        private void submenuverdetalle_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuventas, new frmDetalleVenta());
        }

        private void submenuregistrarcompra_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menucompras, new frmCompras(usuarioActual));
        }

        private void menuproveedores_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuproveedores, new frmProveedores());
        }

        private void submenuverdetallecompra_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menucompras, new frmDetalleCompra());
        }

        private void menuclientes_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmClientes());
        }

        private void menuUsuarioes_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmUsuario());
        }

        private void menureportes_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmReportes());
        }

        private void menu_ItemClicked(object sender, ToolStripItemClickedEventArgs e) { }
        private void menumantenedor_Click(object sender, EventArgs e) { }
        private void contenedor_Paint(object sender, PaintEventArgs e) { }

        private void submenunegocio_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menumantenedor, new frmNegocio());
        }

        private void tsmiVolverLogin_Click(object sender, EventArgs e)
        {
            // Señalá intención de volver a login; el login se abrirá en FormClosed
            cerrarPorLogin = true;
            this.Close(); // Dispara FormClosing -> verifica caja -> etc.
        }

        private void reporteComprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menureportes, new frmReporteCompras());
        }

        private void reporteVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menumantenedor, new frmReportesVentas());
        }

        private void menuacercade_Click(object sender, EventArgs e) { }

        private void retirosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuacercade, new btnFiltrar());
        }

        private void menuCuentaCorriente_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuventas, new frmCuentaCorriente());
        }

        private void menuCierreCaja_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuacercade, new frmCierreCaja());
        }

        private void menuAperturaCaja_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuacercade, new frmAperturaCaja());
        }

        // ==============================
        // BLOQUE 6 — Control del cierre
        // ==============================
        private void Inicio_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_forzarCierre) return; // ya autorizado
            if (e.CloseReason == CloseReason.WindowsShutDown) return;

            // ✅ validar por empleado + timestamp (NO por fecha suelta)
            int empleadoId = (Usuario.Actual != null) ? Usuario.UsuarioId() : 0;
            var ap = new CN_Caja().GetAperturaAbierta(DateTime.Now, empleadoId);

            if (ap != null)
            {
                e.Cancel = true;
                MessageBox.Show(
                    "Hay una apertura de caja abierta. Debe realizar el CIERRE DE CAJA antes de salir.",
                    "Caja abierta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                using (var frm = new frmCierreCaja())
                {
                    frm.ShowDialog(this);
                }

                // Re-chequear
                var ap2 = new CN_Caja().GetAperturaAbierta(DateTime.Now, empleadoId);
                if (ap2 == null)
                {
                    _forzarCierre = true;
                    this.BeginInvoke(new Action(() => this.Close()));
                }
            }
        }

        private void Inicio_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (cerrarPorLogin)
            {
                try
                {
                    var loginForm = new Login();
                    loginForm.Show();
                }
                catch
                {
                    // evitar romper si no existe el form Login
                }
            }
        }

        private void submenureportecaja_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuacercade, new frmCajasMaestroDetalle());
        }
    }
}
