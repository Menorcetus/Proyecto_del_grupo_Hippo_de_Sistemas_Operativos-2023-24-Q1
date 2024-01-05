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
    public partial class CartaObservada : Form
    {
        string nombre;
        int fuerza;
        PictureBox cartaimage;
        public CartaObservada(Carta carta)
        {
            InitializeComponent();
            this.nombre = carta.name;
            this.fuerza = carta.fuerza;
            this.cartaimage = carta.picture;
        }

        private void CartaObservada_Load(object sender, EventArgs e)
        {
            CartaBox.BackgroundImage = cartaimage.Image;
            NombreLbl.Text = nombre;
            FuerzaLbl.Text = Convert.ToString(fuerza);
        }
    }
}
