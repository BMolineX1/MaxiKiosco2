using CapaNegocio;
using System;
using System.Data;
using System.Windows.Forms;
using System.Globalization;
using System.Collections.Generic;

namespace MaxiKiosco.Modales
{
    public partial class mdPagarProductosCC : Form
    {
        private readonly int _idCliente;
        private readonly int _idUsuario;
        private readonly CN_CuentaCorriente _ccNegocio;

        public mdPagarProductosCC(int idCliente, int idUsuario)
        {
            InitializeComponent();

            _idCliente = idCliente;
            _idUsuario = idUsuario;
            _ccNegocio = new CN_CuentaCorriente();

            // Si el Load y los Click ya están configurados en el diseñador,
            // NO los volvemos a enganchar acá.

            // this.Load += mdPagarProductosCC_Load;
            // btnConfirmar.Click += btnConfirmar_Click;
            // btnCancelar.Click += btnCancelar_Click;

            dgvPendientes.CellEndEdit += dgvPendientes_CellEndEdit;

            // 👉 Si ya configuraste esto en el diseñador, no pasa nada tenerlo acá también.
            //    Sólo hace que el Enter en txtMontoPagar dispare la selección automática.
            if (txtMontoPagar != null)
                txtMontoPagar.KeyDown += txtMontoPagar_KeyDown;
        }

        private void mdPagarProductosCC_Load(object sender, EventArgs e)
        {
            try
            {
                // 🔄 Revalúa automáticamente las deudas de este cliente a precios vigentes
                if (!_ccNegocio.RevaluarPendientes(_idCliente, _idUsuario, out string msgReval))
                {
                    // Si falla, avisamos pero dejamos seguir
                    MessageBox.Show("No se pudo revaluar la cuenta corriente:\n" + msgReval,
                        "Revaluación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al intentar revaluar la cuenta corriente:\n" + ex.Message,
                    "Revaluación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            CargarPendientes();
        }

        /// <summary>
        /// Carga en el DataGridView las deudas por producto (pendientes).
        /// </summary>
        private void CargarPendientes()
        {
            try
            {
                DataTable dt = _ccNegocio.ListarPendientesConPrecio(_idCliente);

                dgvPendientes.DataSource = null;
                dgvPendientes.Columns.Clear();
                dgvPendientes.AutoGenerateColumns = true;

                dgvPendientes.DataSource = dt;

                // Títulos amigables
                if (dgvPendientes.Columns["ProductoId"] != null)
                    dgvPendientes.Columns["ProductoId"].HeaderText = "Id";
                if (dgvPendientes.Columns["Codigo"] != null)
                    dgvPendientes.Columns["Codigo"].HeaderText = "Código";
                if (dgvPendientes.Columns["Nombre"] != null)
                    dgvPendientes.Columns["Nombre"].HeaderText = "Producto";
                if (dgvPendientes.Columns["Pendiente"] != null)
                    dgvPendientes.Columns["Pendiente"].HeaderText = "Cant. pend.";
                if (dgvPendientes.Columns["PrecioUnitario"] != null)
                    dgvPendientes.Columns["PrecioUnitario"].HeaderText = "Precio unit.";
                if (dgvPendientes.Columns["MontoPendiente"] != null)
                    dgvPendientes.Columns["MontoPendiente"].HeaderText = "Total pend.";
                if (dgvPendientes.Columns["Pagar"] != null)
                    dgvPendientes.Columns["Pagar"].HeaderText = "Cant. a pagar";
                if (dgvPendientes.Columns["SubTotal"] != null)
                    dgvPendientes.Columns["SubTotal"].HeaderText = "SubTotal";

                RecalcularTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos pendientes: " + ex.Message,
                    "Cuenta Corriente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Cuando el usuario edita la columna "Pagar", recalculamos el SubTotal de esa fila.
        /// </summary>
        private void dgvPendientes_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Sólo reaccionamos cuando se edita la columna "Pagar"
            if (dgvPendientes.Columns[e.ColumnIndex].Name != "Pagar")
                return;

            var row = dgvPendientes.Rows[e.RowIndex];

            decimal pagar = 0, pendiente = 0, precioUnit = 0;

            decimal.TryParse(Convert.ToString(row.Cells["Pagar"].Value), out pagar);
            decimal.TryParse(Convert.ToString(row.Cells["Pendiente"].Value), out pendiente);
            decimal.TryParse(Convert.ToString(row.Cells["PrecioUnitario"].Value), out precioUnit);

            // Normalizamos valores
            if (pagar < 0) pagar = 0;
            if (pagar > pendiente) pagar = pendiente;

            row.Cells["Pagar"].Value = pagar;

            decimal subtotal = pagar * precioUnit;
            row.Cells["SubTotal"].Value = subtotal;

            RecalcularTotal();
        }

        /// <summary>
        /// Recalcula:
        /// - Deuda total (suma de MontoPendiente)
        /// - Total a pagar (suma de SubTotal)
        /// y los muestra en los labels.
        /// </summary>
        private void RecalcularTotal()
        {
            decimal totalPagar = 0;
            decimal deudaTotal = 0;

            foreach (DataGridViewRow row in dgvPendientes.Rows)
            {
                if (row.IsNewRow) continue;

                // Deuda total (columna MontoPendiente)
                if (decimal.TryParse(Convert.ToString(row.Cells["MontoPendiente"].Value), out decimal deudaFila))
                    deudaTotal += deudaFila;

                // Total a pagar (columna SubTotal)
                if (decimal.TryParse(Convert.ToString(row.Cells["SubTotal"].Value), out decimal sub))
                    totalPagar += sub;
            }

            lblDeudaTotal.Text = $"Deuda total: $ {deudaTotal:N2}";
            lblTotal.Text = $"Total a pagar: $ {totalPagar:N2}";
        }

        // ======================================================
        //   NUEVO: selección automática por txtMontoPagar
        // ======================================================

        /// <summary>
        /// Dispara la selección automática al apretar ENTER en txtMontoPagar.
        /// </summary>
        private void txtMontoPagar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                AutoSeleccionarProductosPorMonto();
            }
        }

        /// <summary>
        /// Dado un monto objetivo (txtMontoPagar), busca la combinación de filas
        /// cuya suma de MontoPendiente se acerque lo más posible SIN PASARSE.
        /// Luego:
        ///   - Setea Pagar = Pendiente y SubTotal = MontoPendiente en las filas elegidas.
        ///   - Pone Pagar = 0 / SubTotal = 0 en el resto.
        /// </summary>
        private decimal AutoSeleccionarProductosPorMonto()
        {
            if (txtMontoPagar == null)
                return 0m;

            // 1) Parsear el monto que el cliente entrega
            if (!decimal.TryParse(
                    txtMontoPagar.Text.Replace(".", ","),
                    System.Globalization.NumberStyles.Any,
                    System.Globalization.CultureInfo.CurrentCulture,
                    out decimal objetivoOriginal))
            {
                MessageBox.Show("Monto a pagar inválido.", "Cuenta Corriente",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0m;
            }

            if (objetivoOriginal <= 0)
            {
                MessageBox.Show("El monto a pagar debe ser mayor a cero.", "Cuenta Corriente",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0m;
            }

            decimal restante = objetivoOriginal;
            decimal totalSeleccionado = 0m;
            decimal menorPrecioUnit = decimal.MaxValue;

            // 2) Primero limpiamos cualquier selección previa
            foreach (DataGridViewRow row in dgvPendientes.Rows)
            {
                if (row.IsNewRow) continue;

                if (row.Cells["Pagar"] != null)
                    row.Cells["Pagar"].Value = 0;
                if (row.Cells["SubTotal"] != null)
                    row.Cells["SubTotal"].Value = 0;
            }

            // 3) Recorremos las filas y vamos tomando UNIDADES sin pasarnos
            foreach (DataGridViewRow row in dgvPendientes.Rows)
            {
                if (row.IsNewRow) continue;

                if (!decimal.TryParse(Convert.ToString(row.Cells["Pendiente"].Value),
                                      System.Globalization.NumberStyles.Any,
                                      System.Globalization.CultureInfo.CurrentCulture,
                                      out decimal pendiente))
                    pendiente = 0;

                if (!decimal.TryParse(Convert.ToString(row.Cells["PrecioUnitario"].Value),
                                      System.Globalization.NumberStyles.Any,
                                      System.Globalization.CultureInfo.CurrentCulture,
                                      out decimal precioUnit))
                    precioUnit = 0;

                if (precioUnit <= 0 || pendiente <= 0)
                    continue;

                if (precioUnit < menorPrecioUnit)
                    menorPrecioUnit = precioUnit;

                // ¿Cuántas unidades de esta fila podemos pagar con lo que queda,
                // sin pasarnos del monto?
                int maxPorMonto = (int)(restante / precioUnit); // división entera
                if (maxPorMonto <= 0)
                    continue;

                int cantidadAPagar = (int)Math.Min(pendiente, maxPorMonto);
                if (cantidadAPagar <= 0)
                    continue;

                decimal subtotal = cantidadAPagar * precioUnit;

                // Seteamos en la grilla
                row.Cells["Pagar"].Value = cantidadAPagar;
                row.Cells["SubTotal"].Value = subtotal;

                totalSeleccionado += subtotal;
                restante -= subtotal;

                // Si ya no queda nada del monto, cortamos
                if (restante <= 0)
                    break;
            }

            // 4) Si no se pudo seleccionar nada, avisamos bien claro
            if (totalSeleccionado == 0m)
            {
                if (menorPrecioUnit == decimal.MaxValue)
                {
                    MessageBox.Show("No hay productos pendientes con precio válido.",
                        "Cuenta Corriente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (objetivoOriginal < menorPrecioUnit)
                {
                    MessageBox.Show(
                        $"El monto ingresado es menor que el precio del producto más barato ($ {menorPrecioUnit:N2}).",
                        "Cuenta Corriente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se pudieron seleccionar productos con el monto ingresado.",
                        "Cuenta Corriente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            RecalcularTotal();
            return totalSeleccionado;
        }


        /// <summary>
        /// Devuelve los índices de las filas cuya suma de montos
        /// se acerque lo más posible al objetivo SIN PASARSE.
        /// Implementación por fuerza bruta (2^n), válido para pocas filas.
        /// </summary>
        private List<int> ElegirMejorCombinacion(List<decimal> montos, decimal objetivo)
        {
            int n = montos.Count;
            List<int> mejor = new List<int>();
            decimal mejorSuma = 0m;

            int totalComb = 1 << n; // 2^n combinaciones

            for (int mask = 1; mask < totalComb; mask++)
            {
                decimal suma = 0m;
                List<int> indices = new List<int>();

                for (int i = 0; i < n; i++)
                {
                    if ((mask & (1 << i)) != 0)
                    {
                        suma += montos[i];
                        indices.Add(i);
                    }
                }

                if (suma > objetivo)
                    continue; // Nos pasamos, no sirve

                if (suma > mejorSuma)
                {
                    mejorSuma = suma;
                    mejor = indices;
                }
            }

            return mejor;
        }

        // ======================================================
        //   Confirmar pago
        // ======================================================

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            bool huboError = false;
            string errores = "";

            // Monto que el cliente entrega (opcional)
            decimal montoIngresado = 0m;
            bool tieneMontoIngresado = false;

            if (txtMontoPagar != null && !string.IsNullOrWhiteSpace(txtMontoPagar.Text))
            {
                tieneMontoIngresado = decimal.TryParse(
                    txtMontoPagar.Text.Replace(".", ","),
                    NumberStyles.Any,
                    CultureInfo.CurrentCulture,
                    out montoIngresado);
            }

            // Total real que se está pagando (sumando Pagar * PrecioUnitario)
            decimal totalPagado = 0m;

            foreach (DataGridViewRow row in dgvPendientes.Rows)
            {
                if (row.IsNewRow) continue;

                if (!decimal.TryParse(Convert.ToString(row.Cells["Pagar"].Value), out decimal pagarDec))
                    pagarDec = 0;

                if (pagarDec <= 0)
                    continue;

                int cantidad = (int)pagarDec; // unidades a pagar
                if (cantidad <= 0) continue;

                int productoId = Convert.ToInt32(row.Cells["ProductoId"].Value);

                // Leemos el precio unitario para saber cuánto se está pagando
                decimal precioUnit = 0m;
                decimal.TryParse(Convert.ToString(row.Cells["PrecioUnitario"].Value),
                                 NumberStyles.Any,
                                 CultureInfo.CurrentCulture,
                                 out precioUnit);

                decimal montoFila = cantidad * precioUnit;
                totalPagado += montoFila;

                string mensaje;
                bool ok = _ccNegocio.PagarProducto(
                    _idCliente,
                    productoId,
                    cantidad,
                    _idUsuario,
                    out mensaje
                );

                if (!ok)
                {
                    huboError = true;
                    errores += $"- Producto {row.Cells["Nombre"].Value}: {mensaje}\n";
                }
            }

            if (huboError)
            {
                MessageBox.Show("Se produjeron errores al registrar algunos pagos:\n\n" + errores,
                    "Cuenta Corriente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // Si tenemos un monto ingresado y un totalPagado, calculamos diferencia
                if (tieneMontoIngresado && montoIngresado > 0 && totalPagado > 0)
                {
                    if (montoIngresado < totalPagado)
                    {
                        // El profe pidió "sin sobrepasar", pero por si se dio este caso:
                        MessageBox.Show(
                            "Atención: el monto ingresado es menor al total que se está cancelando.\n" +
                            $"Monto ingresado: $ {montoIngresado:N2}\n" +
                            $"Total pagado: $ {totalPagado:N2}",
                            "Cuenta Corriente",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    }
                    else
                    {
                        decimal diferencia = montoIngresado - totalPagado;

                        if (diferencia > 0)
                        {
                            // Opción: saldo a favor o cambio
                            var resp = MessageBox.Show(
                                $"Total pagado: $ {totalPagado:N2}\n" +
                                $"Monto ingresado: $ {montoIngresado:N2}\n" +
                                $"Diferencia: $ {diferencia:N2}\n\n" +
                                "¿Registrar la diferencia como saldo a favor del cliente?\n" +
                                "Sí = saldo a favor, No = dar cambio.",
                                "Diferencia de pago",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question);

                            if (resp == DialogResult.Yes)
                            {
                                // 👉 Acá iría la lógica real de saldo a favor (si tenés SP o método en CN_CuentaCorriente).
                                // Ejemplo (comentado para no romper nada):
                                // string msgSaldo;
                                // _ccNegocio.RegistrarSaldoAFavor(_idCliente, diferencia, _idUsuario, out msgSaldo);

                                MessageBox.Show(
                                    $"Se dejará un saldo a favor de $ {diferencia:N2} para el cliente.",
                                    "Saldo a favor",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                            }
                            else
                            {
                                // Cambio
                                MessageBox.Show(
                                    $"Cambio a entregar: $ {diferencia:N2}",
                                    "Cambio",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                            }
                        }
                    }
                }

                MessageBox.Show("Pagos registrados correctamente.",
                    "Cuenta Corriente", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
