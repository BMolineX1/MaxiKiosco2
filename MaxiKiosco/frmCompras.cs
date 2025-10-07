using CapaDatos;
using CapaEntidad;
using CapaNegocio;
using MaxiKiosco.Modales;
using MaxiKiosco.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;        // Color
using System.Globalization;  // parseo decimales
using System.Linq;
using System.Text;
using System.Text.RegularExpressions; // regex doc
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaxiKiosco
{
    public partial class frmCompras : Form
    {
        private Usuario _Usuario;

        // Formato típico AR: 0001-00000001
        private static readonly Regex RxNumDocGuion = new Regex(@"^\d{4}-\d{8}$", RegexOptions.Compiled);

        public frmCompras(Usuario oUsuario = null)
        {
            _Usuario = oUsuario;
            InitializeComponent();
        }

        private void frmCompras_Load(object sender, EventArgs e)
        {
            cbotipodocumento.Items.Add(new OpcionCombo() { Valor = "Boleta", texto = "Boleta" });
            cbotipodocumento.Items.Add(new OpcionCombo() { Valor = "Factura", texto = "Factura" });
            cbotipodocumento.DisplayMember = "texto";
            cbotipodocumento.ValueMember = "Valor";
            cbotipodocumento.SelectedIndex = 0;

            txtfecha.Text = DateTime.Now.ToString("dd/MM/yyyy");

            txtidproducto.Text = "0";
            txtidproveedor.Text = "0";

            // Configuración segura de columnas del grid
            ConfigurarColumnasGridSeguras();
        }

        private void ConfigurarColumnasGridSeguras()
        {
            SetColDecimal("PrecioCompra");
            SetColDecimal("PrecioVenta");
            SetColInt("Cantidad");
            SetColDecimal("SubTotal");

            // Asegurá que la columna ID se llame exactamente "idproducto"
            if (dgvdata.Columns.Contains("idproducto"))
            {
                dgvdata.Columns["idproducto"].ValueType = typeof(int);
                dgvdata.Columns["idproducto"].Visible = false; // ocultala si querés
            }
        }

        private void SetColDecimal(string name)
        {
            if (dgvdata.Columns.Contains(name))
            {
                dgvdata.Columns[name].ValueType = typeof(decimal);
                dgvdata.Columns[name].DefaultCellStyle.Format = "N2";
                dgvdata.Columns[name].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }

        private void SetColInt(string name)
        {
            if (dgvdata.Columns.Contains(name))
            {
                dgvdata.Columns[name].ValueType = typeof(int);
                dgvdata.Columns[name].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }

        private void btnbuscarproveedor_Click(object sender, EventArgs e)
        {
            using (var modal = new mdProveedor())
            {
                var result = modal.ShowDialog();
                if (result == DialogResult.OK)
                {
                    txtidproveedor.Text = modal._Proveedor.id.ToString();
                    txtnombreproveedor.Text = modal._Proveedor.nombre.ToString();
                    txtrazonsocial.Text = modal._Proveedor.razonsocial.ToString();
                }
                else
                {
                    txtnombreproveedor.Select();
                }
            }
        }

        private void btnbuscarproducto_Click(object sender, EventArgs e)
        {
            using (var modal = new mdProducto())
            {
                var result = modal.ShowDialog();
                if (result == DialogResult.OK)
                {
                    txtidproducto.Text = modal._Producto.Id.ToString();
                    txtnombreproducto.Text = modal._Producto.nombre;
                    txtcodproducto.Text = modal._Producto.codigo;
                    txtpreciocompraproducto.Select();
                }
                else
                {
                    txtnombreproducto.Select();
                }
            }
        }

        private void txtcodproducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Producto oProducto = new CN_Producto().Listar().Where(p => p.codigo == txtcodproducto.Text && p.estado == true).FirstOrDefault();
                if (oProducto != null)
                {
                    txtcodproducto.BackColor = Color.Honeydew;
                    txtidproducto.Text = oProducto.Id.ToString();
                    txtnombreproducto.Text = oProducto.nombre;
                    txtpreciocompraproducto.Select();
                }
            }
            else
            {
                txtcodproducto.BackColor = Color.MistyRose;
                txtidproducto.Text = "0";
                txtnombreproducto.Text = "";
            }
        }

        private void btnagregarproducto_Click(object sender, EventArgs e)
        {
            decimal preciocompra = 0m;
            decimal precioventa = 0m;
            bool producto_existe = false;

            if (!int.TryParse(txtidproducto.Text, out int idProd) || idProd == 0)
            {
                MessageBox.Show("Debe seleccionar un producto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // precio compra
            if (!decimal.TryParse(txtpreciocompraproducto.Text, NumberStyles.Any, CultureInfo.CurrentCulture, out preciocompra) &&
                !decimal.TryParse(txtpreciocompraproducto.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out preciocompra))
            {
                MessageBox.Show("Precio Compra - Formato moneda incorrecta", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtpreciocompraproducto.Select();
                return;
            }

            // precio venta
            if (!decimal.TryParse(txtprecioventaproducto.Text, NumberStyles.Any, CultureInfo.CurrentCulture, out precioventa) &&
                !decimal.TryParse(txtprecioventaproducto.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out precioventa))
            {
                MessageBox.Show("Precio Venta - Formato moneda incorrecta", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtprecioventaproducto.Select();
                return;
            }

            // duplicado
            foreach (DataGridViewRow fila in dgvdata.Rows)
            {
                if (fila.IsNewRow) continue;
                var val = fila.Cells["idproducto"]?.Value?.ToString();
                if (val == txtidproducto.Text) { producto_existe = true; break; }
            }
            if (producto_existe) return;

            // cantidad y subtotal
            int cant = (int)txtcantidad.Value;
            decimal subtotal = cant * preciocompra;

            // cargar NUMÉRICOS (no strings formateados)
            dgvdata.Rows.Add(new object[]
            {
                txtidproducto.Text,   // idproducto  (Name de la columna)
                "Eliminar",           // btneliminar
                txtcodproducto.Text,  // Codigo (o como se llame esa col)
                preciocompra,         // PrecioCompra  (decimal)
                precioventa,          // PrecioVenta   (decimal)
                cant,                 // Cantidad      (int)
                subtotal              // SubTotal      (decimal)
            });

            calcularTotal();
            limpiarProducto();
            txtcodproducto.Select();
        }

        private void limpiarProducto()
        {
            txtidproducto.Text = "0";
            txtcodproducto.Text = "0";
            txtcodproducto.BackColor = Color.White;
            txtnombreproducto.Text = "";
            txtpreciocompraproducto.Text = "";
            txtprecioventaproducto.Text = "";
            txtcantidad.Value = 1;
        }

        private void calcularTotal()
        {
            decimal total = 0m;

            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                if (row.IsNewRow) continue;

                var val = row.Cells["SubTotal"]?.Value;

                decimal sub = 0m;
                if (val is decimal d) sub = d;
                else
                {
                    var s = val?.ToString() ?? "0";
                    if (!decimal.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out sub) &&
                        !decimal.TryParse(s, NumberStyles.Any, CultureInfo.CurrentCulture, out sub))
                    {
                        sub = 0m;
                    }
                }

                total += sub;
            }

            txttotalpagar.Text = total.ToString("0.00");
        }

        private void dgvdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvdata.Columns[e.ColumnIndex].Name == "btneliminar")
            {
                int indice = e.RowIndex;

                if (indice >= 0)
                {
                    dgvdata.Rows.RemoveAt(indice);
                    calcularTotal();
                }
            }
        }

        private void txtpreciocompraproducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar)) return;

            char ch = e.KeyChar;
            if (char.IsDigit(ch)) return;

            // permitir un separador (coma o punto) si aún no hay
            if ((ch == '.' || ch == ','))
            {
                var txt = txtpreciocompraproducto.Text;
                if (!txt.Contains('.') && !txt.Contains(',')) return;
            }

            e.Handled = true;
        }

        private void txtprecioventaproducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar)) return;

            char ch = e.KeyChar;
            if (char.IsDigit(ch)) return;

            if ((ch == '.' || ch == ','))
            {
                var txt = txtprecioventaproducto.Text;
                if (!txt.Contains('.') && !txt.Contains(',')) return;
            }

            e.Handled = true;
        }

        // ================== Registrar compra (SP con JSON_TABLE) ==================
        private void btnregistrarcompra_Click(object sender, EventArgs e)
        {
            // Validaciones básicas
            if (!int.TryParse(txtidproveedor.Text, out int proveedorId) || proveedorId <= 0)
            {
                MessageBox.Show("Debe seleccionar un proveedor", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            bool hayFilas = dgvdata.Rows.Cast<DataGridViewRow>().Any(r => !r.IsNewRow);
            if (!hayFilas)
            {
                MessageBox.Show("Debe ingresar productos en la compra", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // DataTable que espera la capa de datos / SP
            DataTable detalle = new DataTable();
            detalle.Columns.Add("producto_id", typeof(int));
            detalle.Columns.Add("preciocompra", typeof(decimal));
            detalle.Columns.Add("precioventa", typeof(decimal));
            detalle.Columns.Add("cantidad", typeof(int));

            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                if (row.IsNewRow) continue;

                var cellId = row.Cells["idproducto"]?.Value; // usamos idproducto
                if (cellId == null) continue;

                if (!int.TryParse(cellId.ToString(), out int productoId) || productoId <= 0) continue;

                decimal pc = ParseDecimalCell(row, "PrecioCompra");
                decimal pv = ParseDecimalCell(row, "PrecioVenta");
                int cant = ParseIntCell(row, "Cantidad");
                if (cant <= 0) continue;

                detalle.Rows.Add(productoId, pc, pv, cant);
            }

            if (detalle.Rows.Count == 0)
            {
                MessageBox.Show("El detalle de la compra no tiene filas válidas.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Tipo doc
            var oc = cbotipodocumento.SelectedItem as OpcionCombo;
            string tipoDoc = oc != null ? (oc.Valor?.ToString() ?? oc.texto ?? "").Trim() : (cbotipodocumento.Text ?? "").Trim();
            if (string.IsNullOrWhiteSpace(tipoDoc))
            {
                MessageBox.Show("Debe seleccionar el tipo de documento.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Número de documento: 0001-00000001 (PV fijo de ejemplo)
            int correlativo = new CN_Compra().ObtenerCorrelativo();
            string pvStr = "0001"; // reemplazar si usás PV dinámico
            string nroStr = correlativo.ToString("D8", CultureInfo.InvariantCulture);
            string numeroDocumento = $"{pvStr}-{nroStr}";

            if (!RxNumDocGuion.IsMatch(numeroDocumento))
            {
                MessageBox.Show("Número de documento con formato inválido.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Entidad Compra (minúsculas) + compat para evitar NRE
            var compra = new Compra
            {
                empleadoid = _Usuario != null ? _Usuario.idusuario : 0,
                proveedorid = proveedorId,
                tipodocumento = tipoDoc,
                numerodocumento = numeroDocumento,

                // compat con código viejo:
                ousuario = new Usuario { idusuario = (_Usuario?.idusuario ?? 0) },
                oproveedor = new Proveedor { id = proveedorId }
            };

            if (compra.empleadoid <= 0)
            {
                MessageBox.Show("Usuario no válido para registrar la compra.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Validación temprana (opcional): asegurar que los IDs existen
            var ids = detalle.AsEnumerable().Select(r => (int)r["producto_id"]).Distinct().ToList();
            var existentes = new CN_Producto().Listar().Select(p => p.Id).ToHashSet();
            var faltantes = ids.Where(id => !existentes.Contains(id)).ToList();
            if (faltantes.Count > 0)
            {
                MessageBox.Show("Producto inexistente: " + faltantes.First(), "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Llamada a negocio
            var cn = new CN_Compra();
            if (cn.Registrar(compra, detalle, out var errores, out string mensaje))
            {
                MessageBox.Show(mensaje?.Length > 0 ? mensaje : "Compra registrada correctamente.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // limpiar UI
                dgvdata.Rows.Clear();
                calcularTotal();
                limpiarProducto();
                txtcodproducto.Select();

                var result = MessageBox.Show("Número de compra:\n" + numeroDocumento + "\n\n¿Copiar al portapapeles?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                    Clipboard.SetText(numeroDocumento);
            }
            else
            {
                var extra = (errores != null && errores.Count > 0) ? "\n• " + string.Join("\n• ", errores) : "";
                MessageBox.Show((mensaje?.Length > 0 ? mensaje : "No se pudo registrar la compra.") + extra, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ----------------- Helpers de parseo -----------------
        private static decimal ParseDecimalCell(DataGridViewRow row, string column)
        {
            var val = row.Cells[column]?.Value;
            if (val is decimal d) return d;
            if (val is double db) return (decimal)db;
            var s = val?.ToString() ?? "0";
            if (decimal.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out d)) return d;
            if (decimal.TryParse(s, NumberStyles.Any, CultureInfo.CurrentCulture, out d)) return d;
            return 0m;
        }

        private static int ParseIntCell(DataGridViewRow row, string column)
        {
            var v = row.Cells[column]?.Value?.ToString() ?? "0";
            return int.TryParse(v, NumberStyles.Integer, CultureInfo.InvariantCulture, out var i)
                   || int.TryParse(v, NumberStyles.Integer, CultureInfo.CurrentCulture, out i)
                ? i : 0;
        }
    }
}
