using CapaDatos;
using CapaEntidad;
using CapaNegocio;
using DocumentFormat.OpenXml.Bibliography;
using MaxiKiosco.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaxiKiosco.Modales
{
    public partial class mdProducto : Form
    {
        public Producto _Producto { get; set; }
        public mdProducto()
        {
            InitializeComponent();
        }

        private void mdProducto_Load(object sender, EventArgs e)
        {
            dgvdata.Rows.Clear(); // Limpia la grilla
            try
            {
                List<Producto> listaProducto = new CN_Producto().Listar();
                foreach (Producto item in listaProducto)
                {
                    dgvdata.Rows.Add(new object[] {
                item.Id,                          // 0 → Id
                item.nombre,                      // 1 → Nombre
                item.codigo,                      // 2 → Código
                item.ocategoria.nombre_categoria, // 3 → Categoría
                item.preciocompra,                // 4 → Precio de compra
                item.precioventa,                 // 5 → Precio de venta
                item.stock                        // 6 → Stock
            });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos: " + ex.Message);
            }
        }

        private void dgvdata_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int iRow = e.RowIndex;

            if (iRow >= 0)
            {
                // Variables seguras para conversión
                decimal precioCompra = decimal.TryParse(dgvdata.Rows[iRow].Cells[4].Value?.ToString(), out var pc) ? pc : 0;
                decimal precioVenta = decimal.TryParse(dgvdata.Rows[iRow].Cells[5].Value?.ToString(), out var pv) ? pv : 0;
                int stock = int.TryParse(dgvdata.Rows[iRow].Cells[6].Value?.ToString(), out var s) ? s : 0;

                // Crear objeto Producto
                _Producto = new Producto()
                {
                    Id = Convert.ToInt32(dgvdata.Rows[iRow].Cells[0].Value),
                    nombre = dgvdata.Rows[iRow].Cells[1].Value?.ToString(),
                    codigo = dgvdata.Rows[iRow].Cells[2].Value?.ToString(),
                    
                    preciocompra = precioCompra,
                    precioventa = precioVenta,
                    stock = stock,
                    ocategoria = new Categoria()
                    {
                        nombre_categoria = dgvdata.Rows[iRow].Cells[3].Value?.ToString()
                    },
                };

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }


        private void btnbuscar_Click(object sender, EventArgs e)
        {
            string columnaFiltro = ((OpcionCombo)cbobusqueda.SelectedItem).Valor.ToString();
            if (dgvdata.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvdata.Rows)
                {
                    if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(txtbusqueda.Text.Trim().ToUpper()))

                        row.Visible = true;
                    else
                        row.Visible = false;
                }
            }

        }

        private void btnlimpiarbuscador_Click(object sender, EventArgs e)
        {
            txtbusqueda.Text = "";
            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                row.Visible = true;
            }
        }
    }
}
