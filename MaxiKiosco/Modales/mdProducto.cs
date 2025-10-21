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

            // Recorrer las columnas del DataGridView para llenar el ComboBox
            foreach (DataGridViewColumn column in dgvdata.Columns)
            {
                // El índice [0] es la columna vacía ("") que no queremos para la búsqueda, 
                // a menos que sea la columna que tiene el "Nombre".
                // Generalmente, solo mostramos las columnas visibles y relevantes.
                if (column.Visible == true && !string.IsNullOrEmpty(column.Name))
                {
                    // OpcionCombo almacena el nombre interno (Valor) y el texto visible (texto)
                    cbobusqueda.Items.Add(new OpcionCombo() { Valor = column.Name, texto = column.HeaderText });
                }
            }
            // Seleccionar el primer elemento por defecto
            cbobusqueda.SelectedIndex = 0;


            try
            {
                List<Producto> listaProducto = new CN_Producto().Listar();
                foreach (Producto item in listaProducto)
                {
                    dgvdata.Rows.Add(new object[] {
                    "",
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
                // 1. Obtener el ID y/o Código del DataGridView
                // Columna [1] es Id
                int idProductoSeleccionado = Convert.ToInt32(dgvdata.Rows[iRow].Cells[1].Value);
                // Columna [3] es Código
                string codigoProductoSeleccionado = dgvdata.Rows[iRow].Cells[3].Value?.ToString();

                // BUSCAR EL OBJETO COMPLETO DESDE LA CAPA DE NEGOCIO O LISTA INTERNA

                // Opción A (Más segura): Buscar el producto completo usando la lista que llenó el DGV.
                // Asumiendo que el modal tiene una variable List<Producto> _ListaProductos;
                Producto productoCompleto = new CN_Producto().Listar()
                    .Where(p => p.Id == idProductoSeleccionado)
                    .FirstOrDefault();

                // Opción B (Si el modal tiene la lista cargada):
                // Producto productoCompleto = _ListaProductos.Where(p => p.Id == idProductoSeleccionado).FirstOrDefault();


                if (productoCompleto != null)
                {
                    // 2. Asignar el objeto completo (que ya tiene ocategoria.porcentaje_aumento)
                    _Producto = productoCompleto;

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error: No se pudo encontrar el producto completo en la base de datos.", "Error de Datos");
                }
            }
        }


        private void btnbuscar_Click(object sender, EventArgs e)
        {
            // 1. Manejo seguro del ComboBox seleccionado
            if (cbobusqueda.SelectedItem == null)
            {
                // Si no hay opción seleccionada, simplemente salimos o mostramos un mensaje
                return;
            }

            // Convertir el item seleccionado a OpcionCombo de forma segura
            string columnaFiltro = ((OpcionCombo)cbobusqueda.SelectedItem).Valor.ToString();
            string textoBusqueda = txtbusqueda.Text.Trim().ToUpper();

            if (dgvdata.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvdata.Rows)
                {
                    // 2. Asegurarse que la celda exista y que su valor NO sea NULL antes de hacer .ToString()
                    DataGridViewCell cell = row.Cells[columnaFiltro];

                    // Asumiendo que row.Cells[columnaFiltro] es la fuente del error CS0103.
                    // La versión segura es verificar el valor de la celda.
                    var cellValue = cell.Value;

                    if (cellValue != null && cellValue.ToString().Trim().ToUpper().Contains(textoBusqueda))
                    {
                        row.Visible = true;
                    }
                    else
                    {
                        row.Visible = false;
                    }
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

        private void txtbusqueda_TextChanged(object sender, EventArgs e)
        {
            // Llama directamente al método de búsqueda, ejecutando el filtro cada vez que el texto cambie.
            btnbuscar_Click(sender, e);
        }
    }
}
