namespace ProyectoSO
{
    partial class Principal_LogOut
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
            this.Connector_button = new System.Windows.Forms.Button();
            this.IP_box = new System.Windows.Forms.TextBox();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.inicioDeSesiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Desconectar = new System.Windows.Forms.Button();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Connector_button
            // 
            this.Connector_button.Location = new System.Drawing.Point(322, 130);
            this.Connector_button.Name = "Connector_button";
            this.Connector_button.Size = new System.Drawing.Size(114, 42);
            this.Connector_button.TabIndex = 0;
            this.Connector_button.Text = "Conexión";
            this.Connector_button.UseVisualStyleBackColor = true;
            this.Connector_button.Click += new System.EventHandler(this.Connector_button_Click);
            // 
            // IP_box
            // 
            this.IP_box.Location = new System.Drawing.Point(322, 74);
            this.IP_box.Name = "IP_box";
            this.IP_box.Size = new System.Drawing.Size(127, 22);
            this.IP_box.TabIndex = 1;
            this.IP_box.Text = "192.168.56.101";
            // 
            // menuStrip2
            // 
            this.menuStrip2.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(800, 24);
            this.menuStrip2.TabIndex = 3;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inicioDeSesiónToolStripMenuItem,
            this.registroToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(70, 20);
            this.toolStripMenuItem1.Text = "Conexión";
            // 
            // inicioDeSesiónToolStripMenuItem
            // 
            this.inicioDeSesiónToolStripMenuItem.Name = "inicioDeSesiónToolStripMenuItem";
            this.inicioDeSesiónToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.inicioDeSesiónToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.inicioDeSesiónToolStripMenuItem.Text = "Inicio de Sesión";
            this.inicioDeSesiónToolStripMenuItem.Click += new System.EventHandler(this.inicioDeSesiónToolStripMenuItem_Click);
            // 
            // registroToolStripMenuItem
            // 
            this.registroToolStripMenuItem.Name = "registroToolStripMenuItem";
            this.registroToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.registroToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.registroToolStripMenuItem.Text = "Registro";
            this.registroToolStripMenuItem.Click += new System.EventHandler(this.registroToolStripMenuItem_Click);
            // 
            // Desconectar
            // 
            this.Desconectar.Location = new System.Drawing.Point(323, 207);
            this.Desconectar.Name = "Desconectar";
            this.Desconectar.Size = new System.Drawing.Size(113, 44);
            this.Desconectar.TabIndex = 4;
            this.Desconectar.Text = "Desconectar";
            this.Desconectar.UseVisualStyleBackColor = true;
            this.Desconectar.Click += new System.EventHandler(this.Desconectar_Click);
            // 
            // Principal_LogOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Desconectar);
            this.Controls.Add(this.IP_box);
            this.Controls.Add(this.Connector_button);
            this.Controls.Add(this.menuStrip2);
            this.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MainMenuStrip = this.menuStrip2;
            this.Name = "Principal_LogOut";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Principal";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Connector_button;
        private System.Windows.Forms.TextBox IP_box;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem inicioDeSesiónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registroToolStripMenuItem;
        private System.Windows.Forms.Button Desconectar;
    }
}

