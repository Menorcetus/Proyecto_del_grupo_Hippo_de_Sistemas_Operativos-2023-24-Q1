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
            ((System.ComponentModel.ISupportInitialize)(this.CartaBox)).BeginInit();
            this.SuspendLayout();
            // 
            // CartaBox
            // 
            this.CartaBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CartaBox.Location = new System.Drawing.Point(94, 103);
            this.CartaBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CartaBox.Name = "CartaBox";
            this.CartaBox.Size = new System.Drawing.Size(450, 923);
            this.CartaBox.TabIndex = 0;
            this.CartaBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 18F);
            this.label1.Location = new System.Drawing.Point(612, 169);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 27);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 18F);
            this.label2.Location = new System.Drawing.Point(612, 357);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 27);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fuerza:";
            // 
            // NombreLbl
            // 
            this.NombreLbl.AutoSize = true;
            this.NombreLbl.Font = new System.Drawing.Font("Times New Roman", 18F);
            this.NombreLbl.Location = new System.Drawing.Point(765, 169);
            this.NombreLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.NombreLbl.Name = "NombreLbl";
            this.NombreLbl.Size = new System.Drawing.Size(28, 27);
            this.NombreLbl.TabIndex = 4;
            this.NombreLbl.Text = "--";
            // 
            // FuerzaLbl
            // 
            this.FuerzaLbl.AutoSize = true;
            this.FuerzaLbl.Font = new System.Drawing.Font("Times New Roman", 18F);
            this.FuerzaLbl.Location = new System.Drawing.Point(746, 357);
            this.FuerzaLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.FuerzaLbl.Name = "FuerzaLbl";
            this.FuerzaLbl.Size = new System.Drawing.Size(28, 27);
            this.FuerzaLbl.TabIndex = 5;
            this.FuerzaLbl.Text = "--";
            // 
            // CartaObservada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1618, 1061);
            this.Controls.Add(this.FuerzaLbl);
            this.Controls.Add(this.NombreLbl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CartaBox);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "CartaObservada";
            this.Text = "Form1";
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
    }
}