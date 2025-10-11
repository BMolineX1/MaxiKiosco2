using CapaDatos;
using CapaEntidad;
using CapaNegocio;
using MaxiKiosco.Utilidades;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Cms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;// ⬅️ ¡Esta línea es obligatoria!
using System.Threading.Tasks;
using System.Windows.Forms;
namespace MaxiKiosco
{
    public partial class frmUsuario : Form
    {
        public frmUsuario()
        {
            InitializeComponent();
        }

        // Dentro de la clase frmUsuario
        private void CargarUsuarios()
        {
            // 1. Limpia la grilla antes de cargar nuevos datos
            dgvdata.Rows.Clear();

            // 2. Obtiene la lista de usuarios
            List<Usuario> listaUsuario = new CN_Usuario().Listar();

            // 3. Itera y añade cada usuario a la grilla
            foreach (Usuario item in listaUsuario)
            {
                dgvdata.Rows.Add(new object[] {
                    "",
                    item.idusuario,

                    item.dni,
                    item.nombre,
                    item.apellido,
                    item.email,
                    item.cuenta_usuario,
                    item.contrasena,

                    item.oRol.nombre,
                    item.oRol.idrol,
                    item.telefono,
                    item.estado ? 1 : 0,
                    item.estado ? "Activo" : "Inactivo",

                    item.TipoRolCalculado,

                    item.EsCliente ? 1 : 0,              // Columna 15
                    item.EsProveedor ? 1 : 0,            // Columna 16

                });
            }
        }

        private void frmUsuario_Load(object sender, EventArgs e)
        {
            dgvdata.RowHeadersVisible = false;
            cboestado.Items.Add(new OpcionCombo() { Valor = 1, texto = "Activo" });
            cboestado.Items.Add(new OpcionCombo() { Valor = 0, texto = "No Activo" });
            cboestado.DisplayMember = "Texto";
            cboestado.ValueMember = "Valor";
            cboestado.SelectedIndex = 0;

            List<Rol> listaRol = new CN_Rol().Listar();
            foreach (var item in listaRol)
            {
                cborol.Items.Add(new OpcionCombo() { Valor = item.idrol, texto = item.nombre });
            }
            cborol.DisplayMember = "Texto";
            cborol.ValueMember = "Valor";
            cborol.SelectedIndex = 0;

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

            // Mostrar todos los usuarios
            CargarUsuarios(); // ⬅️ Llamamos al nuevo método de carga
        }

        // [MODIFICADO]
        private void btnguardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            // 1. BLOQUE DE VALIDACIÓN DE CAMPOS OBLIGATORIOS Y FORMATO
            // DNI (8 a 12 dígitos, solo números)
            if (string.IsNullOrWhiteSpace(txtdocumento.Text))
            {
                mensaje += "Debe ingresar el DNI.\n";
            }
            else if (!Regex.IsMatch(txtdocumento.Text.Trim(), @"^\d{8,12}$"))
            {
                mensaje += "El DNI debe tener entre 8 y 12 dígitos numéricos.\n";
            }

            // NOMBRE (Solo letras y espacios, no vacío)
            if (string.IsNullOrWhiteSpace(txtnombre.Text))
            {
                mensaje += "Debe ingresar el Nombre.\n";
            }
            else if (!Regex.IsMatch(txtnombre.Text.Trim(), @"^[a-zA-ZáéíóúÁÉÍÓÚ\s]+$"))
            {
                mensaje += "El Nombre solo puede contener letras y espacios.\n";
            }

            // APELLIDO (Solo letras y espacios, no vacío)
            if (string.IsNullOrWhiteSpace(txtapellido.Text))
            {
                mensaje += "Debe ingresar el Apellido.\n";
            }
            else if (!Regex.IsMatch(txtapellido.Text.Trim(), @"^[a-zA-ZáéíóúÁÉÍÓÚ\s]+$"))
            {
                mensaje += "El Apellido solo puede contener letras y espacios.\n";
            }

            // CORREO (Debe contener '@' y un dominio básico, no vacío)
            if (string.IsNullOrWhiteSpace(txtcorreo.Text))
            {
                mensaje += "Debe ingresar el Correo.\n";
            }
            else if (!Regex.IsMatch(txtcorreo.Text.Trim(), @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                mensaje += "El formato del Correo electrónico no es válido (debe contener '@' y dominio).\n";
            }
            // TELÉFONO (Exactamente 10 dígitos numéricos)
            if (string.IsNullOrWhiteSpace(txttelefono.Text))
            {
                mensaje += "Debe ingresar el Teléfono.\n";
            }
            else if (!Regex.IsMatch(txttelefono.Text.Trim(), @"^\d{10}$"))
            {
                mensaje += "El Teléfono debe contener exactamente 10 dígitos numéricos.\n";
            }

            // 1. **CONVERSIÓN SEGURA y DEFINITIVA**
            // Declaración de idUsuario (necesaria para la validación de clave si no la tenías ya)
            int idUsuario = 0;
            if (!int.TryParse(txtid.Text, out idUsuario))
            {
                idUsuario = 0;
            }

            if (string.IsNullOrWhiteSpace(txtclave.Text) && idUsuario == 0)
            {
                mensaje += "Debe ingresar la Clave para el nuevo usuario.\n";
            }

            // ⛔ Si hay errores, muestra el mensaje y detiene la ejecución.
            if (!string.IsNullOrEmpty(mensaje))
            {
                MessageBox.Show(mensaje, "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return; // Detiene el método aquí.
            }

            // Nota Importante: La declaración de idUsuario se movió arriba para que la validación de la Clave funcione.
            // Si la tenías declarada *después* de la validación de la Clave, causaría un error.


            Usuario objusuario = new Usuario()
            {
                // Usa la variable idUsuario segura
                idusuario = idUsuario,
                dni = txtdocumento.Text,
                nombre = txtnombre.Text,
                apellido = txtapellido.Text,
                email = txtcorreo.Text,
                cuenta_usuario = txtcuenta.Text,
                contrasena = txtclave.Text,
                telefono = txttelefono.Text,

                // Asignación del Rol de Acceso (Admin/Empleado)
                oRol = new Rol() { idrol = Convert.ToInt32(((OpcionCombo)cborol.SelectedItem).Valor), nombre = ((OpcionCombo)cborol.SelectedItem).texto },

                // Asignación del Estado
                estado = Convert.ToBoolean(((OpcionCombo)cboestado.SelectedItem).Valor),

                // 🟢 NUEVOS CAMPOS: Leer el estado de los CheckBoxes
                EsCliente = chkEsCliente.Checked,
                EsProveedor = chkEsProveedor.Checked
            };

            if (objusuario.idusuario == 0)
            {
                int idusuariogenerado = new CN_Usuario().Registrar(objusuario, out mensaje);

                if (idusuariogenerado != 0)
                {
                    MessageBox.Show("Usuario registrado con éxito.", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarUsuarios(); // ⬅️ Recarga toda la tabla (Método limpio y seguro)
                    Limpiar();
                }
                else
                {
                    MessageBox.Show(mensaje);
                }
            }
            else
            {
                bool resultado = new CN_Usuario().Editar(objusuario, out mensaje);

                if (resultado)
                {
                    DataGridViewRow row = dgvdata.Rows[Convert.ToInt32(txtindice.Text)];
                    row.Cells["id"].Value = txtid.Text;
                    row.Cells["Documento"].Value = txtdocumento.Text;
                    row.Cells["Nombre"].Value = txtnombre.Text;
                    row.Cells["Apellido"].Value = txtapellido.Text;
                    row.Cells["Correo"].Value = txtcorreo.Text;
                    row.Cells["NombreCuenta"].Value = txtcuenta.Text;
                    row.Cells["Clave"].Value = txtclave.Text;
                    row.Cells["Telefono"].Value = txttelefono.Text;
                    row.Cells["Rol"].Value = ((OpcionCombo)cborol.SelectedItem).texto.ToString();
                    row.Cells["idrol"].Value = ((OpcionCombo)cborol.SelectedItem).Valor.ToString();
                    row.Cells["Estado"].Value = ((OpcionCombo)cboestado.SelectedItem).texto.ToString();
                    row.Cells["EstadoValor"].Value = ((OpcionCombo)cboestado.SelectedItem).Valor.ToString();
                    Limpiar();
                    // 🟢 1. ACTUALIZAR COLUMNAS OCULTAS DE ROLES (para la próxima edición)
                    row.Cells["EsClienteValor"].Value = objusuario.EsCliente ? 1 : 0;
                    row.Cells["EsProveedorValor"].Value = objusuario.EsProveedor ? 1 : 0;

                    // 🟢 2. ACTUALIZAR COLUMNA VISIBLE DE ROL DE NEGOCIO (Tipo Rol)
                    string tipoRolNegocio =
                        (objusuario.EsCliente && objusuario.EsProveedor) ? "Cliente y Proveedor" :
                        (objusuario.EsCliente) ? "Cliente" :
                        (objusuario.EsProveedor) ? "Proveedor" : "Ninguno";

                    row.Cells["RolesNegocio"].Value = tipoRolNegocio; // Asume que la columna se llama "RolesNegocio"

                    MessageBox.Show("Usuario editado con éxito.", "Edición Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                }
                else
                {
                    MessageBox.Show(mensaje);
                }
            }

        }

        private void Limpiar()
        {
            txtindice.Text = "-1";
            txtid.Text = "0";
            txtdocumento.Text = "";
            txtnombre.Text = "";
            txtapellido.Text = "";
            txtclave.Text = "";
            txtcuenta.Text = "";
            txtcorreo.Text = "";
            txtconfirmarclave.Text = "";
            cborol.SelectedIndex = 0;
            cboestado.SelectedIndex = 0;
            txttelefono.Text = "";

            txtdocumento.Select();
        }

        //Al hacer click en el check nos va a traer los datos en los txt
        private void dgvdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvdata.Columns[e.ColumnIndex].Name == "btnseleccionar")
            {
                int indice = e.RowIndex;

                if (indice >= 0)
                {
                    // 1. Carga de campos de texto (¡OK!)
                    txtindice.Text = indice.ToString();
                    txtid.Text = dgvdata.Rows[indice].Cells["id"].Value.ToString();
                    txtdocumento.Text = dgvdata.Rows[indice].Cells["Documento"].Value.ToString();
                    txtnombre.Text = dgvdata.Rows[indice].Cells["Nombre"].Value.ToString();
                    txtapellido.Text = dgvdata.Rows[indice].Cells["Apellido"].Value.ToString();
                    txtcorreo.Text = dgvdata.Rows[indice].Cells["Correo"].Value.ToString();
                    txtcuenta.Text = dgvdata.Rows[indice].Cells["NombreCuenta"].Value.ToString();
                    txtclave.Text = dgvdata.Rows[indice].Cells["Clave"].Value.ToString();
                    txtconfirmarclave.Text = dgvdata.Rows[indice].Cells["Clave"].Value.ToString();
                    txttelefono.Text = dgvdata.Rows[indice].Cells["Telefono"].Value.ToString();

                    // 2. 🟢 Carga de CheckBoxes (¡OK! Asumo que "EsClienteValor" y "EsProveedorValor" existen)
                    try
                    {
                        int esClienteValor = Convert.ToInt32(dgvdata.Rows[indice].Cells["EsClienteValor"].Value);
                        int esProveedorValor = Convert.ToInt32(dgvdata.Rows[indice].Cells["EsProveedorValor"].Value);
                        chkEsCliente.Checked = (esClienteValor == 1);
                        chkEsProveedor.Checked = (esProveedorValor == 1);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error al cargar roles de negocio. Verifique los nombres de las columnas 'EsClienteValor' y 'EsProveedorValor'.", "Error de Edición", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // 3. 🟢 Carga del ComboBox Rol
                    // Si la columna "idrol" existe y contiene el ID (número)
                    try
                    {
                        string idRolString = dgvdata.Rows[indice].Cells["idrol"].Value.ToString();
                        int idRolAConvertir = 0;

                        if (int.TryParse(idRolString, out idRolAConvertir))
                        {
                            foreach (OpcionCombo oc in cborol.Items)
                            {
                                if (Convert.ToInt32(oc.Valor) == idRolAConvertir)
                                {
                                    cborol.SelectedIndex = cborol.Items.IndexOf(oc);
                                    break;
                                }
                            }
                        }
                    }
                    catch (Exception)
                    {
                        // Esto significa que la columna "idrol" tiene el nombre incorrecto o el valor es inválido.
                        MessageBox.Show("Error al cargar el Rol. Verifique el nombre de la columna oculta 'idrol' en el DGV y su contenido.", "Error de Edición", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // 4. 🟢 ¡NUEVO! Carga del ComboBox Estado
                    // Necesitas la columna oculta que guarda el 1 o 0. Asumo que se llama "EstadoValor".
                    try
                    {
                        string estadoValorString = dgvdata.Rows[indice].Cells["EstadoValor"].Value.ToString();
                        int estadoValor = 0;

                        if (int.TryParse(estadoValorString, out estadoValor))
                        {
                            foreach (OpcionCombo oc in cboestado.Items)
                            {
                                if (Convert.ToInt32(oc.Valor) == estadoValor)
                                {
                                    cboestado.SelectedIndex = cboestado.Items.IndexOf(oc);
                                    break;
                                }
                            }
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error al cargar el Estado. Verifique el nombre de la columna oculta 'EstadoValor' en el DGV y su contenido.", "Error de Edición", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtid.Text) != 0)
            {
                if (MessageBox.Show("¿Desea eliminar el usuario?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    string mensaje = string.Empty;
                    Usuario objusuario = new Usuario()
                    {
                        idusuario = Convert.ToInt32(txtid.Text)
                    };
                    bool respuesta = new CN_Usuario().Eliminar(objusuario, out mensaje);
                    if (respuesta)
                    {
                        dgvdata.Rows.RemoveAt(Convert.ToInt32(txtindice.Text));
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                Limpiar();
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

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        // [AGREGADO]
        private void txtbusqueda_TextChanged(object sender, EventArgs e)
        {
            // 1. Evita el error NullReferenceException si el ComboBox o el texto están vacíos
            if (cbobusqueda.SelectedItem == null)
            {
                return;
            }

            // Obtiene la columna seleccionada por el usuario (ej: "Documento", "Nombre", "Correo")
            string columnaFiltro = ((OpcionCombo)cbobusqueda.SelectedItem).Valor.ToString();
            string textoBusqueda = txtbusqueda.Text.Trim().ToUpper();

            // 2. Iterar y Filtrar (Mostrar/Ocultar filas)
            if (dgvdata.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvdata.Rows)
                {
                    // Verificamos que la celda de la columna seleccionada NO sea nula
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
                    // Si el texto de búsqueda está vacío, mostramos todas las filas
                    else if (string.IsNullOrEmpty(textoBusqueda))
                    {
                        row.Visible = true;
                    }
                }
            }

        }

        private void dgvdata_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        //propiedades para el check
        private void dgvdata_CellContentClick(object sender, DataGridViewCellPaintingEventArgs e)
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
    }
}
