namespace ProyectoSO
{
    partial class Interfaz_juego
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Chatlabel = new System.Windows.Forms.Label();
            this.ChatEnviar = new System.Windows.Forms.Button();
            this.ChatOutput = new System.Windows.Forms.TextBox();
            this.ChatInput = new System.Windows.Forms.TextBox();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Location = new System.Drawing.Point(582, 387);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1258, 126);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.Chatlabel);
            this.panel2.Controls.Add(this.ChatEnviar);
            this.panel2.Controls.Add(this.ChatOutput);
            this.panel2.Controls.Add(this.ChatInput);
            this.panel2.Location = new System.Drawing.Point(49, 71);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(440, 442);
            this.panel2.TabIndex = 1;
            // 
            // Chatlabel
            // 
            this.Chatlabel.AutoSize = true;
            this.Chatlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Chatlabel.Location = new System.Drawing.Point(32, 35);
            this.Chatlabel.Name = "Chatlabel";
            this.Chatlabel.Size = new System.Drawing.Size(68, 29);
            this.Chatlabel.TabIndex = 3;
            this.Chatlabel.Text = "Chat ";
            // 
            // ChatEnviar
            // 
            this.ChatEnviar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ChatEnviar.Location = new System.Drawing.Point(324, 380);
            this.ChatEnviar.Name = "ChatEnviar";
            this.ChatEnviar.Size = new System.Drawing.Size(88, 22);
            this.ChatEnviar.TabIndex = 2;
            this.ChatEnviar.Text = "Enviar";
            this.ChatEnviar.UseVisualStyleBackColor = true;
            this.ChatEnviar.Click += new System.EventHandler(this.ChatEnviar_Click);
            // 
            // ChatOutput
            // 
            this.ChatOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ChatOutput.Enabled = false;
            this.ChatOutput.Location = new System.Drawing.Point(35, 74);
            this.ChatOutput.Multiline = true;
            this.ChatOutput.Name = "ChatOutput";
            this.ChatOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ChatOutput.Size = new System.Drawing.Size(377, 300);
            this.ChatOutput.TabIndex = 1;
            // 
            // ChatInput
            // 
            this.ChatInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ChatInput.Location = new System.Drawing.Point(35, 380);
            this.ChatInput.Name = "ChatInput";
            this.ChatInput.Size = new System.Drawing.Size(283, 22);
            this.ChatInput.TabIndex = 0;
            // 
            // Interfaz_juego
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackgroundImage = global::ProyectoSO.Properties.Resources.fondo_gwent;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Interfaz_juego";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Interfaz_juego";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button ChatEnviar;
        private System.Windows.Forms.TextBox ChatOutput;
        private System.Windows.Forms.TextBox ChatInput;
        private System.Windows.Forms.Label Chatlabel;
    }
}