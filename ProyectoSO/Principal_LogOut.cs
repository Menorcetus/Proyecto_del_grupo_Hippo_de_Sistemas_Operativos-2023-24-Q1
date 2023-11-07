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
using System.Runtime.CompilerServices;
using System.Threading;

namespace ProyectoSO
{
    public partial class Principal_LogOut : Form
    {
        Socket server;
        User user = new User();
        Thread atender; Thread ThreadLogged;
        Principal_Logged logged_form;
        login_form lform;
        register_form rform;

        public Principal_LogOut()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        public void AtenderServidor()
        {
            while (true)
            {
                byte[] msg2 = new byte[512];
                server.Receive(msg2);

                string[] trozos = Encoding.ASCII.GetString(msg2).Split(new[] {'/'}, 2);
                int codigo = Convert.ToInt32(trozos[0]);
                string mensaje = trozos[1];

                switch (codigo)
                {
                    case 1:
                        rform.Respuesta(mensaje);
                        break;
                    case 2:
                        int res = lform.Respuesta(mensaje);
                        if (res == 0)
                        {
                            logged_form = new Principal_Logged(lform.GetUser(), server);
                            lform.Close();

                            ThreadStart ts = delegate { logged_form.ShowDialog();};
                            ThreadLogged = new Thread(ts);
                            ThreadLogged.Start();
                        }
                        break;
                    case 3:
                        logged_form.Tabla(mensaje);
                        break;
                    case 4:
                        logged_form.GestionarLogOut(mensaje);
                        logged_form.Close();
                        break;
                }
            }

        }

        public void Connector_button_Click(object sender, EventArgs e)
        {
            if (this.BackColor != Color.Green)
            {
                //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
                //al que deseamos conectarnos
                IPAddress direc = IPAddress.Parse(IP_box.Text);
                IPEndPoint ipep = new IPEndPoint(direc, 50060);


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

                ThreadStart ts = delegate { AtenderServidor(); };
                atender = new Thread(ts);
                atender.Start();
            }
            else
                MessageBox.Show("Ya estas conectado");
        }

        public void inicioDeSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lform = new login_form(server);
            lform.ShowDialog();
            

        }

        public void registroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.rform = new register_form(user,server);
            rform.ShowDialog();
        }

        private void Desconectar_Click(object sender, EventArgs e)
        {
            if (this.BackColor == Color.Green)
            {
                // Se terminó el servicio. 
                // Nos desconectamos
                string mensaje = "0/";
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                atender.Abort();
                this.BackColor = Color.Gray;
                server.Shutdown(SocketShutdown.Both);
                server.Close();
            }
            else
                MessageBox.Show("No esta conectado");
        }

    }
}


