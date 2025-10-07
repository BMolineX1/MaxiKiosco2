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
        public Inicio(Usuario objusuario)
        {
            usuarioActual = objusuario;

            InitializeComponent();

            //titulo.ForeColor = Color.White; // Cambia el color del texto a blanco
            titulo.Enabled = false;
            //lblusuario.ForeColor = Color.White; // Cambia el color del texto a blanco
            lblusuario.Enabled = false;
            lblusuario.Text = "Usuario: " + objusuario.nombre + " " + objusuario.apellido;


        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            List<Permiso> ListaPermisos = new CN_Permiso().Listar(usuarioActual.idusuario);
            foreach (IconMenuItem iconmenu in menu.Items)
            {
                bool encontrado = ListaPermisos.Any(m => m.nombremenu.Trim().ToLower() == iconmenu.Name);
                if (encontrado == false)
                {
                    iconmenu.Visible = false;
                }

            }

            /*foreach (ToolStripMenuItem item in menu.Items)
            {
                if (item is IconMenuItem iconMenuItem)
                {
                    string nombrePrincipal = iconMenuItem.Name.Trim().ToLower();
                    bool tienePermiso = ListaPermisos.Any(p => p.nombremenu.Trim().ToLower() == nombrePrincipal);

                    if (!tienePermiso)
                        iconMenuItem.Visible = false;

                    // Revisar submenús
                    foreach (ToolStripItem subitem in iconMenuItem.DropDownItems)
                    {
                        if (subitem is IconMenuItem subIconItem)
                        {
                            string nombreSub = subIconItem.Name.Trim().ToLower();
                            bool subpermiso = ListaPermisos.Any(p => p.nombremenu.Trim().ToLower() == nombreSub);

                            if (!subpermiso)
                                subIconItem.Visible = false;
                        }
                    }
                }
            }*/
            lblusuario.Text = usuarioActual.nombre + " " + usuarioActual.apellido;
        }
        private void AbrirFormulario(IconMenuItem menu, Form formulario)
        {
            if (MenuActivo != null)
            {
                MenuActivo.BackColor = Color.White;
            }
            menu.BackColor = Color.Silver;
            MenuActivo = menu;
            if (FormularioActivo != null)
            {
                FormularioActivo.Close();
            }
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
            // Ejemplo: abrir el formulario de proveedores
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

        private void menu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void menumantenedor_Click(object sender, EventArgs e)
        {

        }

        private void contenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void submenunegocio_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menumantenedor, new frmNegocio());
        }
    }
}
