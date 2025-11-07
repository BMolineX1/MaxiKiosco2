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
                dgvdata.Rows.Add(new object[] {
                    // --- PARTE 1: DATOS PARA LAS COLUMNAS CREADAS EN EL DISEÑADOR ---
                    // Este orden DEBE coincidir con el orden de tus columnas en el diseñador.
                    "",                                          // 0. btnSeleccionar
                    item.id,                                     // 1. Id (oculta)
                    item.dni,                                    // 2. Numero de Documento
                    item.nombre,                                 // 3. Nombre
                    item.apellido,                               // 4. Apellido
                    item.email,                                  // 5. Correo
                    item.telefono,                               // 6. Telefono
                    item.domicilio,                              // 7. Domicilio
                    item.estado == true ? 1 : 0,
                    item.estado == true ? "Activo" : "Inactivo", // 8. Estado
                    item.cuit ?? "",                             // 9. CUIT
                    item.razonsocial ?? "",                      // 10. Razón Social
                    item.condicion_iva ?? "",                    // 11. Condición IVA
                    item.tipo_cliente ?? "",                     // 12. Tipo Cliente
                    item.estado == true ? 1 : 0                  // 13. EstadoValor (oculta)
                });
            }

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

            // 1. LLENAR COMBOBOX DE TIPO DE CLIENTE (ENUM: 'Mayorista', 'Minorista')
            cboTipoCliente.Items.Add(new OpcionCombo() { Valor = 0, texto = "Minorista" });
            cboTipoCliente.Items.Add(new OpcionCombo() { Valor = 1, texto = "Mayorista" });
            cboTipoCliente.DisplayMember = "Texto";
            cboTipoCliente.ValueMember = "Valor";
            cboTipoCliente.SelectedIndex = 0;

            // 2. LLENAR COMBOBOX DE CONDICIÓN FRENTE AL IVA (ENUM: 'Responsable Inscripto', 'Monotributista', 'Consumidor Final', 'Exento')
            cboCondicionIVA.Items.Add(new OpcionCombo() { Valor = 0, texto = "Responsable Inscripto" });
            cboCondicionIVA.Items.Add(new OpcionCombo() { Valor = 1, texto = "Monotributista" });
            cboCondicionIVA.Items.Add(new OpcionCombo() { Valor = 2, texto = "Consumidor Final" });
            cboCondicionIVA.Items.Add(new OpcionCombo() { Valor = 3, texto = "Exento" });
            cboCondicionIVA.DisplayMember = "Texto";
            cboCondicionIVA.ValueMember = "Valor";
            cboCondicionIVA.SelectedIndex = 2; // Sugerencia: Empezar en Consumidor Final, ya que es el más común.

            dgvdata.Rows.Clear();
            // 
            // 1.1. CUIT (Insertamos en el índice 3)
            if (!dgvdata.Columns.Contains("Cuit"))
            {
                dgvdata.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    HeaderText = "CUIT",
                    Name = "Cuit",
                    Visible = true,
                    Width = 100
                });
            }
            // 1.2. Razón Social
            if (!dgvdata.Columns.Contains("RazonSocial"))
            {
                dgvdata.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    Name = "RazonSocial",
                    HeaderText = "Razón Social",
                    Width = 150,
                    Visible = true
                });
            }

            // 1.3. Condición IVA
            if (!dgvdata.Columns.Contains("CondicionIVA"))
            {
                dgvdata.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    Name = "CondicionIVA",
                    HeaderText = "Condición IVA",
                    Width = 150,
                    Visible = true
                });
            }

            // 1.4. Tipo Cliente
            if (!dgvdata.Columns.Contains("TipoCliente"))
            {
                dgvdata.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    Name = "TipoCliente",
                    HeaderText = "Tipo Cliente",
                    Width = 100,
                    Visible = true
                });
            }
            // 1.5. EstadoValor (Columna Oculta)
            if (!dgvdata.Columns.Contains("EstadoValor"))
            {
                dgvdata.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    Name = "EstadoValor",
                    HeaderText = "",
                    Width = 0,
                    Visible = false
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
            RecargarGrillaCliente(); // Usamos RecargarGrillaCliente (que se ve más completo)
        }

        // [MODIFICADO]
        private void btnguardar_Click(object sender, EventArgs e)
        {
            string Mensaje = string.Empty;
            string condicionIVA = cboCondicionIVA.Text.Trim();
            string tipoCliente = cboTipoCliente.Text.Trim();
            string cuit = txtcuit.Text.Trim();
            string razonSocial = txtrazonSocial.Text.Trim();

            // [AGREGAR] esta validacion es crucial para el registro o edicion del cliente.
            // [Validación fiscal principal: según condición IVA]
            if (condicionIVA == "Responsable Inscripto" || condicionIVA == "Monotributista")
            {
                if (string.IsNullOrWhiteSpace(cuit))
                {
                    MessageBox.Show("El CUIT es obligatorio para esta condición IVA.", "Error de Edición", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(razonSocial))
                {
                    MessageBox.Show("La Razón Social es obligatoria para esta condición IVA.", "Error de Edición", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                // Los demás (Exento, Consumidor Final) no necesitan CUIT ni Razón Social
                txtcuit.Text = "";
                txtrazonSocial.Text = "";
            }

            // [VALIDACIÓN DE CAMPOS OBLIGATORIOS MÍNIMOS]
            if (string.IsNullOrWhiteSpace(txtnombre.Text) ||
                string.IsNullOrWhiteSpace(txtapellido.Text) ||
                string.IsNullOrWhiteSpace(txtdocumento.Text))
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

            // [VALIDACIÓN DNI/DOCUMENTO] DNI numérico y longitud
            if (!txtdocumento.Text.All(char.IsDigit) || txtdocumento.Text.Length < 8 || txtdocumento.Text.Length > 12)
            {
                MessageBox.Show("El DNI debe ser numérico y tener entre 8 y 12 dígitos.", "Advertencia de Documento", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // [5️⃣ Validación CUIT solo si se ingresó algo]
            if (!string.IsNullOrWhiteSpace(cuit))
            {
                if (cuit.Length != 11 || !cuit.All(char.IsDigit))
                {
                    MessageBox.Show("El CUIT debe tener exactamente 11 dígitos numéricos.", "Advertencia de CUIT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // [ Condición IVA y Tipo Cliente obligatorios]
            if (cboCondicionIVA.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar una Condición de IVA.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboTipoCliente.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un Tipo de Cliente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // [Validación de correo electrónico]
            if (!string.IsNullOrWhiteSpace(txtcorreo.Text) &&
                (!txtcorreo.Text.Contains("@") || !txtcorreo.Text.Contains(".")))
            {
                MessageBox.Show("El formato del correo electrónico no es válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // [8️⃣ Teléfono numérico]
            if (!string.IsNullOrWhiteSpace(txttelefono.Text) && !txttelefono.Text.All(char.IsDigit))
            {
                MessageBox.Show("El teléfono solo debe contener números.", "Advertencia de Teléfono", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // [CREAR OBJETO CLIENTE]
            Cliente objCliente = new Cliente()
            {
                id = Convert.ToInt32(txtid.Text),
                dni = txtdocumento.Text.Trim(),
                cuit = txtcuit.Text.Trim(),
                nombre = txtnombre.Text.Trim(),
                apellido = txtapellido.Text.Trim(),
                email = txtcorreo.Text.Trim(),
                telefono = txttelefono.Text.Trim(),
                domicilio = txtdomicilio.Text.Trim(),
                razonsocial = txtrazonSocial.Text.Trim(),
                condicion_iva = cboCondicionIVA.Text,
                tipo_cliente = cboTipoCliente.Text,
                estado = Convert.ToInt32(((OpcionCombo)cboestado.SelectedItem).Valor) == 1
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

            // ⬇️ Limpieza de NUEVOS CAMPOS FISCALES ⬇️
            txtcuit.Text = "";
            txtrazonSocial.Text = ""; // 👈 ¡ESTE ES EL CAMPO QUE PROBABLEMENTE FALTABA!

            txtdomicilio.Text = "";
            txttelefono.Text = "";
            txtcorreo.Text = "";

            // Restaurar ComboBox al primer elemento (Asumo que el índice 0 es el valor por defecto)
            cboCondicionIVA.SelectedIndex = 0; // Restaurar Condición IVA
            cboTipoCliente.SelectedIndex = 0;  // Restaurar Tipo Cliente
            cboestado.SelectedIndex = 0;

            // Opcional: Centrar el foco
            txtdocumento.Focus();
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

                    // Usa el operador de coalescencia nula (?? "") para evitar NullReferenceException
                    // Columna "id"
                    txtid.Text = dgvdata.Rows[indice].Cells["id"].Value?.ToString() ?? "";

                    // Columna DNI/Documento
                    // Ojo: Asegúrate de que el nombre de la columna sea "Documento" o el que uses en tu grilla.
                    txtdocumento.Text = dgvdata.Rows[indice].Cells["Documento"].Value?.ToString() ?? "";

                    // Columna CUIT
                    txtcuit.Text = dgvdata.Rows[indice].Cells["Cuit"].Value?.ToString() ?? "";
                    // ⬅️ Carga de Nuevos Campos ⬅️
                    txtrazonSocial.Text = dgvdata.Rows[indice].Cells["RazonSocial"].Value?.ToString() ?? ""; // Usar ?. en vez de .

                    // Campos normales (también se benefician de la verificación de nulidad)
                    txtnombre.Text = dgvdata.Rows[indice].Cells["Nombre"].Value?.ToString() ?? "";
                    txtapellido.Text = dgvdata.Rows[indice].Cells["Apellido"].Value?.ToString() ?? "";
                    txttelefono.Text = dgvdata.Rows[indice].Cells["Telefono"].Value?.ToString() ?? "";
                    txtcorreo.Text = dgvdata.Rows[indice].Cells["Correo"].Value?.ToString() ?? "";
                    txtdomicilio.Text = dgvdata.Rows[indice].Cells["Domicilio"].Value?.ToString() ?? "";

                    // Cargar y seleccionar CONDICIÓN IVA
                    string condicionIVA_Texto = dgvdata.Rows[indice].Cells["CondicionIVA"].Value?.ToString() ?? ""; // Asegurar que no sea null
                    foreach (OpcionCombo oc in cboCondicionIVA.Items)
                    {
                        if (oc.texto.ToString() == condicionIVA_Texto)
                        {
                            cboCondicionIVA.SelectedIndex = cboCondicionIVA.Items.IndexOf(oc);
                            break;
                        }
                    }

                    // Cargar y seleccionar TIPO CLIENTE
                    string tipoCliente_Texto = dgvdata.Rows[indice].Cells["TipoCliente"].Value?.ToString() ?? ""; // Asegurar que no sea null
                    foreach (OpcionCombo oc in cboTipoCliente.Items)
                    {
                        if (oc.texto.ToString() == tipoCliente_Texto)
                        {
                            cboTipoCliente.SelectedIndex = cboTipoCliente.Items.IndexOf(oc);
                            break;
                        }
                    }

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

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
