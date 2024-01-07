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
            this.NombreLbl = new System.Windows.Forms.Label();
            this.Correo = new System.Windows.Forms.Label();
            this.PasswordLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // register_btn
            // 
            this.register_btn.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.register_btn.Location = new System.Drawing.Point(400, 369);
            this.register_btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.register_btn.Name = "register_btn";
            this.register_btn.Size = new System.Drawing.Size(140, 53);
            this.register_btn.TabIndex = 0;
            this.register_btn.Text = "Registrar";
            this.register_btn.UseVisualStyleBackColor = true;
            this.register_btn.Click += new System.EventHandler(this.register_btn_Click);
            // 
            // user_box
            // 
            this.user_box.Location = new System.Drawing.Point(419, 174);
            this.user_box.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.user_box.Name = "user_box";
            this.user_box.Size = new System.Drawing.Size(100, 22);
            this.user_box.TabIndex = 1;
            this.user_box.TextChanged += new System.EventHandler(this.user_box_TextChanged);
            this.user_box.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.user_box_KeyPress);
            // 
            // mail_box
            // 
            this.mail_box.Location = new System.Drawing.Point(419, 250);
            this.mail_box.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mail_box.Name = "mail_box";
            this.mail_box.Size = new System.Drawing.Size(100, 22);
            this.mail_box.TabIndex = 2;
            this.mail_box.TextChanged += new System.EventHandler(this.user_box_TextChanged);
            this.mail_box.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.user_box_KeyPress);
            // 
            // pass_box
            // 
            this.pass_box.Location = new System.Drawing.Point(419, 321);
            this.pass_box.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pass_box.Name = "pass_box";
            this.pass_box.PasswordChar = '*';
            this.pass_box.Size = new System.Drawing.Size(100, 22);
            this.pass_box.TabIndex = 3;
            this.pass_box.TextChanged += new System.EventHandler(this.user_box_TextChanged);
            this.pass_box.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.user_box_KeyPress);
            // 
            // NombreLbl
            // 
            this.NombreLbl.AutoSize = true;
            this.NombreLbl.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NombreLbl.Location = new System.Drawing.Point(396, 135);
            this.NombreLbl.Name = "NombreLbl";
            this.NombreLbl.Size = new System.Drawing.Size(108, 15);
            this.NombreLbl.TabIndex = 4;
            this.NombreLbl.Text = "Nombre de usuario";
            // 
            // Correo
            // 
            this.Correo.AutoSize = true;
            this.Correo.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Correo.Location = new System.Drawing.Point(441, 212);
            this.Correo.Name = "Correo";
            this.Correo.Size = new System.Drawing.Size(43, 15);
            this.Correo.TabIndex = 5;
            this.Correo.Text = "Correo";
            // 
            // PasswordLbl
            // 
            this.PasswordLbl.AutoSize = true;
            this.PasswordLbl.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordLbl.Location = new System.Drawing.Point(429, 289);
            this.PasswordLbl.Name = "PasswordLbl";
            this.PasswordLbl.Size = new System.Drawing.Size(68, 15);
            this.PasswordLbl.TabIndex = 6;
            this.PasswordLbl.Text = "Contraseña";
            // 
            // register_form
            // 
            this.AcceptButton = this.register_btn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ProyectoSO.Properties.Resources.register;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(920, 591);
            this.Controls.Add(this.PasswordLbl);
            this.Controls.Add(this.Correo);
            this.Controls.Add(this.NombreLbl);
            this.Controls.Add(this.pass_box);
            this.Controls.Add(this.mail_box);
            this.Controls.Add(this.user_box);
            this.Controls.Add(this.register_btn);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
        private System.Windows.Forms.Label NombreLbl;
        private System.Windows.Forms.Label Correo;
        private System.Windows.Forms.Label PasswordLbl;
    }
}