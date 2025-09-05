using CapaDatos;
using CapaEntidad;
using CapaNegocio;
using DocumentFormat.OpenXml.Drawing.Diagrams;
using DocumentFormat.OpenXml.Spreadsheet;
using MaxiKiosco.Utilidades;
using MySql.Data.MySqlClient;
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
    public partial class frmClientes : Form
    {
        public frmClientes()
        {
            InitializeComponent();
        }
        private void frmClientes_Load(object sender, EventArgs e)
        {
            dgvdata.RowHeadersVisible = false;//es la fila que trae por defecto en el datagrid

            cboestado.Items.Add(new OpcionCombo() { Valor = 1, texto = "Activo" });
            cboestado.Items.Add(new OpcionCombo() { Valor = 0, texto = "No Activo" });
            cboestado.DisplayMember = "texto";
            cboestado.ValueMember = "Valor";
            dgvdata.Rows.Clear();
            foreach (DataGridViewColumn column in dgvdata.Columns)
            {
                if (column.Visible == true && column.Name != "btnseleccionar")
                {
                    cbobusqueda.Items.Add(new OpcionCombo() { Valor = column.Name, texto = column.HeaderText });
                }
            }
            List<Cliente> objcliente = new CN_Cliente().Listar();
            foreach (var item in objcliente)
            {
                dgvdata.Rows.Add(new object[]{
                    "",
                    item.id,
                    item.dni,
                    item.nombre,
                    item.apellido,
                    item.email,
                    item.telefono,
                    item.domicilio,
                    item.estado == true ? 1 : 0,
                    item.estado == true ? "Activo" : "Inactivo",
                });
            }
        }
        private void btnguardar_Click(object sender, EventArgs e)
        {
            string Mensaje = string.Empty;
            Cliente objcliente = new Cliente()
            {
                id = Convert.ToInt32(txtid.Text),
                nombre = txtnombre.Text,
                apellido = txtapellido.Text,
                dni = txtdocumento.Text,
                domicilio = txtdomicilio.Text,
                telefono = txttelefono.Text,
                email = txtcorreo.Text,
                estado = Convert.ToInt32(((OpcionCombo)cboestado.SelectedItem).Valor) == 1 ? true : false,
            };

            if (objcliente.id == 0)
            {
                int idclientegenerado = new CN_Cliente().Registrar(objcliente, out Mensaje);

                if (idclientegenerado != 0)
                {
                    dgvdata.Rows.Add(new object[]
                    {
                    "",
                    idclientegenerado,
                    txtnombre.Text,
                    txtapellido.Text,
                    txtdocumento.Text,
                    txtdomicilio.Text,
                    txttelefono.Text,
                    txtcorreo.Text,
                    ((OpcionCombo)cboestado.SelectedItem).Valor.ToString(),
                    ((OpcionCombo)cboestado.SelectedItem).texto.ToString(),
                    });
                    Limpiar();


                }
                else
                {
                    MessageBox.Show(Mensaje);
                }
            }
            else
            {
                bool resultado = new CN_Cliente().EditarCliente(objcliente, out Mensaje);
                if (resultado)
                {
                    DataGridViewRow row = dgvdata.Rows[Convert.ToInt32(txtindice.Text)];
                    row.Cells["Nombre"].Value = txtnombre.Text;
                    row.Cells["Apellido"].Value = txtapellido.Text;
                    row.Cells["Documento"].Value = txtdocumento.Text;
                    row.Cells["Telefono"].Value = txttelefono.Text;
                    row.Cells["Domicilio"].Value = txtdomicilio.Text;
                    row.Cells["Correo"].Value = txtcorreo.Text;
                    row.Cells["Estado"].Value = ((OpcionCombo)cboestado.SelectedItem).texto.ToString();
                    row.Cells["EstadoValor"].Value = ((OpcionCombo)cboestado.SelectedItem).Valor.ToString();

                }
                else
                {
                    MessageBox.Show(Mensaje);
                }

            }

        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        private void Limpiar()
        {
            txtindice.Text = "-1";
            txtid.Text = "0";
            txtnombre.Text = "";
            txtapellido.Text = "";
            txtdocumento.Text = "";
            txtdomicilio.Text = "";
            txttelefono.Text = "";
            txtcorreo.Text = "";
            cboestado.SelectedIndex = 0;
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtid.Text) != 0)
            {
                if (MessageBox.Show("¿Esta seguro que desea eliminar ese usuario?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string Mensaje = string.Empty;
                    Cliente objcliente = new Cliente()
                    {
                        id = Convert.ToInt32(txtid.Text)
                    };
                    bool respuesta = new CN_Cliente().EliminarCliente(objcliente, out Mensaje);
                    if (respuesta)
                    {
                        dgvdata.Rows.RemoveAt(Convert.ToInt32(txtindice.Text));
                    }
                    else
                    {
                        MessageBox.Show(Mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }


            }


        }

        private void dgvdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvdata.Columns[e.ColumnIndex].Name == "btnseleccionar")
            {
                {
                    int indice = e.RowIndex;
                    if (indice >= 0)
                    {
                        txtindice.Text = indice.ToString();
                        txtid.Text = dgvdata.Rows[indice].Cells["id"].Value.ToString();
                        txtapellido.Text = dgvdata.Rows[indice].Cells["Apellido"].Value.ToString();
                        txtnombre.Text = dgvdata.Rows[indice].Cells["Nombre"].Value.ToString();
                        txtdocumento.Text = dgvdata.Rows[indice].Cells["Documento"].Value.ToString();
                        txttelefono.Text = dgvdata.Rows[indice].Cells["Telefono"].Value.ToString();
                        txtcorreo.Text = dgvdata.Rows[indice].Cells["Correo"].Value.ToString();
                        txtdomicilio.Text = dgvdata.Rows[indice].Cells["Domicilio"].Value.ToString();
                        foreach (OpcionCombo oc in cboestado.Items)
                        {
                            if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvdata.Rows[indice].Cells["EstadoValor"].Value))
                            {
                                int indice_combo = cboestado.Items.IndexOf(oc);
                                cboestado.SelectedIndex = indice_combo;
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void dgvdata_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void cbobusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
