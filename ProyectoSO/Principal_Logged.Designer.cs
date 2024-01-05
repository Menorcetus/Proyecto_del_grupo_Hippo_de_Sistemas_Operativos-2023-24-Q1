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
            this.darseDeBajaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.socialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.conectadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.amigosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.jugarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crearPartidaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.otrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.galeríaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.CartasComboBox = new System.Windows.Forms.ComboBox();
            this.EnviadoLbl = new System.Windows.Forms.Label();
            this.DGVInvitados = new System.Windows.Forms.DataGridView();
            this.Invitado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Accepted = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.EnviarPartida = new System.Windows.Forms.Button();
            this.CartasLbl = new System.Windows.Forms.Label();
            this.SelecctionarLablel = new System.Windows.Forms.Label();
            this.Titulo_invitar = new System.Windows.Forms.Label();
            this.Jugador1ComboBox = new System.Windows.Forms.ComboBox();
            this.manualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.jugarToolStripMenuItem,
            this.otrosToolStripMenuItem});
            this.BarraPrincipal.Location = new System.Drawing.Point(0, 0);
            this.BarraPrincipal.Name = "BarraPrincipal";
            this.BarraPrincipal.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.BarraPrincipal.Size = new System.Drawing.Size(1552, 24);
            this.BarraPrincipal.TabIndex = 0;
            this.BarraPrincipal.Text = "menuStrip1";
            this.BarraPrincipal.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // usuarioToolStripMenuItem
            // 
            this.usuarioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logOutToolStripMenuItem1,
            this.darseDeBajaToolStripMenuItem});
            this.usuarioToolStripMenuItem.Name = "usuarioToolStripMenuItem";
            this.usuarioToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.usuarioToolStripMenuItem.Text = "Usuario";
            // 
            // logOutToolStripMenuItem1
            // 
            this.logOutToolStripMenuItem1.Name = "logOutToolStripMenuItem1";
            this.logOutToolStripMenuItem1.Size = new System.Drawing.Size(144, 22);
            this.logOutToolStripMenuItem1.Text = "LogOut";
            this.logOutToolStripMenuItem1.Click += new System.EventHandler(this.logOutToolStripMenuItem1_Click);
            // 
            // darseDeBajaToolStripMenuItem
            // 
            this.darseDeBajaToolStripMenuItem.Name = "darseDeBajaToolStripMenuItem";
            this.darseDeBajaToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.darseDeBajaToolStripMenuItem.Text = "Darse de baja";
            this.darseDeBajaToolStripMenuItem.Click += new System.EventHandler(this.darseDeBajaToolStripMenuItem_Click);
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
            this.crearPartidaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.crearPartidaToolStripMenuItem.Text = "Crear partida";
            this.crearPartidaToolStripMenuItem.Click += new System.EventHandler(this.crearPartidaToolStripMenuItem_Click);
            // 
            // otrosToolStripMenuItem
            // 
            this.otrosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.galeríaToolStripMenuItem,
            this.manualToolStripMenuItem,
            this.consultasToolStripMenuItem});
            this.otrosToolStripMenuItem.Name = "otrosToolStripMenuItem";
            this.otrosToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.otrosToolStripMenuItem.Text = "Otros";
            // 
            // galeríaToolStripMenuItem
            // 
            this.galeríaToolStripMenuItem.Name = "galeríaToolStripMenuItem";
            this.galeríaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.galeríaToolStripMenuItem.Text = "Galería";
            this.galeríaToolStripMenuItem.Click += new System.EventHandler(this.galeríaToolStripMenuItem_Click);
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
            this.Bienvenida.Location = new System.Drawing.Point(113, 66);
            this.Bienvenida.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
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
            this.dataGridConectados.Location = new System.Drawing.Point(12, 57);
            this.dataGridConectados.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridConectados.Name = "dataGridConectados";
            this.dataGridConectados.RowHeadersWidth = 62;
            this.dataGridConectados.RowTemplate.Height = 24;
            this.dataGridConectados.Size = new System.Drawing.Size(387, 254);
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
            this.panelConectados.Location = new System.Drawing.Point(36, 475);
            this.panelConectados.Margin = new System.Windows.Forms.Padding(2);
            this.panelConectados.Name = "panelConectados";
            this.panelConectados.Size = new System.Drawing.Size(411, 321);
            this.panelConectados.TabIndex = 3;
            this.panelConectados.Visible = false;
            // 
            // TituloConectados
            // 
            this.TituloConectados.AutoSize = true;
            this.TituloConectados.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TituloConectados.Location = new System.Drawing.Point(10, 10);
            this.TituloConectados.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
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
            this.CrearPartida.Controls.Add(this.CartasComboBox);
            this.CrearPartida.Controls.Add(this.EnviadoLbl);
            this.CrearPartida.Controls.Add(this.DGVInvitados);
            this.CrearPartida.Controls.Add(this.EnviarPartida);
            this.CrearPartida.Controls.Add(this.CartasLbl);
            this.CrearPartida.Controls.Add(this.SelecctionarLablel);
            this.CrearPartida.Controls.Add(this.Titulo_invitar);
            this.CrearPartida.Controls.Add(this.Jugador1ComboBox);
            this.CrearPartida.Location = new System.Drawing.Point(666, 81);
            this.CrearPartida.Margin = new System.Windows.Forms.Padding(2);
            this.CrearPartida.Name = "CrearPartida";
            this.CrearPartida.Size = new System.Drawing.Size(676, 441);
            this.CrearPartida.TabIndex = 4;
            this.CrearPartida.Visible = false;
            // 
            // CartasComboBox
            // 
            this.CartasComboBox.FormattingEnabled = true;
            this.CartasComboBox.Items.AddRange(new object[] {
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.CartasComboBox.Location = new System.Drawing.Point(43, 195);
            this.CartasComboBox.Name = "CartasComboBox";
            this.CartasComboBox.Size = new System.Drawing.Size(162, 21);
            this.CartasComboBox.TabIndex = 8;
            this.CartasComboBox.SelectedIndexChanged += new System.EventHandler(this.TurnosComboBox_SelectedIndexChanged);
            // 
            // EnviadoLbl
            // 
            this.EnviadoLbl.AutoSize = true;
            this.EnviadoLbl.Location = new System.Drawing.Point(381, 159);
            this.EnviadoLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.EnviadoLbl.Name = "EnviadoLbl";
            this.EnviadoLbl.Size = new System.Drawing.Size(0, 13);
            this.EnviadoLbl.TabIndex = 7;
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
            this.DGVInvitados.Location = new System.Drawing.Point(324, 186);
            this.DGVInvitados.Margin = new System.Windows.Forms.Padding(2);
            this.DGVInvitados.Name = "DGVInvitados";
            this.DGVInvitados.ReadOnly = true;
            this.DGVInvitados.RowHeadersWidth = 51;
            this.DGVInvitados.RowTemplate.Height = 24;
            this.DGVInvitados.Size = new System.Drawing.Size(310, 206);
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
            this.EnviarPartida.Location = new System.Drawing.Point(383, 81);
            this.EnviarPartida.Margin = new System.Windows.Forms.Padding(2);
            this.EnviarPartida.Name = "EnviarPartida";
            this.EnviarPartida.Size = new System.Drawing.Size(183, 76);
            this.EnviarPartida.TabIndex = 5;
            this.EnviarPartida.Text = "Invitar";
            this.EnviarPartida.UseVisualStyleBackColor = true;
            this.EnviarPartida.Click += new System.EventHandler(this.EnviarPartida_Click);
            // 
            // CartasLbl
            // 
            this.CartasLbl.AutoSize = true;
            this.CartasLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CartasLbl.Location = new System.Drawing.Point(39, 159);
            this.CartasLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.CartasLbl.Name = "CartasLbl";
            this.CartasLbl.Size = new System.Drawing.Size(231, 20);
            this.CartasLbl.TabIndex = 4;
            this.CartasLbl.Text = "Selecciona el numero de cartas";
            // 
            // SelecctionarLablel
            // 
            this.SelecctionarLablel.AutoSize = true;
            this.SelecctionarLablel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelecctionarLablel.Location = new System.Drawing.Point(37, 81);
            this.SelecctionarLablel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SelecctionarLablel.Name = "SelecctionarLablel";
            this.SelecctionarLablel.Size = new System.Drawing.Size(161, 20);
            this.SelecctionarLablel.TabIndex = 4;
            this.SelecctionarLablel.Text = "Selecciona al invitado";
            // 
            // Titulo_invitar
            // 
            this.Titulo_invitar.AutoSize = true;
            this.Titulo_invitar.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Titulo_invitar.Location = new System.Drawing.Point(34, 27);
            this.Titulo_invitar.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Titulo_invitar.Name = "Titulo_invitar";
            this.Titulo_invitar.Size = new System.Drawing.Size(221, 37);
            this.Titulo_invitar.TabIndex = 3;
            this.Titulo_invitar.Text = "Crear Partida";
            // 
            // Jugador1ComboBox
            // 
            this.Jugador1ComboBox.FormattingEnabled = true;
            this.Jugador1ComboBox.Location = new System.Drawing.Point(41, 114);
            this.Jugador1ComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.Jugador1ComboBox.Name = "Jugador1ComboBox";
            this.Jugador1ComboBox.Size = new System.Drawing.Size(164, 21);
            this.Jugador1ComboBox.TabIndex = 0;
            this.Jugador1ComboBox.SelectedIndexChanged += new System.EventHandler(this.Jugador1ComboBox_SelectedIndexChanged);
            // 
            // manualToolStripMenuItem
            // 
            this.manualToolStripMenuItem.Name = "manualToolStripMenuItem";
            this.manualToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.manualToolStripMenuItem.Text = "Manual";
            // 
            // consultasToolStripMenuItem
            // 
            this.consultasToolStripMenuItem.Name = "consultasToolStripMenuItem";
            this.consultasToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.consultasToolStripMenuItem.Text = "Consultas";
            // 
            // Principal_Logged
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = global::ProyectoSO.Properties.Resources.fondo_gwent;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1552, 880);
            this.Controls.Add(this.CrearPartida);
            this.Controls.Add(this.panelConectados);
            this.Controls.Add(this.Bienvenida);
            this.Controls.Add(this.BarraPrincipal);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.BarraPrincipal;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Principal_Logged";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
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
        private System.Windows.Forms.Label SelecctionarLablel;
        private System.Windows.Forms.Label Titulo_invitar;
        private System.Windows.Forms.ComboBox Jugador1ComboBox;
        private System.Windows.Forms.Button EnviarPartida;
        private System.Windows.Forms.DataGridView DGVInvitados;
        private System.Windows.Forms.DataGridViewTextBoxColumn Invitado;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Accepted;
        private System.Windows.Forms.Label EnviadoLbl;
        private System.Windows.Forms.ComboBox CartasComboBox;
        private System.Windows.Forms.Label CartasLbl;
        private System.Windows.Forms.ToolStripMenuItem otrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem galeríaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem darseDeBajaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manualToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultasToolStripMenuItem;
    }
}