namespace ProyectoSO
{
    partial class Grid_Form_Conectados
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
            this.dataGridConectados = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridConectados)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridConectados
            // 
            this.dataGridConectados.AllowUserToAddRows = false;
            this.dataGridConectados.AllowUserToDeleteRows = false;
            this.dataGridConectados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridConectados.Location = new System.Drawing.Point(0, 0);
            this.dataGridConectados.Name = "dataGridConectados";
            this.dataGridConectados.ReadOnly = true;
            this.dataGridConectados.RowHeadersWidth = 51;
            this.dataGridConectados.RowTemplate.Height = 24;
            this.dataGridConectados.Size = new System.Drawing.Size(582, 298);
            this.dataGridConectados.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(641, 352);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 38);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Grid_Form_Conectados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridConectados);
            this.Name = "Grid_Form_Conectados";
            this.Text = "Grid_Form_Conectados";
            this.Load += new System.EventHandler(this.Grid_Form_Conectados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridConectados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridConectados;
        private System.Windows.Forms.Button button1;
    }
}