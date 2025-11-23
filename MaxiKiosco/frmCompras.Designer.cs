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
            label2 = new Label();
            groupBox2 = new GroupBox();
            lbnombreproveedor = new ListBox();
            txtidproveedor = new TextBox();
            txtnombreproveedor = new TextBox();
            label5 = new Label();
            groupBox3 = new GroupBox();
            lbnombreproducto = new ListBox();
            lbcodproducto = new ListBox();
            lbliva = new Label();
            txtivaProducto = new TextBox();
            textcodproducto = new TextBox();
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
            dgvdata = new DataGridView();
            idproducto = new DataGridViewTextBoxColumn();
            btneliminar = new DataGridViewButtonColumn();
            Producto = new DataGridViewTextBoxColumn();
            PrecioCompra = new DataGridViewTextBoxColumn();
            PrecioVenta = new DataGridViewTextBoxColumn();
            Cantidad = new DataGridViewTextBoxColumn();
            SubTotalBruto = new DataGridViewTextBoxColumn();
            MontoIVA = new DataGridViewTextBoxColumn();
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
            label12.Location = new Point(358, 68);
            label12.Name = "label12";
            label12.Size = new Size(1108, 768);
            label12.TabIndex = 27;
            label12.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ButtonHighlight;
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(373, 78);
            label1.Name = "label1";
            label1.Size = new Size(209, 35);
            label1.TabIndex = 28;
            label1.Text = "Registrar Compra";
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.GhostWhite;
            groupBox1.Controls.Add(cbotipodocumento);
            groupBox1.Controls.Add(txtfecha);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(373, 147);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(408, 123);
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
            cbotipodocumento.Visible = false;
            // 
            // txtfecha
            // 
            txtfecha.BackColor = SystemColors.Control;
            txtfecha.Location = new Point(27, 84);
            txtfecha.Name = "txtfecha";
            txtfecha.ReadOnly = true;
            txtfecha.Size = new Size(138, 27);
            txtfecha.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(27, 61);
            label2.Name = "label2";
            label2.Size = new Size(47, 20);
            label2.TabIndex = 0;
            label2.Text = "Fecha";
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.GhostWhite;
            groupBox2.Controls.Add(lbnombreproveedor);
            groupBox2.Controls.Add(txtidproveedor);
            groupBox2.Controls.Add(txtnombreproveedor);
            groupBox2.Controls.Add(label5);
            groupBox2.Location = new Point(818, 147);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(605, 123);
            groupBox2.TabIndex = 30;
            groupBox2.TabStop = false;
            groupBox2.Text = "Informacion Proveedor";
            // 
            // lbnombreproveedor
            // 
            lbnombreproveedor.FormattingEnabled = true;
            lbnombreproveedor.Location = new Point(214, 77);
            lbnombreproveedor.Name = "lbnombreproveedor";
            lbnombreproveedor.Size = new Size(282, 104);
            lbnombreproveedor.TabIndex = 34;
            // 
            // txtidproveedor
            // 
            txtidproveedor.Location = new Point(398, 0);
            txtidproveedor.Name = "txtidproveedor";
            txtidproveedor.Size = new Size(35, 27);
            txtidproveedor.TabIndex = 33;
            txtidproveedor.Visible = false;
            // 
            // txtnombreproveedor
            // 
            txtnombreproveedor.BackColor = SystemColors.Control;
            txtnombreproveedor.Location = new Point(214, 44);
            txtnombreproveedor.Name = "txtnombreproveedor";
            txtnombreproveedor.Size = new Size(282, 27);
            txtnombreproveedor.TabIndex = 3;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(7, 47);
            label5.Name = "label5";
            label5.Size = new Size(161, 20);
            label5.TabIndex = 1;
            label5.Text = "Nombre del Proveedor";
            // 
            // groupBox3
            // 
            groupBox3.BackColor = Color.GhostWhite;
            groupBox3.Controls.Add(lbnombreproducto);
            groupBox3.Controls.Add(lbcodproducto);
            groupBox3.Controls.Add(lbliva);
            groupBox3.Controls.Add(txtivaProducto);
            groupBox3.Controls.Add(textcodproducto);
            groupBox3.Controls.Add(label13);
            groupBox3.Controls.Add(btnagregarproducto);
            groupBox3.Controls.Add(txtcantidad);
            groupBox3.Controls.Add(label9);
            groupBox3.Controls.Add(label10);
            groupBox3.Controls.Add(label8);
            groupBox3.Controls.Add(label7);
            groupBox3.Controls.Add(label6);
            groupBox3.Controls.Add(txtidproducto);
            groupBox3.Controls.Add(txtprecioventaproducto);
            groupBox3.Controls.Add(txtpreciocompraproducto);
            groupBox3.Controls.Add(txtnombreproducto);
            groupBox3.Location = new Point(373, 298);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(1049, 223);
            groupBox3.TabIndex = 31;
            groupBox3.TabStop = false;
            groupBox3.Text = "Informacion de Producto";
            // 
            // lbnombreproducto
            // 
            lbnombreproducto.FormattingEnabled = true;
            lbnombreproducto.Location = new Point(335, 106);
            lbnombreproducto.Name = "lbnombreproducto";
            lbnombreproducto.Size = new Size(253, 104);
            lbnombreproducto.TabIndex = 50;
            // 
            // lbcodproducto
            // 
            lbcodproducto.FormattingEnabled = true;
            lbcodproducto.Location = new Point(155, 106);
            lbcodproducto.Name = "lbcodproducto";
            lbcodproducto.Size = new Size(143, 104);
            lbcodproducto.TabIndex = 49;
            // 
            // lbliva
            // 
            lbliva.AutoSize = true;
            lbliva.Location = new Point(867, 51);
            lbliva.Name = "lbliva";
            lbliva.Size = new Size(63, 20);
            lbliva.TabIndex = 48;
            lbliva.Text = "IVA 21%";
            // 
            // txtivaProducto
            // 
            txtivaProducto.Location = new Point(867, 75);
            txtivaProducto.Margin = new Padding(3, 4, 3, 4);
            txtivaProducto.Name = "txtivaProducto";
            txtivaProducto.ReadOnly = true;
            txtivaProducto.Size = new Size(74, 27);
            txtivaProducto.TabIndex = 47;
            // 
            // textcodproducto
            // 
            textcodproducto.BackColor = SystemColors.Control;
            textcodproducto.Location = new Point(155, 75);
            textcodproducto.Margin = new Padding(3, 4, 3, 4);
            textcodproducto.Name = "textcodproducto";
            textcodproducto.PlaceholderText = "Codigo del Producto";
            textcodproducto.Size = new Size(143, 27);
            textcodproducto.TabIndex = 46;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.Location = new Point(169, 23);
            label13.Name = "label13";
            label13.Size = new Size(121, 20);
            label13.TabIndex = 44;
            label13.Text = "Buscar Producto";
            // 
            // btnagregarproducto
            // 
            btnagregarproducto.IconChar = FontAwesome.Sharp.IconChar.PlusSquare;
            btnagregarproducto.IconColor = Color.ForestGreen;
            btnagregarproducto.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnagregarproducto.Location = new Point(949, 47);
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
            txtcantidad.Location = new Point(42, 74);
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
            label10.Location = new Point(42, 52);
            label10.Name = "label10";
            label10.Size = new Size(69, 20);
            label10.TabIndex = 42;
            label10.Text = "Cantidad";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(733, 51);
            label9.Name = "label9";
            label9.Size = new Size(91, 20);
            label9.TabIndex = 41;
            label9.Text = "Precio Venta";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(600, 51);
            label8.Name = "label8";
            label8.Size = new Size(107, 20);
            label8.TabIndex = 40;
            label8.Text = "Precio Compra";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(336, 52);
            label7.Name = "label7";
            label7.Size = new Size(158, 20);
            label7.TabIndex = 39;
            label7.Text = "Nombre Del Producto:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(160, 51);
            label6.Name = "label6";
            label6.Size = new Size(130, 20);
            label6.TabIndex = 38;
            label6.Text = "Buscar por codigo";
            // 
            // txtidproducto
            // 
            txtidproducto.Location = new Point(282, 19);
            txtidproducto.Name = "txtidproducto";
            txtidproducto.PlaceholderText = "ID";
            txtidproducto.Size = new Size(37, 27);
            txtidproducto.TabIndex = 37;
            txtidproducto.Visible = false;
            // 
            // txtprecioventaproducto
            // 
            txtprecioventaproducto.BackColor = SystemColors.Control;
            txtprecioventaproducto.Location = new Point(733, 75);
            txtprecioventaproducto.Name = "txtprecioventaproducto";
            txtprecioventaproducto.ReadOnly = true;
            txtprecioventaproducto.Size = new Size(125, 27);
            txtprecioventaproducto.TabIndex = 36;
            txtprecioventaproducto.KeyPress += txtprecioventaproducto_KeyPress;
            // 
            // txtpreciocompraproducto
            // 
            txtpreciocompraproducto.BackColor = SystemColors.Control;
            txtpreciocompraproducto.Location = new Point(600, 75);
            txtpreciocompraproducto.Name = "txtpreciocompraproducto";
            txtpreciocompraproducto.Size = new Size(125, 27);
            txtpreciocompraproducto.TabIndex = 35;
            txtpreciocompraproducto.TextChanged += txtpreciocompraproducto_TextChanged;
            txtpreciocompraproducto.KeyPress += txtpreciocompraproducto_KeyPress;
            txtpreciocompraproducto.Validated += txtpreciocompraproducto_Validated;
            // 
            // txtnombreproducto
            // 
            txtnombreproducto.BackColor = SystemColors.Control;
            txtnombreproducto.Location = new Point(336, 75);
            txtnombreproducto.Name = "txtnombreproducto";
            txtnombreproducto.Size = new Size(252, 27);
            txtnombreproducto.TabIndex = 34;
            // 
            // dgvdata
            // 
            dgvdata.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvdata.BackgroundColor = Color.GhostWhite;
            dgvdata.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvdata.Columns.AddRange(new DataGridViewColumn[] { idproducto, btneliminar, Producto, PrecioCompra, PrecioVenta, Cantidad, SubTotalBruto, MontoIVA });
            dgvdata.Location = new Point(373, 527);
            dgvdata.Name = "dgvdata";
            dgvdata.RowHeadersWidth = 51;
            dgvdata.Size = new Size(878, 290);
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
            btneliminar.FillWeight = 15F;
            btneliminar.HeaderText = "Accion Eliminar";
            btneliminar.MinimumWidth = 6;
            btneliminar.Name = "btneliminar";
            // 
            // Producto
            // 
            Producto.FillWeight = 36.16751F;
            Producto.HeaderText = "Producto";
            Producto.MinimumWidth = 6;
            Producto.Name = "Producto";
            // 
            // PrecioCompra
            // 
            PrecioCompra.FillWeight = 36.16751F;
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
            Cantidad.FillWeight = 36.16751F;
            Cantidad.HeaderText = "Cantidad";
            Cantidad.MinimumWidth = 6;
            Cantidad.Name = "Cantidad";
            // 
            // SubTotalBruto
            // 
            SubTotalBruto.FillWeight = 36.16751F;
            SubTotalBruto.HeaderText = "SubTotal";
            SubTotalBruto.MinimumWidth = 6;
            SubTotalBruto.Name = "SubTotalBruto";
            // 
            // MontoIVA
            // 
            MontoIVA.HeaderText = "MontoIVA";
            MontoIVA.MinimumWidth = 6;
            MontoIVA.Name = "MontoIVA";
            MontoIVA.Visible = false;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = SystemColors.ButtonHighlight;
            label11.Location = new Point(1292, 540);
            label11.Name = "label11";
            label11.Size = new Size(95, 20);
            label11.TabIndex = 33;
            label11.Text = "Total a Pagar";
            // 
            // txttotalpagar
            // 
            txttotalpagar.Location = new Point(1271, 563);
            txttotalpagar.Name = "txttotalpagar";
            txttotalpagar.Size = new Size(125, 27);
            txttotalpagar.TabIndex = 34;
            // 
            // btnregistrarcompra
            // 
            btnregistrarcompra.IconChar = FontAwesome.Sharp.IconChar.Tags;
            btnregistrarcompra.IconColor = Color.Teal;
            btnregistrarcompra.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnregistrarcompra.Location = new Point(1257, 616);
            btnregistrarcompra.Name = "btnregistrarcompra";
            btnregistrarcompra.Size = new Size(159, 63);
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
            ClientSize = new Size(1655, 855);
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
        private Label label2;
        private ComboBox cbotipodocumento;
        private TextBox txtfecha;
        private GroupBox groupBox2;
        private Label label5;
        private TextBox txtnombreproveedor;
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
        private NumericUpDown txtcantidad;
        private DataGridView dgvdata;
        private FontAwesome.Sharp.IconButton btnagregarproducto;
        private Label label11;
        private TextBox txttotalpagar;
        private FontAwesome.Sharp.IconButton btnregistrarcompra;
        private Label label13;
        private TextBox textcodproducto;
        private TextBox txtivaProducto;
        private Label lbliva;
        private ListBox lbnombreproducto;
        private ListBox lbcodproducto;
        private ListBox lbnombreproveedor;
        private DataGridViewTextBoxColumn idproducto;
        private DataGridViewButtonColumn btneliminar;
        private DataGridViewTextBoxColumn Producto;
        private DataGridViewTextBoxColumn PrecioCompra;
        private DataGridViewTextBoxColumn PrecioVenta;
        private DataGridViewTextBoxColumn Cantidad;
        private DataGridViewTextBoxColumn SubTotalBruto;
        private DataGridViewTextBoxColumn MontoIVA;
    }
}