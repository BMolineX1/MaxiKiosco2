namespace MaxiKiosco
{
    partial class btnFiltrar
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
            lblmontoo = new Label();
            lblmotivo = new Label();
            lblreferencia = new Label();
            btnGuardar = new Button();
            txtMotivo = new TextBox();
            txtMonto = new TextBox();
            txtReferencia = new TextBox();
            lblhasta = new Label();
            groupBox1 = new GroupBox();
            Filtro = new GroupBox();
            btnFiltrarBuscar = new Button();
            dtpHasta = new DateTimePicker();
            lbldesde = new Label();
            dtpDesde = new DateTimePicker();
            dgvRetiros = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colFechaHora = new DataGridViewTextBoxColumn();
            colEmpleadoId = new DataGridViewTextBoxColumn();
            colMonto = new DataGridViewTextBoxColumn();
            colMotivo = new DataGridViewTextBoxColumn();
            colReferencia = new DataGridViewTextBoxColumn();
            groupBox1.SuspendLayout();
            Filtro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRetiros).BeginInit();
            SuspendLayout();
            // 
            // lblmontoo
            // 
            lblmontoo.AutoSize = true;
            lblmontoo.BackColor = Color.White;
            lblmontoo.Location = new Point(187, 66);
            lblmontoo.Name = "lblmontoo";
            lblmontoo.Size = new Size(53, 20);
            lblmontoo.TabIndex = 0;
            lblmontoo.Text = "Monto";
            // 
            // lblmotivo
            // 
            lblmotivo.AutoSize = true;
            lblmotivo.BackColor = Color.White;
            lblmotivo.Location = new Point(184, 25);
            lblmotivo.Name = "lblmotivo";
            lblmotivo.Size = new Size(56, 20);
            lblmotivo.TabIndex = 1;
            lblmotivo.Text = "Motivo";
            // 
            // lblreferencia
            // 
            lblreferencia.AutoSize = true;
            lblreferencia.BackColor = Color.White;
            lblreferencia.Location = new Point(161, 112);
            lblreferencia.Name = "lblreferencia";
            lblreferencia.Size = new Size(79, 20);
            lblreferencia.TabIndex = 2;
            lblreferencia.Text = "Referencia";
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(226, 163);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(149, 29);
            btnGuardar.TabIndex = 3;
            btnGuardar.Text = "Registrar Retiro";
            btnGuardar.UseVisualStyleBackColor = true;
            // 
            // txtMotivo
            // 
            txtMotivo.Location = new Point(258, 22);
            txtMotivo.Name = "txtMotivo";
            txtMotivo.Size = new Size(117, 27);
            txtMotivo.TabIndex = 4;
            // 
            // txtMonto
            // 
            txtMonto.Location = new Point(258, 66);
            txtMonto.Name = "txtMonto";
            txtMonto.Size = new Size(117, 27);
            txtMonto.TabIndex = 5;
            // 
            // txtReferencia
            // 
            txtReferencia.Location = new Point(258, 112);
            txtReferencia.Name = "txtReferencia";
            txtReferencia.Size = new Size(117, 27);
            txtReferencia.TabIndex = 6;
            // 
            // lblhasta
            // 
            lblhasta.AutoSize = true;
            lblhasta.Location = new Point(281, 69);
            lblhasta.Name = "lblhasta";
            lblhasta.Size = new Size(47, 20);
            lblhasta.TabIndex = 8;
            lblhasta.Text = "Hasta";
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.White;
            groupBox1.Controls.Add(txtMonto);
            groupBox1.Controls.Add(lblmontoo);
            groupBox1.Controls.Add(txtReferencia);
            groupBox1.Controls.Add(lblmotivo);
            groupBox1.Controls.Add(lblreferencia);
            groupBox1.Controls.Add(txtMotivo);
            groupBox1.Controls.Add(btnGuardar);
            groupBox1.Location = new Point(466, 33);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(566, 202);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            groupBox1.Text = "Retirar Dinero";
            // 
            // Filtro
            // 
            Filtro.BackColor = Color.White;
            Filtro.Controls.Add(btnFiltrarBuscar);
            Filtro.Controls.Add(dtpHasta);
            Filtro.Controls.Add(lbldesde);
            Filtro.Controls.Add(dtpDesde);
            Filtro.Controls.Add(lblhasta);
            Filtro.Location = new Point(466, 241);
            Filtro.Name = "Filtro";
            Filtro.Size = new Size(566, 186);
            Filtro.TabIndex = 10;
            Filtro.TabStop = false;
            Filtro.Text = "Filtro";
            // 
            // btnFiltrarBuscar
            // 
            btnFiltrarBuscar.Location = new Point(226, 124);
            btnFiltrarBuscar.Name = "btnFiltrarBuscar";
            btnFiltrarBuscar.Size = new Size(149, 41);
            btnFiltrarBuscar.TabIndex = 13;
            btnFiltrarBuscar.Text = "Filtrar";
            btnFiltrarBuscar.UseVisualStyleBackColor = true;
            // 
            // dtpHasta
            // 
            dtpHasta.Format = DateTimePickerFormat.Short;
            dtpHasta.Location = new Point(334, 69);
            dtpHasta.Name = "dtpHasta";
            dtpHasta.Size = new Size(143, 27);
            dtpHasta.TabIndex = 12;
            // 
            // lbldesde
            // 
            lbldesde.AutoSize = true;
            lbldesde.Location = new Point(75, 69);
            lbldesde.Name = "lbldesde";
            lbldesde.Size = new Size(51, 20);
            lbldesde.TabIndex = 11;
            lbldesde.Text = "Desde";
            // 
            // dtpDesde
            // 
            dtpDesde.Format = DateTimePickerFormat.Short;
            dtpDesde.Location = new Point(132, 69);
            dtpDesde.Name = "dtpDesde";
            dtpDesde.Size = new Size(143, 27);
            dtpDesde.TabIndex = 11;
            // 
            // dgvRetiros
            // 
            dgvRetiros.AllowUserToAddRows = false;
            dgvRetiros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRetiros.BackgroundColor = Color.White;
            dgvRetiros.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRetiros.Columns.AddRange(new DataGridViewColumn[] { colId, colFechaHora, colEmpleadoId, colMonto, colMotivo, colReferencia });
            dgvRetiros.Location = new Point(466, 433);
            dgvRetiros.MultiSelect = false;
            dgvRetiros.Name = "dgvRetiros";
            dgvRetiros.ReadOnly = true;
            dgvRetiros.RowHeadersWidth = 51;
            dgvRetiros.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRetiros.Size = new Size(566, 227);
            dgvRetiros.TabIndex = 11;
            // 
            // colId
            // 
            colId.HeaderText = "Id";
            colId.MinimumWidth = 6;
            colId.Name = "colId";
            colId.ReadOnly = true;
            colId.Visible = false;
            // 
            // colFechaHora
            // 
            colFechaHora.HeaderText = "Fecha/Hora";
            colFechaHora.MinimumWidth = 6;
            colFechaHora.Name = "colFechaHora";
            colFechaHora.ReadOnly = true;
            // 
            // colEmpleadoId
            // 
            colEmpleadoId.HeaderText = "Empleado";
            colEmpleadoId.MinimumWidth = 6;
            colEmpleadoId.Name = "colEmpleadoId";
            colEmpleadoId.ReadOnly = true;
            // 
            // colMonto
            // 
            colMonto.HeaderText = "Monto";
            colMonto.MinimumWidth = 6;
            colMonto.Name = "colMonto";
            colMonto.ReadOnly = true;
            // 
            // colMotivo
            // 
            colMotivo.HeaderText = "Motivo";
            colMotivo.MinimumWidth = 6;
            colMotivo.Name = "colMotivo";
            colMotivo.ReadOnly = true;
            // 
            // colReferencia
            // 
            colReferencia.HeaderText = "Referencia";
            colReferencia.MinimumWidth = 6;
            colReferencia.Name = "colReferencia";
            colReferencia.ReadOnly = true;
            // 
            // btnFiltrar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1290, 728);
            Controls.Add(dgvRetiros);
            Controls.Add(Filtro);
            Controls.Add(groupBox1);
            Name = "btnFiltrar";
            Text = "Monto";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            Filtro.ResumeLayout(false);
            Filtro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRetiros).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lblmontoo;
        private Label lblmotivo;
        private Label lblreferencia;
        private Button btnGuardar;
        private TextBox txtMotivo;
        private TextBox txtMonto;
        private TextBox txtReferencia;
        private Label lblhasta;
        private GroupBox groupBox1;
        private GroupBox Filtro;
        private Label lbldesde;
        private Button btnFiltrarBuscar;
        private DateTimePicker dtpHasta;
        private DateTimePicker dtpDesde;
        private DataGridView dgvRetiros;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colFechaHora;
        private DataGridViewTextBoxColumn colEmpleadoId;
        private DataGridViewTextBoxColumn colMonto;
        private DataGridViewTextBoxColumn colMotivo;
        private DataGridViewTextBoxColumn colReferencia;
    }
}