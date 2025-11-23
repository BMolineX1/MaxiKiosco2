namespace MaxiKiosco
{
    partial class frmSubaPrecio
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
            panel1 = new Panel();
            label2 = new Label();
            panel4 = new Panel();
            dgwpreview = new DataGridView();
            sproducto = new DataGridViewTextBoxColumn();
            scategoria = new DataGridViewTextBoxColumn();
            sproveedor = new DataGridViewTextBoxColumn();
            spracioactual = new DataGridViewTextBoxColumn();
            snuevoprecio = new DataGridViewTextBoxColumn();
            sporcentajeaplicado = new DataGridViewTextBoxColumn();
            panel2 = new Panel();
            label4 = new Label();
            lblPorcentajeActual = new Label();
            lblFiltro = new Label();
            comboFiltro = new ComboBox();
            lblCambio = new Label();
            numericNuevoAumento = new NumericUpDown();
            btnAplicarAumento = new Button();
            label3 = new Label();
            comboxAumentarPor = new ComboBox();
            label1 = new Label();
            txtPrecioVenta = new TextBox();
            label6 = new Label();
            panel1.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgwpreview).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericNuevoAumento).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveBorder;
            panel1.Controls.Add(label2);
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(360, 46);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1263, 696);
            panel1.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(504, 17);
            label2.Name = "label2";
            label2.Size = new Size(290, 46);
            label2.TabIndex = 1;
            label2.Text = "Gestion de Precio";
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.HighlightText;
            panel4.Controls.Add(dgwpreview);
            panel4.Location = new Point(24, 412);
            panel4.Margin = new Padding(3, 4, 3, 4);
            panel4.Name = "panel4";
            panel4.Size = new Size(1219, 239);
            panel4.TabIndex = 2;
            // 
            // dgwpreview
            // 
            dgwpreview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgwpreview.BackgroundColor = SystemColors.ControlLight;
            dgwpreview.BorderStyle = BorderStyle.None;
            dgwpreview.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgwpreview.Columns.AddRange(new DataGridViewColumn[] { sproducto, scategoria, sproveedor, spracioactual, snuevoprecio, sporcentajeaplicado });
            dgwpreview.Dock = DockStyle.Fill;
            dgwpreview.Location = new Point(0, 0);
            dgwpreview.Margin = new Padding(3, 4, 3, 4);
            dgwpreview.Name = "dgwpreview";
            dgwpreview.RowHeadersWidth = 51;
            dgwpreview.Size = new Size(1219, 239);
            dgwpreview.TabIndex = 0;
            // 
            // sproducto
            // 
            sproducto.HeaderText = "Producto";
            sproducto.MinimumWidth = 6;
            sproducto.Name = "sproducto";
            // 
            // scategoria
            // 
            scategoria.HeaderText = "Categoria";
            scategoria.MinimumWidth = 6;
            scategoria.Name = "scategoria";
            // 
            // sproveedor
            // 
            sproveedor.HeaderText = "Proveedor";
            sproveedor.MinimumWidth = 6;
            sproveedor.Name = "sproveedor";
            // 
            // spracioactual
            // 
            spracioactual.HeaderText = "Precio Actual";
            spracioactual.MinimumWidth = 6;
            spracioactual.Name = "spracioactual";
            // 
            // snuevoprecio
            // 
            snuevoprecio.HeaderText = "Nuevo Precio";
            snuevoprecio.MinimumWidth = 6;
            snuevoprecio.Name = "snuevoprecio";
            // 
            // sporcentajeaplicado
            // 
            sporcentajeaplicado.HeaderText = "Porcentaje Aplicado";
            sporcentajeaplicado.MinimumWidth = 6;
            sporcentajeaplicado.Name = "sporcentajeaplicado";
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.HighlightText;
            panel2.Controls.Add(label6);
            panel2.Controls.Add(txtPrecioVenta);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(lblPorcentajeActual);
            panel2.Controls.Add(lblFiltro);
            panel2.Controls.Add(comboFiltro);
            panel2.Controls.Add(lblCambio);
            panel2.Controls.Add(numericNuevoAumento);
            panel2.Controls.Add(btnAplicarAumento);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(comboxAumentarPor);
            panel2.Controls.Add(label1);
            panel2.Location = new Point(24, 89);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(1219, 279);
            panel2.TabIndex = 0;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(811, 11);
            label4.Name = "label4";
            label4.Size = new Size(152, 25);
            label4.TabIndex = 10;
            label4.Text = "Aumento Actual";
            // 
            // lblPorcentajeActual
            // 
            lblPorcentajeActual.AutoSize = true;
            lblPorcentajeActual.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPorcentajeActual.Location = new Point(811, 43);
            lblPorcentajeActual.Name = "lblPorcentajeActual";
            lblPorcentajeActual.Size = new Size(167, 28);
            lblPorcentajeActual.TabIndex = 9;
            lblPorcentajeActual.Text = "Procentaje actual";
            // 
            // lblFiltro
            // 
            lblFiltro.AutoSize = true;
            lblFiltro.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFiltro.Location = new Point(491, 11);
            lblFiltro.Name = "lblFiltro";
            lblFiltro.Size = new Size(183, 28);
            lblFiltro.TabIndex = 8;
            lblFiltro.Text = "Seleccione el tipo: ";
            // 
            // comboFiltro
            // 
            comboFiltro.FormattingEnabled = true;
            comboFiltro.Location = new Point(491, 43);
            comboFiltro.Margin = new Padding(3, 4, 3, 4);
            comboFiltro.Name = "comboFiltro";
            comboFiltro.Size = new Size(297, 28);
            comboFiltro.TabIndex = 7;
            comboFiltro.SelectedIndexChanged += comboFiltro_SelectedIndexChanged;
            // 
            // lblCambio
            // 
            lblCambio.AutoSize = true;
            lblCambio.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblCambio.Location = new Point(24, 240);
            lblCambio.Name = "lblCambio";
            lblCambio.Size = new Size(151, 25);
            lblCambio.TabIndex = 6;
            lblCambio.Text = "previsualizacion";
            // 
            // numericNuevoAumento
            // 
            numericNuevoAumento.Location = new Point(184, 141);
            numericNuevoAumento.Margin = new Padding(3, 4, 3, 4);
            numericNuevoAumento.Name = "numericNuevoAumento";
            numericNuevoAumento.Size = new Size(161, 27);
            numericNuevoAumento.TabIndex = 4;
            numericNuevoAumento.ValueChanged += numericNuevoAumento_ValueChanged;
            numericNuevoAumento.KeyPress += numericNuevoAumento_KeyPress;
            numericNuevoAumento.Leave += numericNuevoAumento_Leave;
            // 
            // btnAplicarAumento
            // 
            btnAplicarAumento.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAplicarAumento.Location = new Point(491, 229);
            btnAplicarAumento.Margin = new Padding(3, 4, 3, 4);
            btnAplicarAumento.Name = "btnAplicarAumento";
            btnAplicarAumento.Size = new Size(174, 37);
            btnAplicarAumento.TabIndex = 3;
            btnAplicarAumento.Text = "Aplicar aumento";
            btnAplicarAumento.UseVisualStyleBackColor = true;
            btnAplicarAumento.Click += btnAplicarAumento_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(24, 141);
            label3.Name = "label3";
            label3.Size = new Size(168, 28);
            label3.TabIndex = 2;
            label3.Text = "Nuevo Aumento:";
            // 
            // comboxAumentarPor
            // 
            comboxAumentarPor.FormattingEnabled = true;
            comboxAumentarPor.Location = new Point(184, 43);
            comboxAumentarPor.Margin = new Padding(3, 4, 3, 4);
            comboxAumentarPor.Name = "comboxAumentarPor";
            comboxAumentarPor.Size = new Size(161, 28);
            comboxAumentarPor.TabIndex = 1;
            comboxAumentarPor.SelectedIndexChanged += comboxAumentarPor_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(24, 43);
            label1.Name = "label1";
            label1.Size = new Size(151, 28);
            label1.TabIndex = 0;
            label1.Text = "Aumentar por: ";
            // 
            // txtPrecioVenta
            // 
            txtPrecioVenta.Location = new Point(631, 140);
            txtPrecioVenta.Name = "txtPrecioVenta";
            txtPrecioVenta.Size = new Size(220, 27);
            txtPrecioVenta.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(494, 139);
            label6.Name = "label6";
            label6.Size = new Size(131, 28);
            label6.TabIndex = 13;
            label6.Text = "Precio Venta:";
            // 
            // frmSubaPrecio
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1589, 707);
            Controls.Add(panel1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmSubaPrecio";
            Text = "frmSubaPrecio";
            Load += frmSubaPrecio_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgwpreview).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericNuevoAumento).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Panel panel4;
        private Label label2;
        private Label label1;
        private Label label3;
        private ComboBox comboxAumentarPor;
        private NumericUpDown numericNuevoAumento;
        private Button btnAplicarAumento;
        private Label lblCambio;
        private DataGridView dgwpreview;
        private Label lblFiltro;
        private ComboBox comboFiltro;
        private Label lblPorcentajeActual;
        private Label label4;
        private DataGridViewTextBoxColumn sproducto;
        private DataGridViewTextBoxColumn scategoria;
        private DataGridViewTextBoxColumn sproveedor;
        private DataGridViewTextBoxColumn spracioactual;
        private DataGridViewTextBoxColumn snuevoprecio;
        private DataGridViewTextBoxColumn sporcentajeaplicado;
        private Label label6;
        private TextBox txtPrecioVenta;
    }
}