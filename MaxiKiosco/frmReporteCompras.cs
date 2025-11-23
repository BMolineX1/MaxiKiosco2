using CapaEntidad;
using CapaNegocio;
using ClosedXML.Excel;
using MaxiKiosco.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MaxiKiosco
{
    public partial class frmReporteCompras : Form
    {
        // Buffer con el último resultado traído del SP (para filtrar y sugerir en memoria)
        private List<ReporteCompra> _bufferCompras = new List<ReporteCompra>();

        // ====== Item sugerencia ======
        private sealed class ItemSug
        {
            public string ValorBusqueda { get; }
            public string Texto { get; }
            public ItemSug(string valorBusqueda, string texto) { ValorBusqueda = valorBusqueda; Texto = texto; }
            public override string ToString() => Texto;
        }

        public frmReporteCompras()
        {
            InitializeComponent();
        }

        private void frmReporteCompras_Load(object sender, EventArgs e)
        {
            // ---- Proveedores
            List<Proveedor> lista = new CN_Proveedor().Listar();
            cboproveedor.Items.Add(new OpcionCombo() { Valor = 0, texto = "TODOS" });
            foreach (Proveedor item in lista)
                cboproveedor.Items.Add(new OpcionCombo() { Valor = item.id, texto = item.razonsocial });

            cboproveedor.DisplayMember = "Texto";
            cboproveedor.ValueMember = "Valor";
            cboproveedor.SelectedIndex = 0;

            // ---- Columnas para cbobusqueda
            cbobusqueda.Items.Clear();
            foreach (DataGridViewColumn columna in dgvdata.Columns)
            {
                if (columna.Visible == true && columna.Name != "btnseleccionar")
                {
                    cbobusqueda.Items.Add(new OpcionCombo()
                    {
                        Valor = columna.Name,      // Name para mapear 1:1
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

            lbbusquedareportecompra.Visible = false;
            lbbusquedareportecompra.DisplayMember = "Texto";
            lbbusquedareportecompra.Click += lbbusquedareportecompra_Click;
            lbbusquedareportecompra.KeyDown += lbbusquedareportecompra_KeyDown;
        }

        /* =========================
           Acciones principales
           ========================= */

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            int idproveedor = Convert.ToInt32(((OpcionCombo)cboproveedor.SelectedItem).Valor);
            string fechaInicio = txtfechainicio.Value.ToString("yyyy-MM-dd");
            string fechaFin = txtfechafin.Value.ToString("yyyy-MM-dd");

            // Trae del SP y guarda en buffer
            _bufferCompras = new CN_Reporte().Compra(fechaInicio, fechaFin, idproveedor) ?? new List<ReporteCompra>();

            // Render inicial (sin filtro)
            RenderCompras(_bufferCompras);
            //  Calcular el total de la lista cargada
            CalcularTotalFiltro(); // <== LLAMADA CLAVE

            // Reiniciar sugerencias
            lbbusquedareportecompra.Visible = false;
        }

        private void RenderCompras(IEnumerable<ReporteCompra> listado)
        {
            dgvdata.Rows.Clear();
            foreach (ReporteCompra item in listado)
            {
                //  Ajustá al ORDEN EXACTO de tu DGV
                dgvdata.Rows.Add(new object[] {
                    item.FechaRegistro,
                    item.TipoDocumento,
                    item.NumeroDocumento,
                    item.MontoTotal,
                    item.UsuarioRegistro,
                    item.DocumentoProveedor,
                    item.RazonSocial,
                    item.CodigoProducto,
                    item.NombreProducto,
                    item.Categoria,
                    item.PrecioCompra,
                    item.PrecioVenta,
                    item.Cantidad,
                    item.SubTotal
                });
            }
        }

        /* =========================
           Exportar Excel (tu versión)
           ========================= */
        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (dgvdata.Rows.Count < 1)
            {
                MessageBox.Show("No hay datos para exportar", "Mensaje",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                var columnas = dgvdata.Columns
                    .Cast<DataGridViewColumn>()
                    .Where(c => c.Visible && !(c is DataGridViewButtonColumn) && !(c is DataGridViewImageColumn))
                    .OrderBy(c => c.DisplayIndex)
                    .ToList();

                if (columnas.Count == 0)
                {
                    MessageBox.Show("No hay columnas visibles para exportar.", "Mensaje",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                DataTable dt = new DataTable("ReporteCompras");
                foreach (var col in columnas)
                    dt.Columns.Add(col.HeaderText, typeof(string));

                foreach (DataGridViewRow row in dgvdata.Rows)
                {
                    if (row.IsNewRow || !row.Visible) continue;

                    var values = new object[columnas.Count];

                    for (int i = 0; i < columnas.Count; i++)
                    {
                        var cell = row.Cells[columnas[i].Index];
                        var val = cell?.Value;

                        if (val == null || val == DBNull.Value)
                        {
                            values[i] = string.Empty;
                        }
                        else if (val is DateTime dtVal)
                        {
                            values[i] = dtVal.ToString("dd/MM/yyyy HH:mm:ss");
                        }
                        else if (val is IFormattable formattable)
                        {
                            values[i] = formattable.ToString("#,0.##", CultureInfo.GetCultureInfo("es-AR"));
                        }
                        else
                        {
                            values[i] = val.ToString();
                        }
                    }

                    dt.Rows.Add(values);
                }

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No hay filas visibles para exportar.", "Mensaje",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                using (SaveFileDialog savefile = new SaveFileDialog())
                {
                    savefile.FileName = string.Format("ReporteCompras_{0}.xlsx",
                        DateTime.Now.ToString("ddMMyyyyHHmm"));
                    savefile.Filter = "Excel Files|*.xlsx";

                    if (savefile.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            using (XLWorkbook wb = new XLWorkbook())
                            {
                                var hoja = wb.Worksheets.Add(dt, "Informe");
                                hoja.Columns().AdjustToContents();
                                wb.SaveAs(savefile.FileName);
                            }

                            MessageBox.Show("Reporte generado correctamente.", "Mensaje",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al generar el reporte:\n" + ex.Message, "Mensaje",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
            }
        }

        /* =========================
           Filtrado general por combo
           ========================= */

        private void iconButton1_Click(object sender, EventArgs e) => ApplyCompraFilter();

        private void CalcularTotalFiltro()
        {
            decimal total = 0m;

            var colMonto = dgvdata.Columns["MontoTotal"];
            var colNumDoc = dgvdata.Columns["NumeroDocumento"];

            if (colMonto == null || colNumDoc == null)
            {
                txttotalfiltro.Text = "N/A";
                return;
            }

            var docsYaSumados = new HashSet<string>();

            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                if (row.IsNewRow || !row.Visible) continue;

                string numeroDoc = Convert.ToString(row.Cells[colNumDoc.Index].Value) ?? "";
                if (string.IsNullOrWhiteSpace(numeroDoc)) continue;

                if (docsYaSumados.Contains(numeroDoc))
                    continue;

                docsYaSumados.Add(numeroDoc);

                object valorCelda = row.Cells[colMonto.Index].Value;
                if (valorCelda == null || valorCelda == DBNull.Value) continue;

                decimal montoFila;

                if (valorCelda is decimal d)
                {
                    montoFila = d;
                }
                else
                {
                    var texto = valorCelda.ToString();
                    if (!decimal.TryParse(texto, NumberStyles.Any, CultureInfo.GetCultureInfo("es-AR"), out montoFila) &&
                        !decimal.TryParse(texto, NumberStyles.Any, CultureInfo.InvariantCulture, out montoFila))
                    {
                        continue;
                    }
                }

                total += montoFila;
            }

            txttotalfiltro.Text = total.ToString("N2");
        }

        private void ApplyCompraFilter()
        {
            string query = (txtbusqueda.Text ?? "").Trim().ToUpperInvariant();
            string columna = (cbobusqueda.SelectedItem as OpcionCombo)?.Valor?.ToString() ?? "";

            IEnumerable<ReporteCompra> source = _bufferCompras ?? Enumerable.Empty<ReporteCompra>();

            if (!string.IsNullOrEmpty(query))
                source = source.Where(rc => CompraMatches(rc, columna, query));

            RenderCompras(source);
        }

        private bool CompraMatches(ReporteCompra rc, string columna, string queryUpper)
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
                    string f1 = rc.FechaRegistro.ToString("dd/MM/yyyy HH:mm:ss").ToUpperInvariant();
                    string f2 = rc.FechaRegistro.ToString("yyyy-MM-dd HH:mm:ss").ToUpperInvariant();
                    string f3 = rc.FechaRegistro.ToString("dd/MM/yyyy").ToUpperInvariant();
                    string f4 = rc.FechaRegistro.ToString("yyyy-MM-dd").ToUpperInvariant();
                    return f1.Contains(queryUpper) || f2.Contains(queryUpper) || f3.Contains(queryUpper) || f4.Contains(queryUpper);

                case "tipodocumento":
                    return (rc.TipoDocumento ?? "").ToUpperInvariant().Contains(queryUpper);

                case "numerodocumento":
                    return (rc.NumeroDocumento ?? "").ToUpperInvariant().Contains(queryUpper);

                case "montototal":
                    return NumMatches(rc.MontoTotal);

                case "usuarioregistro":
                    return (rc.UsuarioRegistro ?? "").ToUpperInvariant().Contains(queryUpper);

                case "documentoproveedor":
                    return (rc.DocumentoProveedor ?? "").ToUpperInvariant().Contains(queryUpper);

                case "razonsocial":
                    return (rc.RazonSocial ?? "").ToUpperInvariant().Contains(queryUpper);

                case "codigoproducto":
                    return (rc.CodigoProducto ?? "").ToUpperInvariant().Contains(queryUpper);

                case "nombreproducto":
                    return (rc.NombreProducto ?? "").ToUpperInvariant().Contains(queryUpper);

                case "categoria":
                    return (rc.Categoria ?? "").ToUpperInvariant().Contains(queryUpper);

                case "preciocompra":
                    return NumMatches(rc.PrecioCompra);

                case "precioventa":
                    return NumMatches(rc.PrecioVenta);

                case "cantidad":
                    return NumMatches(rc.Cantidad);

                case "subtotal":
                    return NumMatches(rc.SubTotal);

                default:
                    // Fallback: búsqueda amplia
                    return
                        (rc.NumeroDocumento ?? "").ToUpperInvariant().Contains(queryUpper) ||
                        (rc.TipoDocumento ?? "").ToUpperInvariant().Contains(queryUpper) ||
                        (rc.UsuarioRegistro ?? "").ToUpperInvariant().Contains(queryUpper) ||
                        (rc.DocumentoProveedor ?? "").ToUpperInvariant().Contains(queryUpper) ||
                        (rc.RazonSocial ?? "").ToUpperInvariant().Contains(queryUpper) ||
                        (rc.CodigoProducto ?? "").ToUpperInvariant().Contains(queryUpper) ||
                        (rc.NombreProducto ?? "").ToUpperInvariant().Contains(queryUpper) ||
                        (rc.Categoria ?? "").ToUpperInvariant().Contains(queryUpper);
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
            lbbusquedareportecompra.Left = txtbusqueda.Left;
            lbbusquedareportecompra.Top = txtbusqueda.Bottom + 2;
            lbbusquedareportecompra.Width = txtbusqueda.Width;

            string q = (txtbusqueda.Text ?? "").Trim();
            if (q.Length == 0 || _bufferCompras.Count == 0)
            {
                lbbusquedareportecompra.Visible = false;
                return;
            }

            string columna = (cbobusqueda.SelectedItem as OpcionCombo)?.Valor?.ToString() ?? "";

            // Construir sugerencias según columna elegida
            var sugs = BuildCompraSuggestions(_bufferCompras, columna, q).Take(12).ToList();
            if (sugs.Count == 0)
            {
                lbbusquedareportecompra.Visible = false;
                return;
            }

            lbbusquedareportecompra.BeginUpdate();
            lbbusquedareportecompra.DataSource = null;
            lbbusquedareportecompra.Items.Clear();
            lbbusquedareportecompra.DataSource = sugs; // SelectedItem = ItemSug
            lbbusquedareportecompra.EndUpdate();
            lbbusquedareportecompra.Visible = true;

            CalcularTotalFiltro(); // <== LLAMADA CLAVE (colócalo al final del método)
        }

        private IEnumerable<ItemSug> BuildCompraSuggestions(IEnumerable<ReporteCompra> src, string columna, string q)
        {
            // Normaliza el query para ContainsLike
            foreach (var rc in src)
            {
                string texto = null;
                string valor = null;

                switch ((columna ?? "").ToLowerInvariant())
                {
                    case "fecharegistro":
                        var f1 = rc.FechaRegistro.ToString("dd/MM/yyyy HH:mm:ss");
                        var f2 = rc.FechaRegistro.ToString("yyyy-MM-dd HH:mm:ss");
                        var f3 = rc.FechaRegistro.ToString("dd/MM/yyyy");
                        var f4 = rc.FechaRegistro.ToString("yyyy-MM-dd");
                        if (ContainsLike(f1, q) || ContainsLike(f2, q) || ContainsLike(f3, q) || ContainsLike(f4, q))
                        {
                            texto = $"{f3} {rc.NumeroDocumento} — {rc.RazonSocial}";
                            valor = f3; // dejo la fecha dd/MM/yyyy
                        }
                        break;

                    case "tipodocumento":
                        if (ContainsLike(rc.TipoDocumento ?? "", q))
                        {
                            texto = $"{rc.TipoDocumento} — {rc.NumeroDocumento} — {rc.RazonSocial}";
                            valor = rc.TipoDocumento ?? "";
                        }
                        break;

                    case "numerodocumento":
                        if (ContainsLike(rc.NumeroDocumento ?? "", q))
                        {
                            texto = $"{rc.NumeroDocumento} — {rc.TipoDocumento} — {rc.RazonSocial}";
                            valor = rc.NumeroDocumento ?? "";
                        }
                        break;

                    case "montototal":
                        {
                            var n1 = rc.MontoTotal.ToString("#,0.##", CultureInfo.GetCultureInfo("es-AR"));
                            var n2 = rc.MontoTotal.ToString(CultureInfo.InvariantCulture);
                            if (ContainsLike(n1, q) || ContainsLike(n2, q))
                            {
                                texto = $"{n1} — {rc.NumeroDocumento} — {rc.RazonSocial}";
                                valor = n1;
                            }
                        }
                        break;

                    case "usuarioregistro":
                        if (ContainsLike(rc.UsuarioRegistro ?? "", q))
                        {
                            texto = $"{rc.UsuarioRegistro} — {rc.NumeroDocumento} — {rc.RazonSocial}";
                            valor = rc.UsuarioRegistro ?? "";
                        }
                        break;

                    case "documentoproveedor":
                        if (ContainsLike(rc.DocumentoProveedor ?? "", q))
                        {
                            texto = $"{rc.DocumentoProveedor} — {rc.RazonSocial} — {rc.NumeroDocumento}";
                            valor = rc.DocumentoProveedor ?? "";
                        }
                        break;

                    case "razonsocial":
                        if (ContainsLike(rc.RazonSocial ?? "", q))
                        {
                            texto = $"{rc.RazonSocial} — {rc.NumeroDocumento}";
                            valor = rc.RazonSocial ?? "";
                        }
                        break;

                    case "codigoproducto":
                        if (ContainsLike(rc.CodigoProducto ?? "", q))
                        {
                            texto = $"{rc.CodigoProducto} — {rc.NombreProducto} — {rc.RazonSocial}";
                            valor = rc.CodigoProducto ?? "";
                        }
                        break;

                    case "nombreproducto":
                        if (ContainsLike(rc.NombreProducto ?? "", q))
                        {
                            texto = $"{rc.NombreProducto} — {rc.CodigoProducto} — {rc.RazonSocial}";
                            valor = rc.NombreProducto ?? "";
                        }
                        break;

                    case "categoria":
                        if (ContainsLike(rc.Categoria ?? "", q))
                        {
                            texto = $"{rc.Categoria} — {rc.NombreProducto} — {rc.RazonSocial}";
                            valor = rc.Categoria ?? "";
                        }
                        break;

                    case "preciocompra":
                        {
                            var n1 = rc.PrecioCompra.ToString("#,0.##", CultureInfo.GetCultureInfo("es-AR"));
                            var n2 = rc.PrecioCompra.ToString(CultureInfo.InvariantCulture);
                            if (ContainsLike(n1, q) || ContainsLike(n2, q))
                            {
                                texto = $"{n1} — {rc.NombreProducto} — {rc.RazonSocial}";
                                valor = n1;
                            }
                        }
                        break;

                    case "precioventa":
                        {
                            var n1 = rc.PrecioVenta.ToString("#,0.##", CultureInfo.GetCultureInfo("es-AR"));
                            var n2 = rc.PrecioVenta.ToString(CultureInfo.InvariantCulture);
                            if (ContainsLike(n1, q) || ContainsLike(n2, q))
                            {
                                texto = $"{n1} — {rc.NombreProducto} — {rc.RazonSocial}";
                                valor = n1;
                            }
                        }
                        break;

                    case "cantidad":
                        {
                            var n1 = rc.Cantidad.ToString("#,0.##", CultureInfo.GetCultureInfo("es-AR"));
                            var n2 = rc.Cantidad.ToString(CultureInfo.InvariantCulture);
                            if (ContainsLike(n1, q) || ContainsLike(n2, q))
                            {
                                texto = $"{n1} — {rc.NombreProducto} — {rc.RazonSocial}";
                                valor = n1;
                            }
                        }
                        break;

                    case "subtotal":
                        {
                            var n1 = rc.SubTotal.ToString("#,0.##", CultureInfo.GetCultureInfo("es-AR"));
                            var n2 = rc.SubTotal.ToString(CultureInfo.InvariantCulture);
                            if (ContainsLike(n1, q) || ContainsLike(n2, q))
                            {
                                texto = $"{n1} — {rc.NombreProducto} — {rc.RazonSocial}";
                                valor = n1;
                            }
                        }
                        break;

                    default:
                        // Fallback: usar número de doc + razón social
                        if (ContainsLike(rc.NumeroDocumento ?? "", q) || ContainsLike(rc.RazonSocial ?? "", q))
                        {
                            texto = $"{rc.NumeroDocumento} — {rc.RazonSocial}";
                            valor = rc.NumeroDocumento ?? rc.RazonSocial ?? q;
                        }
                        break;
                }

                if (texto != null)
                    yield return new ItemSug(valor, texto);
            }
        }

        private void txtbusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (!lbbusquedareportecompra.Visible) return;

            if (e.KeyCode == Keys.Down)
            {
                if (lbbusquedareportecompra.Items.Count > 0)
                {
                    lbbusquedareportecompra.SelectedIndex = 0;
                    lbbusquedareportecompra.Focus();
                }
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (lbbusquedareportecompra.Items.Count > 0)
                {
                    lbbusquedareportecompra.SelectedIndex = 0;
                    ConfirmarSeleccionCompra();
                }
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                lbbusquedareportecompra.Visible = false;
                e.Handled = true;
            }
        }

        private void lbbusquedareportecompra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ConfirmarSeleccionCompra();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                lbbusquedareportecompra.Visible = false;
                txtbusqueda.Focus();
                e.Handled = true;
            }
        }

        private void lbbusquedareportecompra_Click(object sender, EventArgs e)
        {
            ConfirmarSeleccionCompra();
        }

        private void ConfirmarSeleccionCompra()
        {
            if (lbbusquedareportecompra.SelectedItem is ItemSug it)
            {
                txtbusqueda.Text = it.ValorBusqueda;
                lbbusquedareportecompra.Visible = false;
                ApplyCompraFilter();
            }
        }

        private void btnlimpiarbuscador_Click(object sender, EventArgs e)
        {
            txtbusqueda.Text = "";
            lbbusquedareportecompra.Visible = false;
            RenderCompras(_bufferCompras);
            CalcularTotalFiltro(); // <== LLAMADA CLAVE
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
