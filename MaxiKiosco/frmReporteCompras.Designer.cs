namespace MaxiKiosco
{
    partial class frmReporteCompras
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
            txtfechainicio = new DateTimePicker();
            label1 = new Label();
            Re = new Label();
            label2 = new Label();
            label3 = new Label();
            txtfechafin = new DateTimePicker();
            label4 = new Label();
            btnbuscar = new FontAwesome.Sharp.IconButton();
            label5 = new Label();
            dgvdata = new DataGridView();
            FechaRegistro = new DataGridViewTextBoxColumn();
            TipoDocumento = new DataGridViewTextBoxColumn();
            NumeroDocumento = new DataGridViewTextBoxColumn();
            MontoTotal = new DataGridViewTextBoxColumn();
            UsuarioRegistro = new DataGridViewTextBoxColumn();
            DocumentoProveedor = new DataGridViewTextBoxColumn();
            RazonSocial = new DataGridViewTextBoxColumn();
            CodigoProducto = new DataGridViewTextBoxColumn();
            NombreProducto = new DataGridViewTextBoxColumn();
            Categoria = new DataGridViewTextBoxColumn();
            PrecioCompra = new DataGridViewTextBoxColumn();
            PrecioVenta = new DataGridViewTextBoxColumn();
            Cantidad = new DataGridViewTextBoxColumn();
            SubTotal = new DataGridViewTextBoxColumn();
            btnlimpiarbuscador = new FontAwesome.Sharp.IconButton();
            iconButton1 = new FontAwesome.Sharp.IconButton();
            txtbusqueda = new TextBox();
            cbobusqueda = new ComboBox();
            label13 = new Label();
            btnExportar = new FontAwesome.Sharp.IconButton();
            cboproveedor = new ComboBox();
            lbbusquedareportecompra = new ListBox();
            txttotalfiltro = new TextBox();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvdata).BeginInit();
            SuspendLayout();
            // 
            // txtfechainicio
            // 
            txtfechainicio.CustomFormat = "yyyy/MM/dd";
            txtfechainicio.Format = DateTimePickerFormat.Short;
            txtfechainicio.Location = new Point(175, 113);
            txtfechainicio.Name = "txtfechainicio";
            txtfechainicio.Size = new Size(137, 27);
            txtfechainicio.TabIndex = 0;
            // 
            // label1
            // 
            label1.BackColor = Color.White;
            label1.Location = new Point(72, 72);
            label1.Name = "label1";
            label1.Size = new Size(1805, 85);
            label1.TabIndex = 1;
            label1.Text = "label1";
            label1.Click += label1_Click;
            // 
            // Re
            // 
            Re.BackColor = Color.White;
            Re.Font = new Font("Segoe UI", 11F);
            Re.Location = new Point(69, 72);
            Re.Name = "Re";
            Re.Size = new Size(163, 27);
            Re.TabIndex = 2;
            Re.Text = "Reporte Compras";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.White;
            label2.Location = new Point(79, 113);
            label2.Name = "label2";
            label2.Size = new Size(90, 20);
            label2.TabIndex = 3;
            label2.Text = "Fecha Inicio:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.White;
            label3.Location = new Point(327, 113);
            label3.Name = "label3";
            label3.Size = new Size(73, 20);
            label3.TabIndex = 4;
            label3.Text = "Fecha Fin:";
            // 
            // txtfechafin
            // 
            txtfechafin.CustomFormat = "yyyy/MM/dd";
            txtfechafin.Format = DateTimePickerFormat.Short;
            txtfechafin.Location = new Point(415, 113);
            txtfechafin.Name = "txtfechafin";
            txtfechafin.Size = new Size(131, 27);
            txtfechafin.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.White;
            label4.Location = new Point(571, 121);
            label4.Name = "label4";
            label4.Size = new Size(77, 20);
            label4.TabIndex = 6;
            label4.Text = "Proveedor";
            // 
            // btnbuscar
            // 
            btnbuscar.BackColor = Color.White;
            btnbuscar.Cursor = Cursors.Hand;
            btnbuscar.FlatAppearance.BorderColor = Color.Black;
            btnbuscar.FlatStyle = FlatStyle.Flat;
            btnbuscar.ForeColor = SystemColors.ActiveCaptionText;
            btnbuscar.IconChar = FontAwesome.Sharp.IconChar.Search;
            btnbuscar.IconColor = Color.Black;
            btnbuscar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnbuscar.IconSize = 16;
            btnbuscar.Location = new Point(807, 112);
            btnbuscar.Name = "btnbuscar";
            btnbuscar.Size = new Size(122, 29);
            btnbuscar.TabIndex = 94;
            btnbuscar.Text = "Buscar";
            btnbuscar.TextAlign = ContentAlignment.MiddleRight;
            btnbuscar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnbuscar.UseVisualStyleBackColor = false;
            btnbuscar.Click += btnbuscar_Click;
            // 
            // label5
            // 
            label5.BackColor = Color.White;
            label5.Location = new Point(69, 173);
            label5.Name = "label5";
            label5.Size = new Size(1808, 553);
            label5.TabIndex = 95;
            // 
            // dgvdata
            // 
            dgvdata.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvdata.BackgroundColor = Color.White;
            dgvdata.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvdata.Columns.AddRange(new DataGridViewColumn[] { FechaRegistro, TipoDocumento, NumeroDocumento, MontoTotal, UsuarioRegistro, DocumentoProveedor, RazonSocial, CodigoProducto, NombreProducto, Categoria, PrecioCompra, PrecioVenta, Cantidad, SubTotal });
            dgvdata.Location = new Point(95, 251);
            dgvdata.Name = "dgvdata";
            dgvdata.RowHeadersWidth = 51;
            dgvdata.Size = new Size(1781, 388);
            dgvdata.TabIndex = 96;
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
            TipoDocumento.Visible = false;
            // 
            // NumeroDocumento
            // 
            NumeroDocumento.HeaderText = "Numero Comprobante";
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
            // DocumentoProveedor
            // 
            DocumentoProveedor.HeaderText = "Documento Proveedor";
            DocumentoProveedor.MinimumWidth = 6;
            DocumentoProveedor.Name = "DocumentoProveedor";
            // 
            // RazonSocial
            // 
            RazonSocial.HeaderText = "Razon Social";
            RazonSocial.MinimumWidth = 6;
            RazonSocial.Name = "RazonSocial";
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
            btnlimpiarbuscador.Location = new Point(674, 192);
            btnlimpiarbuscador.Name = "btnlimpiarbuscador";
            btnlimpiarbuscador.Size = new Size(38, 29);
            btnlimpiarbuscador.TabIndex = 101;
            btnlimpiarbuscador.TextAlign = ContentAlignment.MiddleRight;
            btnlimpiarbuscador.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnlimpiarbuscador.UseVisualStyleBackColor = false;
            btnlimpiarbuscador.Click += btnlimpiarbuscador_Click;
            // 
            // iconButton1
            // 
            iconButton1.BackColor = Color.White;
            iconButton1.Cursor = Cursors.Hand;
            iconButton1.FlatAppearance.BorderColor = Color.Black;
            iconButton1.FlatStyle = FlatStyle.Flat;
            iconButton1.ForeColor = SystemColors.ControlLightLight;
            iconButton1.IconChar = FontAwesome.Sharp.IconChar.Search;
            iconButton1.IconColor = Color.Black;
            iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton1.IconSize = 16;
            iconButton1.Location = new Point(630, 192);
            iconButton1.Name = "iconButton1";
            iconButton1.Size = new Size(38, 29);
            iconButton1.TabIndex = 100;
            iconButton1.TextAlign = ContentAlignment.MiddleRight;
            iconButton1.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButton1.UseVisualStyleBackColor = false;
            iconButton1.Click += iconButton1_Click;
            // 
            // txtbusqueda
            // 
            txtbusqueda.Location = new Point(405, 195);
            txtbusqueda.Name = "txtbusqueda";
            txtbusqueda.PlaceholderText = "Buscar por Nombre ";
            txtbusqueda.Size = new Size(203, 27);
            txtbusqueda.TabIndex = 99;
            // 
            // cbobusqueda
            // 
            cbobusqueda.DropDownStyle = ComboBoxStyle.DropDownList;
            cbobusqueda.FormattingEnabled = true;
            cbobusqueda.Location = new Point(181, 195);
            cbobusqueda.Name = "cbobusqueda";
            cbobusqueda.Size = new Size(204, 28);
            cbobusqueda.TabIndex = 98;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = SystemColors.ButtonHighlight;
            label13.Location = new Point(95, 197);
            label13.Name = "label13";
            label13.Size = new Size(80, 20);
            label13.TabIndex = 97;
            label13.Text = "Buscar Por:";
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
            btnExportar.Location = new Point(807, 191);
            btnExportar.Name = "btnExportar";
            btnExportar.Size = new Size(163, 31);
            btnExportar.TabIndex = 102;
            btnExportar.Text = "Descargue en excel";
            btnExportar.TextAlign = ContentAlignment.MiddleRight;
            btnExportar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnExportar.UseVisualStyleBackColor = false;
            btnExportar.Click += btnExportar_Click;
            // 
            // cboproveedor
            // 
            cboproveedor.FormattingEnabled = true;
            cboproveedor.Location = new Point(648, 113);
            cboproveedor.Name = "cboproveedor";
            cboproveedor.Size = new Size(153, 28);
            cboproveedor.TabIndex = 103;
            // 
            // lbbusquedareportecompra
            // 
            lbbusquedareportecompra.FormattingEnabled = true;
            lbbusquedareportecompra.Location = new Point(405, 231);
            lbbusquedareportecompra.Name = "lbbusquedareportecompra";
            lbbusquedareportecompra.Size = new Size(203, 104);
            lbbusquedareportecompra.TabIndex = 104;
            // 
            // txttotalfiltro
            // 
            txttotalfiltro.Location = new Point(192, 677);
            txttotalfiltro.Margin = new Padding(3, 4, 3, 4);
            txttotalfiltro.Name = "txttotalfiltro";
            txttotalfiltro.ReadOnly = true;
            txttotalfiltro.Size = new Size(119, 27);
            txttotalfiltro.TabIndex = 105;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.White;
            label6.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(72, 677);
            label6.Name = "label6";
            label6.Size = new Size(122, 28);
            label6.TabIndex = 106;
            label6.Text = "Total Monto";
            // 
            // frmReporteCompras
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1924, 993);
            Controls.Add(label6);
            Controls.Add(txttotalfiltro);
            Controls.Add(lbbusquedareportecompra);
            Controls.Add(cboproveedor);
            Controls.Add(btnExportar);
            Controls.Add(btnlimpiarbuscador);
            Controls.Add(iconButton1);
            Controls.Add(txtbusqueda);
            Controls.Add(cbobusqueda);
            Controls.Add(label13);
            Controls.Add(dgvdata);
            Controls.Add(label5);
            Controls.Add(btnbuscar);
            Controls.Add(label4);
            Controls.Add(txtfechafin);
            Controls.Add(txtfechainicio);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(Re);
            Controls.Add(label1);
            Name = "frmReporteCompras";
            Text = "frmReporteCompras";
            Load += frmReporteCompras_Load;
            ((System.ComponentModel.ISupportInitialize)dgvdata).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker txtfechainicio;
        private Label label1;
        private Label Re;
        private Label label2;
        private Label label3;
        private DateTimePicker txtfechafin;
        private Label label4;
        private FontAwesome.Sharp.IconButton btnbuscar;
        private Label label5;
        private DataGridView dgvdata;
        private FontAwesome.Sharp.IconButton btnlimpiarbuscador;
        private FontAwesome.Sharp.IconButton iconButton1;
        private TextBox txtbusqueda;
        private ComboBox cbobusqueda;
        private Label label13;
        private FontAwesome.Sharp.IconButton btnExportar;
        private ComboBox cboproveedor;
        private ListBox lbbusquedareportecompra;
        private TextBox txttotalfiltro;
        private Label label6;
        private DataGridViewTextBoxColumn FechaRegistro;
        private DataGridViewTextBoxColumn TipoDocumento;
        private DataGridViewTextBoxColumn NumeroDocumento;
        private DataGridViewTextBoxColumn MontoTotal;
        private DataGridViewTextBoxColumn UsuarioRegistro;
        private DataGridViewTextBoxColumn DocumentoProveedor;
        private DataGridViewTextBoxColumn RazonSocial;
        private DataGridViewTextBoxColumn CodigoProducto;
        private DataGridViewTextBoxColumn NombreProducto;
        private DataGridViewTextBoxColumn Categoria;
        private DataGridViewTextBoxColumn PrecioCompra;
        private DataGridViewTextBoxColumn PrecioVenta;
        private DataGridViewTextBoxColumn Cantidad;
        private DataGridViewTextBoxColumn SubTotal;
    }
}