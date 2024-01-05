namespace ProyectoSO
{
    partial class Galeria
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
            this.pictbox11ratas = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictbox11ratas)).BeginInit();
            this.SuspendLayout();
            // 
            // pictbox11ratas
            // 
            this.pictbox11ratas.Image = global::ProyectoSO.Properties.Resources._11;
            this.pictbox11ratas.InitialImage = global::ProyectoSO.Properties.Resources._11;
            this.pictbox11ratas.Location = new System.Drawing.Point(90, 86);
            this.pictbox11ratas.Name = "pictbox11ratas";
            this.pictbox11ratas.Size = new System.Drawing.Size(103, 206);
            this.pictbox11ratas.TabIndex = 0;
            this.pictbox11ratas.TabStop = false;
            this.pictbox11ratas.MouseLeave += new System.EventHandler(this.pictbox11ratas_MouseLeave);
            this.pictbox11ratas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictbox11ratas_MouseMove);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(87, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cuerpo a cuerpo";
            // 
            // Galeria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.BurlyWood;
            this.ClientSize = new System.Drawing.Size(1008, 662);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictbox11ratas);
            this.Name = "Galeria";
            this.Text = "Galeria";
            ((System.ComponentModel.ISupportInitialize)(this.pictbox11ratas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictbox11ratas;
        private System.Windows.Forms.Label label1;
    }
}