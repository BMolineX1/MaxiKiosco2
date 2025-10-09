namespace MaxiKiosco
{
    partial class frmClientes
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
            Documento = new DataGridViewTextBoxColumn();
            Nombre = new DataGridViewTextBoxColumn();
            Apellido = new DataGridViewTextBoxColumn();
            Correo = new DataGridViewTextBoxColumn();
            Telefono = new DataGridViewTextBoxColumn();
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
            txtapellido = new TextBox();
            txtnombre = new TextBox();
            txtdocumento = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            txtdomicilio = new TextBox();
            label8 = new Label();
            txtcuit = new TextBox();
            lblcuit = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvdata).BeginInit();
            SuspendLayout();
            // 
            // txtindice
            // 
            txtindice.Location = new Point(199, 32);
            txtindice.Margin = new Padding(3, 2, 3, 2);
            txtindice.Name = "txtindice";
            txtindice.Size = new Size(33, 23);
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
            btnlimpiarbuscador.Location = new Point(1320, 52);
            btnlimpiarbuscador.Margin = new Padding(3, 2, 3, 2);
            btnlimpiarbuscador.Name = "btnlimpiarbuscador";
            btnlimpiarbuscador.Size = new Size(33, 22);
            btnlimpiarbuscador.TabIndex = 66;
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
            btnbuscar.Location = new Point(1281, 52);
            btnbuscar.Margin = new Padding(3, 2, 3, 2);
            btnbuscar.Name = "btnbuscar";
            btnbuscar.Size = new Size(33, 22);
            btnbuscar.TabIndex = 65;
            btnbuscar.TextAlign = ContentAlignment.MiddleRight;
            btnbuscar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnbuscar.UseVisualStyleBackColor = false;
            btnbuscar.Click += btnbuscar_Click;
            // 
            // txtbusqueda
            // 
            txtbusqueda.Location = new Point(1084, 54);
            txtbusqueda.Margin = new Padding(3, 2, 3, 2);
            txtbusqueda.Name = "txtbusqueda";
            txtbusqueda.PlaceholderText = "Se busca segun el filto";
            txtbusqueda.Size = new Size(178, 23);
            txtbusqueda.TabIndex = 64;
            txtbusqueda.TextChanged += txtbusqueda_TextChanged;
            // 
            // cbobusqueda
            // 
            cbobusqueda.DropDownStyle = ComboBoxStyle.DropDownList;
            cbobusqueda.FormattingEnabled = true;
            cbobusqueda.Location = new Point(888, 54);
            cbobusqueda.Margin = new Padding(3, 2, 3, 2);
            cbobusqueda.Name = "cbobusqueda";
            cbobusqueda.Size = new Size(179, 23);
            cbobusqueda.TabIndex = 63;
            cbobusqueda.SelectedIndexChanged += cbobusqueda_SelectedIndexChanged;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = SystemColors.ButtonHighlight;
            label13.Location = new Point(813, 56);
            label13.Name = "label13";
            label13.Size = new Size(66, 15);
            label13.TabIndex = 62;
            label13.Text = "Buscar Por:";
            // 
            // txtid
            // 
            txtid.Location = new Point(161, 32);
            txtid.Margin = new Padding(3, 2, 3, 2);
            txtid.Name = "txtid";
            txtid.Size = new Size(33, 23);
            txtid.TabIndex = 61;
            txtid.Text = "0";
            txtid.Visible = false;
            // 
            // label12
            // 
            label12.BackColor = SystemColors.ControlLightLight;
            label12.Font = new Font("Segoe UI", 15F);
            label12.Location = new Point(438, 30);
            label12.Name = "label12";
            label12.Size = new Size(944, 59);
            label12.TabIndex = 60;
            label12.Text = "Lista de Clientes";
            label12.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dgvdata
            // 
            dgvdata.AllowUserToAddRows = false;
            dgvdata.BackgroundColor = SystemColors.ButtonHighlight;
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
            dgvdata.Columns.AddRange(new DataGridViewColumn[] { btnseleccionar, id, Documento, Nombre, Apellido, Correo, Telefono, Domicilio, EstadoValor, Estado });
            dgvdata.GridColor = SystemColors.HighlightText;
            dgvdata.Location = new Point(438, 100);
            dgvdata.Margin = new Padding(3, 2, 3, 2);
            dgvdata.MultiSelect = false;
            dgvdata.Name = "dgvdata";
            dgvdata.ReadOnly = true;
            dgvdata.RowHeadersWidth = 51;
            dataGridViewCellStyle2.SelectionBackColor = Color.White;
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dgvdata.RowsDefaultCellStyle = dataGridViewCellStyle2;
            dgvdata.Size = new Size(877, 416);
            dgvdata.TabIndex = 59;
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
            // Telefono
            // 
            Telefono.HeaderText = "Telefono";
            Telefono.MinimumWidth = 6;
            Telefono.Name = "Telefono";
            Telefono.ReadOnly = true;
            Telefono.Width = 125;
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
            label11.Location = new Point(15, 3);
            label11.Name = "label11";
            label11.Size = new Size(138, 28);
            label11.TabIndex = 58;
            label11.Text = "Detalle Cliente";
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
            btneliminar.Location = new Point(58, 482);
            btneliminar.Margin = new Padding(3, 2, 3, 2);
            btneliminar.Name = "btneliminar";
            btneliminar.Size = new Size(151, 34);
            btneliminar.TabIndex = 57;
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
            btnlimpiar.Location = new Point(58, 444);
            btnlimpiar.Margin = new Padding(3, 2, 3, 2);
            btnlimpiar.Name = "btnlimpiar";
            btnlimpiar.Size = new Size(151, 34);
            btnlimpiar.TabIndex = 56;
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
            btnguardar.Location = new Point(58, 406);
            btnguardar.Margin = new Padding(3, 2, 3, 2);
            btnguardar.Name = "btnguardar";
            btnguardar.Size = new Size(151, 34);
            btnguardar.TabIndex = 55;
            btnguardar.Text = "Guardar";
            btnguardar.TextAlign = ContentAlignment.MiddleRight;
            btnguardar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnguardar.UseVisualStyleBackColor = false;
            btnguardar.Click += btnguardar_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = SystemColors.ControlLightLight;
            label10.Location = new Point(29, 351);
            label10.Name = "label10";
            label10.Size = new Size(42, 15);
            label10.TabIndex = 52;
            label10.Text = "Estado";
            // 
            // cboestado
            // 
            cboestado.DropDownStyle = ComboBoxStyle.DropDownList;
            cboestado.FormattingEnabled = true;
            cboestado.Location = new Point(30, 368);
            cboestado.Margin = new Padding(3, 2, 3, 2);
            cboestado.Name = "cboestado";
            cboestado.Size = new Size(203, 23);
            cboestado.TabIndex = 50;
            // 
            // txtcorreo
            // 
            txtcorreo.Location = new Point(31, 326);
            txtcorreo.Margin = new Padding(3, 2, 3, 2);
            txtcorreo.Name = "txtcorreo";
            txtcorreo.Size = new Size(202, 23);
            txtcorreo.TabIndex = 45;
            // 
            // txttelefono
            // 
            txttelefono.Location = new Point(31, 242);
            txttelefono.Margin = new Padding(3, 2, 3, 2);
            txttelefono.Name = "txttelefono";
            txttelefono.Size = new Size(202, 23);
            txttelefono.TabIndex = 44;
            // 
            // txtapellido
            // 
            txtapellido.Location = new Point(30, 200);
            txtapellido.Margin = new Padding(3, 2, 3, 2);
            txtapellido.Name = "txtapellido";
            txtapellido.Size = new Size(202, 23);
            txtapellido.TabIndex = 43;
            // 
            // txtnombre
            // 
            txtnombre.Location = new Point(29, 158);
            txtnombre.Margin = new Padding(3, 2, 3, 2);
            txtnombre.Name = "txtnombre";
            txtnombre.Size = new Size(202, 23);
            txtnombre.TabIndex = 42;
            // 
            // txtdocumento
            // 
            txtdocumento.Location = new Point(30, 70);
            txtdocumento.Margin = new Padding(3, 2, 3, 2);
            txtdocumento.Name = "txtdocumento";
            txtdocumento.Size = new Size(202, 23);
            txtdocumento.TabIndex = 41;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = SystemColors.ControlLightLight;
            label6.Location = new Point(30, 309);
            label6.Name = "label6";
            label6.Size = new Size(105, 15);
            label6.TabIndex = 39;
            label6.Text = "Correo Electronico";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = SystemColors.ControlLightLight;
            label5.Location = new Point(31, 225);
            label5.Name = "label5";
            label5.Size = new Size(52, 15);
            label5.TabIndex = 38;
            label5.Text = "Telefono";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = SystemColors.ControlLightLight;
            label4.Location = new Point(30, 53);
            label4.Name = "label4";
            label4.Size = new Size(27, 15);
            label4.TabIndex = 37;
            label4.Text = "DNI";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.ControlLightLight;
            label3.Location = new Point(29, 141);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 36;
            label3.Text = "Nombre";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.ControlLightLight;
            label2.Location = new Point(30, 183);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 35;
            label2.Text = "Apellido";
            // 
            // label1
            // 
            label1.BackColor = SystemColors.HighlightText;
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.Dock = DockStyle.Left;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(275, 562);
            label1.TabIndex = 34;
            label1.Click += label1_Click;
            // 
            // txtdomicilio
            // 
            txtdomicilio.Location = new Point(31, 284);
            txtdomicilio.Margin = new Padding(3, 2, 3, 2);
            txtdomicilio.Name = "txtdomicilio";
            txtdomicilio.Size = new Size(202, 23);
            txtdomicilio.TabIndex = 69;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = SystemColors.ControlLightLight;
            label8.Location = new Point(30, 267);
            label8.Name = "label8";
            label8.Size = new Size(58, 15);
            label8.TabIndex = 68;
            label8.Text = "Domicilio";
            // 
            // txtcuit
            // 
            txtcuit.Location = new Point(29, 116);
            txtcuit.Margin = new Padding(3, 2, 3, 2);
            txtcuit.Name = "txtcuit";
            txtcuit.Size = new Size(202, 23);
            txtcuit.TabIndex = 70;
            // 
            // lblcuit
            // 
            lblcuit.AutoSize = true;
            lblcuit.BackColor = SystemColors.ControlLightLight;
            lblcuit.Location = new Point(29, 99);
            lblcuit.Name = "lblcuit";
            lblcuit.Size = new Size(32, 15);
            lblcuit.TabIndex = 71;
            lblcuit.Text = "CUIT";
            // 
            // frmClientes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1199, 562);
            Controls.Add(lblcuit);
            Controls.Add(txtcuit);
            Controls.Add(txtdomicilio);
            Controls.Add(label8);
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
            Controls.Add(btneliminar);
            Controls.Add(btnlimpiar);
            Controls.Add(btnguardar);
            Controls.Add(label10);
            Controls.Add(cboestado);
            Controls.Add(txtcorreo);
            Controls.Add(txttelefono);
            Controls.Add(txtapellido);
            Controls.Add(txtnombre);
            Controls.Add(txtdocumento);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "frmClientes";
            Text = "frmClientes";
            Load += frmClientes_Load;
            ((System.ComponentModel.ISupportInitialize)dgvdata).EndInit();
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
        private ComboBox cboestado;
        private TextBox txtcorreo;
        private TextBox txttelefono;
        private TextBox txtapellido;
        private TextBox txtnombre;
        private TextBox txtdocumento;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private DataGridViewButtonColumn btnseleccionar;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn Documento;
        private DataGridViewTextBoxColumn Nombre;
        private DataGridViewTextBoxColumn Apellido;
        private DataGridViewTextBoxColumn Correo;
        private DataGridViewTextBoxColumn Telefono;
        private DataGridViewTextBoxColumn Domicilio;
        private DataGridViewTextBoxColumn EstadoValor;
        private DataGridViewTextBoxColumn Estado;
        private TextBox txtdomicilio;
        private Label label8;
        private TextBox txtcuit;
        private Label lblcuit;
    }
}