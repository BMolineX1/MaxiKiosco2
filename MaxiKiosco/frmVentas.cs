using CapaEntidad;
using CapaNegocio;
// using DocumentFormat.OpenXml.Drawing.Diagrams; // ❌ innecesario en WinForms
using MaxiKiosco.Modales;
using MaxiKiosco.Utilidades;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace MaxiKiosco
{
    public partial class frmVentas : Form
    {
        private Usuario _Usuario;

        public frmVentas(Usuario ousuario = null)
        {
            _Usuario = ousuario;
            InitializeComponent();
        }

        private void frmVentas_Load(object sender, EventArgs e)
        {
            // ✅ Combo tipo documento
            cbotipodocumento.Items.Add(new OpcionCombo { Valor = "Boleta", texto = "Boleta" });
            cbotipodocumento.Items.Add(new OpcionCombo { Valor = "Factura", texto = "Factura" });
            cbotipodocumento.DisplayMember = "Texto";
            cbotipodocumento.ValueMember = "Valor";
            cbotipodocumento.SelectedIndex = 0;

            txtfechaventa.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtidproducto.Text = "0";
            txtpagacon.Text = "";
            txtcambio.Text = "";
            txttotalpagar.Text = "0";

            // Formato visual (asegurate que existan esos Names)
            if (dgvdata.Columns.Contains("Precio"))
                dgvdata.Columns["Precio"].DefaultCellStyle.Format = "N2";
            if (dgvdata.Columns.Contains("SubTotal"))
                dgvdata.Columns["SubTotal"].DefaultCellStyle.Format = "N2";

            // Un solo handler
            dgvdata.CellContentClick -= dgvdata_CellContentClick;
            dgvdata.CellContentClick += dgvdata_CellContentClick;
        }

        private void btnbuscarproveedor_Click(object sender, EventArgs e)
        {
            using (var modal = new mdCliente())
            {
                var result = modal.ShowDialog();
                if (result == DialogResult.OK && modal.ClienteSeleccionado != null)
                {
                    txtnumerodocumentocliente.Text = modal.ClienteSeleccionado.dni.ToString();
                    txtnombrecliente.Text = modal.ClienteSeleccionado.nombre ?? "";
                    txtapellidocliente.Text = modal.ClienteSeleccionado.apellido ?? "";
                    txtcodproducto.Select();
                }
                else
                {
                    txtnumerodocumentocliente.Select();
                }
            }
        }

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
                    txtprecioproducto.Text = modal._Producto.precioventa.ToString("0.00");
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

            Producto oProducto = new CN_Producto()
                .Listar()
                .FirstOrDefault(p => p.codigo == codigo && p.estado);

            if (oProducto != null)
            {
                txtcodproducto.BackColor = Color.Honeydew;
                txtidproducto.Text = oProducto.Id.ToString();
                txtnombreproducto.Text = oProducto.nombre ?? "";
                txtprecioproducto.Text = oProducto.precioventa.ToString("0.00");
                txtstock.Text = CalcularStockVisual(oProducto.Id, oProducto.stock).ToString();
                txtprecioproducto.Select();
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
                MessageBox.Show("Debe seleccionar un producto", "Mensaje",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!TryParseDecimalFlexible(txtprecioproducto.Text, out decimal precio) || precio <= 0)
            {
                MessageBox.Show("Precio - Formato moneda incorrecta", "Mensaje",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtprecioproducto.Select();
                return;
            }

            // stock real del producto debe venir del texto actual (visual)
            int stockVisual = 0;
            int.TryParse(txtstock.Text, out stockVisual);

            int cantidad = (int)txtcantidad.Value;
            if (cantidad <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor a 0", "Mensaje",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            int enCarrito = CantidadEnCarrito(idProd);
            // si txtstock muestra "disponible" (stock_bd - enCarrito), entonces basta comparar:
            if (cantidad > stockVisual)
            {
                MessageBox.Show("La cantidad no puede ser mayor al stock disponible", "Mensaje",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // evita duplicados por idproducto
            bool existe = dgvdata.Rows.Cast<DataGridViewRow>()
                .Where(r => !r.IsNewRow)
                .Any(r => r.Cells["idproducto"].Value?.ToString() == txtidproducto.Text);

            if (existe)
            {
                MessageBox.Show("El producto ya está en el detalle", "Mensaje",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            decimal subtotal = cantidad * precio;

            dgvdata.Rows.Add(new object[]
            {
                txtidproducto.Text,     // idproducto  (Name "idproducto")
                "Eliminar",             // btneliminar (Name "btneliminar")
                txtnombreproducto.Text, // Producto    (Name "Producto")
                precio,                 // Precio      (Name "Precio")
                cantidad,               // Cantidad    (Name "Cantidad")
                subtotal                // SubTotal    (Name "SubTotal")
            });

            calcularTotal();

            // actualizar visual del stock del producto seleccionado:
            // necesitamos el stock BD original. Si no lo tenés a mano, podés recalcular
            // en base a stockVisual - cantidad agregada.
            txtstock.Text = Math.Max(0, stockVisual - cantidad).ToString();

            limpiarProductoBasico();
            txtcodproducto.Select();
        }

        // ÚNICO handler para eliminar fila
        private void dgvdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvdata.Columns[e.ColumnIndex].Name != "btneliminar") return;

            int index = e.RowIndex;
            if (index >= 0 && !dgvdata.Rows[index].IsNewRow)
            {
                // No tocar BD: sólo quitar de la UI
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
                var valor = fila.Cells["SubTotal"].Value;

                if (valor is decimal d) total += d;
                else if (valor is double db) total += (decimal)db;
                else if (valor is float f) total += (decimal)f;
                else if (valor is int i) total += i;
                else if (valor is string s &&
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
            // txtstock se recalcula al volver a seleccionar el producto
            txtcantidad.Value = 1;
        }

        private bool TryParseDecimalFlexible(string input, out decimal value)
        {
            return decimal.TryParse(input, NumberStyles.Any, CultureInfo.CurrentCulture, out value)
                || decimal.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out value);
        }

        private void txtprecioproducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar)) return;
            if (char.IsDigit(e.KeyChar)) return;

            if (e.KeyChar == '.' || e.KeyChar == ',')
            {
                var txt = txtprecioproducto.Text;
                if (!txt.Contains('.') && !txt.Contains(',')) return;
            }

            e.Handled = true;
        }

        private void txtpagacon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar)) return;
            if (char.IsDigit(e.KeyChar)) return;

            if (e.KeyChar == '.' || e.KeyChar == ',')
            {
                var txt = txtpagacon.Text;
                if (!txt.Contains('.') && !txt.Contains(',')) return;
            }

            e.Handled = true;
        }

        private void calcularcambio()
        {
            if (!TryParseDecimalFlexible(txttotalpagar.Text, out var total))
            {
                txtcambio.Text = "0,00";
                return;
            }
            if (!TryParseDecimalFlexible(txtpagacon.Text, out var pagaCon))
            {
                txtcambio.Text = "0,00";
                return;
            }

            txtcambio.Text = (pagaCon >= total ? pagaCon - total : 0m)
                .ToString("N2", CultureInfo.CurrentCulture);
        }

        private void txtpagacon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                calcularcambio();
            }
        }

        private void btnregistrarventa_Click(object sender, EventArgs e)
        {
            // Sesión de usuario válida
            if ((_Usuario?.idusuario ?? 0) <= 0)
            {
                MessageBox.Show("No hay sesión de usuario válida.", "Venta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Validaciones básicas de cliente (según tu lógica)
            if (string.IsNullOrWhiteSpace(txtnumerodocumentocliente.Text))
            {
                MessageBox.Show("Debe ingresar documento del cliente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtnombrecliente.Text))
            {
                MessageBox.Show("Debe ingresar el nombre del cliente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtapellidocliente.Text))
            {
                MessageBox.Show("Debe ingresar el apellido del cliente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Debe haber al menos una fila válida
            if (dgvdata.Rows.Cast<DataGridViewRow>().All(r => r.IsNewRow))
            {
                MessageBox.Show("Debe ingresar producto a la venta", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Pago
            if (!TryParseDecimalFlexible(txtpagacon.Text, out var pagaCon))
            {
                MessageBox.Show("Ingrese el monto con el que paga el cliente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (!TryParseDecimalFlexible(txttotalpagar.Text, out var totalPagar))
            {
                MessageBox.Show("Total a pagar inválido", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (pagaCon < totalPagar)
            {
                MessageBox.Show("El monto de pago es insuficiente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Armar DataTable: producto_id, cantidad, precio_unitario
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
                MessageBox.Show("No hay ítems válidos para registrar.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Entidad Venta alineada al SP
            var venta = new Venta
            {
                EmpleadoId = _Usuario.idusuario,
                TipoDocumento = (cbotipodocumento.SelectedItem as OpcionCombo)?.Valor?.ToString() ?? "Boleta",
                NumeroDocumento = new CN_Venta().GenerarNumeroDocumento("0001"),
                NombreCliente = $"{txtnombrecliente.Text} {txtapellidocliente.Text}".Trim(),
                MontoPago = pagaCon
            };

            // Registrar
            string mensaje;
            bool okRegistrar = new CN_Venta().Registrar(venta, detalle, out mensaje);

            if (okRegistrar)
            {
                MessageBox.Show("Venta registrada correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // limpiar grilla y totales
                dgvdata.Rows.Clear();
                txttotalpagar.Text = "0,00";
                txtpagacon.Text = "";
                txtcambio.Text = "0,00";
                txtnumerodocumentocliente.Text = "";
                txtnombrecliente.Text = "";
                txtapellidocliente.Text = "";
            }
            else
            {
                MessageBox.Show("No se pudo registrar la venta: " + (mensaje ?? ""), "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ======== Helpers de stock visual ========

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
    }
}
