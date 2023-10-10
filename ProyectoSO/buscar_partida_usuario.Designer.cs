namespace ProyectoSO
{
    partial class buscar_partida_usuario
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
            this.label1 = new System.Windows.Forms.Label();
            this.ID_usuario_box = new System.Windows.Forms.TextBox();
            this.sendID_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(336, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID de usuario";
            // 
            // ID_usuario_box
            // 
            this.ID_usuario_box.Location = new System.Drawing.Point(320, 177);
            this.ID_usuario_box.Name = "ID_usuario_box";
            this.ID_usuario_box.Size = new System.Drawing.Size(119, 22);
            this.ID_usuario_box.TabIndex = 1;
            // 
            // sendID_btn
            // 
            this.sendID_btn.Location = new System.Drawing.Point(339, 237);
            this.sendID_btn.Name = "sendID_btn";
            this.sendID_btn.Size = new System.Drawing.Size(75, 23);
            this.sendID_btn.TabIndex = 2;
            this.sendID_btn.Text = "Buscar";
            this.sendID_btn.UseVisualStyleBackColor = true;
            this.sendID_btn.Click += new System.EventHandler(this.sendID_btn_Click);
            // 
            // buscar_partida_usuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.sendID_btn);
            this.Controls.Add(this.ID_usuario_box);
            this.Controls.Add(this.label1);
            this.Name = "buscar_partida_usuario";
            this.Text = "buscar_usuario";
            this.Load += new System.EventHandler(this.buscar_partida_usuario_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ID_usuario_box;
        private System.Windows.Forms.Button sendID_btn;
    }
}