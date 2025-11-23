namespace MaxiKiosco
{
    partial class frmNegocio
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
            label11 = new Label();
            label14 = new Label();
            piclogo = new PictureBox();
            Logo = new Label();
            btnsubirlogo = new FontAwesome.Sharp.IconButton();
            groupBox1 = new GroupBox();
            txtruc = new TextBox();
            label8 = new Label();
            btnguardar = new FontAwesome.Sharp.IconButton();
            txtdireccion = new TextBox();
            txtnombre = new TextBox();
            label6 = new Label();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)piclogo).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = SystemColors.ControlLightLight;
            label11.Font = new Font("Segoe UI", 15F);
            label11.Location = new Point(12, 25);
            label11.Name = "label11";
            label11.Size = new Size(194, 35);
            label11.TabIndex = 60;
            label11.Text = "Detalle Negocio";
            // 
            // label14
            // 
            label14.BackColor = SystemColors.HighlightText;
            label14.BorderStyle = BorderStyle.FixedSingle;
            label14.Dock = DockStyle.Left;
            label14.Location = new Point(0, 0);
            label14.Name = "label14";
            label14.Size = new Size(594, 541);
            label14.TabIndex = 59;
            // 
            // piclogo
            // 
            piclogo.BorderStyle = BorderStyle.FixedSingle;
            piclogo.Location = new Point(16, 112);
            piclogo.Name = "piclogo";
            piclogo.Size = new Size(147, 133);
            piclogo.SizeMode = PictureBoxSizeMode.StretchImage;
            piclogo.TabIndex = 0;
            piclogo.TabStop = false;
            // 
            // Logo
            // 
            Logo.AutoSize = true;
            Logo.Location = new Point(16, 77);
            Logo.Name = "Logo";
            Logo.Size = new Size(43, 20);
            Logo.TabIndex = 1;
            Logo.Text = "Logo";
            // 
            // btnsubirlogo
            // 
            btnsubirlogo.BackColor = SystemColors.ControlDark;
            btnsubirlogo.Cursor = Cursors.Hand;
            btnsubirlogo.FlatAppearance.BorderColor = Color.Black;
            btnsubirlogo.FlatStyle = FlatStyle.Flat;
            btnsubirlogo.ForeColor = SystemColors.ControlLightLight;
            btnsubirlogo.IconChar = FontAwesome.Sharp.IconChar.LongArrowAltUp;
            btnsubirlogo.IconColor = Color.White;
            btnsubirlogo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnsubirlogo.IconSize = 16;
            btnsubirlogo.Location = new Point(16, 270);
            btnsubirlogo.Name = "btnsubirlogo";
            btnsubirlogo.Size = new Size(147, 45);
            btnsubirlogo.TabIndex = 56;
            btnsubirlogo.Text = "Subir";
            btnsubirlogo.TextAlign = ContentAlignment.MiddleRight;
            btnsubirlogo.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnsubirlogo.UseVisualStyleBackColor = false;
            btnsubirlogo.Click += btnsubirlogo_Click;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.ButtonHighlight;
            groupBox1.Controls.Add(txtruc);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(btnguardar);
            groupBox1.Controls.Add(txtdireccion);
            groupBox1.Controls.Add(txtnombre);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(btnsubirlogo);
            groupBox1.Controls.Add(Logo);
            groupBox1.Controls.Add(piclogo);
            groupBox1.Location = new Point(12, 80);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(548, 388);
            groupBox1.TabIndex = 61;
            groupBox1.TabStop = false;
            groupBox1.Enter += groupBox1_Enter;
            // 
            // txtruc
            // 
            txtruc.Location = new Point(226, 165);
            txtruc.Name = "txtruc";
            txtruc.Size = new Size(230, 27);
            txtruc.TabIndex = 76;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = SystemColors.ControlLightLight;
            label8.Location = new Point(226, 142);
            label8.Name = "label8";
            label8.Size = new Size(45, 20);
            label8.TabIndex = 75;
            label8.Text = "R U C";
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
            btnguardar.Location = new Point(226, 270);
            btnguardar.Name = "btnguardar";
            btnguardar.Size = new Size(230, 45);
            btnguardar.TabIndex = 74;
            btnguardar.Text = "Guardar Cambios";
            btnguardar.TextAlign = ContentAlignment.MiddleRight;
            btnguardar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnguardar.UseVisualStyleBackColor = false;
            btnguardar.Click += btnguardar_Click;
            // 
            // txtdireccion
            // 
            txtdireccion.Location = new Point(226, 218);
            txtdireccion.Name = "txtdireccion";
            txtdireccion.Size = new Size(230, 27);
            txtdireccion.TabIndex = 73;
            // 
            // txtnombre
            // 
            txtnombre.Location = new Point(226, 112);
            txtnombre.Name = "txtnombre";
            txtnombre.Size = new Size(230, 27);
            txtnombre.TabIndex = 72;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = SystemColors.ControlLightLight;
            label6.Location = new Point(226, 195);
            label6.Name = "label6";
            label6.Size = new Size(72, 20);
            label6.TabIndex = 71;
            label6.Text = "Direccion";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = SystemColors.ControlLightLight;
            label5.Location = new Point(226, 89);
            label5.Name = "label5";
            label5.Size = new Size(125, 20);
            label5.TabIndex = 70;
            label5.Text = "Nombre Negocio";
            label5.Click += label5_Click;
            // 
            // frmNegocio
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1236, 541);
            Controls.Add(groupBox1);
            Controls.Add(label11);
            Controls.Add(label14);
            Name = "frmNegocio";
            Text = "frmNegocio";
            Load += frmNegocio_Load;
            ((System.ComponentModel.ISupportInitialize)piclogo).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label11;
        private Label label14;
        private PictureBox piclogo;
        private Label Logo;
        private FontAwesome.Sharp.IconButton btnsubirlogo;
        private GroupBox groupBox1;
        private TextBox txtruc;
        private Label label8;
        private FontAwesome.Sharp.IconButton btnguardar;
        private TextBox txtdireccion;
        private TextBox txtnombre;
        private Label label6;
        private Label label5;
    }
}