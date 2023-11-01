namespace ProyectoSO
{
    partial class Principal_Logged
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
            this.BarraPrincipal = new System.Windows.Forms.MenuStrip();
            this.usuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cuentaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preferenciasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.amigosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.añadirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verListaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Bienvenida = new System.Windows.Forms.Label();
            this.socialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.conectadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.amigosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.BarraPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // BarraPrincipal
            // 
            this.BarraPrincipal.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.BarraPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usuarioToolStripMenuItem,
            this.socialToolStripMenuItem});
            this.BarraPrincipal.Location = new System.Drawing.Point(0, 0);
            this.BarraPrincipal.Name = "BarraPrincipal";
            this.BarraPrincipal.Size = new System.Drawing.Size(1920, 24);
            this.BarraPrincipal.TabIndex = 0;
            this.BarraPrincipal.Text = "menuStrip1";
            this.BarraPrincipal.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // usuarioToolStripMenuItem
            // 
            this.usuarioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logOutToolStripMenuItem1});
            this.usuarioToolStripMenuItem.Name = "usuarioToolStripMenuItem";
            this.usuarioToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.usuarioToolStripMenuItem.Text = "Usuario";
            // 
            // logOutToolStripMenuItem1
            // 
            this.logOutToolStripMenuItem1.Name = "logOutToolStripMenuItem1";
            this.logOutToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.logOutToolStripMenuItem1.Text = "LogOut";
            this.logOutToolStripMenuItem1.Click += new System.EventHandler(this.logOutToolStripMenuItem1_Click);
            // 
            // cuentaToolStripMenuItem
            // 
            this.cuentaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.preferenciasToolStripMenuItem,
            this.logOutToolStripMenuItem});
            this.cuentaToolStripMenuItem.Name = "cuentaToolStripMenuItem";
            this.cuentaToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.cuentaToolStripMenuItem.Text = "Cuenta";
            // 
            // preferenciasToolStripMenuItem
            // 
            this.preferenciasToolStripMenuItem.Name = "preferenciasToolStripMenuItem";
            this.preferenciasToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.preferenciasToolStripMenuItem.Text = "Preferencias";
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            // 
            // amigosToolStripMenuItem
            // 
            this.amigosToolStripMenuItem.Name = "amigosToolStripMenuItem";
            this.amigosToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // añadirToolStripMenuItem
            // 
            this.añadirToolStripMenuItem.Name = "añadirToolStripMenuItem";
            this.añadirToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.añadirToolStripMenuItem.Text = "Buscar";
            // 
            // verListaToolStripMenuItem
            // 
            this.verListaToolStripMenuItem.Name = "verListaToolStripMenuItem";
            this.verListaToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.verListaToolStripMenuItem.Text = "Ver lista";
            // 
            // Bienvenida
            // 
            this.Bienvenida.AutoSize = true;
            this.Bienvenida.Font = new System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bienvenida.Location = new System.Drawing.Point(141, 83);
            this.Bienvenida.Name = "Bienvenida";
            this.Bienvenida.Size = new System.Drawing.Size(0, 31);
            this.Bienvenida.TabIndex = 1;
            // 
            // socialToolStripMenuItem
            // 
            this.socialToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.conectadosToolStripMenuItem,
            this.amigosToolStripMenuItem1});
            this.socialToolStripMenuItem.Name = "socialToolStripMenuItem";
            this.socialToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.socialToolStripMenuItem.Text = "Social";
            // 
            // conectadosToolStripMenuItem
            // 
            this.conectadosToolStripMenuItem.Name = "conectadosToolStripMenuItem";
            this.conectadosToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.conectadosToolStripMenuItem.Text = "Conectados";
            this.conectadosToolStripMenuItem.Click += new System.EventHandler(this.conectadosToolStripMenuItem_Click);
            // 
            // amigosToolStripMenuItem1
            // 
            this.amigosToolStripMenuItem1.Name = "amigosToolStripMenuItem1";
            this.amigosToolStripMenuItem1.Size = new System.Drawing.Size(223, 22);
            this.amigosToolStripMenuItem1.Text = "Amigos (No implementado)";
            // 
            // Principal_Logged
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = global::ProyectoSO.Properties.Resources.fondo_gwent;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.Bienvenida);
            this.Controls.Add(this.BarraPrincipal);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.BarraPrincipal;
            this.Name = "Principal_Logged";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.BarraPrincipal.ResumeLayout(false);
            this.BarraPrincipal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip BarraPrincipal;
        private System.Windows.Forms.ToolStripMenuItem cuentaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preferenciasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem amigosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem añadirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verListaToolStripMenuItem;
        private System.Windows.Forms.Label Bienvenida;
        private System.Windows.Forms.ToolStripMenuItem usuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem socialToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem conectadosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem amigosToolStripMenuItem1;
    }
}