using System.Drawing;
using System.Windows.Forms;

namespace MaxiKiosco
{
    partial class frmCajasMaestroDetalle
    {
        private System.ComponentModel.IContainer components = null;

        private DateTimePicker dtpDesde;
        private DateTimePicker dtpHasta;
        private TextBox txtEmpleadoId;
        private Button btnBuscar;

        private SplitContainer split;
        private DataGridView dgvAperturas;

        private TabControl tabs;
        private TabPage tabResumen;
        private TabPage tabVentas;
        private TabPage tabRetiros;
        private TabPage tabCierre;

        private Label lblInicial;
        private Label lblEfectivo;
        private Label lblTarjeta;
        private Label lblCtaCte;
        private Label lblRetiros;
        private Label lblTotal;
        private Label lblEsperado;
        private Label lblSaldoReal;
        private Label lblDiferencia;

        private DataGridView dgvVentas;
        private DataGridView dgvRetiros;

        private TextBox txtSaldoReal;
        private TextBox txtObsCierre;
        private Button btnCerrarCaja;
        private Label lblEstadoApertura;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            // Filtros superiores
            dtpDesde = new DateTimePicker();
            dtpHasta = new DateTimePicker();
            txtEmpleadoId = new TextBox();
            btnBuscar = new Button();

            // Layout maestro/detalle
            split = new SplitContainer();
            dgvAperturas = new DataGridView();

            // Tabs detalle
            tabs = new TabControl();
            tabResumen = new TabPage("Resumen");
            tabVentas = new TabPage("Ventas");
            tabRetiros = new TabPage("Retiros");
            tabCierre = new TabPage("Cierre");

            // Labels de resumen
            lblInicial = new Label();
            lblEfectivo = new Label();
            lblTarjeta = new Label();
            lblCtaCte = new Label();
            lblRetiros = new Label();
            lblTotal = new Label();
            lblEsperado = new Label();
            lblSaldoReal = new Label();
            lblDiferencia = new Label();

            // Grids
            dgvVentas = new DataGridView();
            dgvRetiros = new DataGridView();

            // Cierre
            txtSaldoReal = new TextBox();
            txtObsCierre = new TextBox();
            btnCerrarCaja = new Button();
            lblEstadoApertura = new Label();

            // -------- Form base --------
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Text = "Cajas: Aperturas y Cierres";
            this.StartPosition = FormStartPosition.CenterScreen;

            // -------- Filtros top --------
            dtpDesde.CustomFormat = "dd/MM/yyyy";
            dtpDesde.Format = DateTimePickerFormat.Custom;
            dtpDesde.Location = new System.Drawing.Point(12, 12);
            dtpDesde.Size = new System.Drawing.Size(120, 23);

            dtpHasta.CustomFormat = "dd/MM/yyyy";
            dtpHasta.Format = DateTimePickerFormat.Custom;
            dtpHasta.Location = new System.Drawing.Point(138, 12);
            dtpHasta.Size = new System.Drawing.Size(120, 23);

            txtEmpleadoId.Location = new System.Drawing.Point(264, 12);
            txtEmpleadoId.Size = new System.Drawing.Size(160, 23);
            txtEmpleadoId.PlaceholderText = "EmpleadoId (opcional)";

            btnBuscar.Location = new System.Drawing.Point(430, 12);
            btnBuscar.Size = new System.Drawing.Size(90, 23);
            btnBuscar.Text = "Buscar";

            // -------- Split --------
            split.Location = new System.Drawing.Point(0, 45);
            split.Size = new System.Drawing.Size(1200, 655);
            split.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            split.SplitterDistance = 420;
            split.BorderStyle = BorderStyle.FixedSingle;

            // Left: dgvAperturas
            dgvAperturas.Dock = DockStyle.Fill;
            dgvAperturas.ReadOnly = true;
            dgvAperturas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAperturas.MultiSelect = false;
            dgvAperturas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAperturas.RowHeadersVisible = false;
            dgvAperturas.AllowUserToAddRows = false;
            dgvAperturas.AllowUserToDeleteRows = false;

            split.Panel1.Controls.Add(dgvAperturas);

            // Right: tabs
            tabs.Dock = DockStyle.Fill;
            tabs.TabPages.AddRange(new[] { tabResumen, tabVentas, tabRetiros, tabCierre });
            split.Panel2.Controls.Add(tabs);

            // -------- Resumen --------
            var panelResumen = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 9,
                Padding = new Padding(12),
                AutoSize = true
            };
            panelResumen.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45));
            panelResumen.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55));
            for (int i = 0; i < 9; i++)
                panelResumen.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            void AddRow(string title, Label valueLabel)
            {
                var lt = new Label
                {
                    Text = title,
                    AutoSize = true,
                    Padding = new Padding(0, 6, 0, 6)
                };
                valueLabel.Text = "-";
                valueLabel.AutoSize = true;
                valueLabel.Font = new Font(SystemFonts.DefaultFont, FontStyle.Bold);
                valueLabel.Padding = new Padding(0, 6, 0, 6);

                panelResumen.Controls.Add(lt);
                panelResumen.Controls.Add(valueLabel);
            }

            AddRow("Monto inicial:", lblInicial);
            AddRow("Ventas efectivo:", lblEfectivo);
            AddRow("Ventas tarjeta:", lblTarjeta);
            AddRow("Ventas ctacte:", lblCtaCte);
            AddRow("Retiros:", lblRetiros);
            AddRow("Total ventas:", lblTotal);
            AddRow("Esperado:", lblEsperado);
            AddRow("Saldo real:", lblSaldoReal);
            AddRow("Diferencia:", lblDiferencia);

            tabResumen.Controls.Add(panelResumen);

            // -------- Ventas --------
            dgvVentas.Dock = DockStyle.Fill;
            dgvVentas.ReadOnly = true;
            dgvVentas.RowHeadersVisible = false;
            dgvVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            tabVentas.Controls.Add(dgvVentas);

            // -------- Retiros --------
            dgvRetiros.Dock = DockStyle.Fill;
            dgvRetiros.ReadOnly = true;
            dgvRetiros.RowHeadersVisible = false;
            dgvRetiros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            tabRetiros.Controls.Add(dgvRetiros);

            // -------- Cierre --------
            var pnlCierre = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                Padding = new Padding(12),
                ColumnCount = 2,
                RowCount = 4,
                AutoSize = true
            };
            pnlCierre.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 160));
            pnlCierre.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

            var lblEstadoTitle = new Label { Text = "Estado:", AutoSize = true, Padding = new Padding(0, 6, 0, 6) };
            lblEstadoApertura.Text = "Estado: -";
            lblEstadoApertura.AutoSize = true;
            lblEstadoApertura.Padding = new Padding(0, 6, 0, 6);

            var lblSaldoTitle = new Label { Text = "Saldo real:", AutoSize = true, Padding = new Padding(0, 6, 0, 6) };
            txtSaldoReal.PlaceholderText = "Saldo contado";

            var lblObsTitle = new Label { Text = "Observaciones:", AutoSize = true, Padding = new Padding(0, 6, 0, 6) };
            txtObsCierre.Multiline = true;
            txtObsCierre.Height = 70;
            txtObsCierre.ScrollBars = ScrollBars.Vertical;

            btnCerrarCaja.Text = "Cerrar caja";
            btnCerrarCaja.AutoSize = true;

            pnlCierre.Controls.Add(lblEstadoTitle, 0, 0);
            pnlCierre.Controls.Add(lblEstadoApertura, 1, 0);
            pnlCierre.Controls.Add(lblSaldoTitle, 0, 1);
            pnlCierre.Controls.Add(txtSaldoReal, 1, 1);
            pnlCierre.Controls.Add(lblObsTitle, 0, 2);
            pnlCierre.Controls.Add(txtObsCierre, 1, 2);
            pnlCierre.Controls.Add(btnCerrarCaja, 1, 3);

            tabCierre.Controls.Add(pnlCierre);

            // -------- Agregar controles al Form --------
            this.Controls.Add(split);
            this.Controls.Add(btnBuscar);
            this.Controls.Add(txtEmpleadoId);
            this.Controls.Add(dtpHasta);
            this.Controls.Add(dtpDesde);
        }
    }
}
