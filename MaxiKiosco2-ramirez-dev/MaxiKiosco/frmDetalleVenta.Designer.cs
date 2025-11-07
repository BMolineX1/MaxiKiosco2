namespace MaxiKiosco
{
    partial class frmDetalleVenta
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtbuscar = new TextBox();
            btnlimpiarbuscador = new FontAwesome.Sharp.IconButton();
            btnbuscar = new FontAwesome.Sharp.IconButton();
            groupBox1 = new GroupBox();
            textBox5 = new TextBox();
            label6 = new Label();
            txtapellidocliente = new TextBox();
            txtnombrecliente = new TextBox();
            label5 = new Label();
            label4 = new Label();
            txtnumerodocumentocliente = new TextBox();
            groupBox2 = new GroupBox();
            txtusuario = new TextBox();
            txttipodocumentoventa = new TextBox();
            txtfechaventa = new TextBox();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            dgvdata = new DataGridView();
            Producto = new DataGridViewTextBoxColumn();
            Precio = new DataGridViewTextBoxColumn();
            Cantidad = new DataGridViewTextBoxColumn();
            SubTotal = new DataGridViewTextBoxColumn();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            txtmontototal = new TextBox();
            txtmontopago = new TextBox();
            txtmontocambio = new TextBox();
            lbbusquedadetalleventa = new ListBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvdata).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = Color.White;
            label1.Location = new Point(398, 48);
            label1.Name = "label1";
            label1.Size = new Size(810, 654);
            label1.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.White;
            label2.Font = new Font("Segoe UI", 15F);
            label2.Location = new Point(452, 72);
            label2.Name = "label2";
            label2.Size = new Size(161, 35);
            label2.TabIndex = 1;
            label2.Text = "Detalle Venta";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.White;
            label3.Location = new Point(619, 83);
            label3.Name = "label3";
            label3.Size = new Size(148, 20);
            label3.TabIndex = 2;
            label3.Text = "Numero Documento:";
            // 
            // txtbuscar
            // 
            txtbuscar.Location = new Point(773, 84);
            txtbuscar.Name = "txtbuscar";
            txtbuscar.Size = new Size(231, 27);
            txtbuscar.TabIndex = 3;
            // 
            // btnlimpiarbuscador
            // 
            btnlimpiarbuscador.BackColor = Color.White;
            btnlimpiarbuscador.Cursor = Cursors.Hand;
            btnlimpiarbuscador.FlatAppearance.BorderColor = Color.Black;
            btnlimpiarbuscador.FlatStyle = FlatStyle.Flat;
            btnlimpiarbuscador.ForeColor = SystemColors.ActiveCaptionText;
            btnlimpiarbuscador.IconChar = FontAwesome.Sharp.IconChar.BroomBall;
            btnlimpiarbuscador.IconColor = Color.Black;
            btnlimpiarbuscador.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnlimpiarbuscador.IconSize = 16;
            btnlimpiarbuscador.Location = new Point(1096, 83);
            btnlimpiarbuscador.Name = "btnlimpiarbuscador";
            btnlimpiarbuscador.Size = new Size(92, 29);
            btnlimpiarbuscador.TabIndex = 68;
            btnlimpiarbuscador.Text = "Limpiar";
            btnlimpiarbuscador.TextAlign = ContentAlignment.MiddleRight;
            btnlimpiarbuscador.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnlimpiarbuscador.UseVisualStyleBackColor = false;
            btnlimpiarbuscador.Click += btnlimpiarbuscador_Click_1;
            // 
            // btnbuscar
            // 
            btnbuscar.BackColor = Color.White;
            btnbuscar.Cursor = Cursors.Hand;
            btnbuscar.FlatAppearance.BorderColor = Color.Black;
            btnbuscar.FlatStyle = FlatStyle.Flat;
            btnbuscar.ForeColor = SystemColors.ActiveCaptionText;
            btnbuscar.IconChar = FontAwesome.Sharp.IconChar.Search;
            btnbuscar.IconColor = Color.Black;
            btnbuscar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnbuscar.IconSize = 16;
            btnbuscar.Location = new Point(1010, 84);
            btnbuscar.Name = "btnbuscar";
            btnbuscar.Size = new Size(80, 29);
            btnbuscar.TabIndex = 67;
            btnbuscar.Text = "Buscar";
            btnbuscar.TextAlign = ContentAlignment.MiddleRight;
            btnbuscar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnbuscar.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.White;
            groupBox1.Controls.Add(textBox5);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(txtapellidocliente);
            groupBox1.Controls.Add(txtnombrecliente);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(txtnumerodocumentocliente);
            groupBox1.Location = new Point(452, 292);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(725, 125);
            groupBox1.TabIndex = 69;
            groupBox1.TabStop = false;
            groupBox1.Text = "Informacion Cliente";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(597, 17);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(61, 27);
            textBox5.TabIndex = 73;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(370, 39);
            label6.Name = "label6";
            label6.Size = new Size(69, 20);
            label6.TabIndex = 2;
            label6.Text = "Apellido:";
            // 
            // txtapellidocliente
            // 
            txtapellidocliente.Location = new Point(370, 72);
            txtapellidocliente.Name = "txtapellidocliente";
            txtapellidocliente.Size = new Size(146, 27);
            txtapellidocliente.TabIndex = 71;
            // 
            // txtnombrecliente
            // 
            txtnombrecliente.Location = new Point(184, 72);
            txtnombrecliente.Name = "txtnombrecliente";
            txtnombrecliente.Size = new Size(162, 27);
            txtnombrecliente.TabIndex = 72;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(184, 39);
            label5.Name = "label5";
            label5.Size = new Size(67, 20);
            label5.TabIndex = 1;
            label5.Text = "Nombre:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 39);
            label4.Name = "label4";
            label4.Size = new Size(140, 20);
            label4.TabIndex = 0;
            label4.Text = "Documento Cliente:";
            // 
            // txtnumerodocumentocliente
            // 
            txtnumerodocumentocliente.Location = new Point(6, 72);
            txtnumerodocumentocliente.Name = "txtnumerodocumentocliente";
            txtnumerodocumentocliente.Size = new Size(155, 27);
            txtnumerodocumentocliente.TabIndex = 70;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.White;
            groupBox2.Controls.Add(txtusuario);
            groupBox2.Controls.Add(txttipodocumentoventa);
            groupBox2.Controls.Add(txtfechaventa);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(label7);
            groupBox2.Location = new Point(452, 161);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(725, 125);
            groupBox2.TabIndex = 70;
            groupBox2.TabStop = false;
            groupBox2.Text = "Informacion Venta";
            // 
            // txtusuario
            // 
            txtusuario.Location = new Point(421, 68);
            txtusuario.Name = "txtusuario";
            txtusuario.Size = new Size(144, 27);
            txtusuario.TabIndex = 5;
            // 
            // txttipodocumentoventa
            // 
            txttipodocumentoventa.Location = new Point(207, 68);
            txttipodocumentoventa.Name = "txttipodocumentoventa";
            txttipodocumentoventa.Size = new Size(154, 27);
            txttipodocumentoventa.TabIndex = 4;
            // 
            // txtfechaventa
            // 
            txtfechaventa.Location = new Point(6, 68);
            txtfechaventa.Name = "txtfechaventa";
            txtfechaventa.Size = new Size(140, 27);
            txtfechaventa.TabIndex = 3;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(421, 36);
            label9.Name = "label9";
            label9.Size = new Size(62, 20);
            label9.TabIndex = 2;
            label9.Text = "Usuario:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(207, 36);
            label8.Name = "label8";
            label8.Size = new Size(124, 20);
            label8.TabIndex = 1;
            label8.Text = "Tipo Documento:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 36);
            label7.Name = "label7";
            label7.Size = new Size(50, 20);
            label7.TabIndex = 0;
            label7.Text = "Fecha:";
            // 
            // dgvdata
            // 
            dgvdata.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvdata.BackgroundColor = Color.White;
            dgvdata.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvdata.Columns.AddRange(new DataGridViewColumn[] { Producto, Precio, Cantidad, SubTotal });
            dgvdata.Location = new Point(452, 445);
            dgvdata.Name = "dgvdata";
            dgvdata.RowHeadersWidth = 51;
            dgvdata.Size = new Size(725, 210);
            dgvdata.TabIndex = 71;
            // 
            // Producto
            // 
            Producto.HeaderText = "Producto";
            Producto.MinimumWidth = 6;
            Producto.Name = "Producto";
            // 
            // Precio
            // 
            Precio.HeaderText = "Precio";
            Precio.MinimumWidth = 6;
            Precio.Name = "Precio";
            // 
            // Cantidad
            // 
            Cantidad.HeaderText = "Cantidad";
            Cantidad.MinimumWidth = 6;
            Cantidad.Name = "Cantidad";
            // 
            // SubTotal
            // 
            SubTotal.HeaderText = "Sub Total";
            SubTotal.MinimumWidth = 6;
            SubTotal.Name = "SubTotal";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.White;
            label10.Location = new Point(420, 668);
            label10.Name = "label10";
            label10.Size = new Size(90, 20);
            label10.TabIndex = 72;
            label10.Text = "Monto Total";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.White;
            label11.Location = new Point(690, 668);
            label11.Name = "label11";
            label11.Size = new Size(93, 20);
            label11.TabIndex = 73;
            label11.Text = "Monto Pago:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = Color.White;
            label12.Location = new Point(937, 665);
            label12.Name = "label12";
            label12.Size = new Size(109, 20);
            label12.TabIndex = 74;
            label12.Text = "Monto Cambio";
            // 
            // txtmontototal
            // 
            txtmontototal.Location = new Point(516, 665);
            txtmontototal.Name = "txtmontototal";
            txtmontototal.Size = new Size(125, 27);
            txtmontototal.TabIndex = 75;
            // 
            // txtmontopago
            // 
            txtmontopago.Location = new Point(789, 665);
            txtmontopago.Name = "txtmontopago";
            txtmontopago.Size = new Size(125, 27);
            txtmontopago.TabIndex = 76;
            // 
            // txtmontocambio
            // 
            txtmontocambio.Location = new Point(1052, 661);
            txtmontocambio.Name = "txtmontocambio";
            txtmontocambio.Size = new Size(125, 27);
            txtmontocambio.TabIndex = 77;
            // 
            // lbbusquedadetalleventa
            // 
            lbbusquedadetalleventa.FormattingEnabled = true;
            lbbusquedadetalleventa.Location = new Point(773, 113);
            lbbusquedadetalleventa.Name = "lbbusquedadetalleventa";
            lbbusquedadetalleventa.Size = new Size(231, 64);
            lbbusquedadetalleventa.TabIndex = 78;
            // 
            // frmDetalleVenta
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1366, 711);
            Controls.Add(lbbusquedadetalleventa);
            Controls.Add(txtmontocambio);
            Controls.Add(txtmontopago);
            Controls.Add(txtmontototal);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(dgvdata);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(btnlimpiarbuscador);
            Controls.Add(btnbuscar);
            Controls.Add(txtbuscar);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmDetalleVenta";
            Text = "frmDetalleVenta";
            Load += frmDetalleVenta_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvdata).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtbuscar;
        private FontAwesome.Sharp.IconButton btnlimpiarbuscador;
        private FontAwesome.Sharp.IconButton btnbuscar;
        private GroupBox groupBox1;
        private Label label5;
        private Label label4;
        private TextBox textBox5;
        private Label label6;
        private TextBox txtapellidocliente;
        private TextBox txtnombrecliente;
        private TextBox txtnumerodocumentocliente;
        private GroupBox groupBox2;
        private TextBox txtusuario;
        private TextBox txttipodocumentoventa;
        private TextBox txtfechaventa;
        private Label label9;
        private Label label8;
        private Label label7;
        private DataGridView dgvdata;
        private Label label10;
        private Label label11;
        private Label label12;
        private TextBox txtmontototal;
        private TextBox txtmontopago;
        private TextBox txtmontocambio;
        private DataGridViewTextBoxColumn Producto;
        private DataGridViewTextBoxColumn Precio;
        private DataGridViewTextBoxColumn Cantidad;
        private DataGridViewTextBoxColumn SubTotal;
        private ListBox lbbusquedadetalleventa;
    }
}