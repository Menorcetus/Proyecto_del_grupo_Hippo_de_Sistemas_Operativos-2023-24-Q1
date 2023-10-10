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
    public partial class buscar_partida_personaje : Form
    {

        User user;
        Socket server;
        public buscar_partida_personaje(User user, Socket server)
        {
            InitializeComponent();
            this.user = user;
            this.server = server;
            if (server == null)
            {
                MessageBox.Show("No estas conectado al servidor, conectate antes de continuar");
            }
        }

        private void buscar_partida_personaje_Load(object sender, EventArgs e)
        {

        }

        private void IDsend_btn_Click(object sender, EventArgs e)
        {
            string ID = ID_pers_box.Text;
            ID_pers_box.Clear();
            string mensaje = "4/" + ID;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            //Recibimos la respuesta del servidor
            byte[] msg2 = new byte[512];
            server.Receive(msg2);

            mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
            string[] v = mensaje.Split('/');
            int i = 0;
            while (i < v.Length)
            {

                MessageBox.Show(v[i]); // a mejorar
                i++;
            }
            
            Close();
        }
    }
}
