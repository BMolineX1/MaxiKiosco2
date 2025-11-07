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
        private Image ByteToImage(byte[] imageBytes)
        {
            if (imageBytes == null || imageBytes.Length == 0) return null;

            // Validación rápida de encabezados (JPEG/PNG/GIF/BMP)
            bool headerOk =
                (imageBytes.Length > 3 && imageBytes[0] == 0xFF && imageBytes[1] == 0xD8) ||                   // JPG
                (imageBytes.Length > 7 && imageBytes[0] == 0x89 && imageBytes[1] == 0x50 && imageBytes[2] == 0x4E && imageBytes[3] == 0x47) || // PNG
                (imageBytes.Length > 5 && imageBytes[0] == 0x47 && imageBytes[1] == 0x49 && imageBytes[2] == 0x46) ||                         // GIF
                (imageBytes.Length > 1 && imageBytes[0] == 0x42 && imageBytes[1] == 0x4D);                                                     // BMP

            if (!headerOk) throw new ArgumentException("El contenido no parece ser una imagen válida (encabezado inválido).");

            // Crear imagen desde stream con validación de datos
            using (var ms = new MemoryStream(imageBytes, writable: false))
            {
                // validateImageData:true hace que lance ArgumentException si los bytes están corruptos
                var img = Image.FromStream(ms, useEmbeddedColorManagement: true, validateImageData: true);
                // Clonamos para independizarla del stream (opcional pero recomendable)
                return (Image)img.Clone();
            }
        }
        private void frmNegocio_Load(object sender, EventArgs e)
        {
            bool obtenido = true;
            byte[] imagen = new CN_Negocio().ObtenerLogo(out obtenido);

            try
            {
                if (obtenido && imagen != null && imagen.Length > 0)
                {
                    piclogo.Image?.Dispose(); // evita fugas si ya había imagen
                    piclogo.SizeMode = PictureBoxSizeMode.Zoom; // se ve mejor
                    piclogo.Image = ByteToImage(imagen);
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("No se pudo cargar el logo: " + ex.Message, "Logo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            Negocio obj = new CN_Negocio().ObtenerDatos();
            txtnombre.Text = obj?.nombre ?? "";
            txtruc.Text = obj?.ruc ?? "";
            txtdireccion.Text = obj?.direccion ?? "";
        }

        private void btnsubirlogo_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            using (var file = new OpenFileDialog())
            {
                file.Filter = "Imágenes|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                if (file.ShowDialog() == DialogResult.OK)
                {
                    byte[] byteimage = File.ReadAllBytes(file.FileName);

                    // Comprobar que realmente sea imagen antes de guardar
                    try
                    {
                        using (var prueba = ByteToImage(byteimage)) { /* si no lanza, es válida */ }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("El archivo seleccionado no es una imagen válida.\n" + ex.Message, "Logo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    bool respuesta = new CN_Negocio().ActualizarLogo(byteimage, out mensaje);
                    if (respuesta)
                    {
                        piclogo.Image?.Dispose();
                        piclogo.SizeMode = PictureBoxSizeMode.Zoom;
                        piclogo.Image = ByteToImage(byteimage);
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
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