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
            txtcodproducto = new TextBox();
            btnbuscarproducto = new FontAwesome.Sharp.IconButton();
            dgvdata = new DataGridView();
            idproducto = new DataGridViewTextBoxColumn();
            button = new DataGridViewButtonColumn();
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
            label12.Location = new Point(82, 38);
            label12.Name = "label12";
            label12.Size = new Size(1210, 648);
            label12.TabIndex = 27;
            label12.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ButtonHighlight;
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(97, 47);
            label1.Name = "label1";
            label1.Size = new Size(209, 35);
            label1.TabIndex = 28;
            label1.Text = "Registrar Compra";
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.ButtonHighlight;
            groupBox1.Controls.Add(cbotipodocumento);
            groupBox1.Controls.Add(txtfecha);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(97, 102);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(368, 139);
            groupBox1.TabIndex = 29;
            groupBox1.TabStop = false;
            groupBox1.Text = "Informacion de Compra";
            // 
            // cbotipodocumento
            // 
            cbotipodocumento.BackColor = SystemColors.Control;
            cbotipodocumento.FormattingEnabled = true;
            cbotipodocumento.Location = new Point(192, 84);
            cbotipodocumento.Name = "cbotipodocumento";
            cbotipodocumento.Size = new Size(151, 28);
            cbotipodocumento.TabIndex = 3;
            // 
            // txtfecha
            // 
            txtfecha.BackColor = SystemColors.Control;
            txtfecha.Location = new Point(28, 84);
            txtfecha.Name = "txtfecha";
            txtfecha.Size = new Size(138, 27);
            txtfecha.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(192, 61);
            label3.Name = "label3";
            label3.Size = new Size(121, 20);
            label3.TabIndex = 1;
            label3.Text = "Tipo Documento";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(28, 61);
            label2.Name = "label2";
            label2.Size = new Size(47, 20);
            label2.TabIndex = 0;
            label2.Text = "Fecha";
            // 
            // groupBox2
            // 
            groupBox2.BackColor = SystemColors.ButtonHighlight;
            groupBox2.Controls.Add(txtidproveedor);
            groupBox2.Controls.Add(btnbuscarproveedor);
            groupBox2.Controls.Add(txtnombreproveedor);
            groupBox2.Controls.Add(txtrazonsocial);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label4);
            groupBox2.Location = new Point(604, 116);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(470, 125);
            groupBox2.TabIndex = 30;
            groupBox2.TabStop = false;
            groupBox2.Text = "Informacion Proveedor";
            // 
            // txtidproveedor
            // 
            txtidproveedor.Location = new Point(405, 26);
            txtidproveedor.Name = "txtidproveedor";
            txtidproveedor.Size = new Size(35, 27);
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
            btnbuscarproveedor.Location = new Point(205, 79);
            btnbuscarproveedor.Name = "btnbuscarproveedor";
            btnbuscarproveedor.Size = new Size(38, 29);
            btnbuscarproveedor.TabIndex = 32;
            btnbuscarproveedor.TextAlign = ContentAlignment.MiddleRight;
            btnbuscarproveedor.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnbuscarproveedor.UseVisualStyleBackColor = false;
            btnbuscarproveedor.Click += btnbuscarproveedor_Click;
            // 
            // txtnombreproveedor
            // 
            txtnombreproveedor.BackColor = SystemColors.Control;
            txtnombreproveedor.Location = new Point(272, 80);
            txtnombreproveedor.Name = "txtnombreproveedor";
            txtnombreproveedor.Size = new Size(168, 27);
            txtnombreproveedor.TabIndex = 3;
            // 
            // txtrazonsocial
            // 
            txtrazonsocial.BackColor = SystemColors.Control;
            txtrazonsocial.Location = new Point(43, 80);
            txtrazonsocial.Name = "txtrazonsocial";
            txtrazonsocial.Size = new Size(156, 27);
            txtrazonsocial.TabIndex = 2;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(272, 47);
            label5.Name = "label5";
            label5.Size = new Size(64, 20);
            label5.TabIndex = 1;
            label5.Text = "Nombre";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(43, 47);
            label4.Name = "label4";
            label4.Size = new Size(94, 20);
            label4.TabIndex = 0;
            label4.Text = "Razon Social";
            // 
            // groupBox3
            // 
            groupBox3.BackColor = SystemColors.ButtonHighlight;
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
            groupBox3.Controls.Add(txtcodproducto);
            groupBox3.Controls.Add(btnbuscarproducto);
            groupBox3.Location = new Point(97, 267);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(977, 141);
            groupBox3.TabIndex = 31;
            groupBox3.TabStop = false;
            groupBox3.Text = "Informacion de Producto";
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
            label9.Size = new Size(91, 20);
            label9.TabIndex = 41;
            label9.Text = "Precio Venta";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(466, 78);
            label8.Name = "label8";
            label8.Size = new Size(107, 20);
            label8.TabIndex = 40;
            label8.Text = "Precio Compra";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(247, 79);
            label7.Name = "label7";
            label7.Size = new Size(72, 20);
            label7.TabIndex = 39;
            label7.Text = "Producto:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 76);
            label6.Name = "label6";
            label6.Size = new Size(103, 20);
            label6.TabIndex = 38;
            label6.Text = "Cod. Producto";
            // 
            // txtidproducto
            // 
            txtidproducto.Location = new Point(126, 65);
            txtidproducto.Name = "txtidproducto";
            txtidproducto.Size = new Size(40, 27);
            txtidproducto.TabIndex = 37;
            // 
            // txtprecioventaproducto
            // 
            txtprecioventaproducto.BackColor = SystemColors.Control;
            txtprecioventaproducto.Location = new Point(603, 101);
            txtprecioventaproducto.Name = "txtprecioventaproducto";
            txtprecioventaproducto.Size = new Size(125, 27);
            txtprecioventaproducto.TabIndex = 36;
            txtprecioventaproducto.KeyPress += txtprecioventaproducto_KeyPress;
            // 
            // txtpreciocompraproducto
            // 
            txtpreciocompraproducto.BackColor = SystemColors.Control;
            txtpreciocompraproducto.Location = new Point(466, 101);
            txtpreciocompraproducto.Name = "txtpreciocompraproducto";
            txtpreciocompraproducto.Size = new Size(125, 27);
            txtpreciocompraproducto.TabIndex = 35;
            txtpreciocompraproducto.KeyPress += txtpreciocompraproducto_KeyPress;
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
            dgvdata.BackgroundColor = SystemColors.ButtonHighlight;
            dgvdata.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvdata.Columns.AddRange(new DataGridViewColumn[] { idproducto, button, Producto, PrecioCompra, PrecioVenta, Cantidad, SubTotal });
            dgvdata.Location = new Point(103, 442);
            dgvdata.Name = "dgvdata";
            dgvdata.RowHeadersWidth = 51;
            dgvdata.Size = new Size(871, 232);
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
            // button
            // 
            button.HeaderText = "btneliminar";
            button.MinimumWidth = 6;
            button.Name = "button";
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
            label11.Location = new Point(981, 529);
            label11.Name = "label11";
            label11.Size = new Size(95, 20);
            label11.TabIndex = 33;
            label11.Text = "Total a Pagar";
            // 
            // txttotalpagar
            // 
            txttotalpagar.Location = new Point(980, 552);
            txttotalpagar.Name = "txttotalpagar";
            txttotalpagar.Size = new Size(125, 27);
            txttotalpagar.TabIndex = 34;
            // 
            // btnregistrarcompra
            // 
            btnregistrarcompra.IconChar = FontAwesome.Sharp.IconChar.Tags;
            btnregistrarcompra.IconColor = Color.Teal;
            btnregistrarcompra.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnregistrarcompra.Location = new Point(981, 585);
            btnregistrarcompra.Name = "btnregistrarcompra";
            btnregistrarcompra.Size = new Size(124, 51);
            btnregistrarcompra.TabIndex = 35;
            btnregistrarcompra.Text = "Registrar";
            btnregistrarcompra.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnregistrarcompra.UseVisualStyleBackColor = true;
            btnregistrarcompra.Click += btnregistrarcompra_Click;
            // 
            // frmCompras
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1327, 723);
            Controls.Add(btnregistrarcompra);
            Controls.Add(txttotalpagar);
            Controls.Add(label11);
            Controls.Add(dgvdata);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Controls.Add(label12);
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
        private TextBox txtcodproducto;
        private FontAwesome.Sharp.IconButton btnbuscarproducto;
        private NumericUpDown txtcantidad;
        private DataGridView dgvdata;
        private FontAwesome.Sharp.IconButton btnagregarproducto;
        private Label label11;
        private TextBox txttotalpagar;
        private FontAwesome.Sharp.IconButton btnregistrarcompra;
        private DataGridViewTextBoxColumn idproducto;
        private DataGridViewButtonColumn button;
        private DataGridViewTextBoxColumn Producto;
        private DataGridViewTextBoxColumn PrecioCompra;
        private DataGridViewTextBoxColumn PrecioVenta;
        private DataGridViewTextBoxColumn Cantidad;
        private DataGridViewTextBoxColumn SubTotal;
    }
}