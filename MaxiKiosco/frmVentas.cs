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
        private int _clienteIdCC = 0;
        private ComboBox cboMedioPago;
        private int _idCajaAbierta = 0;

        // Productos en memoria
        private System.Collections.Generic.List<Producto> _productos = new System.Collections.Generic.List<Producto>();

        // Clientes en sugerencias
        private Cliente _clienteSeleccionado = null;
        private System.Collections.Generic.List<Cliente> _sugClientes = new System.Collections.Generic.List<Cliente>();

        // Condición IVA del emisor
        private string _empresaCondIva = "RI"; // RI | Monotributo | Exento | CF

        private sealed class ItemProd
        {
            public int Id { get; }
            public string Texto { get; }
            public ItemProd(int id, string texto) { Id = id; Texto = texto; }
            public override string ToString() => Texto;
        }

        public frmVentas(Usuario ousuario = null)
        {
            InitializeComponent();
            _Usuario = ousuario;
        }

        private void frmVentas_Load(object sender, EventArgs e)
        {
            _empresaCondIva = ConfigKiosco.EmisorCondIva;

            // ====== Medio de pago (NO muevo el control si ya existe) ======
            if (this.Controls.Find("cboMedioPago", true).FirstOrDefault() is ComboBox found)
            {
                cboMedioPago = found;
            }
            else
            {
                cboMedioPago = new ComboBox
                {
                    Name = "cboMedioPago",
                    DropDownStyle = ComboBoxStyle.DropDownList,
                    Width = 180,
                    Left = 643,
                    Top = 165
                };
                this.Controls.Add(cboMedioPago);
            }
            cboMedioPago.BringToFront();

            // ====== Tipo de documento ======
            cbotipodocumento.Items.Clear();
            cbotipodocumento.Items.Add(new OpcionCombo { Valor = "Consumidor Final", texto = "Consumidor Final" });
            cbotipodocumento.Items.Add(new OpcionCombo { Valor = "Factura A", texto = "Factura A" });
            cbotipodocumento.Items.Add(new OpcionCombo { Valor = "Factura B", texto = "Factura B" });
            cbotipodocumento.Items.Add(new OpcionCombo { Valor = "Factura C", texto = "Factura C" });
            cbotipodocumento.DisplayMember = "texto";
            cbotipodocumento.ValueMember = "Valor";
            cbotipodocumento.SelectedIndex = 0; // B por defecto

            // ====== Medios de pago ======
            cboMedioPago.Items.Clear();
            cboMedioPago.Items.Add(new OpcionCombo { Valor = "Efectivo", texto = "Efectivo" });
            cboMedioPago.Items.Add(new OpcionCombo { Valor = "Tarjeta", texto = "Tarjeta" });
            cboMedioPago.Items.Add(new OpcionCombo { Valor = "Billetera Virtual", texto = "Billetera Virtual" });
            cboMedioPago.Items.Add(new OpcionCombo { Valor = "CuentaCorriente", texto = "Cuenta Corriente" });
            cboMedioPago.DisplayMember = "Texto";
            cboMedioPago.ValueMember = "Valor";
            cboMedioPago.SelectedIndex = 0;

            cboMedioPago.SelectedIndexChanged -= cboMedioPago_SelectedIndexChanged;
            cboMedioPago.SelectedIndexChanged += cboMedioPago_SelectedIndexChanged;
            ActualizarUIParaMedioPago();

            // ====== Campos iniciales ======
            txtfechaventa.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtidproducto.Text = "0";
            txtpagacon.Text = "";
            txtcambio.Text = "";
            txttotalpagar.Text = "0";

            txtprecioproducto.ReadOnly = true;
            txtprecioproducto.TabStop = false;
            txtprecioproducto.BackColor = SystemColors.Info;

            txtstock.ReadOnly = true;
            txtstock.TabStop = false;
            txtstock.BackColor = SystemColors.Info;

            if (txtcondicioniva != null)
            {
                txtcondicioniva.ReadOnly = true;
                txtcondicioniva.TabStop = false;
                txtcondicioniva.BackColor = SystemColors.Info;
            }

            if (dgvdata.Columns.Contains("Precio"))
                dgvdata.Columns["Precio"].DefaultCellStyle.Format = "N2";
            if (dgvdata.Columns.Contains("SubTotal"))
                dgvdata.Columns["SubTotal"].DefaultCellStyle.Format = "N2";

            dgvdata.CellContentClick -= dgvdata_CellContentClick;
            dgvdata.CellContentClick += dgvdata_CellContentClick;

            // Cache productos
            _productos = new CN_Producto().Listar().Where(p => p.estado).ToList();

            // ====== Autocomplete de producto por NOMBRE (ListBox del diseñador) ======
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

            txtnombreproducto.TextChanged -= txtnombreproducto_TextChanged;
            txtnombreproducto.TextChanged += txtnombreproducto_TextChanged;
            txtnombreproducto.KeyDown -= txtnombreproducto_KeyDown;
            txtnombreproducto.KeyDown += txtnombreproducto_KeyDown;

            // Flujo sin botón Agregar
            txtcantidad.KeyDown -= txtcantidad_KeyDown;
            txtcantidad.KeyDown += txtcantidad_KeyDown;

            // Código de producto
            txtcodproducto.TextChanged -= txtcodproducto_TextChanged;
            txtcodproducto.TextChanged += txtcodproducto_TextChanged;
            txtcodproducto.KeyDown -= txtcodproducto_KeyDown;
            txtcodproducto.KeyDown += txtcodproducto_KeyDown;

            // ====== Sugerencias de CLIENTE (tres ListBox del diseñador) ======
            lbnumerodocumento.Visible = false;
            lbnombre.Visible = false;
            lbapellido.Visible = false;

            // Escucha en vivo en los tres campos
            txtnumerodocumentocliente.TextChanged -= txtCliente_TextChangedLive;
            txtnumerodocumentocliente.TextChanged += txtCliente_TextChangedLive;
            txtnombrecliente.TextChanged -= txtCliente_TextChangedLive;
            txtnombrecliente.TextChanged += txtCliente_TextChangedLive;
            txtapellidocliente.TextChanged -= txtCliente_TextChangedLive;
            txtapellidocliente.TextChanged += txtCliente_TextChangedLive;

            // Click/Enter en cualquiera de las 3 listas ⇒ completa TODO y cierra listas
            lbnumerodocumento.Click -= lstCliente_Click; lbnumerodocumento.Click += lstCliente_Click;
            lbnombre.Click -= lstCliente_Click; lbnombre.Click += lstCliente_Click;
            lbapellido.Click -= lstCliente_Click; lbapellido.Click += lstCliente_Click;

            lbnumerodocumento.KeyDown -= lstCliente_KeyDown; lbnumerodocumento.KeyDown += lstCliente_KeyDown;
            lbnombre.KeyDown -= lstCliente_KeyDown; lbnombre.KeyDown += lstCliente_KeyDown;
            lbapellido.KeyDown -= lstCliente_KeyDown; lbapellido.KeyDown += lstCliente_KeyDown;

            // Enter/Leave en DNI (por si querés confirmar con Enter)
            txtnumerodocumentocliente.Leave -= txtnumerodocumentocliente_Leave;
            txtnumerodocumentocliente.Leave += txtnumerodocumentocliente_Leave;
            txtnumerodocumentocliente.KeyDown -= txtnumerodocumentocliente_KeyDown;
            txtnumerodocumentocliente.KeyDown += txtnumerodocumentocliente_KeyDown;

            // Verificar caja
            VerificarEstadoCaja();
        }
        private void ResetClienteUI()
        {
            // Rompo vínculo con el cliente
            _clienteSeleccionado = null;
            _clienteIdCC = 0;

            // Limpio campos de cliente
            txtnumerodocumentocliente.Text = "";
            txtnombrecliente.Text = "";
            txtapellidocliente.Text = "";

            // Limpio condición IVA
            if (txtcondicioniva != null)
                txtcondicioniva.Text = "";

            // Vuelvo el tipo de documento a "Consumidor Final"
            for (int i = 0; i < cbotipodocumento.Items.Count; i++)
            {
                if (cbotipodocumento.Items[i] is OpcionCombo it)
                {
                    if ((it.Valor?.ToString() ?? "") == "Consumidor Final")
                    {
                        cbotipodocumento.SelectedIndex = i;
                        break;
                    }
                }
            }

            // Si querés que el usuario pueda elegir otro tipo, lo habilitás:
            cbotipodocumento.Enabled = false;

            // Vuelvo el título de la ventana
            this.Text = "Ventas";

            // Oculto sugerencias de cliente
            OcultarListasCliente();
        }

        // ====== Helpers de presentación ======
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

        // Lee condición IVA del cliente (según cómo se llame en tu entidad)
        private static string GetCondIvaRaw(Cliente c)
        {
            if (c == null) return "";
            // Cubro variantes: condicion_iva | condicioniva | CondicionIva
            var v1 = c.GetType().GetProperty("condicion_iva")?.GetValue(c) as string;
            var v2 = c.GetType().GetProperty("condicioniva")?.GetValue(c) as string;
            var v3 = c.GetType().GetProperty("CondicionIva")?.GetValue(c) as string;
            return v1 ?? v2 ?? v3 ?? "";
        }

        private static string PrettyCondIva(string raw)
        {
            var x = (raw ?? "").Trim().ToUpperInvariant();
            if (x == "RI" || x.Contains("RESP")) return "Responsable Inscripto";
            if (x.Contains("MONO")) return "Monotributo";
            if (x.Contains("EXEN")) return "Exento";
            if (x == "CF" || x.Contains("CONSUMID")) return "Consumidor Final";
            return string.IsNullOrWhiteSpace(raw) ? "" : raw;
        }

        // ====== Caja ======
        private void VerificarEstadoCaja()
        {
            if (_Usuario == null || _Usuario.idusuario <= 0)
            {
                _idCajaAbierta = 0;
            }
            else
            {
                _idCajaAbierta = new CapaNegocio.CN_Caja().ObtenerIdCajaAbierta(_Usuario.idusuario);
            }

            BloquearControlesVenta(_idCajaAbierta <= 0);
            if (_idCajaAbierta <= 0)
            {
                MessageBox.Show(
                    "⛔ La Caja no ha sido iniciada. No se permite el registro de ventas hasta que se realice la Apertura de Caja.",
                    "Caja Requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BloquearControlesVenta(bool bloquear)
        {
            txtcodproducto.Enabled = !bloquear;
            txtcantidad.Enabled = !bloquear;
            btnregistrarventa.Enabled = !bloquear;

            if (cboMedioPago != null)
                cboMedioPago.Enabled = !bloquear;

            txtpagacon.Enabled = !bloquear;
            dgvdata.ReadOnly = bloquear;

            if (bloquear) dgvdata.Rows.Clear();
        }

        // ====== Medios de pago ======
        private void cboMedioPago_SelectedIndexChanged(object sender, EventArgs e) => ActualizarUIParaMedioPago();

        private void ActualizarUIParaMedioPago()
        {
            string medio = (cboMedioPago.SelectedItem as OpcionCombo)?.Valor?.ToString() ?? "Efectivo";
            bool esCC = (medio == "CuentaCorriente");
            txtpagacon.Enabled = !esCC;
            txtcambio.Enabled = !esCC;
            if (esCC) { txtpagacon.Text = ""; txtcambio.Text = ""; }
        }

        // ====== Sugerencias de CLIENTE (tres ListBox) ======
        private void txtCliente_TextChangedLive(object sender, EventArgs e)
        {
            // 🔹 Si los 3 campos quedaron vacíos, reseteo cliente e IVA
            if (string.IsNullOrWhiteSpace(txtnumerodocumentocliente.Text) &&
                string.IsNullOrWhiteSpace(txtnombrecliente.Text) &&
                string.IsNullOrWhiteSpace(txtapellidocliente.Text))
            {
                ResetClienteUI();
                return; // no busco sugerencias
            }

            string q =
                sender == txtnumerodocumentocliente ? (txtnumerodocumentocliente.Text ?? "").Trim() :
                sender == txtapellidocliente ? (txtapellidocliente.Text ?? "").Trim() :
                (txtnombrecliente.Text ?? "").Trim();

            UpdateSugerenciasCliente(q);
        }

        private void UpdateSugerenciasCliente(string texto)
        {
            texto = (texto ?? "").Trim();
            if (texto.Length == 0)
            {
                OcultarListasCliente();
                _sugClientes.Clear();
                return;
            }

            var cn = new CN_Cliente();
            var lista = cn.BuscarClientes(texto) ?? new System.Collections.Generic.List<Cliente>();

            // Si tu BuscarClientes filtra por nombre/apellido, igual lleno las LBs con lo que devuelva
            // (no forzamos formatos ni nada raro)

            if (lista.Count == 0)
            {
                OcultarListasCliente();
                _sugClientes.Clear();
                return;
            }

            _sugClientes = lista;

            lbnumerodocumento.BeginUpdate();
            lbnombre.BeginUpdate();
            lbapellido.BeginUpdate();

            lbnumerodocumento.Items.Clear();
            lbnombre.Items.Clear();
            lbapellido.Items.Clear();

            foreach (var c in lista)
            {
                lbnumerodocumento.Items.Add(c.dni ?? "");
                lbnombre.Items.Add(c.nombre ?? "");
                lbapellido.Items.Add(c.apellido ?? "");
            }

            lbnumerodocumento.EndUpdate();
            lbnombre.EndUpdate();
            lbapellido.EndUpdate();

            lbnumerodocumento.Visible = true;
            lbnombre.Visible = true;
            lbapellido.Visible = true;
        }

        private void OcultarListasCliente()
        {
            lbnumerodocumento.Visible = false;
            lbnombre.Visible = false;
            lbapellido.Visible = false;
        }

        private void lstCliente_Click(object sender, EventArgs e)
        {
            var lb = sender as ListBox;
            int idx = lb?.SelectedIndex ?? -1;
            if (idx >= 0) SeleccionarClientePorIndice(idx);
        }

        private void lstCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var lb = sender as ListBox;
                int idx = lb?.SelectedIndex ?? -1;
                if (idx >= 0)
                {
                    SeleccionarClientePorIndice(idx);
                    e.SuppressKeyPress = true;
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                OcultarListasCliente();
                e.SuppressKeyPress = true;
            }
        }

        private void SeleccionarClientePorIndice(int index)
        {
            if (index < 0 || index >= _sugClientes.Count) return;

            var cli = _sugClientes[index];

            // Tomo un id consistente
            int idVal = cli.id != 0 ? cli.id : cli.Id;
            _clienteSeleccionado = cli;
            _clienteIdCC = idVal;

            // Completo campos
            txtnumerodocumentocliente.Text = cli.dni ?? "";
            txtnombrecliente.Text = cli.nombre ?? "";
            txtapellidocliente.Text = cli.apellido ?? "";

            // << ESTA LÍNEA AHORA SÍ FUNCIONA porque BuscarClientes ya trae condicion_iva >>
            if (txtcondicioniva != null) txtcondicioniva.Text = PrettyCondIva(cli.condicion_iva);

            // Tipo de comprobante por IVA
            RecalcularYSetearTipoComprobanteDesdeUI();

            if ((cboMedioPago.SelectedItem as OpcionCombo)?.Valor?.ToString() == "CuentaCorriente")
                this.Text = $"Ventas — CC: {cli.apellido} {cli.nombre}";
            else
                this.Text = "Ventas";

            OcultarListasCliente();
            txtcodproducto.Select();
        }

        // ====== Cliente (modal clásico) ======
        private void btnbuscarproveedor_Click(object sender, EventArgs e)
        {
            using (var modal = new mdCliente())
            {
                var result = modal.ShowDialog();
                if (result == DialogResult.OK && modal.ClienteSeleccionado != null)
                {
                    var sel = modal.ClienteSeleccionado;

                    _clienteIdCC = sel.id;
                    txtnumerodocumentocliente.Text = sel.dni ?? "";
                    txtnombrecliente.Text = sel.nombre ?? "";
                    txtapellidocliente.Text = sel.apellido ?? "";

                    // ✅ CONDICIÓN IVA (llenamos txtcondicioniva)
                    var condRaw = sel.condicion_iva ?? sel.condicion_iva;
                    txtcondicioniva.Text = PrettyCondIva(condRaw);

                    // Tipo de comprobante según IVA emisor/cliente (AFIP)
                    _clienteSeleccionado = sel; // asegurate de setear referencia actual
                    RecalcularYSetearTipoComprobanteDesdeUI();

                    if ((cboMedioPago.SelectedItem as OpcionCombo)?.Valor?.ToString() == "CuentaCorriente")
                    {
                        this.Text = $"Ventas — CC: {sel.apellido} {sel.nombre}";
                    }
                    txtcodproducto.Select();
                }
                else
                {
                    _clienteIdCC = 0;
                    this.Text = "Ventas";
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
            if (string.IsNullOrEmpty(dni)) { _clienteIdCC = 0; this.Text = "Ventas"; return false; }

            // Uso Listar() si BuscarClientes no filtra por DNI
            var cli = new CN_Cliente()
                        .Listar()
                        .FirstOrDefault(c => (c.dni ?? "") == dni);

            if (cli == null) { _clienteIdCC = 0; this.Text = "Ventas"; return false; }

            _clienteIdCC = cli.id;
            txtnombrecliente.Text = cli.nombre ?? "";
            txtapellidocliente.Text = cli.apellido ?? "";
            if (txtcondicioniva != null) txtcondicioniva.Text = PrettyCondIva(GetCondIvaRaw(cli));

            _clienteSeleccionado = cli;
            RecalcularYSetearTipoComprobanteDesdeUI();

            if ((cboMedioPago.SelectedItem as OpcionCombo)?.Valor?.ToString() == "CuentaCorriente")
                this.Text = $"Ventas — CC: {cli.apellido} {cli.nombre}";
            return true;
        }

        // ====== Productos / búsqueda ======
        private void btnbuscarproducto_Click(object sender, EventArgs e)
        {
            using (var modal = new mdProducto())
            {
                var result = modal.ShowDialog();
                if (result == DialogResult.OK && modal._Producto != null)
                {
                    SetProductoFromEntidad(modal._Producto);
                    txtcantidad.Select();
                }
                else
                {
                    txtcodproducto.Select();
                }
            }
        }

        private void txtcodproducto_TextChanged(object sender, EventArgs e)
        {
            string codigo = (txtcodproducto.Text ?? "").Trim();
            if (codigo.Length < 3) return;

            var oProducto = _productos.FirstOrDefault(p => p.codigo == codigo && p.estado);
            if (oProducto != null)
            {
                SetProductoFromEntidad(oProducto);
                txtcantidad.Select();
                txtcantidad.Select(0, txtcantidad.Text.Length);
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

            var oProducto = _productos.FirstOrDefault(p => p.codigo == codigo && p.estado);

            if (oProducto != null)
            {
                txtcodproducto.BackColor = Color.Honeydew;
                SetProductoFromEntidad(oProducto);
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

        private void SetProductoFromEntidad(Producto p)
        {
            txtidproducto.Text = p.Id.ToString();
            txtnombreproducto.Text = p.nombre ?? "";
            txtcodproducto.Text = p.codigo ?? "";
            txtprecioproducto.Text = p.precioventa.ToString("N2", CultureInfo.CurrentCulture);
            txtstock.Text = CalcularStockVisual(p.Id, p.stock).ToString();
            txtcantidad.Value = 1;
        }

        // ====== Sin botón Agregar ======
        private void txtcantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                AgregarOActualizarLinea();
            }
        }

        private void AgregarOActualizarLinea()
        {
            if (_idCajaAbierta <= 0)
            {
                MessageBox.Show("Debe realizar la Apertura de Caja para ingresar productos.", "Alerta",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtidproducto.Text, out int idProd) || idProd == 0)
            {
                MessageBox.Show("Debe seleccionar un producto", "Mensaje",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!decimal.TryParse(txtprecioproducto.Text, NumberStyles.Number, CultureInfo.CurrentCulture, out decimal precio) || precio <= 0)
            {
                MessageBox.Show("Precio inválido", "Mensaje",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            int.TryParse(txtstock.Text, out int stockVisual);
            int cantidad = (int)txtcantidad.Value;
            if (cantidad <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor a 0", "Mensaje",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Buscar fila existente por idproducto
            DataGridViewRow filaExistente = null;
            foreach (DataGridViewRow fila in dgvdata.Rows)
            {
                if (fila.IsNewRow) continue;
                if ((fila.Cells["idproducto"].Value?.ToString() ?? "") == txtidproducto.Text)
                {
                    filaExistente = fila;
                    break;
                }
            }

            if (filaExistente != null)
            {
                int cantActual = 0;
                int.TryParse(filaExistente.Cells["Cantidad"].Value?.ToString() ?? "0", out cantActual);
                int nuevaCant = cantActual + cantidad;
                decimal nuevoSub = nuevaCant * precio;

                filaExistente.Cells["Cantidad"].Value = nuevaCant;
                filaExistente.Cells["Precio"].Value = precio;
                filaExistente.Cells["SubTotal"].Value = nuevoSub;
            }
            else
            {
                decimal subtotal = cantidad * precio;
                dgvdata.Rows.Add(new object[]
                {
                    txtidproducto.Text,     // idproducto
                    "Eliminar",             // btneliminar
                    txtnombreproducto.Text, // Producto
                    precio,                 // Precio
                    cantidad,               // Cantidad
                    subtotal                // SubTotal
                });
            }

            calcularTotal();

            // Stock visual permite negativo
            txtstock.Text = (stockVisual - cantidad).ToString();

            limpiarProductoBasico();
            txtcodproducto.Select();
        }

        private void btnagregarproducto_Click(object sender, EventArgs e) => AgregarOActualizarLinea();

        private void dgvdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvdata.Columns[e.ColumnIndex].Name != "btneliminar") return;

            int index = e.RowIndex;
            if (index >= 0 && !dgvdata.Rows[index].IsNewRow)
            {
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
            txtprecioproducto.Text = "";
            txtstock.Text = "";
            txtcantidad.Value = 1;
            lbproductobusqueda.Visible = false;
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
                case "Tarjeta": return "Credito";       // (o "Debito" si lo distinguís)
                case "Billetera Virtual": return "Transferencia";
                case "CuentaCorriente": return "CuentaCorriente";
                default: return "Efectivo";
            }
        }

        // ====== Registrar Venta ======
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

            // Detalle
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
                string precioLimpio = vPrecio.ToString().Replace(".", "").Replace(",", ".");

                detalle.Rows.Add(
                    Convert.ToInt32(vId),
                    Convert.ToInt32(vCant),
                    Convert.ToDecimal(precioLimpio, CultureInfo.InvariantCulture)
                );
            }

            if (detalle.Rows.Count == 0)
            {
                MessageBox.Show("No hay ítems válidos para registrar.", "Mensaje",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string nombreSnap = $"{(txtnombrecliente.Text ?? "").Trim()} {(txtapellidocliente.Text ?? "").Trim()}".Trim();
            if (string.IsNullOrWhiteSpace(nombreSnap)) nombreSnap = "Consumidor Final";

            decimal montoCambio = 0;
            if (medioUI != "CuentaCorriente")
            {
                decimal.TryParse(txtpagacon.Text, out var pagaCon);
                montoCambio = Math.Max(0, pagaCon - totalPagar);
            }
            var emisor = ParseCondIva(_empresaCondIva);
            var condCliente = ParseCondIva(GetCondIvaRaw(_clienteSeleccionado)); // si es null, ParseCondIva maneja CF
            string tipoComprobante = DeterminarComprobante(emisor, condCliente);
            var venta = new Venta
            {
                EmpleadoId = _Usuario.idusuario,
                ClienteId = _clienteIdCC > 0 ? _clienteIdCC : 0,
                // ya seteado por IVA
                TipoDocumento = tipoComprobante,
                NumeroDocumento = new CN_Venta().GenerarNumeroDocumento("0001"),
                MontoPago = (medioUI == "CuentaCorriente") ? 0
                                  : (decimal.TryParse(txtpagacon.Text, out var pg) ? pg : 0),
                MontoTotal = totalPagar,
                MontoCambio = montoCambio,
                NombreCliente = nombreSnap
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

            // Limpieza
            dgvdata.Rows.Clear();
            txttotalpagar.Text = "0,00";
            txtpagacon.Text = "";
            txtcambio.Text = "0,00";
            _clienteIdCC = 0;
            txtnumerodocumentocliente.Text = "";
            txtnombrecliente.Text = "";
            txtapellidocliente.Text = "";
            if (txtcondicioniva != null) txtcondicioniva.Text = "";
            cboMedioPago.SelectedIndex = 0;
            ActualizarUIParaMedioPago();
            limpiarProductoBasico();
            this.Text = "Ventas";
        }

        // ====== Stock visual ======
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
            return stockBD - enCarrito;
        }

        // ====== Autocomplete producto ======
        private void txtnombreproducto_TextChanged(object sender, EventArgs e)
        {
            string q = (txtnombreproducto.Text ?? "").Trim();

            lbproductobusqueda.Left = txtnombreproducto.Left;
            lbproductobusqueda.Top = txtnombreproducto.Bottom + 2;
            lbproductobusqueda.Width = txtnombreproducto.Width;

            if (string.IsNullOrEmpty(q))
            {
                lbproductobusqueda.Visible = false;
                return;
            }

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
                var p = _productos.FirstOrDefault(x => x.Id == it.Id);
                if (p != null)
                {
                    int cantidadActual = (int)txtcantidad.Value;
                    // 1) Cargar datos del producto en los txt (id, nombre, precio, stock, cantidad = 1)
                    SetProductoFromEntidad(p);

                    txtcantidad.Value = cantidadActual;

                    // 2) Agregar directamente al dgvdata usando la lógica que ya tenés
                    AgregarOActualizarLinea();
                }
                lbproductobusqueda.Visible = false;
                txtcodproducto.Select();
            }
        }

        private void txtpagacon_TextChanged(object sender, EventArgs e) => calcularcambio();

        // ====== IVA ======
        private enum CondIva { RI, Monotributo, Exento, ConsumidorFinal }

        private static CondIva ParseCondIva(string s)
        {
            s = (s ?? "").Trim().ToUpperInvariant();
            if (s.Contains("RESP") || s == "RI") return CondIva.RI;
            if (s.Contains("MONO")) return CondIva.Monotributo;
            if (s.Contains("EXEN")) return CondIva.Exento;
            if (s.Contains("CONSUMID") || s == "CF") return CondIva.ConsumidorFinal;
            return CondIva.ConsumidorFinal; // default
        }

        private string DeterminarComprobante(CondIva emisor, CondIva cliente)
        {
            if (emisor == CondIva.RI)
                return (cliente == CondIva.RI) ? "Factura A" : "Factura B";
            return "Factura C"; // Emisor Monotributo o Exento
        }

        private void SetComprobanteUI(string tipo)
        {
            string[] tipos = new[] { "Factura A", "Factura B", "Factura C" };
            foreach (var t in tipos)
            {
                bool existe = false;
                for (int i = 0; i < cbotipodocumento.Items.Count; i++)
                {
                    if (((OpcionCombo)cbotipodocumento.Items[i]).Valor?.ToString() == t)
                    { existe = true; break; }
                }
                if (!existe)
                    cbotipodocumento.Items.Add(new OpcionCombo { Valor = t, texto = t });
            }

            for (int i = 0; i < cbotipodocumento.Items.Count; i++)
            {
                var it = (OpcionCombo)cbotipodocumento.Items[i];
                if ((it.Valor?.ToString() ?? "") == tipo)
                { cbotipodocumento.SelectedIndex = i; break; }
            }
        }
        private void RecalcularYSetearTipoComprobanteDesdeUI()
        {
            // IVA del emisor (config)
            var emisor = ParseCondIva(_empresaCondIva);

            // IVA del cliente: si no hay cliente o campo vacío → Consumidor Final
            string rawCli = "";
            if (_clienteSeleccionado != null)
                rawCli = GetCondIvaRaw(_clienteSeleccionado);
            else if (txtcondicioniva != null)
                rawCli = txtcondicioniva.Text;

            var condCliente = ParseCondIva(string.IsNullOrWhiteSpace(rawCli) ? "CF" : rawCli);

            // Determinar "Factura A/B/C" y reflejar en el combo (bloqueado)
            string tipo = DeterminarComprobante(emisor, condCliente);
            SetComprobanteUI(tipo);
            cbotipodocumento.Enabled = false;
        }

        private void txtnombreproducto_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
