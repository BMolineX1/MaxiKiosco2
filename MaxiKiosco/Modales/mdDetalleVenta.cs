using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace MaxiKiosco.Modales
{
    public partial class mdDetalleVenta : Form
    {
        private readonly List<ReporteVentaDetalle> _detalle;
        public mdDetalleVenta(List<ReporteVentaDetalle> detalle)
        {
            InitializeComponent();
            _detalle = detalle ?? new List<ReporteVentaDetalle>();
        }

        private void mdDetalleVenta_Load(object sender, EventArgs e)
        {
            // Cabecera
            var cab = _detalle.FirstOrDefault();
            if (cab != null)
            {
                lblCabecera.Text =
                    $"Venta {cab.TipoDocumento} {cab.NumeroDocumento} — {cab.Fecha:dd/MM/yyyy HH:mm}\n" +
                    $"Cliente: {cab.ClienteNombre} (DNI: {cab.ClienteDni}) — IVA: {cab.ClienteCondicionIva}";
            }

            // Config DGV
            dgvDetalle.AutoGenerateColumns = false;
            dgvDetalle.Columns.Clear();

            dgvDetalle.Columns.Add(new DataGridViewTextBoxColumn { Name = "Codigo", HeaderText = "Código", DataPropertyName = "ProductoCodigo", Width = 100 });
            dgvDetalle.Columns.Add(new DataGridViewTextBoxColumn { Name = "Producto", HeaderText = "Producto", DataPropertyName = "ProductoNombre", Width = 220 });
            dgvDetalle.Columns.Add(new DataGridViewTextBoxColumn { Name = "Categoria", HeaderText = "Categoría", DataPropertyName = "Categoria", Width = 120 });
            dgvDetalle.Columns.Add(new DataGridViewTextBoxColumn { Name = "Cantidad", HeaderText = "Cant.", DataPropertyName = "Cantidad", Width = 60 });
            dgvDetalle.Columns.Add(new DataGridViewTextBoxColumn { Name = "Precio", HeaderText = "Precio", DataPropertyName = "PrecioUnitario", Width = 90 });
            dgvDetalle.Columns.Add(new DataGridViewTextBoxColumn { Name = "Subtotal", HeaderText = "Subtotal", DataPropertyName = "Subtotal", Width = 100 });

            dgvDetalle.DataSource = _detalle.Select(d => new
            {
                d.ProductoCodigo,
                d.ProductoNombre,
                d.Categoria,
                d.Cantidad,
                PrecioUnitario = d.PrecioUnitario.ToString("N2", CultureInfo.CurrentCulture),
                Subtotal = d.Subtotal.ToString("N2", CultureInfo.CurrentCulture)
            }).ToList();

            // Total
            var total = _detalle.Sum(x => x.Subtotal);
            lblTotal.Text = $"Total: {total.ToString("N2", CultureInfo.CurrentCulture)}";
        }
    }
}
