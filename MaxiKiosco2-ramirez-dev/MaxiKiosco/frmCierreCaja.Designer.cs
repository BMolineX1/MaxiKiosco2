namespace MaxiKiosco
{
    partial class frmCierreCaja
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
            gbDatosCierre = new GroupBox();
            lblDiferencia = new Label();
            lblTotalVentas = new Label();
            btnCerrarCaja = new Button();
            lblRetiros = new Label();
            txtObservaciones = new TextBox();
            lblVentasCtaCte = new Label();
            dtpFecha = new DateTimePicker();
            lblVentasTarjeta = new Label();
            txtSaldoReal = new TextBox();
            lblVentasEfectivos = new Label();
            lblobs = new Label();
            lblFecha = new Label();
            lblSaldoReal = new Label();
            gbDatosCierre.SuspendLayout();
            SuspendLayout();
            // 
            // gbDatosCierre
            // 
            gbDatosCierre.BackColor = Color.White;
            gbDatosCierre.Controls.Add(lblDiferencia);
            gbDatosCierre.Controls.Add(lblTotalVentas);
            gbDatosCierre.Controls.Add(btnCerrarCaja);
            gbDatosCierre.Controls.Add(lblRetiros);
            gbDatosCierre.Controls.Add(txtObservaciones);
            gbDatosCierre.Controls.Add(lblVentasCtaCte);
            gbDatosCierre.Controls.Add(dtpFecha);
            gbDatosCierre.Controls.Add(lblVentasTarjeta);
            gbDatosCierre.Controls.Add(txtSaldoReal);
            gbDatosCierre.Controls.Add(lblVentasEfectivos);
            gbDatosCierre.Controls.Add(lblobs);
            gbDatosCierre.Controls.Add(lblFecha);
            gbDatosCierre.Controls.Add(lblSaldoReal);
            gbDatosCierre.Location = new Point(350, 148);
            gbDatosCierre.Name = "gbDatosCierre";
            gbDatosCierre.Size = new Size(823, 262);
            gbDatosCierre.TabIndex = 0;
            gbDatosCierre.TabStop = false;
            gbDatosCierre.Text = "Cierre de Caja";
            // 
            // lblDiferencia
            // 
            lblDiferencia.AutoSize = true;
            lblDiferencia.Location = new Point(747, 192);
            lblDiferencia.Name = "lblDiferencia";
            lblDiferencia.Size = new Size(50, 20);
            lblDiferencia.TabIndex = 6;
            lblDiferencia.Text = "label6";
            // 
            // lblTotalVentas
            // 
            lblTotalVentas.AutoSize = true;
            lblTotalVentas.Location = new Point(598, 192);
            lblTotalVentas.Name = "lblTotalVentas";
            lblTotalVentas.Size = new Size(50, 20);
            lblTotalVentas.TabIndex = 5;
            lblTotalVentas.Text = "label5";
            // 
            // btnCerrarCaja
            // 
            btnCerrarCaja.Location = new Point(374, 106);
            btnCerrarCaja.Name = "btnCerrarCaja";
            btnCerrarCaja.Size = new Size(125, 45);
            btnCerrarCaja.TabIndex = 1;
            btnCerrarCaja.Text = "Cerrar Caja";
            btnCerrarCaja.UseVisualStyleBackColor = true;
            // 
            // lblRetiros
            // 
            lblRetiros.AutoSize = true;
            lblRetiros.Location = new Point(449, 192);
            lblRetiros.Name = "lblRetiros";
            lblRetiros.Size = new Size(50, 20);
            lblRetiros.TabIndex = 4;
            lblRetiros.Text = "label4";
            // 
            // txtObservaciones
            // 
            txtObservaciones.Location = new Point(630, 57);
            txtObservaciones.Name = "txtObservaciones";
            txtObservaciones.Size = new Size(125, 27);
            txtObservaciones.TabIndex = 2;
            // 
            // lblVentasCtaCte
            // 
            lblVentasCtaCte.AutoSize = true;
            lblVentasCtaCte.Location = new Point(308, 192);
            lblVentasCtaCte.Name = "lblVentasCtaCte";
            lblVentasCtaCte.Size = new Size(50, 20);
            lblVentasCtaCte.TabIndex = 3;
            lblVentasCtaCte.Text = "label3";
            // 
            // dtpFecha
            // 
            dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.Location = new Point(59, 57);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(178, 27);
            dtpFecha.TabIndex = 1;
            // 
            // lblVentasTarjeta
            // 
            lblVentasTarjeta.AutoSize = true;
            lblVentasTarjeta.Location = new Point(163, 192);
            lblVentasTarjeta.Name = "lblVentasTarjeta";
            lblVentasTarjeta.Size = new Size(50, 20);
            lblVentasTarjeta.TabIndex = 2;
            lblVentasTarjeta.Text = "label2";
            // 
            // txtSaldoReal
            // 
            txtSaldoReal.Location = new Point(374, 54);
            txtSaldoReal.Name = "txtSaldoReal";
            txtSaldoReal.Size = new Size(125, 27);
            txtSaldoReal.TabIndex = 1;
            // 
            // lblVentasEfectivos
            // 
            lblVentasEfectivos.AutoSize = true;
            lblVentasEfectivos.Location = new Point(6, 192);
            lblVentasEfectivos.Name = "lblVentasEfectivos";
            lblVentasEfectivos.Size = new Size(50, 20);
            lblVentasEfectivos.TabIndex = 1;
            lblVentasEfectivos.Text = "label1";
            // 
            // lblobs
            // 
            lblobs.AutoSize = true;
            lblobs.Location = new Point(519, 57);
            lblobs.Name = "lblobs";
            lblobs.Size = new Size(105, 20);
            lblobs.TabIndex = 3;
            lblobs.Text = "Observaciones";
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(6, 57);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(47, 20);
            lblFecha.TabIndex = 1;
            lblFecha.Text = "Fecha";
            // 
            // lblSaldoReal
            // 
            lblSaldoReal.AutoSize = true;
            lblSaldoReal.Location = new Point(260, 57);
            lblSaldoReal.Name = "lblSaldoReal";
            lblSaldoReal.Size = new Size(108, 20);
            lblSaldoReal.TabIndex = 2;
            lblSaldoReal.Text = "Saldo Contado";
            // 
            // frmCierreCaja
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1270, 540);
            Controls.Add(gbDatosCierre);
            Name = "frmCierreCaja";
            Text = "frmCierreCaja";
            Load += frmCierreCaja_Load;
            gbDatosCierre.ResumeLayout(false);
            gbDatosCierre.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gbDatosCierre;
        private TextBox txtObservaciones;
        private DateTimePicker dtpFecha;
        private TextBox txtSaldoReal;
        private Label lblobs;
        private Label lblFecha;
        private Label lblSaldoReal;
        private Label lblDiferencia;
        private Label lblTotalVentas;
        private Button btnCerrarCaja;
        private Label lblRetiros;
        private Label lblVentasCtaCte;
        private Label lblVentasTarjeta;
        private Label lblVentasEfectivos;
    }
}