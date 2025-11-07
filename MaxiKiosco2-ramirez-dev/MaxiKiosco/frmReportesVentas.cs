using CapaEntidad;
using CapaNegocio;
using MaxiKiosco.Utilidades;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MaxiKiosco
{
    public partial class frmReportesVentas : Form
    {
        // Buffer con el último resultado de ventas (para filtrar y sugerir en memoria)
        private List<ReporteVenta> _bufferVentas = new List<ReporteVenta>();

        // ====== Item sugerencia ======
        private sealed class ItemSug
        {
            public string ValorBusqueda { get; }
            public string Texto { get; }
            public ItemSug(string valorBusqueda, string texto) { ValorBusqueda = valorBusqueda; Texto = texto; }
            public override string ToString() => Texto;
        }

        public frmReportesVentas()
        {
            InitializeComponent();
        }

        private void frmReportesVentas_Load(object sender, EventArgs e)
        {
            // Completar combo de búsqueda con las columnas visibles del DGV
            cbobusqueda.Items.Clear();
            foreach (DataGridViewColumn columna in dgvdata.Columns)
            {
                if (columna.Visible && columna.Name != "btnseleccionar")
                {
                    cbobusqueda.Items.Add(new OpcionCombo()
                    {
                        Valor = columna.Name,        // usamos el Name para filtrar 1:1
                        texto = columna.HeaderText
                    });
                }
            }
            cbobusqueda.DisplayMember = "Texto";
            cbobusqueda.ValueMember = "Valor";
            if (cbobusqueda.Items.Count > 0) cbobusqueda.SelectedIndex = 0;

            // ---- Autocomplete wiring
            txtbusqueda.TextChanged += txtbusqueda_TextChanged;
            txtbusqueda.KeyDown += txtbusqueda_KeyDown;

            lbbusquedareporteventa.Visible = false;
            lbbusquedareporteventa.DisplayMember = "Texto";
            lbbusquedareporteventa.Click += lbbusquedareporteventa_Click;
            lbbusquedareporteventa.KeyDown += lbbusquedareporteventa_KeyDown;
        }

        /* =========================
           Acciones principales
           ========================= */

        private void btnbuscarreporte_Click(object sender, EventArgs e)
        {
            string fIni = txtfechainicio.Value.ToString("yyyy-MM-dd");
            string fFin = txtfechafin.Value.ToString("yyyy-MM-dd");

            var lista = new CN_Reporte().Venta(fIni, fFin) ?? new List<ReporteVenta>();

            _bufferVentas = lista;          // guardo para filtrar en memoria
            RenderVentas(_bufferVentas);    // pinto la grilla

            // Reiniciar sugerencias
            lbbusquedareporteventa.Visible = false;
        }

        private void btnbuscarreporteporcategoria_Click(object sender, EventArgs e)
        {
            string query = (txtbusqueda.Text ?? "").Trim().ToUpperInvariant();
            IEnumerable<ReporteVenta> source = _bufferVentas ?? Enumerable.Empty<ReporteVenta>();

            if (!string.IsNullOrEmpty(query))
                source = source.Where(rv => (rv.Categoria ?? "").ToUpperInvariant().Contains(query));

            RenderVentas(source);
        }

        private void btnlimpiarbuscador_Click(object sender, EventArgs e)
        {
            txtbusqueda.Text = "";
            lbbusquedareporteventa.Visible = false;
            RenderVentas(_bufferVentas);
        }

        private void iconButton1_Click(object sender, EventArgs e) => ApplyVentaFilter();
        private void iconButton2_Click(object sender, EventArgs e) => ApplyVentaFilter();
        // Si querés tiempo real: descomentá
        // private void txtbusqueda_TextChanged(object sender, EventArgs e) => ApplyVentaFilter();

        /* =========================
           Filtro general por combo
           ========================= */

        private void ApplyVentaFilter()
        {
            string query = (txtbusqueda.Text ?? "").Trim().ToUpperInvariant();
            string columna = (cbobusqueda.SelectedItem as OpcionCombo)?.Valor?.ToString() ?? "";

            IEnumerable<ReporteVenta> source = _bufferVentas ?? Enumerable.Empty<ReporteVenta>();

            if (!string.IsNullOrEmpty(query))
                source = source.Where(rv => VentaMatches(rv, columna, query));

            RenderVentas(source);
        }

        private bool VentaMatches(ReporteVenta rv, string columna, string queryUpper)
        {
            bool NumMatches(decimal n)
            {
                string n1 = n.ToString("#,0.##", CultureInfo.GetCultureInfo("es-AR")).ToUpperInvariant();
                string n2 = n.ToString(CultureInfo.InvariantCulture).ToUpperInvariant();
                return n1.Contains(queryUpper) || n2.Contains(queryUpper);
            }

            switch ((columna ?? "").ToLowerInvariant())
            {
                case "fecharegistro":
                    string f1 = rv.FechaRegistro.ToString("dd/MM/yyyy HH:mm:ss").ToUpperInvariant();
                    string f2 = rv.FechaRegistro.ToString("yyyy-MM-dd HH:mm:ss").ToUpperInvariant();
                    string f3 = rv.FechaRegistro.ToString("dd/MM/yyyy").ToUpperInvariant();
                    string f4 = rv.FechaRegistro.ToString("yyyy-MM-dd").ToUpperInvariant();
                    return f1.Contains(queryUpper) || f2.Contains(queryUpper) || f3.Contains(queryUpper) || f4.Contains(queryUpper);

                case "tipodocumento": return (rv.TipoDocumento ?? "").ToUpperInvariant().Contains(queryUpper);
                case "numerodocumento": return (rv.NumeroDocumento ?? "").ToUpperInvariant().Contains(queryUpper);
                case "montototal": return NumMatches(rv.MontoTotal);
                case "usuarioregistro": return (rv.UsuarioRegistro ?? "").ToUpperInvariant().Contains(queryUpper);
                case "documentocliente": return (rv.DocumentoCliente ?? "").ToUpperInvariant().Contains(queryUpper);
                case "nombrecliente": return (rv.NombreCliente ?? "").ToUpperInvariant().Contains(queryUpper);
                case "codigoproducto": return (rv.CodigoProducto ?? "").ToUpperInvariant().Contains(queryUpper);
                case "nombreproducto": return (rv.NombreProducto ?? "").ToUpperInvariant().Contains(queryUpper);
                case "categoria": return (rv.Categoria ?? "").ToUpperInvariant().Contains(queryUpper);
                case "precioventa": return NumMatches(rv.PrecioVenta);

                default:
                    // Fallback amplio
                    return
                        (rv.NumeroDocumento ?? "").ToUpperInvariant().Contains(queryUpper) ||
                        (rv.TipoDocumento ?? "").ToUpperInvariant().Contains(queryUpper) ||
                        (rv.UsuarioRegistro ?? "").ToUpperInvariant().Contains(queryUpper) ||
                        (rv.DocumentoCliente ?? "").ToUpperInvariant().Contains(queryUpper) ||
                        (rv.NombreCliente ?? "").ToUpperInvariant().Contains(queryUpper) ||
                        (rv.CodigoProducto ?? "").ToUpperInvariant().Contains(queryUpper) ||
                        (rv.NombreProducto ?? "").ToUpperInvariant().Contains(queryUpper) ||
                        (rv.Categoria ?? "").ToUpperInvariant().Contains(queryUpper);
            }
        }

        /* =========================
           Render DGV
           ========================= */

        private void RenderVentas(IEnumerable<ReporteVenta> listado)
        {
            dgvdata.Rows.Clear();
            foreach (var rv in listado)
            {
                dgvdata.Rows.Add(new object[]
                {
                    rv.FechaRegistro,
                    rv.TipoDocumento,
                    rv.NumeroDocumento,
                    rv.MontoTotal,
                    rv.UsuarioRegistro,
                    rv.DocumentoCliente,
                    rv.NombreCliente,
                    rv.CodigoProducto,
                    rv.NombreProducto,
                    rv.Categoria,
                    rv.PrecioVenta
                });
            }
        }

        /* =========================
           Autocomplete según cbobusqueda
           ========================= */

        private static string NormalizeText(string s)
        {
            if (string.IsNullOrEmpty(s)) return string.Empty;
            var normalized = s.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();
            foreach (char ch in normalized)
            {
                var cat = System.Globalization.CharUnicodeInfo.GetUnicodeCategory(ch);
                if (cat != System.Globalization.UnicodeCategory.NonSpacingMark) sb.Append(ch);
            }
            return sb.ToString().Normalize(NormalizationForm.FormC);
        }

        private static bool ContainsLike(string haystack, string needle)
        {
            return NormalizeText(haystack).ToUpperInvariant()
                   .Contains(NormalizeText(needle).ToUpperInvariant());
        }

        private void txtbusqueda_TextChanged(object sender, EventArgs e)
        {
            // Posicionar ListBox debajo del textbox
            lbbusquedareporteventa.Left = txtbusqueda.Left;
            lbbusquedareporteventa.Top = txtbusqueda.Bottom + 2;
            lbbusquedareporteventa.Width = txtbusqueda.Width;

            string q = (txtbusqueda.Text ?? "").Trim();
            if (q.Length == 0 || _bufferVentas.Count == 0)
            {
                lbbusquedareporteventa.Visible = false;
                return;
            }

            string columna = (cbobusqueda.SelectedItem as OpcionCombo)?.Valor?.ToString() ?? "";

            // Construir sugerencias según columna elegida
            var sugs = BuildVentaSuggestions(_bufferVentas, columna, q).Take(12).ToList();
            if (sugs.Count == 0)
            {
                lbbusquedareporteventa.Visible = false;
                return;
            }

            lbbusquedareporteventa.BeginUpdate();
            lbbusquedareporteventa.DataSource = null;
            lbbusquedareporteventa.Items.Clear();
            lbbusquedareporteventa.DataSource = sugs; // SelectedItem = ItemSug
            lbbusquedareporteventa.EndUpdate();
            lbbusquedareporteventa.Visible = true;
        }

        private IEnumerable<ItemSug> BuildVentaSuggestions(IEnumerable<ReporteVenta> src, string columna, string q)
        {
            foreach (var rv in src)
            {
                string texto = null;
                string valor = null;

                switch ((columna ?? "").ToLowerInvariant())
                {
                    case "fecharegistro":
                        var f1 = rv.FechaRegistro.ToString("dd/MM/yyyy HH:mm:ss");
                        var f2 = rv.FechaRegistro.ToString("yyyy-MM-dd HH:mm:ss");
                        var f3 = rv.FechaRegistro.ToString("dd/MM/yyyy");
                        var f4 = rv.FechaRegistro.ToString("yyyy-MM-dd");
                        if (ContainsLike(f1, q) || ContainsLike(f2, q) || ContainsLike(f3, q) || ContainsLike(f4, q))
                        {
                            texto = $"{f3} — {rv.NumeroDocumento} — {rv.NombreCliente}";
                            valor = f3;
                        }
                        break;

                    case "tipodocumento":
                        if (ContainsLike(rv.TipoDocumento ?? "", q))
                        {
                            texto = $"{rv.TipoDocumento} — {rv.NumeroDocumento} — {rv.NombreCliente}";
                            valor = rv.TipoDocumento ?? "";
                        }
                        break;

                    case "numerodocumento":
                        if (ContainsLike(rv.NumeroDocumento ?? "", q))
                        {
                            texto = $"{rv.NumeroDocumento} — {rv.TipoDocumento} — {rv.NombreCliente}";
                            valor = rv.NumeroDocumento ?? "";
                        }
                        break;

                    case "montototal":
                        {
                            var n1 = rv.MontoTotal.ToString("#,0.##", CultureInfo.GetCultureInfo("es-AR"));
                            var n2 = rv.MontoTotal.ToString(CultureInfo.InvariantCulture);
                            if (ContainsLike(n1, q) || ContainsLike(n2, q))
                            {
                                texto = $"{n1} — {rv.NumeroDocumento} — {rv.NombreCliente}";
                                valor = n1;
                            }
                        }
                        break;

                    case "usuarioregistro":
                        if (ContainsLike(rv.UsuarioRegistro ?? "", q))
                        {
                            texto = $"{rv.UsuarioRegistro} — {rv.NumeroDocumento}";
                            valor = rv.UsuarioRegistro ?? "";
                        }
                        break;

                    case "documentocliente":
                        if (ContainsLike(rv.DocumentoCliente ?? "", q))
                        {
                            texto = $"{rv.DocumentoCliente} — {rv.NombreCliente}";
                            valor = rv.DocumentoCliente ?? "";
                        }
                        break;

                    case "nombrecliente":
                        if (ContainsLike(rv.NombreCliente ?? "", q))
                        {
                            texto = $"{rv.NombreCliente} — {rv.NumeroDocumento}";
                            valor = rv.NombreCliente ?? "";
                        }
                        break;

                    case "codigoproducto":
                        if (ContainsLike(rv.CodigoProducto ?? "", q))
                        {
                            texto = $"{rv.CodigoProducto} — {rv.NombreProducto} — {rv.NombreCliente}";
                            valor = rv.CodigoProducto ?? "";
                        }
                        break;

                    case "nombreproducto":
                        if (ContainsLike(rv.NombreProducto ?? "", q))
                        {
                            texto = $"{rv.NombreProducto} — {rv.CodigoProducto} — {rv.NombreCliente}";
                            valor = rv.NombreProducto ?? "";
                        }
                        break;

                    case "categoria":
                        if (ContainsLike(rv.Categoria ?? "", q))
                        {
                            texto = $"{rv.Categoria} — {rv.NombreProducto}";
                            valor = rv.Categoria ?? "";
                        }
                        break;

                    case "precioventa":
                        {
                            var n1 = rv.PrecioVenta.ToString("#,0.##", CultureInfo.GetCultureInfo("es-AR"));
                            var n2 = rv.PrecioVenta.ToString(CultureInfo.InvariantCulture);
                            if (ContainsLike(n1, q) || ContainsLike(n2, q))
                            {
                                texto = $"{n1} — {rv.NombreProducto}";
                                valor = n1;
                            }
                        }
                        break;

                    default:
                        // Fallback: número de doc y nombre cliente
                        if (ContainsLike(rv.NumeroDocumento ?? "", q) || ContainsLike(rv.NombreCliente ?? "", q))
                        {
                            texto = $"{rv.NumeroDocumento} — {rv.NombreCliente}";
                            valor = rv.NumeroDocumento ?? rv.NombreCliente ?? q;
                        }
                        break;
                }

                if (texto != null)
                    yield return new ItemSug(valor, texto);
            }
        }

        /* =========================
           Eventos autocomplete
           ========================= */

        private void txtbusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (!lbbusquedareporteventa.Visible) return;

            if (e.KeyCode == Keys.Down)
            {
                if (lbbusquedareporteventa.Items.Count > 0)
                {
                    lbbusquedareporteventa.SelectedIndex = 0;
                    lbbusquedareporteventa.Focus();
                }
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (lbbusquedareporteventa.Items.Count > 0)
                {
                    lbbusquedareporteventa.SelectedIndex = 0;
                    ConfirmarSeleccionVenta();
                }
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                lbbusquedareporteventa.Visible = false;
                e.Handled = true;
            }
        }

        private void lbbusquedareporteventa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ConfirmarSeleccionVenta();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                lbbusquedareporteventa.Visible = false;
                txtbusqueda.Focus();
                e.Handled = true;
            }
        }

        private void lbbusquedareporteventa_Click(object sender, EventArgs e)
        {
            ConfirmarSeleccionVenta();
        }

        private void ConfirmarSeleccionVenta()
        {
            if (lbbusquedareporteventa.SelectedItem is ItemSug it)
            {
                txtbusqueda.Text = it.ValorBusqueda;
                lbbusquedareporteventa.Visible = false;
                ApplyVentaFilter();
            }
        }
    }
}
