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

namespace ProyectoSO
{
    public partial class Interfaz_juego : Form
    {
        User user;
        Socket server;
        int ID_partida;
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
            string mensaje = "7/" + this.ID_partida + "/" + this.user.Name;
            byte[] msg = Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }

        internal void RecibirMano(string mensaje)
        {
            string[] trozos = mensaje.Split('/');
            Carta[] mano = new Carta[Convert.ToInt32(trozos[0])];
            for (int i = 1; i < Convert.ToInt32(trozos[0]); i+=5)
            {
                mano[i - 1].id = Convert.ToInt32(trozos[i]);
                mano[i - 1].nombre = trozos[i + 1];
                mano[i - 1].fuerza = Convert.ToInt32(trozos[i + 2]);
                mano[i - 1].tipo = Convert.ToInt32(trozos[i + 3]);
                mano[i - 1].repetible = Convert.ToInt32(trozos[i + 4]);
            }
        }
    }
}
