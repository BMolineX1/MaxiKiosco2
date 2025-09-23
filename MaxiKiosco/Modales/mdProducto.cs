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


            //mostrar todos los productos
            dgvdata.Rows.Clear(); // Limpia la grilla
            try
            {
                List<Producto> listaProducto = new CN_Producto().Listar();
                foreach (Producto item in listaProducto)
                {
                    dgvdata.Rows.Add(new object[] {
            item.Id,
            item.codigo,
            item.nombre,
            
            
            item.preciocompra,
            item.precioventa,
            item.ocategoria.nombre_categoria,
            item.stock
            
                  });
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void dgvdata_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int iRow = e.RowIndex;
            int iColum = e.ColumnIndex;

            if (iRow >= 0 && iColum > 0)
            {
                _Producto = new Producto()
                {
                    Id = Convert.ToInt32(dgvdata.Rows[iRow].Cells[0].Value),
                    nombre = dgvdata.Rows[iRow].Cells[1].Value.ToString(),
                    codigo = dgvdata.Rows[iRow].Cells[2].Value.ToString(),
                    precioventa = Convert.ToDecimal(dgvdata.Rows[iRow].Cells[3].Value),
                    preciocompra = Convert.ToDecimal(dgvdata.Rows[iRow].Cells[4].Value),
                    stock = Convert.ToInt16(dgvdata.Rows[iRow].Cells[5].Value)
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
