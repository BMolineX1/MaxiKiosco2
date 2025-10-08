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
                listaProductos = new CN_Producto().Listar();

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
            List<Categoria> listaCategoria = new CN_Categoria().Listar();
            foreach (var item in listaCategoria)
            {

                cbocategoria.Items.Add(new OpcionCombo() { Valor = item.Id, texto = item.nombre_categoria });
            }

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
            // 1. Verificar si los campos numéricos son válidos
            // Nota: Dejé la validación de txtcodigo.Text aquí, pero será manejada por la lógica GENERAR_INTERNO
            if (string.IsNullOrWhiteSpace(txtnombre.Text) ||
             string.IsNullOrWhiteSpace(txtprecioventa.Text) ||
             string.IsNullOrWhiteSpace(txtpreciocompra.Text) ||
             string.IsNullOrWhiteSpace(txtstock.Text))
            {
                MessageBox.Show("Debe completar los campos Nombre, Precios y Stock.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            // 2. PARSEO DE VALORES NUMÉRICOS (SEGURO)
            decimal precioventa;
            decimal preciocompra;
            int stock;
            int idproducto;
            int idestado;
            int idcategoria;

            // Usamos TryParse para asegurarnos de que el formato sea correcto
            if (!decimal.TryParse(txtprecioventa.Text, out precioventa) ||
                !decimal.TryParse(txtpreciocompra.Text, out preciocompra) ||
                !int.TryParse(txtstock.Text, out stock) ||
                !int.TryParse(txtidproducto.Text, out idproducto) ||
                !int.TryParse(((OpcionCombo)cboestado.SelectedItem).Valor.ToString(), out idestado) ||
                !int.TryParse(((OpcionCombo)cbocategoria.SelectedItem).Valor.ToString(), out idcategoria))
            {
                MessageBox.Show("Por favor, ingrese formatos numéricos válidos para Precios y/o Stock.", "Error de Formato", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // 3. LÓGICA DE CÓDIGO DE BARRAS (GENERACIÓN INTERNA)
            string codigoProducto = txtcodigo.Text.Trim();
            int idproducto_check = Convert.ToInt32(txtidproducto.Text); // Obtener el ID para chequear si es edición

            // Si NO es edición (Id = 0) Y el campo está vacío, usamos la bandera.
            if (idproducto_check == 0 && string.IsNullOrWhiteSpace(codigoProducto))
            {
                codigoProducto = "GENERAR_INTERNO";
            }

            // Si es edición (Id > 0) y el campo está vacío, simplemente lo dejamos vacío (""),
            // y la CN_Producto.Editar lo validará si es necesario.
            // Si es edición y tiene "GENERAR_INTERNO", significa que el usuario borró el campo,
            // lo cual debería fallar si el código de barras es obligatorio al editar. 

            // Si dejamos la lógica de arriba, funciona, porque si ID > 0, nunca entra al IF.
            // Hacemos una pequeña mejora en el IF para hacerlo más explícito:
            if (string.IsNullOrWhiteSpace(codigoProducto) && idproducto == 0)
            {
                codigoProducto = "GENERAR_INTERNO";
            }

            // 4. CREACIÓN DEL OBJETO PRODUCTO (USANDO VALORES PARSEADOS Y EL CÓDIGO MANEJADO)
            Producto objproducto = new Producto()
            {
                // [CORREGIDO]: Usar la variable 'idproducto' ya parseada
                Id = idproducto,
                nombre = txtnombre.Text,
                // [AGREGADO]: Usar la variable 'codigoProducto' con la bandera
                codigo = codigoProducto,
                // [CORREGIDO]: Usar las variables ya parseadas
                precioventa = precioventa,
                preciocompra = preciocompra,
                descripcion = txtdescripcion.Text,
                // Asignamos la fecha y hora del sistema.
                fecharegistro = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                // [CORREGIDO]: Usar las variables ya parseadas
                ocategoria = new Categoria() { Id = idcategoria },
                stock = stock,
                estado = idestado == 1 ? true : false,
            };

            // 5. LÓGICA DE REGISTRO/EDICIÓN
            if (objproducto.Id == 0) // REGISTRAR NUEVO
            {
                // La CN_Producto se encargará de reemplazar "GENERAR_INTERNO" por el código real
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
                // La edición no debe permitir GENERAR_INTERNO, la CN_Producto ya tiene esa validación.
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