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
            this.jugarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crearPartidaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.CrearPartida = new System.Windows.Forms.Panel();
            this.DGVInvitados = new System.Windows.Forms.DataGridView();
            this.Invitado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Accepted = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.EnviarPartida = new System.Windows.Forms.Button();
            this.LabelInvitado3 = new System.Windows.Forms.Label();
            this.LabelInvitado2 = new System.Windows.Forms.Label();
            this.LabelInvitado1 = new System.Windows.Forms.Label();
            this.SelecctionarLablel = new System.Windows.Forms.Label();
            this.LabelMode = new System.Windows.Forms.Label();
            this.Titulo_invitar = new System.Windows.Forms.Label();
            this.Jugador3ComboBox = new System.Windows.Forms.ComboBox();
            this.Jugador2ComboBox = new System.Windows.Forms.ComboBox();
            this.Jugador1ComboBox = new System.Windows.Forms.ComboBox();
            this.ModeComboBox = new System.Windows.Forms.ComboBox();
            this.BarraPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridConectados)).BeginInit();
            this.panelConectados.SuspendLayout();
            this.CrearPartida.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVInvitados)).BeginInit();
            this.SuspendLayout();
            // 
            // BarraPrincipal
            // 
            this.BarraPrincipal.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.BarraPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usuarioToolStripMenuItem,
            this.socialToolStripMenuItem,
            this.jugarToolStripMenuItem});
            this.BarraPrincipal.Location = new System.Drawing.Point(0, 0);
            this.BarraPrincipal.Name = "BarraPrincipal";
            this.BarraPrincipal.Size = new System.Drawing.Size(1940, 24);
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
            // jugarToolStripMenuItem
            // 
            this.jugarToolStripMenuItem.CheckOnClick = true;
            this.jugarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.crearPartidaToolStripMenuItem});
            this.jugarToolStripMenuItem.Name = "jugarToolStripMenuItem";
            this.jugarToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.jugarToolStripMenuItem.Text = "Jugar";
            // 
            // crearPartidaToolStripMenuItem
            // 
            this.crearPartidaToolStripMenuItem.CheckOnClick = true;
            this.crearPartidaToolStripMenuItem.Name = "crearPartidaToolStripMenuItem";
            this.crearPartidaToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.crearPartidaToolStripMenuItem.Text = "Crear partida";
            this.crearPartidaToolStripMenuItem.Click += new System.EventHandler(this.crearPartidaToolStripMenuItem_Click);
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
            this.dataGridConectados.RowHeadersWidth = 62;
            this.dataGridConectados.RowTemplate.Height = 24;
            this.dataGridConectados.Size = new System.Drawing.Size(484, 318);
            this.dataGridConectados.TabIndex = 2;
            // 
            // User_column
            // 
            this.User_column.HeaderText = "Usuario";
            this.User_column.MinimumWidth = 8;
            this.User_column.Name = "User_column";
            this.User_column.ReadOnly = true;
            // 
            // Jugando_column
            // 
            this.Jugando_column.HeaderText = "Jugando";
            this.Jugando_column.MinimumWidth = 8;
            this.Jugando_column.Name = "Jugando_column";
            this.Jugando_column.ReadOnly = true;
            this.Jugando_column.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Jugando_column.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // panelConectados
            // 
            this.panelConectados.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelConectados.AutoSize = true;
            this.panelConectados.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelConectados.Controls.Add(this.TituloConectados);
            this.panelConectados.Controls.Add(this.dataGridConectados);
            this.panelConectados.Cursor = System.Windows.Forms.Cursors.Default;
            this.panelConectados.Location = new System.Drawing.Point(45, 594);
            this.panelConectados.Name = "panelConectados";
            this.panelConectados.Size = new System.Drawing.Size(514, 401);
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
            // CrearPartida
            // 
            this.CrearPartida.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CrearPartida.AutoSize = true;
            this.CrearPartida.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CrearPartida.Controls.Add(this.DGVInvitados);
            this.CrearPartida.Controls.Add(this.EnviarPartida);
            this.CrearPartida.Controls.Add(this.LabelInvitado3);
            this.CrearPartida.Controls.Add(this.LabelInvitado2);
            this.CrearPartida.Controls.Add(this.LabelInvitado1);
            this.CrearPartida.Controls.Add(this.SelecctionarLablel);
            this.CrearPartida.Controls.Add(this.LabelMode);
            this.CrearPartida.Controls.Add(this.Titulo_invitar);
            this.CrearPartida.Controls.Add(this.Jugador3ComboBox);
            this.CrearPartida.Controls.Add(this.Jugador2ComboBox);
            this.CrearPartida.Controls.Add(this.Jugador1ComboBox);
            this.CrearPartida.Controls.Add(this.ModeComboBox);
            this.CrearPartida.Location = new System.Drawing.Point(995, 83);
            this.CrearPartida.Name = "CrearPartida";
            this.CrearPartida.Size = new System.Drawing.Size(845, 551);
            this.CrearPartida.TabIndex = 4;
            this.CrearPartida.Visible = false;
            // 
            // DGVInvitados
            // 
            this.DGVInvitados.AllowUserToAddRows = false;
            this.DGVInvitados.AllowUserToDeleteRows = false;
            this.DGVInvitados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGVInvitados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVInvitados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVInvitados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Invitado,
            this.Accepted});
            this.DGVInvitados.Location = new System.Drawing.Point(405, 232);
            this.DGVInvitados.Name = "DGVInvitados";
            this.DGVInvitados.ReadOnly = true;
            this.DGVInvitados.RowHeadersWidth = 51;
            this.DGVInvitados.RowTemplate.Height = 24;
            this.DGVInvitados.Size = new System.Drawing.Size(387, 257);
            this.DGVInvitados.TabIndex = 6;
            // 
            // Invitado
            // 
            this.Invitado.HeaderText = "Invitado";
            this.Invitado.MinimumWidth = 6;
            this.Invitado.Name = "Invitado";
            this.Invitado.ReadOnly = true;
            // 
            // Accepted
            // 
            this.Accepted.HeaderText = "Accepted?";
            this.Accepted.MinimumWidth = 6;
            this.Accepted.Name = "Accepted";
            this.Accepted.ReadOnly = true;
            this.Accepted.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Accepted.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // EnviarPartida
            // 
            this.EnviarPartida.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EnviarPartida.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnviarPartida.Location = new System.Drawing.Point(479, 101);
            this.EnviarPartida.Name = "EnviarPartida";
            this.EnviarPartida.Size = new System.Drawing.Size(229, 95);
            this.EnviarPartida.TabIndex = 5;
            this.EnviarPartida.Text = "Invitar";
            this.EnviarPartida.UseVisualStyleBackColor = true;
            this.EnviarPartida.Click += new System.EventHandler(this.EnviarPartida_Click);
            // 
            // LabelInvitado3
            // 
            this.LabelInvitado3.AutoSize = true;
            this.LabelInvitado3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelInvitado3.Location = new System.Drawing.Point(45, 374);
            this.LabelInvitado3.Name = "LabelInvitado3";
            this.LabelInvitado3.Size = new System.Drawing.Size(78, 20);
            this.LabelInvitado3.TabIndex = 4;
            this.LabelInvitado3.Text = "Invitado 3";
            this.LabelInvitado3.Visible = false;
            // 
            // LabelInvitado2
            // 
            this.LabelInvitado2.AutoSize = true;
            this.LabelInvitado2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelInvitado2.Location = new System.Drawing.Point(45, 292);
            this.LabelInvitado2.Name = "LabelInvitado2";
            this.LabelInvitado2.Size = new System.Drawing.Size(78, 20);
            this.LabelInvitado2.TabIndex = 4;
            this.LabelInvitado2.Text = "Invitado 2";
            this.LabelInvitado2.Visible = false;
            // 
            // LabelInvitado1
            // 
            this.LabelInvitado1.AutoSize = true;
            this.LabelInvitado1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelInvitado1.Location = new System.Drawing.Point(45, 214);
            this.LabelInvitado1.Name = "LabelInvitado1";
            this.LabelInvitado1.Size = new System.Drawing.Size(78, 20);
            this.LabelInvitado1.TabIndex = 4;
            this.LabelInvitado1.Text = "Invitado 1";
            this.LabelInvitado1.Visible = false;
            // 
            // SelecctionarLablel
            // 
            this.SelecctionarLablel.AutoSize = true;
            this.SelecctionarLablel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelecctionarLablel.Location = new System.Drawing.Point(45, 171);
            this.SelecctionarLablel.Name = "SelecctionarLablel";
            this.SelecctionarLablel.Size = new System.Drawing.Size(177, 20);
            this.SelecctionarLablel.TabIndex = 4;
            this.SelecctionarLablel.Text = "Selecciona los invitados";
            // 
            // LabelMode
            // 
            this.LabelMode.AutoSize = true;
            this.LabelMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelMode.Location = new System.Drawing.Point(45, 92);
            this.LabelMode.Name = "LabelMode";
            this.LabelMode.Size = new System.Drawing.Size(278, 20);
            this.LabelMode.TabIndex = 4;
            this.LabelMode.Text = "Selecciona cuantos jugadores quieres";
            // 
            // Titulo_invitar
            // 
            this.Titulo_invitar.AutoSize = true;
            this.Titulo_invitar.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Titulo_invitar.Location = new System.Drawing.Point(42, 34);
            this.Titulo_invitar.Name = "Titulo_invitar";
            this.Titulo_invitar.Size = new System.Drawing.Size(221, 37);
            this.Titulo_invitar.TabIndex = 3;
            this.Titulo_invitar.Text = "Crear Partida";
            // 
            // Jugador3ComboBox
            // 
            this.Jugador3ComboBox.FormattingEnabled = true;
            this.Jugador3ComboBox.Items.AddRange(new object[] {
            "2",
            "4"});
            this.Jugador3ComboBox.Location = new System.Drawing.Point(50, 412);
            this.Jugador3ComboBox.Name = "Jugador3ComboBox";
            this.Jugador3ComboBox.Size = new System.Drawing.Size(204, 21);
            this.Jugador3ComboBox.TabIndex = 0;
            this.Jugador3ComboBox.Visible = false;
            // 
            // Jugador2ComboBox
            // 
            this.Jugador2ComboBox.FormattingEnabled = true;
            this.Jugador2ComboBox.Items.AddRange(new object[] {
            "2",
            "4"});
            this.Jugador2ComboBox.Location = new System.Drawing.Point(50, 330);
            this.Jugador2ComboBox.Name = "Jugador2ComboBox";
            this.Jugador2ComboBox.Size = new System.Drawing.Size(204, 21);
            this.Jugador2ComboBox.TabIndex = 0;
            this.Jugador2ComboBox.Visible = false;
            // 
            // Jugador1ComboBox
            // 
            this.Jugador1ComboBox.FormattingEnabled = true;
            this.Jugador1ComboBox.Items.AddRange(new object[] {
            "2",
            "4"});
            this.Jugador1ComboBox.Location = new System.Drawing.Point(50, 252);
            this.Jugador1ComboBox.Name = "Jugador1ComboBox";
            this.Jugador1ComboBox.Size = new System.Drawing.Size(204, 21);
            this.Jugador1ComboBox.TabIndex = 0;
            this.Jugador1ComboBox.Visible = false;
            // 
            // ModeComboBox
            // 
            this.ModeComboBox.FormattingEnabled = true;
            this.ModeComboBox.Items.AddRange(new object[] {
            "2",
            "4"});
            this.ModeComboBox.Location = new System.Drawing.Point(50, 130);
            this.ModeComboBox.Name = "ModeComboBox";
            this.ModeComboBox.Size = new System.Drawing.Size(204, 21);
            this.ModeComboBox.TabIndex = 0;
            this.ModeComboBox.TextChanged += new System.EventHandler(this.ModeComboBox_TextChanged);
            // 
            // Principal_Logged
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = global::ProyectoSO.Properties.Resources.fondo_gwent;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1940, 1100);
            this.Controls.Add(this.CrearPartida);
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
            this.CrearPartida.ResumeLayout(false);
            this.CrearPartida.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVInvitados)).EndInit();
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
        private System.Windows.Forms.ToolStripMenuItem jugarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem crearPartidaToolStripMenuItem;
        private System.Windows.Forms.Panel CrearPartida;
        private System.Windows.Forms.ComboBox ModeComboBox;
        private System.Windows.Forms.Label LabelInvitado2;
        private System.Windows.Forms.Label LabelInvitado1;
        private System.Windows.Forms.Label SelecctionarLablel;
        private System.Windows.Forms.Label LabelMode;
        private System.Windows.Forms.Label Titulo_invitar;
        private System.Windows.Forms.ComboBox Jugador2ComboBox;
        private System.Windows.Forms.ComboBox Jugador1ComboBox;
        private System.Windows.Forms.Label LabelInvitado3;
        private System.Windows.Forms.ComboBox Jugador3ComboBox;
        private System.Windows.Forms.Button EnviarPartida;
        private System.Windows.Forms.DataGridView DGVInvitados;
        private System.Windows.Forms.DataGridViewTextBoxColumn Invitado;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Accepted;
    }
}