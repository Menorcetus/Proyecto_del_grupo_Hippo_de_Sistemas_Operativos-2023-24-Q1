namespace ProyectoSO
{
    partial class register_form
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
            this.register_btn = new System.Windows.Forms.Button();
            this.user_box = new System.Windows.Forms.TextBox();
            this.mail_box = new System.Windows.Forms.TextBox();
            this.pass_box = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Correo = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // register_btn
            // 
            this.register_btn.Location = new System.Drawing.Point(336, 287);
            this.register_btn.Name = "register_btn";
            this.register_btn.Size = new System.Drawing.Size(120, 46);
            this.register_btn.TabIndex = 0;
            this.register_btn.Text = "Registrar";
            this.register_btn.UseVisualStyleBackColor = true;
            this.register_btn.Click += new System.EventHandler(this.register_btn_Click);
            // 
            // user_box
            // 
            this.user_box.Location = new System.Drawing.Point(346, 99);
            this.user_box.Name = "user_box";
            this.user_box.Size = new System.Drawing.Size(100, 22);
            this.user_box.TabIndex = 1;
            // 
            // mail_box
            // 
            this.mail_box.Location = new System.Drawing.Point(346, 165);
            this.mail_box.Name = "mail_box";
            this.mail_box.Size = new System.Drawing.Size(100, 22);
            this.mail_box.TabIndex = 2;
            // 
            // pass_box
            // 
            this.pass_box.Location = new System.Drawing.Point(346, 228);
            this.pass_box.Name = "pass_box";
            this.pass_box.PasswordChar = '*';
            this.pass_box.Size = new System.Drawing.Size(100, 22);
            this.pass_box.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(334, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nombre de usuario";
            // 
            // Correo
            // 
            this.Correo.AutoSize = true;
            this.Correo.Location = new System.Drawing.Point(374, 135);
            this.Correo.Name = "Correo";
            this.Correo.Size = new System.Drawing.Size(48, 16);
            this.Correo.TabIndex = 5;
            this.Correo.Text = "Correo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(360, 199);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Contraseña";
            // 
            // register_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Correo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pass_box);
            this.Controls.Add(this.mail_box);
            this.Controls.Add(this.user_box);
            this.Controls.Add(this.register_btn);
            this.Name = "register_form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Resgistro de usuario";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button register_btn;
        private System.Windows.Forms.TextBox user_box;
        private System.Windows.Forms.TextBox mail_box;
        private System.Windows.Forms.TextBox pass_box;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Correo;
        private System.Windows.Forms.Label label3;
    }
}