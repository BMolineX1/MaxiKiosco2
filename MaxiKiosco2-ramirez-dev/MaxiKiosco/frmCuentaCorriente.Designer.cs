namespace MaxiKiosco
{
    partial class frmCuentaCorriente
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            splitContainer1 = new SplitContainer();
            lstSugerencias = new ListBox();
            dgvClientes = new DataGridView();
            colCliId = new DataGridViewTextBoxColumn();
            colCliNombre = new DataGridViewTextBoxColumn();
            colCliSaldo = new DataGridViewTextBoxColumn();
            colCliLimite = new DataGridViewTextBoxColumn();
            colCliHabilitada = new DataGridViewTextBoxColumn();
            txtBuscarCliente = new TextBox();
            lblBuscarCliente = new Label();
            label1 = new Label();
            gbRegistrarPago = new GroupBox();
            txtPagoConcepto = new TextBox();
            txtPagoMonto = new TextBox();
            btnRegistrarPago = new Button();
            lblPagoConcepto = new Label();
            lblMontoPago = new Label();
            dgvMovimientos = new DataGridView();
            colMovFecha = new DataGridViewTextBoxColumn();
            colMovTipo = new DataGridViewTextBoxColumn();
            colMovConcepto = new DataGridViewTextBoxColumn();
            colMovVentas = new DataGridViewTextBoxColumn();
            colMovMonto = new DataGridViewTextBoxColumn();
            gbMovimientos = new GroupBox();
            btnFiltrar = new Button();
            dtpHasta = new DateTimePicker();
            lblHasta = new Label();
            dtpDesde = new DateTimePicker();
            lblDesde = new Label();
            gbEstado = new GroupBox();
            lblHabilitada = new Label();
            lblLimite = new Label();
            lblSaldo = new Label();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            gbRegistrarPago.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMovimientos).BeginInit();
            gbMovimientos.SuspendLayout();
            gbEstado.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(lstSugerencias);
            splitContainer1.Panel1.Controls.Add(dgvClientes);
            splitContainer1.Panel1.Controls.Add(txtBuscarCliente);
            splitContainer1.Panel1.Controls.Add(lblBuscarCliente);
            splitContainer1.Panel1.Controls.Add(label1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(gbRegistrarPago);
            splitContainer1.Panel2.Controls.Add(dgvMovimientos);
            splitContainer1.Panel2.Controls.Add(gbMovimientos);
            splitContainer1.Panel2.Controls.Add(gbEstado);
            splitContainer1.Size = new Size(1702, 641);
            splitContainer1.SplitterDistance = 567;
            splitContainer1.TabIndex = 0;
            // 
            // lstSugerencias
            // 
            lstSugerencias.FormattingEnabled = true;
            lstSugerencias.Location = new Point(135, 79);
            lstSugerencias.Name = "lstSugerencias";
            lstSugerencias.Size = new Size(196, 104);
            lstSugerencias.TabIndex = 3;
            // 
            // dgvClientes
            // 
            dgvClientes.AllowUserToAddRows = false;
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClientes.BackgroundColor = Color.White;
            dgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClientes.Columns.AddRange(new DataGridViewColumn[] { colCliId, colCliNombre, colCliSaldo, colCliLimite, colCliHabilitada });
            dgvClientes.GridColor = Color.White;
            dgvClientes.Location = new Point(12, 189);
            dgvClientes.Name = "dgvClientes";
            dgvClientes.ReadOnly = true;
            dgvClientes.RowHeadersVisible = false;
            dgvClientes.RowHeadersWidth = 51;
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClientes.Size = new Size(522, 424);
            dgvClientes.TabIndex = 2;
            // 
            // colCliId
            // 
            colCliId.HeaderText = "Id";
            colCliId.MinimumWidth = 6;
            colCliId.Name = "colCliId";
            colCliId.ReadOnly = true;
            colCliId.Visible = false;
            // 
            // colCliNombre
            // 
            colCliNombre.HeaderText = "Cliente";
            colCliNombre.MinimumWidth = 6;
            colCliNombre.Name = "colCliNombre";
            colCliNombre.ReadOnly = true;
            // 
            // colCliSaldo
            // 
            dataGridViewCellStyle1.Format = "N2";
            colCliSaldo.DefaultCellStyle = dataGridViewCellStyle1;
            colCliSaldo.HeaderText = "Saldo";
            colCliSaldo.MinimumWidth = 6;
            colCliSaldo.Name = "colCliSaldo";
            colCliSaldo.ReadOnly = true;
            // 
            // colCliLimite
            // 
            dataGridViewCellStyle2.Format = "N2";
            colCliLimite.DefaultCellStyle = dataGridViewCellStyle2;
            colCliLimite.HeaderText = "Limite";
            colCliLimite.MinimumWidth = 6;
            colCliLimite.Name = "colCliLimite";
            colCliLimite.ReadOnly = true;
            // 
            // colCliHabilitada
            // 
            colCliHabilitada.HeaderText = "Habilitada";
            colCliHabilitada.MinimumWidth = 6;
            colCliHabilitada.Name = "colCliHabilitada";
            colCliHabilitada.ReadOnly = true;
            // 
            // txtBuscarCliente
            // 
            txtBuscarCliente.Location = new Point(135, 53);
            txtBuscarCliente.Name = "txtBuscarCliente";
            txtBuscarCliente.Size = new Size(196, 27);
            txtBuscarCliente.TabIndex = 1;
            txtBuscarCliente.TextChanged += txtBuscarCliente_TextChanged_1;
            // 
            // lblBuscarCliente
            // 
            lblBuscarCliente.AutoSize = true;
            lblBuscarCliente.BackColor = Color.White;
            lblBuscarCliente.Location = new Point(144, 30);
            lblBuscarCliente.Name = "lblBuscarCliente";
            lblBuscarCliente.Size = new Size(102, 20);
            lblBuscarCliente.TabIndex = 0;
            lblBuscarCliente.Text = "Buscar Cliente";
            // 
            // label1
            // 
            label1.BackColor = Color.White;
            label1.Location = new Point(7, 18);
            label1.Name = "label1";
            label1.Size = new Size(548, 705);
            label1.TabIndex = 4;
            label1.Text = "label1";
            // 
            // gbRegistrarPago
            // 
            gbRegistrarPago.BackColor = Color.White;
            gbRegistrarPago.Controls.Add(txtPagoConcepto);
            gbRegistrarPago.Controls.Add(txtPagoMonto);
            gbRegistrarPago.Controls.Add(btnRegistrarPago);
            gbRegistrarPago.Controls.Add(lblPagoConcepto);
            gbRegistrarPago.Controls.Add(lblMontoPago);
            gbRegistrarPago.Location = new Point(915, 288);
            gbRegistrarPago.Name = "gbRegistrarPago";
            gbRegistrarPago.Size = new Size(187, 341);
            gbRegistrarPago.TabIndex = 3;
            gbRegistrarPago.TabStop = false;
            gbRegistrarPago.Text = "Registrar Pago";
            // 
            // txtPagoConcepto
            // 
            txtPagoConcepto.Location = new Point(29, 148);
            txtPagoConcepto.Name = "txtPagoConcepto";
            txtPagoConcepto.Size = new Size(125, 27);
            txtPagoConcepto.TabIndex = 4;
            // 
            // txtPagoMonto
            // 
            txtPagoMonto.Location = new Point(29, 86);
            txtPagoMonto.Name = "txtPagoMonto";
            txtPagoMonto.Size = new Size(125, 27);
            txtPagoMonto.TabIndex = 3;
            // 
            // btnRegistrarPago
            // 
            btnRegistrarPago.Location = new Point(16, 213);
            btnRegistrarPago.Name = "btnRegistrarPago";
            btnRegistrarPago.Size = new Size(159, 50);
            btnRegistrarPago.TabIndex = 2;
            btnRegistrarPago.Text = "Registrar Pago";
            btnRegistrarPago.UseVisualStyleBackColor = true;
            // 
            // lblPagoConcepto
            // 
            lblPagoConcepto.AutoSize = true;
            lblPagoConcepto.Location = new Point(29, 125);
            lblPagoConcepto.Name = "lblPagoConcepto";
            lblPagoConcepto.Size = new Size(73, 20);
            lblPagoConcepto.TabIndex = 1;
            lblPagoConcepto.Text = "Concepto";
            // 
            // lblMontoPago
            // 
            lblMontoPago.AutoSize = true;
            lblMontoPago.Location = new Point(29, 63);
            lblMontoPago.Name = "lblMontoPago";
            lblMontoPago.Size = new Size(53, 20);
            lblMontoPago.TabIndex = 0;
            lblMontoPago.Text = "Monto";
            // 
            // dgvMovimientos
            // 
            dgvMovimientos.AllowUserToAddRows = false;
            dgvMovimientos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMovimientos.BackgroundColor = Color.White;
            dgvMovimientos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMovimientos.Columns.AddRange(new DataGridViewColumn[] { colMovFecha, colMovTipo, colMovConcepto, colMovVentas, colMovMonto });
            dgvMovimientos.Location = new Point(15, 288);
            dgvMovimientos.Name = "dgvMovimientos";
            dgvMovimientos.ReadOnly = true;
            dgvMovimientos.RowHeadersVisible = false;
            dgvMovimientos.RowHeadersWidth = 51;
            dgvMovimientos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMovimientos.Size = new Size(875, 341);
            dgvMovimientos.TabIndex = 2;
            // 
            // colMovFecha
            // 
            colMovFecha.HeaderText = "Fecha/Hora";
            colMovFecha.MinimumWidth = 6;
            colMovFecha.Name = "colMovFecha";
            colMovFecha.ReadOnly = true;
            // 
            // colMovTipo
            // 
            colMovTipo.HeaderText = "Tipo";
            colMovTipo.MinimumWidth = 6;
            colMovTipo.Name = "colMovTipo";
            colMovTipo.ReadOnly = true;
            // 
            // colMovConcepto
            // 
            colMovConcepto.HeaderText = "Concepto";
            colMovConcepto.MinimumWidth = 6;
            colMovConcepto.Name = "colMovConcepto";
            colMovConcepto.ReadOnly = true;
            // 
            // colMovVentas
            // 
            colMovVentas.HeaderText = "Ventas";
            colMovVentas.MinimumWidth = 6;
            colMovVentas.Name = "colMovVentas";
            colMovVentas.ReadOnly = true;
            // 
            // colMovMonto
            // 
            dataGridViewCellStyle3.Format = "N2";
            colMovMonto.DefaultCellStyle = dataGridViewCellStyle3;
            colMovMonto.HeaderText = "Monto";
            colMovMonto.MinimumWidth = 6;
            colMovMonto.Name = "colMovMonto";
            colMovMonto.ReadOnly = true;
            // 
            // gbMovimientos
            // 
            gbMovimientos.BackColor = Color.White;
            gbMovimientos.Controls.Add(btnFiltrar);
            gbMovimientos.Controls.Add(dtpHasta);
            gbMovimientos.Controls.Add(lblHasta);
            gbMovimientos.Controls.Add(dtpDesde);
            gbMovimientos.Controls.Add(lblDesde);
            gbMovimientos.Location = new Point(463, 106);
            gbMovimientos.Name = "gbMovimientos";
            gbMovimientos.Size = new Size(427, 139);
            gbMovimientos.TabIndex = 1;
            gbMovimientos.TabStop = false;
            gbMovimientos.Text = "Movimientos";
            // 
            // btnFiltrar
            // 
            btnFiltrar.Location = new Point(197, 96);
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(94, 29);
            btnFiltrar.TabIndex = 2;
            btnFiltrar.Text = "Filtrar";
            btnFiltrar.UseVisualStyleBackColor = true;
            // 
            // dtpHasta
            // 
            dtpHasta.Format = DateTimePickerFormat.Short;
            dtpHasta.Location = new Point(288, 55);
            dtpHasta.Name = "dtpHasta";
            dtpHasta.Size = new Size(123, 27);
            dtpHasta.TabIndex = 3;
            // 
            // lblHasta
            // 
            lblHasta.AutoSize = true;
            lblHasta.Location = new Point(235, 57);
            lblHasta.Name = "lblHasta";
            lblHasta.Size = new Size(47, 20);
            lblHasta.TabIndex = 1;
            lblHasta.Text = "Hasta";
            // 
            // dtpDesde
            // 
            dtpDesde.Format = DateTimePickerFormat.Short;
            dtpDesde.Location = new Point(102, 55);
            dtpDesde.Name = "dtpDesde";
            dtpDesde.Size = new Size(123, 27);
            dtpDesde.TabIndex = 2;
            // 
            // lblDesde
            // 
            lblDesde.AutoSize = true;
            lblDesde.Location = new Point(45, 57);
            lblDesde.Name = "lblDesde";
            lblDesde.Size = new Size(51, 20);
            lblDesde.TabIndex = 0;
            lblDesde.Text = "Desde";
            // 
            // gbEstado
            // 
            gbEstado.BackColor = Color.White;
            gbEstado.Controls.Add(lblHabilitada);
            gbEstado.Controls.Add(lblLimite);
            gbEstado.Controls.Add(lblSaldo);
            gbEstado.Location = new Point(15, 106);
            gbEstado.Name = "gbEstado";
            gbEstado.Size = new Size(419, 139);
            gbEstado.TabIndex = 0;
            gbEstado.TabStop = false;
            gbEstado.Text = "Estado";
            // 
            // lblHabilitada
            // 
            lblHabilitada.AutoSize = true;
            lblHabilitada.Location = new Point(292, 59);
            lblHabilitada.Name = "lblHabilitada";
            lblHabilitada.Size = new Size(79, 20);
            lblHabilitada.TabIndex = 1;
            lblHabilitada.Text = "Habilitada";
            // 
            // lblLimite
            // 
            lblLimite.AutoSize = true;
            lblLimite.Location = new Point(174, 60);
            lblLimite.Name = "lblLimite";
            lblLimite.Size = new Size(50, 20);
            lblLimite.TabIndex = 1;
            lblLimite.Text = "Limite";
            // 
            // lblSaldo
            // 
            lblSaldo.AutoSize = true;
            lblSaldo.Location = new Point(53, 60);
            lblSaldo.Name = "lblSaldo";
            lblSaldo.Size = new Size(47, 20);
            lblSaldo.TabIndex = 0;
            lblSaldo.Text = "Saldo";
            // 
            // frmCuentaCorriente
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1702, 641);
            Controls.Add(splitContainer1);
            Name = "frmCuentaCorriente";
            Text = "frmCuentaCorriente";
            Load += frmCuentaCorriente_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            gbRegistrarPago.ResumeLayout(false);
            gbRegistrarPago.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMovimientos).EndInit();
            gbMovimientos.ResumeLayout(false);
            gbMovimientos.PerformLayout();
            gbEstado.ResumeLayout(false);
            gbEstado.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private TextBox txtBuscarCliente;
        private Label lblBuscarCliente;
        private DataGridView dgvClientes;
        private DateTimePicker dtpHasta;
        private GroupBox gbMovimientos;
        private Label lblHasta;
        private DateTimePicker dtpDesde;
        private Label lblDesde;
        private GroupBox gbEstado;
        private Label lblHabilitada;
        private Label lblLimite;
        private Label lblSaldo;
        private DataGridView dgvMovimientos;
        private Button btnFiltrar;
        private GroupBox gbRegistrarPago;
        private DataGridViewTextBoxColumn colMovFecha;
        private DataGridViewTextBoxColumn colMovTipo;
        private DataGridViewTextBoxColumn colMovConcepto;
        private DataGridViewTextBoxColumn colMovVentas;
        private DataGridViewTextBoxColumn colMovMonto;
        private TextBox txtPagoConcepto;
        private TextBox txtPagoMonto;
        private Button btnRegistrarPago;
        private Label lblPagoConcepto;
        private Label lblMontoPago;
        private ListBox lstSugerencias;
        private DataGridViewTextBoxColumn colCliId;
        private DataGridViewTextBoxColumn colCliNombre;
        private DataGridViewTextBoxColumn colCliSaldo;
        private DataGridViewTextBoxColumn colCliLimite;
        private DataGridViewTextBoxColumn colCliHabilitada;
        private Label label1;
    }
}