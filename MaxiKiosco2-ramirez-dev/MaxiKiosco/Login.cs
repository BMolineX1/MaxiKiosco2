using System;
using System.Linq;
using System.Windows.Forms;
using CapaNegocio;
using CapaEntidad;

namespace MaxiKiosco
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            // Si querés cerrar con ESC:
            this.KeyPreview = true;
            this.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Escape) Application.Exit();
                if (e.KeyCode == Keys.Enter) btningresar.PerformClick();
            };
        }

        private void Login_Load(object sender, EventArgs e)
        {
            // Opcional: foco inicial
            txtusuario.Focus();
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            // Cierra completamente la aplicación
            Application.Exit();
        }

        private void btningresar_Click(object sender, EventArgs e)
        {
            try
            {
                string user = (txtusuario.Text ?? "").Trim();
                string pass = (txtcontrasena.Text ?? "").Trim();

                if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
                {
                    MessageBox.Show("Ingrese usuario y contraseña.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                // ✅ Autenticar (tu lógica actual)
                Usuario ousuario = new CN_Usuario()
                    .Listar()
                    .FirstOrDefault(u => u.cuenta_usuario == user && u.contrasena == pass);

                if (ousuario == null)
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtcontrasena.Clear();
                    txtcontrasena.Focus();
                    return;
                }

                // ✅ Iniciar sesión global usando la clase Usuario (estáticos)
                Usuario.Iniciar(ousuario);

                // ✅ Abrir el formulario principal
                Inicio form = new Inicio(ousuario);

                // Ocultar login y mostrar principal
                this.Hide();
                form.Show();

                // Manejo del cierre del principal
                form.FormClosed += (s, args) =>
                {
                    // 's' es el Inicio que se cerró
                    Inicio formCerrado = (Inicio)s;

                    if (!formCerrado.cerrarPorLogin)
                    {
                        // Cierre normal de la app -> cerramos también el Login oculto
                        this.Close();
                    }
                    else
                    {
                        // Volver al Login desde el principal (por botón "Cerrar sesión" o similar)
                        Usuario.Cerrar(); // 🔒 Limpia la sesión
                        txtusuario.Clear();
                        txtcontrasena.Clear();
                        this.Show();
                        txtusuario.Focus();
                    }
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al iniciar sesión:\n" + ex.Message,
                    "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Si en algún lado ya asignaste este handler, lo dejamos por compatibilidad
        private void frm_closing(object sender, FormClosingEventArgs e)
        {
            // Esto solo se ejecutará si llamás a Close() sobre el Login directamente
            txtusuario.Clear();
            txtcontrasena.Clear();
            this.Show();
        }
    }
}
