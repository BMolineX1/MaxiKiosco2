namespace MaxiKiosco
{
    partial class frmVentas
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
            groupBox1 = new GroupBox();
            cbotipodocumento = new ComboBox();
            label4 = new Label();
            label3 = new Label();
            txtfechaventa = new TextBox();
            groupBox2 = new GroupBox();
            btnbuscarproveedor = new FontAwesome.Sharp.IconButton();
            txtapellidocliente = new TextBox();
            txtnombrecliente = new TextBox();
            txtnumerodocumentocliente = new TextBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            txtcantidadproducto = new GroupBox();
            btnagregarproducto = new FontAwesome.Sharp.IconButton();
            txtcantidad = new NumericUpDown();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label11 = new Label();
            label12 = new Label();
            txtidproducto = new TextBox();
            txtstock = new TextBox();
            txtprecioproducto = new TextBox();
            txtnombreproducto = new TextBox();
            txtcodproducto = new TextBox();
            btnbuscarproducto = new FontAwesome.Sharp.IconButton();
            dgvdata = new DataGridView();
            idproducto = new DataGridViewTextBoxColumn();
            btneliminar = new DataGridViewTextBoxColumn();
            Producto = new DataGridViewTextBoxColumn();
            Precio = new DataGridViewTextBoxColumn();
            Cantidad = new DataGridViewTextBoxColumn();
            SubTotal = new DataGridViewTextBoxColumn();
            label13 = new Label();
            label14 = new Label();
            label15 = new Label();
            txttotalpagar = new TextBox();
            txtcambio = new TextBox();
            txtpagacon = new TextBox();
            btnregistrarventa = new FontAwesome.Sharp.IconButton();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            txtcantidadproducto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtcantidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvdata).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = Color.White;
            label1.Location = new Point(298, 33);
            label1.Name = "label1";
            label1.Size = new Size(1178, 704);
            label1.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.White;
            label2.Location = new Point(314, 56);
            label2.Name = "label2";
            label2.Size = new Size(109, 20);
            label2.TabIndex = 1;
            label2.Text = "Registrar Venta";
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.White;
            groupBox1.Controls.Add(cbotipodocumento);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtfechaventa);
            groupBox1.Location = new Point(314, 97);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(393, 125);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Informacion Venta";
            // 
            // cbotipodocumento
            // 
            cbotipodocumento.FormattingEnabled = true;
            cbotipodocumento.Location = new Point(194, 72);
            cbotipodocumento.Name = "cbotipodocumento";
            cbotipodocumento.Size = new Size(166, 28);
            cbotipodocumento.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(194, 49);
            label4.Name = "label4";
            label4.Size = new Size(124, 20);
            label4.TabIndex = 4;
            label4.Text = "Tipo Documento:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 49);
            label3.Name = "label3";
            label3.Size = new Size(50, 20);
            label3.TabIndex = 3;
            label3.Text = "Fecha:";
            // 
            // txtfechaventa
            // 
            txtfechaventa.Location = new Point(6, 72);
            txtfechaventa.Name = "txtfechaventa";
            txtfechaventa.Size = new Size(162, 27);
            txtfechaventa.TabIndex = 3;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.White;
            groupBox2.Controls.Add(btnbuscarproveedor);
            groupBox2.Controls.Add(txtapellidocliente);
            groupBox2.Controls.Add(txtnombrecliente);
            groupBox2.Controls.Add(txtnumerodocumentocliente);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(label5);
            groupBox2.Location = new Point(727, 97);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(606, 125);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Informacion Cliente:";
            // 
            // btnbuscarproveedor
            // 
            btnbuscarproveedor.BackColor = Color.White;
            btnbuscarproveedor.Cursor = Cursors.Hand;
            btnbuscarproveedor.FlatAppearance.BorderColor = Color.Black;
            btnbuscarproveedor.FlatStyle = FlatStyle.Flat;
            btnbuscarproveedor.ForeColor = SystemColors.ControlLightLight;
            btnbuscarproveedor.IconChar = FontAwesome.Sharp.IconChar.Search;
            btnbuscarproveedor.IconColor = Color.Black;
            btnbuscarproveedor.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnbuscarproveedor.IconSize = 16;
            btnbuscarproveedor.Location = new Point(168, 74);
            btnbuscarproveedor.Name = "btnbuscarproveedor";
            btnbuscarproveedor.Size = new Size(38, 27);
            btnbuscarproveedor.TabIndex = 33;
            btnbuscarproveedor.TextAlign = ContentAlignment.MiddleRight;
            btnbuscarproveedor.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnbuscarproveedor.UseVisualStyleBackColor = false;
            btnbuscarproveedor.Click += btnbuscarproveedor_Click;
            // 
            // txtapellidocliente
            // 
            txtapellidocliente.Location = new Point(399, 74);
            txtapellidocliente.Name = "txtapellidocliente";
            txtapellidocliente.Size = new Size(183, 27);
            txtapellidocliente.TabIndex = 5;
            // 
            // txtnombrecliente
            // 
            txtnombrecliente.Location = new Point(212, 74);
            txtnombrecliente.Name = "txtnombrecliente";
            txtnombrecliente.Size = new Size(171, 27);
            txtnombrecliente.TabIndex = 4;
            // 
            // txtnumerodocumentocliente
            // 
            txtnumerodocumentocliente.Location = new Point(6, 74);
            txtnumerodocumentocliente.Name = "txtnumerodocumentocliente";
            txtnumerodocumentocliente.Size = new Size(156, 27);
            txtnumerodocumentocliente.TabIndex = 3;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(399, 48);
            label7.Name = "label7";
            label7.Size = new Size(69, 20);
            label7.TabIndex = 2;
            label7.Text = "Apellido:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(205, 49);
            label6.Name = "label6";
            label6.Size = new Size(67, 20);
            label6.TabIndex = 1;
            label6.Text = "Nombre:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 49);
            label5.Name = "label5";
            label5.Size = new Size(148, 20);
            label5.TabIndex = 0;
            label5.Text = "Numero Documento:";
            // 
            // txtcantidadproducto
            // 
            txtcantidadproducto.BackColor = SystemColors.ButtonHighlight;
            txtcantidadproducto.Controls.Add(btnagregarproducto);
            txtcantidadproducto.Controls.Add(txtcantidad);
            txtcantidadproducto.Controls.Add(label10);
            txtcantidadproducto.Controls.Add(label9);
            txtcantidadproducto.Controls.Add(label8);
            txtcantidadproducto.Controls.Add(label11);
            txtcantidadproducto.Controls.Add(label12);
            txtcantidadproducto.Controls.Add(txtidproducto);
            txtcantidadproducto.Controls.Add(txtstock);
            txtcantidadproducto.Controls.Add(txtprecioproducto);
            txtcantidadproducto.Controls.Add(txtnombreproducto);
            txtcantidadproducto.Controls.Add(txtcodproducto);
            txtcantidadproducto.Controls.Add(btnbuscarproducto);
            txtcantidadproducto.Location = new Point(314, 243);
            txtcantidadproducto.Name = "txtcantidadproducto";
            txtcantidadproducto.Size = new Size(1019, 141);
            txtcantidadproducto.TabIndex = 32;
            txtcantidadproducto.TabStop = false;
            txtcantidadproducto.Text = "Informacion de Producto";
            // 
            // btnagregarproducto
            // 
            btnagregarproducto.IconChar = FontAwesome.Sharp.IconChar.PlusSquare;
            btnagregarproducto.IconColor = Color.ForestGreen;
            btnagregarproducto.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnagregarproducto.Location = new Point(866, 42);
            btnagregarproducto.Name = "btnagregarproducto";
            btnagregarproducto.Size = new Size(94, 73);
            btnagregarproducto.TabIndex = 33;
            btnagregarproducto.Text = "Agregar";
            btnagregarproducto.TextImageRelation = TextImageRelation.ImageAboveText;
            btnagregarproducto.UseVisualStyleBackColor = true;
            btnagregarproducto.Click += btnagregarproducto_Click;
            // 
            // txtcantidad
            // 
            txtcantidad.Location = new Point(747, 100);
            txtcantidad.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            txtcantidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            txtcantidad.Name = "txtcantidad";
            txtcantidad.Size = new Size(97, 27);
            txtcantidad.TabIndex = 43;
            txtcantidad.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(747, 72);
            label10.Name = "label10";
            label10.Size = new Size(69, 20);
            label10.TabIndex = 42;
            label10.Text = "Cantidad";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(603, 78);
            label9.Name = "label9";
            label9.Size = new Size(45, 20);
            label9.TabIndex = 41;
            label9.Text = "Stock";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(466, 78);
            label8.Name = "label8";
            label8.Size = new Size(50, 20);
            label8.TabIndex = 40;
            label8.Text = "Precio";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(247, 79);
            label11.Name = "label11";
            label11.Size = new Size(72, 20);
            label11.TabIndex = 39;
            label11.Text = "Producto:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(6, 76);
            label12.Name = "label12";
            label12.Size = new Size(103, 20);
            label12.TabIndex = 38;
            label12.Text = "Cod. Producto";
            // 
            // txtidproducto
            // 
            txtidproducto.Location = new Point(126, 65);
            txtidproducto.Name = "txtidproducto";
            txtidproducto.Size = new Size(40, 27);
            txtidproducto.TabIndex = 37;
            // 
            // txtstock
            // 
            txtstock.BackColor = SystemColors.Control;
            txtstock.Location = new Point(603, 101);
            txtstock.Name = "txtstock";
            txtstock.Size = new Size(125, 27);
            txtstock.TabIndex = 36;
            // 
            // txtprecioproducto
            // 
            txtprecioproducto.BackColor = SystemColors.Control;
            txtprecioproducto.Location = new Point(466, 101);
            txtprecioproducto.Name = "txtprecioproducto";
            txtprecioproducto.Size = new Size(125, 27);
            txtprecioproducto.TabIndex = 35;
            txtprecioproducto.KeyPress += txtprecioproducto_KeyPress;
            // 
            // txtnombreproducto
            // 
            txtnombreproducto.BackColor = SystemColors.Control;
            txtnombreproducto.Location = new Point(239, 100);
            txtnombreproducto.Name = "txtnombreproducto";
            txtnombreproducto.Size = new Size(202, 27);
            txtnombreproducto.TabIndex = 34;
            // 
            // txtcodproducto
            // 
            txtcodproducto.BackColor = SystemColors.Control;
            txtcodproducto.Location = new Point(6, 99);
            txtcodproducto.Name = "txtcodproducto";
            txtcodproducto.Size = new Size(159, 27);
            txtcodproducto.TabIndex = 33;
            txtcodproducto.KeyDown += txtcodproducto_KeyDown;
            // 
            // btnbuscarproducto
            // 
            btnbuscarproducto.BackColor = Color.White;
            btnbuscarproducto.Cursor = Cursors.Hand;
            btnbuscarproducto.FlatAppearance.BorderColor = Color.Black;
            btnbuscarproducto.FlatStyle = FlatStyle.Flat;
            btnbuscarproducto.ForeColor = SystemColors.ControlLightLight;
            btnbuscarproducto.IconChar = FontAwesome.Sharp.IconChar.Search;
            btnbuscarproducto.IconColor = Color.Black;
            btnbuscarproducto.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnbuscarproducto.IconSize = 16;
            btnbuscarproducto.Location = new Point(171, 99);
            btnbuscarproducto.Name = "btnbuscarproducto";
            btnbuscarproducto.Size = new Size(38, 29);
            btnbuscarproducto.TabIndex = 32;
            btnbuscarproducto.TextAlign = ContentAlignment.MiddleRight;
            btnbuscarproducto.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnbuscarproducto.UseVisualStyleBackColor = false;
            btnbuscarproducto.Click += btnbuscarproducto_Click;
            // 
            // dgvdata
            // 
            dgvdata.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvdata.BackgroundColor = Color.White;
            dgvdata.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvdata.Columns.AddRange(new DataGridViewColumn[] { idproducto, btneliminar, Producto, Precio, Cantidad, SubTotal });
            dgvdata.Location = new Point(314, 424);
            dgvdata.Name = "dgvdata";
            dgvdata.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvdata.RowHeadersWidth = 51;
            dgvdata.Size = new Size(1019, 296);
            dgvdata.TabIndex = 33;
            // 
            // idproducto
            // 
            idproducto.HeaderText = "idproducto";
            idproducto.MinimumWidth = 6;
            idproducto.Name = "idproducto";
            idproducto.Visible = false;
            // 
            // btneliminar
            // 
            btneliminar.HeaderText = "Eliminar";
            btneliminar.MinimumWidth = 6;
            btneliminar.Name = "btneliminar";
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
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = Color.White;
            label13.Location = new Point(1339, 424);
            label13.Name = "label13";
            label13.Size = new Size(98, 20);
            label13.TabIndex = 34;
            label13.Text = "Total a Pagar:";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.BackColor = Color.White;
            label14.Location = new Point(1339, 498);
            label14.Name = "label14";
            label14.Size = new Size(72, 20);
            label14.TabIndex = 35;
            label14.Text = "Paga con:";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.BackColor = Color.White;
            label15.Location = new Point(1339, 563);
            label15.Name = "label15";
            label15.Size = new Size(64, 20);
            label15.TabIndex = 36;
            label15.Text = "Cambio:";
            // 
            // txttotalpagar
            // 
            txttotalpagar.Location = new Point(1339, 447);
            txttotalpagar.Name = "txttotalpagar";
            txttotalpagar.Size = new Size(125, 27);
            txttotalpagar.TabIndex = 37;
            // 
            // txtcambio
            // 
            txtcambio.Location = new Point(1339, 586);
            txtcambio.Name = "txtcambio";
            txtcambio.Size = new Size(125, 27);
            txtcambio.TabIndex = 38;
            // 
            // txtpagacon
            // 
            txtpagacon.Location = new Point(1339, 521);
            txtpagacon.Name = "txtpagacon";
            txtpagacon.Size = new Size(125, 27);
            txtpagacon.TabIndex = 39;
            txtpagacon.KeyDown += txtpagacon_KeyDown;
            txtpagacon.KeyPress += txtpagacon_KeyPress;
            // 
            // btnregistrarventa
            // 
            btnregistrarventa.IconChar = FontAwesome.Sharp.IconChar.Tags;
            btnregistrarventa.IconColor = Color.Teal;
            btnregistrarventa.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnregistrarventa.Location = new Point(1339, 638);
            btnregistrarventa.Name = "btnregistrarventa";
            btnregistrarventa.Size = new Size(124, 51);
            btnregistrarventa.TabIndex = 40;
            btnregistrarventa.Text = "Crear Venta";
            btnregistrarventa.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnregistrarventa.UseVisualStyleBackColor = true;
            btnregistrarventa.Click += btnregistrarventa_Click;
            // 
            // frmVentas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1488, 756);
            Controls.Add(btnregistrarventa);
            Controls.Add(txtpagacon);
            Controls.Add(txtcambio);
            Controls.Add(txttotalpagar);
            Controls.Add(label15);
            Controls.Add(label14);
            Controls.Add(label13);
            Controls.Add(dgvdata);
            Controls.Add(txtcantidadproducto);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmVentas";
            Text = "frmVentas";
            Load += frmVentas_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            txtcantidadproducto.ResumeLayout(false);
            txtcantidadproducto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtcantidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvdata).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private GroupBox groupBox1;
        private Label label4;
        private Label label3;
        private TextBox txtfechaventa;
        private ComboBox cbotipodocumento;
        private GroupBox groupBox2;
        private TextBox txtapellidocliente;
        private TextBox txtnombrecliente;
        private TextBox txtnumerodocumentocliente;
        private Label label7;
        private Label label6;
        private Label label5;
        private FontAwesome.Sharp.IconButton btnbuscarproveedor;
        private GroupBox txtcantidadproducto;
        private FontAwesome.Sharp.IconButton btnagregarproducto;
        private NumericUpDown txtcantidad;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label11;
        private Label label12;
        private TextBox txtidproducto;
        private TextBox txtstock;
        private TextBox txtprecioproducto;
        private TextBox txtnombreproducto;
        private TextBox txtcodproducto;
        private FontAwesome.Sharp.IconButton btnbuscarproducto;
        private DataGridView dgvdata;
        private DataGridViewTextBoxColumn idproducto;
        private DataGridViewTextBoxColumn btneliminar;
        private DataGridViewTextBoxColumn Producto;
        private DataGridViewTextBoxColumn Precio;
        private DataGridViewTextBoxColumn Cantidad;
        private DataGridViewTextBoxColumn SubTotal;
        private Label label13;
        private Label label14;
        private Label label15;
        private TextBox txttotalpagar;
        private TextBox txtcambio;
        private TextBox txtpagacon;
        private FontAwesome.Sharp.IconButton btnregistrarventa;
    }
}