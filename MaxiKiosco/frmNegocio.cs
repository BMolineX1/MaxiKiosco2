using CapaEntidad;
using CapaNegocio;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaxiKiosco
{
    public partial class frmNegocio : Form
    {
        public frmNegocio()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        public Image ByteToImage(byte[] imageBytes)
        {
            MemoryStream ms = new MemoryStream();
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = new Bitmap(ms);

            return image;
        }
        private void frmNegocio_Load(object sender, EventArgs e)
        {
            bool obtenido = true;
            byte[] imagen = new CN_Negocio().ObtenerLogo(out obtenido);
            if (obtenido)
            {
                if (obtenido && imagen != null && imagen.Length > 0)
                {
                    piclogo.Image = ByteToImage(imagen);
                }
            }

            Negocio obj = new CN_Negocio().ObtenerDatos();

            txtnombre.Text = obj.nombre;
            txtruc.Text = obj.ruc;
            txtdireccion.Text = obj.direccion;

        }

        private void btnsubirlogo_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";

            if (file.ShowDialog() == DialogResult.OK)
            {
                byte[] byteimage = File.ReadAllBytes(file.FileName);
                bool respuesta = new CN_Negocio().ActualizarLogo(byteimage, out mensaje);
                if (respuesta)
                {
                    piclogo.Image = ByteToImage(byteimage);
                }
                else
                {
                    MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            Negocio obj = new Negocio()
            {
                nombre = txtnombre.Text,
                ruc = txtruc.Text,
                direccion = txtdireccion.Text
            };
            bool respuesta = new CN_Negocio().GuardarDatos(obj, out mensaje);
            if (respuesta)
            {
                MessageBox.Show("Los datos se guardaron correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}