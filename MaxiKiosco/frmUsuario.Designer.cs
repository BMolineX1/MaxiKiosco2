namespace MaxiKiosco
{
    partial class frmUsuario
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            txtdocumento = new TextBox();
            txtnombre = new TextBox();
            txtapellido = new TextBox();
            txttelefono = new TextBox();
            txtcorreo = new TextBox();
            txtclave = new TextBox();
            label8 = new Label();
            label9 = new Label();
            txtconfirmarclave = new TextBox();
            cboestado = new ComboBox();
            cborol = new ComboBox();
            label10 = new Label();
            Cuenta = new Label();
            txtcuenta = new TextBox();
            btnguardar = new FontAwesome.Sharp.IconButton();
            btnlimpiar = new FontAwesome.Sharp.IconButton();
            btneliminar = new FontAwesome.Sharp.IconButton();
            label11 = new Label();
            label12 = new Label();
            txtid = new TextBox();
            label13 = new Label();
            cbobusqueda = new ComboBox();
            txtbusqueda = new TextBox();
            btnlimpiarbuscador = new FontAwesome.Sharp.IconButton();
            btnbuscar = new FontAwesome.Sharp.IconButton();
            txtindice = new TextBox();
            panel1 = new Panel();
            label14 = new Label();
            chkEsProveedor = new CheckBox();
            chkEsCliente = new CheckBox();
            dgvdata = new DataGridView();
            btnseleccionar = new DataGridViewButtonColumn();
            id = new DataGridViewTextBoxColumn();
            Documento = new DataGridViewTextBoxColumn();
            Nombre = new DataGridViewTextBoxColumn();
            Apellido = new DataGridViewTextBoxColumn();
            Correo = new DataGridViewTextBoxColumn();
            NombreCuenta = new DataGridViewTextBoxColumn();
            Clave = new DataGridViewTextBoxColumn();
            Rol = new DataGridViewTextBoxColumn();
            idrol = new DataGridViewTextBoxColumn();
            Telefono = new DataGridViewTextBoxColumn();
            EstadoValor = new DataGridViewTextBoxColumn();
            Estado = new DataGridViewTextBoxColumn();
            RolesNegocio = new DataGridViewTextBoxColumn();
            EsClienteValor = new DataGridViewTextBoxColumn();
            EsProveedorValor = new DataGridViewTextBoxColumn();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvdata).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = SystemColors.HighlightText;
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.Dock = DockStyle.Left;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(275, 562);
            label1.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Location = new Point(20, 105);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 1;
            label2.Text = "Apellido";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Location = new Point(20, 55);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 2;
            label3.Text = "Nombre";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Location = new Point(20, 9);
            label4.Name = "label4";
            label4.Size = new Size(27, 15);
            label4.TabIndex = 3;
            label4.Text = "DNI";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Location = new Point(19, 152);
            label5.Name = "label5";
            label5.Size = new Size(52, 15);
            label5.TabIndex = 4;
            label5.Text = "Telefono";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Location = new Point(20, 202);
            label6.Name = "label6";
            label6.Size = new Size(105, 15);
            label6.TabIndex = 5;
            label6.Text = "Correo Electronico";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Location = new Point(20, 407);
            label7.Name = "label7";
            label7.Size = new Size(24, 15);
            label7.TabIndex = 6;
            label7.Text = "Rol";
            // 
            // txtdocumento
            // 
            txtdocumento.Location = new Point(20, 26);
            txtdocumento.Margin = new Padding(3, 2, 3, 2);
            txtdocumento.Name = "txtdocumento";
            txtdocumento.PlaceholderText = "obligatorio";
            txtdocumento.Size = new Size(202, 23);
            txtdocumento.TabIndex = 7;
            // 
            // txtnombre
            // 
            txtnombre.Location = new Point(20, 72);
            txtnombre.Margin = new Padding(3, 2, 3, 2);
            txtnombre.Name = "txtnombre";
            txtnombre.PlaceholderText = "obligatorio";
            txtnombre.Size = new Size(202, 23);
            txtnombre.TabIndex = 8;
            // 
            // txtapellido
            // 
            txtapellido.Location = new Point(20, 122);
            txtapellido.Margin = new Padding(3, 2, 3, 2);
            txtapellido.Name = "txtapellido";
            txtapellido.PlaceholderText = "obligatorio";
            txtapellido.Size = new Size(202, 23);
            txtapellido.TabIndex = 9;
            // 
            // txttelefono
            // 
            txttelefono.Location = new Point(20, 169);
            txttelefono.Margin = new Padding(3, 2, 3, 2);
            txttelefono.Name = "txttelefono";
            txttelefono.PlaceholderText = "debe tener 10 digito sin espacio";
            txttelefono.Size = new Size(202, 23);
            txttelefono.TabIndex = 10;
            // 
            // txtcorreo
            // 
            txtcorreo.Location = new Point(20, 219);
            txtcorreo.Margin = new Padding(3, 2, 3, 2);
            txtcorreo.Name = "txtcorreo";
            txtcorreo.PlaceholderText = "usuario@dominio.com";
            txtcorreo.Size = new Size(202, 23);
            txtcorreo.TabIndex = 11;
            // 
            // txtclave
            // 
            txtclave.Location = new Point(20, 320);
            txtclave.Margin = new Padding(3, 2, 3, 2);
            txtclave.Name = "txtclave";
            txtclave.PasswordChar = '*';
            txtclave.PlaceholderText = "Eje: root";
            txtclave.Size = new Size(203, 23);
            txtclave.TabIndex = 12;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Location = new Point(20, 303);
            label8.Name = "label8";
            label8.Size = new Size(67, 15);
            label8.TabIndex = 13;
            label8.Text = "Contraseña";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Location = new Point(19, 362);
            label9.Name = "label9";
            label9.Size = new Size(124, 15);
            label9.TabIndex = 15;
            label9.Text = "Confirmar Contraseña";
            // 
            // txtconfirmarclave
            // 
            txtconfirmarclave.Location = new Point(19, 379);
            txtconfirmarclave.Margin = new Padding(3, 2, 3, 2);
            txtconfirmarclave.Name = "txtconfirmarclave";
            txtconfirmarclave.PasswordChar = '*';
            txtconfirmarclave.PlaceholderText = "root";
            txtconfirmarclave.Size = new Size(203, 23);
            txtconfirmarclave.TabIndex = 14;
            // 
            // cboestado
            // 
            cboestado.DropDownStyle = ComboBoxStyle.DropDownList;
            cboestado.FormattingEnabled = true;
            cboestado.Location = new Point(19, 471);
            cboestado.Margin = new Padding(3, 2, 3, 2);
            cboestado.Name = "cboestado";
            cboestado.Size = new Size(203, 23);
            cboestado.TabIndex = 16;
            // 
            // cborol
            // 
            cborol.DropDownStyle = ComboBoxStyle.DropDownList;
            cborol.FormattingEnabled = true;
            cborol.Location = new Point(19, 424);
            cborol.Margin = new Padding(3, 2, 3, 2);
            cborol.Name = "cborol";
            cborol.Size = new Size(203, 23);
            cborol.TabIndex = 17;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Transparent;
            label10.Location = new Point(20, 454);
            label10.Name = "label10";
            label10.Size = new Size(42, 15);
            label10.TabIndex = 18;
            label10.Text = "Estado";
            // 
            // Cuenta
            // 
            Cuenta.AutoSize = true;
            Cuenta.BackColor = Color.Transparent;
            Cuenta.Location = new Point(20, 253);
            Cuenta.Name = "Cuenta";
            Cuenta.Size = new Size(45, 15);
            Cuenta.TabIndex = 19;
            Cuenta.Text = "Cuenta";
            // 
            // txtcuenta
            // 
            txtcuenta.Location = new Point(20, 270);
            txtcuenta.Margin = new Padding(3, 2, 3, 2);
            txtcuenta.Name = "txtcuenta";
            txtcuenta.PlaceholderText = "Eje: usuario";
            txtcuenta.Size = new Size(203, 23);
            txtcuenta.TabIndex = 20;
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
            btnguardar.Location = new Point(59, 478);
            btnguardar.Margin = new Padding(3, 2, 3, 2);
            btnguardar.Name = "btnguardar";
            btnguardar.Size = new Size(151, 34);
            btnguardar.TabIndex = 21;
            btnguardar.Text = "Guardar";
            btnguardar.TextAlign = ContentAlignment.MiddleRight;
            btnguardar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnguardar.UseVisualStyleBackColor = false;
            btnguardar.Click += btnguardar_Click;
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
            btnlimpiar.Location = new Point(59, 517);
            btnlimpiar.Margin = new Padding(3, 2, 3, 2);
            btnlimpiar.Name = "btnlimpiar";
            btnlimpiar.Size = new Size(151, 34);
            btnlimpiar.TabIndex = 22;
            btnlimpiar.Text = "Limpiar";
            btnlimpiar.TextAlign = ContentAlignment.MiddleRight;
            btnlimpiar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnlimpiar.UseVisualStyleBackColor = false;
            btnlimpiar.Click += btnlimpiar_Click;
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
            btneliminar.Location = new Point(59, 555);
            btneliminar.Margin = new Padding(3, 2, 3, 2);
            btneliminar.Name = "btneliminar";
            btneliminar.Size = new Size(151, 34);
            btneliminar.TabIndex = 23;
            btneliminar.Text = "Eliminar";
            btneliminar.TextAlign = ContentAlignment.MiddleRight;
            btneliminar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btneliminar.UseVisualStyleBackColor = false;
            btneliminar.Click += btneliminar_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = SystemColors.ControlLightLight;
            label11.Font = new Font("Segoe UI", 15F);
            label11.Location = new Point(24, 7);
            label11.Name = "label11";
            label11.Size = new Size(145, 28);
            label11.TabIndex = 24;
            label11.Text = "Detalle Usuario";
            // 
            // label12
            // 
            label12.BackColor = SystemColors.ControlLightLight;
            label12.Font = new Font("Segoe UI", 15F);
            label12.Location = new Point(447, 34);
            label12.Name = "label12";
            label12.Size = new Size(944, 59);
            label12.TabIndex = 26;
            label12.Text = "Lista de Usuarios";
            label12.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtid
            // 
            txtid.Location = new Point(171, 35);
            txtid.Margin = new Padding(3, 2, 3, 2);
            txtid.Name = "txtid";
            txtid.Size = new Size(33, 23);
            txtid.TabIndex = 27;
            txtid.Text = "0";
            txtid.Visible = false;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = SystemColors.ButtonHighlight;
            label13.Location = new Point(822, 59);
            label13.Name = "label13";
            label13.Size = new Size(66, 15);
            label13.TabIndex = 28;
            label13.Text = "Buscar Por:";
            // 
            // cbobusqueda
            // 
            cbobusqueda.DropDownStyle = ComboBoxStyle.DropDownList;
            cbobusqueda.FormattingEnabled = true;
            cbobusqueda.Location = new Point(898, 58);
            cbobusqueda.Margin = new Padding(3, 2, 3, 2);
            cbobusqueda.Name = "cbobusqueda";
            cbobusqueda.Size = new Size(179, 23);
            cbobusqueda.TabIndex = 29;
            // 
            // txtbusqueda
            // 
            txtbusqueda.Location = new Point(1094, 58);
            txtbusqueda.Margin = new Padding(3, 2, 3, 2);
            txtbusqueda.Name = "txtbusqueda";
            txtbusqueda.PlaceholderText = "Buscar segun el filto";
            txtbusqueda.Size = new Size(178, 23);
            txtbusqueda.TabIndex = 30;
            txtbusqueda.TextChanged += txtbusqueda_TextChanged;
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
            btnlimpiarbuscador.Location = new Point(1329, 56);
            btnlimpiarbuscador.Margin = new Padding(3, 2, 3, 2);
            btnlimpiarbuscador.Name = "btnlimpiarbuscador";
            btnlimpiarbuscador.Size = new Size(33, 22);
            btnlimpiarbuscador.TabIndex = 32;
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
            btnbuscar.Location = new Point(1291, 56);
            btnbuscar.Margin = new Padding(3, 2, 3, 2);
            btnbuscar.Name = "btnbuscar";
            btnbuscar.Size = new Size(33, 22);
            btnbuscar.TabIndex = 31;
            btnbuscar.TextAlign = ContentAlignment.MiddleRight;
            btnbuscar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnbuscar.UseVisualStyleBackColor = false;
            btnbuscar.Click += btnbuscar_Click;
            // 
            // txtindice
            // 
            txtindice.Location = new Point(208, 35);
            txtindice.Margin = new Padding(3, 2, 3, 2);
            txtindice.Name = "txtindice";
            txtindice.Size = new Size(33, 23);
            txtindice.TabIndex = 33;
            txtindice.Text = "-1";
            txtindice.Visible = false;
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.BackColor = Color.GhostWhite;
            panel1.Controls.Add(label14);
            panel1.Controls.Add(chkEsProveedor);
            panel1.Controls.Add(chkEsCliente);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(txtdocumento);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(txtnombre);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtapellido);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(txttelefono);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(txtcorreo);
            panel1.Controls.Add(Cuenta);
            panel1.Controls.Add(txtcuenta);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(txtclave);
            panel1.Controls.Add(cboestado);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(cborol);
            panel1.Controls.Add(txtconfirmarclave);
            panel1.Controls.Add(label7);
            panel1.Location = new Point(12, 59);
            panel1.Name = "panel1";
            panel1.Size = new Size(263, 402);
            panel1.TabIndex = 34;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label14.Location = new Point(90, 506);
            label14.Name = "label14";
            label14.Size = new Size(53, 15);
            label14.TabIndex = 23;
            label14.Text = "Rol Extra";
            // 
            // chkEsProveedor
            // 
            chkEsProveedor.AutoSize = true;
            chkEsProveedor.Location = new Point(128, 525);
            chkEsProveedor.Name = "chkEsProveedor";
            chkEsProveedor.Size = new Size(94, 19);
            chkEsProveedor.TabIndex = 22;
            chkEsProveedor.Text = "Es proveedor";
            chkEsProveedor.UseVisualStyleBackColor = true;
            // 
            // chkEsCliente
            // 
            chkEsCliente.AutoSize = true;
            chkEsCliente.Location = new Point(36, 525);
            chkEsCliente.Name = "chkEsCliente";
            chkEsCliente.Size = new Size(77, 19);
            chkEsCliente.TabIndex = 21;
            chkEsCliente.Text = "Es Cliente";
            chkEsCliente.UseVisualStyleBackColor = true;
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
            dgvdata.Columns.AddRange(new DataGridViewColumn[] { btnseleccionar, id, Documento, Nombre, Apellido, Correo, NombreCuenta, Clave, Rol, idrol, Telefono, EstadoValor, Estado, RolesNegocio, EsClienteValor, EsProveedorValor });
            dgvdata.GridColor = SystemColors.HighlightText;
            dgvdata.Location = new Point(447, 114);
            dgvdata.Margin = new Padding(3, 2, 3, 2);
            dgvdata.MultiSelect = false;
            dgvdata.Name = "dgvdata";
            dgvdata.ReadOnly = true;
            dgvdata.RowHeadersWidth = 51;
            dataGridViewCellStyle2.SelectionBackColor = Color.White;
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dgvdata.RowsDefaultCellStyle = dataGridViewCellStyle2;
            dgvdata.Size = new Size(907, 416);
            dgvdata.TabIndex = 35;
            dgvdata.CellContentClick += dgvdata_CellContentClick;
            dgvdata.CellPainting += dgvdata_CellContentClick;
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
            // Documento
            // 
            Documento.HeaderText = "Numero de Documento";
            Documento.MinimumWidth = 6;
            Documento.Name = "Documento";
            Documento.ReadOnly = true;
            Documento.Width = 125;
            // 
            // Nombre
            // 
            Nombre.HeaderText = "Nombre";
            Nombre.MinimumWidth = 6;
            Nombre.Name = "Nombre";
            Nombre.ReadOnly = true;
            Nombre.Width = 125;
            // 
            // Apellido
            // 
            Apellido.HeaderText = "Apellido";
            Apellido.MinimumWidth = 6;
            Apellido.Name = "Apellido";
            Apellido.ReadOnly = true;
            Apellido.Width = 125;
            // 
            // Correo
            // 
            Correo.HeaderText = "Correo";
            Correo.MinimumWidth = 6;
            Correo.Name = "Correo";
            Correo.ReadOnly = true;
            Correo.Width = 150;
            // 
            // NombreCuenta
            // 
            NombreCuenta.HeaderText = "Nombre Cuenta";
            NombreCuenta.MinimumWidth = 6;
            NombreCuenta.Name = "NombreCuenta";
            NombreCuenta.ReadOnly = true;
            NombreCuenta.Width = 125;
            // 
            // Clave
            // 
            Clave.HeaderText = "Clave";
            Clave.MinimumWidth = 6;
            Clave.Name = "Clave";
            Clave.ReadOnly = true;
            Clave.Visible = false;
            Clave.Width = 125;
            // 
            // Rol
            // 
            Rol.HeaderText = "Rol";
            Rol.MinimumWidth = 6;
            Rol.Name = "Rol";
            Rol.ReadOnly = true;
            Rol.Width = 125;
            // 
            // idrol
            // 
            idrol.HeaderText = "idrol";
            idrol.MinimumWidth = 6;
            idrol.Name = "idrol";
            idrol.ReadOnly = true;
            idrol.Visible = false;
            idrol.Width = 125;
            // 
            // Telefono
            // 
            Telefono.HeaderText = "Telefono";
            Telefono.MinimumWidth = 6;
            Telefono.Name = "Telefono";
            Telefono.ReadOnly = true;
            Telefono.Width = 125;
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
            // RolesNegocio
            // 
            RolesNegocio.HeaderText = "Rol Extra";
            RolesNegocio.Name = "RolesNegocio";
            RolesNegocio.ReadOnly = true;
            // 
            // EsClienteValor
            // 
            EsClienteValor.HeaderText = "EsClienteValor";
            EsClienteValor.Name = "EsClienteValor";
            EsClienteValor.ReadOnly = true;
            EsClienteValor.Visible = false;
            // 
            // EsProveedorValor
            // 
            EsProveedorValor.HeaderText = "EsProveedorValor";
            EsProveedorValor.Name = "EsProveedorValor";
            EsProveedorValor.ReadOnly = true;
            EsProveedorValor.Visible = false;
            // 
            // frmUsuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(1199, 562);
            Controls.Add(dgvdata);
            Controls.Add(panel1);
            Controls.Add(txtindice);
            Controls.Add(btnlimpiarbuscador);
            Controls.Add(btnbuscar);
            Controls.Add(txtbusqueda);
            Controls.Add(cbobusqueda);
            Controls.Add(label13);
            Controls.Add(txtid);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(btneliminar);
            Controls.Add(btnlimpiar);
            Controls.Add(btnguardar);
            Controls.Add(label1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "frmUsuario";
            Text = "frmUsuario";
            Load += frmUsuario_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvdata).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox txtdocumento;
        private TextBox txtnombre;
        private TextBox txtapellido;
        private TextBox txttelefono;
        private TextBox txtcorreo;
        private TextBox txtclave;
        private Label label8;
        private Label label9;
        private TextBox txtconfirmarclave;
        private ComboBox cboestado;
        private ComboBox cborol;
        private Label label10;
        private Label Cuenta;
        private TextBox txtcuenta;
        private FontAwesome.Sharp.IconButton btnguardar;
        private FontAwesome.Sharp.IconButton btnlimpiar;
        private FontAwesome.Sharp.IconButton btneliminar;
        private Label label11;
        private Label label12;
        private TextBox txtid;
        private Label label13;
        private ComboBox cbobusqueda;
        private TextBox txtbusqueda;
        private FontAwesome.Sharp.IconButton btnlimpiarbuscador;
        private FontAwesome.Sharp.IconButton btnbuscar;
        private TextBox txtindice;
        private Panel panel1;
        private CheckBox chkEsCliente;
        private CheckBox chkEsProveedor;
        private DataGridView dgvdata;
        private DataGridViewButtonColumn btnseleccionar;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn Documento;
        private DataGridViewTextBoxColumn Nombre;
        private DataGridViewTextBoxColumn Apellido;
        private DataGridViewTextBoxColumn Correo;
        private DataGridViewTextBoxColumn NombreCuenta;
        private DataGridViewTextBoxColumn Clave;
        private DataGridViewTextBoxColumn Rol;
        private DataGridViewTextBoxColumn idrol;
        private DataGridViewTextBoxColumn Telefono;
        private DataGridViewTextBoxColumn EstadoValor;
        private DataGridViewTextBoxColumn Estado;
        private DataGridViewTextBoxColumn RolesNegocio;
        private DataGridViewTextBoxColumn EsClienteValor;
        private DataGridViewTextBoxColumn EsProveedorValor;
        private Label label14;
    }
}