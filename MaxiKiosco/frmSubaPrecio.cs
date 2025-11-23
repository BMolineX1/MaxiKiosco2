using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CapaNegocio;
using CapaEntidad;

namespace MaxiKiosco
{
    public partial class frmSubaPrecio : Form
    {
        // ====================== Código Funcionalidad Global ==========================

        private CN_Categoria categoriaService = new CN_Categoria();
        private CN_Proveedor proveedorService = new CN_Proveedor();
        private CN_Producto productoService = new CN_Producto();

        // Cache de productos para modo "Unidad"
        private List<Producto> _productosUnidadCache = new List<Producto>();
        private Producto _productoSeleccionadoUnidad;   // ⬅️ producto elegido desde la grilla

        public frmSubaPrecio()
        {
            InitializeComponent();

            dgwpreview.DataBindingComplete += (s, e) => ConfigurarEstilosDataGridView();

            // Editar precio unitario desde la grilla (si querés seguir usando NuevoPrecio)
            dgwpreview.CellEndEdit += dgwpreview_CellEndEdit;

            // Filtrar mientras escribís en el combo de búsqueda (modo Unidad)
            comboFiltro.TextChanged += comboFiltro_TextChanged;

            // Click en la grilla para seleccionar producto
            dgwpreview.CellClick += dgwpreview_CellClick;

            // Eventos del textbox de precio de venta
            txtPrecioVenta.KeyDown += txtPrecioVenta_KeyDown;
            txtPrecioVenta.Leave += txtPrecioVenta_Leave;
        }


        private void frmSubaPrecio_Load(object sender, EventArgs e)
        {
            lblFiltro.Visible = false;
            comboFiltro.Visible = false;
            lblPorcentajeActual.Visible = false;

            // al inicio oculto el txt de precio unitario
            txtPrecioVenta.Visible = false;

            comboxAumentarPor.Items.Add("Categoria");
            comboxAumentarPor.Items.Add("Proveedor");
            comboxAumentarPor.Items.Add("Unidad");
            comboxAumentarPor.SelectedIndex = 0;

            ConfigurarEstilosDataGridView();
        }

        // ====================== Carga de DataGrid ==========================

        private void CargarDataGrid()
        {
            string tipoFiltro = comboxAumentarPor.SelectedItem?.ToString() ?? "";
            dgwpreview.DataSource = null;
            dgwpreview.Columns.Clear();

            if (string.IsNullOrEmpty(tipoFiltro))
                return;

            decimal nuevoPorcentaje = numericNuevoAumento.Value;

            // ----- MODO UNIDAD: cambio de precio manual por producto -----
            if (tipoFiltro == "Unidad")
            {
                if (_productosUnidadCache == null || _productosUnidadCache.Count == 0)
                {
                    _productosUnidadCache = productoService.Listar();
                }

                string texto = comboFiltro.Text.Trim().ToUpper();

                IEnumerable<Producto> filtrados = _productosUnidadCache;

                if (!string.IsNullOrEmpty(texto))
                {
                    bool esSoloNumero = texto.All(char.IsDigit);

                    if (esSoloNumero)
                    {
                        // Buscar SOLO por código
                        filtrados = filtrados.Where(p =>
                            (p.codigo ?? "").ToUpper().Contains(texto)
                        );
                    }
                    else
                    {
                        // Buscar SOLO por nombre
                        filtrados = filtrados.Where(p =>
                            (p.nombre ?? "").ToUpper().Contains(texto)
                        );
                    }
                }

                DataTable dt = new DataTable();
                dt.Columns.Add("IdProducto", typeof(int));
                dt.Columns.Add("Codigo", typeof(string));
                dt.Columns.Add("Producto", typeof(string));
                dt.Columns.Add("PrecioActual", typeof(decimal));
                dt.Columns.Add("NuevoPrecio", typeof(decimal));

                foreach (var p in filtrados)
                {
                    // Truncamos el precio para mostrar 25156 en vez de 25156,72
                    decimal precioEntero = Math.Truncate(p.precioventa);

                    dt.Rows.Add(
                        p.Id,
                        p.codigo,
                        p.nombre,
                        precioEntero,
                        precioEntero
                    );
                }

                dgwpreview.DataSource = dt;
                ConfigurarEstilosDataGridView();

                if (dgwpreview.Columns.Contains("IdProducto"))
                    dgwpreview.Columns["IdProducto"].Visible = false;

                return;
            }

            // ----- MODO CATEGORIA / PROVEEDOR: con porcentaje -----

            if (!comboFiltro.Visible || comboFiltro.SelectedIndex == -1 || comboFiltro.SelectedValue == null)
                return;

            if (!int.TryParse(comboFiltro.SelectedValue.ToString(), out int idFiltro))
                return;

            DataTable dtProductos = productoService.PrevisualizarAumento(
                tipoFiltro,
                idFiltro,
                nuevoPorcentaje
            );

            dgwpreview.DataSource = dtProductos;
            ConfigurarEstilosDataGridView();
        }

        private void ConfigurarEstilosDataGridView()
        {
            dgwpreview.EnableHeadersVisualStyles = false;

            dgwpreview.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(4, 150, 197);
            dgwpreview.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgwpreview.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgwpreview.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(4, 150, 197);
            dgwpreview.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;
            dgwpreview.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgwpreview.RowsDefaultCellStyle.BackColor = Color.White;
            dgwpreview.RowsDefaultCellStyle.ForeColor = Color.Black;
            dgwpreview.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 192, 128);
            dgwpreview.RowsDefaultCellStyle.SelectionForeColor = Color.Black;
            dgwpreview.RowsDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Regular);

            dgwpreview.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dgwpreview.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;
            dgwpreview.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 192, 128);
            dgwpreview.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.Black;

            dgwpreview.RowHeadersVisible = false;

            if (dgwpreview.Columns.Count > 0)
            {
                if (dgwpreview.Columns.Contains("Producto"))
                    dgwpreview.Columns["Producto"].Width = 200;

                if (dgwpreview.Columns.Contains("Categoria"))
                    dgwpreview.Columns["Categoria"].Width = 200;

                if (dgwpreview.Columns.Contains("Proveedor"))
                    dgwpreview.Columns["Proveedor"].Width = 200;

                if (dgwpreview.Columns.Contains("Codigo"))
                    dgwpreview.Columns["Codigo"].Width = 120;

                if (dgwpreview.Columns.Contains("PrecioActual"))
                    dgwpreview.Columns["PrecioActual"].Width = 120;

                if (dgwpreview.Columns.Contains("NuevoPrecio"))
                    dgwpreview.Columns["NuevoPrecio"].Width = 120;
            }

            if (dgwpreview.Columns.Contains("PrecioActual"))
                dgwpreview.Columns["PrecioActual"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            if (dgwpreview.Columns.Contains("NuevoPrecio"))
                dgwpreview.Columns["NuevoPrecio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        // ====================== Selección de tipo (Categoria / Proveedor / Unidad) ==========================

        private void comboxAumentarPor_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboFiltro.DataSource = null;

            if (comboxAumentarPor.SelectedIndex == -1)
                return;

            string tipoSeleccionado = comboxAumentarPor.SelectedItem.ToString();

            if (tipoSeleccionado == "Categoria" || tipoSeleccionado == "Proveedor")
            {
                // Mostrar combo y label, ocultar precio venta
                lblFiltro.Visible = true;
                comboFiltro.Visible = true;
                lblPorcentajeActual.Visible = true;
                txtPrecioVenta.Visible = false;
            }
            else if (tipoSeleccionado == "Unidad")
            {
                // Usamos comboFiltro como caja de búsqueda, y mostramos txtPrecioVenta
                lblFiltro.Visible = true;
                comboFiltro.Visible = true;
                lblPorcentajeActual.Visible = false;
                lblPorcentajeActual.Text = "0.00%";
                txtPrecioVenta.Visible = true;
                txtPrecioVenta.Text = "";
            }
            else
            {
                lblFiltro.Visible = false;
                comboFiltro.Visible = false;
                lblPorcentajeActual.Visible = false;
                txtPrecioVenta.Visible = false;
                return;
            }

            if (tipoSeleccionado == "Categoria")
            {
                lblFiltro.Text = "Seleccionar Categoría:";
                comboFiltro.DropDownStyle = ComboBoxStyle.DropDownList;

                comboFiltro.DataSource = categoriaService.Listar();
                comboFiltro.DisplayMember = "nombre_categoria";
                comboFiltro.ValueMember = "Id";
            }
            else if (tipoSeleccionado == "Proveedor")
            {
                lblFiltro.Text = "Seleccionar Proveedor:";
                comboFiltro.DropDownStyle = ComboBoxStyle.DropDownList;

                comboFiltro.DataSource = proveedorService.Listar();
                comboFiltro.DisplayMember = "razonsocial";
                comboFiltro.ValueMember = "id";
            }
            else if (tipoSeleccionado == "Unidad")
            {
                lblFiltro.Text = "Buscar producto (código o nombre):";
                comboFiltro.DropDownStyle = ComboBoxStyle.DropDown; // se puede escribir

                _productosUnidadCache = productoService.Listar();

                var listaCombo = _productosUnidadCache
                    .Select(p => new
                    {
                        Id = p.Id,
                        Descripcion = (string.IsNullOrEmpty(p.codigo) ? "" : p.codigo + " - ") + p.nombre
                    })
                    .OrderBy(x => x.Descripcion)
                    .ToList();

                comboFiltro.DataSource = listaCombo;
                comboFiltro.DisplayMember = "Descripcion";
                comboFiltro.ValueMember = "Id";
            }

            lblPorcentajeActual.Text = "0.00%";
            CargarDataGrid();
        }

        private void comboFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!comboFiltro.Visible)
            {
                lblPorcentajeActual.Text = "0.00%";
                CargarDataGrid();
                return;
            }

            string tipoSeleccionado = comboxAumentarPor.SelectedItem?.ToString() ?? "";

            // En Unidad no mostramos "aumento actual", sólo manual
            if (tipoSeleccionado == "Unidad")
            {
                lblPorcentajeActual.Visible = false;
                lblPorcentajeActual.Text = "0.00%";
                ActualizarPrevisualizacion();
                CargarDataGrid();
                return;
            }

            if (comboFiltro.SelectedIndex == -1 || comboFiltro.SelectedValue == null)
            {
                lblPorcentajeActual.Text = "0.00%";
                CargarDataGrid();
                return;
            }

            string valorSeleccionado = comboFiltro.SelectedValue.ToString();
            if (!int.TryParse(valorSeleccionado, out int idFiltro))
            {
                lblPorcentajeActual.Text = "0.00%";
                CargarDataGrid();
                return;
            }

            decimal porcentajeActual = 0m;

            if (tipoSeleccionado == "Categoria")
            {
                porcentajeActual = categoriaService.ObtenerPorcentajeAumento(idFiltro);
                lblPorcentajeActual.Visible = true;
                lblPorcentajeActual.Text = $"{porcentajeActual:F2}%";
            }
            else if (tipoSeleccionado == "Proveedor")
            {
                porcentajeActual = proveedorService.ObtenerPorcentajeAumento(idFiltro);
                lblPorcentajeActual.Visible = true;
                lblPorcentajeActual.Text = $"{porcentajeActual:F2}%";
            }

            ActualizarPrevisualizacion();
            CargarDataGrid();
        }

        // Filtrar en tiempo real PARA UNIDAD
        private void comboFiltro_TextChanged(object sender, EventArgs e)
        {
            if (comboxAumentarPor.SelectedItem?.ToString() == "Unidad")
            {
                CargarDataGrid();
            }
        }

        // ====================== Eventos NumericUpDown (para % masivo) ==========================

        private void numericNuevoAumento_ValueChanged(object sender, EventArgs e)
        {
            ActualizarPrevisualizacion();
            CargarDataGrid();
        }

        private void numericNuevoAumento_Leave(object sender, EventArgs e)
        {
            ActualizarPrevisualizacion();
            CargarDataGrid();
        }

        private void numericNuevoAumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            ActualizarPrevisualizacion();
            CargarDataGrid();
        }

        // ====================== Aplicar Aumento Porcentaje ==========================

        private void btnAplicarAumento_Click(object sender, EventArgs e)
        {
            string tipoFiltro = comboxAumentarPor.SelectedItem?.ToString() ?? "";

            // El % tiene sentido para Categoria / Proveedor
            if (tipoFiltro != "Unidad" && (comboFiltro.Visible && comboFiltro.SelectedIndex == -1))
            {
                MessageBox.Show("Debe seleccionar un filtro (Categoría o Proveedor).",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!decimal.TryParse(numericNuevoAumento.Value.ToString(), out decimal nuevoPorcentaje))
            {
                MessageBox.Show("Ingrese un porcentaje de aumento válido.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultadoConfirmacion = MessageBox.Show(
                $"¿Está seguro de aplicar un aumento de {nuevoPorcentaje:F2}% según el filtro '{tipoFiltro}'?\n\n¡Esta acción no se puede deshacer!",
                "Confirmar Aumento de Precios",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (resultadoConfirmacion != DialogResult.Yes)
            {
                MessageBox.Show("Operación cancelada por el usuario.",
                    "Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int idFiltro = 0;

            if (tipoFiltro == "Unidad")
            {
                // (opcional si querés aplicar % a un solo producto)
                if (comboFiltro.SelectedValue == null ||
                    !int.TryParse(comboFiltro.SelectedValue.ToString(), out idFiltro))
                {
                    MessageBox.Show("Seleccione un producto del listado para aplicar aumento por porcentaje.",
                        "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            else
            {
                idFiltro = Convert.ToInt32(comboFiltro.SelectedValue);
            }

            string mensaje = string.Empty;
            bool resultado = productoService.AplicarAumento(tipoFiltro, idFiltro, nuevoPorcentaje, out mensaje);

            if (resultado)
            {
                MessageBox.Show($"¡Aumento aplicado con éxito!\n{mensaje}",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarDataGrid();
            }
            else
            {
                MessageBox.Show($"Fallo al aplicar aumento:\n{mensaje}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ====================== Click en la grilla (Unidad) ==========================

        private void dgwpreview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (comboxAumentarPor.SelectedItem?.ToString() != "Unidad") return;

            DataGridViewRow row = dgwpreview.Rows[e.RowIndex];

            if (row.Cells["IdProducto"].Value == null) return;
            int idProd;
            try 
            {
                idProd = Convert.ToInt32(row.Cells["IdProducto"].Value);
            }catch (Exception ex)
            {
                return; 
            }
            
            _productoSeleccionadoUnidad = _productosUnidadCache.FirstOrDefault(p => p.Id == idProd);

            if (_productoSeleccionadoUnidad == null) return;

            // Rellenar buscador con el NOMBRE (podés poner tambien el código si querés)
            comboFiltro.Text = _productoSeleccionadoUnidad.nombre;

            // Rellenar txtPrecioVenta con el precio REAL (no truncado)
            txtPrecioVenta.Text = _productoSeleccionadoUnidad.precioventa.ToString("N2");
        }

        // ====================== Editar precio directo desde la grilla (Unidad) ==========================

        private void dgwpreview_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            if (comboxAumentarPor.SelectedItem?.ToString() != "Unidad")
                return;

            var grid = dgwpreview;
            string colName = grid.Columns[e.ColumnIndex].Name;

            if (colName != "NuevoPrecio")
                return;

            DataGridViewRow row = grid.Rows[e.RowIndex];

            if (!int.TryParse(row.Cells["IdProducto"].Value?.ToString(), out int idProd))
                return;

            string valorNuevo = Convert.ToString(row.Cells["NuevoPrecio"].Value);
            if (!decimal.TryParse(valorNuevo, out decimal nuevoPrecio) || nuevoPrecio <= 0)
            {
                MessageBox.Show("Ingrese un precio válido mayor a cero.",
                    "Precio inválido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                row.Cells["NuevoPrecio"].Value = row.Cells["PrecioActual"].Value;
                return;
            }

            string mensaje;
            bool ok = new CN_Producto().ActualizarPrecioUnitario(idProd, nuevoPrecio, out mensaje);

            if (ok)
            {
                row.Cells["PrecioActual"].Value = nuevoPrecio;
                MessageBox.Show("Precio actualizado correctamente.",
                    "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se pudo actualizar el precio:\n" + mensaje,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                row.Cells["NuevoPrecio"].Value = row.Cells["PrecioActual"].Value;
            }
        }

        // ====================== Editar precio desde txtPrecioVenta ==========================

        private void txtPrecioVenta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                GuardarPrecioDesdeTextBox();
            }
        }

        private void txtPrecioVenta_Leave(object sender, EventArgs e)
        {
            GuardarPrecioDesdeTextBox();
        }

        private void GuardarPrecioDesdeTextBox()
        {
            if (comboxAumentarPor.SelectedItem?.ToString() != "Unidad") return;
            if (_productoSeleccionadoUnidad == null) return;

            string texto = txtPrecioVenta.Text.Trim();
            if (string.IsNullOrEmpty(texto)) return;

            if (!decimal.TryParse(texto, out decimal nuevoPrecio) || nuevoPrecio <= 0)
            {
                MessageBox.Show("Ingrese un precio válido mayor a cero.",
                    "Precio inválido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPrecioVenta.Text = _productoSeleccionadoUnidad.precioventa.ToString("N2");
                return;
            }

            string mensaje;
            bool ok = new CN_Producto().ActualizarPrecioUnitario(_productoSeleccionadoUnidad.Id, nuevoPrecio, out mensaje);

            if (!ok)
            {
                MessageBox.Show("No se pudo actualizar el precio:\n" + mensaje,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPrecioVenta.Text = _productoSeleccionadoUnidad.precioventa.ToString("N2");
                return;
            }

            // Actualizar el objeto en cache
            _productoSeleccionadoUnidad.precioventa = nuevoPrecio;

            // Refrescar la grilla manteniendo el filtro actual
            CargarDataGrid();
        }

        // ====================== Función Auxiliar ==========================

        private void ActualizarPrevisualizacion()
        {
            decimal nuevoAumento = 0m;
            decimal.TryParse(numericNuevoAumento.Value.ToString(), out nuevoAumento);
            decimal porcentajeTotal = nuevoAumento;
            decimal precioEjemplo = 100m;
            decimal nuevoPrecio = precioEjemplo * (1 + (porcentajeTotal / 100));

            lblCambio.Text = $"Se aumentará el {porcentajeTotal:F2}% (Ej: 100 -> {nuevoPrecio:C2})";
        }
    }
}
