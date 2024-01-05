using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoSO
{
    public partial class Galeria : Form
    {


        public Color borderColor;
        public Galeria()
        {
            InitializeComponent();
            int hola;
        }

        private void Galeria_Load(object sender, EventArgs e)
        {

        }

        private void ChangePictureBoxBorderColor(PictureBox pictureBox, Color color)
        {
            borderColor = color;
            pictureBox.Paint += PictureBox_Paint;
        }

        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            ControlPaint.DrawBorder(e.Graphics, pictureBox.ClientRectangle, borderColor, ButtonBorderStyle.Solid);
        }

        private void pictbox11ratas_MouseMove(object sender, MouseEventArgs e)
        {
            PictureBox picturebox = (PictureBox)sender;
            picturebox.Size = new Size(60, 120);
            ChangePictureBoxBorderColor(picturebox, Color.Yellow);
        }

        private void pictbox11ratas_MouseLeave(object sender, EventArgs e)
        {
            PictureBox picturebox = (PictureBox)sender;
            picturebox.Size = new Size(48, 96);
            ChangePictureBoxBorderColor(picturebox, Color.Transparent);
        }




    }

}
