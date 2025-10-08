namespace MaxiKiosco
{
    partial class Inicio : Form
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inicio));
            menu = new MenuStrip();
            menuusuario = new FontAwesome.Sharp.IconMenuItem();
            menumantenedor = new FontAwesome.Sharp.IconMenuItem();
            submenucategoria = new FontAwesome.Sharp.IconMenuItem();
            submenuproducto = new FontAwesome.Sharp.IconMenuItem();
            submenunegocio = new ToolStripMenuItem();
            menuventas = new FontAwesome.Sharp.IconMenuItem();
            submenuregistrarventa = new FontAwesome.Sharp.IconMenuItem();
            submenuverdetalle = new FontAwesome.Sharp.IconMenuItem();
            menucompras = new FontAwesome.Sharp.IconMenuItem();
            submenuregistrarcompra = new FontAwesome.Sharp.IconMenuItem();
            submenuverdetallecompra = new FontAwesome.Sharp.IconMenuItem();
            menuclientes = new FontAwesome.Sharp.IconMenuItem();
            menuproveedores = new FontAwesome.Sharp.IconMenuItem();
            menureportes = new FontAwesome.Sharp.IconMenuItem();
            menuacercade = new FontAwesome.Sharp.IconMenuItem();
            menutitulo = new MenuStrip();
            titulo = new ToolStripMenuItem();
            lblusuario = new ToolStripMenuItem();
            tsmiVolverLogin = new ToolStripMenuItem();
            contenedor = new Panel();
            label2 = new Label();
            menu.SuspendLayout();
            menutitulo.SuspendLayout();
            contenedor.SuspendLayout();
            SuspendLayout();
            // 
            // menu
            // 
            menu.BackColor = SystemColors.ButtonHighlight;
            menu.ImageScalingSize = new Size(20, 20);
            menu.Items.AddRange(new ToolStripItem[] { menuusuario, menumantenedor, menuventas, menucompras, menuclientes, menuproveedores, menureportes, menuacercade });
            menu.Location = new Point(0, 71);
            menu.Name = "menu";
            menu.Padding = new Padding(7, 2, 0, 2);
            menu.Size = new Size(1199, 78);
            menu.TabIndex = 0;
            menu.Text = "menuStrip1";
            menu.ItemClicked += menu_ItemClicked;
            // 
            // menuusuario
            // 
            menuusuario.AutoSize = false;
            menuusuario.IconChar = FontAwesome.Sharp.IconChar.UserGear;
            menuusuario.IconColor = Color.Black;
            menuusuario.IconFont = FontAwesome.Sharp.IconFont.Auto;
            menuusuario.IconSize = 50;
            menuusuario.ImageScaling = ToolStripItemImageScaling.None;
            menuusuario.Name = "menuusuario";
            menuusuario.Size = new Size(80, 74);
            menuusuario.Text = "Usuarios";
            menuusuario.TextImageRelation = TextImageRelation.ImageAboveText;
            menuusuario.Click += menuusuario_Click_1;
            // 
            // menumantenedor
            // 
            menumantenedor.AutoSize = false;
            menumantenedor.DropDownItems.AddRange(new ToolStripItem[] { submenucategoria, submenuproducto, submenunegocio });
            menumantenedor.IconChar = FontAwesome.Sharp.IconChar.Tools;
            menumantenedor.IconColor = Color.Black;
            menumantenedor.IconFont = FontAwesome.Sharp.IconFont.Auto;
            menumantenedor.IconSize = 50;
            menumantenedor.ImageScaling = ToolStripItemImageScaling.None;
            menumantenedor.Name = "menumantenedor";
            menumantenedor.Size = new Size(152, 74);
            menumantenedor.Text = "Productos y Categoria";
            menumantenedor.TextImageRelation = TextImageRelation.ImageAboveText;
            menumantenedor.Click += menumantenedor_Click;
            // 
            // submenucategoria
            // 
            submenucategoria.IconChar = FontAwesome.Sharp.IconChar.None;
            submenucategoria.IconColor = Color.Black;
            submenucategoria.IconFont = FontAwesome.Sharp.IconFont.Auto;
            submenucategoria.Name = "submenucategoria";
            submenucategoria.Size = new Size(125, 22);
            submenucategoria.Text = "Categoria";
            submenucategoria.Click += submenucategoria_Click;
            // 
            // submenuproducto
            // 
            submenuproducto.IconChar = FontAwesome.Sharp.IconChar.None;
            submenuproducto.IconColor = Color.Black;
            submenuproducto.IconFont = FontAwesome.Sharp.IconFont.Auto;
            submenuproducto.Name = "submenuproducto";
            submenuproducto.Size = new Size(125, 22);
            submenuproducto.Text = "Producto";
            submenuproducto.Click += submenuproducto_Click;
            // 
            // submenunegocio
            // 
            submenunegocio.Name = "submenunegocio";
            submenunegocio.Size = new Size(125, 22);
            submenunegocio.Text = "Negocio";
            submenunegocio.Click += submenunegocio_Click;
            // 
            // menuventas
            // 
            menuventas.AutoSize = false;
            menuventas.DropDownItems.AddRange(new ToolStripItem[] { submenuregistrarventa, submenuverdetalle });
            menuventas.IconChar = FontAwesome.Sharp.IconChar.Tags;
            menuventas.IconColor = Color.Black;
            menuventas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            menuventas.IconSize = 50;
            menuventas.ImageScaling = ToolStripItemImageScaling.None;
            menuventas.Name = "menuventas";
            menuventas.Size = new Size(80, 74);
            menuventas.Text = "Ventas";
            menuventas.TextImageRelation = TextImageRelation.ImageAboveText;
            // 
            // submenuregistrarventa
            // 
            submenuregistrarventa.IconChar = FontAwesome.Sharp.IconChar.None;
            submenuregistrarventa.IconColor = Color.Black;
            submenuregistrarventa.IconFont = FontAwesome.Sharp.IconFont.Auto;
            submenuregistrarventa.Name = "submenuregistrarventa";
            submenuregistrarventa.Size = new Size(129, 22);
            submenuregistrarventa.Text = "Registrar";
            submenuregistrarventa.Click += submenuregistrarventa_Click;
            // 
            // submenuverdetalle
            // 
            submenuverdetalle.IconChar = FontAwesome.Sharp.IconChar.None;
            submenuverdetalle.IconColor = Color.Black;
            submenuverdetalle.IconFont = FontAwesome.Sharp.IconFont.Auto;
            submenuverdetalle.Name = "submenuverdetalle";
            submenuverdetalle.Size = new Size(129, 22);
            submenuverdetalle.Text = "Ver Detalle";
            submenuverdetalle.Click += submenuverdetalle_Click;
            // 
            // menucompras
            // 
            menucompras.AutoSize = false;
            menucompras.DropDownItems.AddRange(new ToolStripItem[] { submenuregistrarcompra, submenuverdetallecompra });
            menucompras.IconChar = FontAwesome.Sharp.IconChar.CartFlatbed;
            menucompras.IconColor = Color.Black;
            menucompras.IconFont = FontAwesome.Sharp.IconFont.Auto;
            menucompras.IconSize = 50;
            menucompras.ImageScaling = ToolStripItemImageScaling.None;
            menucompras.Name = "menucompras";
            menucompras.Size = new Size(80, 74);
            menucompras.Text = "Compras";
            menucompras.TextImageRelation = TextImageRelation.ImageAboveText;
            // 
            // submenuregistrarcompra
            // 
            submenuregistrarcompra.IconChar = FontAwesome.Sharp.IconChar.None;
            submenuregistrarcompra.IconColor = Color.Black;
            submenuregistrarcompra.IconFont = FontAwesome.Sharp.IconFont.Auto;
            submenuregistrarcompra.Name = "submenuregistrarcompra";
            submenuregistrarcompra.Size = new Size(129, 22);
            submenuregistrarcompra.Text = "Registrar";
            submenuregistrarcompra.Click += submenuregistrarcompra_Click;
            // 
            // submenuverdetallecompra
            // 
            submenuverdetallecompra.IconChar = FontAwesome.Sharp.IconChar.None;
            submenuverdetallecompra.IconColor = Color.Black;
            submenuverdetallecompra.IconFont = FontAwesome.Sharp.IconFont.Auto;
            submenuverdetallecompra.Name = "submenuverdetallecompra";
            submenuverdetallecompra.Size = new Size(129, 22);
            submenuverdetallecompra.Text = "Ver Detalle";
            submenuverdetallecompra.Click += submenuverdetallecompra_Click;
            // 
            // menuclientes
            // 
            menuclientes.AutoSize = false;
            menuclientes.IconChar = FontAwesome.Sharp.IconChar.UserFriends;
            menuclientes.IconColor = Color.Black;
            menuclientes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            menuclientes.IconSize = 50;
            menuclientes.ImageScaling = ToolStripItemImageScaling.None;
            menuclientes.Name = "menuclientes";
            menuclientes.Size = new Size(80, 74);
            menuclientes.Text = "Clientes";
            menuclientes.TextImageRelation = TextImageRelation.ImageAboveText;
            menuclientes.Click += menuclientes_Click;
            // 
            // menuproveedores
            // 
            menuproveedores.AutoSize = false;
            menuproveedores.IconChar = FontAwesome.Sharp.IconChar.Vcard;
            menuproveedores.IconColor = Color.Black;
            menuproveedores.IconFont = FontAwesome.Sharp.IconFont.Auto;
            menuproveedores.IconSize = 50;
            menuproveedores.ImageScaling = ToolStripItemImageScaling.None;
            menuproveedores.Name = "menuproveedores";
            menuproveedores.Size = new Size(90, 74);
            menuproveedores.Text = "Proveedores";
            menuproveedores.TextImageRelation = TextImageRelation.ImageAboveText;
            menuproveedores.Click += menuproveedores_Click;
            // 
            // menureportes
            // 
            menureportes.AutoSize = false;
            menureportes.IconChar = FontAwesome.Sharp.IconChar.BarChart;
            menureportes.IconColor = Color.Black;
            menureportes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            menureportes.IconSize = 50;
            menureportes.ImageScaling = ToolStripItemImageScaling.None;
            menureportes.Name = "menureportes";
            menureportes.Size = new Size(80, 74);
            menureportes.Text = "Reportes";
            menureportes.TextImageRelation = TextImageRelation.ImageAboveText;
            menureportes.Click += menureportes_Click;
            // 
            // menuacercade
            // 
            menuacercade.AutoSize = false;
            menuacercade.IconChar = FontAwesome.Sharp.IconChar.CircleInfo;
            menuacercade.IconColor = Color.Black;
            menuacercade.IconFont = FontAwesome.Sharp.IconFont.Auto;
            menuacercade.IconSize = 50;
            menuacercade.ImageScaling = ToolStripItemImageScaling.None;
            menuacercade.Name = "menuacercade";
            menuacercade.Size = new Size(90, 74);
            menuacercade.Text = "Acerca de";
            menuacercade.TextImageRelation = TextImageRelation.ImageAboveText;
            // 
            // menutitulo
            // 
            menutitulo.AutoSize = false;
            menutitulo.BackColor = SystemColors.MenuHighlight;
            menutitulo.ImageScalingSize = new Size(20, 20);
            menutitulo.Items.AddRange(new ToolStripItem[] { titulo, lblusuario, tsmiVolverLogin });
            menutitulo.Location = new Point(0, 0);
            menutitulo.Name = "menutitulo";
            menutitulo.Padding = new Padding(7, 2, 0, 2);
            menutitulo.RightToLeft = RightToLeft.No;
            menutitulo.Size = new Size(1199, 71);
            menutitulo.TabIndex = 1;
            menutitulo.Text = "menuStrip2";
            // 
            // titulo
            // 
            titulo.BackColor = SystemColors.MenuHighlight;
            titulo.Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Regular, GraphicsUnit.Point, 0);
            titulo.ForeColor = SystemColors.ButtonHighlight;
            titulo.Name = "titulo";
            titulo.Size = new Size(253, 67);
            titulo.Text = "Sistema de Ventas";
            // 
            // lblusuario
            // 
            lblusuario.Font = new Font("Segoe UI", 12F);
            lblusuario.Name = "lblusuario";
            lblusuario.Size = new Size(12, 67);
            // 
            // tsmiVolverLogin
            // 
            tsmiVolverLogin.Alignment = ToolStripItemAlignment.Right;
            tsmiVolverLogin.BackColor = Color.Transparent;
            tsmiVolverLogin.Font = new Font("Tahoma", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tsmiVolverLogin.ForeColor = Color.Black;
            tsmiVolverLogin.Image = (Image)resources.GetObject("tsmiVolverLogin.Image");
            tsmiVolverLogin.Name = "tsmiVolverLogin";
            tsmiVolverLogin.Size = new Size(87, 67);
            tsmiVolverLogin.Text = "Login";
            tsmiVolverLogin.Click += tsmiVolverLogin_Click;
            // 
            // contenedor
            // 
            contenedor.BackColor = SystemColors.Control;
            contenedor.Controls.Add(label2);
            contenedor.Dock = DockStyle.Fill;
            contenedor.Location = new Point(0, 149);
            contenedor.Margin = new Padding(1, 2, 1, 2);
            contenedor.Name = "contenedor";
            contenedor.Size = new Size(1199, 413);
            contenedor.TabIndex = 3;
            contenedor.Paint += contenedor_Paint;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(357, 25);
            label2.Margin = new Padding(1, 0, 1, 0);
            label2.Name = "label2";
            label2.Size = new Size(0, 15);
            label2.TabIndex = 0;
            // 
            // Inicio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1199, 562);
            Controls.Add(contenedor);
            Controls.Add(menu);
            Controls.Add(menutitulo);
            MainMenuStrip = menu;
            Name = "Inicio";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Inicio_Load;
            menu.ResumeLayout(false);
            menu.PerformLayout();
            menutitulo.ResumeLayout(false);
            menutitulo.PerformLayout();
            contenedor.ResumeLayout(false);
            contenedor.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.MenuStrip menutitulo;
        private FontAwesome.Sharp.IconMenuItem menuacercade;
        private FontAwesome.Sharp.IconMenuItem menuusuario;
        private FontAwesome.Sharp.IconMenuItem menumantenedor;
        private FontAwesome.Sharp.IconMenuItem menuventas;
        private FontAwesome.Sharp.IconMenuItem menucompras;
        private FontAwesome.Sharp.IconMenuItem menuclientes;
        private FontAwesome.Sharp.IconMenuItem menuproveedores;
        private FontAwesome.Sharp.IconMenuItem menureportes;
        private System.Windows.Forms.Panel contenedor;
        private Label label2;
        private ToolStripMenuItem titulo;
        private FontAwesome.Sharp.IconMenuItem submenucategoria;
        private FontAwesome.Sharp.IconMenuItem submenuproducto;
        private FontAwesome.Sharp.IconMenuItem submenuregistrarventa;
        private FontAwesome.Sharp.IconMenuItem submenuverdetalle;
        private FontAwesome.Sharp.IconMenuItem submenuregistrarcompra;
        private FontAwesome.Sharp.IconMenuItem submenuverdetallecompra;
        private ToolStripMenuItem submenunegocio;
        private ToolStripMenuItem tsmiVolverLogin;
        private ToolStripMenuItem lblusuario;
    }
}

