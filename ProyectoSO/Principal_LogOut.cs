﻿using System;
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
using System.Globalization;
using WMPLib;
using System.Reflection.Emit;
using System.Diagnostics;

namespace ProyectoSO
{
    public partial class Principal_LogOut : Form
    {
        Socket server;
        User user = new User();
        Thread atender; Thread ThreadLogged; Thread ThreadJuego; Thread ThreadGaleria;
        Principal_Logged logged_form;
        login_form lform;
        register_form rform;
        Interfaz_juego juego;
        GaleriaCartas galeria;
        int Entry = 1;
        WindowsMediaPlayer player = new WindowsMediaPlayer();




        public Principal_LogOut()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            this.player = player;         
            
        }

        public void AtenderServidor()
        {
            while (true)
            {
                byte[] msg2 = new byte[1500];
                server.Receive(msg2);

                string clean_ms = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                string[] trozos = clean_ms.Split(new[] {'/'}, 2);

                int codigo = Convert.ToInt32(trozos[0]);
                string mensaje = trozos[1];

                ConsolaControl.AppendText(String.Format("Entry {0}: {1}/{2}. ", Entry, codigo, mensaje));
                ConsolaControl.AppendText(Environment.NewLine);
                Entry++;

                switch (codigo)
                {
                    case 1:
                        rform.Respuesta(mensaje);
                        break;
                    case 2:
                        int res = lform.Respuesta(mensaje);
                        if (res == 0)
                        {
                            logged_form = new Principal_Logged(lform.GetUser(), server, player);
                            this.user = lform.GetUser();
                            lform.Close();

                            ThreadStart ts = delegate { logged_form.ShowDialog();};
                            ThreadLogged = new Thread(ts);
                            ThreadLogged.Start();
                        }
                        else
                        {
                            lform.UsuarioLbl.ForeColor = Color.Black;
                            lform.PaswordLbl.ForeColor = Color.Black;
                        }
                        break;
                    case 3: // rellena tabla de conectados
                        logged_form.Tabla(mensaje);
                        break;
                    case 4:
                        logged_form.ResponderInvitacion(mensaje);
                        break;
                    case 5:
                        logged_form.MostrarRespuesta(mensaje);
                        break;
                    case 6: // iniciar partida y crear interfaz de juego nueva
                        player.controls.stop();
                        string[] trozosMsg = mensaje.Split('/');
                        int id_partida = Convert.ToInt32(trozosMsg[0]);
                        int accion = Convert.ToInt32(trozosMsg[1]);
                        int num_cartas = Convert.ToInt32(trozosMsg[2]);
                        string jugador1 = trozosMsg[3];
                        string jugador2 = trozosMsg[4];
                        juego = new Interfaz_juego(user, server, id_partida, accion, num_cartas, jugador1, jugador2);
                        ThreadStart tsJuego = delegate { juego.ShowDialog();};
                        ThreadJuego = new Thread(tsJuego);
                        ThreadJuego.Start();
                        
                        break;
                    case 7:
                        juego.RecibirChat(mensaje);
                        break;

                    case 8:
                        juego.RecibirMano(mensaje);
                        break;
                    case 9:
                        juego.RecibirManoEnemiga(mensaje);
                        break;
                    case 10:
                        juego.ReiniciarTurno(mensaje);
                        break;
                    case 11:
                        juego.EnviarResultados();
                        break;
                    case 12:
                        juego.RecibirResultadoFinal(mensaje);
                        logged_form.Jugador1ComboBox.Enabled = true;
                        logged_form.CartasComboBox.Enabled = true;
                        logged_form.EnviadoLbl.Text = null;
                        logged_form.EnviarPartida.Text = "Invitar";
                        logged_form.EnviarPartida.Enabled = true;
                        break;
                    case 13:
                        galeria = new GaleriaCartas(mensaje);
                        ThreadStart tsGaleria = delegate { galeria.ShowDialog(); };
                        ThreadGaleria = new Thread(tsGaleria);
                        ThreadGaleria.Start();
                        break;
                    case 14: // Consulta la lista de jugadores con los que he echado una partida.
                        logged_form.LlenarEnfrentados(mensaje);
                        break;
                    case 15:
                        logged_form.LlenarResultadosRival(mensaje);
                        break;
                    case 16:
                        logged_form.LlenarPeriodos(mensaje);
                        break;

                }
            }

        }

        public void Connector_button_Click(object sender, EventArgs e)
        {

            if (IP_Box.Text == "")
            {
                MessageBox.Show("Selecciona un servidor, por favor.");
            }


            if (this.BackColor != Color.Green && IP_Box.Text != "")
            {
                //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
                //al que deseamos conectarnos

          

                IPAddress direc = IPAddress.Parse(IP_Box.Text);
                IPEndPoint ipep = new IPEndPoint(direc, 50060);


                //Creamos el socket 
                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                try
                {
                    server.Connect(ipep);//Intentamos conectar el socket
                    this.BackColor = Color.Green;
                    MessageBox.Show("Conectado");
                    ConsolaControl.AppendText(String.Format("Entry {0}: Conectado a {1}. ", Entry, IP_Box.Text) + Environment.NewLine);
                    Entry++;
                    IP_Box.Enabled = false;
                    ConexionStripMenuItem1.Visible = true;
                }
                catch (SocketException ex)
                {
                    //Si hay excepcion imprimimos error y salimos
                    MessageBox.Show("No he podido conectar con el servidor");
                    // Mucahs gracias a Asier Lopez^2 por ayudarnos con la consola de control
                    ConsolaControl.AppendText(String.Format("Entry {0}: No he podido conectar con el servidor {1}. ", Entry, IP_Box.Text) + Environment.NewLine);
                    Entry++;
                    server = null;
                    return;
                }

                ThreadStart ts = delegate { AtenderServidor(); };
                atender = new Thread(ts);
                atender.Start();
            }
            else if (IP_Box.Text != "" && this.BackColor == Color.Green)
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
                ConsolaControl.AppendText(String.Format("Entry {0}: Se ha cerrado la conexion con {1}. ", Entry, IP_Box.Text) + Environment.NewLine);
                Entry++;
                this.BackColor = Color.Gray;
                server.Shutdown(SocketShutdown.Both);
                server.Close();
                IP_Box.Enabled = true; 
                ConexionStripMenuItem1.Visible = false;
            }
            else
                MessageBox.Show("No estas conectado a ningun servidor.");
        }

        private void consolaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (consolaToolStripMenuItem.Checked == false)
                ConsolaControl.Visible = false;
            else if (consolaToolStripMenuItem.Checked == true)
                ConsolaControl.Visible = true;
        }

        private void IP_Box_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void manuelToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Process proceso = new Process();
            proceso.StartInfo.FileName = @"..\..\Resources\Manual_Juego.pdf"; // en el bin\Debug
            try
            {
                proceso.Start();
            }
            catch
            {
                MessageBox.Show("Error al abrir el manual");
            }

        }
    }
}


