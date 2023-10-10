using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using ProyectoSO;

namespace ProyectoSO
{
    public partial class Form1 : Form
    {
        Socket server;
        User user = new User();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        public void Connector_button_Click(object sender, EventArgs e)
        {

            //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
            //al que deseamos conectarnos
            IPAddress direc = IPAddress.Parse(IP_box.Text);
            IPEndPoint ipep = new IPEndPoint(direc, 9070);


            //Creamos el socket 
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ipep);//Intentamos conectar el socket
                this.BackColor = Color.Green;
                MessageBox.Show("Conectado");

            }
            catch (SocketException ex)
            {
                //Si hay excepcion imprimimos error y salimos del programa con return 
                MessageBox.Show("No he podido conectar con el servidor");
                server = null;
                return;
            }
        }

        private void inicioDeSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {

            login_form lform = new login_form(user, server);
            lform.Show();
            user = lform.GetUser();

        }

        private void registroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            register_form rform = new register_form(user, server);
            rform.Show();
            user = rform.GetUser();
        }

        private void Desconectar_Click(object sender, EventArgs e)
        {
            // Se terminó el servicio. 
            // Nos desconectamos
            string mensaje = "0/";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            this.BackColor = Color.Gray;
            server.Shutdown(SocketShutdown.Both);
            server.Close();
        }

        private void sinVidasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string mensaje = "3/";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            //Recibimos la respuesta del servidor
            byte[] msg2 = new byte[512];
            server.Receive(msg2);


            mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
            MessageBox.Show(mensaje);
        }

        private void buscarPersonajeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buscar_partida_personaje bspers = new buscar_partida_personaje(user, server);
            bspers.Show();
        }

        private void buscarPersonajeEnPartidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buscar_partida_usuario bpus = new buscar_partida_usuario(user, server);
            bpus.Show();
        }
    }
}


