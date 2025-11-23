namespace MaxiKiosco.Modales
{
    partial class mdPagarProductosCC
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
            dgvPendientes = new DataGridView();
            ProductoId = new DataGridViewTextBoxColumn();
            Codigo = new DataGridViewTextBoxColumn();
            Nombre = new DataGridViewTextBoxColumn();
            Pendiente = new DataGridViewTextBoxColumn();
            PrecioVigente = new DataGridViewTextBoxColumn();
            Pagar = new DataGridViewTextBoxColumn();
            SubTotal = new DataGridViewTextBoxColumn();
            btnConfirmar = new Button();
            btnCancelar = new Button();
            groupBox1 = new GroupBox();
            lblTotal = new Label();
            lblDeudaTotal = new Label();
            txtMontoPagar = new TextBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvPendientes).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvPendientes
            // 
            dgvPendientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPendientes.BackgroundColor = Color.White;
            dgvPendientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPendientes.Columns.AddRange(new DataGridViewColumn[] { ProductoId, Codigo, Nombre, Pendiente, PrecioVigente, Pagar, SubTotal });
            dgvPendientes.Location = new Point(89, 82);
            dgvPendientes.Name = "dgvPendientes";
            dgvPendientes.RowHeadersWidth = 51;
            dgvPendientes.Size = new Size(838, 276);
            dgvPendientes.TabIndex = 0;
            // 
            // ProductoId
            // 
            ProductoId.HeaderText = "ProductoId";
            ProductoId.MinimumWidth = 6;
            ProductoId.Name = "ProductoId";
            ProductoId.Visible = false;
            // 
            // Codigo
            // 
            Codigo.HeaderText = "Codigo";
            Codigo.MinimumWidth = 6;
            Codigo.Name = "Codigo";
            // 
            // Nombre
            // 
            Nombre.HeaderText = "Nombre";
            Nombre.MinimumWidth = 6;
            Nombre.Name = "Nombre";
            // 
            // Pendiente
            // 
            Pendiente.HeaderText = "Pendiente";
            Pendiente.MinimumWidth = 6;
            Pendiente.Name = "Pendiente";
            // 
            // PrecioVigente
            // 
            PrecioVigente.HeaderText = "PrecioVigente";
            PrecioVigente.MinimumWidth = 6;
            PrecioVigente.Name = "PrecioVigente";
            // 
            // Pagar
            // 
            Pagar.HeaderText = "Pagar";
            Pagar.MinimumWidth = 6;
            Pagar.Name = "Pagar";
            // 
            // SubTotal
            // 
            SubTotal.HeaderText = "SubTotal";
            SubTotal.MinimumWidth = 6;
            SubTotal.Name = "SubTotal";
            // 
            // btnConfirmar
            // 
            btnConfirmar.Location = new Point(291, 388);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(114, 47);
            btnConfirmar.TabIndex = 1;
            btnConfirmar.Text = "Confirmar";
            btnConfirmar.UseVisualStyleBackColor = true;
            btnConfirmar.Click += btnConfirmar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(601, 388);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(94, 47);
            btnCancelar.TabIndex = 2;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.White;
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtMontoPagar);
            groupBox1.Controls.Add(lblTotal);
            groupBox1.Controls.Add(lblDeudaTotal);
            groupBox1.Controls.Add(btnCancelar);
            groupBox1.Controls.Add(btnConfirmar);
            groupBox1.Controls.Add(dgvPendientes);
            groupBox1.Location = new Point(1, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1009, 471);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Pago de Cuenta Corriente";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(824, 424);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(0, 20);
            lblTotal.TabIndex = 4;
            lblTotal.Click += label1_Click;
            // 
            // lblDeudaTotal
            // 
            lblDeudaTotal.AutoSize = true;
            lblDeudaTotal.Location = new Point(824, 379);
            lblDeudaTotal.Name = "lblDeudaTotal";
            lblDeudaTotal.Size = new Size(0, 20);
            lblDeudaTotal.TabIndex = 3;
            // 
            // txtMontoPagar
            // 
            txtMontoPagar.Location = new Point(89, 408);
            txtMontoPagar.Name = "txtMontoPagar";
            txtMontoPagar.Size = new Size(125, 27);
            txtMontoPagar.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(89, 379);
            label1.Name = "label1";
            label1.Size = new Size(109, 20);
            label1.TabIndex = 6;
            label1.Text = "Monto a Pagar:";
            // 
            // mdPagarProductosCC
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1012, 538);
            Controls.Add(groupBox1);
            Name = "mdPagarProductosCC";
            Text = "mdPagarProductosCC";
            Load += mdPagarProductosCC_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPendientes).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvPendientes;
        private DataGridViewTextBoxColumn ProductoId;
        private DataGridViewTextBoxColumn Codigo;
        private DataGridViewTextBoxColumn Nombre;
        private DataGridViewTextBoxColumn Pendiente;
        private DataGridViewTextBoxColumn PrecioVigente;
        private DataGridViewTextBoxColumn Pagar;
        private DataGridViewTextBoxColumn SubTotal;
        private Button btnConfirmar;
        private Button btnCancelar;
        private GroupBox groupBox1;
        private Label lblDeudaTotal;
        private Label lblTotal;
        private Label label1;
        private TextBox txtMontoPagar;
    }
}