using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
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
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            // [MODIFICADO] Cierra completamente la aplicación, terminando todos los hilos.
            // Esto es más agresivo y seguro para terminar la ejecución que solo this.Close().
            Application.Exit();
        }

        private void btningresar_Click(object sender, EventArgs e)
        {
           Usuario ousuario = new CN_Usuario().Listar().Where(u => u.cuenta_usuario == txtusuario.Text && u.contrasena == txtcontrasena.Text).FirstOrDefault();

            if (ousuario != null)
            {
                Inicio form = new Inicio(ousuario);

                this.Hide();

                form.Show();

                // 2. Suscribimos el evento FormClosed del formulario principal.
                // **Solo cerraremos el Login oculto (y la app) si el formulario Principal NO se cerró para volver al Login.**
                form.FormClosed += (s, args) =>
                {
                    // Accedemos a la variable de estado del formulario Inicio que se está cerrando
                    // El 's' es el objeto que dispara el evento (en este caso, el 'Inicio' que se cierra)
                    Inicio formCerrado = (Inicio)s;

                    // Si el cierre NO fue por el botón "Volver a Login", cerramos la aplicación.
                    if (!formCerrado.cerrarPorLogin)
                    {
                        this.Close(); // Cierra el Login oculto, terminando la aplicación.
                    }
                };
            }
            else
            {
                MessageBox.Show("No se encontro el usuario", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void frm_closing(object sender, FormClosingEventArgs e)
        {
            txtusuario.Clear();
            txtcontrasena.Clear();
            this.Show();
        }
        
    }
}
