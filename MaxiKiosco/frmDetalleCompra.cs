using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing;              // GDI+
using System.Drawing.Imaging;      // ImageFormat
using System.ComponentModel;       // Designer guard
using System.Diagnostics;          // Designer guard
using System.Collections.Generic;

using CapaEntidad;
using CapaNegocio;

using iTextSharp.text;             // iText (Paragraph, FontFactory, etc.)
using iTextSharp.text.pdf;         // iText PDF (PdfWriter, PdfPCell, PdfPTable, etc.)
using iTextSharp.text.pdf.draw;    // LineSeparator
using iTextSharp.tool.xml;         // XMLWorker (ParseXHtml)

// ==== ALIAS para desambiguar tipos con el mismo nombre ====
using DrawingImage = System.Drawing.Image;            // imágenes GDI+ (logo)
using PdfImage = iTextSharp.text.Image;               // imágenes en iText
using PdfRectangle = iTextSharp.text.Rectangle;       // NO_BORDER, BOX, etc.
using PdfFont = iTextSharp.text.Font;                 // fuentes iText

namespace MaxiKiosco
{
    // ===== Pie de página: nombre de negocio + numeración =====
    internal class BrandedFooter : PdfPageEventHelper
    {
        private readonly string _negocio;
        private readonly BaseColor _muted = new BaseColor(108, 117, 125);
        private readonly BaseColor _line = new BaseColor(210, 214, 220);
        private readonly PdfFont _font;

        public BrandedFooter(string negocio)
        {
            _negocio = string.IsNullOrWhiteSpace(negocio) ? "Mi Negocio" : negocio;
            _font = FontFactory.GetFont(FontFactory.HELVETICA, 8f, _muted);
        }

        public override void OnEndPage(PdfWriter writer, Document document)
        {
            var cb = writer.DirectContent;
            float left = document.LeftMargin;
            float right = document.PageSize.Width - document.RightMargin;
            float y = document.BottomMargin - 12f;

            // línea sutil
            cb.SetColorStroke(_line);
            cb.MoveTo(left, y + 6f);
            cb.LineTo(right, y + 6f);
            cb.Stroke();

            // texto izquierda: nombre negocio
            ColumnText.ShowTextAligned(cb, Element.ALIGN_LEFT,
                new Phrase(_negocio, _font), left, y, 0);

            // texto derecha: página X
            var pageText = $"Página {writer.PageNumber}";
            ColumnText.ShowTextAligned(cb, Element.ALIGN_RIGHT,
                new Phrase(pageText, _font), right, y, 0);
        }
    }

    public partial class frmDetalleCompra : Form
    {
        // ===== Cache de datos/imagen del negocio para la cabecera del PDF =====
        private CapaEntidad.Negocio _negocio;
        private DrawingImage _logoImg;

        // ====== AUTOCOMPLETE (compras) ======
        private List<Compra> _comprasIndex = new List<Compra>(); // cabeceras para sugerir
        private ListBox _lbSugsCompras;                           // lista creada por código

        public frmDetalleCompra()
        {
            InitializeComponent();
            this.Load += frmDetalleCompra_Load;
        }

        // ===== Guard de diseñador =====
        private static bool IsDesignMode() =>
            LicenseManager.UsageMode == LicenseUsageMode.Designtime ||
            Process.GetCurrentProcess().ProcessName.Equals("devenv", StringComparison.OrdinalIgnoreCase);

        private void frmDetalleCompra_Load(object sender, EventArgs e)
        {
            if (IsDesignMode()) return; // ⬅️ evita ejecutar lógica en el diseñador

            // No autogenerar columnas: usamos las que ya creaste en el diseñador
            dgvdata.AutoGenerateColumns = false;
            dgvdata.AllowUserToAddRows = false;

            // Traer datos de negocio (para PDF)
            CargarDatosNegocio();

            // (Opcional) Formatos de columnas numéricas
            if (dgvdata.Columns.Contains("PrecioCompra"))
            {
                dgvdata.Columns["PrecioCompra"].DefaultCellStyle.Format = "N2";
                dgvdata.Columns["PrecioCompra"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            if (dgvdata.Columns.Contains("Cantidad"))
                dgvdata.Columns["Cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            if (dgvdata.Columns.Contains("SubTotal"))
            {
                dgvdata.Columns["SubTotal"].DefaultCellStyle.Format = "N2";
                dgvdata.Columns["SubTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            // ====== Construir índice de compras para sugerencias ======
            try
            {
                var cn = new CN_Compra();
                // Debe existir en tu CN_Compra (ya te pasé su implementación)
                _comprasIndex = cn.ListarCabeceras();
                if (_comprasIndex == null) _comprasIndex = new List<Compra>();
            }
            catch
            {
                _comprasIndex = new List<Compra>();
            }

            // ====== Crear ListBox de sugerencias debajo de txttipodocumento ======
            _lbSugsCompras = new ListBox
            {
                Visible = false,
                Height = 140,
                Width = txttipodocumento.Width,
                Left = txttipodocumento.Left,
                Top = txttipodocumento.Bottom + 2
            };
            _lbSugsCompras.DisplayMember = "Texto";  // 👈 importante para mostrar la propiedad Texto
            _lbSugsCompras.Click += _lbSugsCompras_Click;
            _lbSugsCompras.KeyDown += _lbSugsCompras_KeyDown;
            this.Controls.Add(_lbSugsCompras);
            _lbSugsCompras.BringToFront();

            // eventos de búsqueda
            txtbusqueda.TextChanged += txtbusqueda_TextChanged;
            txtbusqueda.KeyDown += txtbusqueda_KeyDown;
        }

        // ===== Helpers negocio =====
        private void CargarDatosNegocio()
        {
            try
            {
                _negocio = new CN_Negocio().ObtenerDatos();

                bool okLogo;
                var bytesLogo = new CN_Negocio().ObtenerLogo(out okLogo);
                _logoImg = (okLogo && bytesLogo != null && bytesLogo.Length > 0)
                           ? ByteToImage(bytesLogo)
                           : null;
            }
            catch
            {
                _negocio = null;
                _logoImg = null;
            }
        }

        private DrawingImage ByteToImage(byte[] imageBytes)
        {
            if (imageBytes == null || imageBytes.Length == 0) return null;
            using (var ms = new MemoryStream(imageBytes))
            {
                return DrawingImage.FromStream(ms);
            }
        }

        // ===================== BUSCAR COMPRA =====================
        private void btnbuscar_Click(object sender, EventArgs e)
        {
            CargarCompraPorNumero(txtbusqueda.Text?.Trim());
        }

        private void CargarCompraPorNumero(string numero)
        {
            var cn = new CN_Compra();
            var compra = cn.ObtenerCompra(numero, out var msgCabecera);

            if (compra == null)
            {
                MessageBox.Show(
                    string.IsNullOrWhiteSpace(msgCabecera) ? "No se encontró la compra." : msgCabecera,
                    "Buscar compra", MessageBoxButtons.OK, MessageBoxIcon.Information
                );
                LimpiarVista();
                return;
            }

            // ---- Cabecera
            txtnumerodocumento.Text = compra.numerodocumento;
            txtfecha.Text = compra.fecharegistro.ToString("dd/MM/yyyy HH:mm");
            txtusuario.Text = $"{compra.ousuario.nombre} {compra.ousuario.apellido}".Trim();
            txtdocproveedor.Text = compra.oproveedor.cuit;
            txtrazonsocialproveedor.Text = compra.oproveedor.razonsocial;
            txttipodocumento.Text = compra.tipodocumento;

            // ---- Detalle
            var detalle = cn.ObtenerDetalleCompra(compra.id, out _);

            dgvdata.Rows.Clear(); // limpiar filas anteriores

            int iProd = dgvdata.Columns["Producto"].Index;
            int iPrecio = dgvdata.Columns["PrecioCompra"].Index;
            int iCant = dgvdata.Columns["Cantidad"].Index;
            int iSub = dgvdata.Columns["SubTotal"].Index;

            decimal totalCalculado = 0m;

            foreach (var d in detalle)
            {
                string producto = d.oproducto.nombre;
                decimal precio = d.precio_compra;
                int cantidad = d.cantidad;
                decimal subtotal = d.montototal > 0 ? d.montototal : cantidad * precio;

                int rowIndex = dgvdata.Rows.Add();
                var row = dgvdata.Rows[rowIndex];

                row.Cells[iProd].Value = producto;
                row.Cells[iPrecio].Value = precio;
                row.Cells[iCant].Value = cantidad;
                row.Cells[iSub].Value = subtotal;

                totalCalculado += subtotal;
            }

            var total = compra.montototal > 0 ? compra.montototal : totalCalculado;
            txttotal.Text = total.ToString("N2");

            // ocultar sugerencias
            _lbSugsCompras.Visible = false;
        }

        private void LimpiarVista()
        {
            txtnumerodocumento.Clear();
            txtfecha.Clear();
            txtusuario.Clear();
            txtdocproveedor.Clear();
            txtrazonsocialproveedor.Clear();
            txttipodocumento.Clear();
            txttotal.Clear();
            dgvdata.Rows.Clear();
        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            LimpiarVista();
        }

        // ===================== PDF =====================
        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (dgvdata.Rows.Count == 0)
            {
                MessageBox.Show("No hay ítems para exportar.", "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (_negocio == null || string.IsNullOrWhiteSpace(_negocio.nombre))
            {
                CargarDatosNegocio();
            }

            using (var sfd = new SaveFileDialog
            {
                Filter = "PDF (*.pdf)|*.pdf",
                FileName = $"Compra_{txtnumerodocumento.Text}.pdf",
                OverwritePrompt = true
            })
            {
                if (sfd.ShowDialog() != DialogResult.OK) return;

                try
                {
                    using (var fs = new FileStream(sfd.FileName, FileMode.Create))
                    using (var doc = new Document(PageSize.A4, 36, 36, 36, 36))
                    {
                        var writer = PdfWriter.GetInstance(doc, fs);
                        writer.PageEvent = new BrandedFooter(_negocio?.nombre ?? "");
                        doc.Open();

                        // ======= PALETA Y FUENTES =======
                        BaseColor bgSoft = new BaseColor(245, 246, 248);
                        BaseColor borderCol = new BaseColor(210, 214, 220);
                        BaseColor textDark = new BaseColor(33, 37, 41);
                        BaseColor textMuted = new BaseColor(108, 117, 125);
                        BaseColor brand = new BaseColor(52, 120, 246);

                        PdfFont fTitle = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 13f, textDark);
                        PdfFont fName = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12f, textDark);
                        PdfFont fLabel = FontFactory.GetFont(FontFactory.HELVETICA, 9.5f, textMuted);
                        PdfFont fValue = FontFactory.GetFont(FontFactory.HELVETICA, 10f, textDark);

                        // ======= CABECERA TARJETA =======
                        var card = new PdfPTable(1) { WidthPercentage = 100f };
                        var cardCell = new PdfPCell
                        {
                            Border = PdfRectangle.BOX,
                            BorderColor = borderCol,
                            BackgroundColor = bgSoft,
                            Padding = 10f
                        };

                        var ribbon = new PdfPTable(1) { WidthPercentage = 100f };
                        var ribbonCell = new PdfPCell(new Phrase(" "))
                        {
                            BackgroundColor = brand,
                            FixedHeight = 4f,
                            Border = PdfRectangle.NO_BORDER
                        };
                        ribbon.AddCell(ribbonCell);
                        cardCell.AddElement(ribbon);
                        cardCell.AddElement(new Paragraph(" "));

                        var header = new PdfPTable(new float[] { 28f, 72f }) { WidthPercentage = 100f };

                        PdfPCell celLogo;
                        if (_logoImg != null)
                        {
                            using (var ms = new MemoryStream())
                            {
                                _logoImg.Save(ms, ImageFormat.Png);
                                var img = PdfImage.GetInstance(ms.ToArray());
                                img.ScaleToFit(110f, 55f);
                                img.Alignment = Element.ALIGN_LEFT;
                                celLogo = new PdfPCell(img, fit: true);
                            }
                        }
                        else
                        {
                            celLogo = new PdfPCell(new Phrase(" "));
                        }
                        celLogo.Border = PdfRectangle.NO_BORDER;
                        celLogo.VerticalAlignment = Element.ALIGN_MIDDLE;
                        header.AddCell(celLogo);

                        var datos = new PdfPTable(1) { WidthPercentage = 100f };
                        var pName = new Paragraph((_negocio?.nombre ?? "Mi Negocio"), fName) { Leading = 14f };
                        var cName = new PdfPCell(pName) { Border = PdfRectangle.NO_BORDER, PaddingBottom = 2f };
                        datos.AddCell(cName);

                        PdfPCell MakeRow(string label, string value)
                        {
                            var p = new Paragraph();
                            p.Add(new Chunk(label + ": ", fLabel));
                            p.Add(new Chunk(string.IsNullOrWhiteSpace(value) ? "-" : value, fValue));
                            return new PdfPCell(p)
                            {
                                Border = PdfRectangle.NO_BORDER,
                                PaddingTop = 1f,
                                PaddingBottom = 1f
                            };
                        }

                        datos.AddCell(MakeRow("RUC/CUIT", _negocio?.ruc));
                        datos.AddCell(MakeRow("Dirección", _negocio?.direccion));
                        datos.AddCell(MakeRow("Fecha de emisión", DateTime.Now.ToString("dd/MM/yyyy HH:mm")));

                        var celDatos = new PdfPCell(datos)
                        {
                            Border = PdfRectangle.NO_BORDER,
                            PaddingLeft = 6f,
                            VerticalAlignment = Element.ALIGN_MIDDLE
                        };
                        header.AddCell(celDatos);

                        cardCell.AddElement(header);
                        card.AddCell(cardCell);
                        doc.Add(card);

                        var sep = new LineSeparator(0.5f, 100f, borderCol, Element.ALIGN_CENTER, -4f);
                        doc.Add(new Chunk(sep));
                        doc.Add(new Paragraph(" "));

                        var titulo = new Paragraph("Detalle de Compra", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14f, textDark))
                        { Alignment = Element.ALIGN_CENTER, SpacingAfter = 8f };
                        doc.Add(titulo);

                        var chip = new PdfPTable(new float[] { 20f, 20f, 20f, 20f, 20f }) { WidthPercentage = 100f };
                        PdfPCell MakeChip(string label, string value)
                        {
                            var wrap = new PdfPTable(1) { WidthPercentage = 100f };
                            var cell = new PdfPCell { BackgroundColor = bgSoft, BorderColor = borderCol, Padding = 6f };

                            var p = new Paragraph();
                            p.Add(new Chunk(label + "\n", fLabel));
                            p.Add(new Chunk(string.IsNullOrWhiteSpace(value) ? "-" : value, fValue));

                            cell.AddElement(p);
                            wrap.AddCell(cell);

                            return new PdfPCell(wrap)
                            {
                                Border = PdfRectangle.NO_BORDER,
                                Padding = 2f
                            };
                        }

                        chip.AddCell(MakeChip("Nro", txtnumerodocumento.Text));
                        chip.AddCell(MakeChip("Tipo", txttipodocumento.Text));
                        chip.AddCell(MakeChip("Fecha", txtfecha.Text));
                        chip.AddCell(MakeChip("Usuario", txtusuario.Text));
                        chip.AddCell(MakeChip("Proveedor", txtrazonsocialproveedor.Text));

                        doc.Add(chip);
                        doc.Add(new Paragraph(" "));

                        string html = BuildHtmlDetalleCompra();
                        using (var srHtml = new StringReader(html))
                        {
                            XMLWorkerHelper.GetInstance().ParseXHtml(writer, doc, srHtml);
                        }

                        doc.Close();
                    }

                    MessageBox.Show("PDF generado correctamente.", "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al generar PDF: " + ex.Message, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ===== HTML del detalle =====
        private string BuildHtmlDetalleCompra()
        {
            string E(string s) => (s ?? "")
                .Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;")
                .Replace("\"", "&quot;").Replace("'", "&#39;");

            var sb = new StringBuilder();

            sb.Append(@"
<!DOCTYPE html>
<html>
<head>
<meta charset='utf-8' />
<style>
    body { font-family: Helvetica, Arial, sans-serif; font-size: 11pt; color: #222; }
    h2 { margin: 0 0 8px 0; }
    .meta, .totals { width: 100%; border-collapse: collapse; margin-bottom: 12px; }
    .meta td { padding: 4px 6px; vertical-align: top; }
    .label { color: #666; width: 28%; }
    .value { font-weight: bold; }
    table.detalle { width: 100%; border-collapse: collapse; }
    table.detalle th, table.detalle td { border: 1px solid #888; padding: 6px; }
    table.detalle th { background: #f0f0f0; text-align: left; }
    td.num { text-align: right; }
    .right { text-align: right; }
</style>
</head>
<body>
");

            // Cabecera de la compra (texto simple)
            sb.Append("<table class='meta'>");
            sb.AppendFormat("<tr><td class='label'>Número de documento:</td><td class='value'>{0}</td></tr>", E(txtnumerodocumento.Text));
            sb.AppendFormat("<tr><td class='label'>Tipo de documento:</td><td class='value'>{0}</td></tr>", E(txttipodocumento.Text));
            sb.AppendFormat("<tr><td class='label'>Fecha:</td><td class='value'>{0}</td></tr>", E(txtfecha.Text));
            sb.AppendFormat("<tr><td class='label'>Usuario:</td><td class='value'>{0}</td></tr>", E(txtusuario.Text));
            sb.AppendFormat("<tr><td class='label'>Proveedor CUIT:</td><td class='value'>{0}</td></tr>", E(txtdocproveedor.Text));
            sb.AppendFormat("<tr><td class='label'>Razón social:</td><td class='value'>{0}</td></tr>", E(txtrazonsocialproveedor.Text));
            sb.Append("</table>");

            // Detalle
            sb.Append("<h2>Ítems</h2>");
            sb.Append("<table class='detalle'>");
            sb.Append("<thead><tr>");
            sb.Append("<th>Producto</th><th class='right'>Precio Compra</th><th class='right'>Cantidad</th><th class='right'>Sub Total</th>");
            sb.Append("</tr></thead><tbody>");

            decimal total = 0m;

            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                if (row.IsNewRow) continue;

                string prod = row.Cells["Producto"]?.Value?.ToString() ?? "";
                decimal precio = 0m, subtotal = 0m;
                int cantidad = 0;

                decimal.TryParse(Convert.ToString(row.Cells["PrecioCompra"]?.Value), out precio);
                int.TryParse(Convert.ToString(row.Cells["Cantidad"]?.Value), out cantidad);
                decimal.TryParse(Convert.ToString(row.Cells["SubTotal"]?.Value), out subtotal);

                if (subtotal == 0m) subtotal = precio * cantidad;
                total += subtotal;

                sb.Append("<tr>");
                sb.AppendFormat("<td>{0}</td>", E(prod));
                sb.AppendFormat("<td class='num'>{0}</td>", precio.ToString("N2"));
                sb.AppendFormat("<td class='num'>{0}</td>", cantidad);
                sb.AppendFormat("<td class='num'>{0}</td>", subtotal.ToString("N2"));
                sb.Append("</tr>");
            }

            sb.Append("</tbody></table>");

            // Totales
            decimal totalCaja;
            if (!decimal.TryParse(txttotal.Text, out totalCaja))
                totalCaja = total;

            sb.Append("<br/>");
            sb.Append("<table class='totals'>");
            sb.AppendFormat("<tr><td class='label'>Total:</td><td class='value right'>{0}</td></tr>", totalCaja.ToString("N2"));
            sb.Append("</table>");

            sb.Append("</body></html>");

            return sb.ToString();
        }

        /* =========================
           AUTOCOMPLETE — COMPRAS
           ========================= */

        // Normalizar tildes
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

        // Item sugerencia
        private sealed class ItemSugCompra
        {
            public int Id { get; }
            public string Numero { get; }
            public string Texto { get; }
            public ItemSugCompra(int id, string numero, string texto) { Id = id; Numero = numero; Texto = texto; }
            public override string ToString() => Texto;
        }

        private void txtbusqueda_TextChanged(object sender, EventArgs e)
        {
            string q = (txtbusqueda.Text ?? "").Trim();

            // posicionar debajo de txttipodocumento (según pediste)
            _lbSugsCompras.Left = txttipodocumento.Left;
            _lbSugsCompras.Top = txttipodocumento.Bottom + 2;
            _lbSugsCompras.Width = txttipodocumento.Width;

            if (q.Length == 0 || _comprasIndex.Count == 0)
            {
                _lbSugsCompras.Visible = false;
                return;
            }

            // Construimos la lista de sugerencias como ItemSugCompra
            List<ItemSugCompra> sugs = _comprasIndex
                .Where(c =>
                    ContainsLike(c.numerodocumento ?? "", q) ||
                    ContainsLike(c.tipodocumento ?? "", q) ||
                    ContainsLike(c.oproveedor?.razonsocial ?? "", q) ||
                    ContainsLike(c.oproveedor?.cuit ?? "", q)
                )
                .Take(10)
                .Select(c =>
                {
                    string textoProv = string.IsNullOrWhiteSpace(c.oproveedor?.razonsocial)
                                        ? (string.IsNullOrWhiteSpace(c.oproveedor?.cuit) ? "(Sin proveedor)" : c.oproveedor.cuit)
                                        : c.oproveedor.razonsocial;

                    string numero = c.numerodocumento ?? "";
                    string texto = $"{numero} — {c.tipodocumento} — {textoProv}";
                    return new ItemSugCompra(c.id, numero, texto);
                })
                .ToList();

            if (sugs.Count == 0)
            {
                _lbSugsCompras.Visible = false;
                return;
            }

            // Bind seguro (sin objetos anónimos)
            _lbSugsCompras.BeginUpdate();
            _lbSugsCompras.DataSource = null;   // reset
            _lbSugsCompras.Items.Clear();       // por si venías cargando a mano
            _lbSugsCompras.DataSource = sugs;   // 👈 ahora SelectedItem es ItemSugCompra
            _lbSugsCompras.EndUpdate();
            _lbSugsCompras.Visible = true;
        }

        private void txtbusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (!_lbSugsCompras.Visible) return;

            if (e.KeyCode == Keys.Down)
            {
                if (_lbSugsCompras.Items.Count > 0)
                {
                    _lbSugsCompras.SelectedIndex = 0;
                    _lbSugsCompras.Focus();
                }
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                _lbSugsCompras.Visible = false;
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (_lbSugsCompras.Items.Count > 0)
                {
                    _lbSugsCompras.SelectedIndex = 0;
                    ConfirmarSeleccionCompra();
                }
                e.Handled = true;
            }
        }

        private void _lbSugsCompras_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ConfirmarSeleccionCompra();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                _lbSugsCompras.Visible = false;
                txtbusqueda.Focus();
                e.Handled = true;
            }
        }

        private void _lbSugsCompras_Click(object sender, EventArgs e)
        {
            ConfirmarSeleccionCompra();
        }

        private void ConfirmarSeleccionCompra()
        {
            if (_lbSugsCompras.SelectedItem is ItemSugCompra it)
            {
                txtbusqueda.Text = it.Numero;
                _lbSugsCompras.Visible = false;
                CargarCompraPorNumero(it.Numero);
            }
        }
    }
}
