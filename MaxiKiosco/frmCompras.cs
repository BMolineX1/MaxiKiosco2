using CapaDatos;
using CapaEntidad;
using CapaNegocio;
using FontAwesome.Sharp;
using MaxiKiosco.Modales;
using MaxiKiosco.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;        // Color
using System.Globalization;  // parseo decimales
using System.Linq;
using System.Text;
using System.Text.RegularExpressions; // regex doc
using System.Windows.Forms;

namespace MaxiKiosco
{
    public partial class frmCompras : Form
    {
        private Usuario _Usuario;
        private Producto _productoActual = null;

        // Cache para sugerencias
        private List<Producto> _productosCache = new List<Producto>();
        private List<Proveedor> _proveedoresCache = new List<Proveedor>();

        // Formato típico AR: 0001-00000001
        private static readonly Regex RxNumDocGuion = new Regex(@"^\d{4}-\d{8}$", RegexOptions.Compiled);

        // Variables globales sobre datos fiscale de calculos.
        private const decimal IVA_PERCENTAJE = 0.21m;// IVA del producto (21%)


        public frmCompras(Usuario oUsuario = null)
        {
            _Usuario = oUsuario;

            InitializeComponent();

        }

        private void frmCompras_Load(object sender, EventArgs e)
        {
            // Fecha (TextBox)
            SetFechaHoy();

            // Tipo de comprobantes
            cbotipodocumento.Items.Add(new OpcionCombo() { Valor = "Factura A", texto = "Factura A" });
            cbotipodocumento.Items.Add(new OpcionCombo() { Valor = "Factura B", texto = "Factura B" });
            cbotipodocumento.Items.Add(new OpcionCombo() { Valor = "Nota de Crédito", texto = "Nota de Crédito" });

            cbotipodocumento.DisplayMember = "texto";
            cbotipodocumento.ValueMember = "Valor";

            cbotipodocumento.SelectedIndex = 0;

            // Defaults
            txtidproveedor.Text = "0";
            txtidproducto.Text = "0";

            // Config mínima del grid (NO toco tamaño ni autosize)
            ConfigurarColumnasGridSeguras();

            // Preparo caches para sugerencias
            _productosCache = new CN_Producto().Listar() ?? new List<Producto>();
            _proveedoresCache = new CN_Proveedor().Listar() ?? new List<Proveedor>();

            // Sugerencias producto
            ConfigurarSugerenciasProducto();

            // Sugerencias proveedor
            ConfigurarSugerenciasProveedor();

            // Eventos de edición de precio venta -> recalcula IVA por producto
            txtprecioventaproducto.TextChanged += (s, ev) => RecalcIvaProducto();
            txtprecioventaproducto.KeyPress += txtprecioventaproducto_KeyPress;

            // Precio compra validación de entrada
            txtpreciocompraproducto.KeyPress += txtpreciocompraproducto_KeyPress;

            // Handlers que pediste explícitos
            textcodproducto.KeyDown += textcodproducto_KeyDown;
            txtnombreproveedor.KeyDown += txtnombreproveedor_KeyDown;
        }

        // Este metodo es el que realiza el cambio de ventana o no.
        public bool PuedeCambiarDeVentana()
        {
            // 1. Verificamos si hay filas de productos agregados
            bool hayItemsEnCarrito = dgvdata.Rows.Cast<DataGridViewRow>().Any(r => !r.IsNewRow);

            if (hayItemsEnCarrito)
            {
                // 2. Mostrar la ventana de diálogo de confirmación
                DialogResult result = MessageBox.Show(
                    "Hay productos agregados al carrito. Si cambia de opción, se perderá el progreso. ¿Desea continuar?",
                    "Advertencia de Pérdida de Datos",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                // Retorna true solo si el usuario dijo 'Sí'
                return result == DialogResult.Yes;
            }

            // Si no hay ítems en el carrito, SIEMPRE se puede cambiar de ventana.
            return true;
        }

        /* =========================
         *  FECHA (TextBox)
         * ========================= */
        private void SetFechaHoy()
        {
            var hoy = DateTime.Now;
            // txtfecha es TextBox
            txtfecha.Text = hoy.ToString("dd/MM/yyyy");
            txtfecha.ReadOnly = true;
            txtfecha.TabStop = false;
            txtfecha.BackColor = SystemColors.Control;
            txtfecha.KeyPress += (s, e) => { e.Handled = true; }; // bloquear edición
        }

        /* =========================
         *  CONFIG DGV (mínimo, sin tocar tamaño)
         * ========================= */
        private void ConfigurarColumnasGridSeguras()
        {
            // Estas columnas deben existir en el diseñador con EXACTO Name:
            // idproducto, btneliminar, NombreProducto, PrecioCompra, PrecioVenta, Cantidad, SubTotal

            SetColDecimal("PrecioCompra");
            SetColDecimal("PrecioVenta");
            SetColInt("Cantidad");
            SetColDecimal("SubTotal");

            if (dgvdata.Columns.Contains("idproducto"))
            {
                dgvdata.Columns["idproducto"].ValueType = typeof(int);
                dgvdata.Columns["idproducto"].Visible = false; // si querés visualizarla, poner true
            }

            dgvdata.AllowUserToAddRows = false;
            dgvdata.RowHeadersVisible = false;
        }

        private void SetColDecimal(string name)
        {
            if (dgvdata.Columns.Contains(name))
            {
                dgvdata.Columns[name].ValueType = typeof(decimal);
                dgvdata.Columns[name].DefaultCellStyle.Format = "N2";
                dgvdata.Columns[name].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }
        private void SetColInt(string name)
        {
            if (dgvdata.Columns.Contains(name))
            {
                dgvdata.Columns[name].ValueType = typeof(int);
                dgvdata.Columns[name].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }

        /* =========================
         *  SUGERENCIAS: helpers
         * ========================= */
        private static string Normalize(string s)
        {
            if (string.IsNullOrEmpty(s)) return string.Empty;
            var norm = s.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();
            foreach (char ch in norm)
            {
                var cat = System.Globalization.CharUnicodeInfo.GetUnicodeCategory(ch);
                if (cat != System.Globalization.UnicodeCategory.NonSpacingMark) sb.Append(ch);
            }
            return sb.ToString().Normalize(NormalizationForm.FormC).ToUpperInvariant();
        }
        private static bool Like(string haystack, string needle) => Normalize(haystack).Contains(Normalize(needle));

        // ===== Items para mostrar SOLO un campo =====
        private sealed class ItemSugCodigo
        {
            public int Id { get; }
            public string Codigo { get; }
            public string Texto { get; }
            public ItemSugCodigo(int id, string codigo) { Id = id; Codigo = codigo ?? ""; Texto = Codigo; }
            public override string ToString() => Texto;
        }
        private sealed class ItemSugNombreProd
        {
            public int Id { get; }
            public string Nombre { get; }
            public string Texto { get; }
            public ItemSugNombreProd(int id, string nombre) { Id = id; Nombre = nombre ?? ""; Texto = Nombre; }
            public override string ToString() => Texto;
        }
        private sealed class ItemSugNombreProv
        {
            public int Id { get; }
            public string Nombre { get; }
            public string Razon { get; }
            public string Texto { get; }  // solo nombre visible
            public ItemSugNombreProv(int id, string nombre, string razon)
            { Id = id; Nombre = nombre ?? ""; Razon = razon ?? ""; Texto = Nombre; }
            public override string ToString() => Texto;
        }

        /* =========================
         *  SUGERENCIAS PRODUCTO
         * ========================= */
        private void ConfigurarSugerenciasProducto()
        {
            // ListBox códigos
            lbcodproducto.Visible = false;
            lbcodproducto.DisplayMember = "Texto";
            lbcodproducto.Click += (s, e) => ConfirmarSeleccionCodigo();
            lbcodproducto.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter) { ConfirmarSeleccionCodigo(); e.Handled = true; }
                else if (e.KeyCode == Keys.Escape) { lbcodproducto.Visible = false; textcodproducto.Focus(); e.Handled = true; }
            };

            // ListBox nombres
            lbnombreproducto.Visible = false;
            lbnombreproducto.DisplayMember = "Texto";
            lbnombreproducto.Click += (s, e) => ConfirmarSeleccionNombreProducto();
            lbnombreproducto.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter) { ConfirmarSeleccionNombreProducto(); e.Handled = true; }
                else if (e.KeyCode == Keys.Escape) { lbnombreproducto.Visible = false; txtnombreproducto.Focus(); e.Handled = true; }
            };

            // Eventos de texto
            textcodproducto.TextChanged += textcodproducto_TextChanged_SoloCodigos;
            textcodproducto.KeyDown += textcodproducto_KeyDown_SoloEnter;

            txtnombreproducto.TextChanged += txtnombreproducto_TextChanged_SoloNombres;
            txtnombreproducto.KeyDown += txtnombreproducto_KeyDown_SoloEnter;
        }

        // Código -> lbcodproducto (solo códigos)
        private void textcodproducto_TextChanged_SoloCodigos(object sender, EventArgs e)
        {
            string q = (textcodproducto.Text ?? "").Trim();

            lbcodproducto.Left = textcodproducto.Left;
            lbcodproducto.Top = textcodproducto.Bottom + 2;
            lbcodproducto.Width = textcodproducto.Width;

            if (q.Length == 0 || _productosCache.Count == 0)
            {
                lbcodproducto.Visible = false;
                LimpiarCamposProducto(); // <--- ✅ Usamos tu método de limpieza
                return;
            }

            var sugs = _productosCache
                .Where(p => Like(p.codigo ?? "", q))
                .OrderBy(p => p.codigo)
                .Take(20)
                .Select(p => new ItemSugCodigo(p.Id, p.codigo))
                .ToList();

            if (sugs.Count == 0) { lbcodproducto.Visible = false; return; }

            lbcodproducto.BeginUpdate();
            lbcodproducto.DataSource = null;
            lbcodproducto.Items.Clear();
            lbcodproducto.DataSource = sugs; // Muestra solo el código
            lbcodproducto.EndUpdate();
            lbcodproducto.Visible = true;
        }

        private void ConfirmarSeleccionCodigo()
        {
            if (lbcodproducto.SelectedItem is ItemSugCodigo it)
            {
                // Completa SOLO el textbox de código
                textcodproducto.Text = it.Codigo ?? "";
                lbcodproducto.Visible = false;

                var prod = _productosCache.FirstOrDefault(p => p.Id == it.Id);
                if (prod != null) CargarDatosProducto(prod);
            }
        }

        private void textcodproducto_KeyDown_SoloEnter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string cod = (textcodproducto.Text ?? "").Trim();
                var prod = _productosCache.FirstOrDefault(p => string.Equals(p.codigo ?? "", cod, StringComparison.OrdinalIgnoreCase));

                if (prod != null)
                    CargarDatosProducto(prod);
                else
                    MessageBox.Show("Código de producto no encontrado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                e.SuppressKeyPress = true;
            }
        }

        // Nombre -> lbnombreproducto (solo nombres)
        private void txtnombreproducto_TextChanged_SoloNombres(object sender, EventArgs e)
        {
            string q = (txtnombreproducto.Text ?? "").Trim();

            lbnombreproducto.Left = txtnombreproducto.Left;
            lbnombreproducto.Top = txtnombreproducto.Bottom + 2;
            lbnombreproducto.Width = txtnombreproducto.Width;

            if (q.Length == 0 || _productosCache.Count == 0)
            {
                lbnombreproducto.Visible = false;
                LimpiarCamposProducto(); // <--- ✅ Usamos tu método de limpieza
                return;
            }

            var sugs = _productosCache
                .Where(p => Like(p.nombre ?? "", q))
                .OrderBy(p => p.nombre)
                .Take(20)
                .Select(p => new ItemSugNombreProd(p.Id, p.nombre))
                .ToList();

            if (sugs.Count == 0) { lbnombreproducto.Visible = false; return; }

            lbnombreproducto.BeginUpdate();
            lbnombreproducto.DataSource = null;
            lbnombreproducto.Items.Clear();
            lbnombreproducto.DataSource = sugs; // Muestra solo el nombre
            lbnombreproducto.EndUpdate();
            lbnombreproducto.Visible = true;
        }

        private void ConfirmarSeleccionNombreProducto()
        {
            if (lbnombreproducto.SelectedItem is ItemSugNombreProd it)
            {
                // Completa SOLO el textbox de nombre
                txtnombreproducto.Text = it.Nombre ?? "";
                lbnombreproducto.Visible = false;

                var prod = _productosCache.FirstOrDefault(p => p.Id == it.Id);
                if (prod != null) CargarDatosProducto(prod);
            }
        }
        private void txtnombreproducto_KeyDown_SoloEnter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string q = (txtnombreproducto.Text ?? "").Trim();
                var prod = _productosCache.FirstOrDefault(p => Like(p.nombre ?? "", q));

                if (prod != null)
                    CargarDatosProducto(prod);
                else
                    MessageBox.Show("Producto no encontrado por Nombre.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                e.SuppressKeyPress = true;
            }
        }

        /* =========================
         *  SUGERENCIAS PROVEEDOR (por nombre)
         * ========================= */
        private void ConfigurarSugerenciasProveedor()
        {
            lbnombreproveedor.Visible = false;
            lbnombreproveedor.DisplayMember = "Texto";
            lbnombreproveedor.Click += (s, e) => ConfirmarSeleccionNombreProveedor();
            lbnombreproveedor.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter) { ConfirmarSeleccionNombreProveedor(); e.Handled = true; }
                else if (e.KeyCode == Keys.Escape) { lbnombreproveedor.Visible = false; txtnombreproveedor.Focus(); e.Handled = true; }
            };

            txtnombreproveedor.TextChanged += txtnombreproveedor_TextChanged_SoloNombres;
            // también quedó el KeyDown explícito:
            txtnombreproveedor.KeyDown += txtnombreproveedor_KeyDown;
        }

        private void txtnombreproveedor_TextChanged_SoloNombres(object sender, EventArgs e)
        {
            string q = (txtnombreproveedor.Text ?? "").Trim();

            lbnombreproveedor.Left = txtnombreproveedor.Left;
            lbnombreproveedor.Top = txtnombreproveedor.Bottom + 2;
            lbnombreproveedor.Width = txtnombreproveedor.Width;

            if (q.Length == 0 || _proveedoresCache.Count == 0)
            {
                lbnombreproveedor.Visible = false;
                return;
            }

            var sugs = _proveedoresCache
                .Where(p => Like(p.nombre ?? "", q))
                .OrderBy(p => p.nombre)
                .Take(20)
                .Select(p => new ItemSugNombreProv(p.id, p.nombre, p.razonsocial))
                .ToList();

            if (sugs.Count == 0) { lbnombreproveedor.Visible = false; return; }

            lbnombreproveedor.BeginUpdate();
            lbnombreproveedor.DataSource = null;
            lbnombreproveedor.Items.Clear();
            lbnombreproveedor.DataSource = sugs; // Muestra solo el nombre
            lbnombreproveedor.EndUpdate();
            lbnombreproveedor.Visible = true;
        }

        private void ConfirmarSeleccionNombreProveedor()
        {
            if (lbnombreproveedor.SelectedItem is ItemSugNombreProv it)
            {
                // Completa SOLO el nombre en el textbox, y asigna id/razón
                txtnombreproveedor.Text = it.Nombre ?? "";
                lbnombreproveedor.Visible = false;

                var prov = _proveedoresCache.FirstOrDefault(p => p.id == it.Id);
                if (prov != null)
                {
                    txtidproveedor.Text = prov.id.ToString();
                }
            }
        }

        // Handlers explícitos que pediste
        private void textcodproducto_KeyDown(object sender, KeyEventArgs e)
        {
            // Ya lo manejo con textcodproducto_KeyDown_SoloEnter, pero lo dejo por compat
            if (e.KeyCode == Keys.Enter)
            {
                textcodproducto_KeyDown_SoloEnter(sender, e);
                e.SuppressKeyPress = true;
            }
        }

        private void txtnombreproveedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && lbnombreproveedor.Visible && lbnombreproveedor.Items.Count > 0)
            {
                lbnombreproveedor.SelectedIndex = 0;
                ConfirmarSeleccionNombreProveedor();
                e.SuppressKeyPress = true;
            }
        }

        /* =========================
         *  BUSCAR PROVEEDOR / PRODUCTO (modal)
         * ========================= */
        private void btnbuscarproveedor_Click(object sender, EventArgs e)
        {
            using (var modal = new mdProveedor())
            {
                if (modal.ShowDialog() == DialogResult.OK && modal._Proveedor != null)
                {
                    txtidproveedor.Text = modal._Proveedor.id.ToString();
                    txtnombreproveedor.Text = modal._Proveedor.nombre;
                }
                else
                {
                    txtnombreproveedor.Select();
                }
            }
        }

        private void btnbuscarproducto_Click(object sender, EventArgs e)
        {
            using (var modal = new mdProducto())
            {
                if (modal.ShowDialog() == DialogResult.OK && modal._Producto != null)
                {
                    CargarDatosProducto(modal._Producto);
                }
            }
        }

        /* =========================
         *  CARGA DE PRODUCTO / IVA 21%
         * ========================= */
        private void CargarDatosProducto(Producto p)
        {
            // Guardar el objeto completo.
            _productoActual = p; // <--- ✅ Ahora _productoActual tiene el porcentaje_aumento

            // Carga datos base
            txtidproducto.Text = p.Id.ToString();
            textcodproducto.Text = p.codigo ?? "";
            txtnombreproducto.Text = p.nombre ?? "";
            // Asignar el Precio Compra del Producto a la interfaz (será editable)
            txtpreciocompraproducto.Text = p.preciocompra.ToString("0.00");
            // Aplicar el cálculo INICIAL usando el Precio Compra existente
            RecalcularPrecioVenta(); // <--- Llamamos a la nueva función de cálculos

            // Cantidad default
            txtcantidad.Value = 1;
            txtcantidad.Focus();

            // Ocultar LBs de sugerencias si quedaron abiertos
            lbcodproducto.Visible = false;
            lbnombreproducto.Visible = false;
        }

        private void RecalcularPrecioVenta()
        {
            decimal precioCompra;

            // 1. Validación Única y Extracción de datos
            if (_productoActual == null || !decimal.TryParse(txtpreciocompraproducto.Text, out precioCompra))
            {
                // Si la validación falla, limpiar y salir.
                txtprecioventaproducto.Text = "0.00";
                txtivaProducto.Text = "0.00";
                return;
            }

            // Si la validación pasa, 'precioCompra' ya contiene el valor.

            decimal porcentajeAumento = _productoActual.ocategoria?.porcentaje_aumento ?? 0m;
            decimal precioVentaCalculado;

            // --- CÁLCULO DE PRECIO VENTA (BASE PARA EL MARGEN) ---

            // 2. Cálculo del Precio de Venta Sugerido (PC + Margen)
            if (porcentajeAumento > 0)
            {
                // Fórmula: P_Venta = P_Compra * (1 + Margen/100)
                decimal multiplicador = 1 + (porcentajeAumento / 100m);

                // Aplicamos Math.Round para evitar el error de precisión que discutimos
                precioVentaCalculado = Math.Round(
                    precioCompra * multiplicador,
                    2,
                    MidpointRounding.AwayFromZero
                );
            }
            else
            {
                // Si no hay margen, el PV es el PC.
                precioVentaCalculado = precioCompra;
            }

            // --- CÁLCULO DEL IVA (BASE PARA EL CRÉDITO FISCAL) ---

            // 3. Calcular el Monto IVA por Unidad (Base: Precio Compra)
            decimal montoIvaPorUnidad = Math.Round(
                precioCompra * IVA_PERCENTAJE, // 🎯 CORRECTO: IVA calculado sobre el Precio Compra
                2,
                MidpointRounding.AwayFromZero
            );

            // 4. Actualización de los Campos y Objeto

            // Actualizar PV Sugerido
            txtprecioventaproducto.Text = precioVentaCalculado.ToString("0.00");

            // Actualizar el Monto IVA (Usamos el valor del PC)
            txtivaProducto.Text = montoIvaPorUnidad.ToString("0.00"); // ❌ ELIMINADA LA SOBRESCRITURA ANTERIOR

            // Actualización del Objeto Producto para el Carrito
            _productoActual.precioventa = precioVentaCalculado;
        }
        
        private void RecalcIvaProducto()
        {
            if (!decimal.TryParse(txtprecioventaproducto.Text, NumberStyles.Any, CultureInfo.CurrentCulture, out decimal pv) &&
                !decimal.TryParse(txtprecioventaproducto.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out pv))
            {
                pv = 0m;
            }
            txtivaProducto.Text = (pv * IVA_PERCENTAJE).ToString("0.00");
        }

        // DENTRO DE Form_Compra.cs
        private void txtpreciocompraproducto_Validated(object sender, EventArgs e)
        {
            // Ejecuta la lógica de recálculo cada vez que el usuario sale del TextBox de Precio Compra
            RecalcularPrecioVenta();
        }

        private void LimpiarCamposProducto()
        {
            txtidproducto.Text = "0";
            textcodproducto.Text = "";
            txtnombreproducto.Text = "";
            txtpreciocompraproducto.Text = "";
            txtprecioventaproducto.Text = "";
            txtivaProducto.Text = "0.00";
            txtcantidad.Value = 1;

            lbcodproducto.Visible = false;
            lbnombreproducto.Visible = false;

            txtnombreproducto.Select();
        }

        /* =========================
         *  AGREGAR / ELIMINAR ÍTEM
         * ========================= */
        private void btnagregarproducto_Click(object sender, EventArgs e)
        {
            // Validaciones
            if (!int.TryParse(txtidproducto.Text, out int idProd) || idProd <= 0)
            {
                MessageBox.Show("Debe seleccionar un producto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!decimal.TryParse(txtpreciocompraproducto.Text, NumberStyles.Any, CultureInfo.CurrentCulture, out decimal pc) &&
                !decimal.TryParse(txtpreciocompraproducto.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out pc))
            {
                MessageBox.Show("Precio Compra con formato inválido", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtpreciocompraproducto.Select(); return;
            }

            if (!decimal.TryParse(txtprecioventaproducto.Text, NumberStyles.Any, CultureInfo.CurrentCulture, out decimal pv) &&
                !decimal.TryParse(txtprecioventaproducto.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out pv))
            {
                MessageBox.Show("Precio Venta con formato inválido", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtprecioventaproducto.Select(); return;
            }

            int cant = (int)txtcantidad.Value;
            if (cant <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor a cero.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtcantidad.Select(); return;
            }


            // Duplicado
            foreach (DataGridViewRow fila in dgvdata.Rows)
            {
                if (fila.IsNewRow) continue;
                if ((fila.Cells["idproducto"]?.Value?.ToString() ?? "") == idProd.ToString())
                {
                    MessageBox.Show("El producto ya fue agregado.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            // --- CÁLCULO DE IVA Y BRUTO ---
            decimal tasaIVA = 0.21m; // Asumimos esta constante
            decimal montoIvaFila = (pc * cant) * tasaIVA;
            decimal subtotalBruto = (pc * cant) + montoIvaFila; // Neto + IVA

            decimal subtotal = cant * pc;

            // Agregar fila (en el orden de columnas del DGV)
            dgvdata.Rows.Add(new object[]
            {
                idProd,                               // idproducto (oculta)
                "Eliminar",                           // btneliminar (texto)
                txtnombreproducto.Text,               // NombreProducto
                pc,                                   // PrecioCompra (decimal)
                pv,                                   // PrecioVenta  (decimal)
                cant,                                 // Cantidad     (int)
                subtotalBruto,                        // SubTotal     (decimal)
                montoIvaFila                          // 🎯 NUEVO: MontoIVA (OCULTA, pero necesaria para el registro)
            });

            calcularTotal();
            LimpiarCamposProducto();
        }

        private void dgvdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvdata.Columns[e.ColumnIndex].Name == "btneliminar")
            {
                dgvdata.Rows.RemoveAt(e.RowIndex);
                calcularTotal();
            }
        }

        /* =========================
         *  TOTALES
         * ========================= */
        private void calcularTotal()
        {
            // 1. Inicialización de Acumuladores
            decimal totalBruto = 0m;
            decimal totalIVA = 0m; // 🎯 Acumulador para el IVA Total

            // Nota: totalNeto se calculará al final por diferencia (Bruto - IVA)

            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                if (row.IsNewRow) continue;

                // 1.1. Extracción y acumulación del SubTotal BRUTO
                var valBruto = row.Cells["SubTotalBruto"]?.Value;
                decimal subBruto = 0m;

                // Lógica de parseo robusta para SubTotal (Bruto)
                if (valBruto is decimal d) subBruto = d;
                else
                {
                    var s = valBruto?.ToString() ?? "0";
                    if (!decimal.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out subBruto) &&
                         !decimal.TryParse(s, NumberStyles.Any, CultureInfo.CurrentCulture, out subBruto))
                        subBruto = 0m;
                }
                totalBruto += subBruto;


                // 1.2. Extracción y acumulación del Monto IVA por Línea
                var valIVA = row.Cells["MontoIVA"]?.Value;
                decimal montoIvaFila = 0m;

                if (valIVA is decimal dIva) montoIvaFila = dIva;
                else
                {
                    // Opcional: lógica de parseo si la columna no es decimal
                    decimal.TryParse(valIVA?.ToString() ?? "0", out montoIvaFila);
                }
                totalIVA += montoIvaFila;
            }

            // --- CÁLCULOS FINALES ---

            // 2. Calcular el Total Neto (Por diferencia, ya que acumulamos el Bruto y el IVA)
            decimal totalNeto = totalBruto - totalIVA;

            // 3. Mostrar los Resultados en los TextBox

            // 3.1. Mostrar el Total IVA
            txtivaProducto.Text = totalIVA.ToString("0.00");

            // 3.2. Mostrar el Total Final (BRUTO)
            txttotalpagar.Text = totalBruto.ToString("0.00");

            // 3.3. Recomendación: Mostrar el Total Neto
            // Si tienes un campo para Total Neto (ej: txttotalneto), muéstralo:
            // txttotalneto.Text = totalNeto.ToString("0.00");
        }
        
        /* =========================
         *  REGISTRAR COMPRA
         * ========================= */
        private void btnregistrarcompra_Click(object sender, EventArgs e)
        {
            // Proveedor
            if (!int.TryParse(txtidproveedor.Text, out int proveedorId) || proveedorId <= 0)
            {
                MessageBox.Show("Debe seleccionar un proveedor", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Items
            bool hayFilas = dgvdata.Rows.Cast<DataGridViewRow>().Any(r => !r.IsNewRow);
            if (!hayFilas)
            {
                MessageBox.Show("Debe ingresar productos en la compra", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Total (parse robusto local/invariante)
            decimal montoTotalFinal;

            if (!decimal.TryParse(txttotalpagar.Text, NumberStyles.Any, CultureInfo.CurrentCulture, out montoTotalFinal) &&
                !decimal.TryParse(txttotalpagar.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out montoTotalFinal))
            {
                MessageBox.Show("El monto total no es válido.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Para simplificar, obtenemos el Total Neto de la grilla (base imponible)
            decimal totalNetoCompra = 0m;
            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                if (row.IsNewRow) continue;
                // Asumiendo la columna SubTotal (que es el neto)
                if (row.Cells["SubTotalBruto"]?.Value != null && decimal.TryParse(row.Cells["SubTotalBruto"].Value.ToString(), out decimal subTotalFila))
                {
                    totalNetoCompra += subTotalFila;
                }
            }

            if (totalNetoCompra <= 0)
            {
                MessageBox.Show("El total de la compra debe ser mayor a cero.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Variables para acumular los totales
            decimal montoTotalBruto = 0m; // 🎯 NUEVO: El total bruto de la compra (MontoTotal en la BD)
            decimal montoIvaTotal = 0m;   // 🎯 NUEVO: El IVA total de la compra
            decimal tasaIVA = 0.21m;      // Tasa de IVA fija para el cálculo

            // DataTable detalle
            // 1. Armar el DataTable e implementar cálculos
            DataTable detalle = new DataTable();
            detalle.Columns.Add("producto_id", typeof(int));
            detalle.Columns.Add("preciocompra", typeof(decimal));  // 👈 Usaremos este para el PRECIO NETO (Base Imponible)
            detalle.Columns.Add("precioventa", typeof(decimal));
            detalle.Columns.Add("cantidad", typeof(int));

            // CAMPOS DE IVA AGREGADOS AL DATATABLE
            detalle.Columns.Add("monto_iva", typeof(decimal));     // Monto IVA de la línea
            detalle.Columns.Add("precio_bruto", typeof(decimal)); // Precio unitario bruto

            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                if (row.IsNewRow) continue;

                if (!int.TryParse(row.Cells["idproducto"]?.Value?.ToString(), out int productoId) || productoId <= 0) continue;

                decimal precioNeto = ParseDecimalCell(row, "PrecioCompra"); // 👈 PRECIO NETO (Sin IVA)
                decimal precioVenta = ParseDecimalCell(row, "PrecioVenta");

                int cant = ParseIntCell(row, "Cantidad");
                if (cant <= 0) continue;

                // --- CÁLCULO DEL IVA POR FILA ---
                decimal montoIvaFila = (precioNeto * cant) * tasaIVA;
                decimal precioBrutoUnitario = precioNeto * (1 + tasaIVA);
                decimal montoBrutoFila = (precioNeto * cant) + montoIvaFila;

                // Acumular totales
                montoIvaTotal += montoIvaFila;
                montoTotalBruto += montoBrutoFila;

                // Agregar la fila al DataTable
                detalle.Rows.Add(productoId,
                                 precioNeto,         // preciocompra (Neto)
                                 precioVenta,
                                 cant,
                                 montoIvaFila,       // 🎯 monto_iva
                                 precioBrutoUnitario // 🎯 precio_bruto
                );
            }
            // Revalidar: Si no se pudo acumular nada
            if (montoTotalBruto <= 0)
            {
                MessageBox.Show("El total de la compra debe ser mayor a cero.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (detalle.Rows.Count == 0)
            {
                MessageBox.Show("El detalle de la compra no tiene filas válidas.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Tipo doc
            var oc = cbotipodocumento.SelectedItem as OpcionCombo;
            string tipoDoc = oc != null ? (oc.Valor?.ToString() ?? oc.texto ?? "").Trim() : (cbotipodocumento.Text ?? "").Trim();
            if (string.IsNullOrWhiteSpace(tipoDoc))
            {
                MessageBox.Show("Debe seleccionar el tipo de documento.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Nro documento correlativo
            int correlativo = new CN_Compra().ObtenerCorrelativo();
            string pvStr = "0001"; // Punto de venta fijo de ejemplo
            string nroStr = correlativo.ToString("D8", CultureInfo.InvariantCulture);
            string numeroDocumento = $"{pvStr}-{nroStr}";

            if (!RxNumDocGuion.IsMatch(numeroDocumento))
            {
                MessageBox.Show("Número de documento con formato inválido.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Entidad
            var compra = new Compra
            {
                empleadoid = _Usuario?.idusuario ?? 0,
                proveedorid = proveedorId,
                tipodocumento = tipoDoc,
                numerodocumento = numeroDocumento,
                montototal = montoTotalBruto,     // 👈 AHORA ES EL TOTAL BRUTO (Neto + IVA)
                monto_iva_total = montoIvaTotal, // 🎯 NUEVO CAMPO AGREGADO

                // compat
                ousuario = new Usuario { idusuario = (_Usuario?.idusuario ?? 0) },
                oproveedor = new Proveedor { id = proveedorId }
            };

            if (compra.empleadoid <= 0)
            {
                MessageBox.Show("Usuario no válido para registrar la compra.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Validación “soft” de productos existentes
            var ids = detalle.AsEnumerable().Select(r => (int)r["producto_id"]).Distinct().ToList();
            var existentes = new CN_Producto().Listar().Select(p => p.Id).ToHashSet();
            var faltantes = ids.Where(id => !existentes.Contains(id)).ToList();
            if (faltantes.Count > 0)
            {
                MessageBox.Show("Producto inexistente: " + faltantes.First(), "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Registrar
            var cn = new CN_Compra();
            if (cn.Registrar(compra, detalle, out var errores, out string mensaje))
            {
                MessageBox.Show(string.IsNullOrWhiteSpace(mensaje) ? "Compra registrada correctamente." : mensaje, "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);

                dgvdata.Rows.Clear();
                calcularTotal();
                LimpiarCamposProducto();

                if (MessageBox.Show("Número de compra:\n" + numeroDocumento + "\n\n¿Copiar al portapapeles?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    Clipboard.SetText(numeroDocumento);
            }
            else
            {
                var extra = (errores != null && errores.Count > 0) ? "\n• " + string.Join("\n• ", errores) : "";
                MessageBox.Show((string.IsNullOrWhiteSpace(mensaje) ? "No se pudo registrar la compra." : mensaje) + extra, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /* =========================
         *  HELPERS PARSEO
         * ========================= */
        private static decimal ParseDecimalCell(DataGridViewRow row, string column)
        {
            var val = row.Cells[column]?.Value;
            if (val is decimal d) return d;
            if (val is double db) return (decimal)db;
            var s = val?.ToString() ?? "0";
            if (decimal.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out d)) return d;
            if (decimal.TryParse(s, NumberStyles.Any, CultureInfo.CurrentCulture, out d)) return d;
            return 0m;
        }
        private static int ParseIntCell(DataGridViewRow row, string column)
        {
            var v = row.Cells[column]?.Value?.ToString() ?? "0";
            return int.TryParse(v, NumberStyles.Integer, CultureInfo.InvariantCulture, out var i)
                   || int.TryParse(v, NumberStyles.Integer, CultureInfo.CurrentCulture, out i)
                ? i : 0;
        }

        /* =========================
         *  VALIDACIONES DE ENTRADA (precio)
         * ========================= */
        private void txtpreciocompraproducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar)) return;
            if (char.IsDigit(e.KeyChar)) return;

            if ((e.KeyChar == '.' || e.KeyChar == ','))
            {
                var txt = txtpreciocompraproducto.Text;
                if (!txt.Contains('.') && !txt.Contains(',')) return;
            }
            e.Handled = true;
        }
        private void txtprecioventaproducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar)) return;
            if (char.IsDigit(e.KeyChar)) return;

            if ((e.KeyChar == '.' || e.KeyChar == ','))
            {
                var txt = txtprecioventaproducto.Text;
                if (!txt.Contains('.') && !txt.Contains(',')) return;
            }
            e.Handled = true;
        }

        private void txtpreciocompraproducto_TextChanged(object sender, EventArgs e)
        {
            // Llama al método que recalcula el PV y el IVA unitario
            RecalcularPrecioVenta();
        }
    }
}
