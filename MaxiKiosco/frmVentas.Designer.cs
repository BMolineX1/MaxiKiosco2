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
            label16 = new Label();
            cbotipodocumento = new ComboBox();
            label4 = new Label();
            label3 = new Label();
            txtfechaventa = new TextBox();
            groupBox2 = new GroupBox();
            txtcondicioniva = new TextBox();
            label17 = new Label();
            txtapellidocliente = new TextBox();
            txtnombrecliente = new TextBox();
            txtnumerodocumentocliente = new TextBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            lbapellido = new ListBox();
            txtcantidadproducto = new GroupBox();
            lbproductobusqueda = new ListBox();
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
            lbnumerodocumento = new ListBox();
            lbnombre = new ListBox();
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
            label1.Location = new Point(185, 36);
            label1.Name = "label1";
            label1.Size = new Size(1485, 757);
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
            groupBox1.Controls.Add(label16);
            groupBox1.Controls.Add(cbotipodocumento);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtfechaventa);
            groupBox1.Location = new Point(238, 97);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(614, 140);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Informacion Venta";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(405, 49);
            label16.Name = "label16";
            label16.Size = new Size(100, 20);
            label16.TabIndex = 6;
            label16.Text = "Tipo de Pago:";
            // 
            // cbotipodocumento
            // 
            cbotipodocumento.Enabled = false;
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
            txtfechaventa.Enabled = false;
            txtfechaventa.Location = new Point(6, 72);
            txtfechaventa.Name = "txtfechaventa";
            txtfechaventa.Size = new Size(162, 27);
            txtfechaventa.TabIndex = 3;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.White;
            groupBox2.Controls.Add(txtcondicioniva);
            groupBox2.Controls.Add(label17);
            groupBox2.Controls.Add(txtapellidocliente);
            groupBox2.Controls.Add(txtnombrecliente);
            groupBox2.Controls.Add(txtnumerodocumentocliente);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(label5);
            groupBox2.Location = new Point(870, 96);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(785, 141);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Informacion Cliente:";
            // 
            // txtcondicioniva
            // 
            txtcondicioniva.Location = new Point(607, 75);
            txtcondicioniva.Name = "txtcondicioniva";
            txtcondicioniva.ReadOnly = true;
            txtcondicioniva.Size = new Size(160, 27);
            txtcondicioniva.TabIndex = 7;
            txtcondicioniva.TabStop = false;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(607, 48);
            label17.Name = "label17";
            label17.Size = new Size(102, 20);
            label17.TabIndex = 6;
            label17.Text = "Condicion IVA";
            // 
            // txtapellidocliente
            // 
            txtapellidocliente.Location = new Point(399, 75);
            txtapellidocliente.Name = "txtapellidocliente";
            txtapellidocliente.Size = new Size(183, 27);
            txtapellidocliente.TabIndex = 5;
            // 
            // txtnombrecliente
            // 
            txtnombrecliente.Location = new Point(191, 75);
            txtnombrecliente.Name = "txtnombrecliente";
            txtnombrecliente.Size = new Size(171, 27);
            txtnombrecliente.TabIndex = 4;
            // 
            // txtnumerodocumentocliente
            // 
            txtnumerodocumentocliente.Location = new Point(6, 75);
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
            label6.Location = new Point(191, 49);
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
            // lbapellido
            // 
            lbapellido.FormattingEnabled = true;
            lbapellido.Location = new Point(1269, 204);
            lbapellido.Name = "lbapellido";
            lbapellido.Size = new Size(183, 104);
            lbapellido.TabIndex = 6;
            // 
            // txtcantidadproducto
            // 
            txtcantidadproducto.BackColor = SystemColors.ButtonHighlight;
            txtcantidadproducto.Controls.Add(lbproductobusqueda);
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
            txtcantidadproducto.Location = new Point(238, 243);
            txtcantidadproducto.Name = "txtcantidadproducto";
            txtcantidadproducto.Size = new Size(1095, 231);
            txtcantidadproducto.TabIndex = 32;
            txtcantidadproducto.TabStop = false;
            txtcantidadproducto.Text = "Informacion de Producto";
            // 
            // lbproductobusqueda
            // 
            lbproductobusqueda.FormattingEnabled = true;
            lbproductobusqueda.Location = new Point(354, 128);
            lbproductobusqueda.Name = "lbproductobusqueda";
            lbproductobusqueda.Size = new Size(246, 104);
            lbproductobusqueda.TabIndex = 41;
            // 
            // txtcantidad
            // 
            txtcantidad.Location = new Point(52, 101);
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
            label10.Location = new Point(52, 78);
            label10.Name = "label10";
            label10.Size = new Size(69, 20);
            label10.TabIndex = 42;
            label10.Text = "Cantidad";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(765, 78);
            label9.Name = "label9";
            label9.Size = new Size(121, 20);
            label9.TabIndex = 41;
            label9.Text = "Stock Disponible";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(626, 78);
            label8.Name = "label8";
            label8.Size = new Size(91, 20);
            label8.TabIndex = 40;
            label8.Text = "Precio Venta";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(354, 77);
            label11.Name = "label11";
            label11.Size = new Size(72, 20);
            label11.TabIndex = 39;
            label11.Text = "Producto:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(168, 77);
            label12.Name = "label12";
            label12.Size = new Size(103, 20);
            label12.TabIndex = 38;
            label12.Text = "Cod. Producto";
            // 
            // txtidproducto
            // 
            txtidproducto.Location = new Point(932, 100);
            txtidproducto.Name = "txtidproducto";
            txtidproducto.Size = new Size(41, 27);
            txtidproducto.TabIndex = 37;
            txtidproducto.Visible = false;
            // 
            // txtstock
            // 
            txtstock.BackColor = SystemColors.Control;
            txtstock.Location = new Point(765, 101);
            txtstock.Name = "txtstock";
            txtstock.Size = new Size(125, 27);
            txtstock.TabIndex = 36;
            // 
            // txtprecioproducto
            // 
            txtprecioproducto.BackColor = SystemColors.Control;
            txtprecioproducto.Location = new Point(626, 101);
            txtprecioproducto.Name = "txtprecioproducto";
            txtprecioproducto.Size = new Size(125, 27);
            txtprecioproducto.TabIndex = 35;
            // 
            // txtnombreproducto
            // 
            txtnombreproducto.BackColor = SystemColors.Control;
            txtnombreproducto.Location = new Point(354, 101);
            txtnombreproducto.Name = "txtnombreproducto";
            txtnombreproducto.Size = new Size(246, 27);
            txtnombreproducto.TabIndex = 34;
            txtnombreproducto.TextChanged += txtnombreproducto_TextChanged_1;
            // 
            // txtcodproducto
            // 
            txtcodproducto.BackColor = SystemColors.Control;
            txtcodproducto.Location = new Point(168, 100);
            txtcodproducto.Name = "txtcodproducto";
            txtcodproducto.Size = new Size(159, 27);
            txtcodproducto.TabIndex = 33;
            txtcodproducto.TextChanged += txtcodproducto_TextChanged;
            txtcodproducto.KeyDown += txtcodproducto_KeyDown;
            // 
            // dgvdata
            // 
            dgvdata.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvdata.BackgroundColor = Color.White;
            dgvdata.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvdata.Columns.AddRange(new DataGridViewColumn[] { idproducto, btneliminar, Producto, Precio, Cantidad, SubTotal });
            dgvdata.Location = new Point(238, 480);
            dgvdata.Name = "dgvdata";
            dgvdata.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvdata.RowHeadersWidth = 51;
            dgvdata.Size = new Size(1095, 296);
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
            label13.Location = new Point(1412, 497);
            label13.Name = "label13";
            label13.Size = new Size(98, 20);
            label13.TabIndex = 34;
            label13.Text = "Total a Pagar:";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.BackColor = Color.White;
            label14.Location = new Point(1412, 572);
            label14.Name = "label14";
            label14.Size = new Size(72, 20);
            label14.TabIndex = 35;
            label14.Text = "Paga con:";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.BackColor = Color.White;
            label15.Location = new Point(1412, 636);
            label15.Name = "label15";
            label15.Size = new Size(64, 20);
            label15.TabIndex = 36;
            label15.Text = "Cambio:";
            // 
            // txttotalpagar
            // 
            txttotalpagar.Location = new Point(1412, 520);
            txttotalpagar.Name = "txttotalpagar";
            txttotalpagar.ReadOnly = true;
            txttotalpagar.Size = new Size(125, 27);
            txttotalpagar.TabIndex = 37;
            // 
            // txtcambio
            // 
            txtcambio.Location = new Point(1412, 660);
            txtcambio.Name = "txtcambio";
            txtcambio.ReadOnly = true;
            txtcambio.Size = new Size(125, 27);
            txtcambio.TabIndex = 38;
            // 
            // txtpagacon
            // 
            txtpagacon.Location = new Point(1412, 594);
            txtpagacon.Name = "txtpagacon";
            txtpagacon.Size = new Size(125, 27);
            txtpagacon.TabIndex = 39;
            txtpagacon.TextChanged += txtpagacon_TextChanged;
            txtpagacon.KeyDown += txtpagacon_KeyDown;
            txtpagacon.KeyPress += txtpagacon_KeyPress;
            // 
            // btnregistrarventa
            // 
            btnregistrarventa.IconChar = FontAwesome.Sharp.IconChar.Tags;
            btnregistrarventa.IconColor = Color.Teal;
            btnregistrarventa.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnregistrarventa.Location = new Point(1412, 710);
            btnregistrarventa.Name = "btnregistrarventa";
            btnregistrarventa.Size = new Size(123, 61);
            btnregistrarventa.TabIndex = 40;
            btnregistrarventa.Text = "Crear Venta";
            btnregistrarventa.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnregistrarventa.UseVisualStyleBackColor = true;
            btnregistrarventa.Click += btnregistrarventa_Click;
            // 
            // lbnumerodocumento
            // 
            lbnumerodocumento.FormattingEnabled = true;
            lbnumerodocumento.Location = new Point(876, 204);
            lbnumerodocumento.Name = "lbnumerodocumento";
            lbnumerodocumento.Size = new Size(156, 104);
            lbnumerodocumento.TabIndex = 44;
            // 
            // lbnombre
            // 
            lbnombre.FormattingEnabled = true;
            lbnombre.Location = new Point(1061, 204);
            lbnombre.Name = "lbnombre";
            lbnombre.Size = new Size(171, 104);
            lbnombre.TabIndex = 44;
            // 
            // frmVentas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1695, 749);
            Controls.Add(lbapellido);
            Controls.Add(lbnombre);
            Controls.Add(lbnumerodocumento);
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
        private GroupBox txtcantidadproducto;
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
        private ListBox lbproductobusqueda;
        private Label label16;
        private ListBox lbapellido;
        private ListBox lbnumerodocumento;
        private ListBox lbnombre;
        private TextBox txtcondicioniva;
        private Label label17;
    }
}