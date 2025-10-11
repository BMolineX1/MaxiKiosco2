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
            // Cargo las columnas por codigo en ves del diseñador
            dgvdata.RowHeadersVisible = false;
            dgvdata.Columns.Clear();

            // 1 btn 
            dgvdata.Columns.Add(new DataGridViewButtonColumn()
            {
                Name = "btnseleccionar",
                HeaderText = "",
                Width = 30,
                Text = "Seleccionar",
                UseColumnTextForButtonValue = true
            });

            // Nombre de categoría
            dgvdata.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "NombreDeCategoria",
                HeaderText = "Nombre De Categoria",
                Width = 230 // más espacio
            });

            dgvdata.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Id", HeaderText = "ID", Visible = false });

            // Estado
            dgvdata.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Estado",
                HeaderText = "Estado",
                Width = 200
            });

            dgvdata.Columns.Add(new DataGridViewTextBoxColumn() { Name = "EstadoValor", HeaderText = "EstadoValor", Visible = false });

            // Porcentaje aumento
            dgvdata.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "PorcentajeAumento",
                HeaderText = "% Aumento",
                Width = 170
            });

            cboestado.Items.Add(new OpcionCombo() { Valor = 1, texto = "Activo" });
            cboestado.Items.Add(new OpcionCombo() { Valor = 0, texto = "No Activo" });
            cboestado.DisplayMember = "Texto";
            cboestado.ValueMember = "Valor";
            cboestado.SelectedIndex = 0;

            cbobusqueda.Items.Clear();
            foreach (DataGridViewColumn column in dgvdata.Columns)
            {
                if (column.Visible && column.Name != "btnseleccionar" && column.Name != "Id" && column.Name != "EstadoValor")
                {
                    cbobusqueda.Items.Add(new OpcionCombo() { Valor = column.Name, texto = column.HeaderText });
                }
            }
            cbobusqueda.DisplayMember = "Texto";
            cbobusqueda.ValueMember = "Valor";
            cbobusqueda.SelectedIndex = 0;

            dgvdata.Rows.Clear();
            List<Categoria> listaCategoria = new CN_Categoria().Listar();

            foreach (Categoria item in listaCategoria)
            {
                dgvdata.Rows.Add(new object[] {
                    "", // botón
                    item.nombre_categoria,
                    item.Id,
                    item.estado ? "Activo" : "No Activo",
                    item.estado ? 1 : 0,
                    item.porcentaje_aumento
                });
            }
        }
        
        private void Limpiar()
        {
            txtindice.Text = "-1";
            txtid.Text = "0";
            txtnombreC.Text = string.Empty;

            // Si tenés un NumericUpDown para el porcentaje:
            txtPorcentajeAumento.Value = 0;

            // Restablece el combo de estado
            if (cboestado.Items.Count > 0)
                cboestado.SelectedIndex = 0;

            // Limpia selección del DataGridView (por estética)
            dgvdata.ClearSelection();

            // Si el botón guardar cambia de texto al editar
            btnguardar.Text = "Guardar";
            btnguardar.BackColor = Color.FromArgb(0, 192, 0); // verde de nuevo, si lo usás así

            // Devuelve el foco al primer campo
            txtnombreC.Focus();
        }


        // [MODIFICADO]
        private void btnguardar_Click_1(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            decimal porcentajeAumento = 0;

            // 1. VALIDACIÓN y LECTURA del nuevo campo
            if (!decimal.TryParse(txtPorcentajeAumento.Text.Trim(), out porcentajeAumento))
            {
                MessageBox.Show("El Porcentaje de Aumento debe ser un valor numérico válido (ej. 10 o 5.5).", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Categoria objCategoria = new Categoria()
            {
                Id = Convert.ToInt32(txtid.Text),
                nombre_categoria = txtnombreC.Text,
                estado = Convert.ToInt32(((OpcionCombo)cboestado.SelectedItem).Valor) == 1 ? true : false,
                porcentaje_aumento = porcentajeAumento //nuevo para el procentaje
            };

            if (objCategoria.Id == 0)
            {
                int idCategoriagenerado = new CN_Categoria().Registrar(objCategoria, out mensaje);

                if (idCategoriagenerado != 0)
                {
                    dgvdata.Rows.Add(new object[] {
                        "",
                        txtnombreC.Text, // Revisa si el campo de texto para el nombre es realmente txtdocumento.Text
                        idCategoriagenerado,
                        ((OpcionCombo)cboestado.SelectedItem).texto.ToString(),
                        ((OpcionCombo)cboestado.SelectedItem).Valor.ToString(),
                        objCategoria.porcentaje_aumento // 🌟 CORRECCIÓN: Agregar el porcentaje de aumento
                    });
                    Limpiar();
                    MessageBox.Show("Categoría registrada con éxito.", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    row.Cells["NombreDeCategoria"].Value = txtnombreC.Text;
                    row.Cells["Id"].Value = txtid.Text;
                    row.Cells["Estado"].Value = ((OpcionCombo)cboestado.SelectedItem).texto.ToString();
                    row.Cells["EstadoValor"].Value = ((OpcionCombo)cboestado.SelectedItem).Valor.ToString();
                    row.Cells["PorcentajeAumento"].Value = objCategoria.porcentaje_aumento;

                    MessageBox.Show("Categoría editada con éxito.", "Edición Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                    txtnombreC.Text = dgvdata.Rows[indice].Cells["NombreDeCategoria"].Value.ToString();
                    // 🌟 CARGA DEL NUEVO CAMPO
                    txtPorcentajeAumento.Text = dgvdata.Rows[indice].Cells["PorcentajeAumento"].Value.ToString();

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


        private void cbobusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtbusqueda_Click(object sender, EventArgs e)
        {

        }

        private void txtbusqueda_TextChanged(object sender, EventArgs e)
        {
            // 1. Verificación de seguridad y obtención de filtros

            // Evita el error NullReferenceException si el ComboBox no se ha cargado todavía
            if (cbobusqueda.SelectedItem == null)
            {
                return;
            }

            // Obtiene la columna de la grilla que se debe usar para el filtro (ej: "Descripcion")
            string columnaFiltro = ((OpcionCombo)cbobusqueda.SelectedItem).Valor.ToString();
            string textoBusqueda = txtbusqueda.Text.Trim().ToUpper(); // Pone el texto en mayúsculas para la comparación

            // 2. Iterar y Filtrar (Mostrar/Ocultar filas)

            if (dgvdata.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvdata.Rows)
                {
                    // Omitimos la primera columna del botón seleccionar o validamos que la celda exista
                    if (row.Cells[columnaFiltro].Value != null)
                    {
                        // Convierte el valor de la celda a mayúsculas para la comparación
                        string valorCelda = row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper();

                        // 3. Mostrar u ocultar la fila si el valor de la celda contiene el texto de búsqueda
                        if (valorCelda.Contains(textoBusqueda))
                        {
                            row.Visible = true;
                        }
                        else
                        {
                            row.Visible = false;
                        }
                    }
                    // Si el texto de búsqueda está vacío, mostramos todas las filas
                    else if (string.IsNullOrEmpty(textoBusqueda))
                    {
                        row.Visible = true;
                    }
                }
            }

        }
    }
}
