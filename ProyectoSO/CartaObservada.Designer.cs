namespace ProyectoSO
{
    partial class CartaObservada
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
            this.CartaBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.NombreLbl = new System.Windows.Forms.Label();
            this.FuerzaLbl = new System.Windows.Forms.Label();
            this.descripcLbl = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.NombreLbl_2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.CartaBox)).BeginInit();
            this.SuspendLayout();
            // 
            // CartaBox
            // 
            this.CartaBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CartaBox.Location = new System.Drawing.Point(63, 67);
            this.CartaBox.Name = "CartaBox";
            this.CartaBox.Size = new System.Drawing.Size(300, 600);
            this.CartaBox.TabIndex = 0;
            this.CartaBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 18F);
            this.label1.Location = new System.Drawing.Point(408, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 27);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 18F);
            this.label2.Location = new System.Drawing.Point(408, 232);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 27);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fuerza:";
            // 
            // NombreLbl
            // 
            this.NombreLbl.AutoSize = true;
            this.NombreLbl.Font = new System.Drawing.Font("Times New Roman", 18F);
            this.NombreLbl.Location = new System.Drawing.Point(69, 23);
            this.NombreLbl.Name = "NombreLbl";
            this.NombreLbl.Size = new System.Drawing.Size(28, 27);
            this.NombreLbl.TabIndex = 4;
            this.NombreLbl.Text = "--";
            // 
            // FuerzaLbl
            // 
            this.FuerzaLbl.AutoSize = true;
            this.FuerzaLbl.Font = new System.Drawing.Font("Times New Roman", 18F);
            this.FuerzaLbl.Location = new System.Drawing.Point(497, 232);
            this.FuerzaLbl.Name = "FuerzaLbl";
            this.FuerzaLbl.Size = new System.Drawing.Size(28, 27);
            this.FuerzaLbl.TabIndex = 5;
            this.FuerzaLbl.Text = "--";
            // 
            // descripcLbl
            // 
            this.descripcLbl.AutoSize = true;
            this.descripcLbl.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descripcLbl.Location = new System.Drawing.Point(410, 375);
            this.descripcLbl.Name = "descripcLbl";
            this.descripcLbl.Size = new System.Drawing.Size(22, 21);
            this.descripcLbl.TabIndex = 6;
            this.descripcLbl.Text = "--";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 18F);
            this.label3.Location = new System.Drawing.Point(409, 324);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 27);
            this.label3.TabIndex = 7;
            this.label3.Text = "Descripción:";
            // 
            // NombreLbl_2
            // 
            this.NombreLbl_2.AutoSize = true;
            this.NombreLbl_2.BackColor = System.Drawing.Color.Transparent;
            this.NombreLbl_2.Font = new System.Drawing.Font("Times New Roman", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NombreLbl_2.Location = new System.Drawing.Point(520, 109);
            this.NombreLbl_2.Name = "NombreLbl_2";
            this.NombreLbl_2.Size = new System.Drawing.Size(172, 28);
            this.NombreLbl_2.TabIndex = 8;
            this.NombreLbl_2.Text = "--------------------";
            // 
            // CartaObservada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1081, 690);
            this.Controls.Add(this.NombreLbl_2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.descripcLbl);
            this.Controls.Add(this.FuerzaLbl);
            this.Controls.Add(this.NombreLbl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CartaBox);
            this.Name = "CartaObservada";
            this.Load += new System.EventHandler(this.CartaObservada_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CartaBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox CartaBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label NombreLbl;
        private System.Windows.Forms.Label FuerzaLbl;
        private System.Windows.Forms.Label descripcLbl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label NombreLbl_2;
    }
}