using CapaDatos;
using CapaEntidad;
using CapaNegocio;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

// Alias para evitar ambigüedad con System.Drawing.Rectangle
using PdfRectangle = iTextSharp.text.Rectangle;

namespace MaxiKiosco
{
    public partial class frmDetalleVenta : Form
    {
        // ===== Índice para autocomplete =====
        private List<Venta> _ventasIndex = new List<Venta>();

        // Negocio / logo para PDF
        private Negocio _negocio;
        private System.Drawing.Image _logoImg;

        // Clase para items de sugerencia
        private sealed class ItemSugVenta
        {
            public int Id { get; }
            public string Numero { get; }
            public string Texto { get; }
            public ItemSugVenta(int id, string numero, string texto) { Id = id; Numero = numero; Texto = texto; }
            public override string ToString() => Texto; // fallback si no setean DisplayMember
        }

        public frmDetalleVenta()
        {
            InitializeComponent();

            // textbox buscar
            txtbuscar.TextChanged += txtbuscar_TextChanged;
            txtbuscar.KeyDown += txtbuscar_KeyDown;

            // listbox sugerencias (ya existe en diseñador)
            lbbusquedadetalleventa.Visible = false;
            lbbusquedadetalleventa.DisplayMember = "Texto";
            lbbusquedadetalleventa.Click += lbbusquedadetalleventa_Click;
            lbbusquedadetalleventa.KeyDown += lbbusquedadetalleventa_KeyDown;
        }

        private void frmDetalleVenta_Load(object sender, EventArgs e)
        {
            CargarDatosNegocio();
            TryCargarIndiceVentas();
        }

        private void CargarDatosNegocio()
        {
            _negocio = new CN_Negocio().ObtenerDatos();
            _logoImg = null; // si querés, podés leer el logo desde CN_Negocio().ObtenerLogo(...)
        }

        private void TryCargarIndiceVentas()
        {
            try
            {
                var cn = new CN_Venta();
                var lista = cn.ListarCabeceras(); // <-- requiere que exista en tus capas (ver sección 2)
                _ventasIndex = lista ?? new List<Venta>();
            }
            catch
            {
                _ventasIndex = new List<Venta>();
                lbbusquedadetalleventa.Visible = false;
            }
        }

        /* =========================
           AUTOCOMPLETE — Ventas
           ========================= */

        private static string Normalizar(string s)
        {
            if (string.IsNullOrEmpty(s)) return string.Empty;
            var norm = s.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();
            foreach (char ch in norm)
            {
                var cat = System.Globalization.CharUnicodeInfo.GetUnicodeCategory(ch);
                if (cat != System.Globalization.UnicodeCategory.NonSpacingMark) sb.Append(ch);
            }
            return sb.ToString().Normalize(NormalizationForm.FormC);
        }

        private static bool ContainsLike(string haystack, string needle)
        {
            return Normalizar(haystack).ToUpperInvariant()
                   .Contains(Normalizar(needle).ToUpperInvariant());
        }

        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {
            string q = (txtbuscar.Text ?? "").Trim();

            // posicionar el ListBox debajo del txtbuscar
            lbbusquedadetalleventa.Left = txtbuscar.Left;
            lbbusquedadetalleventa.Top = txtbuscar.Bottom + 2;
            lbbusquedadetalleventa.Width = txtbuscar.Width;

            if (q.Length == 0 || _ventasIndex.Count == 0)
            {
                lbbusquedadetalleventa.Visible = false;
                return;
            }

            // filtrar por NumeroDocumento, DNI, nombre, apellido
            List<ItemSugVenta> sugs = new List<ItemSugVenta>();

            foreach (var v in _ventasIndex)
            {
                var numero = v.NumeroDocumento ?? "";
                var dni = v.oCliente?.dni ?? "";
                var nombre = v.oCliente?.nombre ?? "";
                var apellido = v.oCliente?.apellido ?? "";
                var nomComp = $"{nombre} {apellido}".Trim();

                if (ContainsLike(numero, q) ||
                    ContainsLike(dni, q) ||
                    ContainsLike(nombre, q) ||
                    ContainsLike(apellido, q) ||
                    ContainsLike(nomComp, q))
                {
                    string textoCliente = string.IsNullOrWhiteSpace(nomComp)
                        ? (string.IsNullOrWhiteSpace(dni) ? "Consumidor Final" : dni)
                        : nomComp;

                    string texto = $"{numero} — {v.TipoDocumento} — {textoCliente}";
                    sugs.Add(new ItemSugVenta(v.VentaId, numero, texto));
                    if (sugs.Count >= 12) break; // límite razonable
                }
            }

            if (sugs.Count == 0)
            {
                lbbusquedadetalleventa.Visible = false;
                return;
            }

            lbbusquedadetalleventa.BeginUpdate();
            lbbusquedadetalleventa.DataSource = null;
            lbbusquedadetalleventa.Items.Clear();
            lbbusquedadetalleventa.DataSource = sugs; // SelectedItem será ItemSugVenta
            lbbusquedadetalleventa.EndUpdate();
            lbbusquedadetalleventa.Visible = true;
        }

        private void txtbuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (!lbbusquedadetalleventa.Visible) return;

            if (e.KeyCode == Keys.Down)
            {
                if (lbbusquedadetalleventa.Items.Count > 0)
                {
                    lbbusquedadetalleventa.SelectedIndex = 0;
                    lbbusquedadetalleventa.Focus();
                }
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (lbbusquedadetalleventa.Items.Count > 0)
                {
                    lbbusquedadetalleventa.SelectedIndex = 0;
                    ConfirmarSeleccionVenta();
                }
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                lbbusquedadetalleventa.Visible = false;
                e.Handled = true;
            }
        }

        private void lbbusquedadetalleventa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ConfirmarSeleccionVenta();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                lbbusquedadetalleventa.Visible = false;
                txtbuscar.Focus();
                e.Handled = true;
            }
        }

        private void lbbusquedadetalleventa_Click(object sender, EventArgs e)
        {
            ConfirmarSeleccionVenta();
        }

        private void ConfirmarSeleccionVenta()
        {
            if (lbbusquedadetalleventa.SelectedItem is ItemSugVenta it)
            {
                txtbuscar.Text = it.Numero;       // muestro el número elegido
                lbbusquedadetalleventa.Visible = false;
                CargarVentaPorNumero(it.Numero);  // cargo los datos
            }
        }

        /* =========================
           Carga de Venta / PDF
           ========================= */

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            CargarVentaPorNumero(txtbuscar.Text.Trim());
        }

        private void CargarVentaPorNumero(string numeroDocumento)
        {
            if (string.IsNullOrWhiteSpace(numeroDocumento))
            {
                LimpiarVista();
                return;
            }

            try
            {
                Venta oVenta = new CN_Venta().ObtenerVenta(numeroDocumento);
                if (oVenta != null && oVenta.VentaId != 0)
                {
                    // Cabecera
                    txttipodocumentoventa.Text = oVenta.TipoDocumento;
                    txtfechaventa.Text = oVenta.FechaRegistro?.ToString("dd/MM/yyyy HH:mm") ?? "";
                    txtusuario.Text = oVenta.oEmpleado?.nombre ?? "";

                    // Cliente
                    txtnumerodocumentocliente.Text = string.IsNullOrEmpty(oVenta.oCliente?.dni) ? "" : oVenta.oCliente.dni;
                    string nom = oVenta.oCliente?.nombre ?? "";
                    string ape = oVenta.oCliente?.apellido ?? "";
                    string nomComp = $"{nom} {ape}".Trim();
                    txtnombrecliente.Text = string.IsNullOrWhiteSpace(nomComp) ? "Consumidor Final" : nomComp;
                    txtapellidocliente.Text = ""; // ya va en nombre completo

                    // Detalle
                    dgvdata.Rows.Clear();
                    if (oVenta.oDetalle_Venta != null)
                    {
                        foreach (detalle_venta dv in oVenta.oDetalle_Venta)
                        {
                            int idProd = dv.oproducto?.Id ?? 0;
                            string desc = dv.oproducto?.nombre ?? "";
                            int cant = dv.cantidad;
                            decimal precio = dv.precio_unitario;
                            decimal sub = cant * precio;

                            dgvdata.Rows.Add(new object[]
                            {
                                idProd,      // id producto
                                desc,       // producto
                                cant,       // cantidad
                                precio,     // precio unitario
                                sub         // subtotal
                            });
                        }
                    }

                    // Totales
                    txtmontototal.Text = oVenta.MontoTotal.ToString("0.00");
                    txtmontopago.Text = oVenta.MontoPago.ToString("0.00");
                    txtmontocambio.Text = oVenta.MontoCambio.ToString("0.00");
                }
                else
                {
                    LimpiarVista();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar la venta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnlimpiarbuscador_Click(object sender, EventArgs e)
        {
            LimpiarVista();
        }

        private void LimpiarVista()
        {
            txtfechaventa.Text = "";
            txttipodocumentoventa.Text = "";
            txtusuario.Text = "";
            txtnumerodocumentocliente.Text = "";
            txtnombrecliente.Text = "";
            txtapellidocliente.Text = "";

            dgvdata.Rows.Clear();
            txtmontocambio.Text = "0.00";
            txtmontopago.Text = "0.00";
            txtmontototal.Text = "0.00";
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (dgvdata.Rows.Count == 0)
            {
                MessageBox.Show("No hay ítems para exportar.", "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (_negocio == null)
                CargarDatosNegocio();

            using (var sfd = new SaveFileDialog
            {
                Filter = "PDF (*.pdf)|*.pdf",
                FileName = $"Venta_{txtnumerodocumentocliente.Text}.pdf",
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
                        doc.Open();

                        // Fuentes
                        BaseColor textDark = new BaseColor(33, 37, 41);
                        iTextSharp.text.Font fLabel = FontFactory.GetFont(FontFactory.HELVETICA, 9.5f, textDark);
                        iTextSharp.text.Font fValue = FontFactory.GetFont(FontFactory.HELVETICA, 10f, textDark);

                        // Resumen (usar SIEMPRE PdfRectangle.NO_BORDER)
                        PdfPTable tableMeta = new PdfPTable(2) { WidthPercentage = 100f };
                        tableMeta.AddCell(new PdfPCell(new Phrase("Cliente:", fLabel)) { Border = PdfRectangle.NO_BORDER });
                        tableMeta.AddCell(new PdfPCell(new Phrase($"{txtnombrecliente.Text} {txtapellidocliente.Text}", fValue)) { Border = PdfRectangle.NO_BORDER });
                        tableMeta.AddCell(new PdfPCell(new Phrase("Documento:", fLabel)) { Border = PdfRectangle.NO_BORDER });
                        tableMeta.AddCell(new PdfPCell(new Phrase(txtnumerodocumentocliente.Text, fValue)) { Border = PdfRectangle.NO_BORDER });
                        tableMeta.AddCell(new PdfPCell(new Phrase("Tipo Doc:", fLabel)) { Border = PdfRectangle.NO_BORDER });
                        tableMeta.AddCell(new PdfPCell(new Phrase(txttipodocumentoventa.Text, fValue)) { Border = PdfRectangle.NO_BORDER });
                        tableMeta.AddCell(new PdfPCell(new Phrase("Fecha:", fLabel)) { Border = PdfRectangle.NO_BORDER });
                        tableMeta.AddCell(new PdfPCell(new Phrase(txtfechaventa.Text, fValue)) { Border = PdfRectangle.NO_BORDER });
                        tableMeta.AddCell(new PdfPCell(new Phrase("Usuario:", fLabel)) { Border = PdfRectangle.NO_BORDER });
                        tableMeta.AddCell(new PdfPCell(new Phrase(txtusuario.Text, fValue)) { Border = PdfRectangle.NO_BORDER });
                        doc.Add(tableMeta);

                        doc.Add(new Paragraph(" "));

                        // Detalle
                        PdfPTable tableDetalle = new PdfPTable(4) { WidthPercentage = 100f };
                        tableDetalle.SetWidths(new float[] { 50f, 15f, 15f, 20f });

                        tableDetalle.AddCell(new PdfPCell(new Phrase("Producto", fLabel)));
                        tableDetalle.AddCell(new PdfPCell(new Phrase("Cantidad", fLabel)) { HorizontalAlignment = Element.ALIGN_RIGHT });
                        tableDetalle.AddCell(new PdfPCell(new Phrase("Precio", fLabel)) { HorizontalAlignment = Element.ALIGN_RIGHT });
                        tableDetalle.AddCell(new PdfPCell(new Phrase("Subtotal", fLabel)) { HorizontalAlignment = Element.ALIGN_RIGHT });

                        decimal total = 0m;
                        foreach (DataGridViewRow row in dgvdata.Rows)
                        {
                            if (row.IsNewRow) continue;

                            string prod = row.Cells[1]?.Value?.ToString() ?? "";
                            int cantidad = Convert.ToInt32(row.Cells[2]?.Value ?? 0);
                            decimal precio = Convert.ToDecimal(row.Cells[3]?.Value ?? 0);
                            decimal subtotal = cantidad * precio;

                            total += subtotal;

                            tableDetalle.AddCell(new PdfPCell(new Phrase(prod, fValue)));
                            tableDetalle.AddCell(new PdfPCell(new Phrase(cantidad.ToString(), fValue)) { HorizontalAlignment = Element.ALIGN_RIGHT });
                            tableDetalle.AddCell(new PdfPCell(new Phrase(precio.ToString("N2"), fValue)) { HorizontalAlignment = Element.ALIGN_RIGHT });
                            tableDetalle.AddCell(new PdfPCell(new Phrase(subtotal.ToString("N2"), fValue)) { HorizontalAlignment = Element.ALIGN_RIGHT });
                        }

                        doc.Add(tableDetalle);

                        // Total
                        PdfPTable tableTotal = new PdfPTable(2) { WidthPercentage = 100f };
                        tableTotal.SetWidths(new float[] { 80f, 20f });
                        tableTotal.AddCell(new PdfPCell(new Phrase("Total:", fLabel)) { Border = PdfRectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_RIGHT });
                        tableTotal.AddCell(new PdfPCell(new Phrase(total.ToString("N2"), fValue)) { Border = PdfRectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_RIGHT });
                        doc.Add(tableTotal);

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

        private void btnlimpiarbuscador_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Limpia todos los campos y la grilla (ya lo tenés implementado)
                LimpiarVista();

                // Limpia el cuadro de búsqueda
                if (txtbuscar != null)
                    txtbuscar.Clear();

                // Oculta y resetea el ListBox de sugerencias
                if (lbbusquedadetalleventa != null)
                {
                    lbbusquedadetalleventa.Visible = false;
                    lbbusquedadetalleventa.DataSource = null;
                    lbbusquedadetalleventa.Items.Clear();
                }

                // Vuelve el foco al buscador
                if (txtbuscar != null && txtbuscar.CanFocus)
                    txtbuscar.Focus();
            }
            catch
            {
                // No arrojamos excepción al usuario; el método es "safe"
            }
        }
    }
}
