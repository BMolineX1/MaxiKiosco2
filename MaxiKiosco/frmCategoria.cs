using CapaDatos;
using CapaEntidad;
using CapaNegocio;
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

namespace MaxiKiosco
{
    public partial class frmCategoria : Form
    {
        public frmCategoria()
        {
            InitializeComponent();
        }
        private void frmCategoria_Load(object sender, EventArgs e)
        {
            dgvdata.RowHeadersVisible = false;
            cboestado.Items.Add(new OpcionCombo() { Valor = 1, texto = "Activo" });
            cboestado.Items.Add(new OpcionCombo() { Valor = 0, texto = "No Activo" });
            cboestado.DisplayMember = "Texto";
            cboestado.ValueMember = "Valor";
            cboestado.SelectedIndex = 0;
            dgvdata.Rows.Clear(); // Limpia la grilla
            foreach (DataGridViewColumn column in dgvdata.Columns)
            {
                if (column.Visible == true && column.Name != "btnseleccionar")
                {
                    cbobusqueda.Items.Add(new OpcionCombo() { Valor = column.Name, texto = column.HeaderText });
                }
            }
            cbobusqueda.DisplayMember = "Texto";
            cbobusqueda.ValueMember = "Valor";
            cbobusqueda.SelectedIndex = 0;

            //mostrar todos los Categorias
            dgvdata.Rows.Clear(); // Limpia la grilla
            List<Categoria> listaCategoria = new CN_Categoria().Listar();
            foreach (Categoria item in listaCategoria)
            {
                dgvdata.Rows.Add(new object[] {
                    "",
                    item.nombre_categoria,
                    item.Id,
                    item.estado == true ? "Activo" : "Inactivo",
                    item.estado == true ? 1 : 0,

            });
            }
        }
        private void Limpiar()
        {
            txtindice.Text = "-1";
            txtid.Text = "0";
            txtdocumento.Text = "";
            cboestado.SelectedIndex = 0;


            txtdocumento.Select();
        }
        //Al hacer click en el check nos va a traer los datos en los txt
        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnguardar_Click_1(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            Categoria objCategoria = new Categoria()
            {
                Id = Convert.ToInt32(txtid.Text),
                nombre_categoria = txtdocumento.Text,
                estado = Convert.ToInt32(((OpcionCombo)cboestado.SelectedItem).Valor) == 1 ? true : false,
            };
            if (objCategoria.Id == 0)
            {
                int idCategoriagenerado = new CN_Categoria().Registrar(objCategoria, out mensaje);

                if (idCategoriagenerado != 0)
                {
                    dgvdata.Rows.Add(new object[] {"",
                        txtdocumento.Text,
                        idCategoriagenerado,
                        ((OpcionCombo)cboestado.SelectedItem).texto.ToString(),
                        ((OpcionCombo)cboestado.SelectedItem).Valor.ToString(),
                });
                    Limpiar();
                }
                else
                {
                    MessageBox.Show(mensaje);
                }
            }
            else
            {
                bool resultado = new CN_Categoria().Editar(objCategoria, out mensaje);
                if (resultado)
                {
                    DataGridViewRow row = dgvdata.Rows[Convert.ToInt32(txtindice.Text)];
                    row.Cells["NombreDeCategoria"].Value = txtdocumento.Text;
                    row.Cells["Id"].Value = txtid.Text;
                    row.Cells["Estado"].Value = ((OpcionCombo)cboestado.SelectedItem).texto.ToString();
                    row.Cells["EstadoValor"].Value = ((OpcionCombo)cboestado.SelectedItem).Valor.ToString();
                    Limpiar();
                }
                else
                {
                    MessageBox.Show(mensaje);
                }
            }
        }
        private void btnlimpiar_Click_1(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btneliminar_Click_1(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtid.Text) != 0)
            {
                if (MessageBox.Show("¿Desea eliminar el Categoria?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string mensaje = string.Empty;
                    Categoria objCategoria = new Categoria()
                    {
                        Id = Convert.ToInt32(txtid.Text)
                    };
                    bool respuesta = new CN_Categoria().Eliminar(objCategoria, out mensaje);
                    if (respuesta)
                    {
                        dgvdata.Rows.RemoveAt(Convert.ToInt32(txtindice.Text));
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        private void dgvdata_CellPainting_1(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if (e.ColumnIndex == 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                int w = 24;
                int h = 24;
                int x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                int y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;
                e.Graphics.DrawImage(Properties.Resources.checkpng, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        private void dgvdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvdata.Columns[e.ColumnIndex].Name == "btnseleccionar")
            {
                int indice = e.RowIndex;

                if (indice >= 0)
                {
                    txtindice.Text = indice.ToString();

                    txtid.Text = dgvdata.Rows[indice].Cells["Id"].Value.ToString();
                    txtdocumento.Text = dgvdata.Rows[indice].Cells["NombreDeCategoria"].Value.ToString();

                    foreach (OpcionCombo oc in cboestado.Items)
                    {
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvdata.Rows[indice].Cells["EstadoValor"].Value))
                        {

                            int indice_combo = cboestado.Items.IndexOf(oc);
                            cboestado.SelectedIndex = indice_combo;

                        }
                    }

                }
            }
        }

        private void btnbuscar2_Click_1(object sender, EventArgs e)
        {
            string columnaFiltro = ((OpcionCombo)cbobusqueda.SelectedItem).Valor.ToString();
            if (dgvdata.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvdata.Rows)
                {
                    if (row.Cells[columnaFiltro].Value != null &&
                        row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(txtbusqueda.Text.Trim().ToUpper()))

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

        private void dgvdata_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cbobusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtbusqueda_Click(object sender, EventArgs e)
        {

        }
    }
}
