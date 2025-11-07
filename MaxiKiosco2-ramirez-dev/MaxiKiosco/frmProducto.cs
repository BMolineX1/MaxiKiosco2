using CapaDatos;
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

        // [AGREGADO] 1. Variable para almacenar la lista COMPLETA de productos, Esto evita tener que consultar la base de datos o el DataGridView en cada pulsación de tecla.
        private List<Producto> listaProductos; //agregado

        public frmProducto()
        {
            InitializeComponent();
        }

        // [AGREGADO] para buscar categorias activas
        private void CargarCategoriasCombo()
        {
            cbocategoria.Items.Clear();

            // ❌ CORRECCIÓN: Usar ListarActivos() en lugar de Listar()
            List<Categoria> listaCategoria = new CN_Categoria().ListarActivos();

            foreach (Categoria item in listaCategoria)
            {
                cbocategoria.Items.Add(new OpcionCombo() { Valor = item.Id, texto = item.nombre_categoria });
            }
            cbocategoria.DisplayMember = "Texto";
            cbocategoria.ValueMember = "Valor";
            if (cbocategoria.Items.Count > 0)
            {
                cbocategoria.SelectedIndex = 0;
            }
        }

        // [AGREGADO] 2. Nuevo método para cargar los productos y mantenerlos en memoria
        private void CargarProductos()
        {
            try
            {
                // Carga la lista COMPLETA desde la capa de negocio
                listaProductos = new CN_Producto().Listar();

                // Si se carga correctamente, se usa esta lista para llenar el DataGridView
                foreach (Producto item in listaProductos)
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

        // [AGREGADO/MODIFICADO] 
        // Método para recargar la lista en memoria y repintar la grilla
        private void RecargarProductos()
        {
            // Limpia la grilla antes de cargar
            dgvdata.Rows.Clear();

            // Vuelve a cargar la lista COMPLETA de productos desde la capa de negocio
            // Esto es NECESARIO porque el registro/edición puede haber cambiado los datos del producto (Id, etc.)
            try
            {
                // Esta línea asumo que es la lista que usas para llenar la grilla
                // Si no la tienes declarada a nivel de clase, puedes declararla aquí
                List<Producto> listaProductos = new CN_Producto().Listar();
                //listaProductos = new CN_Producto().Listar();

                // Llena el DataGridView con los datos de la lista recién cargada
                foreach (Producto item in listaProductos)
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
                MessageBox.Show("Error al recargar productos: " + ex.Message);
            }
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

            /* Borrar una ves que ffuncine todo
            List<Categoria> listaCategoria = new CN_Categoria().Listar();
            foreach (var item in listaCategoria)
            {

                cbocategoria.Items.Add(new OpcionCombo() { Valor = item.Id, texto = item.nombre_categoria });
            }*/

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


            // 1. Aplicar formato "N2" a la columna de Precio de Compra
            // Usamos el nombre 'preciocompra' (minúsculas) que es común cuando se usa la propiedad del objeto.
            if (dgvdata.Columns.Contains("preciocompra"))
            {
                // Forzar el tipo de dato de la columna.
                dgvdata.Columns["preciocompra"].ValueType = typeof(decimal);

                // Luego aplicar el formato.
                dgvdata.Columns["preciocompra"].DefaultCellStyle.Format = "N2";
            }

            // 2. Aplicar formato "N2" a la columna de Precio de Venta
            if (dgvdata.Columns.Contains("precioventa"))
            {
                dgvdata.Columns["precioventa"].DefaultCellStyle.Format = "N2";
            }

            CargarCategoriasCombo(); // Llama a la función de carga del combo filtrada
            // [MODIFICADO] Aquí has llamado a CargarProductos()
            CargarProductos();
        }

        private void Limpiar()
        {
            // [IMPORTANTE] Restablecer el ID para indicar que es un registro nuevo
            txtidproducto.Text = "0"; // O el nombre del TextBox que uses para el ID
            txtindice.Text = "-1";    // Restablecer el índice de la fila seleccionada (si lo usas)

            // Restablecer los campos de detalle
            txtnombre.Text = "";
            txtcodigo.Text = "";
            txtprecioventa.Text = "";
            txtpreciocompra.Text = "";
            txtstock.Text = "";
            txtdescripcion.Text = "";

            // Restablecer ComboBox a la primera opción (o la opción por defecto)
            cbocategoria.SelectedIndex = 0;
            cboestado.SelectedIndex = 0;
        }

        //[MODIFICADO]
        private void btnguardar_Click_1(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            // Declaración de variables fuera del TryParse
            decimal precioventa;
            decimal preciocompra;
            int stock;
            int idproducto;
            int idestado;
            int idcategoria; // Variable para la Categoría

            // 1. VERIFICACIÓN DE CAMPOS DE TEXTO VACÍOS (VALIDACIÓN BÁSICA)
            if (string.IsNullOrWhiteSpace(txtnombre.Text) ||
             string.IsNullOrWhiteSpace(txtprecioventa.Text) ||
             string.IsNullOrWhiteSpace(txtpreciocompra.Text) ||
             string.IsNullOrWhiteSpace(txtstock.Text))
            {
                MessageBox.Show("Debe completar los campos Nombre, Precios y Stock.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // 2. VALIDACIÓN DEL COMBOBOX DE CATEGORÍA (PREVENCIÓN DE NullReferenceException)
            // CORRECCIÓN CLAVE: Validamos que haya un ítem seleccionado ANTES de usarlo.
            if (cbocategoria.SelectedItem == null)
            {
                mensaje += "Debe seleccionar una Categoría válida.\nSi no hay categoria agrege primero una (en la sesion de categoria) y luego registre su producto con la nueva categoria,";
            }

            // Si la validación de categoría falló, mostramos el error y salimos.
            if (mensaje != string.Empty)
            {
                MessageBox.Show(mensaje, "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // ASIGNACIÓN SEGURA: Como ya validamos que NO es nulo, obtenemos el ID de categoría.
            // Esto ya no necesita estar dentro del bloque TryParse.
            idcategoria = Convert.ToInt32(((OpcionCombo)cbocategoria.SelectedItem).Valor);


            // 3. VERIFICACIÓN DE FORMATO DECIMAL (PUNTO Y COMA)
            char separadorDecimal = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];
            string textoVenta = txtprecioventa.Text.Trim();
            string textoCompra = txtpreciocompra.Text.Trim();

            int cuentaSeparadorVenta = textoVenta.Count(c => c == separadorDecimal);
            int cuentaSeparadorCompra = textoCompra.Count(c => c == separadorDecimal);

            if (cuentaSeparadorVenta > 1 || cuentaSeparadorCompra > 1)
            {
                MessageBox.Show($"El formato de precio es incorrecto. Debe usar el separador decimal '{separadorDecimal}' solo una vez. Ejemplo: 123{separadorDecimal}45.",
                                 "Error de Formato Decimal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            // 4. PARSEO DE VALORES NUMÉRICOS RESTANTES
            // CORRECCIÓN: Quitamos la validación de idcategoria de este bloque.
            // CORRECCIÓN: Usamos TryParse con CultureInfo.CurrentCulture para manejar correctamente la coma decimal.
            bool parseVenta = decimal.TryParse(textoVenta, System.Globalization.NumberStyles.Any,
                                   System.Globalization.CultureInfo.CurrentCulture, out precioventa);
            bool parseCompra = decimal.TryParse(textoCompra, System.Globalization.NumberStyles.Any,
                                                System.Globalization.CultureInfo.CurrentCulture, out preciocompra);

            // Verificamos si las conversiones fueron exitosas junto con las demás
            if (!parseVenta || !parseCompra ||
                !int.TryParse(txtstock.Text, out stock) ||
                !int.TryParse(txtidproducto.Text, out idproducto) ||
                !int.TryParse(((OpcionCombo)cboestado.SelectedItem).Valor.ToString(), out idestado))
            {
                MessageBox.Show("Por favor, ingrese formatos numéricos válidos para Precios y/o Stock. Recuerde que el Stock debe ser un número entero.", "Error de Formato Numérico", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            // 5. LÓGICA DE CÓDIGO DE BARRAS (GENERACIÓN INTERNA)
            string codigoProducto = txtcodigo.Text.Trim();

            // Si NO es edición (Id = 0) Y el campo de código está vacío, usamos la bandera.
            if (string.IsNullOrWhiteSpace(codigoProducto) && idproducto == 0)
            {
                codigoProducto = "GENERAR_INTERNO";
            }

            // 6. CREACIÓN DEL OBJETO PRODUCTO
            Producto objproducto = new Producto()
            {
                Id = idproducto,
                nombre = txtnombre.Text,
                codigo = codigoProducto,
                precioventa = precioventa,
                preciocompra = preciocompra,
                descripcion = txtdescripcion.Text,
                fecharegistro = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                // Usamos la variable idcategoria que obtuvimos de forma segura
                ocategoria = new Categoria() { Id = idcategoria },
                stock = stock,
                estado = idestado == 1 ? true : false,
            };

            // 7. LÓGICA DE REGISTRO/EDICIÓN
            if (objproducto.Id == 0) // REGISTRAR NUEVO
            {
                int idProductogenerado = new CN_Producto().Registrar(objproducto, out mensaje);

                if (idProductogenerado != 0)
                {
                    RecargarProductos();
                    Limpiar();
                }
                else
                {
                    MessageBox.Show(mensaje);
                }
            }
            else // EDITAR EXISTENTE
            {
                bool resultado = new CN_Producto().Editar(objproducto, out mensaje);

                if (resultado)
                {
                    RecargarProductos();
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
            string mensaje = string.Empty;
            int idproducto_a_eliminar = 0;

            // 1. Obtener y validar el ID usando TXTIDPRODUCTO
            if (int.TryParse(txtidproducto.Text, out idproducto_a_eliminar) && idproducto_a_eliminar != 0)
            {
                // 2. Confirmación
                if (MessageBox.Show("¿Desea eliminar el producto de forma definitiva?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // 3. Crear el objeto con el ID
                    Producto objproducto = new Producto()
                    {
                        Id = idproducto_a_eliminar
                    };

                    // 4. Llamar a la Capa de Negocio
                    bool respuesta = new CN_Producto().Eliminar(objproducto, out mensaje);

                    if (respuesta)
                    {
                        // [ACTUALIZACIÓN SEGURA] Recargar la lista y limpiar el formulario
                        RecargarProductos();
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Error al Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            else
            {
                // Si el ID es 0 o no es un número válido.
                MessageBox.Show("Debe seleccionar un producto de la lista para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    // [MODIFICACIÓN CRUCIAL AQUÍ]
                    // Asegurarse de usar el campo que se chequea en el botón Guardar
                    txtidproducto.Text = dgvdata.Rows[indice].Cells["id"].Value.ToString();

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

        // [MODIFICADO] El botón de búsqueda manual (iconButton2_Click) ahora reutiliza
        // la lógica del evento TextChanged para unificar el código de filtrado.
        private void iconButton2_Click(object sender, EventArgs e)
        {
            // Llama al evento de búsqueda en tiempo real, ya que contienen la lógica de filtrado
            txtbusquedaproducto_TextChanged(sender, e);
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

        // [MODIFICADO] Evento TextChanged para la búsqueda en tiempo real
        private void txtbusquedaproducto_TextChanged(object sender, EventArgs e)
        {
            string textoBusqueda = txtbusquedaproducto.Text.Trim().ToUpper();

            // Limpia el DataGridView antes de llenarlo con los resultados filtrados
            dgvdata.Rows.Clear();

            // Determina la columna de filtro seleccionada en el ComboBox de búsqueda (cbobusqueda)
            string columnaFiltro = ((OpcionCombo)cbobusqueda.SelectedItem).Valor.ToString();

            if (string.IsNullOrEmpty(textoBusqueda))
            {
                // Si el campo de búsqueda está vacío, volvemos a mostrar la lista COMPLETA
                foreach (Producto item in listaProductos)
                {
                    dgvdata.Rows.Add(new object[] {
                        "", item.Id, item.nombre, item.codigo, item.preciocompra, item.precioventa,
                        item.descripcion, item.ocategoria.nombre_categoria, item.ocategoria.Id,
                        item.stock, item.estado == true ? 1 : 0, item.estado == true ? "Activo" : "Inactivo",
                    });
                }
            }
            else
            {
                // Filtra la lista de productos que está en memoria (listaProductos)
                // Se busca coincidencia en el campo seleccionado por el ComboBox
                foreach (Producto item in listaProductos)
                {
                    // Obtiene el valor de la propiedad del producto según la columna seleccionada
                    // Se agrega una verificación adicional para buscar por Codigo y Nombre directamente
                    if (
                        (item.GetType().GetProperty(columnaFiltro)?.GetValue(item)?.ToString().ToUpper().Contains(textoBusqueda) == true) ||
                        item.codigo.ToUpper().Contains(textoBusqueda) ||
                        item.nombre.ToUpper().Contains(textoBusqueda)
                       )
                    {
                        dgvdata.Rows.Add(new object[] {
                            "", item.Id, item.nombre, item.codigo, item.preciocompra, item.precioventa,
                            item.descripcion, item.ocategoria.nombre_categoria, item.ocategoria.Id,
                            item.stock, item.estado == true ? 1 : 0, item.estado == true ? "Activo" : "Inactivo",
                        });
                    }
                }
            }

        }

        private void cbocategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}