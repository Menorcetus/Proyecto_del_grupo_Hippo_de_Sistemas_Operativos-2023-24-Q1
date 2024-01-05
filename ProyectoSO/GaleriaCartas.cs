using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoSO
{
    public partial class GaleriaCartas : Form
    {
        string mensaje;
        Carta[] cartasgaleria = new Carta[30];
        CartaObservada observacion;
        Thread ThreadCarta;

        public GaleriaCartas(string mensaje)
        {
            InitializeComponent();
            this.mensaje = mensaje;
        }

        private void GaleriaCartas_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < cartasgaleria.Length; i++)
            {
                cartasgaleria[i] = new Carta();
            }

            cartasgaleria[0].picture = Carta1;
            cartasgaleria[1].picture = Carta2;
            cartasgaleria[2].picture = Carta3;
            cartasgaleria[3].picture = Carta4;
            cartasgaleria[4].picture = Carta5;
            cartasgaleria[5].picture = Carta6;
            cartasgaleria[6].picture = Carta7;
            cartasgaleria[7].picture = Carta8;
            cartasgaleria[8].picture = Carta9;
            cartasgaleria[9].picture = Carta10;
            cartasgaleria[10].picture = Carta11;
            cartasgaleria[11].picture = Carta12;
            cartasgaleria[12].picture = Carta13;
            cartasgaleria[13].picture = Carta14;
            cartasgaleria[14].picture = Carta15;
            cartasgaleria[15].picture = Carta16;
            cartasgaleria[16].picture = Carta17;
            cartasgaleria[17].picture = Carta18;
            cartasgaleria[18].picture = Carta19;
            cartasgaleria[19].picture = Carta20;
            cartasgaleria[20].picture = Carta21;
            cartasgaleria[21].picture = Carta22;
            cartasgaleria[22].picture = Carta23;
            cartasgaleria[23].picture = Carta24;
            cartasgaleria[24].picture = Carta25;
            cartasgaleria[25].picture = Carta26;
            cartasgaleria[26].picture = Carta27;
            cartasgaleria[27].picture = Carta28;
            cartasgaleria[28].picture = Carta29;
            cartasgaleria[29].picture = Carta30;

            string[] trozos = mensaje.Split('/');
            for (int i = 0; i < cartasgaleria.Length; i++)
            {
                cartasgaleria[i].id = Convert.ToInt32(trozos[3*i]);
                cartasgaleria[i].name = Convert.ToString(trozos[3*i + 1]);
                cartasgaleria[i].fuerza = Convert.ToInt32(trozos[3*i + 2]);
                string resourceName = "_" + Convert.ToString(cartasgaleria[i].id);
                cartasgaleria[i].picture.Image = (System.Drawing.Bitmap)Properties.Resources.ResourceManager.GetObject(resourceName);
            }
        }

        private int DameCartaMano(PictureBox picturebox)
        {
            int i = 0;
            while (i < cartasgaleria.Length)
            {
                if (cartasgaleria[i].picture == picturebox)
                {
                    return i;
                }
                i++;
            }
            return -1;
        }

        private void Carta22_Click(object sender, EventArgs e)
        {
            PictureBox picturebox = (PictureBox)sender;
            Carta carta = cartasgaleria[DameCartaMano(picturebox)];
            observacion = new CartaObservada(carta);
            ThreadStart tsCarta = delegate { observacion.ShowDialog(); };
            ThreadCarta = new Thread(tsCarta);
            ThreadCarta.Start();
        }
    }
}
