namespace MaxiKiosco
{
    partial class frmCategoria
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
            btnbuscar = new FontAwesome.Sharp.IconButton();
            dgvdata = new DataGridView();
            btnseleccionar = new DataGridViewButtonColumn();
            NombreDeCategoria = new DataGridViewTextBoxColumn();
            id = new DataGridViewTextBoxColumn();
            Estado = new DataGridViewTextBoxColumn();
            EstadoValor = new DataGridViewTextBoxColumn();
            label11 = new Label();
            btnlimpiarbuscador = new FontAwesome.Sharp.IconButton();
            txtbusqueda = new TextBox();
            cbobusqueda = new ComboBox();
            label13 = new Label();
            txtid = new TextBox();
            label12 = new Label();
            txtindice = new TextBox();
            btneliminar = new FontAwesome.Sharp.IconButton();
            btnlimpiar = new FontAwesome.Sharp.IconButton();
            btnguardar = new FontAwesome.Sharp.IconButton();
            label10 = new Label();
            cboestado = new ComboBox();
            txtdocumento = new TextBox();
            label4 = new Label();
            label14 = new Label();
            btnbuscar2 = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)dgvdata).BeginInit();
            SuspendLayout();
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
            btnbuscar.Location = new Point(1206, -258);
            btnbuscar.Margin = new Padding(3, 2, 3, 2);
            btnbuscar.Name = "btnbuscar";
            btnbuscar.Size = new Size(33, 22);
            btnbuscar.TabIndex = 65;
            btnbuscar.TextAlign = ContentAlignment.MiddleRight;
            btnbuscar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnbuscar.UseVisualStyleBackColor = false;
            // 
            // dgvdata
            // 
            dgvdata.AllowUserToAddRows = false;
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
            dgvdata.Columns.AddRange(new DataGridViewColumn[] { btnseleccionar, NombreDeCategoria, id, Estado, EstadoValor });
            dgvdata.Location = new Point(434, 106);
            dgvdata.Margin = new Padding(3, 2, 3, 2);
            dgvdata.MultiSelect = false;
            dgvdata.Name = "dgvdata";
            dgvdata.ReadOnly = true;
            dgvdata.RowHeadersWidth = 51;
            dataGridViewCellStyle2.SelectionBackColor = Color.White;
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dgvdata.RowsDefaultCellStyle = dataGridViewCellStyle2;
            dgvdata.Size = new Size(944, 250);
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
            // NombreDeCategoria
            // 
            NombreDeCategoria.HeaderText = "Nombre  De Categoria";
            NombreDeCategoria.MinimumWidth = 6;
            NombreDeCategoria.Name = "NombreDeCategoria";
            NombreDeCategoria.ReadOnly = true;
            NombreDeCategoria.Width = 125;
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
            // Estado
            // 
            Estado.HeaderText = "Estado";
            Estado.MinimumWidth = 6;
            Estado.Name = "Estado";
            Estado.ReadOnly = true;
            Estado.Width = 125;
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
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = SystemColors.ControlLightLight;
            label11.Font = new Font("Segoe UI", 15F);
            label11.Location = new Point(38, 7);
            label11.Name = "label11";
            label11.Size = new Size(163, 28);
            label11.TabIndex = 58;
            label11.Text = "Detalle Categoria";
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
            btnlimpiarbuscador.Location = new Point(1245, 56);
            btnlimpiarbuscador.Margin = new Padding(3, 2, 3, 2);
            btnlimpiarbuscador.Name = "btnlimpiarbuscador";
            btnlimpiarbuscador.Size = new Size(33, 22);
            btnlimpiarbuscador.TabIndex = 66;
            btnlimpiarbuscador.TextAlign = ContentAlignment.MiddleRight;
            btnlimpiarbuscador.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnlimpiarbuscador.UseVisualStyleBackColor = false;
            btnlimpiarbuscador.Click += btnlimpiarbuscador_Click;
            // 
            // txtbusqueda
            // 
            txtbusqueda.Location = new Point(1010, 58);
            txtbusqueda.Margin = new Padding(3, 2, 3, 2);
            txtbusqueda.Name = "txtbusqueda";
            txtbusqueda.PlaceholderText = "Buscar por Nombre";
            txtbusqueda.Size = new Size(178, 23);
            txtbusqueda.TabIndex = 64;
            txtbusqueda.Click += txtbusqueda_Click;
            txtbusqueda.TextChanged += txtbusqueda_TextChanged;
            // 
            // cbobusqueda
            // 
            cbobusqueda.DropDownStyle = ComboBoxStyle.DropDownList;
            cbobusqueda.FormattingEnabled = true;
            cbobusqueda.Location = new Point(814, 58);
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
            label13.Location = new Point(738, 59);
            label13.Name = "label13";
            label13.Size = new Size(66, 15);
            label13.TabIndex = 62;
            label13.Text = "Buscar Por:";
            // 
            // txtid
            // 
            txtid.Location = new Point(158, 35);
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
            label12.Location = new Point(434, 34);
            label12.Name = "label12";
            label12.Size = new Size(944, 59);
            label12.TabIndex = 60;
            label12.Text = "Lista de Categorias";
            label12.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtindice
            // 
            txtindice.Location = new Point(195, 35);
            txtindice.Margin = new Padding(3, 2, 3, 2);
            txtindice.Name = "txtindice";
            txtindice.Size = new Size(33, 23);
            txtindice.TabIndex = 67;
            txtindice.Text = "-1";
            txtindice.Visible = false;
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
            btneliminar.Location = new Point(62, 261);
            btneliminar.Margin = new Padding(3, 2, 3, 2);
            btneliminar.Name = "btneliminar";
            btneliminar.Size = new Size(151, 34);
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
            btnlimpiar.Location = new Point(62, 223);
            btnlimpiar.Margin = new Padding(3, 2, 3, 2);
            btnlimpiar.Name = "btnlimpiar";
            btnlimpiar.Size = new Size(151, 34);
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
            btnguardar.Location = new Point(62, 184);
            btnguardar.Margin = new Padding(3, 2, 3, 2);
            btnguardar.Name = "btnguardar";
            btnguardar.Size = new Size(151, 34);
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
            label10.BackColor = SystemColors.ControlLightLight;
            label10.Location = new Point(40, 109);
            label10.Name = "label10";
            label10.Size = new Size(42, 15);
            label10.TabIndex = 52;
            label10.Text = "Estado";
            // 
            // cboestado
            // 
            cboestado.DropDownStyle = ComboBoxStyle.DropDownList;
            cboestado.FormattingEnabled = true;
            cboestado.Location = new Point(37, 126);
            cboestado.Margin = new Padding(3, 2, 3, 2);
            cboestado.Name = "cboestado";
            cboestado.Size = new Size(203, 23);
            cboestado.TabIndex = 50;
            // 
            // txtdocumento
            // 
            txtdocumento.Location = new Point(38, 81);
            txtdocumento.Margin = new Padding(3, 2, 3, 2);
            txtdocumento.Name = "txtdocumento";
            txtdocumento.Size = new Size(202, 23);
            txtdocumento.TabIndex = 41;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = SystemColors.ControlLightLight;
            label4.Location = new Point(38, 64);
            label4.Name = "label4";
            label4.Size = new Size(121, 15);
            label4.TabIndex = 37;
            label4.Text = "Nombre de Categoria";
            // 
            // label14
            // 
            label14.BackColor = SystemColors.HighlightText;
            label14.BorderStyle = BorderStyle.FixedSingle;
            label14.Dock = DockStyle.Left;
            label14.Location = new Point(0, 0);
            label14.Name = "label14";
            label14.Size = new Size(275, 562);
            label14.TabIndex = 34;
            // 
            // btnbuscar2
            // 
            btnbuscar2.BackColor = Color.White;
            btnbuscar2.Cursor = Cursors.Hand;
            btnbuscar2.FlatAppearance.BorderColor = Color.Black;
            btnbuscar2.FlatStyle = FlatStyle.Flat;
            btnbuscar2.ForeColor = SystemColors.ControlLightLight;
            btnbuscar2.IconChar = FontAwesome.Sharp.IconChar.Search;
            btnbuscar2.IconColor = Color.Black;
            btnbuscar2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnbuscar2.IconSize = 16;
            btnbuscar2.Location = new Point(1207, 56);
            btnbuscar2.Margin = new Padding(3, 2, 3, 2);
            btnbuscar2.Name = "btnbuscar2";
            btnbuscar2.Size = new Size(33, 22);
            btnbuscar2.TabIndex = 69;
            btnbuscar2.TextAlign = ContentAlignment.MiddleRight;
            btnbuscar2.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnbuscar2.UseVisualStyleBackColor = false;
            btnbuscar2.Click += btnbuscar2_Click_1;
            // 
            // frmCategoria
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1199, 562);
            Controls.Add(btnbuscar2);
            Controls.Add(btnbuscar);
            Controls.Add(dgvdata);
            Controls.Add(label11);
            Controls.Add(btnlimpiarbuscador);
            Controls.Add(txtbusqueda);
            Controls.Add(cbobusqueda);
            Controls.Add(label13);
            Controls.Add(txtid);
            Controls.Add(label12);
            Controls.Add(txtindice);
            Controls.Add(btneliminar);
            Controls.Add(btnlimpiar);
            Controls.Add(btnguardar);
            Controls.Add(label10);
            Controls.Add(cboestado);
            Controls.Add(txtdocumento);
            Controls.Add(label4);
            Controls.Add(label14);
            Margin = new Padding(3, 2, 3, 2);
            Name = "frmCategoria";
            Text = "frmCategoria";
            Load += frmCategoria_Load;
            ((System.ComponentModel.ISupportInitialize)dgvdata).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FontAwesome.Sharp.IconButton btnbuscar;
        private DataGridView dgvdata;
        private Label label11;
        private FontAwesome.Sharp.IconButton btnlimpiarbuscador;
        private TextBox txtbusqueda;
        private ComboBox cbobusqueda;
        private Label label13;
        private TextBox txtid;
        private Label label12;
        private TextBox txtindice;
        private FontAwesome.Sharp.IconButton btneliminar;
        private FontAwesome.Sharp.IconButton btnlimpiar;
        private FontAwesome.Sharp.IconButton btnguardar;
        private Label label10;
        private ComboBox cboestado;
        private TextBox txtdocumento;
        private Label label4;
        private Label label14;
        private DataGridViewButtonColumn btnseleccionar;
        private DataGridViewTextBoxColumn NombreDeCategoria;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn Estado;
        private DataGridViewTextBoxColumn EstadoValor;
        private FontAwesome.Sharp.IconButton btnbuscar2;
    }
}