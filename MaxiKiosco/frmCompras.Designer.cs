namespace MaxiKiosco
{
    partial class frmCompras
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
            label12 = new Label();
            label1 = new Label();
            groupBox1 = new GroupBox();
            cbotipodocumento = new ComboBox();
            txtfecha = new TextBox();
            label3 = new Label();
            label2 = new Label();
            groupBox2 = new GroupBox();
            txtidproveedor = new TextBox();
            btnbuscarproveedor = new FontAwesome.Sharp.IconButton();
            txtnombreproveedor = new TextBox();
            txtrazonsocial = new TextBox();
            label5 = new Label();
            label4 = new Label();
            groupBox3 = new GroupBox();
            lbliva = new Label();
            txtivaProducto = new TextBox();
            textcodproducto = new TextBox();
            label14 = new Label();
            label13 = new Label();
            btnagregarproducto = new FontAwesome.Sharp.IconButton();
            txtcantidad = new NumericUpDown();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            txtidproducto = new TextBox();
            txtprecioventaproducto = new TextBox();
            txtpreciocompraproducto = new TextBox();
            txtnombreproducto = new TextBox();
            txtnomproducto = new TextBox();
            btnbuscarproducto = new FontAwesome.Sharp.IconButton();
            dgvdata = new DataGridView();
            idproducto = new DataGridViewTextBoxColumn();
            btneliminar = new DataGridViewButtonColumn();
            Producto = new DataGridViewTextBoxColumn();
            PrecioCompra = new DataGridViewTextBoxColumn();
            PrecioVenta = new DataGridViewTextBoxColumn();
            Cantidad = new DataGridViewTextBoxColumn();
            SubTotal = new DataGridViewTextBoxColumn();
            label11 = new Label();
            txttotalpagar = new TextBox();
            btnregistrarcompra = new FontAwesome.Sharp.IconButton();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtcantidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvdata).BeginInit();
            SuspendLayout();
            // 
            // label12
            // 
            label12.BackColor = SystemColors.ControlLightLight;
            label12.Font = new Font("Segoe UI", 15F);
            label12.Location = new Point(72, 28);
            label12.Name = "label12";
            label12.Size = new Size(1059, 486);
            label12.TabIndex = 27;
            label12.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ButtonHighlight;
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(85, 35);
            label1.Name = "label1";
            label1.Size = new Size(164, 28);
            label1.TabIndex = 28;
            label1.Text = "Registrar Compra";
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.GhostWhite;
            groupBox1.Controls.Add(cbotipodocumento);
            groupBox1.Controls.Add(txtfecha);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(85, 87);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(357, 92);
            groupBox1.TabIndex = 29;
            groupBox1.TabStop = false;
            groupBox1.Text = "Informacion de Compra";
            // 
            // cbotipodocumento
            // 
            cbotipodocumento.BackColor = SystemColors.Control;
            cbotipodocumento.FormattingEnabled = true;
            cbotipodocumento.Location = new Point(168, 63);
            cbotipodocumento.Margin = new Padding(3, 2, 3, 2);
            cbotipodocumento.Name = "cbotipodocumento";
            cbotipodocumento.Size = new Size(133, 23);
            cbotipodocumento.TabIndex = 3;
            // 
            // txtfecha
            // 
            txtfecha.BackColor = SystemColors.Control;
            txtfecha.Location = new Point(24, 63);
            txtfecha.Margin = new Padding(3, 2, 3, 2);
            txtfecha.Name = "txtfecha";
            txtfecha.ReadOnly = true;
            txtfecha.Size = new Size(121, 23);
            txtfecha.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(168, 46);
            label3.Name = "label3";
            label3.Size = new Size(96, 15);
            label3.TabIndex = 1;
            label3.Text = "Tipo Documento";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(24, 46);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 0;
            label2.Text = "Fecha";
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.GhostWhite;
            groupBox2.Controls.Add(txtidproveedor);
            groupBox2.Controls.Add(btnbuscarproveedor);
            groupBox2.Controls.Add(txtnombreproveedor);
            groupBox2.Controls.Add(txtrazonsocial);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label4);
            groupBox2.Location = new Point(474, 87);
            groupBox2.Margin = new Padding(3, 2, 3, 2);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 2, 3, 2);
            groupBox2.Size = new Size(529, 94);
            groupBox2.TabIndex = 30;
            groupBox2.TabStop = false;
            groupBox2.Text = "Informacion Proveedor";
            // 
            // txtidproveedor
            // 
            txtidproveedor.Location = new Point(354, 20);
            txtidproveedor.Margin = new Padding(3, 2, 3, 2);
            txtidproveedor.Name = "txtidproveedor";
            txtidproveedor.Size = new Size(31, 23);
            txtidproveedor.TabIndex = 33;
            txtidproveedor.Visible = false;
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
            btnbuscarproveedor.Location = new Point(179, 59);
            btnbuscarproveedor.Margin = new Padding(3, 2, 3, 2);
            btnbuscarproveedor.Name = "btnbuscarproveedor";
            btnbuscarproveedor.Size = new Size(33, 22);
            btnbuscarproveedor.TabIndex = 32;
            btnbuscarproveedor.TextAlign = ContentAlignment.MiddleRight;
            btnbuscarproveedor.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnbuscarproveedor.UseVisualStyleBackColor = false;
            btnbuscarproveedor.Click += btnbuscarproveedor_Click;
            // 
            // txtnombreproveedor
            // 
            txtnombreproveedor.BackColor = SystemColors.Control;
            txtnombreproveedor.Location = new Point(238, 60);
            txtnombreproveedor.Margin = new Padding(3, 2, 3, 2);
            txtnombreproveedor.Name = "txtnombreproveedor";
            txtnombreproveedor.Size = new Size(148, 23);
            txtnombreproveedor.TabIndex = 3;
            txtnombreproveedor.KeyDown += txtnombreproveedor_KeyDown;
            // 
            // txtrazonsocial
            // 
            txtrazonsocial.BackColor = SystemColors.Control;
            txtrazonsocial.Location = new Point(38, 60);
            txtrazonsocial.Margin = new Padding(3, 2, 3, 2);
            txtrazonsocial.Name = "txtrazonsocial";
            txtrazonsocial.Size = new Size(137, 23);
            txtrazonsocial.TabIndex = 2;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(238, 35);
            label5.Name = "label5";
            label5.Size = new Size(51, 15);
            label5.TabIndex = 1;
            label5.Text = "Nombre";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(38, 35);
            label4.Name = "label4";
            label4.Size = new Size(73, 15);
            label4.TabIndex = 0;
            label4.Text = "Razon Social";
            // 
            // groupBox3
            // 
            groupBox3.BackColor = Color.GhostWhite;
            groupBox3.Controls.Add(lbliva);
            groupBox3.Controls.Add(txtivaProducto);
            groupBox3.Controls.Add(textcodproducto);
            groupBox3.Controls.Add(label14);
            groupBox3.Controls.Add(label13);
            groupBox3.Controls.Add(btnagregarproducto);
            groupBox3.Controls.Add(txtcantidad);
            groupBox3.Controls.Add(label10);
            groupBox3.Controls.Add(label9);
            groupBox3.Controls.Add(label8);
            groupBox3.Controls.Add(label7);
            groupBox3.Controls.Add(label6);
            groupBox3.Controls.Add(txtidproducto);
            groupBox3.Controls.Add(txtprecioventaproducto);
            groupBox3.Controls.Add(txtpreciocompraproducto);
            groupBox3.Controls.Add(txtnombreproducto);
            groupBox3.Controls.Add(txtnomproducto);
            groupBox3.Controls.Add(btnbuscarproducto);
            groupBox3.Location = new Point(85, 200);
            groupBox3.Margin = new Padding(3, 2, 3, 2);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(3, 2, 3, 2);
            groupBox3.Size = new Size(918, 106);
            groupBox3.TabIndex = 31;
            groupBox3.TabStop = false;
            groupBox3.Text = "Informacion de Producto";
            // 
            // lbliva
            // 
            lbliva.AutoSize = true;
            lbliva.Location = new Point(746, 38);
            lbliva.Name = "lbliva";
            lbliva.Size = new Size(49, 15);
            lbliva.TabIndex = 48;
            lbliva.Text = "IVA 21%";
            // 
            // txtivaProducto
            // 
            txtivaProducto.Location = new Point(746, 56);
            txtivaProducto.Name = "txtivaProducto";
            txtivaProducto.ReadOnly = true;
            txtivaProducto.Size = new Size(65, 23);
            txtivaProducto.TabIndex = 47;
            // 
            // textcodproducto
            // 
            textcodproducto.BackColor = SystemColors.Control;
            textcodproducto.Location = new Point(115, 42);
            textcodproducto.Name = "textcodproducto";
            textcodproducto.PlaceholderText = "Codigo del Producto";
            textcodproducto.Size = new Size(126, 23);
            textcodproducto.TabIndex = 46;
            textcodproducto.KeyDown += textcodproducto_KeyDown;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(5, 78);
            label14.Name = "label14";
            label14.Size = new Size(110, 15);
            label14.TabIndex = 45;
            label14.Text = "Buscar por Nombre";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.Location = new Point(70, 22);
            label13.Name = "label13";
            label13.Size = new Size(94, 15);
            label13.TabIndex = 44;
            label13.Text = "Buscar Producto";
            // 
            // btnagregarproducto
            // 
            btnagregarproducto.IconChar = FontAwesome.Sharp.IconChar.PlusSquare;
            btnagregarproducto.IconColor = Color.ForestGreen;
            btnagregarproducto.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnagregarproducto.Location = new Point(830, 35);
            btnagregarproducto.Margin = new Padding(3, 2, 3, 2);
            btnagregarproducto.Name = "btnagregarproducto";
            btnagregarproducto.Size = new Size(82, 55);
            btnagregarproducto.TabIndex = 33;
            btnagregarproducto.Text = "Agregar";
            btnagregarproducto.TextImageRelation = TextImageRelation.ImageAboveText;
            btnagregarproducto.UseVisualStyleBackColor = true;
            btnagregarproducto.Click += btnagregarproducto_Click;
            // 
            // txtcantidad
            // 
            txtcantidad.Location = new Point(655, 56);
            txtcantidad.Margin = new Padding(3, 2, 3, 2);
            txtcantidad.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            txtcantidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            txtcantidad.Name = "txtcantidad";
            txtcantidad.Size = new Size(85, 23);
            txtcantidad.TabIndex = 43;
            txtcantidad.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(666, 35);
            label10.Name = "label10";
            label10.Size = new Size(55, 15);
            label10.TabIndex = 42;
            label10.Text = "Cantidad";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(539, 39);
            label9.Name = "label9";
            label9.Size = new Size(72, 15);
            label9.TabIndex = 41;
            label9.Text = "Precio Venta";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(427, 39);
            label8.Name = "label8";
            label8.Size = new Size(86, 15);
            label8.TabIndex = 40;
            label8.Text = "Precio Compra";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(286, 38);
            label7.Name = "label7";
            label7.Size = new Size(126, 15);
            label7.TabIndex = 39;
            label7.Text = "Nombre Del Producto:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 42);
            label6.Name = "label6";
            label6.Size = new Size(103, 15);
            label6.TabIndex = 38;
            label6.Text = "Buscar por codigo";
            // 
            // txtidproducto
            // 
            txtidproducto.Location = new Point(247, 14);
            txtidproducto.Margin = new Padding(3, 2, 3, 2);
            txtidproducto.Name = "txtidproducto";
            txtidproducto.PlaceholderText = "ID";
            txtidproducto.Size = new Size(33, 23);
            txtidproducto.TabIndex = 37;
            txtidproducto.Visible = false;
            // 
            // txtprecioventaproducto
            // 
            txtprecioventaproducto.BackColor = SystemColors.Control;
            txtprecioventaproducto.Location = new Point(539, 55);
            txtprecioventaproducto.Margin = new Padding(3, 2, 3, 2);
            txtprecioventaproducto.Name = "txtprecioventaproducto";
            txtprecioventaproducto.ReadOnly = true;
            txtprecioventaproducto.Size = new Size(110, 23);
            txtprecioventaproducto.TabIndex = 36;
            txtprecioventaproducto.KeyPress += txtprecioventaproducto_KeyPress;
            // 
            // txtpreciocompraproducto
            // 
            txtpreciocompraproducto.BackColor = SystemColors.Control;
            txtpreciocompraproducto.Location = new Point(423, 55);
            txtpreciocompraproducto.Margin = new Padding(3, 2, 3, 2);
            txtpreciocompraproducto.Name = "txtpreciocompraproducto";
            txtpreciocompraproducto.Size = new Size(110, 23);
            txtpreciocompraproducto.TabIndex = 35;
            txtpreciocompraproducto.KeyPress += txtpreciocompraproducto_KeyPress;
            // 
            // txtnombreproducto
            // 
            txtnombreproducto.BackColor = SystemColors.Control;
            txtnombreproducto.Location = new Point(286, 55);
            txtnombreproducto.Margin = new Padding(3, 2, 3, 2);
            txtnombreproducto.Name = "txtnombreproducto";
            txtnombreproducto.ReadOnly = true;
            txtnombreproducto.Size = new Size(131, 23);
            txtnombreproducto.TabIndex = 34;
            txtnombreproducto.TextChanged += txtnombreproducto_TextChanged;
            // 
            // txtnomproducto
            // 
            txtnomproducto.BackColor = SystemColors.Control;
            txtnomproducto.Location = new Point(115, 74);
            txtnomproducto.Margin = new Padding(3, 2, 3, 2);
            txtnomproducto.Name = "txtnomproducto";
            txtnomproducto.PlaceholderText = "Nombre del producto";
            txtnomproducto.Size = new Size(126, 23);
            txtnomproducto.TabIndex = 33;
            txtnomproducto.KeyDown += txtnomproducto_KeyDown;
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
            btnbuscarproducto.Location = new Point(247, 42);
            btnbuscarproducto.Margin = new Padding(3, 2, 3, 2);
            btnbuscarproducto.Name = "btnbuscarproducto";
            btnbuscarproducto.Size = new Size(33, 56);
            btnbuscarproducto.TabIndex = 32;
            btnbuscarproducto.TextAlign = ContentAlignment.MiddleRight;
            btnbuscarproducto.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnbuscarproducto.UseVisualStyleBackColor = false;
            btnbuscarproducto.Click += btnbuscarproducto_Click;
            // 
            // dgvdata
            // 
            dgvdata.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvdata.BackgroundColor = Color.GhostWhite;
            dgvdata.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvdata.Columns.AddRange(new DataGridViewColumn[] { idproducto, btneliminar, Producto, PrecioCompra, PrecioVenta, Cantidad, SubTotal });
            dgvdata.Location = new Point(90, 332);
            dgvdata.Margin = new Padding(3, 2, 3, 2);
            dgvdata.Name = "dgvdata";
            dgvdata.RowHeadersWidth = 51;
            dgvdata.Size = new Size(762, 174);
            dgvdata.TabIndex = 32;
            dgvdata.CellContentClick += dgvdata_CellContentClick;
            // 
            // idproducto
            // 
            idproducto.HeaderText = "IdProducto";
            idproducto.MinimumWidth = 6;
            idproducto.Name = "idproducto";
            idproducto.Visible = false;
            // 
            // btneliminar
            // 
            btneliminar.HeaderText = "Accion Eliminar";
            btneliminar.MinimumWidth = 6;
            btneliminar.Name = "btneliminar";
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
            // PrecioVenta
            // 
            PrecioVenta.HeaderText = "Precio Venta";
            PrecioVenta.MinimumWidth = 6;
            PrecioVenta.Name = "PrecioVenta";
            PrecioVenta.Visible = false;
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
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = SystemColors.ButtonHighlight;
            label11.Location = new Point(889, 382);
            label11.Name = "label11";
            label11.Size = new Size(74, 15);
            label11.TabIndex = 33;
            label11.Text = "Total a Pagar";
            // 
            // txttotalpagar
            // 
            txttotalpagar.Location = new Point(871, 399);
            txttotalpagar.Margin = new Padding(3, 2, 3, 2);
            txttotalpagar.Name = "txttotalpagar";
            txttotalpagar.Size = new Size(110, 23);
            txttotalpagar.TabIndex = 34;
            // 
            // btnregistrarcompra
            // 
            btnregistrarcompra.IconChar = FontAwesome.Sharp.IconChar.Tags;
            btnregistrarcompra.IconColor = Color.Teal;
            btnregistrarcompra.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnregistrarcompra.Location = new Point(858, 439);
            btnregistrarcompra.Margin = new Padding(3, 2, 3, 2);
            btnregistrarcompra.Name = "btnregistrarcompra";
            btnregistrarcompra.Size = new Size(139, 47);
            btnregistrarcompra.TabIndex = 35;
            btnregistrarcompra.Text = "Registrar";
            btnregistrarcompra.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnregistrarcompra.UseVisualStyleBackColor = true;
            btnregistrarcompra.Click += btnregistrarcompra_Click;
            // 
            // frmCompras
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1161, 542);
            Controls.Add(btnregistrarcompra);
            Controls.Add(txttotalpagar);
            Controls.Add(label11);
            Controls.Add(dgvdata);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Controls.Add(label12);
            Margin = new Padding(3, 2, 3, 2);
            Name = "frmCompras";
            Text = "frmCompras";
            Load += frmCompras_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtcantidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvdata).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label12;
        private Label label1;
        private GroupBox groupBox1;
        private Label label3;
        private Label label2;
        private ComboBox cbotipodocumento;
        private TextBox txtfecha;
        private GroupBox groupBox2;
        private Label label5;
        private Label label4;
        private FontAwesome.Sharp.IconButton btnbuscarproveedor;
        private TextBox txtnombreproveedor;
        private TextBox txtrazonsocial;
        private TextBox txtidproveedor;
        private GroupBox groupBox3;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private TextBox txtidproducto;
        private TextBox txtprecioventaproducto;
        private TextBox txtpreciocompraproducto;
        private TextBox txtnombreproducto;
        private TextBox txtnomproducto;
        private FontAwesome.Sharp.IconButton btnbuscarproducto;
        private NumericUpDown txtcantidad;
        private DataGridView dgvdata;
        private FontAwesome.Sharp.IconButton btnagregarproducto;
        private Label label11;
        private TextBox txttotalpagar;
        private FontAwesome.Sharp.IconButton btnregistrarcompra;
        private Label label14;
        private Label label13;
        private TextBox textcodproducto;
        private TextBox txtivaProducto;
        private Label lbliva;
        private DataGridViewTextBoxColumn idproducto;
        private DataGridViewButtonColumn btneliminar;
        private DataGridViewTextBoxColumn Producto;
        private DataGridViewTextBoxColumn PrecioCompra;
        private DataGridViewTextBoxColumn PrecioVenta;
        private DataGridViewTextBoxColumn Cantidad;
        private DataGridViewTextBoxColumn SubTotal;
    }
}