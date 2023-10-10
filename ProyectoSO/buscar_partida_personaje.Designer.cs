namespace ProyectoSO
{
    partial class buscar_partida_personaje
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
            this.ID_pers_box = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.IDsend_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ID_pers_box
            // 
            this.ID_pers_box.Location = new System.Drawing.Point(338, 146);
            this.ID_pers_box.Name = "ID_pers_box";
            this.ID_pers_box.Size = new System.Drawing.Size(100, 22);
            this.ID_pers_box.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(335, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "ID del personaje";
            // 
            // IDsend_btn
            // 
            this.IDsend_btn.Location = new System.Drawing.Point(351, 197);
            this.IDsend_btn.Name = "IDsend_btn";
            this.IDsend_btn.Size = new System.Drawing.Size(75, 23);
            this.IDsend_btn.TabIndex = 2;
            this.IDsend_btn.Text = "Buscar";
            this.IDsend_btn.UseVisualStyleBackColor = true;
            this.IDsend_btn.Click += new System.EventHandler(this.IDsend_btn_Click);
            // 
            // buscar_partida_personaje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.IDsend_btn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ID_pers_box);
            this.Name = "buscar_partida_personaje";
            this.Text = "buscar_partida_personaje";
            this.Load += new System.EventHandler(this.buscar_partida_personaje_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ID_pers_box;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button IDsend_btn;
    }
}