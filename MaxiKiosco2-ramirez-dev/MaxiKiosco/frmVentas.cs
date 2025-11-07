using CapaDatos;
using CapaEntidad;
using CapaNegocio;
using MaxiKiosco.Modales;
using MaxiKiosco.Utilidades;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MaxiKiosco
{
    public partial class frmVentas : Form
    {
        private Usuario _Usuario;
        private int _clienteIdCC = 0;                  // ID del cliente para Cuenta Corriente
        private ComboBox cboMedioPago;                 // si no existe en diseñador, se crea por código

        // ====== AUTOCOMPLETE DE PRODUCTOS (por nombre/código) ======
        private System.Collections.Generic.List<Producto> _productos = new System.Collections.Generic.List<Producto>();

        // Item para la lista (id + texto visible)
        private sealed class ItemProd
        {
            public int Id { get; }
            public string Texto { get; }
            public ItemProd(int id, string texto) { Id = id; Texto = texto; }
            public override string ToString() => Texto;
        }

        public frmVentas(Usuario ousuario = null)
        {
            _Usuario = ousuario;
            InitializeComponent();
        }

        private void frmVentas_Load(object sender, EventArgs e)
        {
            // ====== Asegurar combo de Medio de Pago (si no está en diseñador) ======
            if (this.Controls.Find("cboMedioPago", true).FirstOrDefault() is ComboBox found)
            {
                cboMedioPago = found; // ya existe en diseñador
            }
            else
            {
                cboMedioPago = new ComboBox
                {
                    Name = "cboMedioPago",
                    DropDownStyle = ComboBoxStyle.DropDownList,
                    Width = 180,
                    Left = 20,   // ajustá posición
                    Top = 120
                };
                this.Controls.Add(cboMedioPago);
            }

            // ====== Tipo de documento ======
            cbotipodocumento.Items.Clear();
            cbotipodocumento.Items.Add(new OpcionCombo { Valor = "Boleta", texto = "Boleta" });
            cbotipodocumento.Items.Add(new OpcionCombo { Valor = "Factura", texto = "Factura" });
            cbotipodocumento.DisplayMember = "Texto";
            cbotipodocumento.ValueMember = "Valor";
            cbotipodocumento.SelectedIndex = 0;

            // ====== Medios de pago (incluye Cuenta Corriente) ======
            cboMedioPago.Items.Clear();
            cboMedioPago.Items.Add(new OpcionCombo { Valor = "Efectivo", texto = "Efectivo" });
            cboMedioPago.Items.Add(new OpcionCombo { Valor = "Tarjeta", texto = "Tarjeta" });
            cboMedioPago.Items.Add(new OpcionCombo { Valor = "Billetera Virtual", texto = "Billetera Virtual" });
            cboMedioPago.Items.Add(new OpcionCombo { Valor = "CuentaCorriente", texto = "Cuenta Corriente" }); // Valor EXACTO a comparar
            cboMedioPago.DisplayMember = "Texto";
            cboMedioPago.ValueMember = "Valor";
            cboMedioPago.SelectedIndex = 0;

            cboMedioPago.SelectedIndexChanged -= cboMedioPago_SelectedIndexChanged;
            cboMedioPago.SelectedIndexChanged += cboMedioPago_SelectedIndexChanged;
            ActualizarUIParaMedioPago(); // estado inicial

            // ====== Campos iniciales ======
            txtfechaventa.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtidproducto.Text = "0";
            txtpagacon.Text = "";
            txtcambio.Text = "";
            txttotalpagar.Text = "0";

            // ====== Precio y Stock SOLO informativos (bloqueados) ======
            txtprecioproducto.ReadOnly = true;
            txtprecioproducto.TabStop = false;
            txtprecioproducto.BackColor = SystemColors.Info;

            txtstock.ReadOnly = true;
            txtstock.TabStop = false;
            txtstock.BackColor = SystemColors.Info;

            if (dgvdata.Columns.Contains("Precio"))
                dgvdata.Columns["Precio"].DefaultCellStyle.Format = "N2";
            if (dgvdata.Columns.Contains("SubTotal"))
                dgvdata.Columns["SubTotal"].DefaultCellStyle.Format = "N2";

            dgvdata.CellContentClick -= dgvdata_CellContentClick;
            dgvdata.CellContentClick += dgvdata_CellContentClick;

            // Vinculación por DNI
            txtnumerodocumentocliente.Leave -= txtnumerodocumentocliente_Leave;
            txtnumerodocumentocliente.Leave += txtnumerodocumentocliente_Leave;
            txtnumerodocumentocliente.KeyDown -= txtnumerodocumentocliente_KeyDown;
            txtnumerodocumentocliente.KeyDown += txtnumerodocumentocliente_KeyDown;

            // ====== Cache de productos para sugerencias ======
            _productos = new CN_Producto().Listar().Where(p => p.estado).ToList();

            // ====== TU LISTBOX DE SUGERENCIAS ======
            lbproductobusqueda.Visible = false;
            lbproductobusqueda.Height = 140;
            lbproductobusqueda.Left = txtnombreproducto.Left;
            lbproductobusqueda.Top = txtnombreproducto.Bottom + 2;
            lbproductobusqueda.Width = txtnombreproducto.Width;
            lbproductobusqueda.BringToFront();

            lbproductobusqueda.Click -= lbproductobusqueda_Click;
            lbproductobusqueda.Click += lbproductobusqueda_Click;

            lbproductobusqueda.KeyDown -= lbproductobusqueda_KeyDown;
            lbproductobusqueda.KeyDown += lbproductobusqueda_KeyDown;

            // Eventos del textbox nombre
            txtnombreproducto.TextChanged -= txtnombreproducto_TextChanged;
            txtnombreproducto.TextChanged += txtnombreproducto_TextChanged;

            txtnombreproducto.KeyDown -= txtnombreproducto_KeyDown;
            txtnombreproducto.KeyDown += txtnombreproducto_KeyDown;
        }

        // ===================== UI: Medios de pago =====================
        private void cboMedioPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarUIParaMedioPago();
        }

        private void ActualizarUIParaMedioPago()
        {
            string medio = (cboMedioPago.SelectedItem as OpcionCombo)?.Valor?.ToString() ?? "Efectivo";
            bool esCC = (medio == "CuentaCorriente");

            // En CC no se usa "Paga con" ni "Cambio"
            txtpagacon.Enabled = !esCC;
            txtcambio.Enabled = !esCC;

            if (esCC)
            {
                txtpagacon.Text = "";
                txtcambio.Text = "";
            }
        }

        // ===================== Cliente (buscar / vincular) =====================
        private void btnbuscarproveedor_Click(object sender, EventArgs e)
        {
            using (var modal = new mdCliente())
            {
                var result = modal.ShowDialog();
                if (result == DialogResult.OK && modal.ClienteSeleccionado != null)
                {
                    _clienteIdCC = modal.ClienteSeleccionado.id;
                    txtnumerodocumentocliente.Text = modal.ClienteSeleccionado.dni ?? "";
                    txtnombrecliente.Text = modal.ClienteSeleccionado.nombre ?? "";
                    txtapellidocliente.Text = modal.ClienteSeleccionado.apellido ?? "";
                    txtcodproducto.Select();
                }
                else
                {
                    _clienteIdCC = 0;
                    txtnumerodocumentocliente.Select();
                }
            }
        }

        private void txtnumerodocumentocliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                TryVincularClientePorDNI();
            }
        }

        private void txtnumerodocumentocliente_Leave(object sender, EventArgs e)
        {
            TryVincularClientePorDNI();
        }

        private bool TryVincularClientePorDNI()
        {
            string dni = (txtnumerodocumentocliente.Text ?? "").Trim();
            if (string.IsNullOrEmpty(dni)) { _clienteIdCC = 0; return false; }

            var cli = new CN_Cliente()
                        .Listar()
                        .FirstOrDefault(c => (c.dni ?? "") == dni);

            if (cli == null) { _clienteIdCC = 0; return false; }

            _clienteIdCC = cli.id;
            txtnombrecliente.Text = cli.nombre ?? "";
            txtapellidocliente.Text = cli.apellido ?? "";
            return true;
        }

        // ===================== Productos / grilla =====================
        private void btnbuscarproducto_Click(object sender, EventArgs e)
        {
            using (var modal = new mdProducto())
            {
                var result = modal.ShowDialog();
                if (result == DialogResult.OK && modal._Producto != null)
                {
                    txtidproducto.Text = modal._Producto.Id.ToString();
                    txtnombreproducto.Text = modal._Producto.nombre ?? "";
                    txtcodproducto.Text = modal._Producto.codigo ?? "";
                    // 👇 Mostrar SIEMPRE con cultura actual (ej: 140,02)
                    txtprecioproducto.Text = modal._Producto.precioventa.ToString("N2", CultureInfo.CurrentCulture);
                    txtstock.Text = CalcularStockVisual(modal._Producto.Id, modal._Producto.stock).ToString();
                    txtcantidad.Select();
                }
                else
                {
                    txtcodproducto.Select();
                }
            }
        }

        private void txtcodproducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;

            e.SuppressKeyPress = true;
            string codigo = (txtcodproducto.Text ?? "").Trim();
            if (string.IsNullOrEmpty(codigo))
            {
                txtcodproducto.BackColor = Color.MistyRose;
                return;
            }

            var oProducto = new CN_Producto().Listar()
                              .FirstOrDefault(p => p.codigo == codigo && p.estado);

            if (oProducto != null)
            {
                txtcodproducto.BackColor = Color.Honeydew;
                txtidproducto.Text = oProducto.Id.ToString();
                txtnombreproducto.Text = oProducto.nombre ?? "";
                txtprecioproducto.Text = oProducto.precioventa.ToString("N2", CultureInfo.CurrentCulture);
                txtstock.Text = CalcularStockVisual(oProducto.Id, oProducto.stock).ToString();
                txtcantidad.Select();
            }
            else
            {
                txtcodproducto.BackColor = Color.MistyRose;
                txtidproducto.Text = "0";
                txtnombreproducto.Text = "";
                txtstock.Text = "";
                txtcantidad.Value = 1;
            }
        }

        private void btnagregarproducto_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtidproducto.Text, out int idProd) || idProd == 0)
            {
                MessageBox.Show("Debe seleccionar un producto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // ✅ Parsear con cultura actual (coincide con el formato del TextBox)
            if (!decimal.TryParse(txtprecioproducto.Text,
                                  NumberStyles.Number,
                                  CultureInfo.CurrentCulture,
                                  out decimal precio) || precio <= 0)
            {
                MessageBox.Show("Precio inválido", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            int stockVisual = 0;
            int.TryParse(txtstock.Text, out stockVisual);

            int cantidad = (int)txtcantidad.Value;
            if (cantidad <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor a 0", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (cantidad > stockVisual)
            {
                MessageBox.Show("La cantidad no puede ser mayor al stock disponible", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            bool existe = dgvdata.Rows.Cast<DataGridViewRow>()
                .Where(r => !r.IsNewRow)
                .Any(r => r.Cells["idproducto"].Value?.ToString() == txtidproducto.Text);

            if (existe)
            {
                MessageBox.Show("El producto ya está en el detalle", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            decimal subtotal = cantidad * precio;

            dgvdata.Rows.Add(new object[]
            {
        txtidproducto.Text,     // idproducto
        "Eliminar",             // btneliminar
        txtnombreproducto.Text, // Producto
        precio,                 // Precio (la grilla lo formatea con "N2")
        cantidad,               // Cantidad
        subtotal                // SubTotal
            });

            calcularTotal();
            txtstock.Text = Math.Max(0, stockVisual - cantidad).ToString();
            limpiarProductoBasico();
            txtcodproducto.Select();
        }

        private void dgvdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvdata.Columns[e.ColumnIndex].Name != "btneliminar") return;

            int index = e.RowIndex;
            if (index >= 0 && !dgvdata.Rows[index].IsNewRow)
            {
                // devolver stock visual (opcional)
                if (int.TryParse(Convert.ToString(dgvdata.Rows[index].Cells["idproducto"].Value), out int prodId))
                {
                    var p = _productos.FirstOrDefault(x => x.Id == prodId);
                    if (p != null && int.TryParse(txtstock.Text, out int stk))
                    {
                        int cant = 0;
                        int.TryParse(Convert.ToString(dgvdata.Rows[index].Cells["Cantidad"].Value), out cant);
                        txtstock.Text = (stk + cant).ToString();
                    }
                }

                dgvdata.Rows.RemoveAt(index);
                calcularTotal();
            }
        }

        private void calcularTotal()
        {
            decimal total = 0m;
            foreach (DataGridViewRow fila in dgvdata.Rows)
            {
                if (fila.IsNewRow) continue;
                var v = fila.Cells["SubTotal"].Value;

                if (v is decimal d) total += d;
                else if (v is double db) total += (decimal)db;
                else if (v is float f) total += (decimal)f;
                else if (v is int i) total += i;
                else if (v is string s &&
                         (decimal.TryParse(s, NumberStyles.Number, CultureInfo.CurrentCulture, out var sub) ||
                          decimal.TryParse(s.Replace(".", "").Replace(',', '.'), NumberStyles.Number, CultureInfo.InvariantCulture, out sub)))
                    total += sub;
            }
            txttotalpagar.Text = total.ToString("N2", CultureInfo.CurrentCulture);
        }

        private void limpiarProductoBasico()
        {
            txtidproducto.Text = "0";
            txtcodproducto.Text = "";
            txtnombreproducto.Text = "";
            txtcantidad.Value = 1;
            lbproductobusqueda.Visible = false;   // ocultar lista de sugerencias
        }

        private bool TryParseDecimalFlexible(string input, out decimal value)
        {
            return decimal.TryParse(input, NumberStyles.Any, CultureInfo.CurrentCulture, out value)
                || decimal.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out value);
        }

        private void txtpagacon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar)) return;
            if (char.IsDigit(e.KeyChar)) return;
            if ((e.KeyChar == '.' || e.KeyChar == ',') && !txtpagacon.Text.Any(ch => ch == '.' || ch == ','))
                return;
            e.Handled = true;
        }

        private void calcularcambio()
        {
            if (!TryParseDecimalFlexible(txttotalpagar.Text, out var total)) { txtcambio.Text = "0,00"; return; }
            if (!TryParseDecimalFlexible(txtpagacon.Text, out var pagaCon)) { txtcambio.Text = "0,00"; return; }
            txtcambio.Text = (pagaCon >= total ? pagaCon - total : 0m).ToString("N2", CultureInfo.CurrentCulture);
        }

        private void txtpagacon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; calcularcambio(); }
        }

        // ====== Mapeo UI -> ENUM BD ======
        private string MapMedioPagoBD(string medioUI)
        {
            switch (medioUI)
            {
                case "Efectivo": return "Efectivo";
                case "Tarjeta": return "Credito";       // o "Debito" si lo distinguís
                case "Billetera Virtual": return "Transferencia";
                case "CuentaCorriente": return "CuentaCorriente";
                default: return "Efectivo";
            }
        }

        // ===================== Registrar Venta =====================
        private void btnregistrarventa_Click(object sender, EventArgs e)
        {
            if ((_Usuario?.idusuario ?? 0) <= 0)
            {
                MessageBox.Show("No hay sesión de usuario válida.", "Venta",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (dgvdata.Rows.Cast<DataGridViewRow>().All(r => r.IsNewRow))
            {
                MessageBox.Show("Debe ingresar producto a la venta", "Mensaje",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string medioUI = (cboMedioPago.SelectedItem as OpcionCombo)?.Valor?.ToString() ?? "Efectivo";
            string medioBD = MapMedioPagoBD(medioUI);

            if (!TryParseDecimalFlexible(txttotalpagar.Text, out var totalPagar) || totalPagar <= 0)
            {
                MessageBox.Show("Total a pagar inválido", "Mensaje",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (medioUI == "CuentaCorriente")
            {
                if (_clienteIdCC <= 0) TryVincularClientePorDNI();
                if (_clienteIdCC <= 0)
                {
                    MessageBox.Show("Seleccione un cliente para cuenta corriente o ingrese un DNI existente.",
                        "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            else
            {
                if (!TryParseDecimalFlexible(txtpagacon.Text, out var pagaCon))
                {
                    MessageBox.Show("Ingrese el monto con el que paga el cliente", "Mensaje",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (pagaCon < totalPagar)
                {
                    MessageBox.Show("El monto de pago es insuficiente", "Mensaje",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                calcularcambio();
            }

            // Armar detalle
            var detalle = new DataTable();
            detalle.Columns.Add("producto_id", typeof(int));
            detalle.Columns.Add("cantidad", typeof(int));
            detalle.Columns.Add("precio_unitario", typeof(decimal));

            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                if (row.IsNewRow) continue;

                var vId = row.Cells["idproducto"].Value;
                var vCant = row.Cells["Cantidad"].Value;
                var vPrecio = row.Cells["Precio"].Value;
                if (vId == null || vCant == null || vPrecio == null) continue;

                detalle.Rows.Add(
                    Convert.ToInt32(vId),
                    Convert.ToInt32(vCant),
                    Convert.ToDecimal(vPrecio, CultureInfo.InvariantCulture)
                );
            }

            if (detalle.Rows.Count == 0)
            {
                MessageBox.Show("No hay ítems válidos para registrar.", "Mensaje",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string nombreSnap = $"{(txtnombrecliente.Text ?? "").Trim()} {(txtapellidocliente.Text ?? "").Trim()}".Trim();

            var venta = new Venta
            {
                EmpleadoId = _Usuario.idusuario,
                ClienteId = _clienteIdCC > 0 ? _clienteIdCC : 0,
                TipoDocumento = (cbotipodocumento.SelectedItem as OpcionCombo)?.Valor?.ToString() ?? "Boleta",
                NumeroDocumento = new CN_Venta().GenerarNumeroDocumento("0001"),
                MontoPago = (medioUI == "CuentaCorriente") ? 0
                                  : (decimal.TryParse(txtpagacon.Text, out var pg) ? pg : 0),
                NombreCliente = string.IsNullOrEmpty(nombreSnap) ? "Consumidor Final" : nombreSnap
            };

            string msgVenta;
            bool ok = new CN_Venta().Registrar(venta, detalle, medioBD, out msgVenta);
            if (!ok)
            {
                MessageBox.Show("No se pudo registrar la venta: " + (msgVenta ?? ""),
                    "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var ventaGuardada = new CN_Venta().ObtenerVenta(venta.NumeroDocumento);
            int ventaId = ventaGuardada?.VentaId ?? 0;

            if (ventaId > 0)
            {
                new CN_Venta().RegistrarMedioPago(ventaId, medioBD, totalPagar, out _);

                if (medioUI == "CuentaCorriente")
                {
                    var cnCC = new CN_CuentaCorriente();
                    if (!cnCC.RegistrarVentaFiada(_clienteIdCC, ventaId, totalPagar, _Usuario.idusuario, out string msgCC))
                    {
                        MessageBox.Show("Venta OK, pero no se impactó en Cuenta Corriente: " + msgCC,
                            "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("Venta registrada en cuenta corriente.",
                            "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Venta registrada correctamente.",
                        "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Venta registrada, pero no se pudo recuperar el ID para registrar medio de pago.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // Limpieza UI
            dgvdata.Rows.Clear();
            txttotalpagar.Text = "0,00";
            txtpagacon.Text = "";
            txtcambio.Text = "0,00";
            txtnumerodocumentocliente.Text = "";
            txtnombrecliente.Text = "";
            txtapellidocliente.Text = "";
            _clienteIdCC = 0;
            cboMedioPago.SelectedIndex = 0;
            ActualizarUIParaMedioPago();
            limpiarProductoBasico();
        }

        // ===================== Helpers de stock visual =====================
        private int CantidadEnCarrito(int idProd)
        {
            int total = 0;
            foreach (DataGridViewRow r in dgvdata.Rows)
            {
                if (r.IsNewRow) continue;
                if (int.TryParse(Convert.ToString(r.Cells["idproducto"].Value), out int id) && id == idProd)
                {
                    if (int.TryParse(Convert.ToString(r.Cells["Cantidad"].Value), out int c))
                        total += c;
                }
            }
            return total;
        }

        private int CalcularStockVisual(int idProd, int stockBD)
        {
            int enCarrito = CantidadEnCarrito(idProd);
            return Math.Max(0, stockBD - enCarrito);
        }

        /* ==============================
           AUTOCOMPLETE — Nombre producto
           ============================== */

        // Normalizar tildes
        private static string NormalizeText(string s)
        {
            if (string.IsNullOrEmpty(s)) return string.Empty;
            var normalized = s.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();
            foreach (char ch in normalized)
            {
                var cat = CharUnicodeInfo.GetUnicodeCategory(ch);
                if (cat != System.Globalization.UnicodeCategory.NonSpacingMark) sb.Append(ch);
            }
            return sb.ToString().Normalize(NormalizationForm.FormC);
        }
        private static bool ContainsLike(string haystack, string needle)
        {
            return NormalizeText(haystack).ToUpperInvariant()
                   .Contains(NormalizeText(needle).ToUpperInvariant());
        }

        private void txtnombreproducto_TextChanged(object sender, EventArgs e)
        {
            string q = (txtnombreproducto.Text ?? "").Trim();

            // Reposicionar la lista para que quede pegada al textbox
            lbproductobusqueda.Left = txtnombreproducto.Left;
            lbproductobusqueda.Top = txtnombreproducto.Bottom + 2;
            lbproductobusqueda.Width = txtnombreproducto.Width;

            if (string.IsNullOrEmpty(q))
            {
                lbproductobusqueda.Visible = false;
                return;
            }

            // Buscar por nombre o código
            var sugs = _productos
                .Where(p => p.estado && (ContainsLike(p.nombre ?? "", q) || ContainsLike(p.codigo ?? "", q)))
                .Take(8)
                .Select(p => new ItemProd(p.Id, $"{p.nombre} — {p.codigo}"))
                .ToList();

            if (sugs.Count == 0)
            {
                lbproductobusqueda.Visible = false;
                return;
            }

            lbproductobusqueda.BeginUpdate();
            lbproductobusqueda.Items.Clear();
            foreach (var it in sugs) lbproductobusqueda.Items.Add(it);
            lbproductobusqueda.EndUpdate();
            lbproductobusqueda.Visible = true;
        }

        private void txtnombreproducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (!lbproductobusqueda.Visible) return;

            if (e.KeyCode == Keys.Down)
            {
                if (lbproductobusqueda.Items.Count > 0)
                {
                    lbproductobusqueda.SelectedIndex = 0;
                    lbproductobusqueda.Focus();
                }
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                lbproductobusqueda.Visible = false;
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (lbproductobusqueda.Items.Count > 0)
                {
                    lbproductobusqueda.SelectedIndex = 0;
                    ConfirmarSeleccionProductoDesdeLista();
                }
                e.Handled = true;
            }
        }

        private void lbproductobusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ConfirmarSeleccionProductoDesdeLista();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                lbproductobusqueda.Visible = false;
                txtnombreproducto.Focus();
                e.Handled = true;
            }
        }

        private void lbproductobusqueda_Click(object sender, EventArgs e)
        {
            ConfirmarSeleccionProductoDesdeLista();
        }

        private void ConfirmarSeleccionProductoDesdeLista()
        {
            if (lbproductobusqueda.SelectedItem is ItemProd it)
            {
                SetProductoById(it.Id);
                lbproductobusqueda.Visible = false;
                txtcantidad.Select();  // listo para cargar cantidad
            }
        }

        private void SetProductoById(int id)
        {
            var p = _productos.FirstOrDefault(x => x.Id == id);
            if (p == null) return;

            txtidproducto.Text = p.Id.ToString();
            txtnombreproducto.Text = p.nombre ?? "";
            txtcodproducto.Text = p.codigo ?? "";
            txtprecioproducto.Text = p.precioventa.ToString("N2", CultureInfo.CurrentCulture);
            txtstock.Text = CalcularStockVisual(p.Id, p.stock).ToString();

            txtcantidad.Value = 1;  // listo para agregar
        }
        private void txtnombreproducto_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
