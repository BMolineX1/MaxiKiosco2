using CapaEntidad;
using CapaNegocio;
using ClosedXML.Excel;
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
    public partial class frmProducto : Form
    {
        public frmProducto()
        {
            InitializeComponent();
        }
        private void frmProducto_Load(object sender, EventArgs e)
        {



            dgvdata.RowHeadersVisible = false;
            cboestado.Items.Add(new OpcionCombo() { Valor = 1, texto = "Activo" });
            cboestado.Items.Add(new OpcionCombo() { Valor = 0, texto = "No Activo" });
            cboestado.DisplayMember = "texto";
            cboestado.ValueMember = "Valor";
            cboestado.SelectedIndex = 0;
            dgvdata.Rows.Clear(); // Limpia la grilla
            List<Categoria> listaCategoria = new CN_Categoria().Listar();
            foreach (var item in listaCategoria)
            {

                cbocategoria.Items.Add(new OpcionCombo() { Valor = item.Id, texto = item.nombre_categoria });
            }
            
            cboproductos.Items.Add(new OpcionCombo() { Valor = "", texto = "Elija una opcion" });
            cboproductos.DisplayMember = "texto";
            cboproductos.ValueMember = "Valor";
            cboproductos.SelectedIndex = 0;

            foreach (DataGridViewColumn column in dgvdata.Columns)
            {
                if (column.Visible == true && column.Name != "btnseleccionar")
                {

                    cbobusqueda.Items.Add(new OpcionCombo() { Valor = column.Name, texto = column.HeaderText });
                }
            }
            cbobusqueda.DisplayMember = "texto";
            cbobusqueda.ValueMember = "Valor";
            cbobusqueda.SelectedIndex = 0;

            //mostrar todos los productos
            dgvdata.Rows.Clear(); // Limpia la grilla
            try
            {
                List<Producto> listaProducto = new CN_Producto().Listar();
                foreach (Producto item in listaProducto)
                {
                    dgvdata.Rows.Add(new object[] {
            "",
            item.Id,
            item.nombre,
            item.codigo,

            item.preciocompra,
            item.precioventa,
            item.descripcion,
            item.ocategoria.nombre_categoria,
            item.ocategoria.Id,
            item.stock,
            item.estado == true ? 1 : 0,
            item.estado == true ? "Activo" : "Inactivo",
        });
                }
            }



            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos: " + ex.Message);
            }
        }
        private void Limpiar()
        {
            txtindice.Text = "-1";
            txtid.Text = "0";
            txtnombre.Text = "";
            txtdescripcion.Text = "";
            txtprecioventa.Text = "";
            txtpreciocompra.Text = "";
            txtstock.Text = "";
            txtcodigo.Text = "";
            cbocategoria.SelectedIndex = 0;
            cboestado.SelectedIndex = 0;

            txtdocumento.Select();
        }
        //propiedades para el check

        //Al hacer click en el check nos va a traer los datos en los txt

        private void btnguardar_Click_1(object sender, EventArgs e)
        {

            string mensaje = string.Empty;
            Producto objproducto = new Producto()
            {
                Id = Convert.ToInt32(txtidproducto.Text),
                nombre = txtnombre.Text,
                codigo = txtcodigo.Text,

                precioventa = Convert.ToDecimal(txtprecioventa.Text),
                preciocompra = Convert.ToDecimal(txtpreciocompra.Text),
                descripcion = txtdescripcion.Text,

                ocategoria = new Categoria() { Id = Convert.ToInt32(((OpcionCombo)cbocategoria.SelectedItem).Valor) },
                stock = Convert.ToInt32(txtstock.Text),
                estado = Convert.ToInt32(((OpcionCombo)cboestado.SelectedItem).Valor) == 1 ? true : false,


            };
            if (objproducto.Id == 0)
            {
                int idusuariogenerado = new CN_Producto().Registrar(objproducto, out mensaje);

                if (idusuariogenerado != 0)
                {
                    dgvdata.Rows.Add(new object[] {"",
                    idusuariogenerado,
                    txtnombre.Text,
                    txtcodigo.Text,

                    txtprecioventa.Text,
                    txtpreciocompra.Text,
                    txtdescripcion.Text,
                ((OpcionCombo)cbocategoria.SelectedItem).texto.ToString(),
                ((OpcionCombo)cbocategoria.SelectedItem).Valor.ToString(),
                txtstock.Text,
                ((OpcionCombo)cboestado.SelectedItem).Valor.ToString(),
                ((OpcionCombo)cboestado.SelectedItem).texto.ToString(),



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
                bool resultado = new CN_Producto().Editar(objproducto, out mensaje);

                if (resultado)
                {
                    DataGridViewRow row = dgvdata.Rows[Convert.ToInt32(txtindice.Text)];
                    row.Cells["id"].Value = txtid.Text;
                    row.Cells["Nombre"].Value = txtnombre.Text;
                    row.Cells["Codigo"].Value = txtcodigo.Text;

                    row.Cells["PrecioDeCompra"].Value = txtpreciocompra.Text;
                    row.Cells["PrecioDeVenta"].Value = txtprecioventa.Text;
                    row.Cells["Descripcion"].Value = txtdescripcion.Text;
                    row.Cells["Stock"].Value = txtstock.Text;
                    row.Cells["Categoria"].Value = ((OpcionCombo)cbocategoria.SelectedItem).texto.ToString();
                    row.Cells["idcategoria"].Value = ((OpcionCombo)cbocategoria.SelectedItem).Valor.ToString();
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

        private void btneliminar_Click_1(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtid.Text) != 0)
            {
                if (MessageBox.Show("¿Desea eliminar el producto?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    string mensaje = string.Empty;
                    Producto objproducto = new Producto()
                    {
                        Id = Convert.ToInt32(txtid.Text)
                    };
                    bool respuesta = new CN_Producto().Eliminar(objproducto, out mensaje);
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

        private void btnlimpiar_Click_1(object sender, EventArgs e)
        {
            Limpiar();
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
                    txtid.Text = dgvdata.Rows[indice].Cells["id"].Value.ToString();
                    txtnombre.Text = dgvdata.Rows[indice].Cells["Nombre"].Value.ToString();
                    txtcodigo.Text = dgvdata.Rows[indice].Cells["Codigo"].Value.ToString();

                    txtdescripcion.Text = dgvdata.Rows[indice].Cells["Descripcion"].Value.ToString();
                    txtpreciocompra.Text = dgvdata.Rows[indice].Cells["PrecioDeCompra"].Value.ToString();
                    txtprecioventa.Text = dgvdata.Rows[indice].Cells["PrecioDeVenta"].Value.ToString();
                    txtstock.Text = dgvdata.Rows[indice].Cells["Stock"].Value.ToString();

                    foreach (OpcionCombo oc in cbocategoria.Items)
                    {
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvdata.Rows[indice].Cells["idcategoria"].Value))
                        {
                            int indice_combo = cbocategoria.Items.IndexOf(oc);
                            cbocategoria.SelectedIndex = indice_combo;
                        }
                    }
                }
            }

        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            string columnaFiltro = ((OpcionCombo)cbobusqueda.SelectedItem).Valor.ToString();
            if (dgvdata.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvdata.Rows)
                {
                    if (row.Cells[columnaFiltro].Value != null &&
                        row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(txtbusquedaproducto.Text.Trim().ToUpper()))


                        row.Visible = true;
                    else
                        row.Visible = false;
                }
            }


        }
        private void iconButton3_Click(object sender, EventArgs e)
        {
            txtbusquedaproducto.Text = "";
            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                row.Visible = true;
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (dgvdata.Rows.Count < 1)
            {
                MessageBox.Show("No hay datos para exportar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                DataTable dt = new DataTable();
                foreach (DataGridViewColumn columna in dgvdata.Columns)
                {
                    if (columna.HeaderText != "" && columna.Visible)
                    {
                        dt.Columns.Add(columna.HeaderText, typeof(string));
                    }

                }
                foreach (DataGridViewRow row in dgvdata.Rows)
                {
                    if (row.Visible)
                    {
                        dt.Rows.Add(new object[]
                        {
                            row.Cells[2].Value.ToString(),
                            row.Cells[3].Value.ToString(),
                            row.Cells[4].Value.ToString(),
                            row.Cells[5].Value.ToString(),
                            row.Cells[6].Value.ToString(),
                            row.Cells[7].Value.ToString(),
                            row.Cells[9].Value.ToString(),
                            row.Cells[11].Value.ToString()
                        });
                    }
                }
                //codigo para crear el archivo excel de los productos
                // descargue la libreria XLWorkbook
                SaveFileDialog savefile = new SaveFileDialog();
                savefile.FileName = string.Format("ReporteProducto_(0).xlsx", DateTime.Now.ToString("ddMMyyyyHHmm"));
                savefile.Filter = "Excel Files | *.xlsx";
                if (savefile.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        XLWorkbook wb = new XLWorkbook();
                        var hoja = wb.Worksheets.Add(dt, "Informe");
                        hoja.ColumnsUsed().AdjustToContents();
                        wb.SaveAs(savefile.FileName);
                        MessageBox.Show("Reporte Generado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        MessageBox.Show("Error el generar el reporte", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        private void txtbusquedaproducto_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbocategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}