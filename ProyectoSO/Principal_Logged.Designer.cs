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
            this.socialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.conectadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.amigosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cuentaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preferenciasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.amigosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.añadirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verListaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Bienvenida = new System.Windows.Forms.Label();
            this.dataGridConectados = new System.Windows.Forms.DataGridView();
            this.User_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Jugando_column = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panelConectados = new System.Windows.Forms.Panel();
            this.TituloConectados = new System.Windows.Forms.Label();
            this.BarraPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridConectados)).BeginInit();
            this.panelConectados.SuspendLayout();
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
            this.logOutToolStripMenuItem1.Size = new System.Drawing.Size(114, 22);
            this.logOutToolStripMenuItem1.Text = "LogOut";
            this.logOutToolStripMenuItem1.Click += new System.EventHandler(this.logOutToolStripMenuItem1_Click);
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
            this.conectadosToolStripMenuItem.CheckOnClick = true;
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
            // dataGridConectados
            // 
            this.dataGridConectados.AllowUserToAddRows = false;
            this.dataGridConectados.AllowUserToDeleteRows = false;
            this.dataGridConectados.AllowUserToResizeColumns = false;
            this.dataGridConectados.AllowUserToResizeRows = false;
            this.dataGridConectados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridConectados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridConectados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridConectados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.User_column,
            this.Jugando_column});
            this.dataGridConectados.Location = new System.Drawing.Point(15, 71);
            this.dataGridConectados.Name = "dataGridConectados";
            this.dataGridConectados.RowTemplate.Height = 24;
            this.dataGridConectados.Size = new System.Drawing.Size(462, 338);
            this.dataGridConectados.TabIndex = 2;
            // 
            // User_column
            // 
            this.User_column.HeaderText = "Usuario";
            this.User_column.Name = "User_column";
            this.User_column.ReadOnly = true;
            // 
            // Jugando_column
            // 
            this.Jugando_column.HeaderText = "Jugando";
            this.Jugando_column.Name = "Jugando_column";
            this.Jugando_column.ReadOnly = true;
            this.Jugando_column.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Jugando_column.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // panelConectados
            // 
            this.panelConectados.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelConectados.Controls.Add(this.TituloConectados);
            this.panelConectados.Controls.Add(this.dataGridConectados);
            this.panelConectados.Location = new System.Drawing.Point(49, 568);
            this.panelConectados.Name = "panelConectados";
            this.panelConectados.Size = new System.Drawing.Size(492, 421);
            this.panelConectados.TabIndex = 3;
            this.panelConectados.Visible = false;
            // 
            // TituloConectados
            // 
            this.TituloConectados.AutoSize = true;
            this.TituloConectados.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TituloConectados.Location = new System.Drawing.Point(12, 13);
            this.TituloConectados.Name = "TituloConectados";
            this.TituloConectados.Size = new System.Drawing.Size(321, 37);
            this.TituloConectados.TabIndex = 3;
            this.TituloConectados.Text = "Lista de conectados";
            // 
            // Principal_Logged
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = global::ProyectoSO.Properties.Resources.fondo_gwent;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.panelConectados);
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridConectados)).EndInit();
            this.panelConectados.ResumeLayout(false);
            this.panelConectados.PerformLayout();
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
        private System.Windows.Forms.Label TituloConectados;
        private System.Windows.Forms.DataGridViewTextBoxColumn User_column;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Jugando_column;
        public System.Windows.Forms.DataGridView dataGridConectados;
        public System.Windows.Forms.Panel panelConectados;
    }
}