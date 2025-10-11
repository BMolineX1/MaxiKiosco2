namespace MaxiKiosco
{
    partial class frmProveedores
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
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            txtdomicilio = new TextBox();
            label8 = new Label();
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
            Cuit = new DataGridViewTextBoxColumn();
            Correo = new DataGridViewTextBoxColumn();
            telefono = new DataGridViewTextBoxColumn();
            Domicilio = new DataGridViewTextBoxColumn();
            EstadoValor = new DataGridViewTextBoxColumn();
            Estado = new DataGridViewTextBoxColumn();
            label11 = new Label();
            btneliminar = new FontAwesome.Sharp.IconButton();
            btnlimpiar = new FontAwesome.Sharp.IconButton();
            btnguardar = new FontAwesome.Sharp.IconButton();
            label10 = new Label();
            cboestado = new ComboBox();
            txtcorreo = new TextBox();
            txttelefono = new TextBox();
            txtnombre = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label3 = new Label();
            label1 = new Label();
            label2 = new Label();
            txtcuit = new TextBox();
            lblrazonsocial = new Label();
            txtrazonsocial = new TextBox();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvdata).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // txtdomicilio
            // 
            txtdomicilio.Location = new Point(15, 198);
            txtdomicilio.Margin = new Padding(3, 2, 3, 2);
            txtdomicilio.Name = "txtdomicilio";
            txtdomicilio.Size = new Size(202, 23);
            txtdomicilio.TabIndex = 97;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Location = new Point(24, 181);
            label8.Name = "label8";
            label8.Size = new Size(58, 15);
            label8.TabIndex = 96;
            label8.Text = "Domicilio";
            // 
            // txtindice
            // 
            txtindice.Location = new Point(198, 32);
            txtindice.Margin = new Padding(3, 2, 3, 2);
            txtindice.Name = "txtindice";
            txtindice.Size = new Size(33, 23);
            txtindice.TabIndex = 95;
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
            btnlimpiarbuscador.Location = new Point(1319, 52);
            btnlimpiarbuscador.Margin = new Padding(3, 2, 3, 2);
            btnlimpiarbuscador.Name = "btnlimpiarbuscador";
            btnlimpiarbuscador.Size = new Size(33, 22);
            btnlimpiarbuscador.TabIndex = 94;
            btnlimpiarbuscador.TextAlign = ContentAlignment.MiddleRight;
            btnlimpiarbuscador.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnlimpiarbuscador.UseVisualStyleBackColor = false;
            btnlimpiarbuscador.Click += btnlimpiarbuscador_Click;
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
            btnbuscar.Location = new Point(1280, 52);
            btnbuscar.Margin = new Padding(3, 2, 3, 2);
            btnbuscar.Name = "btnbuscar";
            btnbuscar.Size = new Size(33, 22);
            btnbuscar.TabIndex = 93;
            btnbuscar.TextAlign = ContentAlignment.MiddleRight;
            btnbuscar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnbuscar.UseVisualStyleBackColor = false;
            btnbuscar.Click += btnbuscar_Click;
            // 
            // txtbusqueda
            // 
            txtbusqueda.Location = new Point(1083, 54);
            txtbusqueda.Margin = new Padding(3, 2, 3, 2);
            txtbusqueda.Name = "txtbusqueda";
            txtbusqueda.PlaceholderText = "Buscar por Nombre ";
            txtbusqueda.Size = new Size(178, 23);
            txtbusqueda.TabIndex = 92;
            txtbusqueda.TextChanged += txtbusqueda_TextChanged;
            // 
            // cbobusqueda
            // 
            cbobusqueda.DropDownStyle = ComboBoxStyle.DropDownList;
            cbobusqueda.FormattingEnabled = true;
            cbobusqueda.Location = new Point(887, 54);
            cbobusqueda.Margin = new Padding(3, 2, 3, 2);
            cbobusqueda.Name = "cbobusqueda";
            cbobusqueda.Size = new Size(179, 23);
            cbobusqueda.TabIndex = 91;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = SystemColors.ButtonHighlight;
            label13.Location = new Point(812, 56);
            label13.Name = "label13";
            label13.Size = new Size(66, 15);
            label13.TabIndex = 90;
            label13.Text = "Buscar Por:";
            // 
            // txtid
            // 
            txtid.Location = new Point(160, 32);
            txtid.Margin = new Padding(3, 2, 3, 2);
            txtid.Name = "txtid";
            txtid.Size = new Size(33, 23);
            txtid.TabIndex = 89;
            txtid.Text = "0";
            txtid.Visible = false;
            // 
            // label12
            // 
            label12.BackColor = SystemColors.ControlLightLight;
            label12.Font = new Font("Segoe UI", 15F);
            label12.Location = new Point(437, 30);
            label12.Name = "label12";
            label12.Size = new Size(944, 59);
            label12.TabIndex = 88;
            label12.Text = "Lista de Proveedores";
            label12.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dgvdata
            // 
            dgvdata.AllowUserToAddRows = false;
            dgvdata.BackgroundColor = Color.WhiteSmoke;
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = SystemColors.Control;
            dataGridViewCellStyle9.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle9.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle9.Padding = new Padding(2);
            dataGridViewCellStyle9.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = DataGridViewTriState.True;
            dgvdata.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            dgvdata.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvdata.Columns.AddRange(new DataGridViewColumn[] { btnseleccionar, id, Nombre, Cuit, Correo, telefono, Domicilio, EstadoValor, Estado });
            dgvdata.GridColor = SystemColors.HighlightText;
            dgvdata.Location = new Point(437, 100);
            dgvdata.Margin = new Padding(3, 2, 3, 2);
            dgvdata.MultiSelect = false;
            dgvdata.Name = "dgvdata";
            dgvdata.ReadOnly = true;
            dgvdata.RowHeadersWidth = 51;
            dataGridViewCellStyle10.SelectionBackColor = Color.White;
            dataGridViewCellStyle10.SelectionForeColor = Color.Black;
            dgvdata.RowsDefaultCellStyle = dataGridViewCellStyle10;
            dgvdata.Size = new Size(877, 416);
            dgvdata.TabIndex = 87;
            dgvdata.CellContentClick += dgvdata_CellContentClick;
            dgvdata.CellPainting += dgvdata_CellPainting;
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
            id.HeaderText = "idusuario";
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
            // Cuit
            // 
            Cuit.HeaderText = "Cuit";
            Cuit.MinimumWidth = 6;
            Cuit.Name = "Cuit";
            Cuit.ReadOnly = true;
            Cuit.Width = 125;
            // 
            // Correo
            // 
            Correo.HeaderText = "Correo";
            Correo.MinimumWidth = 6;
            Correo.Name = "Correo";
            Correo.ReadOnly = true;
            Correo.Width = 150;
            // 
            // telefono
            // 
            telefono.HeaderText = "Telefono";
            telefono.MinimumWidth = 6;
            telefono.Name = "telefono";
            telefono.ReadOnly = true;
            telefono.Width = 125;
            // 
            // Domicilio
            // 
            Domicilio.HeaderText = "Domicilio";
            Domicilio.MinimumWidth = 6;
            Domicilio.Name = "Domicilio";
            Domicilio.ReadOnly = true;
            Domicilio.Width = 125;
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
            label11.Location = new Point(14, 3);
            label11.Name = "label11";
            label11.Size = new Size(187, 28);
            label11.TabIndex = 86;
            label11.Text = "Detalle Proveedores";
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
            btneliminar.Location = new Point(44, 414);
            btneliminar.Margin = new Padding(3, 2, 3, 2);
            btneliminar.Name = "btneliminar";
            btneliminar.Size = new Size(151, 34);
            btneliminar.TabIndex = 85;
            btneliminar.Text = "Eliminar";
            btneliminar.TextAlign = ContentAlignment.MiddleRight;
            btneliminar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btneliminar.UseVisualStyleBackColor = false;
            btneliminar.Click += btneliminar_Click;
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
            btnlimpiar.Location = new Point(44, 366);
            btnlimpiar.Margin = new Padding(3, 2, 3, 2);
            btnlimpiar.Name = "btnlimpiar";
            btnlimpiar.Size = new Size(151, 34);
            btnlimpiar.TabIndex = 84;
            btnlimpiar.Text = "Limpiar";
            btnlimpiar.TextAlign = ContentAlignment.MiddleRight;
            btnlimpiar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnlimpiar.UseVisualStyleBackColor = false;
            btnlimpiar.Click += btnlimpiar_Click;
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
            btnguardar.Location = new Point(44, 319);
            btnguardar.Margin = new Padding(3, 2, 3, 2);
            btnguardar.Name = "btnguardar";
            btnguardar.Size = new Size(151, 34);
            btnguardar.TabIndex = 83;
            btnguardar.Text = "Guardar";
            btnguardar.TextAlign = ContentAlignment.MiddleRight;
            btnguardar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnguardar.UseVisualStyleBackColor = false;
            btnguardar.Click += btnguardar_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Transparent;
            label10.Location = new Point(24, 265);
            label10.Name = "label10";
            label10.Size = new Size(42, 15);
            label10.TabIndex = 82;
            label10.Text = "Estado";
            // 
            // cboestado
            // 
            cboestado.DropDownStyle = ComboBoxStyle.DropDownList;
            cboestado.FormattingEnabled = true;
            cboestado.Location = new Point(15, 282);
            cboestado.Margin = new Padding(3, 2, 3, 2);
            cboestado.Name = "cboestado";
            cboestado.Size = new Size(203, 23);
            cboestado.TabIndex = 81;
            // 
            // txtcorreo
            // 
            txtcorreo.Location = new Point(15, 240);
            txtcorreo.Margin = new Padding(3, 2, 3, 2);
            txtcorreo.Name = "txtcorreo";
            txtcorreo.PlaceholderText = "proveedor@dominio.com";
            txtcorreo.Size = new Size(202, 23);
            txtcorreo.TabIndex = 80;
            // 
            // txttelefono
            // 
            txttelefono.Location = new Point(15, 156);
            txttelefono.Margin = new Padding(3, 2, 3, 2);
            txttelefono.Name = "txttelefono";
            txttelefono.PlaceholderText = "debe tener 10 digito sin espacio";
            txttelefono.Size = new Size(202, 23);
            txttelefono.TabIndex = 79;
            // 
            // txtnombre
            // 
            txtnombre.Location = new Point(15, 30);
            txtnombre.Margin = new Padding(3, 2, 3, 2);
            txtnombre.Name = "txtnombre";
            txtnombre.PlaceholderText = "obligatorio";
            txtnombre.Size = new Size(202, 23);
            txtnombre.TabIndex = 77;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Location = new Point(23, 223);
            label6.Name = "label6";
            label6.Size = new Size(105, 15);
            label6.TabIndex = 75;
            label6.Text = "Correo Electronico";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Location = new Point(23, 139);
            label5.Name = "label5";
            label5.Size = new Size(52, 15);
            label5.TabIndex = 74;
            label5.Text = "Telefono";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Location = new Point(24, 13);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 72;
            label3.Text = "Nombre";
            // 
            // label1
            // 
            label1.BackColor = SystemColors.HighlightText;
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.Dock = DockStyle.Left;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(275, 525);
            label1.TabIndex = 70;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Location = new Point(24, 97);
            label2.Name = "label2";
            label2.Size = new Size(29, 15);
            label2.TabIndex = 71;
            label2.Text = "Cuit";
            // 
            // txtcuit
            // 
            txtcuit.Location = new Point(15, 114);
            txtcuit.Margin = new Padding(3, 2, 3, 2);
            txtcuit.Name = "txtcuit";
            txtcuit.PlaceholderText = "debe tener 11 digito sin '-'";
            txtcuit.Size = new Size(202, 23);
            txtcuit.TabIndex = 78;
            // 
            // lblrazonsocial
            // 
            lblrazonsocial.AutoSize = true;
            lblrazonsocial.BackColor = Color.Transparent;
            lblrazonsocial.Location = new Point(24, 55);
            lblrazonsocial.Name = "lblrazonsocial";
            lblrazonsocial.Size = new Size(73, 15);
            lblrazonsocial.TabIndex = 98;
            lblrazonsocial.Text = "Razon Social";
            // 
            // txtrazonsocial
            // 
            txtrazonsocial.Location = new Point(15, 72);
            txtrazonsocial.Margin = new Padding(3, 2, 3, 2);
            txtrazonsocial.Name = "txtrazonsocial";
            txtrazonsocial.PlaceholderText = "Eje: Empresa S.R.L";
            txtrazonsocial.Size = new Size(202, 23);
            txtrazonsocial.TabIndex = 99;
            // 
            // panel1
            // 
            panel1.BackColor = Color.GhostWhite;
            panel1.Controls.Add(label3);
            panel1.Controls.Add(txtdomicilio);
            panel1.Controls.Add(txtrazonsocial);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(txtnombre);
            panel1.Controls.Add(lblrazonsocial);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtcuit);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(txttelefono);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(btneliminar);
            panel1.Controls.Add(txtcorreo);
            panel1.Controls.Add(btnlimpiar);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(btnguardar);
            panel1.Controls.Add(cboestado);
            panel1.Location = new Point(24, 60);
            panel1.Name = "panel1";
            panel1.Size = new Size(231, 465);
            panel1.TabIndex = 100;
            // 
            // frmProveedores
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1199, 525);
            Controls.Add(panel1);
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
            Controls.Add(label1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "frmProveedores";
            Text = "frmProveedores";
            Load += frmProveedores_Load;
            ((System.ComponentModel.ISupportInitialize)dgvdata).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtdomicilio;
        private Label label8;
        private TextBox txtindice;
        private FontAwesome.Sharp.IconButton btnlimpiarbuscador;
        private FontAwesome.Sharp.IconButton btnbuscar;
        private TextBox txtbusqueda;
        private ComboBox cbobusqueda;
        private Label label13;
        private TextBox txtid;
        private Label label12;
        private DataGridView dgvdata;
        private DataGridViewButtonColumn btnseleccionar;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn Nombre;
        private DataGridViewTextBoxColumn Cuit;
        private DataGridViewTextBoxColumn Correo;
        private DataGridViewTextBoxColumn telefono;
        private DataGridViewTextBoxColumn Domicilio;
        private DataGridViewTextBoxColumn EstadoValor;
        private DataGridViewTextBoxColumn Estado;
        private Label label11;
        private FontAwesome.Sharp.IconButton btneliminar;
        private FontAwesome.Sharp.IconButton btnlimpiar;
        private FontAwesome.Sharp.IconButton btnguardar;
        private Label label10;
        private ComboBox cboestado;
        private TextBox txtcorreo;
        private TextBox txttelefono;
        private TextBox txtnombre;
        private Label label6;
        private Label label5;
        private Label label3;
        private Label label1;
        private Label label2;
        private TextBox txtcuit;
        private Label lblrazonsocial;
        private TextBox txtrazonsocial;
        private Panel panel1;
    }
}