using CapaEntidad;
using CapaNegocio;
using MaxiKiosco.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaxiKiosco
{
    public partial class frmProveedores : Form
    {
        public frmProveedores()
        {
            InitializeComponent();
        }
        
        private void menuproveedores_Click(object sender, EventArgs e)
        {
            frmProveedores frm = new frmProveedores();
            frm.ShowDialog();
        }

        // [Modificado]
        private void frmProveedores_Load(object sender, EventArgs e)
        {
            dgvdata.RowHeadersVisible = false;//es la fila que trae por defecto en el datagrid

            cboestado.Items.Add(new OpcionCombo() { Valor = 1, texto = "Activo" });
            cboestado.Items.Add(new OpcionCombo() { Valor = 0, texto = "No Activo" });
            cboestado.DisplayMember = "texto";
            cboestado.ValueMember = "Valor";

            // [INSERTAR COLUMNA RAZONSOCIAL - SÓLO AQUÍ]
            if (!dgvdata.Columns.Contains("RazonSocial"))
            {
                dgvdata.Columns.Insert(5, new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Razón Social",
                    Name = "RazonSocial",
                    Visible = true,
                    Width = 150
                });
            }

            // Limpiar opciones de búsqueda y agregar nuevas
            // Necesitas limpiar primero antes de agregarlas de nuevo
            cbobusqueda.Items.Clear();


            foreach (DataGridViewColumn column in dgvdata.Columns)
            {
                if (column.Visible == true && column.Name != "btnseleccionar")
                {
                    cbobusqueda.Items.Add(new OpcionCombo() { Valor = column.Name, texto = column.HeaderText });
                }
            }

            // 🚨 Asegúrate de que el primer elemento esté seleccionado
            if (cbobusqueda.Items.Count > 0)
            {
                cbobusqueda.SelectedIndex = 0;
            }

            // LLAMAR AL NUEVO MÉTODO DE CARGA
            RecargarGrilla();
        }

        // [AGREGADO]  Metodo para listar los proveedores.
        private void RecargarGrilla()
        {
            // Limpiamos la grilla para recargar los datos frescos de la BD
            dgvdata.Rows.Clear();

            List<Proveedor> objProveedor = new CN_Proveedor().Listar();

            foreach (var item in objProveedor)
            {
                dgvdata.Rows.Add(new object[]{
                    "",                     // Columna 0: btnseleccionar
                    item.id,                // Columna 1: id (Oculta)
                    item.nombre,            // Columna 2: Nombre
                    item.cuit,              // Columna 3: Cuit
                    item.porcentaje_aumento,
                    item.razonsocial,       // Columna 4: Razón Social
                    item.email,             // Columna 5: Correo 
                    item.telefono,          // Columna 6: Telefono 
                    item.direccion,         // Columna 7: Domicilio
                    item.estado == true ? 1 : 0,    // Columna 8: EstadoValor
                    item.estado == true ? "Activo" : "Inactivo", // Columna 9: Estado
                });
            }
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            string Mensaje = string.Empty;

            // [AGREGADO VALIDACIÓN DE CAMPOS]
            if (string.IsNullOrWhiteSpace(txtnombre.Text) || string.IsNullOrWhiteSpace(txtcuit.Text))
            {
                MessageBox.Show("Los campos Nombre y CUIT son obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // [AGREGADO VALIDACIÓN DE CUIT: 11 DÍGITOS y NUMÉRICO]
            // Usamos TryParse, que es más seguro y eficiente que .All(char.IsDigit)
            if (txtcuit.Text.Length != 11 || !long.TryParse(txtcuit.Text, out long cuitValido))
            {
                MessageBox.Show("El campo CUIT debe ser numérico y tener exactamente 11 dígitos (sin guiones).", "Advertencia de CUIT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // [AGREGADO VALIDACIÓN DE EMAIL: Formato básico]
            // Validamos solo si el campo no está vacío
            if (!string.IsNullOrWhiteSpace(txtcorreo.Text))
            {
                try
                {
                    var addr = new System.Net.Mail.MailAddress(txtcorreo.Text);
                }
                catch
                {
                    MessageBox.Show("El Correo Electrónico no parece tener un formato válido.", "Advertencia de Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // --- TELÉFONO: Sólo numérico (como lo tenías, usando Char.IsDigit) ---
            if (!string.IsNullOrWhiteSpace(txttelefono.Text) && !txttelefono.Text.All(char.IsDigit))
            {
                MessageBox.Show("El Teléfono solo debe contener caracteres numéricos (sin espacios ni símbolos).", "Advertencia de Teléfono", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // --- PORCENTAJE DE AUMENTO (CRÍTICO PARA FUTURO CÁLCULO) ---
            decimal porcentajeAumento = 0m;
            //  TRASPASAMOS EL VALOR A UNA VARIABLE LIMPIA
            string porcentajeText = txtporcentajeaumento.Text.Trim();

            if (!string.IsNullOrWhiteSpace(porcentajeText))
            {
                // 3. Si TryParse falla O el valor es negativo, mostramos error
                if (!decimal.TryParse(porcentajeText, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out porcentajeAumento) || porcentajeAumento < 0)
                {
                    MessageBox.Show("El Porcentaje de Aumento debe ser un valor numérico positivo o cero.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // 🛑 Detiene el flujo
                }
            }

            Proveedor objProveedor = new Proveedor()
            {
                id = Convert.ToInt32(txtid.Text),
                nombre = txtnombre.Text,
                cuit = txtcuit.Text,
                // [MODIFICACIÓN CRUCIAL] 
                razonsocial = txtrazonsocial.Text, //AGREGAR RAZON SOCIAL
                direccion = txtdomicilio.Text,
                telefono = txttelefono.Text,
                email = txtcorreo.Text,
                estado = Convert.ToInt32(((OpcionCombo)cboestado.SelectedItem).Valor) == 1 ? true : false,
                porcentaje_aumento = porcentajeAumento
            };

            if (objProveedor.id == 0) // REGISTRAR (INSERTAR)
            {
                int idProveedorgenerado = new CN_Proveedor().Registrar(objProveedor, out Mensaje);

                if (idProveedorgenerado != 0) // Agregar RazonSocial a la inserción de la fila
                {
                    // 🎯 1. LIMPIAR TODAS LAS FILAS ANTES DE INSERTAR LA NUEVA
                    dgvdata.Rows.Clear();

                    // 2. INSERTAR LA FILA RECIÉN GENERADA
                    dgvdata.Rows.Add(new object[] {
                        // Columna de selección (Ícono)
                        "",
                        idProveedorgenerado.ToString(),// 1. ID (usamos el ID generado)
                        objProveedor.nombre,
                        objProveedor.cuit,
                        objProveedor.porcentaje_aumento.ToString("0.##"),
                        objProveedor.razonsocial,
                        objProveedor.email,
                        objProveedor.telefono,
                        objProveedor.direccion,
                        objProveedor.estado == true ? 1 : 0,
                        objProveedor.estado == true ? "Activo" : "No Activo",
                    });

                    Limpiar();
                    MessageBox.Show("Proveedor registrado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(Mensaje, "Error de Registro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else // EDITAR (ACTUALIZAR)
            {
                bool resultado = new CN_Proveedor().Editar(objProveedor, out Mensaje);
                if (resultado)
                {
                    // 🎯 1. LIMPIAR TODAS LAS FILAS
                    // Al limpiar, el índice que tenías ya no es válido, por eso la edición fallaba.
                    dgvdata.Rows.Clear();

                    // 2. INSERTAR LA FILA ACTUALIZADA (como si fuera una nueva)
                    dgvdata.Rows.Add(new object[] {
                        // Columna de selección (Ícono)
                        "",
                        // 1. ID (usamos el ID que ya tenía)
                        objProveedor.id.ToString(),
                        objProveedor.nombre,
                        objProveedor.cuit,
                        objProveedor.porcentaje_aumento.ToString("0.##"),
                        objProveedor.razonsocial,
                        objProveedor.email,
                        objProveedor.telefono,
                        objProveedor.direccion,
                        objProveedor.estado == true ? 1 : 0,
                        objProveedor.estado == true ? "Activo" : "No Activo",
                    });

                    Limpiar(); // Limpia los campos de la izquierda
                    MessageBox.Show("Proveedor editado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            RecargarGrilla();
        }

        private void Limpiar()
        {
            txtindice.Text = "-1";
            txtid.Text = "0";
            txtnombre.Text = "";
            txtcuit.Text = "";
            // [AGREGAR RAZÓN SOCIAL]
            txtrazonsocial.Text = "";
            // [Continuación del código de limpieza]
            txtdomicilio.Text = "";
            txttelefono.Text = "";
            txtcorreo.Text = "";
            cboestado.SelectedIndex = 0;
        }
        
        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtid.Text) != 0)
            {
                if (MessageBox.Show("¿Está seguro que desea eliminar este proveedor?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string Mensaje = string.Empty;
                    Proveedor objProveedor = new Proveedor()
                    {
                        id = Convert.ToInt32(txtid.Text)
                    };

                    // La Capa de Negocio se encarga de la eliminación (cambio de estado a Inactivo)
                    bool respuesta = new CN_Proveedor().Eliminar(objProveedor, out Mensaje);

                    if (respuesta)
                    {
                        // [CONFIRMACIÓN DE RECARGA] En lugar de remover la fila manualmente, recargamos toda la grilla.
                        RecargarGrilla(); // Recarga la grilla después de la eliminación
                        MessageBox.Show("Proveedor eliminado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(Mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                Limpiar(); // Limpia los campos del detalle después de intentar eliminar
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
                        txtcuit.Text = dgvdata.Rows[indice].Cells["Cuit"].Value.ToString();
                        // Usar formato numérico simple al cargar el TextBox para evitar símbolos de coma/punto raros
                        object valorPorcentaje = dgvdata.Rows[indice].Cells["porcentaje_aumento"].Value;
                        txtporcentajeaumento.Text = Convert.ToDecimal(valorPorcentaje).ToString("0.##");
                        txtrazonsocial.Text = dgvdata.Rows[indice].Cells["RazonSocial"].Value.ToString();
                        txtnombre.Text = dgvdata.Rows[indice].Cells["Nombre"].Value.ToString();
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
            RecargarGrilla();
        }

        // [AGREGADO] Busqued en tiempo real de proveedor
        private void txtbusqueda_TextChanged(object sender, EventArgs e)
        {
            // [CORRECCIÓN CRUCIAL] VERIFICAR QUE HAYA UN ÍTEM SELECCIONADO EN EL COMBO
            if (cbobusqueda.SelectedItem == null)
            {
                // Si no hay nada seleccionado, simplemente salimos del método para evitar el error.
                return;
            }

            // 1. Obtener la columna de búsqueda seleccionada
            // Ya es seguro acceder a SelectedItem.
            string columnaFiltro = ((OpcionCombo)cbobusqueda.SelectedItem).Valor.ToString();
            string textoBusqueda = txtbusqueda.Text.Trim().ToUpper();

            // 2. Iterar sobre las filas del DataGridView
            if (dgvdata.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvdata.Rows)
                {
                    // Verificamos que la celda de la columna filtro exista y no sea nula.
                    if (row.Cells[columnaFiltro].Value != null)
                    {
                        // Convertimos el valor de la celda a mayúsculas para la comparación
                        string valorCelda = row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper();

                        // 3. Mostrar u ocultar la fila
                        if (valorCelda.Contains(textoBusqueda))
                        {
                            row.Visible = true; // El texto coincide, mostramos la fila
                        }
                        else
                        {
                            row.Visible = false; // No coincide, ocultamos la fila
                        }
                    }
                    // Si el texto de búsqueda está vacío, o la celda es nula, mostramos la fila
                    // si el textoBusqueda es vacío (para que vuelvan a aparecer todos).
                    else if (string.IsNullOrEmpty(textoBusqueda))
                    {
                        row.Visible = true;
                    }
                }
            }
            // NUEVO: Si el campo de búsqueda está vacío, recargar la grilla completa
            if (string.IsNullOrWhiteSpace(txtbusqueda.Text))
            {
                RecargarGrilla();
                return; // Salimos para no ejecutar la lógica de filtrado si no hay texto
            }
        }
    }
}


