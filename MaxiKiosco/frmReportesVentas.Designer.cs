namespace MaxiKiosco
{
    partial class frmReportesVentas
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
            txtfechafin = new DateTimePicker();
            txtfechainicio = new DateTimePicker();
            label3 = new Label();
            label2 = new Label();
            Re = new Label();
            label1 = new Label();
            btnbuscarreporte = new FontAwesome.Sharp.IconButton();
            label4 = new Label();
            dgvdata = new DataGridView();
            btnlimpiarbuscador = new FontAwesome.Sharp.IconButton();
            btnbuscarreporteporcategoria = new FontAwesome.Sharp.IconButton();
            txtbusqueda = new TextBox();
            cbobusqueda = new ComboBox();
            label13 = new Label();
            lbbusquedareporteventa = new ListBox();
            label6 = new Label();
            txttotalfiltro = new TextBox();
            FechaRegistro = new DataGridViewTextBoxColumn();
            TipoDocumento = new DataGridViewTextBoxColumn();
            NumeroDocumento = new DataGridViewTextBoxColumn();
            MontoTotal = new DataGridViewTextBoxColumn();
            UsuarioRegistro = new DataGridViewTextBoxColumn();
            DocumentoCliente = new DataGridViewTextBoxColumn();
            NombreCliente = new DataGridViewTextBoxColumn();
            CodigoProducto = new DataGridViewTextBoxColumn();
            NombreProducto = new DataGridViewTextBoxColumn();
            Categoria = new DataGridViewTextBoxColumn();
            PrecioVenta = new DataGridViewTextBoxColumn();
            ClienteCondicionIva = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvdata).BeginInit();
            SuspendLayout();
            // 
            // txtfechafin
            // 
            txtfechafin.CustomFormat = "yyyy/MM/dd";
            txtfechafin.Format = DateTimePickerFormat.Short;
            txtfechafin.Location = new Point(386, 99);
            txtfechafin.Name = "txtfechafin";
            txtfechafin.Size = new Size(131, 27);
            txtfechafin.TabIndex = 11;
            // 
            // txtfechainicio
            // 
            txtfechainicio.CustomFormat = "yyyy/MM/dd";
            txtfechainicio.Format = DateTimePickerFormat.Short;
            txtfechainicio.Location = new Point(146, 99);
            txtfechainicio.Name = "txtfechainicio";
            txtfechainicio.Size = new Size(137, 27);
            txtfechainicio.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.White;
            label3.Location = new Point(298, 99);
            label3.Name = "label3";
            label3.Size = new Size(73, 20);
            label3.TabIndex = 10;
            label3.Text = "Fecha Fin:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.White;
            label2.Location = new Point(50, 99);
            label2.Name = "label2";
            label2.Size = new Size(90, 20);
            label2.TabIndex = 9;
            label2.Text = "Fecha Inicio:";
            // 
            // Re
            // 
            Re.BackColor = Color.White;
            Re.Font = new Font("Segoe UI", 11F);
            Re.Location = new Point(39, 57);
            Re.Name = "Re";
            Re.Size = new Size(163, 27);
            Re.TabIndex = 8;
            Re.Text = "Reporte Ventas";
            // 
            // label1
            // 
            label1.BackColor = Color.White;
            label1.Location = new Point(39, 57);
            label1.Name = "label1";
            label1.Size = new Size(1578, 85);
            label1.TabIndex = 7;
            label1.Text = "label1";
            // 
            // btnbuscarreporte
            // 
            btnbuscarreporte.BackColor = Color.White;
            btnbuscarreporte.Cursor = Cursors.Hand;
            btnbuscarreporte.FlatAppearance.BorderColor = Color.Black;
            btnbuscarreporte.FlatStyle = FlatStyle.Flat;
            btnbuscarreporte.ForeColor = SystemColors.ControlLightLight;
            btnbuscarreporte.IconChar = FontAwesome.Sharp.IconChar.Search;
            btnbuscarreporte.IconColor = Color.Black;
            btnbuscarreporte.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnbuscarreporte.IconSize = 16;
            btnbuscarreporte.Location = new Point(537, 96);
            btnbuscarreporte.Name = "btnbuscarreporte";
            btnbuscarreporte.Size = new Size(38, 29);
            btnbuscarreporte.TabIndex = 101;
            btnbuscarreporte.TextAlign = ContentAlignment.MiddleRight;
            btnbuscarreporte.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnbuscarreporte.UseVisualStyleBackColor = false;
            btnbuscarreporte.Click += btnbuscarreporte_Click;
            // 
            // label4
            // 
            label4.BackColor = Color.White;
            label4.Location = new Point(42, 189);
            label4.Name = "label4";
            label4.Size = new Size(1575, 539);
            label4.TabIndex = 102;
            // 
            // dgvdata
            // 
            dgvdata.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvdata.BackgroundColor = Color.White;
            dgvdata.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvdata.Columns.AddRange(new DataGridViewColumn[] { FechaRegistro, TipoDocumento, NumeroDocumento, MontoTotal, UsuarioRegistro, DocumentoCliente, NombreCliente, CodigoProducto, NombreProducto, Categoria, PrecioVenta, ClienteCondicionIva });
            dgvdata.Location = new Point(72, 280);
            dgvdata.Name = "dgvdata";
            dgvdata.RowHeadersWidth = 51;
            dgvdata.Size = new Size(1482, 380);
            dgvdata.TabIndex = 103;
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
            btnlimpiarbuscador.Location = new Point(651, 209);
            btnlimpiarbuscador.Name = "btnlimpiarbuscador";
            btnlimpiarbuscador.Size = new Size(38, 29);
            btnlimpiarbuscador.TabIndex = 108;
            btnlimpiarbuscador.TextAlign = ContentAlignment.MiddleRight;
            btnlimpiarbuscador.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnlimpiarbuscador.UseVisualStyleBackColor = false;
            btnlimpiarbuscador.Click += btnlimpiarbuscador_Click;
            // 
            // btnbuscarreporteporcategoria
            // 
            btnbuscarreporteporcategoria.BackColor = Color.White;
            btnbuscarreporteporcategoria.Cursor = Cursors.Hand;
            btnbuscarreporteporcategoria.FlatAppearance.BorderColor = Color.Black;
            btnbuscarreporteporcategoria.FlatStyle = FlatStyle.Flat;
            btnbuscarreporteporcategoria.ForeColor = SystemColors.ControlLightLight;
            btnbuscarreporteporcategoria.IconChar = FontAwesome.Sharp.IconChar.Search;
            btnbuscarreporteporcategoria.IconColor = Color.Black;
            btnbuscarreporteporcategoria.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnbuscarreporteporcategoria.IconSize = 16;
            btnbuscarreporteporcategoria.Location = new Point(607, 209);
            btnbuscarreporteporcategoria.Name = "btnbuscarreporteporcategoria";
            btnbuscarreporteporcategoria.Size = new Size(38, 29);
            btnbuscarreporteporcategoria.TabIndex = 107;
            btnbuscarreporteporcategoria.TextAlign = ContentAlignment.MiddleRight;
            btnbuscarreporteporcategoria.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnbuscarreporteporcategoria.UseVisualStyleBackColor = false;
            btnbuscarreporteporcategoria.Click += btnbuscarreporteporcategoria_Click;
            // 
            // txtbusqueda
            // 
            txtbusqueda.Location = new Point(382, 212);
            txtbusqueda.Name = "txtbusqueda";
            txtbusqueda.PlaceholderText = "Buscar por Nombre ";
            txtbusqueda.Size = new Size(203, 27);
            txtbusqueda.TabIndex = 106;
            // 
            // cbobusqueda
            // 
            cbobusqueda.DropDownStyle = ComboBoxStyle.DropDownList;
            cbobusqueda.FormattingEnabled = true;
            cbobusqueda.Location = new Point(158, 212);
            cbobusqueda.Name = "cbobusqueda";
            cbobusqueda.Size = new Size(204, 28);
            cbobusqueda.TabIndex = 105;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = SystemColors.ButtonHighlight;
            label13.Location = new Point(72, 215);
            label13.Name = "label13";
            label13.Size = new Size(80, 20);
            label13.TabIndex = 104;
            label13.Text = "Buscar Por:";
            // 
            // lbbusquedareporteventa
            // 
            lbbusquedareporteventa.FormattingEnabled = true;
            lbbusquedareporteventa.Location = new Point(382, 245);
            lbbusquedareporteventa.Name = "lbbusquedareporteventa";
            lbbusquedareporteventa.Size = new Size(203, 104);
            lbbusquedareporteventa.TabIndex = 109;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.White;
            label6.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(42, 684);
            label6.Name = "label6";
            label6.Size = new Size(122, 28);
            label6.TabIndex = 110;
            label6.Text = "Total Monto";
            // 
            // txttotalfiltro
            // 
            txttotalfiltro.Location = new Point(158, 684);
            txttotalfiltro.Margin = new Padding(3, 4, 3, 4);
            txttotalfiltro.Name = "txttotalfiltro";
            txttotalfiltro.ReadOnly = true;
            txttotalfiltro.Size = new Size(119, 27);
            txttotalfiltro.TabIndex = 111;
            // 
            // FechaRegistro
            // 
            FechaRegistro.HeaderText = "Fecha Registro";
            FechaRegistro.MinimumWidth = 6;
            FechaRegistro.Name = "FechaRegistro";
            // 
            // TipoDocumento
            // 
            TipoDocumento.HeaderText = "Tipo Documento";
            TipoDocumento.MinimumWidth = 6;
            TipoDocumento.Name = "TipoDocumento";
            // 
            // NumeroDocumento
            // 
            NumeroDocumento.HeaderText = "Numero Documento";
            NumeroDocumento.MinimumWidth = 6;
            NumeroDocumento.Name = "NumeroDocumento";
            // 
            // MontoTotal
            // 
            MontoTotal.HeaderText = "Monto Total";
            MontoTotal.MinimumWidth = 6;
            MontoTotal.Name = "MontoTotal";
            // 
            // UsuarioRegistro
            // 
            UsuarioRegistro.HeaderText = "Usuario Registro";
            UsuarioRegistro.MinimumWidth = 6;
            UsuarioRegistro.Name = "UsuarioRegistro";
            // 
            // DocumentoCliente
            // 
            DocumentoCliente.HeaderText = "Documento Cliente";
            DocumentoCliente.MinimumWidth = 6;
            DocumentoCliente.Name = "DocumentoCliente";
            // 
            // NombreCliente
            // 
            NombreCliente.HeaderText = "Nombre Cliente";
            NombreCliente.MinimumWidth = 6;
            NombreCliente.Name = "NombreCliente";
            // 
            // CodigoProducto
            // 
            CodigoProducto.HeaderText = "Codigo Producto";
            CodigoProducto.MinimumWidth = 6;
            CodigoProducto.Name = "CodigoProducto";
            // 
            // NombreProducto
            // 
            NombreProducto.HeaderText = "Nombre Producto";
            NombreProducto.MinimumWidth = 6;
            NombreProducto.Name = "NombreProducto";
            // 
            // Categoria
            // 
            Categoria.HeaderText = "Categoria";
            Categoria.MinimumWidth = 6;
            Categoria.Name = "Categoria";
            // 
            // PrecioVenta
            // 
            PrecioVenta.HeaderText = "Precio Venta";
            PrecioVenta.MinimumWidth = 6;
            PrecioVenta.Name = "PrecioVenta";
            // 
            // ClienteCondicionIva
            // 
            ClienteCondicionIva.HeaderText = "Condicion Iva";
            ClienteCondicionIva.MinimumWidth = 6;
            ClienteCondicionIva.Name = "ClienteCondicionIva";
            ClienteCondicionIva.ReadOnly = true;
            // 
            // frmReportesVentas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1907, 999);
            Controls.Add(txttotalfiltro);
            Controls.Add(label6);
            Controls.Add(lbbusquedareporteventa);
            Controls.Add(btnlimpiarbuscador);
            Controls.Add(btnbuscarreporteporcategoria);
            Controls.Add(txtbusqueda);
            Controls.Add(cbobusqueda);
            Controls.Add(label13);
            Controls.Add(dgvdata);
            Controls.Add(label4);
            Controls.Add(btnbuscarreporte);
            Controls.Add(txtfechafin);
            Controls.Add(txtfechainicio);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(Re);
            Controls.Add(label1);
            Name = "frmReportesVentas";
            Text = "frmReportesVentas";
            Load += frmReportesVentas_Load;
            ((System.ComponentModel.ISupportInitialize)dgvdata).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker txtfechafin;
        private DateTimePicker txtfechainicio;
        private Label label3;
        private Label label2;
        private Label Re;
        private Label label1;
        private FontAwesome.Sharp.IconButton btnbuscarreporte;
        private Label label4;
        private DataGridView dgvdata;
        private FontAwesome.Sharp.IconButton btnlimpiarbuscador;
        private FontAwesome.Sharp.IconButton btnbuscarreporteporcategoria;
        private TextBox txtbusqueda;
        private ComboBox cbobusqueda;
        private Label label13;
        private ListBox lbbusquedareporteventa;
        private Label label6;
        private TextBox txttotalfiltro;
        private DataGridViewTextBoxColumn FechaRegistro;
        private DataGridViewTextBoxColumn TipoDocumento;
        private DataGridViewTextBoxColumn NumeroDocumento;
        private DataGridViewTextBoxColumn MontoTotal;
        private DataGridViewTextBoxColumn UsuarioRegistro;
        private DataGridViewTextBoxColumn DocumentoCliente;
        private DataGridViewTextBoxColumn NombreCliente;
        private DataGridViewTextBoxColumn CodigoProducto;
        private DataGridViewTextBoxColumn NombreProducto;
        private DataGridViewTextBoxColumn Categoria;
        private DataGridViewTextBoxColumn PrecioVenta;
        private DataGridViewTextBoxColumn ClienteCondicionIva;
    }
}