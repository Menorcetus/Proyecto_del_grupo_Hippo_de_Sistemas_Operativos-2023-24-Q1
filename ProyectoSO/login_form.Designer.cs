namespace ProyectoSO
{
    partial class login_form
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
            this.login_btn = new System.Windows.Forms.Button();
            this.UsuarioLbl = new System.Windows.Forms.Label();
            this.PaswordLbl = new System.Windows.Forms.Label();
            this.user_box = new System.Windows.Forms.TextBox();
            this.pass_box = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // login_btn
            // 
            this.login_btn.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.login_btn.Location = new System.Drawing.Point(324, 410);
            this.login_btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.login_btn.Name = "login_btn";
            this.login_btn.Size = new System.Drawing.Size(92, 41);
            this.login_btn.TabIndex = 0;
            this.login_btn.Text = "Iniciar sesión";
            this.login_btn.UseVisualStyleBackColor = true;
            this.login_btn.Click += new System.EventHandler(this.login_btn_Click);
            // 
            // UsuarioLbl
            // 
            this.UsuarioLbl.AutoSize = true;
            this.UsuarioLbl.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsuarioLbl.Location = new System.Drawing.Point(335, 219);
            this.UsuarioLbl.Name = "UsuarioLbl";
            this.UsuarioLbl.Size = new System.Drawing.Size(49, 15);
            this.UsuarioLbl.TabIndex = 4;
            this.UsuarioLbl.Text = "Usuario";
            // 
            // PaswordLbl
            // 
            this.PaswordLbl.AutoSize = true;
            this.PaswordLbl.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PaswordLbl.Location = new System.Drawing.Point(325, 304);
            this.PaswordLbl.Name = "PaswordLbl";
            this.PaswordLbl.Size = new System.Drawing.Size(68, 15);
            this.PaswordLbl.TabIndex = 5;
            this.PaswordLbl.Text = "Contraseña";
            // 
            // user_box
            // 
            this.user_box.Location = new System.Drawing.Point(321, 263);
            this.user_box.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.user_box.Name = "user_box";
            this.user_box.Size = new System.Drawing.Size(108, 22);
            this.user_box.TabIndex = 1;
            this.user_box.TextChanged += new System.EventHandler(this.user_box_TextChanged);
            this.user_box.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.user_box_KeyPress);
            // 
            // pass_box
            // 
            this.pass_box.Location = new System.Drawing.Point(321, 336);
            this.pass_box.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pass_box.Name = "pass_box";
            this.pass_box.PasswordChar = '*';
            this.pass_box.Size = new System.Drawing.Size(108, 22);
            this.pass_box.TabIndex = 2;
            this.pass_box.TextChanged += new System.EventHandler(this.user_box_TextChanged);
            this.pass_box.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.user_box_KeyPress);
            // 
            // login_form
            // 
            this.AcceptButton = this.login_btn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ProyectoSO.Properties.Resources.loging;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(745, 842);
            this.Controls.Add(this.pass_box);
            this.Controls.Add(this.user_box);
            this.Controls.Add(this.PaswordLbl);
            this.Controls.Add(this.UsuarioLbl);
            this.Controls.Add(this.login_btn);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "login_form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Inicio de  sesión";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button login_btn;
        private System.Windows.Forms.TextBox user_box;
        private System.Windows.Forms.TextBox pass_box;
        public System.Windows.Forms.Label UsuarioLbl;
        public System.Windows.Forms.Label PaswordLbl;
    }
}