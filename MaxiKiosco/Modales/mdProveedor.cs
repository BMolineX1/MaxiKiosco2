using CapaEntidad;
using CapaDatos;
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
using MaxiKiosco;


namespace MaxiKiosco.Modales
{
    public partial class mdProveedor : Form
    {
        public Proveedor _Proveedor { get; set; }
        public mdProveedor()
        {
            InitializeComponent();
        }

        private void mdProveedor_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn column in dgvdata.Columns)
            {
                if (column.Visible == true)
                {
                    cbobusqueda.Items.Add(new OpcionCombo() { Valor = column.Name, texto = column.HeaderText });
                }
            }

            // FILTRAR SOLO PROVEEDORES QUE TENGAN RAZON SOCIAL, Declarar y cargar la lista completa de proveedores
            List<Proveedor> objProveedor = new CN_Proveedor().Listar();
            List<Proveedor> proveedoresFiltrados = objProveedor
                .Where(p => !string.IsNullOrWhiteSpace(p.razonsocial))
                .ToList();

            foreach (var item in proveedoresFiltrados)
            {
                dgvdata.Rows.Add(new object[]{
                    "",
                    item.id,
                    item.nombre,
                    item.razonsocial,
                });
            }
        }

        private void dgvdata_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int iRow = e.RowIndex;

            // La condición iColum > 0 es correcta si la columna 0 es el botón de acción
            if (iRow >= 0 /* && e.ColumnIndex > 0 */)
            {
                DataGridViewRow row = dgvdata.Rows[iRow];

                try
                {
                    _Proveedor = new Proveedor()
                    {
                        // USAMOS EL ÍNDICE BASADO EN CÓMO CARGASTE LOS DATOS ARRIBA
                        // Posición 1 (item.id)
                        id = Convert.ToInt32(row.Cells[1].Value.ToString()),
                        // Posición 2 (item.nombre)
                        nombre = row.Cells[2].Value.ToString(),
                        // Posición 3 (item.razonsocial)
                        razonsocial = row.Cells[3].Value.ToString()
                    };

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    // Si hay un error de conversión o índice, te avisará
                    MessageBox.Show($"Error al cargar datos del proveedor: {ex.Message}\nAsegúrese que la columna de ID (índice 1) es numérica.",
                                    "Error de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            // 1. Manejo seguro del ComboBox seleccionado
            OpcionCombo oc = cbobusqueda.SelectedItem as OpcionCombo;
            if (oc == null) return; // Si no hay nada seleccionado, salir

            string columnaFiltro = oc.Valor.ToString();
            string textoBusqueda = txtbusqueda.Text.Trim().ToUpper();

            if (dgvdata.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvdata.Rows)
                {
                    // 2. Asegurarse que la celda exista y que su valor NO sea NULL antes de hacer .ToString()
                    var cellValue = row.Cells[columnaFiltro].Value;

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


        //[AGREGADO] Buscar proveedores en tiempo real
        private void txtbusqueda_TextChanged_1(object sender, EventArgs e)
        {
            // Llama directamente al método de búsqueda que ya funciona
            btnbuscar_Click(sender, e);
        }
    }
}
