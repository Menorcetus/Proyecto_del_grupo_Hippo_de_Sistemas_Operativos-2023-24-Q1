using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace ProyectoSO
{
    public partial class Interfaz_juego : Form
    {
        User user;
        Socket server;
        int ID_partida;
        public PictureBox[] ManoCartas = new PictureBox[15];
        public Interfaz_juego(User user, Socket server, int ID_partida)
        {
            InitializeComponent();
            this.user = user;
            this.server = server;
            this.ID_partida = ID_partida;
        }

        internal void RecibirChat(string mensaje)
        {
            string[] trozos = mensaje.Split('/');
            if (Convert.ToInt32(trozos[0]) == ID_partida)
            {
                ChatOutput.AppendText(String.Format("-> {0}: {1}", trozos[1], trozos[2]) + Environment.NewLine);
            }
        }

        private void ChatEnviar_Click(object sender, EventArgs e)
        {
            string mensaje = "6/" + this.ID_partida + "/" + this.user.Name + "/" + ChatInput.Text;
            if (ChatInput.Text != "")
            {
                byte[] msg = Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
            ChatInput.Text = "";
        }

        private void Interfaz_juego_Load(object sender, EventArgs e)
        {
            
            
            
        }

        internal void RecibirMano(string mensaje)
        {
            ManoCartas[0] = Mano1;
            ManoCartas[1] = Mano2;
            ManoCartas[2] = Mano3;
            ManoCartas[3] = Mano4;
            ManoCartas[4] = Mano5;
            ManoCartas[5] = Mano6;
            ManoCartas[6] = Mano7;
            ManoCartas[7] = Mano8;
            ManoCartas[8] = Mano9;
            ManoCartas[9] = Mano10;


            string[] trozos = mensaje.Split('/');
            Carta[] mano = new Carta[Convert.ToInt32(trozos[0])];
            for (int i = 0; i < Convert.ToInt32(trozos[0]); i ++)
            {
                mano[i] = new Carta();
                mano[i].id = Convert.ToInt32(trozos[i+1]);
                //mano[i - 1].nombre = trozos[i + 1];
                //mano[i - 1].fuerza = Convert.ToInt32(trozos[i + 2]);
                //mano[i - 1].tipo = Convert.ToInt32(trozos[i + 3]);
                string resourceName = "_" + Convert.ToString(mano[i].id);
                //ManoCartas[i - 1].BackgroundImage = resourceName;
                ManoCartas[i].Image = (System.Drawing.Bitmap)Properties.Resources.ResourceManager.GetObject(resourceName);

            }
        }

        private void PedirMazo_btn_Click(object sender, EventArgs e)
        {
            string mensaje = "7/" + this.ID_partida + "/" + this.user.Name;
            byte[] msg = Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            //PedirMazo_btn.Enabled = false;
        }

        private void Mano10_MouseMove(object sender, MouseEventArgs e)
        {
            this.Mano10.Size = new System.Drawing.Size(80, 160);
            this.Mano10.BringToFront();
        }

        private void Mano10_MouseLeave(object sender, EventArgs e)
        {
            this.Mano10.Size = new System.Drawing.Size(48, 96);
        }

        private void Mano5_MouseMove(object sender, MouseEventArgs e)
        {
            this.Mano5.Size = new System.Drawing.Size(80, 160);
            this.Mano5.BringToFront();
        }

        private void Mano5_MouseLeave(object sender, EventArgs e)
        {
            this.Mano5.Size = new System.Drawing.Size(48, 96);
        }

        private void Mano9_MouseMove(object sender, MouseEventArgs e)
        {
            this.Mano9.Size = new System.Drawing.Size(80, 160);
            this.Mano9.BringToFront();
        }

        private void Mano9_MouseLeave(object sender, EventArgs e)
        {
            this.Mano9.Size = new System.Drawing.Size(48, 96);
        }

        private void Mano8_MouseMove(object sender, MouseEventArgs e)
        {
            this.Mano8.Size = new System.Drawing.Size(80, 160);
            this.Mano8.BringToFront();
        }

        private void Mano8_MouseLeave(object sender, EventArgs e)
        {
            this.Mano8.Size = new System.Drawing.Size(48, 96);
        }

        private void Mano7_MouseLeave(object sender, EventArgs e)
        {
            this.Mano7.Size = new System.Drawing.Size(48, 96);
        }

        private void Mano7_MouseMove(object sender, MouseEventArgs e)
        {
            this.Mano7.Size = new System.Drawing.Size(80, 160);
            this.Mano7.BringToFront();
        }

        private void Mano6_MouseMove(object sender, MouseEventArgs e)
        {
            this.Mano6.Size = new System.Drawing.Size(80, 160);
            this.Mano6.BringToFront();
        }

        private void Mano6_MouseLeave(object sender, EventArgs e)
        {
            this.Mano6.Size = new System.Drawing.Size(48, 96);
        }

        private void Mano4_MouseMove(object sender, MouseEventArgs e)
        {
            this.Mano4.Size = new System.Drawing.Size(80, 160);
            this.Mano4.BringToFront();
        }

        private void Mano4_MouseLeave(object sender, EventArgs e)
        {
            this.Mano4.Size = new System.Drawing.Size(48, 96);
        }

        private void Mano3_MouseMove(object sender, MouseEventArgs e)
        {
            this.Mano3.Size = new System.Drawing.Size(80, 160);
            this.Mano3.BringToFront();
        }

        private void Mano3_MouseLeave(object sender, EventArgs e)
        {
            this.Mano3.Size = new System.Drawing.Size(48, 96);
        }

        private void Mano2_MouseMove(object sender, MouseEventArgs e)
        {
            this.Mano2.Size = new System.Drawing.Size(80, 160);
            this.Mano2.BringToFront();
        }

        private void Mano2_MouseLeave(object sender, EventArgs e)
        {
            this.Mano2.Size = new System.Drawing.Size(48, 96);
        }

        private void Mano1_MouseLeave(object sender, EventArgs e)
        {
            this.Mano1.Size = new System.Drawing.Size(48, 96);
        }

        private void Mano1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Mano1.Size = new System.Drawing.Size(80, 160);
            this.Mano1.BringToFront();
        }
    }
}