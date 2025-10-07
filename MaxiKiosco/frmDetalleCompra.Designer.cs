namespace MaxiKiosco
{
    partial class frmDetalleCompra
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
            txtbusqueda = new TextBox();
            label3 = new Label();
            btnbuscar = new FontAwesome.Sharp.IconButton();
            btnlimpiar = new FontAwesome.Sharp.IconButton();
            groupBox1 = new GroupBox();
            txtusuario = new TextBox();
            txttipodocumento = new TextBox();
            txtfecha = new TextBox();
            label6 = new Label();
            label4 = new Label();
            label5 = new Label();
            groupBox2 = new GroupBox();
            txtnumerodocumento = new TextBox();
            txtrazonsocialproveedor = new TextBox();
            txtdocproveedor = new TextBox();
            label8 = new Label();
            label7 = new Label();
            dgvdata = new DataGridView();
            Producto = new DataGridViewTextBoxColumn();
            PrecioCompra = new DataGridViewTextBoxColumn();
            Cantidad = new DataGridViewTextBoxColumn();
            SubTotal = new DataGridViewTextBoxColumn();
            label9 = new Label();
            txttotal = new TextBox();
            btnExportar = new FontAwesome.Sharp.IconButton();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvdata).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = Color.White;
            label1.Location = new Point(420, 21);
            label1.Name = "label1";
            label1.Size = new Size(876, 706);
            label1.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.White;
            label2.Location = new Point(438, 27);
            label2.Name = "label2";
            label2.Size = new Size(114, 20);
            label2.TabIndex = 1;
            label2.Text = "Detalle Compra";
            // 
            // txtbusqueda
            // 
            txtbusqueda.BackColor = Color.White;
            txtbusqueda.Location = new Point(763, 58);
            txtbusqueda.Name = "txtbusqueda";
            txtbusqueda.Size = new Size(228, 27);
            txtbusqueda.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.WhiteSmoke;
            label3.Location = new Point(603, 65);
            label3.Name = "label3";
            label3.Size = new Size(148, 20);
            label3.TabIndex = 3;
            label3.Text = "Numero Documento:";
            // 
            // btnbuscar
            // 
            btnbuscar.BackColor = Color.Gainsboro;
            btnbuscar.IconChar = FontAwesome.Sharp.IconChar.Search;
            btnbuscar.IconColor = Color.Black;
            btnbuscar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnbuscar.IconSize = 24;
            btnbuscar.Location = new Point(1010, 58);
            btnbuscar.Name = "btnbuscar";
            btnbuscar.Size = new Size(99, 27);
            btnbuscar.TabIndex = 4;
            btnbuscar.Text = "Buscar";
            btnbuscar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnbuscar.UseVisualStyleBackColor = false;
            btnbuscar.Click += btnbuscar_Click;
            // 
            // btnlimpiar
            // 
            btnlimpiar.BackColor = Color.LightGray;
            btnlimpiar.IconChar = FontAwesome.Sharp.IconChar.Broom;
            btnlimpiar.IconColor = Color.Black;
            btnlimpiar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnlimpiar.IconSize = 24;
            btnlimpiar.Location = new Point(1115, 58);
            btnlimpiar.Name = "btnlimpiar";
            btnlimpiar.Size = new Size(100, 27);
            btnlimpiar.TabIndex = 5;
            btnlimpiar.Text = "Limpiar";
            btnlimpiar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnlimpiar.UseVisualStyleBackColor = false;
            btnlimpiar.Click += btnlimpiar_Click;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.WhiteSmoke;
            groupBox1.Controls.Add(txtusuario);
            groupBox1.Controls.Add(txttipodocumento);
            groupBox1.Controls.Add(txtfecha);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label5);
            groupBox1.Location = new Point(444, 109);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(832, 125);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Informacion Compra";
            // 
            // txtusuario
            // 
            txtusuario.Location = new Point(649, 60);
            txtusuario.Name = "txtusuario";
            txtusuario.Size = new Size(152, 27);
            txtusuario.TabIndex = 7;
            // 
            // txttipodocumento
            // 
            txttipodocumento.Location = new Point(335, 60);
            txttipodocumento.Name = "txttipodocumento";
            txttipodocumento.Size = new Size(221, 27);
            txttipodocumento.TabIndex = 7;
            // 
            // txtfecha
            // 
            txtfecha.Location = new Point(56, 60);
            txtfecha.Name = "txtfecha";
            txtfecha.Size = new Size(194, 27);
            txtfecha.TabIndex = 7;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(649, 37);
            label6.Name = "label6";
            label6.Size = new Size(62, 20);
            label6.TabIndex = 9;
            label6.Text = "Usuario:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(56, 37);
            label4.Name = "label4";
            label4.Size = new Size(50, 20);
            label4.TabIndex = 7;
            label4.Text = "Fecha:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(335, 37);
            label5.Name = "label5";
            label5.Size = new Size(124, 20);
            label5.TabIndex = 8;
            label5.Text = "Tipo Documento:";
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.WhiteSmoke;
            groupBox2.Controls.Add(txtnumerodocumento);
            groupBox2.Controls.Add(txtrazonsocialproveedor);
            groupBox2.Controls.Add(txtdocproveedor);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(label7);
            groupBox2.Location = new Point(444, 257);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(832, 136);
            groupBox2.TabIndex = 7;
            groupBox2.TabStop = false;
            groupBox2.Text = "Informacion Proveedor";
            // 
            // txtnumerodocumento
            // 
            txtnumerodocumento.Location = new Point(741, 62);
            txtnumerodocumento.Name = "txtnumerodocumento";
            txtnumerodocumento.Size = new Size(80, 27);
            txtnumerodocumento.TabIndex = 8;
            // 
            // txtrazonsocialproveedor
            // 
            txtrazonsocialproveedor.Location = new Point(335, 62);
            txtrazonsocialproveedor.Name = "txtrazonsocialproveedor";
            txtrazonsocialproveedor.Size = new Size(221, 27);
            txtrazonsocialproveedor.TabIndex = 11;
            // 
            // txtdocproveedor
            // 
            txtdocproveedor.Location = new Point(56, 62);
            txtdocproveedor.Name = "txtdocproveedor";
            txtdocproveedor.Size = new Size(194, 27);
            txtdocproveedor.TabIndex = 10;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(335, 39);
            label8.Name = "label8";
            label8.Size = new Size(97, 20);
            label8.TabIndex = 9;
            label8.Text = "Razon Social:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(56, 39);
            label7.Name = "label7";
            label7.Size = new Size(148, 20);
            label7.TabIndex = 8;
            label7.Text = "Numero Documento:";
            // 
            // dgvdata
            // 
            dgvdata.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvdata.BackgroundColor = SystemColors.ButtonHighlight;
            dgvdata.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvdata.Columns.AddRange(new DataGridViewColumn[] { Producto, PrecioCompra, Cantidad, SubTotal });
            dgvdata.Location = new Point(444, 424);
            dgvdata.Name = "dgvdata";
            dgvdata.RowHeadersWidth = 51;
            dgvdata.Size = new Size(832, 227);
            dgvdata.TabIndex = 8;
            // 
            // Producto
            // 
            Producto.HeaderText = "Producto";
            Producto.MinimumWidth = 6;
            Producto.Name = "Producto";
            // 
            // PrecioCompra
            // 
            PrecioCompra.HeaderText = "Precio Compra";
            PrecioCompra.MinimumWidth = 6;
            PrecioCompra.Name = "PrecioCompra";
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
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.WhiteSmoke;
            label9.Location = new Point(444, 665);
            label9.Name = "label9";
            label9.Size = new Size(93, 20);
            label9.TabIndex = 9;
            label9.Text = "Monto Total:";
            // 
            // txttotal
            // 
            txttotal.Location = new Point(543, 662);
            txttotal.Name = "txttotal";
            txttotal.Size = new Size(125, 27);
            txttotal.TabIndex = 10;
            // 
            // btnExportar
            // 
            btnExportar.BackColor = Color.White;
            btnExportar.Cursor = Cursors.Hand;
            btnExportar.FlatAppearance.BorderColor = Color.Black;
            btnExportar.FlatStyle = FlatStyle.Flat;
            btnExportar.ForeColor = SystemColors.ActiveCaptionText;
            btnExportar.IconChar = FontAwesome.Sharp.IconChar.FileExcel;
            btnExportar.IconColor = Color.Black;
            btnExportar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnExportar.IconSize = 16;
            btnExportar.Location = new Point(1050, 657);
            btnExportar.Name = "btnExportar";
            btnExportar.Size = new Size(181, 31);
            btnExportar.TabIndex = 83;
            btnExportar.Text = "Descargue en PDF";
            btnExportar.TextAlign = ContentAlignment.MiddleRight;
            btnExportar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnExportar.UseVisualStyleBackColor = false;
            btnExportar.Click += btnExportar_Click;
            // 
            // frmDetalleCompra
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1378, 736);
            Controls.Add(btnExportar);
            Controls.Add(txttotal);
            Controls.Add(label9);
            Controls.Add(dgvdata);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(btnlimpiar);
            Controls.Add(btnbuscar);
            Controls.Add(label3);
            Controls.Add(txtbusqueda);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmDetalleCompra";
            Text = "frmDetalleCompra";
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
        private TextBox txtbusqueda;
        private Label label3;
        private FontAwesome.Sharp.IconButton btnbuscar;
        private FontAwesome.Sharp.IconButton btnlimpiar;
        private GroupBox groupBox1;
        private TextBox txtusuario;
        private TextBox txttipodocumento;
        private TextBox txtfecha;
        private Label label6;
        private Label label4;
        private Label label5;
        private GroupBox groupBox2;
        private Label label7;
        private TextBox txtnumerodocumento;
        private TextBox txtrazonsocialproveedor;
        private TextBox txtdocproveedor;
        private Label label8;
        private DataGridView dgvdata;
        private DataGridViewTextBoxColumn Producto;
        private DataGridViewTextBoxColumn PrecioCompra;
        private DataGridViewTextBoxColumn Cantidad;
        private DataGridViewTextBoxColumn SubTotal;
        private Label label9;
        private TextBox txttotal;
        private FontAwesome.Sharp.IconButton btnExportar;
    }
}