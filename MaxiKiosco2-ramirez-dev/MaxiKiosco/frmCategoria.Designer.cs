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
            btnbuscar = new FontAwesome.Sharp.IconButton();
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
            txtnombreC = new TextBox();
            label4 = new Label();
            label14 = new Label();
            btnbuscar2 = new FontAwesome.Sharp.IconButton();
            txtPorcentajeAumento = new NumericUpDown();
            label1 = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            dgvdata = new DataGridView();
            btnseleccionar = new DataGridViewButtonColumn();
            NombreDeCategoria = new DataGridViewTextBoxColumn();
            Id = new DataGridViewTextBoxColumn();
            Estado = new DataGridViewTextBoxColumn();
            EstadoValor = new DataGridViewTextBoxColumn();
            PorcentajeAumento = new DataGridViewTextBoxColumn();
            lbbusquedacategoria = new ListBox();
            ((System.ComponentModel.ISupportInitialize)txtPorcentajeAumento).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
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
            btnbuscar.Location = new Point(1378, -344);
            btnbuscar.Name = "btnbuscar";
            btnbuscar.Size = new Size(38, 29);
            btnbuscar.TabIndex = 65;
            btnbuscar.TextAlign = ContentAlignment.MiddleRight;
            btnbuscar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnbuscar.UseVisualStyleBackColor = false;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = SystemColors.ControlLightLight;
            label11.Font = new Font("Segoe UI", 15F);
            label11.Location = new Point(43, 9);
            label11.Name = "label11";
            label11.Size = new Size(206, 35);
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
            btnlimpiarbuscador.Location = new Point(1282, 74);
            btnlimpiarbuscador.Name = "btnlimpiarbuscador";
            btnlimpiarbuscador.Size = new Size(38, 29);
            btnlimpiarbuscador.TabIndex = 66;
            btnlimpiarbuscador.TextAlign = ContentAlignment.MiddleRight;
            btnlimpiarbuscador.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnlimpiarbuscador.UseVisualStyleBackColor = false;
            btnlimpiarbuscador.Click += btnlimpiarbuscador_Click;
            // 
            // txtbusqueda
            // 
            txtbusqueda.Location = new Point(1029, 75);
            txtbusqueda.Name = "txtbusqueda";
            txtbusqueda.PlaceholderText = "Buscar por Nombre";
            txtbusqueda.Size = new Size(203, 27);
            txtbusqueda.TabIndex = 64;
            txtbusqueda.Click += txtbusqueda_Click;
            txtbusqueda.TextChanged += txtbusqueda_TextChanged;
            // 
            // cbobusqueda
            // 
            cbobusqueda.DropDownStyle = ComboBoxStyle.DropDownList;
            cbobusqueda.FormattingEnabled = true;
            cbobusqueda.Location = new Point(819, 75);
            cbobusqueda.Name = "cbobusqueda";
            cbobusqueda.Size = new Size(204, 28);
            cbobusqueda.TabIndex = 63;
            cbobusqueda.SelectedIndexChanged += cbobusqueda_SelectedIndexChanged;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = SystemColors.ButtonHighlight;
            label13.Location = new Point(733, 75);
            label13.Name = "label13";
            label13.Size = new Size(80, 20);
            label13.TabIndex = 62;
            label13.Text = "Buscar Por:";
            // 
            // txtid
            // 
            txtid.Location = new Point(181, 47);
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
            label12.Location = new Point(496, 45);
            label12.Name = "label12";
            label12.Size = new Size(1008, 79);
            label12.TabIndex = 60;
            label12.Text = "Lista de Categorias";
            label12.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtindice
            // 
            txtindice.Location = new Point(223, 47);
            txtindice.Name = "txtindice";
            txtindice.Size = new Size(37, 27);
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
            btneliminar.Location = new Point(47, 403);
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
            btnlimpiar.Location = new Point(47, 339);
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
            btnguardar.Location = new Point(47, 276);
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
            label10.Location = new Point(15, 184);
            label10.Name = "label10";
            label10.Size = new Size(54, 20);
            label10.TabIndex = 52;
            label10.Text = "Estado";
            // 
            // cboestado
            // 
            cboestado.DropDownStyle = ComboBoxStyle.DropDownList;
            cboestado.FormattingEnabled = true;
            cboestado.Location = new Point(15, 207);
            cboestado.Name = "cboestado";
            cboestado.Size = new Size(231, 28);
            cboestado.TabIndex = 50;
            // 
            // txtnombreC
            // 
            txtnombreC.Location = new Point(14, 53);
            txtnombreC.Name = "txtnombreC";
            txtnombreC.PlaceholderText = "obligatorio";
            txtnombreC.Size = new Size(230, 27);
            txtnombreC.TabIndex = 41;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Location = new Point(14, 31);
            label4.Name = "label4";
            label4.Size = new Size(154, 20);
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
            label14.Size = new Size(314, 749);
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
            btnbuscar2.Location = new Point(1238, 75);
            btnbuscar2.Name = "btnbuscar2";
            btnbuscar2.Size = new Size(38, 29);
            btnbuscar2.TabIndex = 69;
            btnbuscar2.TextAlign = ContentAlignment.MiddleRight;
            btnbuscar2.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnbuscar2.UseVisualStyleBackColor = false;
            btnbuscar2.Click += btnbuscar2_Click_1;
            // 
            // txtPorcentajeAumento
            // 
            txtPorcentajeAumento.Location = new Point(15, 124);
            txtPorcentajeAumento.Margin = new Padding(3, 4, 3, 4);
            txtPorcentajeAumento.Name = "txtPorcentajeAumento";
            txtPorcentajeAumento.Size = new Size(230, 27);
            txtPorcentajeAumento.TabIndex = 70;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Location = new Point(14, 100);
            label1.Name = "label1";
            label1.Size = new Size(86, 20);
            label1.TabIndex = 71;
            label1.Text = "% Aumento";
            // 
            // panel1
            // 
            panel1.Controls.Add(dgvdata);
            panel1.Location = new Point(496, 177);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1008, 556);
            panel1.TabIndex = 72;
            // 
            // panel2
            // 
            panel2.BackColor = Color.GhostWhite;
            panel2.Controls.Add(label4);
            panel2.Controls.Add(txtnombreC);
            panel2.Controls.Add(txtPorcentajeAumento);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(label10);
            panel2.Controls.Add(cboestado);
            panel2.Controls.Add(btnguardar);
            panel2.Controls.Add(btnlimpiar);
            panel2.Controls.Add(btneliminar);
            panel2.Location = new Point(14, 84);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(271, 511);
            panel2.TabIndex = 73;
            // 
            // dgvdata
            // 
            dgvdata.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvdata.BackgroundColor = Color.White;
            dgvdata.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvdata.Columns.AddRange(new DataGridViewColumn[] { btnseleccionar, NombreDeCategoria, Id, Estado, EstadoValor, PorcentajeAumento });
            dgvdata.Location = new Point(24, 31);
            dgvdata.Name = "dgvdata";
            dgvdata.RowHeadersWidth = 51;
            dgvdata.Size = new Size(964, 492);
            dgvdata.TabIndex = 74;
            // 
            // btnseleccionar
            // 
            btnseleccionar.HeaderText = "Seleccionar";
            btnseleccionar.MinimumWidth = 6;
            btnseleccionar.Name = "btnseleccionar";
            btnseleccionar.Resizable = DataGridViewTriState.True;
            btnseleccionar.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // NombreDeCategoria
            // 
            NombreDeCategoria.HeaderText = "Categoria";
            NombreDeCategoria.MinimumWidth = 6;
            NombreDeCategoria.Name = "NombreDeCategoria";
            // 
            // Id
            // 
            Id.HeaderText = "Id";
            Id.MinimumWidth = 6;
            Id.Name = "Id";
            Id.Visible = false;
            // 
            // Estado
            // 
            Estado.HeaderText = "Estado";
            Estado.MinimumWidth = 6;
            Estado.Name = "Estado";
            // 
            // EstadoValor
            // 
            EstadoValor.HeaderText = "EstadoValor";
            EstadoValor.MinimumWidth = 6;
            EstadoValor.Name = "EstadoValor";
            // 
            // PorcentajeAumento
            // 
            PorcentajeAumento.HeaderText = "Porcentaje de Aumento";
            PorcentajeAumento.MinimumWidth = 6;
            PorcentajeAumento.Name = "PorcentajeAumento";
            // 
            // lbbusquedacategoria
            // 
            lbbusquedacategoria.FormattingEnabled = true;
            lbbusquedacategoria.Location = new Point(1029, 108);
            lbbusquedacategoria.Name = "lbbusquedacategoria";
            lbbusquedacategoria.Size = new Size(203, 64);
            lbbusquedacategoria.TabIndex = 74;
            // 
            // frmCategoria
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1637, 749);
            Controls.Add(lbbusquedacategoria);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(btnbuscar2);
            Controls.Add(btnbuscar);
            Controls.Add(label11);
            Controls.Add(btnlimpiarbuscador);
            Controls.Add(txtbusqueda);
            Controls.Add(cbobusqueda);
            Controls.Add(label13);
            Controls.Add(txtid);
            Controls.Add(label12);
            Controls.Add(txtindice);
            Controls.Add(label14);
            Name = "frmCategoria";
            Text = "frmCategoria";
            Load += frmCategoria_Load;
            ((System.ComponentModel.ISupportInitialize)txtPorcentajeAumento).EndInit();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvdata).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FontAwesome.Sharp.IconButton btnbuscar;
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
        private TextBox txtnombreC;
        private Label label4;
        private Label label14;
        private FontAwesome.Sharp.IconButton btnbuscar2;
        private NumericUpDown txtPorcentajeAumento;
        private Label label1;
        private Panel panel1;
        private Panel panel2;
        private DataGridView dgvdata;
        private DataGridViewButtonColumn btnseleccionar;
        private DataGridViewTextBoxColumn NombreDeCategoria;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn Estado;
        private DataGridViewTextBoxColumn EstadoValor;
        private DataGridViewTextBoxColumn PorcentajeAumento;
        private ListBox lbbusquedacategoria;
    }
}