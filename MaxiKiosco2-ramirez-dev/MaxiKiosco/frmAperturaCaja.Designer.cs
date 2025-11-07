using System;
using System.Drawing;
using System.Windows.Forms;

namespace MaxiKiosco
{
    partial class frmAperturaCaja
    {
        private System.ComponentModel.IContainer components = null;

        private Label label1;
        private DateTimePicker dtpFecha;
        private Label label2;
        private TextBox txtMontoInicial;
        private Label label3;
        private TextBox txtObsApertura;
        private Button btnAbrirCaja;
        private Label lblEstadoApertura;
        private Label label4;
        private Label lblEstadoAperturas;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            label1 = new Label();
            dtpFecha = new DateTimePicker();
            label2 = new Label();
            txtMontoInicial = new TextBox();
            label3 = new Label();
            txtObsApertura = new TextBox();
            btnAbrirCaja = new Button();
            lblEstadoApertura = new Label();
            label4 = new Label();
            lblEstadoAperturas = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.White;
            label1.Location = new Point(587, 172);
            label1.Name = "label1";
            label1.Size = new Size(47, 20);
            label1.TabIndex = 9;
            label1.Text = "Fecha";
            // 
            // dtpFecha
            // 
            dtpFecha.CustomFormat = "dd/MM/yyyy";
            dtpFecha.Enabled = false;
            dtpFecha.Format = DateTimePickerFormat.Custom;
            dtpFecha.Location = new Point(587, 195);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(250, 27);
            dtpFecha.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.White;
            label2.Location = new Point(666, 311);
            label2.Name = "label2";
            label2.Size = new Size(96, 20);
            label2.TabIndex = 8;
            label2.Text = "Monto Inicial";
            // 
            // txtMontoInicial
            // 
            txtMontoInicial.Location = new Point(644, 334);
            txtMontoInicial.Name = "txtMontoInicial";
            txtMontoInicial.Size = new Size(145, 27);
            txtMontoInicial.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.White;
            label3.Location = new Point(587, 225);
            label3.Name = "label3";
            label3.Size = new Size(105, 20);
            label3.TabIndex = 7;
            label3.Text = "Observaciones";
            // 
            // txtObsApertura
            // 
            txtObsApertura.Location = new Point(587, 248);
            txtObsApertura.Multiline = true;
            txtObsApertura.Name = "txtObsApertura";
            txtObsApertura.Size = new Size(250, 60);
            txtObsApertura.TabIndex = 5;
            // 
            // btnAbrirCaja
            // 
            btnAbrirCaja.Location = new Point(644, 367);
            btnAbrirCaja.Name = "btnAbrirCaja";
            btnAbrirCaja.Size = new Size(145, 54);
            btnAbrirCaja.TabIndex = 6;
            btnAbrirCaja.Text = "Abrir Caja";
            btnAbrirCaja.UseVisualStyleBackColor = true;
            btnAbrirCaja.Click += btnAbrirCaja_Click;
            // 
            // lblEstadoApertura
            // 
            lblEstadoApertura.AutoSize = true;
            lblEstadoApertura.BackColor = Color.White;
            lblEstadoApertura.Location = new Point(963, 244);
            lblEstadoApertura.Name = "lblEstadoApertura";
            lblEstadoApertura.Size = new Size(0, 20);
            lblEstadoApertura.TabIndex = 1;
            // 
            // label4
            // 
            label4.BackColor = Color.White;
            label4.Location = new Point(326, 49);
            label4.Name = "label4";
            label4.Size = new Size(818, 468);
            label4.TabIndex = 8;
            // 
            // lblEstadoAperturas
            // 
            lblEstadoAperturas.AutoSize = true;
            lblEstadoAperturas.Location = new Point(900, 367);
            lblEstadoAperturas.Name = "lblEstadoAperturas";
            lblEstadoAperturas.Size = new Size(0, 20);
            lblEstadoAperturas.TabIndex = 0;
            // 
            // frmAperturaCaja
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1544, 768);
            Controls.Add(lblEstadoAperturas);
            Controls.Add(lblEstadoApertura);
            Controls.Add(btnAbrirCaja);
            Controls.Add(txtObsApertura);
            Controls.Add(label3);
            Controls.Add(txtMontoInicial);
            Controls.Add(label2);
            Controls.Add(dtpFecha);
            Controls.Add(label1);
            Controls.Add(label4);
            Name = "frmAperturaCaja";
            Text = "Apertura de Caja";
            Load += frmAperturaCaja_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
