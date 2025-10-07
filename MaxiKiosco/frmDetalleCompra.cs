using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing;              // GDI+
using System.Drawing.Imaging;      // ImageFormat
using CapaEntidad;
using CapaNegocio;

using iTextSharp.text;             // iText (Paragraph, FontFactory, etc.)
using iTextSharp.text.pdf;         // iText PDF (PdfWriter, PdfPCell, PdfPTable, etc.)
using iTextSharp.text.pdf.draw;    // LineSeparator
using iTextSharp.tool.xml;         // XMLWorker (ParseXHtml)

// ==== ALIAS para desambiguar tipos con el mismo nombre ====
using DrawingImage = System.Drawing.Image;            // imágenes GDI+ (logo)
using PdfImage = iTextSharp.text.Image;           // imágenes en iText
using PdfRectangle = iTextSharp.text.Rectangle;       // NO_BORDER, BOX, etc.
using PdfFont = iTextSharp.text.Font;            // fuentes iText

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

        public frmDetalleCompra()
        {
            InitializeComponent();
            this.Load += frmDetalleCompra_Load;
        }

        private void frmDetalleCompra_Load(object sender, EventArgs e)
        {
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

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            var numero = txtbusqueda.Text?.Trim();
            var cn = new CN_Compra();

            // Obtenemos cabecera
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

            // ---- Detalle (cargar filas manualmente en las 4 columnas)
            var detalle = cn.ObtenerDetalleCompra(compra.id, out _);

            dgvdata.Rows.Clear(); // limpiar filas anteriores

            // Índices por nombre (por si el orden difiere)
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

            // Total: si el SP lo trae (>0), uso ese. Si no, sumo lo calculado.
            var total = compra.montototal > 0 ? compra.montototal : totalCalculado;
            txttotal.Text = total.ToString("N2");
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

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (dgvdata.Rows.Count == 0)
            {
                MessageBox.Show("No hay ítems para exportar.", "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Refresh por si el form quedó abierto mucho tiempo
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

                        // Pie de página
                        writer.PageEvent = new BrandedFooter(_negocio?.nombre ?? "");

                        doc.Open();

                        // ======= PALETA Y FUENTES =======
                        BaseColor bgSoft = new BaseColor(245, 246, 248);   // gris muy suave
                        BaseColor borderCol = new BaseColor(210, 214, 220);   // borde sutil
                        BaseColor textDark = new BaseColor(33, 37, 41);      // texto principal
                        BaseColor textMuted = new BaseColor(108, 117, 125);   // texto secundario
                        BaseColor brand = new BaseColor(52, 120, 246);    // toque azul

                        PdfFont fTitle = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 13f, textDark);
                        PdfFont fName = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12f, textDark);
                        PdfFont fLabel = FontFactory.GetFont(FontFactory.HELVETICA, 9.5f, textMuted);
                        PdfFont fValue = FontFactory.GetFont(FontFactory.HELVETICA, 10f, textDark);

                        // ======= CABECERA “TARJETA” CON LOGO Y DATOS =======
                        var card = new PdfPTable(1) { WidthPercentage = 100f };
                        var cardCell = new PdfPCell
                        {
                            Border = PdfRectangle.BOX,
                            BorderColor = borderCol,
                            BackgroundColor = bgSoft,
                            Padding = 10f
                        };

                        // Cinta de color arriba (detalle)
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

                        // Layout interno: 2 cols (logo | datos)
                        var header = new PdfPTable(new float[] { 28f, 72f }) { WidthPercentage = 100f };

                        // Logo
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

                        // Datos
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

                        // Separador y espacio
                        var sep = new LineSeparator(0.5f, 100f, borderCol, Element.ALIGN_CENTER, -4f);
                        doc.Add(new Chunk(sep));
                        doc.Add(new Paragraph(" "));

                        // ======= TÍTULO =======
                        var titulo = new Paragraph("Detalle de Compra", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14f, textDark))
                        { Alignment = Element.ALIGN_CENTER, SpacingAfter = 8f };
                        doc.Add(titulo);

                        // ======= CHIP RESUMEN (Nro / Tipo / Fecha / Usuario / Proveedor) =======
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

                        // ======= DETALLE (HTML) =======
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

        // ===== HTML del detalle (igual que lo tenías, limpio y compatible con XMLWorker) =====
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
    }
}
