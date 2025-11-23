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
// using System.Windows.Media; // ❌ No usar en WinForms

namespace MaxiKiosco.Modales
{
    public partial class mdCliente : Form
    {
        // ✅ Propiedad dentro de la clase
        public Cliente ClienteSeleccionado { get; private set; }

        public mdCliente()
        {
            InitializeComponent();
        }

        private void mdCliente_Load(object sender, EventArgs e)
        {
            // Poblar combo de búsqueda con las columnas existentes del DataGridView
            foreach (DataGridViewColumn column in dgvdata.Columns)
            {
                cbobusqueda.Items.Add(new OpcionCombo() { Valor = column.Name, texto = column.HeaderText });
            }
            cbobusqueda.DisplayMember = "Texto";
            cbobusqueda.ValueMember = "Valor";
            cbobusqueda.SelectedIndex = 0;

            // Listar clientes
            List<Cliente> lista = new CN_Cliente().Listar();

            // Asegurate de que el DataGridView tenga 3 columnas en este orden:
            // 0: Documento/DNI, 1: Nombre, 2: Apellido
            foreach (Cliente item in lista)
            {
                if (item.estado)
                {
                    // Ajustá estos nombres a tus propiedades reales (Dni vs Documento, etc.)
                    dgvdata.Rows.Add(new object[]
                    {
                        item.dni,       // o item.Documento
                        item.nombre,    // o item.Nombre
                        item.apellido   // o item.Apellido
                    });
                }
            }
        }

        private void label13_Click(object sender, EventArgs e)
        {
            // (opcional) comportamiento al hacer click en label13
        }

        private void dgvdata_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int iRow = e.RowIndex;
            int iColumn = e.ColumnIndex;

            if (iRow >= 0 && iColumn >= 0)
            {
                // ✅ Leer por índice para evitar problemas de Name de columna
                string doc = dgvdata.Rows[iRow].Cells[0].Value?.ToString();
                string nom = dgvdata.Rows[iRow].Cells[1].Value?.ToString();
                string ape = dgvdata.Rows[iRow].Cells[2].Value?.ToString();

                // ✅ Inicializador de objeto correcto
                ClienteSeleccionado = new Cliente
                {
                    dni = doc,  // o Dni si tu entidad lo llama así
                    nombre = nom,
                    apellido = ape
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
