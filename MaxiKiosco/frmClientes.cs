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

        // [AGREGADO] Metodo para completar tabla
        private void RecargarGrillaCliente()
        {
            dgvdata.Rows.Clear();

            List<Cliente> objcliente = new CN_Cliente().Listar();

            foreach (var item in objcliente)
            {
                dgvdata.Rows.Add(new object[]{
            "",                     // Columna 0: btnseleccionar
            item.id,                // Columna 1: id (Oculta)
            item.dni,               // Columna 2: DNI/Documento
            
            item.cuit,              // Columna 3: CUIT (NUEVA POSICIÓN)
            
            item.nombre,            // Columna 4: Nombre (Se movió de 3 a 4)
            item.apellido,          // Columna 5: Apellido (Se movió de 4 a 5)
            item.email,             // Columna 6: Correo (Se movió de 5 a 6)
            item.telefono,          // Columna 7: Teléfono (Se movió de 6 a 7)
            item.domicilio,         // Columna 8: Domicilio (Se movió de 7 a 8)
            item.estado == true ? 1 : 0, // Columna 9: EstadoValor (Se movió de 8 a 9)
            item.estado == true ? "Activo" : "Inactivo", // Columna 10: Estado (Se movió de 9 a 10)
        });
            }

            // Aseguramos que la primera opción de búsqueda quede seleccionada
            if (cbobusqueda.Items.Count > 0)
            {
                cbobusqueda.SelectedIndex = 0;
            }
        }

        // [MODIFICADO]
        private void frmClientes_Load(object sender, EventArgs e)
        {
            dgvdata.RowHeadersVisible = false;//es la fila que trae por defecto en el datagrid

            cboestado.Items.Add(new OpcionCombo() { Valor = 1, texto = "Activo" });
            cboestado.Items.Add(new OpcionCombo() { Valor = 0, texto = "No Activo" });
            cboestado.DisplayMember = "texto";
            cboestado.ValueMember = "Valor";

            dgvdata.Rows.Clear();

            // 1. AGREGAR LA COLUMNA CUIT PROGRAMÁTICAMENTE (Índice 3) Debe ir después de DNI/Documento (Índice 2).
            if (!dgvdata.Columns.Contains("Cuit"))
            {
                // Insertamos en el índice 3 (después de DNI/Documento)
                dgvdata.Columns.Insert(3, new DataGridViewTextBoxColumn()
                {
                    HeaderText = "CUIT",
                    Name = "Cuit", // ¡Usamos este nombre para referenciarla!
                    Visible = true,
                    Width = 100
                });
            }
            cbobusqueda.Items.Clear(); // Limpiamos las opciones antes de rellenar

            // Rellenar el ComboBox de búsqueda
            foreach (DataGridViewColumn column in dgvdata.Columns)
            {
                if (column.Visible == true && column.Name != "btnseleccionar")
                {
                    cbobusqueda.Items.Add(new OpcionCombo() { Valor = column.Name, texto = column.HeaderText });
                }
            }

            // 2. CARGAR LOS DATOS
            RecargarGrillaCliente();
        }


        // [MODIFICADO]
        private void btnguardar_Click(object sender, EventArgs e)
        {
            string Mensaje = string.Empty;

            // [VALIDACIÓN DE CAMPOS OBLIGATORIOS MÍNIMOS EN EL FORMULARIO]
            if (string.IsNullOrWhiteSpace(txtnombre.Text) || string.IsNullOrWhiteSpace(txtapellido.Text) || string.IsNullOrWhiteSpace(txtdocumento.Text))
            {
                MessageBox.Show("Los campos Nombre, Apellido y DNI son obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // [VALIDACIÓN: NOMBRE Y APELLIDO - NO NÚMEROS]
            if (txtnombre.Text.Any(char.IsDigit) || txtapellido.Text.Any(char.IsDigit))
            {
                MessageBox.Show("El Nombre y Apellido no deben contener números.", "Advertencia de Formato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // [VALIDACIÓN 3: DNI/DOCUMENTO - Longitud y Numérico] Se permite entre 8 y 12 dígitos (para DNI o CUIL con sólo dígitos)
            if (!txtdocumento.Text.All(char.IsDigit) || txtdocumento.Text.Length < 8 || txtdocumento.Text.Length > 12)
            {
                MessageBox.Show("El Número de Documento (DNI) debe ser numérico y tener entre 8 y 12 dígitos.", "Advertencia de Documento", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // [VALIDACIÓN CONDICIONAL DE CUIT (Opcional, pero si se pone, debe ser válido)]
            if (!string.IsNullOrWhiteSpace(txtcuit.Text))
            {
                // Si CUIT tiene datos, debe tener 11 dígitos y ser numérico.
                if (txtcuit.Text.Length != 11 || !txtcuit.Text.All(char.IsDigit))
                {
                    MessageBox.Show("Si ingresa CUIT, debe ser numérico y tener exactamente 11 dígitos.", "Advertencia de CUIT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // [VALIDACIÓN DE EMAIL (Si tiene datos)]
            if (!string.IsNullOrWhiteSpace(txtcorreo.Text) && (!txtcorreo.Text.Contains("@") || !txtcorreo.Text.Contains(".")))
            {
                MessageBox.Show("El Correo Electrónico no parece tener un formato válido.", "Advertencia de Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // [VALIDACIÓN DE TELÉFONO (Si tiene datos)]
            if (!string.IsNullOrWhiteSpace(txttelefono.Text) && !txttelefono.Text.All(char.IsDigit))
            {
                MessageBox.Show("El Teléfono solo debe contener caracteres numéricos.", "Advertencia de Teléfono", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Cliente objCliente = new Cliente()
            {
                id = Convert.ToInt32(txtid.Text),
                dni = txtdocumento.Text,
                cuit = txtcuit.Text,
                nombre = txtnombre.Text,
                apellido = txtapellido.Text,
                email = txtcorreo.Text,
                telefono = txttelefono.Text,
                domicilio = txtdomicilio.Text,
                estado = Convert.ToInt32(((OpcionCombo)cboestado.SelectedItem).Valor) == 1 ? true : false,
            };


            if (objCliente.id == 0) // REGISTRAR (INSERTAR)
            {
                int idClientegenerado = new CN_Cliente().Registrar(objCliente, out Mensaje);

                if (idClientegenerado != 0)
                {
                    RecargarGrillaCliente();
                    Limpiar();
                    MessageBox.Show("Cliente registrado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(Mensaje, "Error de Registro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else // EDITAR (ACTUALIZAR)
            {
                // CORRECCIÓN CLAVE: Usar el nombre de método correcto.
                bool resultado = new CN_Cliente().EditarCliente(objCliente, out Mensaje);
                if (resultado)
                {
                    RecargarGrillaCliente();
                    Limpiar();
                    MessageBox.Show("Cliente editado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(Mensaje, "Error de Edición", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            txtdocumento.Text = ""; // Número de Documento (DNI)

            // [NUEVO CAMPO] Limpiar CUIT
            txtcuit.Text = "";

            txtdomicilio.Text = "";
            txttelefono.Text = "";
            txtcorreo.Text = "";
            cboestado.SelectedIndex = 0;
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            // Verifica que haya un registro seleccionado para eliminar
            if (Convert.ToInt32(txtid.Text) != 0)
            {
                if (MessageBox.Show("¿Está seguro que desea eliminar este cliente?", "Confirmación de Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string Mensaje = string.Empty;
                    Cliente objCliente = new Cliente()
                    {
                        id = Convert.ToInt32(txtid.Text)
                    };

                    // Llama al método correcto de la Capa de Negocio
                    bool respuesta = new CN_Cliente().EliminarCliente(objCliente, out Mensaje);

                    if (respuesta)
                    {
                        // Éxito: Recarga la tabla y limpia los campos
                        RecargarGrillaCliente();
                        Limpiar();
                        MessageBox.Show("Cliente eliminado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(Mensaje, "Error al Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un cliente para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                    // [CORRECCIÓN CRUCIAL] Usar operador de coalescencia nula (?? "") para evitar fallos

                    // Columna "id"
                    txtid.Text = dgvdata.Rows[indice].Cells["id"].Value?.ToString() ?? "";

                    // Columna DNI/Documento
                    // Ojo: Asegúrate de que el nombre de la columna sea "Documento" o el que uses en tu grilla.
                    txtdocumento.Text = dgvdata.Rows[indice].Cells["Documento"].Value?.ToString() ?? "";

                    // Columna CUIT
                    txtcuit.Text = dgvdata.Rows[indice].Cells["Cuit"].Value?.ToString() ?? "";

                    // Campos normales (también se benefician de la verificación de nulidad)
                    txtnombre.Text = dgvdata.Rows[indice].Cells["Nombre"].Value?.ToString() ?? "";
                    txtapellido.Text = dgvdata.Rows[indice].Cells["Apellido"].Value?.ToString() ?? "";
                    txttelefono.Text = dgvdata.Rows[indice].Cells["Telefono"].Value?.ToString() ?? "";
                    txtcorreo.Text = dgvdata.Rows[indice].Cells["Correo"].Value?.ToString() ?? "";
                    txtdomicilio.Text = dgvdata.Rows[indice].Cells["Domicilio"].Value?.ToString() ?? "";

                    // Cargar estado
                    foreach (OpcionCombo oc in cboestado.Items)
                    {
                        // Usamos Convert.ToString() en lugar de .Value.ToString() para manejar posibles nulos en la comparación
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtbusqueda_TextChanged(object sender, EventArgs e)
        {
            if (cbobusqueda.SelectedItem == null)
            {
                return;
            }

            // Obtiene la columna seleccionada por el usuario (ej: "Nombre", "Documento", "Apellido")
            string columnaFiltro = ((OpcionCombo)cbobusqueda.SelectedItem).Valor.ToString();
            string textoBusqueda = txtbusqueda.Text.Trim().ToUpper();

            if (dgvdata.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvdata.Rows)
                {
                    // Verifica que la celda de la columna seleccionada no sea nula
                    if (row.Cells[columnaFiltro].Value != null)
                    {
                        string valorCelda = row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper();

                        // Filtrado: Muestra si el valor de la celda CONTIENE el texto de búsqueda
                        if (valorCelda.Contains(textoBusqueda))
                        {
                            row.Visible = true;
                        }
                        else
                        {
                            row.Visible = false;
                        }
                    }
                    else if (string.IsNullOrEmpty(textoBusqueda))
                    {
                        // Si el texto de búsqueda está vacío, muestra todas las filas (incluidas las que tienen valor nulo en la columna)
                        row.Visible = true;
                    }
                }
            }
        }
    }
}
