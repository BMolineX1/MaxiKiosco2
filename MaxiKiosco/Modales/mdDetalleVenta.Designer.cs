namespace MaxiKiosco.Modales
{
    partial class mdDetalleVenta
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
            lblCabecera = new Label();
            dgvDetalle = new DataGridView();
            lblTotal = new Label();
            groupBox1 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)dgvDetalle).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // lblCabecera
            // 
            lblCabecera.AutoSize = true;
            lblCabecera.Location = new Point(97, 52);
            lblCabecera.Name = "lblCabecera";
            lblCabecera.Size = new Size(75, 20);
            lblCabecera.TabIndex = 0;
            lblCabecera.Text = "Productos";
            // 
            // dgvDetalle
            // 
            dgvDetalle.BackgroundColor = Color.White;
            dgvDetalle.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetalle.Location = new Point(97, 134);
            dgvDetalle.Name = "dgvDetalle";
            dgvDetalle.RowHeadersWidth = 51;
            dgvDetalle.Size = new Size(730, 283);
            dgvDetalle.TabIndex = 1;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.BackColor = Color.White;
            lblTotal.Location = new Point(97, 397);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(0, 20);
            lblTotal.TabIndex = 2;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.White;
            groupBox1.Controls.Add(lblTotal);
            groupBox1.Controls.Add(dgvDetalle);
            groupBox1.Controls.Add(lblCabecera);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(915, 522);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Detalle de la Venta";
            // 
            // mdDetalleVenta
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(931, 527);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "mdDetalleVenta";
            StartPosition = FormStartPosition.CenterParent;
            Text = "mdDetalleVenta";
            Load += mdDetalleVenta_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDetalle).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblCabecera;
        private DataGridView dgvDetalle;
        private Label lblTotal;
        private GroupBox groupBox1;
    }
}