namespace MaxiKiosco
{
    partial class frmProducto
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            txtindice = new TextBox();
            btnlimpiarbuscador = new FontAwesome.Sharp.IconButton();
            btnbuscar = new FontAwesome.Sharp.IconButton();
            txtbusqueda = new TextBox();
            cbobusqueda = new ComboBox();
            label13 = new Label();
            txtid = new TextBox();
            label12 = new Label();
            dgvdata = new DataGridView();
            btnseleccionar = new DataGridViewButtonColumn();
            id = new DataGridViewTextBoxColumn();
            Nombre = new DataGridViewTextBoxColumn();
            Codigo = new DataGridViewTextBoxColumn();
            PrecioDeCompra = new DataGridViewTextBoxColumn();
            PrecioDeVenta = new DataGridViewTextBoxColumn();
            Descripcion = new DataGridViewTextBoxColumn();
            Categoria = new DataGridViewTextBoxColumn();
            idcategoria = new DataGridViewTextBoxColumn();
            Stock = new DataGridViewTextBoxColumn();
            stockminimo = new DataGridViewTextBoxColumn();
            EstadoValor = new DataGridViewTextBoxColumn();
            Estado = new DataGridViewTextBoxColumn();
            label11 = new Label();
            btneliminar = new FontAwesome.Sharp.IconButton();
            btnlimpiar = new FontAwesome.Sharp.IconButton();
            btnguardar = new FontAwesome.Sharp.IconButton();
            label10 = new Label();
            cbocategoria = new ComboBox();
            cboestado = new ComboBox();
            txtprecioventa = new TextBox();
            txtcodigo = new TextBox();
            txtnombre = new TextBox();
            txtdocumento = new TextBox();
            label7 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            iconButton1 = new FontAwesome.Sharp.IconButton();
            iconButton2 = new FontAwesome.Sharp.IconButton();
            txtbusquedaproducto = new TextBox();
            label15 = new Label();
            txtdescripcion = new TextBox();
            label8 = new Label();
            textBox3 = new TextBox();
            txtidproducto = new TextBox();
            label9 = new Label();
            txtstock = new TextBox();
            label = new Label();
            btnLimpiarFiltro = new FontAwesome.Sharp.IconButton();
            btnExportar = new FontAwesome.Sharp.IconButton();
            panel1 = new Panel();
            label6 = new Label();
            txtstockminimo = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvdata).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // txtindice
            // 
            txtindice.Location = new Point(216, -83);
            txtindice.Name = "txtindice";
            txtindice.Size = new Size(37, 27);
            txtindice.TabIndex = 67;
            txtindice.Text = "-1";
            txtindice.Visible = false;
            // 
            // btnlimpiarbuscador
            // 
            btnlimpiarbuscador.BackColor = Color.White;
            btnlimpiarbuscador.Cursor = Cursors.Hand;
            btnlimpiarbuscador.FlatAppearance.BorderColor = Color.Black;
            btnlimpiarbuscador.FlatStyle = FlatStyle.Flat;
            btnlimpiarbuscador.ForeColor = SystemColors.ControlLightLight;
            btnlimpiarbuscador.IconChar = FontAwesome.Sharp.IconChar.BroomBall;
            btnlimpiarbuscador.IconColor = Color.Black;
            btnlimpiarbuscador.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnlimpiarbuscador.IconSize = 16;
            btnlimpiarbuscador.Location = new Point(1416, -53);
            btnlimpiarbuscador.Name = "btnlimpiarbuscador";
            btnlimpiarbuscador.Size = new Size(38, 29);
            btnlimpiarbuscador.TabIndex = 66;
            btnlimpiarbuscador.TextAlign = ContentAlignment.MiddleRight;
            btnlimpiarbuscador.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnlimpiarbuscador.UseVisualStyleBackColor = false;
            // 
            // btnbuscar
            // 
            btnbuscar.BackColor = Color.White;
            btnbuscar.Cursor = Cursors.Hand;
            btnbuscar.FlatAppearance.BorderColor = Color.Black;
            btnbuscar.FlatStyle = FlatStyle.Flat;
            btnbuscar.ForeColor = SystemColors.ControlLightLight;
            btnbuscar.IconChar = FontAwesome.Sharp.IconChar.Search;
            btnbuscar.IconColor = Color.Black;
            btnbuscar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnbuscar.IconSize = 16;
            btnbuscar.Location = new Point(1371, -55);
            btnbuscar.Name = "btnbuscar";
            btnbuscar.Size = new Size(38, 29);
            btnbuscar.TabIndex = 65;
            btnbuscar.TextAlign = ContentAlignment.MiddleRight;
            btnbuscar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnbuscar.UseVisualStyleBackColor = false;
            // 
            // txtbusqueda
            // 
            txtbusqueda.Location = new Point(1147, -52);
            txtbusqueda.Name = "txtbusqueda";
            txtbusqueda.Size = new Size(203, 27);
            txtbusqueda.TabIndex = 64;
            // 
            // cbobusqueda
            // 
            cbobusqueda.DropDownStyle = ComboBoxStyle.DropDownList;
            cbobusqueda.FormattingEnabled = true;
            cbobusqueda.Location = new Point(923, -52);
            cbobusqueda.Name = "cbobusqueda";
            cbobusqueda.Size = new Size(204, 28);
            cbobusqueda.TabIndex = 63;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = SystemColors.ButtonHighlight;
            label13.Location = new Point(837, -51);
            label13.Name = "label13";
            label13.Size = new Size(80, 20);
            label13.TabIndex = 62;
            label13.Text = "Buscar Por:";
            // 
            // txtid
            // 
            txtid.Location = new Point(173, -83);
            txtid.Name = "txtid";
            txtid.Size = new Size(37, 27);
            txtid.TabIndex = 61;
            txtid.Text = "0";
            txtid.Visible = false;
            // 
            // label12
            // 
            label12.BackColor = SystemColors.ControlLightLight;
            label12.Font = new Font("Segoe UI", 15F);
            label12.Location = new Point(489, -84);
            label12.Name = "label12";
            label12.Size = new Size(1079, 79);
            label12.TabIndex = 60;
            label12.Text = "Lista de Usuarios";
            label12.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dgvdata
            // 
            dgvdata.AllowUserToAddRows = false;
            dgvdata.BackgroundColor = Color.WhiteSmoke;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new Padding(2);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvdata.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvdata.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvdata.Columns.AddRange(new DataGridViewColumn[] { btnseleccionar, id, Nombre, Codigo, PrecioDeCompra, PrecioDeVenta, Descripcion, Categoria, idcategoria, Stock, stockminimo, EstadoValor, Estado });
            dgvdata.Location = new Point(488, 113);
            dgvdata.MultiSelect = false;
            dgvdata.Name = "dgvdata";
            dgvdata.ReadOnly = true;
            dgvdata.RowHeadersWidth = 51;
            dataGridViewCellStyle2.SelectionBackColor = Color.White;
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dgvdata.RowsDefaultCellStyle = dataGridViewCellStyle2;
            dgvdata.Size = new Size(1079, 581);
            dgvdata.TabIndex = 59;
            dgvdata.CellContentClick += dgvdata_CellContentClick;
            dgvdata.CellPainting += dgvdata_CellPainting_1;
            // 
            // btnseleccionar
            // 
            btnseleccionar.HeaderText = "";
            btnseleccionar.MinimumWidth = 6;
            btnseleccionar.Name = "btnseleccionar";
            btnseleccionar.ReadOnly = true;
            btnseleccionar.Width = 50;
            // 
            // id
            // 
            id.HeaderText = "id";
            id.MinimumWidth = 6;
            id.Name = "id";
            id.ReadOnly = true;
            id.Visible = false;
            id.Width = 125;
            // 
            // Nombre
            // 
            Nombre.HeaderText = "Nombre";
            Nombre.MinimumWidth = 6;
            Nombre.Name = "Nombre";
            Nombre.ReadOnly = true;
            Nombre.Width = 125;
            // 
            // Codigo
            // 
            Codigo.HeaderText = "Codigo";
            Codigo.MinimumWidth = 6;
            Codigo.Name = "Codigo";
            Codigo.ReadOnly = true;
            Codigo.Width = 125;
            // 
            // PrecioDeCompra
            // 
            PrecioDeCompra.HeaderText = "Precio de Compra";
            PrecioDeCompra.MinimumWidth = 6;
            PrecioDeCompra.Name = "PrecioDeCompra";
            PrecioDeCompra.ReadOnly = true;
            PrecioDeCompra.Width = 150;
            // 
            // PrecioDeVenta
            // 
            PrecioDeVenta.HeaderText = "Precio de Venta";
            PrecioDeVenta.MinimumWidth = 6;
            PrecioDeVenta.Name = "PrecioDeVenta";
            PrecioDeVenta.ReadOnly = true;
            PrecioDeVenta.Width = 125;
            // 
            // Descripcion
            // 
            Descripcion.HeaderText = "Descripcion";
            Descripcion.MinimumWidth = 6;
            Descripcion.Name = "Descripcion";
            Descripcion.ReadOnly = true;
            Descripcion.Width = 125;
            // 
            // Categoria
            // 
            Categoria.HeaderText = "Categoria";
            Categoria.MinimumWidth = 6;
            Categoria.Name = "Categoria";
            Categoria.ReadOnly = true;
            Categoria.Width = 125;
            // 
            // idcategoria
            // 
            idcategoria.HeaderText = "IdCategoria";
            idcategoria.MinimumWidth = 6;
            idcategoria.Name = "idcategoria";
            idcategoria.ReadOnly = true;
            idcategoria.Visible = false;
            idcategoria.Width = 125;
            // 
            // Stock
            // 
            Stock.HeaderText = "Stock Disponible";
            Stock.MinimumWidth = 6;
            Stock.Name = "Stock";
            Stock.ReadOnly = true;
            Stock.Width = 125;
            // 
            // stockminimo
            // 
            stockminimo.HeaderText = "Stock Minimo";
            stockminimo.MinimumWidth = 6;
            stockminimo.Name = "stockminimo";
            stockminimo.ReadOnly = true;
            stockminimo.Width = 125;
            // 
            // EstadoValor
            // 
            EstadoValor.HeaderText = "EstadoValor";
            EstadoValor.MinimumWidth = 6;
            EstadoValor.Name = "EstadoValor";
            EstadoValor.ReadOnly = true;
            EstadoValor.Visible = false;
            EstadoValor.Width = 125;
            // 
            // Estado
            // 
            Estado.HeaderText = "Estado";
            Estado.MinimumWidth = 6;
            Estado.Name = "Estado";
            Estado.ReadOnly = true;
            Estado.Width = 125;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = SystemColors.ControlLightLight;
            label11.Font = new Font("Segoe UI", 15F);
            label11.Location = new Point(6, -120);
            label11.Name = "label11";
            label11.Size = new Size(184, 35);
            label11.TabIndex = 58;
            label11.Text = "Detalle Usuario";
            // 
            // btneliminar
            // 
            btneliminar.BackColor = Color.Firebrick;
            btneliminar.Cursor = Cursors.Hand;
            btneliminar.FlatAppearance.BorderColor = Color.Black;
            btneliminar.FlatStyle = FlatStyle.Flat;
            btneliminar.ForeColor = SystemColors.ControlLightLight;
            btneliminar.IconChar = FontAwesome.Sharp.IconChar.TrashAlt;
            btneliminar.IconColor = Color.White;
            btneliminar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btneliminar.IconSize = 16;
            btneliminar.Location = new Point(42, 595);
            btneliminar.Name = "btneliminar";
            btneliminar.Size = new Size(173, 45);
            btneliminar.TabIndex = 57;
            btneliminar.Text = "Eliminar";
            btneliminar.TextAlign = ContentAlignment.MiddleRight;
            btneliminar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btneliminar.UseVisualStyleBackColor = false;
            btneliminar.Click += btneliminar_Click_1;
            // 
            // btnlimpiar
            // 
            btnlimpiar.BackColor = Color.RoyalBlue;
            btnlimpiar.Cursor = Cursors.Hand;
            btnlimpiar.FlatAppearance.BorderColor = Color.Black;
            btnlimpiar.FlatStyle = FlatStyle.Flat;
            btnlimpiar.ForeColor = SystemColors.ControlLightLight;
            btnlimpiar.IconChar = FontAwesome.Sharp.IconChar.Broom;
            btnlimpiar.IconColor = Color.White;
            btnlimpiar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnlimpiar.IconSize = 18;
            btnlimpiar.Location = new Point(42, 544);
            btnlimpiar.Name = "btnlimpiar";
            btnlimpiar.Size = new Size(173, 45);
            btnlimpiar.TabIndex = 56;
            btnlimpiar.Text = "Limpiar";
            btnlimpiar.TextAlign = ContentAlignment.MiddleRight;
            btnlimpiar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnlimpiar.UseVisualStyleBackColor = false;
            btnlimpiar.Click += btnlimpiar_Click_1;
            // 
            // btnguardar
            // 
            btnguardar.BackColor = Color.ForestGreen;
            btnguardar.Cursor = Cursors.Hand;
            btnguardar.FlatAppearance.BorderColor = Color.Black;
            btnguardar.FlatStyle = FlatStyle.Flat;
            btnguardar.ForeColor = SystemColors.ControlLightLight;
            btnguardar.IconChar = FontAwesome.Sharp.IconChar.Save;
            btnguardar.IconColor = Color.White;
            btnguardar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnguardar.IconSize = 16;
            btnguardar.Location = new Point(42, 493);
            btnguardar.Name = "btnguardar";
            btnguardar.Size = new Size(173, 45);
            btnguardar.TabIndex = 55;
            btnguardar.Text = "Guardar";
            btnguardar.TextAlign = ContentAlignment.MiddleRight;
            btnguardar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnguardar.UseVisualStyleBackColor = false;
            btnguardar.Click += btnguardar_Click_1;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Transparent;
            label10.Location = new Point(17, 413);
            label10.Name = "label10";
            label10.Size = new Size(54, 20);
            label10.TabIndex = 52;
            label10.Text = "Estado";
            // 
            // cbocategoria
            // 
            cbocategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cbocategoria.FormattingEnabled = true;
            cbocategoria.Location = new Point(11, 364);
            cbocategoria.Name = "cbocategoria";
            cbocategoria.Size = new Size(231, 28);
            cbocategoria.TabIndex = 51;
            cbocategoria.SelectedIndexChanged += cbocategoria_SelectedIndexChanged;
            // 
            // cboestado
            // 
            cboestado.DropDownStyle = ComboBoxStyle.DropDownList;
            cboestado.FormattingEnabled = true;
            cboestado.Location = new Point(11, 436);
            cboestado.Name = "cboestado";
            cboestado.Size = new Size(231, 28);
            cboestado.TabIndex = 50;
            // 
            // txtprecioventa
            // 
            txtprecioventa.Enabled = false;
            txtprecioventa.Location = new Point(11, 140);
            txtprecioventa.Name = "txtprecioventa";
            txtprecioventa.PlaceholderText = "Eje: 100,99";
            txtprecioventa.Size = new Size(230, 27);
            txtprecioventa.TabIndex = 44;
            // 
            // txtcodigo
            // 
            txtcodigo.Location = new Point(11, 25);
            txtcodigo.Name = "txtcodigo";
            txtcodigo.Size = new Size(230, 27);
            txtcodigo.TabIndex = 43;
            // 
            // txtnombre
            // 
            txtnombre.Location = new Point(11, 84);
            txtnombre.Name = "txtnombre";
            txtnombre.Size = new Size(230, 27);
            txtnombre.TabIndex = 42;
            // 
            // txtdocumento
            // 
            txtdocumento.Location = new Point(6, -29);
            txtdocumento.Name = "txtdocumento";
            txtdocumento.Size = new Size(230, 27);
            txtdocumento.TabIndex = 41;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Location = new Point(11, 341);
            label7.Name = "label7";
            label7.Size = new Size(74, 20);
            label7.TabIndex = 40;
            label7.Text = "Categoria";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Location = new Point(11, 117);
            label5.Name = "label5";
            label5.Size = new Size(112, 20);
            label5.TabIndex = 38;
            label5.Text = "Precio de Venta";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = SystemColors.ControlLightLight;
            label4.Location = new Point(7, -53);
            label4.Name = "label4";
            label4.Size = new Size(166, 20);
            label4.TabIndex = 37;
            label4.Text = "Numero de Documento";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Location = new Point(17, 61);
            label3.Name = "label3";
            label3.Size = new Size(64, 20);
            label3.TabIndex = 36;
            label3.Text = "Nombre";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Location = new Point(17, 3);
            label2.Name = "label2";
            label2.Size = new Size(97, 20);
            label2.TabIndex = 35;
            label2.Text = "Codigo Barra";
            // 
            // label1
            // 
            label1.BackColor = SystemColors.HighlightText;
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.Dock = DockStyle.Left;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(314, 683);
            label1.TabIndex = 34;
            // 
            // iconButton1
            // 
            iconButton1.BackColor = Color.White;
            iconButton1.Cursor = Cursors.Hand;
            iconButton1.FlatAppearance.BorderColor = Color.Black;
            iconButton1.FlatStyle = FlatStyle.Flat;
            iconButton1.ForeColor = SystemColors.ControlLightLight;
            iconButton1.IconChar = FontAwesome.Sharp.IconChar.BroomBall;
            iconButton1.IconColor = Color.Black;
            iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton1.IconSize = 16;
            iconButton1.Location = new Point(1415, -101);
            iconButton1.Name = "iconButton1";
            iconButton1.Size = new Size(38, 29);
            iconButton1.TabIndex = 73;
            iconButton1.TextAlign = ContentAlignment.MiddleRight;
            iconButton1.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButton1.UseVisualStyleBackColor = false;
            // 
            // iconButton2
            // 
            iconButton2.BackColor = Color.White;
            iconButton2.Cursor = Cursors.Hand;
            iconButton2.FlatAppearance.BorderColor = Color.Black;
            iconButton2.FlatStyle = FlatStyle.Flat;
            iconButton2.ForeColor = SystemColors.ControlLightLight;
            iconButton2.IconChar = FontAwesome.Sharp.IconChar.Search;
            iconButton2.IconColor = Color.Black;
            iconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton2.IconSize = 16;
            iconButton2.Location = new Point(1449, 48);
            iconButton2.Name = "iconButton2";
            iconButton2.Size = new Size(38, 29);
            iconButton2.TabIndex = 72;
            iconButton2.TextAlign = ContentAlignment.MiddleRight;
            iconButton2.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButton2.UseVisualStyleBackColor = false;
            iconButton2.Click += iconButton2_Click;
            // 
            // txtbusquedaproducto
            // 
            txtbusquedaproducto.Location = new Point(1224, 51);
            txtbusquedaproducto.Name = "txtbusquedaproducto";
            txtbusquedaproducto.PlaceholderText = "buscar por nombre/codigo";
            txtbusquedaproducto.Size = new Size(203, 27);
            txtbusquedaproducto.TabIndex = 71;
            txtbusquedaproducto.TextChanged += txtbusquedaproducto_TextChanged;
            // 
            // label15
            // 
            label15.BackColor = SystemColors.ControlLightLight;
            label15.Font = new Font("Segoe UI", 15F);
            label15.Location = new Point(488, 19);
            label15.Name = "label15";
            label15.Size = new Size(1079, 79);
            label15.TabIndex = 68;
            label15.Text = "Lista de Productos";
            label15.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtdescripcion
            // 
            txtdescripcion.Location = new Point(11, 308);
            txtdescripcion.Name = "txtdescripcion";
            txtdescripcion.Size = new Size(230, 27);
            txtdescripcion.TabIndex = 75;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Location = new Point(17, 285);
            label8.Name = "label8";
            label8.Size = new Size(87, 20);
            label8.TabIndex = 74;
            label8.Text = "Descripcion";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(251, 57);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(37, 27);
            textBox3.TabIndex = 78;
            textBox3.Text = "-1";
            textBox3.Visible = false;
            // 
            // txtidproducto
            // 
            txtidproducto.Location = new Point(209, 57);
            txtidproducto.Name = "txtidproducto";
            txtidproducto.Size = new Size(37, 27);
            txtidproducto.TabIndex = 77;
            txtidproducto.Text = "0";
            txtidproducto.Visible = false;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = SystemColors.ControlLightLight;
            label9.Font = new Font("Segoe UI", 15F);
            label9.Location = new Point(42, 19);
            label9.Name = "label9";
            label9.Size = new Size(201, 35);
            label9.TabIndex = 76;
            label9.Text = "Detalle Producto";
            // 
            // txtstock
            // 
            txtstock.Location = new Point(11, 252);
            txtstock.Name = "txtstock";
            txtstock.Size = new Size(230, 27);
            txtstock.TabIndex = 80;
            // 
            // label
            // 
            label.AutoSize = true;
            label.BackColor = Color.Transparent;
            label.Location = new Point(15, 232);
            label.Name = "label";
            label.Size = new Size(121, 20);
            label.TabIndex = 79;
            label.Text = "Stock Disponible";
            // 
            // btnLimpiarFiltro
            // 
            btnLimpiarFiltro.BackColor = Color.White;
            btnLimpiarFiltro.Cursor = Cursors.Hand;
            btnLimpiarFiltro.FlatAppearance.BorderColor = Color.Black;
            btnLimpiarFiltro.FlatStyle = FlatStyle.Flat;
            btnLimpiarFiltro.ForeColor = SystemColors.ControlLightLight;
            btnLimpiarFiltro.IconChar = FontAwesome.Sharp.IconChar.BroomBall;
            btnLimpiarFiltro.IconColor = Color.Black;
            btnLimpiarFiltro.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnLimpiarFiltro.IconSize = 16;
            btnLimpiarFiltro.Location = new Point(1493, 48);
            btnLimpiarFiltro.Name = "btnLimpiarFiltro";
            btnLimpiarFiltro.Size = new Size(38, 29);
            btnLimpiarFiltro.TabIndex = 81;
            btnLimpiarFiltro.TextAlign = ContentAlignment.MiddleRight;
            btnLimpiarFiltro.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnLimpiarFiltro.UseVisualStyleBackColor = false;
            btnLimpiarFiltro.Click += btnLimpiarFiltro_Click;
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
            btnExportar.Location = new Point(717, 51);
            btnExportar.Name = "btnExportar";
            btnExportar.Size = new Size(181, 31);
            btnExportar.TabIndex = 82;
            btnExportar.Text = "Descargue en excel";
            btnExportar.TextAlign = ContentAlignment.MiddleRight;
            btnExportar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnExportar.UseVisualStyleBackColor = false;
            btnExportar.Click += btnExportar_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.GhostWhite;
            panel1.Controls.Add(label6);
            panel1.Controls.Add(txtstockminimo);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtcodigo);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(txtstock);
            panel1.Controls.Add(txtnombre);
            panel1.Controls.Add(label);
            panel1.Controls.Add(txtdescripcion);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(txtprecioventa);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(cbocategoria);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(cboestado);
            panel1.Controls.Add(btnguardar);
            panel1.Controls.Add(btnlimpiar);
            panel1.Controls.Add(btneliminar);
            panel1.Location = new Point(27, 95);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(262, 643);
            panel1.TabIndex = 83;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(11, 173);
            label6.Name = "label6";
            label6.Size = new Size(100, 20);
            label6.TabIndex = 82;
            label6.Text = "Stock Minimo";
            // 
            // txtstockminimo
            // 
            txtstockminimo.Location = new Point(11, 197);
            txtstockminimo.Margin = new Padding(3, 4, 3, 4);
            txtstockminimo.Name = "txtstockminimo";
            txtstockminimo.Size = new Size(230, 27);
            txtstockminimo.TabIndex = 81;
            // 
            // frmProducto
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1732, 683);
            Controls.Add(panel1);
            Controls.Add(btnExportar);
            Controls.Add(btnLimpiarFiltro);
            Controls.Add(textBox3);
            Controls.Add(txtidproducto);
            Controls.Add(label9);
            Controls.Add(iconButton1);
            Controls.Add(iconButton2);
            Controls.Add(txtbusquedaproducto);
            Controls.Add(label15);
            Controls.Add(txtindice);
            Controls.Add(btnlimpiarbuscador);
            Controls.Add(btnbuscar);
            Controls.Add(txtbusqueda);
            Controls.Add(cbobusqueda);
            Controls.Add(label13);
            Controls.Add(txtid);
            Controls.Add(label12);
            Controls.Add(dgvdata);
            Controls.Add(label11);
            Controls.Add(txtdocumento);
            Controls.Add(label4);
            Controls.Add(label1);
            Name = "frmProducto";
            Text = "frmProducto";
            Load += frmProducto_Load;
            ((System.ComponentModel.ISupportInitialize)dgvdata).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtindice;
        private FontAwesome.Sharp.IconButton btnlimpiarbuscador;
        private FontAwesome.Sharp.IconButton btnbuscar;
        private TextBox txtbusqueda;
        private ComboBox cbobusqueda;
        private Label label13;
        private TextBox txtid;
        private Label label12;
        private DataGridView dgvdata;
        private Label label11;
        private FontAwesome.Sharp.IconButton btneliminar;
        private FontAwesome.Sharp.IconButton btnlimpiar;
        private FontAwesome.Sharp.IconButton btnguardar;
        private Label label10;
        private ComboBox cbocategoria;
        private ComboBox cboestado;
        private TextBox txtprecioventa;
        private TextBox txtcodigo;
        private TextBox txtnombre;
        private TextBox txtdocumento;
        private Label label7;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private FontAwesome.Sharp.IconButton iconButton1;
        private FontAwesome.Sharp.IconButton iconButton2;
        private TextBox txtbusquedaproducto;
        private Label label15;
        private TextBox txtdescripcion;
        private Label label8;
        private TextBox textBox3;
        private TextBox txtidproducto;
        private Label label9;
        private TextBox txtstock;
        private Label label;
        private FontAwesome.Sharp.IconButton btnLimpiarFiltro;
        private FontAwesome.Sharp.IconButton btnExportar;
        private Panel panel1;
        private TextBox txtstockminimo;
        private Label label6;
        private DataGridViewButtonColumn btnseleccionar;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn Nombre;
        private DataGridViewTextBoxColumn Codigo;
        private DataGridViewTextBoxColumn PrecioDeCompra;
        private DataGridViewTextBoxColumn PrecioDeVenta;
        private DataGridViewTextBoxColumn Descripcion;
        private DataGridViewTextBoxColumn Categoria;
        private DataGridViewTextBoxColumn idcategoria;
        private DataGridViewTextBoxColumn Stock;
        private DataGridViewTextBoxColumn stockminimo;
        private DataGridViewTextBoxColumn EstadoValor;
        private DataGridViewTextBoxColumn Estado;
    }
}