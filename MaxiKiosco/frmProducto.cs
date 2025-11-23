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

        private void PintarCeldasStockBajo(DataGridViewRow fila)
        {
            if (fila == null) return;
            int stock = 0;
            int stockminimo = 0;

            int.TryParse(fila.Cells["Stock"].Value?.ToString(), out stock);
            int.TryParse(fila.Cells["stockminimo"].Value?.ToString(), out stockminimo);

            if (stock <= stockminimo)
            {
                fila.DefaultCellStyle.BackColor = Color.MistyRose;
            }
            else
            {
                fila.DefaultCellStyle.BackColor = Color.White;
            }
        }

        // [AGREGADO] para buscar categorias activas
       

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
                    int index = dgvdata.Rows.Add(new object[] {
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
                        item.stockminimo,
                        item.estado == true ? 1 : 0,
                        item.estado == true ? "Activo" : "Inactivo",
                    });
                    var fila = dgvdata.Rows[index];

                    PintarCeldasStockBajo(fila);
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
                    int index = dgvdata.Rows.Add(new object[] {
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
                        item.stockminimo,
                        item.estado == true ? 1 : 0,
                        item.estado == true ? "Activo" : "Inactivo",
                    });

                    var fila = dgvdata.Rows[index];

                    PintarCeldasStockBajo(fila);
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
            
            // 🔒 El precio de venta se administra en SubaPrecio, acá solo se muestra
            txtprecioventa.ReadOnly = true;
            txtprecioventa.Enabled = false; // si querés que no se pueda ni seleccionar

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

            CargarCategoriasCombo();

            // [MODIFICADO] Aquí has llamado a CargarProductos()
            CargarProductos();
        }
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

        private void Limpiar()
        {
            // [IMPORTANTE] Restablecer el ID para indicar que es un registro nuevo
            txtidproducto.Text = "0"; // O el nombre del TextBox que uses para el ID
            txtindice.Text = "-1";    // Restablecer el índice de la fila seleccionada (si lo usas)

            // Restablecer los campos de detalle
            txtnombre.Text = "";
            txtcodigo.Text = "";
            txtprecioventa.Text = "";
            txtstock.Text = "";
            txtstockminimo.Text = "";
            txtdescripcion.Text = "";

            // Restablecer ComboBox a la primera opción (o la opción por defecto)
            cboestado.SelectedIndex = 0;

            // AÑADIR: Recargar la grilla completa
            RecargarProductos(); // O el nombre de tu método para llenar la grilla
        }

        //[MODIFICADO]
        private void btnguardar_Click_1(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            // Variables numéricas
            int stock;
            int stockminimo;
            int idproducto;
            int idestado;
            int idcategoria;

            // 1) Validación básica (YA SIN PRECIO DE VENTA)
            if (string.IsNullOrWhiteSpace(txtnombre.Text) ||
                string.IsNullOrWhiteSpace(txtstock.Text) ||
                string.IsNullOrWhiteSpace(txtstockminimo.Text))
            {
                MessageBox.Show(
                    "Debe completar los campos Nombre y Stock.",
                    "Error de Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation
                );
                return;
            }

            // 2) Validación de categoría
            if (cbocategoria.SelectedItem == null)
            {
                mensaje += "Debe seleccionar una Categoría válida.\n" +
                           "Si no hay categorías, cree una primero en el módulo de Categorías.\n";
            }

            if (mensaje != string.Empty)
            {
                MessageBox.Show(mensaje, "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Id de categoría ya validado
            idcategoria = Convert.ToInt32(((OpcionCombo)cbocategoria.SelectedItem).Valor);

            // 3) Parseos numéricos (sin precio de venta)
            if (!int.TryParse(txtstock.Text, out stock) ||
                !int.TryParse(txtstockminimo.Text, out stockminimo) ||
                !int.TryParse(txtidproducto.Text, out idproducto) ||
                !int.TryParse(((OpcionCombo)cboestado.SelectedItem).Valor.ToString(), out idestado))
            {
                MessageBox.Show(
                    "Por favor, ingrese formatos numéricos válidos para Stock y Stock mínimo.\n" +
                    "Recuerde que el Stock debe ser un número entero.",
                    "Error de Formato Numérico",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation
                );
                return;
            }

            // 4) Código de producto (generación interna si está vacío y es nuevo)
            string codigoProducto = txtcodigo.Text.Trim();

            if (string.IsNullOrWhiteSpace(codigoProducto) && idproducto == 0)
            {
                // Bandera para que CN_Producto genere el código interno
                codigoProducto = "GENERAR_INTERNO";
            }

            // 5) Precio de venta actual (SOLO para edición)
            // 👉 YA NO SE LEE DE txtprecioventa: se trae de listaProductos
            decimal precioVentaActual = 0m;

            if (idproducto != 0 && listaProductos != null)
            {
                var prodExistente = listaProductos.FirstOrDefault(p => p.Id == idproducto);
                if (prodExistente != null)
                {
                    precioVentaActual = prodExistente.precioventa;
                }
            }
            // Si es nuevo (idproducto == 0), se queda en 0m y luego se ajusta desde SubaPrecio

            // 6) Construir objeto Producto
            Producto objproducto = new Producto()
            {
                Id = idproducto,
                nombre = txtnombre.Text,
                codigo = codigoProducto,
                precioventa = precioVentaActual,          // 👈 se conserva o queda en 0
                descripcion = txtdescripcion.Text,
                fecharegistro = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                ocategoria = new Categoria() { Id = idcategoria },
                stock = stock,
                stockminimo = stockminimo,
                estado = (idestado == 1)
            };

            // 7) Registrar o editar
            if (objproducto.Id == 0)
            {
                // 👉 NUEVO PRODUCTO: entra con precio 0, luego lo subís desde SubaPrecio
                int idProductogenerado = new CN_Producto().Registrar(objproducto, out mensaje);

                if (idProductogenerado != 0)
                {
                    MostrarSoloRegistro(idProductogenerado);
                }
                else
                {
                    MessageBox.Show(mensaje);
                }
            }
            else
            {
                // 👉 EDICIÓN: no toca precio, lo conserva
                bool resultado = new CN_Producto().Editar(objproducto, out mensaje);

                if (resultado)
                {
                    MostrarSoloRegistro(objproducto.Id);
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
                    txtprecioventa.Text = dgvdata.Rows[indice].Cells["PrecioDeVenta"].Value.ToString();
                    txtstock.Text = dgvdata.Rows[indice].Cells["Stock"].Value.ToString();
                    txtstockminimo.Text = dgvdata.Rows[indice].Cells["StockMinimo"].Value.ToString();

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
                    int index = dgvdata.Rows.Add(new object[] {
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
                        item.stockminimo,
                        item.estado == true ? 1 : 0,
                        item.estado == true ? "Activo" : "Inactivo",
                    });
                    var fila = dgvdata.Rows[index];
                    PintarCeldasStockBajo(fila);
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
                        int index = dgvdata.Rows.Add(new object[] {
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
                            item.stockminimo,
                            item.estado == true ? 1 : 0,
                            item.estado == true ? "Activo" : "Inactivo",
                        });
                        var fila = dgvdata.Rows[index];
                        PintarCeldasStockBajo(fila);
                    }
                }
            }

        }

        private void cbocategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        // MÉTODO MostrarSoloRegistro CORREGIDO
        private void MostrarSoloRegistro(int idProducto)
        {
            // 1. OBTENER EL PRODUCTO ACTUALIZADO
            // Recargamos toda la lista desde la BD (listaProductos), pero SÓLO para obtener el dato más fresco del producto que nos interesa.
            List<Producto> listaActualizada = new CN_Producto().Listar();

            // 2. BUSCAR EL PRODUCTO ESPECÍFICO
            Producto item = listaActualizada.FirstOrDefault(p => p.Id == idProducto);

            // Si encontramos el producto
            if (item != null)
            {
                // 3. LIMPIAR la grilla SOLO para el registro o edición simple, luego mostrarlo.
                // Si quieres que solo se vea el registro insertado/editado, debes limpiar la grilla.
                dgvdata.Rows.Clear(); // Limpiamos para mostrar SÓLO el registro de interés

                // 4. INSERTAR la nueva fila con los datos (Asegúrate que el orden sea correcto)
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
                    item.stockminimo,
                    item.estado == true ? 1 : 0,
                    item.estado == true ? "Activo" : "Inactivo",
                 });

                // 5. Actualizar la lista global en memoria (¡CRUCIAL para la búsqueda en tiempo real!)
                // La mejor práctica es:
                listaProductos = listaActualizada;

                // Opcional: Centrar la selección en la nueva fila.
                if (dgvdata.Rows.Count > 0)
                {
                    dgvdata.ClearSelection();
                    dgvdata.Rows[0].Selected = true;
                }
            }
        }

        private void btnLimpiarFiltro_Click(object sender, EventArgs e)
        {
            txtbusquedaproducto.Text = "";
            Limpiar();
        }

        private void cboproductos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}