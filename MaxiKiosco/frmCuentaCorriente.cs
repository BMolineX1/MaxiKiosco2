using CapaDatos;
using CapaEntidad;
using CapaNegocio;
using MaxiKiosco.Modales;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MaxiKiosco
{
    public partial class frmCuentaCorriente : Form
    {
        private int _clienteSeleccionadoId = 0;
        private readonly CN_CuentaCorriente _cn = new CN_CuentaCorriente();

        // Cache para el autocomplete (clientes “maestro”)
        private List<Cliente> _clientes = new List<Cliente>();

        // Cache para el grid izquierdo (cuentas) + vista filtrable
        private DataTable _dtCuentas;
        private DataView _dvCuentas;

        public frmCuentaCorriente()
        {
            InitializeComponent();

            // Eventos (por si no están seteados en el diseñador)
            this.Load += frmCuentaCorriente_Load;
            btnFiltrar.Click += btnFiltrar_Click;


            dgvClientes.SelectionChanged += dgvClientes_SelectionChanged;

            txtBuscarCliente.TextChanged += txtBuscarCliente_TextChanged;
            txtBuscarCliente.KeyDown += txtBuscarCliente_KeyDown;
            lstSugerencias.KeyDown += lstSugerencias_KeyDown;
            lstSugerencias.Click += lstSugerencias_Click;

            dgvMovimientos.DataBindingComplete += dgvMovimientos_DataBindingComplete;
            dgvMovimientos.CellContentClick += dgvMovimientos_CellContentClick; // ⬅ NUEVO
        }

        private void btnPagarProducto_Click(object sender, EventArgs e)
        {
            if (_clienteSeleccionadoId <= 0)
            {
                MessageBox.Show("Seleccioná un cliente con cuenta corriente primero.",
                    "Cuenta Corriente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idCliente = _clienteSeleccionadoId;
            int idUsuario = Usuario.UsuarioId(); // lo mismo que usás en RegistrarPago

            using (var form = new mdPagarProductosCC(idCliente, idUsuario))
            {
                var result = form.ShowDialog();

                if (result == DialogResult.OK)
                {
                    CargarEstado();
                    CargarMovimientos();
                    CargarGridCuentas();
                }
            }
        }
        private void dgvMovimientos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var col = dgvMovimientos.Columns[e.ColumnIndex];

            // Ajustá "btnPagarProducto" al NOMBRE REAL de la columna botón
            if (col is DataGridViewButtonColumn && col.Name == "btnPagarProducto")
            {
                AbrirModalPagarProductos();
            }
        }

        private void AbrirModalPagarProductos()
        {
            if (_clienteSeleccionadoId <= 0)
            {
                MessageBox.Show("Seleccioná un cliente con cuenta corriente primero.",
                    "Cuenta Corriente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int idCliente = _clienteSeleccionadoId;
                int idUsuario = Usuario.UsuarioId(); // el mismo helper que usás en btnRegistrarPago

                using (var form = new mdPagarProductosCC(idCliente, idUsuario))
                {
                    var result = form.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        CargarEstado();
                        CargarMovimientos();
                        CargarGridCuentas();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir el pago por productos: " + ex.Message,
                    "Cuenta Corriente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public DataTable ListarPendientesConPrecio(int clienteId)
        {
            var dt = new DataTable();
            const string sql = @"
        SELECT 
            d.producto_id,
            p.codigo,
            p.nombre,
            d.cantidad_pend,
            p.precioventa AS precio_vigente
        FROM cc_detalle d
        JOIN producto p ON p.id = d.producto_id
        WHERE d.cliente_id = @cli AND d.cantidad_pend > 0
        ORDER BY p.nombre";
            using (var cn = new MySqlConnection(Conexion.cadena))
            using (var da = new MySqlDataAdapter(sql, cn))
            {
                da.SelectCommand.Parameters.AddWithValue("@cli", clienteId);
                da.Fill(dt);
            }
            return dt;
        }


        private void frmCuentaCorriente_Load(object sender, EventArgs e)
        {
            dtpDesde.Value = DateTime.Today.AddMonths(-1);
            dtpHasta.Value = DateTime.Today;

            // Autocomplete base
            _clientes = new CN_Cliente().Listar();

            lstSugerencias.Left = txtBuscarCliente.Left;
            lstSugerencias.Top = txtBuscarCliente.Bottom + 2;
            lstSugerencias.Width = txtBuscarCliente.Width;
            lstSugerencias.Visible = false;

            // Grid izquierdo: cargar y dejar lista la vista filtrable
            CargarGridCuentas();

            if (_clienteSeleccionadoId > 0)
            {
                CargarEstado();
                CargarMovimientos();
            }
        }

        /* ======================================================
           GRID IZQUIERDO (cuentas) — usa columnas del diseñador
           ====================================================== */
        private void CargarGridCuentas()
        {
            _dtCuentas = _cn.ListarCuentas();     // columnas: Id, Cliente, Saldo, Limite, Habilitada
            _dvCuentas = new DataView(_dtCuentas);

            dgvClientes.AutoGenerateColumns = false;

            dgvClientes.Columns["colCliId"].DataPropertyName = "Id";
            dgvClientes.Columns["colCliNombre"].DataPropertyName = "Cliente";
            dgvClientes.Columns["colCliSaldo"].DataPropertyName = "Saldo";
            dgvClientes.Columns["colCliLimite"].DataPropertyName = "Limite";
            dgvClientes.Columns["colCliHabilitada"].DataPropertyName = "Habilitada";

            dgvClientes.DataSource = _dvCuentas;

            dgvClientes.Columns["colCliSaldo"].DefaultCellStyle.Format = "N2";
            dgvClientes.Columns["colCliLimite"].DefaultCellStyle.Format = "N2";
        }

        private void AplicarFiltroClientes(string q)
        {
            if (_dvCuentas == null) return;

            if (string.IsNullOrWhiteSpace(q))
            {
                _dvCuentas.RowFilter = string.Empty;
                return;
            }

            // Filtro simple por nombre mostrado en el grid
            // Escapar comillas simples para evitar errores de sintaxis en RowFilter
            var safe = q.Replace("'", "''");
            _dvCuentas.RowFilter = $"Cliente LIKE '%{safe}%'";
        }

        private void dgvClientes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow == null) return;

            var cell = dgvClientes.CurrentRow.Cells["colCliId"];
            if (cell?.Value == null) return;

            _clienteSeleccionadoId = Convert.ToInt32(cell.Value);
            CargarEstado();
            CargarMovimientos();
        }

        /* ==========================
           ESTADO (saldo/limite/hab)
           ========================== */
        private void CargarEstado()
        {
            var est = _cn.ObtenerEstado(_clienteSeleccionadoId);
            if (est == null)
            {
                lblSaldo.Text = "Saldo: 0,00";
                lblLimite.Text = "Límite: 0,00";
                lblHabilitada.Text = "Habilitada: No";
                return;
            }
            lblSaldo.Text = $"Saldo: {est.Saldo:N2}";
            lblLimite.Text = $"Límite: {est.LimiteCredito:N2}";
            lblHabilitada.Text = $"Habilitada: {(est.Habilitada ? "Sí" : "No")}";
        }

        /* ======================================================
           GRID CENTRAL (movimientos) — usa columnas del diseñador
           ====================================================== */
        private sealed class MovimientoUI
        {
            public DateTime FechaHora { get; set; }  // → colMovFecha
            public string Tipo { get; set; }         // "Cargo"/"Pago" → colMovTipo
            public string Concepto { get; set; }     // → colMovConcepto
            public int VentaId { get; set; }         // → colMovVentas
            public decimal Monto { get; set; }       // → colMovMonto
        }

        private void EnsureMappingMovimientos()
        {
            dgvMovimientos.AutoGenerateColumns = false;

            dgvMovimientos.Columns["colMovFecha"].DataPropertyName = nameof(MovimientoUI.FechaHora);
            dgvMovimientos.Columns["colMovTipo"].DataPropertyName = nameof(MovimientoUI.Tipo);
            dgvMovimientos.Columns["colMovConcepto"].DataPropertyName = nameof(MovimientoUI.Concepto);
         
            dgvMovimientos.Columns["colMovMonto"].DataPropertyName = nameof(MovimientoUI.Monto);

            dgvMovimientos.Columns["colMovFecha"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            dgvMovimientos.Columns["colMovMonto"].DefaultCellStyle.Format = "N2";
        }

        private void CargarMovimientos()
        {
            var desde = dtpDesde.Value.Date;
            var hasta = dtpHasta.Value.Date;

            var movsRaw = _cn.ListarMovimientos(_clienteSeleccionadoId, desde, hasta);

            var data = movsRaw.Select(m => new MovimientoUI
            {
                FechaHora = m.FechaHora,
                Tipo = (m.Tipo == "DEBITO") ? "Cargo" : "Pago",
                Concepto = m.Concepto,
                VentaId = m.VentaId ?? 0,
                Monto = m.Monto
            })
            .OrderByDescending(x => x.FechaHora)
            .ToList();

            EnsureMappingMovimientos();

            dgvMovimientos.DataSource = null;
            dgvMovimientos.DataSource = data;
        }

        private void dgvMovimientos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvMovimientos.Rows)
            {
                var tipo = Convert.ToString(row.Cells["colMovTipo"].Value);
                row.DefaultCellStyle.ForeColor = (tipo == "Pago") ? Color.DarkGreen : Color.DarkRed;
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e) => CargarMovimientos();

        /* ======================
           REGISTRAR PAGO (tope)
           ====================== */
        

        /* =========================
           AUTOCOMPLETE + FILTRO GRID
           ========================= */

        // Quita tildes y normaliza
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

        private void txtBuscarCliente_TextChanged(object sender, EventArgs e)
        {
            string q = txtBuscarCliente.Text.Trim();

            // (1) Filtra el grid izquierdo en vivo
            AplicarFiltroClientes(q);

            // (2) Autocomplete (opcional si querés ambas cosas)
            if (q.Length == 0)
            {
                lstSugerencias.Visible = false;
                return;
            }

            var sugs = _clientes
                .Where(c =>
                    ContainsLike($"{c.nombre} {c.apellido}", q) ||
                    ContainsLike(c.dni ?? "", q)
                )
                .Take(8)
                .Select(c => new
                {
                    Id = c.id,
                    Texto = (($"{c.nombre} {c.apellido}").Trim().Length > 0)
                            ? $"{c.nombre} {c.apellido} — {c.dni}"
                            : $"{c.dni}"
                })
                .ToList();

            if (sugs.Count == 0)
            {
                lstSugerencias.Visible = false;
                return;
            }

            lstSugerencias.BeginUpdate();
            lstSugerencias.Items.Clear();
            foreach (var s in sugs) lstSugerencias.Items.Add(new ItemSug(s.Id, s.Texto));
            lstSugerencias.EndUpdate();
            lstSugerencias.Visible = true;

            lstSugerencias.Left = txtBuscarCliente.Left;
            lstSugerencias.Top = txtBuscarCliente.Bottom + 2;
            lstSugerencias.Width = txtBuscarCliente.Width;
        }

        private void txtBuscarCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (!lstSugerencias.Visible) return;

            if (e.KeyCode == Keys.Down)
            {
                if (lstSugerencias.Items.Count > 0)
                {
                    lstSugerencias.SelectedIndex = 0;
                    lstSugerencias.Focus();
                }
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                lstSugerencias.Visible = false;
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Enter)
            {
                ConfirmarSeleccionDesdeTexto();
                e.Handled = true;
            }
        }

        private void lstSugerencias_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ConfirmarSeleccionDesdeLista();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                lstSugerencias.Visible = false;
                txtBuscarCliente.Focus();
                e.Handled = true;
            }
        }

        private void lstSugerencias_Click(object sender, EventArgs e)
        {
            ConfirmarSeleccionDesdeLista();
        }

        private void ConfirmarSeleccionDesdeLista()
        {
            if (lstSugerencias.SelectedItem is ItemSug sug)
            {
                _clienteSeleccionadoId = sug.Id;
                txtBuscarCliente.Text = sug.Texto;
                lstSugerencias.Visible = false;
                txtBuscarCliente.SelectionStart = txtBuscarCliente.Text.Length;

                // Selecciona en el grid izquierdo si está visible en el filtro
                SeleccionarClienteEnGrid(_clienteSeleccionadoId);

                CargarEstado();
                CargarMovimientos();
            }
        }

        private void ConfirmarSeleccionDesdeTexto()
        {
            if (lstSugerencias.Visible && lstSugerencias.Items.Count > 0)
            {
                lstSugerencias.SelectedIndex = 0;
                ConfirmarSeleccionDesdeLista();
            }
        }

        private void SeleccionarClienteEnGrid(int id)
        {
            if (dgvClientes == null) return;

            foreach (DataGridViewRow row in dgvClientes.Rows)
            {
                var cellId = row.Cells["colCliId"]?.Value;
                if (cellId == null) continue;

                if (Convert.ToInt32(cellId) == id)
                {
                    row.Selected = true;

                    // CurrentCell en la PRIMERA columna visible para evitar excepciones
                    DataGridViewCell visibleCell = null;
                    foreach (DataGridViewColumn col in dgvClientes.Columns)
                    {
                        if (col.Visible)
                        {
                            visibleCell = row.Cells[col.Index];
                            break;
                        }
                    }
                    if (visibleCell != null)
                        dgvClientes.CurrentCell = visibleCell;

                    if (row.Index >= 0)
                        dgvClientes.FirstDisplayedScrollingRowIndex = row.Index;
                    break;
                }
            }
        }

        // Item para la lista del autocomplete
        private sealed class ItemSug
        {
            public int Id { get; }
            public string Texto { get; }
            public ItemSug(int id, string texto) { Id = id; Texto = texto; }
            public override string ToString() => Texto;
        }

        private void txtBuscarCliente_TextChanged_1(object sender, EventArgs e) { }
    }
}
