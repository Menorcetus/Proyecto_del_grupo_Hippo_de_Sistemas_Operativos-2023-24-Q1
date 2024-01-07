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
using WMPLib;
using System.IO;

namespace ProyectoSO
{
    public partial class Interfaz_juego : Form
    {
        User user;
        string contrincante;
        Socket server;
        int ID_partida;
        public PictureBox[] Mano = new PictureBox[10];
        public Carta[] ManoCartas = new Carta[10];

        public Carta[] CartasArt = new Carta[9]; int FuerzaArt = 0;
        public Carta[] CartasRan = new Carta[9]; int FuerzaRan = 0;
        public Carta[] CartasMel = new Carta[9]; int FuerzaMel = 0;

        public PictureBox[] Mano_Mel = new PictureBox[9];
        public PictureBox[] Mano_Ran = new PictureBox[9];
        public PictureBox[] Mano_Art = new PictureBox[9];
        public Carta[] CartasArt_M = new Carta[9]; int FuerzaArt_M = 0;
        public Carta[] CartasRan_M = new Carta[9]; int FuerzaRan_M = 0;
        public Carta[] CartasMel_M = new Carta[9]; int FuerzaMel_M = 0;

        public Color borderColor;
        public Carta cartaselecc;
        int numCartas;
        int accion;
        int pasado;
        int primero;
        int turnosganados;
        int num_turnos;
        int num_cartas;
        int turno_actual;
        int nocambies = 0;
        WindowsMediaPlayer player2 = new WindowsMediaPlayer();
        WindowsMediaPlayer player3 = new WindowsMediaPlayer();


        public Interfaz_juego(User user, Socket server, int ID_partida, int accion, int num_cartas, string jugador1, string jugador2)
        {
            InitializeComponent();
            this.user = user;
            this.server = server;
            this.ID_partida = ID_partida;
            this.accion = accion;
            this.num_cartas = num_cartas;
            this.turno_actual = 1;
            if (this.user.Name == jugador1)
                this.contrincante = jugador2;
            else
                this.contrincante = jugador1;

            player3.URL = Path.GetFullPath(@"..\..\Resources\partida.wav"); ;
            player3.settings.setMode("loop", true);

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
            ContrincanteLbl.Text = "Contrincante: " + contrincante;
            TurnoLbl.Text = "Turno: 1";
            RondasGanadasLbl.Visible = false;

            CartasArt[0] = new Carta(); CartasRan[0] = new Carta(); CartasMel[0] = new Carta(); CartasArt_M[0] = new Carta(); CartasRan_M[0] = new Carta(); CartasMel_M[0] = new Carta();
            CartasArt[1] = new Carta(); CartasRan[1] = new Carta(); CartasMel[1] = new Carta(); CartasArt_M[1] = new Carta(); CartasRan_M[1] = new Carta(); CartasMel_M[1] = new Carta();
            CartasArt[2] = new Carta(); CartasRan[2] = new Carta(); CartasMel[2] = new Carta(); CartasArt_M[2] = new Carta(); CartasRan_M[2] = new Carta(); CartasMel_M[2] = new Carta();
            CartasArt[3] = new Carta(); CartasRan[3] = new Carta(); CartasMel[3] = new Carta(); CartasArt_M[3] = new Carta(); CartasRan_M[3] = new Carta(); CartasMel_M[3] = new Carta();
            CartasArt[4] = new Carta(); CartasRan[4] = new Carta(); CartasMel[4] = new Carta(); CartasArt_M[4] = new Carta(); CartasRan_M[4] = new Carta(); CartasMel_M[4] = new Carta();
            CartasArt[5] = new Carta(); CartasRan[5] = new Carta(); CartasMel[5] = new Carta(); CartasArt_M[5] = new Carta(); CartasRan_M[5] = new Carta(); CartasMel_M[5] = new Carta();
            CartasArt[6] = new Carta(); CartasRan[6] = new Carta(); CartasMel[6] = new Carta(); CartasArt_M[6] = new Carta(); CartasRan_M[6] = new Carta(); CartasMel_M[6] = new Carta();
            CartasArt[7] = new Carta(); CartasRan[7] = new Carta(); CartasMel[7] = new Carta(); CartasArt_M[7] = new Carta(); CartasRan_M[7] = new Carta(); CartasMel_M[7] = new Carta();
            CartasArt[8] = new Carta(); CartasRan[8] = new Carta(); CartasMel[8] = new Carta(); CartasArt_M[8] = new Carta(); CartasRan_M[8] = new Carta(); CartasMel_M[8] = new Carta();



            CartasArt[0].id = -1; CartasRan[0].id = -1; CartasMel[0].id = -1;   CartasArt_M[0].id = -1; CartasRan_M[0].id = -1; CartasMel_M[0].id = -1;
            CartasArt[1].id = -1; CartasRan[1].id = -1; CartasMel[1].id = -1;   CartasArt_M[1].id = -1; CartasRan_M[1].id = -1; CartasMel_M[1].id = -1;
            CartasArt[2].id = -1; CartasRan[2].id = -1; CartasMel[2].id = -1;   CartasArt_M[2].id = -1; CartasRan_M[2].id = -1; CartasMel_M[2].id = -1;
            CartasArt[3].id = -1; CartasRan[3].id = -1; CartasMel[3].id = -1;   CartasArt_M[3].id = -1; CartasRan_M[3].id = -1; CartasMel_M[3].id = -1;
            CartasArt[4].id = -1; CartasRan[4].id = -1; CartasMel[4].id = -1;   CartasArt_M[4].id = -1; CartasRan_M[4].id = -1; CartasMel_M[4].id = -1;
            CartasArt[5].id = -1; CartasRan[5].id = -1; CartasMel[5].id = -1;   CartasArt_M[5].id = -1; CartasRan_M[5].id = -1; CartasMel_M[5].id = -1;
            CartasArt[6].id = -1; CartasRan[6].id = -1; CartasMel[6].id = -1;   CartasArt_M[6].id = -1; CartasRan_M[6].id = -1; CartasMel_M[6].id = -1;
            CartasArt[7].id = -1; CartasRan[7].id = -1; CartasMel[7].id = -1;   CartasArt_M[7].id = -1; CartasRan_M[7].id = -1; CartasMel_M[7].id = -1;
            CartasArt[8].id = -1; CartasRan[8].id = -1; CartasMel[8].id = -1;   CartasArt_M[8].id = -1; CartasRan_M[8].id = -1; CartasMel_M[8].id = -1;
            
            if (accion == 1)
            {
                turno.Text = "¡Tu turno!";
                primero = 1;
            }

            else
            {
                turno.Text = "¡Turno del contrincante!";
                primero = 0;
            }

        }

        internal void RecibirMano(string mensaje)
        {
            Mano[0] = Mano1;
            Mano[1] = Mano2;
            Mano[2] = Mano3;
            Mano[3] = Mano4;
            Mano[4] = Mano5;
            Mano[5] = Mano6;
            Mano[6] = Mano7;
            Mano[7] = Mano8;
            Mano[8] = Mano9;
            Mano[9] = Mano10;

            string[] trozos = mensaje.Split('/');
            numCartas = Convert.ToInt32(trozos[0]);
            Carta[] mano = new Carta[numCartas];  //Formato: numCartas/ID1/Fuerza1/Tipo1/ID2/Fuerza2/Tipo2/ID3/...
           
            for (int i = 0; i < Convert.ToInt32(trozos[0]); i ++)
            {
                mano[i] = new Carta();
                mano[i].id = Convert.ToInt32(trozos[3*i+1]);
                //mano[i - 1].nombre = trozos[i + 1];
                mano[i].fuerza = Convert.ToInt32(trozos[3*i + 2]);
                mano[i].tipo = Convert.ToInt32(trozos[3*i + 3]);
                string resourceName = "_" + Convert.ToString(mano[i].id);
                //ManoCartas[i - 1].BackgroundImage = resourceName;
                mano[i].picture = Mano[i];
                mano[i].picture.Image = (System.Drawing.Bitmap)Properties.Resources.ResourceManager.GetObject(resourceName);
                ManoCartas[i] = mano[i];
            }
        }

        internal void RecibirManoEnemiga(string mensaje)
        {
            string[] trozos = mensaje.Split(new[] { '/' }, 8);

            FuerzaArt_M = Convert.ToInt32(trozos[1]);
            FuerzaRan_M = Convert.ToInt32(trozos[2]);
            FuerzaMel_M = Convert.ToInt32(trozos[3]);

            FuerzaArt = Convert.ToInt32(trozos[4]);
            FuerzaRan = Convert.ToInt32(trozos[5]);
            FuerzaMel = Convert.ToInt32(trozos[6]);

            if(turno.Text == "¡Turno del contrincante!")
            {
                accion = 1;
                turno.Text = "¡Tu turno!";
            }

            FuerzaArt_lbl.Text = Convert.ToString(FuerzaArt);
            FuerzaRan_lbl.Text = Convert.ToString(FuerzaRan);
            FuerzaMel_lbl.Text = Convert.ToString(FuerzaMel);
            FuerzaArt_M_lbl.Text = Convert.ToString(FuerzaArt_M);
            FuerzaRan_M_lbl.Text = Convert.ToString(FuerzaRan_M);
            FuerzaMel_M_lbl.Text = Convert.ToString(FuerzaMel_M);


            Mano_Mel[0] = Mel1_M; Mano_Ran[0] = Ran1_M; Mano_Art[0] = Art1_M;
            Mano_Mel[1] = Mel2_M; Mano_Ran[1] = Ran2_M; Mano_Art[1] = Art2_M;
            Mano_Mel[2] = Mel3_M; Mano_Ran[2] = Ran3_M; Mano_Art[2] = Art3_M;
            Mano_Mel[3] = Mel4_M; Mano_Ran[3] = Ran4_M; Mano_Art[3] = Art4_M;
            Mano_Mel[4] = Mel5_M; Mano_Ran[4] = Ran5_M; Mano_Art[4] = Art5_M;
            Mano_Mel[5] = Mel6_M; Mano_Ran[5] = Ran6_M; Mano_Art[5] = Art6_M;
            Mano_Mel[6] = Mel7_M; Mano_Ran[6] = Ran7_M; Mano_Art[6] = Art7_M;
            Mano_Mel[7] = Mel8_M; Mano_Ran[7] = Ran8_M; Mano_Art[7] = Art8_M;
            Mano_Mel[8] = Mel9_M; Mano_Ran[8] = Ran9_M; Mano_Art[8] = Art9_M;

            string posiciones = trozos[7];
            string[] pos = posiciones.Split('/');
            Carta[] mano = new Carta[9];

            for (int i = 0; i < 9; i++)
            {
                mano[i] = new Carta();
                mano[i].id = Convert.ToInt32(pos[2 * i]);
                mano[i].fuerza = Convert.ToInt32(pos[2 * i + 1]);
                string resourceName = "_" + Convert.ToString(mano[i].id);

                mano[i].picture = Mano_Mel[i];
                mano[i].picture.Image = (System.Drawing.Bitmap)Properties.Resources.ResourceManager.GetObject(resourceName);
                CartasMel_M[i] = mano[i];
            }
            for (int i = 0; i < 9; i++)
            {
                mano[i] = new Carta();
                mano[i].id = Convert.ToInt32(pos[2 * i + 18]);
                mano[i].fuerza = Convert.ToInt32(pos[2 * i + 1 + 18]);
                string resourceName = "_" + Convert.ToString(mano[i].id);

                mano[i].picture = Mano_Ran[i];
                mano[i].picture.Image = (System.Drawing.Bitmap)Properties.Resources.ResourceManager.GetObject(resourceName);
                CartasRan_M[i] = mano[i];
            }
            for (int i = 0; i < 9; i++)
            {
                mano[i] = new Carta();
                mano[i].id = Convert.ToInt32(pos[2 * i + 36]);
                mano[i].fuerza = Convert.ToInt32(pos[2 * i + 1 + 36]);
                string resourceName = "_" + Convert.ToString(mano[i].id);

                mano[i].picture = Mano_Art[i];
                mano[i].picture.Image = (System.Drawing.Bitmap)Properties.Resources.ResourceManager.GetObject(resourceName);
                CartasArt_M[i] = mano[i];
            }

            if (Convert.ToInt32(pos[53]) == 1 || pasado == 1)
                pasado = 1;

            if (turno.Text == "¡Has pasado!")
            {
                string DistribucionCartas = DistribuirCartas(CartasArt, CartasRan, CartasMel);
                string mensaje2 = "8/" + this.ID_partida + "/" + this.user.Name + "/" + this.FuerzaMel + "/" + this.FuerzaRan + "/" + this.FuerzaArt
                                                        + "/" + this.FuerzaMel_M + "/" + this.FuerzaRan_M + "/" + this.FuerzaArt_M + DistribucionCartas + "0";

                byte[] msg = Encoding.ASCII.GetBytes(mensaje2);
                server.Send(msg);
            }
        }

        private void PedirMazo_btn_Click(object sender, EventArgs e)
        {
            string mensaje = "7/" + this.ID_partida + "/" + this.user.Name;
            byte[] msg = Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
            PedirMazo_btn.Enabled = false;
        }

        internal void ReiniciarTurno(string mensaje) // id_partida/FuerzaTotal/FuerzaTotal_M/resultado
        {
            string[] trozos = mensaje.Split('/');
            this.turno_actual = Convert.ToInt32(trozos[4]);
            if (this.turno_actual != 4)
            {
                TurnoLbl.Text = "Turno: " + trozos[4];
            }

            pasado = 0;
            nocambies = 1;
            if (primero == 1)
            {
                primero = 0;
                accion = 0;
                turno.Text = "¡Turno del contrincante!";
            }
            else if (primero == 0)
            {
                primero = 1;
                accion = 1;
                turno.Text = "¡Tu turno!";
            }

            nocambies = 0;

            FuerzaArt = 0;
            FuerzaMel = 0;
            FuerzaRan = 0;
            FuerzaRan_M = 0;
            FuerzaMel_M = 0;
            FuerzaArt_M = 0;

            FuerzaArt_lbl.Text = "0";
            FuerzaRan_lbl.Text = "0";
            FuerzaMel_lbl.Text = "0";
            FuerzaArt_M_lbl.Text = "0";
            FuerzaRan_M_lbl.Text = "0";
            FuerzaMel_M_lbl.Text = "0";

            CartasArt[0] = new Carta(); CartasRan[0] = new Carta(); CartasMel[0] = new Carta(); CartasArt_M[0] = new Carta(); CartasRan_M[0] = new Carta(); CartasMel_M[0] = new Carta();
            CartasArt[1] = new Carta(); CartasRan[1] = new Carta(); CartasMel[1] = new Carta(); CartasArt_M[1] = new Carta(); CartasRan_M[1] = new Carta(); CartasMel_M[1] = new Carta();
            CartasArt[2] = new Carta(); CartasRan[2] = new Carta(); CartasMel[2] = new Carta(); CartasArt_M[2] = new Carta(); CartasRan_M[2] = new Carta(); CartasMel_M[2] = new Carta();
            CartasArt[3] = new Carta(); CartasRan[3] = new Carta(); CartasMel[3] = new Carta(); CartasArt_M[3] = new Carta(); CartasRan_M[3] = new Carta(); CartasMel_M[3] = new Carta();
            CartasArt[4] = new Carta(); CartasRan[4] = new Carta(); CartasMel[4] = new Carta(); CartasArt_M[4] = new Carta(); CartasRan_M[4] = new Carta(); CartasMel_M[4] = new Carta();
            CartasArt[5] = new Carta(); CartasRan[5] = new Carta(); CartasMel[5] = new Carta(); CartasArt_M[5] = new Carta(); CartasRan_M[5] = new Carta(); CartasMel_M[5] = new Carta();
            CartasArt[6] = new Carta(); CartasRan[6] = new Carta(); CartasMel[6] = new Carta(); CartasArt_M[6] = new Carta(); CartasRan_M[6] = new Carta(); CartasMel_M[6] = new Carta();
            CartasArt[7] = new Carta(); CartasRan[7] = new Carta(); CartasMel[7] = new Carta(); CartasArt_M[7] = new Carta(); CartasRan_M[7] = new Carta(); CartasMel_M[7] = new Carta();
            CartasArt[8] = new Carta(); CartasRan[8] = new Carta(); CartasMel[8] = new Carta(); CartasArt_M[8] = new Carta(); CartasRan_M[8] = new Carta(); CartasMel_M[8] = new Carta();


            CartasArt[0].id = -1; CartasRan[0].id = -1; CartasMel[0].id = -1; CartasArt_M[0].id = -1; CartasRan_M[0].id = -1; CartasMel_M[0].id = -1;
            CartasArt[1].id = -1; CartasRan[1].id = -1; CartasMel[1].id = -1; CartasArt_M[1].id = -1; CartasRan_M[1].id = -1; CartasMel_M[1].id = -1;
            CartasArt[2].id = -1; CartasRan[2].id = -1; CartasMel[2].id = -1; CartasArt_M[2].id = -1; CartasRan_M[2].id = -1; CartasMel_M[2].id = -1;
            CartasArt[3].id = -1; CartasRan[3].id = -1; CartasMel[3].id = -1; CartasArt_M[3].id = -1; CartasRan_M[3].id = -1; CartasMel_M[3].id = -1;
            CartasArt[4].id = -1; CartasRan[4].id = -1; CartasMel[4].id = -1; CartasArt_M[4].id = -1; CartasRan_M[4].id = -1; CartasMel_M[4].id = -1;
            CartasArt[5].id = -1; CartasRan[5].id = -1; CartasMel[5].id = -1; CartasArt_M[5].id = -1; CartasRan_M[5].id = -1; CartasMel_M[5].id = -1;
            CartasArt[6].id = -1; CartasRan[6].id = -1; CartasMel[6].id = -1; CartasArt_M[6].id = -1; CartasRan_M[6].id = -1; CartasMel_M[6].id = -1;
            CartasArt[7].id = -1; CartasRan[7].id = -1; CartasMel[7].id = -1; CartasArt_M[7].id = -1; CartasRan_M[7].id = -1; CartasMel_M[7].id = -1;
            CartasArt[8].id = -1; CartasRan[8].id = -1; CartasMel[8].id = -1; CartasArt_M[8].id = -1; CartasRan_M[8].id = -1; CartasMel_M[8].id = -1;

            CartasArt[0].picture = Art1; CartasMel[0].picture = Mel1; CartasRan[0].picture = Ran1; CartasMel_M[0].picture = Mel1_M; CartasArt_M[0].picture = Art1_M; CartasRan_M[0].picture = Ran1_M;
            CartasArt[1].picture = Art2; CartasMel[1].picture = Mel2; CartasRan[1].picture = Ran2; CartasMel_M[1].picture = Mel2_M; CartasArt_M[1].picture = Art2_M; CartasRan_M[1].picture = Ran2_M;
            CartasArt[2].picture = Art3; CartasMel[2].picture = Mel3; CartasRan[2].picture = Ran3; CartasMel_M[2].picture = Mel3_M; CartasArt_M[2].picture = Art3_M; CartasRan_M[2].picture = Mel3_M;
            CartasArt[3].picture = Art4; CartasMel[3].picture = Mel4; CartasRan[3].picture = Ran4; CartasMel_M[3].picture = Mel4_M; CartasArt_M[3].picture = Art4_M; CartasRan_M[3].picture = Mel4_M;
            CartasArt[4].picture = Art5; CartasMel[4].picture = Mel5; CartasRan[4].picture = Ran5; CartasMel_M[4].picture = Mel5_M; CartasArt_M[4].picture = Art5_M; CartasRan_M[4].picture = Mel5_M;
            CartasArt[5].picture = Art6; CartasMel[5].picture = Mel6; CartasRan[5].picture = Ran6; CartasMel_M[5].picture = Mel6_M; CartasArt_M[5].picture = Art6_M; CartasRan_M[5].picture = Mel6_M;
            CartasArt[6].picture = Art7; CartasMel[6].picture = Mel7; CartasRan[6].picture = Ran7; CartasMel_M[6].picture = Mel7_M; CartasArt_M[6].picture = Art7_M; CartasRan_M[6].picture = Mel7_M;
            CartasArt[7].picture = Art8; CartasMel[7].picture = Mel8; CartasRan[7].picture = Ran8; CartasMel_M[7].picture = Mel8_M; CartasArt_M[7].picture = Art8_M; CartasRan_M[7].picture = Mel8_M;
            CartasArt[8].picture = Art9; CartasMel[8].picture = Mel9; CartasRan[8].picture = Ran9; CartasMel_M[8].picture = Mel9_M; CartasArt_M[8].picture = Art9_M; CartasRan_M[8].picture = Mel9_M;

            for (int i = 0; i < 9; i++)
            {
                CartasArt[i].picture.Image = null;
                CartasMel[i].picture.Image = null;
                CartasRan[i].picture.Image = null;
                CartasArt_M[i].picture.Image = null;
                CartasMel_M[i].picture.Image = null;
                CartasRan_M[i].picture.Image = null;

            }

            // 0 = usuario pierde
            // 1 = usuario gana
            // 2 = usuario empata
            int resultado = Convert.ToInt32(trozos[3]);
            string texto;
            switch (resultado)
            {
                case 0:
                    texto = string.Format("Has perdido la ronda.\n resultado: {0} vs {1}", trozos[2], trozos[1]);
                    MessageBox.Show(texto);
                    break;
                case 1:
                    texto = string.Format("Has ganado la ronda.\n resultado: {0} vs {1}", trozos[2], trozos[1]);
                    MessageBox.Show(texto);
                    turnosganados++;
                    break;
                case 2:
                    texto = string.Format("Empate.\n resultado: {0} vs {1}", trozos[2], trozos[1]);
                    MessageBox.Show(texto);
                    turnosganados++;
                    break;
            } 

            RondasGanadasLbl.Visible = true;
            RondasGanadasLbl.Text = "Has ganado:" + turnosganados + " turnos.";
        }

        internal void EnviarResultados()
        { 
            string respuesta = "9/" + this.ID_partida + "/" + this.user.Name + "/" + this.turnosganados;
            byte[] msg = Encoding.ASCII.GetBytes(respuesta);
            server.Send(msg);
        }

        internal void RecibirResultadoFinal(string mensaje)
        {
            string[] trozos = mensaje.Split('/');
            int resultado = Convert.ToInt32(trozos[1]);
            string texto; string ganador;
            switch (resultado)
            {
                case 0:
                    ganador = trozos[2];
                    texto = string.Format("Has perdido contra {0}", ganador);
                    MessageBox.Show(texto);
                    Close();
                    break;
                case 1:
                    ganador = trozos[2];
                    texto = string.Format("Felicidades {0}, has ganado", ganador);
                    MessageBox.Show(texto);
                    Close();
                    break;
                case 2:
                    texto = string.Format("Habeis empatado");
                    MessageBox.Show(texto);
                    Close();
                    break;
            }

            player3.controls.stop();

            
        }

        //=============================================================================================================
        // Funciones de auxiliares para cartas
        private void ChangePictureBoxBorderColor(PictureBox pictureBox, Color color)
        {
            borderColor = color;
            pictureBox.Paint += PictureBox_Paint;
        }

        private void ClearPictureBoxBorderColor(PictureBox pictureBox)
        {
            borderColor = Color.Transparent;
            pictureBox.Paint -= PictureBox_Paint; // Unsubscribe from the Paint event
            pictureBox.Refresh(); // Refresh the PictureBox
        }

        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            ControlPaint.DrawBorder(e.Graphics, pictureBox.ClientRectangle, borderColor, ButtonBorderStyle.Solid);
        }

        private void M_PictureBox_Click(object sender, EventArgs e)
        {
            PictureBox picturebox = (PictureBox)sender;
            ChangePictureBoxBorderColor(picturebox, Color.Red);
            if (DameCartaMano(picturebox) != -1)
                cartaselecc = ManoCartas[DameCartaMano(picturebox)];
        }

        private void T_PictureBox_MouseOverCorrect(object sender, EventArgs e)
        {
            PictureBox picturebox = (PictureBox)sender;
            picturebox.BackColor = Color.FromArgb(128, Color.Yellow);
        }

        private void M_PictureBox_MouseOver(object sender, EventArgs e)
        {
            PictureBox picturebox = (PictureBox)sender;
            if (DameCartaMano(picturebox) != -1)
                picturebox.Size = new Size(60, 120);
                ChangePictureBoxBorderColor(picturebox, Color.Yellow);
        }

        private void M_PictureBox_MouseLeave(object sender, EventArgs e)
        {
            PictureBox picturebox = (PictureBox)sender;
            if (DameCartaMano(picturebox) != -1)
                picturebox.Size = new Size(48, 96);
                ChangePictureBoxBorderColor(picturebox, Color.Transparent);
        }

        private void T_PictureBox_MouseOverIncorrect(object sender, EventArgs e)
        {
            PictureBox picturebox = (PictureBox)sender;
            picturebox.BackColor = Color.FromArgb(128, Color.Red);
        }

        private void T_PictureBox_MouseLeaving(object sender, EventArgs e)
        {
            PictureBox picturebox = (PictureBox)sender;
            picturebox.BackColor = Color.Transparent;
        }

        private void T_PictureBox_Click(object sender, EventArgs e)
        {
            PictureBox picBox = (PictureBox)sender;
            ManoCartas[DameCartaMano(cartaselecc.picture)].picture.Visible = false;
            picBox.BackColor = Color.Transparent;
            ManoCartas[DameCartaMano(cartaselecc.picture)].picture.Size = new Size(60, 120);
            picBox.Image = ManoCartas[DameCartaMano(cartaselecc.picture)].picture.Image;
        }

        private int DameCartaMano(PictureBox picturebox)
        {
            int i = 0;
            while (i < numCartas)
            {
                if (ManoCartas[i].picture == picturebox)
                {
                    return i;
                }
                i++;
            }
            return -1;
        }

        private string DistribuirCartas(Carta[] Artilleria, Carta[] Rango, Carta[] Melee)
        {
            // Genera un vector de string guardando las id de las cartas segun la distribucion en el tablero
            // Primero coloca la fila de melee, luego rango i luego artilleria
            // Si no hay carta en la posicion se envia un -1
            string matriz ="/";
            for (int i = 0; i < Melee.Length; i++)
                matriz = matriz + Melee[i].id + "/" + Melee[i].fuerza + "/";
            for (int i = 0; i < Rango.Length; i++)
                matriz = matriz + Rango[i].id + "/" + Rango[i].fuerza + "/";
            for (int i = 0; i < Artilleria.Length; i++)
                matriz = matriz + Artilleria[i].id + "/" + Artilleria[i].fuerza + "/";
            return matriz;
        }


        private void PasarTurnoBtn_Click(object sender, EventArgs e)
        {

            string DistribucionCartas = DistribuirCartas(CartasArt, CartasRan, CartasMel);
            string mensaje = "8/" + this.ID_partida + "/" + this.user.Name + "/" + this.FuerzaMel + "/" + this.FuerzaRan + "/" + this.FuerzaArt
                                                    + "/" + this.FuerzaMel_M + "/" + this.FuerzaRan_M + "/" + this.FuerzaArt_M + DistribucionCartas + "1";

            byte[] msg = Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
            turno.Text = "¡Has pasado!";
            accion = 0;
        }

        private int ContarFuerza(Carta[] Cartas)
        {
            int total = 0;
            for (int i=0; i < Cartas.Length; i++)
            {
                if (Cartas[i].id != -1)
                    total += Cartas[i].fuerza;
            }
            return total;
        }

        private void turno_TextChanged(object sender, EventArgs e)
        {
            if (nocambies == 0)
            {
                FuerzaArt_lbl.Text = Convert.ToString(FuerzaArt);
                FuerzaRan_lbl.Text = Convert.ToString(FuerzaRan);
                FuerzaMel_lbl.Text = Convert.ToString(FuerzaMel);
                FuerzaArt_M_lbl.Text = Convert.ToString(FuerzaArt_M);
                FuerzaRan_M_lbl.Text = Convert.ToString(FuerzaRan_M);
                FuerzaMel_M_lbl.Text = Convert.ToString(FuerzaMel_M);
                // Si se cambia el texto significa que se ha colocado una carta, para que se el contrincante sea consciente se auto envia un mensaje al servidor.
                if (turno.Text == "¡Turno del contrincante!")
                {
                    PasarTurnoBtn.Enabled = false;
                    string DistribucionCartas = DistribuirCartas(CartasArt, CartasRan, CartasMel);
                    string mensaje = "8/" + this.ID_partida + "/" + this.user.Name + "/" + this.FuerzaMel + "/" + this.FuerzaRan + "/" + this.FuerzaArt
                                                            + "/" + this.FuerzaMel_M + "/" + this.FuerzaRan_M + "/" + this.FuerzaArt_M + DistribucionCartas + "0";

                    byte[] msg = Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
                }
                else if (turno.Text == "¡Tu turno!")
                    PasarTurnoBtn.Enabled = true;
            }
        }

        //=============================================================================================================
        // Acciones pasar por encima de carta

        private void Mano10_MouseMove(object sender, MouseEventArgs e)
        {
            M_PictureBox_MouseOver(Mano10, e);
        }

        private void Mano10_MouseLeave(object sender, EventArgs e)
        {
            M_PictureBox_MouseLeave(Mano10, e);
        }

        private void Mano9_MouseMove(object sender, MouseEventArgs e)
        {
            M_PictureBox_MouseOver(Mano9, e);
        }

        private void Mano9_MouseLeave(object sender, EventArgs e)
        {
            M_PictureBox_MouseLeave(Mano9, e);
        }

        private void Mano8_MouseMove(object sender, MouseEventArgs e)
        {
            M_PictureBox_MouseOver(Mano8, e);
        }

        private void Mano8_MouseLeave(object sender, EventArgs e)
        {
            M_PictureBox_MouseLeave(Mano8, e);
        }

        private void Mano7_MouseLeave(object sender, EventArgs e)
        {
            M_PictureBox_MouseLeave(Mano7, e);

        }

        private void Mano7_MouseMove(object sender, MouseEventArgs e)
        {
            M_PictureBox_MouseOver(Mano7, e);
        }

        private void Mano6_MouseMove(object sender, MouseEventArgs e)
        {
            M_PictureBox_MouseOver(Mano6, e);
        }

        private void Mano6_MouseLeave(object sender, EventArgs e)
        {
            M_PictureBox_MouseLeave(Mano6, e);
        }

        private void Mano5_MouseMove(object sender, MouseEventArgs e)
        {
            M_PictureBox_MouseOver(Mano5, e);
        }

        private void Mano5_MouseLeave(object sender, EventArgs e)
        {
            M_PictureBox_MouseLeave(Mano5, e);
        }
        private void Mano4_MouseMove(object sender, MouseEventArgs e)
        {
            M_PictureBox_MouseOver(Mano4, e);
        }

        private void Mano4_MouseLeave(object sender, EventArgs e)
        {
            M_PictureBox_MouseLeave(Mano4, e);
        }

        private void Mano3_MouseMove(object sender, MouseEventArgs e)
        {
            M_PictureBox_MouseOver(Mano3, e);
        }

        private void Mano3_MouseLeave(object sender, EventArgs e)
        {
            M_PictureBox_MouseLeave(Mano3, e);
        }

        private void Mano2_MouseMove(object sender, MouseEventArgs e)
        {
            M_PictureBox_MouseOver(Mano2, e);
        }

        private void Mano2_MouseLeave(object sender, EventArgs e)
        {
            M_PictureBox_MouseLeave(Mano2, e);
        }

        private void Mano1_MouseLeave(object sender, EventArgs e)
        {
            M_PictureBox_MouseLeave(Mano1, e);
        }

        private void Mano1_MouseMove(object sender, MouseEventArgs e)
        {
            M_PictureBox_MouseOver(Mano1, e);
        }

        //=============================================================================================================
        // Click en carta del tablero
        // Artilleria:


        
        private void Art1_Click(object sender, EventArgs e)
        {
            if (accion == 1)
            { 
                    if (cartaselecc != null)
                    {
                        if (cartaselecc.tipo == 3 || cartaselecc.tipo == 4)
                        {

                            T_PictureBox_Click(sender, e);
                            CartasArt[0] = cartaselecc;
                            player2.URL = Path.GetFullPath(@"..\..\Resources\carta.wav");
                            FuerzaArt = ContarFuerza(CartasArt);
                            cartaselecc = null;
                            accion = 0;
                            turno.Text = "¡Turno del contrincante!";
                        }
                    }
            }
        }

        private void Art2_Click(object sender, EventArgs e)
        {


            if (accion == 1)
            {
                if (cartaselecc != null)
                {
                     if (cartaselecc.tipo == 3 || cartaselecc.tipo == 4)
                     {
                         T_PictureBox_Click(sender, e);
                         CartasArt[1] = cartaselecc;
                        player2.URL = Path.GetFullPath(@"..\..\Resources\carta.wav");
                        FuerzaArt = ContarFuerza(CartasArt);
                         cartaselecc = null;
                         accion = 0;
                         turno.Text = "¡Turno del contrincante!";
                     }
                }
            }
        
        }

        private void Art3_Click(object sender, EventArgs e)
        {
            if (accion == 1)
            {
                if (cartaselecc != null)
                {
                    if (cartaselecc.tipo == 3 || cartaselecc.tipo == 4)
                    {
                        T_PictureBox_Click(sender, e);
                        CartasArt[2] = cartaselecc;
                        player2.URL = Path.GetFullPath(@"..\..\Resources\carta.wav");
                        FuerzaArt = ContarFuerza(CartasArt);
                        cartaselecc = null;
                        accion = 0;
                        turno.Text = "¡Turno del contrincante!";
                    }
                }
            }
        }

        private void Art4_Click(object sender, EventArgs e)
        {
            if (accion == 1)
            {
                if (cartaselecc != null)
                {
                    if (cartaselecc.tipo == 3 || cartaselecc.tipo == 4)
                    {
                        T_PictureBox_Click(sender, e);
                        CartasArt[3] = cartaselecc;
                        FuerzaArt = ContarFuerza(CartasArt);
                        player2.URL = Path.GetFullPath(@"..\..\Resources\carta.wav");
                        cartaselecc = null;
                        accion = 0;
                        turno.Text = "¡Turno del contrincante!";
                    }
                }
            }
        }

        private void Art5_Click(object sender, EventArgs e)
        {
            if (accion == 1)
            {
                if (cartaselecc != null)
                {
                    if (cartaselecc.tipo == 3 || cartaselecc.tipo == 4)
                    {
                        T_PictureBox_Click(sender, e);
                        CartasArt[4] = cartaselecc;
                        FuerzaArt = ContarFuerza(CartasArt);
                        player2.URL = Path.GetFullPath(@"..\..\Resources\carta.wav");
                        cartaselecc = null;
                        accion = 0;
                        turno.Text = "¡Turno del contrincante!";
                    }
                }
            }
        }

        private void Art6_Click(object sender, EventArgs e)
        {
            if (accion == 1)
            {
                if (cartaselecc != null)
                {
                    if (cartaselecc.tipo == 3 || cartaselecc.tipo == 4)
                    {
                        T_PictureBox_Click(sender, e);
                        CartasArt[5] = cartaselecc;
                        FuerzaArt = ContarFuerza(CartasArt);
                        player2.URL = Path.GetFullPath(@"..\..\Resources\carta.wav");
                        cartaselecc = null;
                        accion = 0;
                        turno.Text = "¡Turno del contrincante!";
                    }
                }
            }
        }

        private void Art7_Click(object sender, EventArgs e)
        {
            if (accion == 1)
            {
                if (cartaselecc != null)
                {
                    if (cartaselecc.tipo == 3 || cartaselecc.tipo == 4)
                    {
                        T_PictureBox_Click(sender, e);
                        CartasArt[6] = cartaselecc;
                        FuerzaArt = ContarFuerza(CartasArt);
                        player2.URL = Path.GetFullPath(@"..\..\Resources\carta.wav");
                        cartaselecc = null;
                        accion = 0;
                        turno.Text = "¡Turno del contrincante!";
                    }
                }
            }
        }

        private void Art8_Click(object sender, EventArgs e)
        {
            if (accion == 1)
            {
                if (cartaselecc != null)
                {
                    if (cartaselecc.tipo == 3 || cartaselecc.tipo == 4)
                    {
                        T_PictureBox_Click(sender, e);
                        CartasArt[7] = cartaselecc;
                        FuerzaArt = ContarFuerza(CartasArt);
                        player2.URL = Path.GetFullPath(@"..\..\Resources\carta.wav");
                        cartaselecc = null;
                        accion = 0;
                        turno.Text = "¡Turno del contrincante!";

                    }
                }
            }
        }

        private void Art9_Click(object sender, EventArgs e)
        {
            if (accion == 1)
            {
                if (cartaselecc != null)
                {
                    if (cartaselecc.tipo == 3 || cartaselecc.tipo == 4)
                    {
                        T_PictureBox_Click(sender, e);
                        CartasArt[8] = cartaselecc;
                        FuerzaArt = ContarFuerza(CartasArt);
                        player2.URL = Path.GetFullPath(@"..\..\Resources\carta.wav");
                        cartaselecc = null;
                        accion = 0;
                        turno.Text = "¡Turno del contrincante!";
                    }
                }
            }
        }

        // Rango:

        private void Ran1_Click(object sender, EventArgs e)
        {
            if (accion == 1)
            {

               if (cartaselecc != null)
               {
                   if (cartaselecc.tipo == 2 || cartaselecc.tipo == 4)
                   {
                       T_PictureBox_Click(sender, e);
                       CartasRan[0] = cartaselecc;
                       FuerzaRan = ContarFuerza(CartasRan);
                        player2.URL = Path.GetFullPath(@"..\..\Resources\carta.wav");
                        cartaselecc = null;
                        accion = 0;
                        turno.Text = "¡Turno del contrincante!";
                    }
               }
            }
        }

        private void Ran2_Click(object sender, EventArgs e)
        {
            if (accion == 1)
            {

                if (cartaselecc != null)
                {
                    if (cartaselecc.tipo == 2 || cartaselecc.tipo == 4)
                    {
                        T_PictureBox_Click(sender, e);
                        CartasRan[1] = cartaselecc;
                        FuerzaRan = ContarFuerza(CartasRan);
                        player2.URL = Path.GetFullPath(@"..\..\Resources\carta.wav");
                        cartaselecc = null;
                        accion = 0;
                        turno.Text = "¡Turno del contrincante!";
                    }
                }
            }
        }

        private void Ran3_Click(object sender, EventArgs e)
        {
            if (accion == 1)
            {

                if (cartaselecc != null)
                {
                    if (cartaselecc.tipo == 2 || cartaselecc.tipo == 4)
                    {
                        T_PictureBox_Click(sender, e);
                        CartasRan[2] = cartaselecc;
                        FuerzaRan = ContarFuerza(CartasRan);
                        player2.URL = Path.GetFullPath(@"..\..\Resources\carta.wav");
                        cartaselecc = null;
                        accion = 0;
                        turno.Text = "¡Turno del contrincante!";
                    }
                }
            }
        }

        private void Ran4_Click(object sender, EventArgs e)
        {
            if (accion == 1)
            {

                if (cartaselecc != null)
                {
                    if (cartaselecc.tipo == 2 || cartaselecc.tipo == 4)
                    {
                        T_PictureBox_Click(sender, e);
                        CartasRan[3] = cartaselecc;
                        FuerzaRan = ContarFuerza(CartasRan);
                        player2.URL = Path.GetFullPath(@"..\..\Resources\carta.wav");
                        cartaselecc = null;
                        accion = 0;
                        turno.Text = "¡Turno del contrincante!";
                    }
                }
            }
        }

        private void Ran5_Click(object sender, EventArgs e)
        {
            if (accion == 1)
            {

                if (cartaselecc != null)
                {
                    if (cartaselecc.tipo == 2 || cartaselecc.tipo == 4)
                    {
                        T_PictureBox_Click(sender, e);
                        CartasRan[4] = cartaselecc;
                        FuerzaRan = ContarFuerza(CartasRan);
                        player2.URL = Path.GetFullPath(@"..\..\Resources\carta.wav");
                        cartaselecc = null;
                        accion = 0;
                        turno.Text = "¡Turno del contrincante!";
                    }
                }
            }
        }

        private void Ran6_Click(object sender, EventArgs e)
        {
            if (accion == 1)
            {

                if (cartaselecc != null)
                {
                    if (cartaselecc.tipo == 2 || cartaselecc.tipo == 4)
                    {
                        T_PictureBox_Click(sender, e);
                        CartasRan[5] = cartaselecc;
                        FuerzaRan = ContarFuerza(CartasRan);
                        player2.URL = Path.GetFullPath(@"..\..\Resources\carta.wav");
                        cartaselecc = null;
                        accion = 0;
                        turno.Text = "¡Turno del contrincante!";
                    }
                }
            }
        }

        private void Ran7_Click(object sender, EventArgs e)
        {
            if (accion == 1)
            {

                if (cartaselecc != null)
                {
                    if (cartaselecc.tipo == 2 || cartaselecc.tipo == 4)
                    {
                        T_PictureBox_Click(sender, e);
                        CartasRan[6] = cartaselecc;
                        FuerzaRan = ContarFuerza(CartasRan);
                        player2.URL = Path.GetFullPath(@"..\..\Resources\carta.wav");
                        cartaselecc = null;
                        accion = 0;
                        turno.Text = "¡Turno del contrincante!";
                    }
                }
            }
        }

        private void Ran8_Click(object sender, EventArgs e)
        {
            if (accion == 1)
            {

                if (cartaselecc != null)
                {
                    if (cartaselecc.tipo == 2 || cartaselecc.tipo == 4)
                    {
                        T_PictureBox_Click(sender, e);
                        CartasRan[7] = cartaselecc;
                        FuerzaRan = ContarFuerza(CartasRan);
                        player2.URL = Path.GetFullPath(@"..\..\Resources\carta.wav");
                        cartaselecc = null;
                        accion = 0;
                        turno.Text = "¡Turno del contrincante!";
                    }
                }
            }
        }

        private void Ran9_Click(object sender, EventArgs e)
        {
            if (accion == 1)
            {

                if (cartaselecc != null)
                {
                    if (cartaselecc.tipo == 2 || cartaselecc.tipo == 4)
                    {
                        T_PictureBox_Click(sender, e);
                        CartasRan[8] = cartaselecc;
                        FuerzaRan = ContarFuerza(CartasRan);
                        player2.URL = Path.GetFullPath(@"..\..\Resources\carta.wav");
                        cartaselecc = null;
                        accion = 0;
                        turno.Text = "¡Turno del contrincante!";
                    }
                }
            }
        }

        // Melee:

        private void Mel1_Click(object sender, EventArgs e)
        {
            if (accion == 1)
            {

                if (cartaselecc != null)
                {
                    if (cartaselecc.tipo == 1 || cartaselecc.tipo == 4)
                    {
                        T_PictureBox_Click(sender, e);
                        CartasMel[0] = cartaselecc;
                        FuerzaMel = ContarFuerza(CartasMel);
                        player2.URL = Path.GetFullPath(@"..\..\Resources\carta.wav");
                        cartaselecc = null;
                        accion = 0;
                        turno.Text = "¡Turno del contrincante!";
                    }
                }
            }

        }

        private void Mel2_Click(object sender, EventArgs e)
        {
            if (accion == 1)
            {

                if (cartaselecc != null)
                {
                    if (cartaselecc.tipo == 1 || cartaselecc.tipo == 4)
                    {
                        T_PictureBox_Click(sender, e);
                        CartasMel[1] = cartaselecc;
                        FuerzaMel = ContarFuerza(CartasMel);
                        player2.URL = Path.GetFullPath(@"..\..\Resources\carta.wav");
                        cartaselecc = null;
                        accion = 0;
                        turno.Text = "¡Turno del contrincante!";
                    }
                }
            }
        }

        private void Mel3_Click(object sender, EventArgs e)
        {
            if (accion == 1)
            {

                if (cartaselecc != null)
                {
                    if (cartaselecc.tipo == 1 || cartaselecc.tipo == 4)
                    {
                        T_PictureBox_Click(sender, e);
                        CartasMel[2] = cartaselecc;
                        FuerzaMel = ContarFuerza(CartasMel);
                        player2.URL = Path.GetFullPath(@"..\..\Resources\carta.wav");
                        cartaselecc = null;
                        accion = 0;
                        turno.Text = "¡Turno del contrincante!";
                    }
                }
            }
        }

        private void Mel4_Click(object sender, EventArgs e)
        {
            if (accion == 1)
            {

                if (cartaselecc != null)
                {
                    if (cartaselecc.tipo == 1 || cartaselecc.tipo == 4)
                    {
                        T_PictureBox_Click(sender, e);
                        CartasMel[3] = cartaselecc;
                        FuerzaMel = ContarFuerza(CartasMel);
                        player2.URL = Path.GetFullPath(@"..\..\Resources\carta.wav");
                        cartaselecc = null;
                        accion = 0;
                        turno.Text = "¡Turno del contrincante!";
                    }
                }
            }
        }

        private void Mel5_Click(object sender, EventArgs e)
        {
            if (accion == 1)
            {

                if (cartaselecc != null)
                {
                    if (cartaselecc.tipo == 1 || cartaselecc.tipo == 4)
                    {
                        T_PictureBox_Click(sender, e);
                        CartasMel[4] = cartaselecc;
                        FuerzaMel = ContarFuerza(CartasMel);
                        player2.URL = Path.GetFullPath(@"..\..\Resources\carta.wav");
                        cartaselecc = null;
                        accion = 0;
                        turno.Text = "¡Turno del contrincante!";
                    }
                }
            }
        }

        private void Mel6_Click(object sender, EventArgs e)
        {
            if (accion == 1)
            {

                if (cartaselecc != null)
                {
                    if (cartaselecc.tipo == 1 || cartaselecc.tipo == 4)
                    {
                        T_PictureBox_Click(sender, e);
                        CartasMel[5] = cartaselecc;
                        FuerzaMel = ContarFuerza(CartasMel);
                        player2.URL = Path.GetFullPath(@"..\..\Resources\carta.wav");
                        cartaselecc = null;
                        accion = 0;
                        turno.Text = "¡Turno del contrincante!";
                    }
                }
            }
        }

        private void Mel7_Click(object sender, EventArgs e)
        {
            if (accion == 1)
            {

                if (cartaselecc != null)
                {
                    if (cartaselecc.tipo == 1 || cartaselecc.tipo == 4)
                    {
                        T_PictureBox_Click(sender, e);
                        CartasMel[6] = cartaselecc;
                        FuerzaMel = ContarFuerza(CartasMel);
                        player2.URL = Path.GetFullPath(@"..\..\Resources\carta.wav");
                        cartaselecc = null;
                        accion = 0;
                        turno.Text = "¡Turno del contrincante!";
                    }
                }
            }
        }

        private void Mel8_Click(object sender, EventArgs e)
        {
            if (accion == 1)
            {

                if (cartaselecc != null)
                {
                    if (cartaselecc.tipo == 1 || cartaselecc.tipo == 4)
                    {
                        T_PictureBox_Click(sender, e);
                        CartasMel[7] = cartaselecc;
                        FuerzaMel = ContarFuerza(CartasMel);
                        player2.URL = Path.GetFullPath(@"..\..\Resources\carta.wav");
                        cartaselecc = null;
                        accion = 0;
                        turno.Text = "¡Turno del contrincante!";
                    }
                }
            }
        }

        private void Mel9_Click(object sender, EventArgs e)
        {
            if (accion == 1)
            {

                if (cartaselecc != null)
                {
                    if (cartaselecc.tipo == 1 || cartaselecc.tipo == 4)
                    {
                        T_PictureBox_Click(sender, e);
                        CartasMel[8] = cartaselecc;
                        FuerzaMel = ContarFuerza(CartasMel);
                        player2.URL = Path.GetFullPath(@"..\..\Resources\carta.wav");
                        cartaselecc = null;
                        accion = 0;
                        turno.Text = "¡Turno del contrincante!";
                    }
                }
            }
        }

        //=============================================================================================================
        // Mostrar disponibilidad
        // Artilleria:

        private void Art1_MouseMove(object sender, MouseEventArgs e)
        {
            if (cartaselecc != null)
            {
                if (cartaselecc.tipo == 3 || cartaselecc.tipo == 4)
                    T_PictureBox_MouseOverCorrect(sender, e);
                else
                    T_PictureBox_MouseOverIncorrect(sender, e);
            }
        }

        private void Art2_MouseMove(object sender, MouseEventArgs e)
        {
            if (cartaselecc != null)
            {
                if (cartaselecc.tipo == 3 || cartaselecc.tipo == 4)
                    T_PictureBox_MouseOverCorrect(sender, e);
                else
                    T_PictureBox_MouseOverIncorrect(sender, e);
            }
        }

        private void Art3_MouseMove(object sender, MouseEventArgs e)
        {
            if (cartaselecc != null)
            {
                if (cartaselecc.tipo == 3 || cartaselecc.tipo == 4)
                    T_PictureBox_MouseOverCorrect(sender, e);
                else
                    T_PictureBox_MouseOverIncorrect(sender, e);
            }
        }

        private void Art4_MouseMove(object sender, MouseEventArgs e)
        {
            if (cartaselecc != null)
            {
                if (cartaselecc.tipo == 3 || cartaselecc.tipo == 4)
                    T_PictureBox_MouseOverCorrect(sender, e);
                else
                    T_PictureBox_MouseOverIncorrect(sender, e);
            }
        }

        private void Art5_MouseMove(object sender, MouseEventArgs e)
        {
            if (cartaselecc != null)
            {
                if (cartaselecc.tipo == 3 || cartaselecc.tipo == 4)
                    T_PictureBox_MouseOverCorrect(sender, e);
                else
                    T_PictureBox_MouseOverIncorrect(sender, e);
            }
        }

        private void Art6_MouseMove(object sender, MouseEventArgs e)
        {
            if (cartaselecc != null)
            {
                if (cartaselecc.tipo == 3 || cartaselecc.tipo == 4)
                    T_PictureBox_MouseOverCorrect(sender, e);
                else
                    T_PictureBox_MouseOverIncorrect(sender, e);
            }
        }

        private void Art7_MouseMove(object sender, MouseEventArgs e)
        {
            if (cartaselecc != null)
            {
                if (cartaselecc.tipo == 3 || cartaselecc.tipo == 4)
                    T_PictureBox_MouseOverCorrect(sender, e);
                else
                    T_PictureBox_MouseOverIncorrect(sender, e);
            }
        }

        private void Art8_MouseMove(object sender, MouseEventArgs e)
        {
            if (cartaselecc != null)
            {
                if (cartaselecc.tipo == 3 || cartaselecc.tipo == 4)
                    T_PictureBox_MouseOverCorrect(sender, e);
                else
                    T_PictureBox_MouseOverIncorrect(sender, e);
            }
        }

        private void Art9_MouseMove(object sender, MouseEventArgs e)
        {
            if (cartaselecc != null)
            {
                if (cartaselecc.tipo == 3 || cartaselecc.tipo == 4)
                    T_PictureBox_MouseOverCorrect(sender, e);
                else
                    T_PictureBox_MouseOverIncorrect(sender, e);
            }
        }

        private void Art1_MouseLeave(object sender, EventArgs e)
        {
            PictureBox picturebox = (PictureBox)sender;
            if (picturebox.BackgroundImage == null)
            {
                T_PictureBox_MouseLeaving(sender, e);
            }
        }

        private void Art2_MouseLeave(object sender, EventArgs e)
        {
            PictureBox picturebox = (PictureBox)sender;
            if (picturebox.BackgroundImage == null)
            {
                T_PictureBox_MouseLeaving(sender, e);
            }
        }

        private void Art3_MouseLeave(object sender, EventArgs e)
        {
            PictureBox picturebox = (PictureBox)sender;
            if (picturebox.BackgroundImage == null)
            {
                T_PictureBox_MouseLeaving(sender, e);
            }
        }

        private void Art4_MouseLeave(object sender, EventArgs e)
        {
            PictureBox picturebox = (PictureBox)sender;
            if (picturebox.BackgroundImage == null)
            {
                T_PictureBox_MouseLeaving(sender, e);
            }
        }

        private void Art5_MouseLeave(object sender, EventArgs e)
        {
            PictureBox picturebox = (PictureBox)sender;
            if (picturebox.BackgroundImage == null)
            {
                T_PictureBox_MouseLeaving(sender, e);
            }
        }

        private void Art6_MouseLeave(object sender, EventArgs e)
        {
            PictureBox picturebox = (PictureBox)sender;
            if (picturebox.BackgroundImage == null)
            {
                T_PictureBox_MouseLeaving(sender, e);
            }
        }

        private void Art7_MouseLeave(object sender, EventArgs e)
        {
            PictureBox picturebox = (PictureBox)sender;
            if (picturebox.BackgroundImage == null)
            {
                T_PictureBox_MouseLeaving(sender, e);
            }
        }

        private void Art8_MouseLeave(object sender, EventArgs e)
        {
            PictureBox picturebox = (PictureBox)sender;
            if (picturebox.BackgroundImage == null)
            {
                T_PictureBox_MouseLeaving(sender, e);
            }
        }

        private void Art9_MouseLeave(object sender, EventArgs e)
        {
            PictureBox picturebox = (PictureBox)sender;
            if (picturebox.BackgroundImage == null)
            {
                T_PictureBox_MouseLeaving(sender, e);
            }
        }


        // Rango:

        private void Ran1_MouseMove(object sender, MouseEventArgs e)
        {
            if (cartaselecc != null)
            {
                if (cartaselecc.tipo == 2 || cartaselecc.tipo == 4)
                    T_PictureBox_MouseOverCorrect(sender, e);
                else
                    T_PictureBox_MouseOverIncorrect(sender, e);
            }
        }

        private void Ran2_MouseMove(object sender, MouseEventArgs e)
        {
            if (cartaselecc != null)
            {
                if (cartaselecc.tipo == 2 || cartaselecc.tipo == 4)
                    T_PictureBox_MouseOverCorrect(sender, e);
                else
                    T_PictureBox_MouseOverIncorrect(sender, e);
            }
        }

        private void Ran3_MouseMove(object sender, MouseEventArgs e)
        {
            if (cartaselecc != null)
            {
                if (cartaselecc.tipo == 2 || cartaselecc.tipo == 4)
                    T_PictureBox_MouseOverCorrect(sender, e);
                else
                    T_PictureBox_MouseOverIncorrect(sender, e);
            }
        }

        private void Ran4_MouseMove(object sender, MouseEventArgs e)
        {
            if (cartaselecc != null)
            {
                if (cartaselecc.tipo == 2 || cartaselecc.tipo == 4)
                    T_PictureBox_MouseOverCorrect(sender, e);
                else
                    T_PictureBox_MouseOverIncorrect(sender, e);
            }
        }

        private void Ran5_MouseMove(object sender, MouseEventArgs e)
        {
            if (cartaselecc != null)
            {
                if (cartaselecc.tipo == 2 || cartaselecc.tipo == 4)
                    T_PictureBox_MouseOverCorrect(sender, e);
                else
                    T_PictureBox_MouseOverIncorrect(sender, e);
            }
        }

        private void Ran6_MouseMove(object sender, MouseEventArgs e)
        {
            if (cartaselecc != null)
            {
                if (cartaselecc.tipo == 2 || cartaselecc.tipo == 4)
                    T_PictureBox_MouseOverCorrect(sender, e);
                else
                    T_PictureBox_MouseOverIncorrect(sender, e);
            }
        }

        private void Ran7_MouseMove(object sender, MouseEventArgs e)
        {
            if (cartaselecc != null)
            {
                if (cartaselecc.tipo == 2 || cartaselecc.tipo == 4)
                    T_PictureBox_MouseOverCorrect(sender, e);
                else
                    T_PictureBox_MouseOverIncorrect(sender, e);
            }
        }

        private void Ran8_MouseMove(object sender, MouseEventArgs e)
        {
            if (cartaselecc != null)
            {
                if (cartaselecc.tipo == 2 || cartaselecc.tipo == 4)
                    T_PictureBox_MouseOverCorrect(sender, e);
                else
                    T_PictureBox_MouseOverIncorrect(sender, e);
            }
        }

        private void Ran9_MouseMove(object sender, MouseEventArgs e)
        {
            if (cartaselecc != null)
            {
                if (cartaselecc.tipo == 2 || cartaselecc.tipo == 4)
                    T_PictureBox_MouseOverCorrect(sender, e);
                else
                    T_PictureBox_MouseOverIncorrect(sender, e);
            }
        }

        private void Ran1_MouseLeave(object sender, EventArgs e)
        {
            PictureBox picturebox = (PictureBox)sender;
            if (picturebox.BackgroundImage == null)
            {
                T_PictureBox_MouseLeaving(sender, e);
            }
        }

        private void Ran2_MouseLeave(object sender, EventArgs e)
        {
            PictureBox picturebox = (PictureBox)sender;
            if (picturebox.BackgroundImage == null)
            {
                T_PictureBox_MouseLeaving(sender, e);
            }
        }

        private void Ran3_MouseLeave(object sender, EventArgs e)
        {
            PictureBox picturebox = (PictureBox)sender;
            if (picturebox.BackgroundImage == null)
            {
                T_PictureBox_MouseLeaving(sender, e);
            }
        }

        private void Ran4_MouseLeave(object sender, EventArgs e)
        {
            PictureBox picturebox = (PictureBox)sender;
            if (picturebox.BackgroundImage == null)
            {
                T_PictureBox_MouseLeaving(sender, e);
            }
        }

        private void Ran5_MouseLeave(object sender, EventArgs e)
        {
            PictureBox picturebox = (PictureBox)sender;
            if (picturebox.BackgroundImage == null)
            {
                T_PictureBox_MouseLeaving(sender, e);
            }
        }

        private void Ran6_MouseLeave(object sender, EventArgs e)
        {
            PictureBox picturebox = (PictureBox)sender;
            if (picturebox.BackgroundImage == null)
            {
                T_PictureBox_MouseLeaving(sender, e);
            }
        }

        private void Ran7_MouseLeave(object sender, EventArgs e)
        {
            PictureBox picturebox = (PictureBox)sender;
            if (picturebox.BackgroundImage == null)
            {
                T_PictureBox_MouseLeaving(sender, e);
            }
        }

        private void Ran8_MouseLeave(object sender, EventArgs e)
        {
            PictureBox picturebox = (PictureBox)sender;
            if (picturebox.BackgroundImage == null)
            {
                T_PictureBox_MouseLeaving(sender, e);
            }
        }

        private void Ran9_MouseLeave(object sender, EventArgs e)
        {
            PictureBox picturebox = (PictureBox)sender;
            if (picturebox.BackgroundImage == null)
            {
                T_PictureBox_MouseLeaving(sender, e);
            }
        }


        // Melee:

        private void Mel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (cartaselecc != null)
            {
                if (cartaselecc.tipo == 1 || cartaselecc.tipo == 4)
                    T_PictureBox_MouseOverCorrect(sender, e);
                else
                    T_PictureBox_MouseOverIncorrect(sender, e);
            }
        }

        private void Mel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (cartaselecc != null)
            {
                if (cartaselecc.tipo == 1 || cartaselecc.tipo == 4)
                    T_PictureBox_MouseOverCorrect(sender, e);
                else
                    T_PictureBox_MouseOverIncorrect(sender, e);
            }
        }

        private void Mel3_MouseMove(object sender, MouseEventArgs e)
        {
            if (cartaselecc != null)
            {
                if (cartaselecc.tipo == 1 || cartaselecc.tipo == 4)
                    T_PictureBox_MouseOverCorrect(sender, e);
                else
                    T_PictureBox_MouseOverIncorrect(sender, e);
            }
        }

        private void Mel4_MouseMove(object sender, MouseEventArgs e)
        {
            if (cartaselecc != null)
            {
                if (cartaselecc.tipo == 1 || cartaselecc.tipo == 4)
                    T_PictureBox_MouseOverCorrect(sender, e);
                else
                    T_PictureBox_MouseOverIncorrect(sender, e);
            }
        }

        private void Mel5_MouseMove(object sender, MouseEventArgs e)
        {
            if (cartaselecc != null)
            {
                if (cartaselecc.tipo == 1 || cartaselecc.tipo == 4)
                    T_PictureBox_MouseOverCorrect(sender, e);
                else
                    T_PictureBox_MouseOverIncorrect(sender, e);
            }
        }

        private void Mel6_MouseMove(object sender, MouseEventArgs e)
        {
            if (cartaselecc != null)
            {
                if (cartaselecc.tipo == 1 || cartaselecc.tipo == 4)
                    T_PictureBox_MouseOverCorrect(sender, e);
                else
                    T_PictureBox_MouseOverIncorrect(sender, e);
            }
        }

        private void Mel7_MouseMove(object sender, MouseEventArgs e)
        {
            if (cartaselecc != null)
            {
                if (cartaselecc.tipo == 1 || cartaselecc.tipo == 4)
                    T_PictureBox_MouseOverCorrect(sender, e);
                else
                    T_PictureBox_MouseOverIncorrect(sender, e);
            }
        }

        private void Mel8_MouseMove(object sender, MouseEventArgs e)
        {
            if (cartaselecc != null)
            {
                if (cartaselecc.tipo == 1 || cartaselecc.tipo == 4)
                    T_PictureBox_MouseOverCorrect(sender, e);
                else
                    T_PictureBox_MouseOverIncorrect(sender, e);
            }
        }

        private void Mel9_MouseMove(object sender, MouseEventArgs e)
        {
            if (cartaselecc != null)
            {
                if (cartaselecc.tipo == 1 || cartaselecc.tipo == 4)
                    T_PictureBox_MouseOverCorrect(sender, e);
                else
                    T_PictureBox_MouseOverIncorrect(sender, e);
            }
        }


        private void Mel1_MouseLeave(object sender, EventArgs e)
        {
            PictureBox picturebox = (PictureBox)sender;
            if (picturebox.BackgroundImage == null)
            {
                T_PictureBox_MouseLeaving(sender, e);
            }
        }

        private void Mel2_MouseLeave(object sender, EventArgs e)
        {
            PictureBox picturebox = (PictureBox)sender;
            if (picturebox.BackgroundImage == null)
            {
                T_PictureBox_MouseLeaving(sender, e);
            }
        }


        private void Mel3_MouseLeave(object sender, EventArgs e)
        {
            PictureBox picturebox = (PictureBox)sender;
            if (picturebox.BackgroundImage == null)
            {
                T_PictureBox_MouseLeaving(sender, e);
            }
        }

        private void Mel4_MouseLeave(object sender, EventArgs e)
        {
            PictureBox picturebox = (PictureBox)sender;
            if (picturebox.BackgroundImage == null)
            {
                T_PictureBox_MouseLeaving(sender, e);
            }
        }

        private void Mel5_MouseLeave(object sender, EventArgs e)
        {
            PictureBox picturebox = (PictureBox)sender;
            if (picturebox.BackgroundImage == null)
            {
                T_PictureBox_MouseLeaving(sender, e);
            }
        }

        private void Mel6_MouseLeave(object sender, EventArgs e)
        {
            PictureBox picturebox = (PictureBox)sender;
            if (picturebox.BackgroundImage == null)
            {
                T_PictureBox_MouseLeaving(sender, e);
            }
        }

        private void Mel7_MouseLeave(object sender, EventArgs e)
        {
            PictureBox picturebox = (PictureBox)sender;
            if (picturebox.BackgroundImage == null)
            {
                T_PictureBox_MouseLeaving(sender, e);
            }
        }

        private void Mel8_MouseLeave(object sender, EventArgs e)
        {
            PictureBox picturebox = (PictureBox)sender;
            if (picturebox.BackgroundImage == null)
            {
                T_PictureBox_MouseLeaving(sender, e);
            }
        }

        private void Mel9_MouseLeave(object sender, EventArgs e)
        {
            PictureBox picturebox = (PictureBox)sender;
            if (picturebox.BackgroundImage == null)
            {
                T_PictureBox_MouseLeaving(sender, e);
            }
        }
        //=============================================================================================================
        // Seleccionar carta del mazo

        private void Mano1_Click(object sender, EventArgs e)
        {
            if (accion == 1)
            {
                M_PictureBox_Click(sender, e);
                player2.URL = Path.GetFullPath(@"..\..\Resources\carta.wav");
            }   
        }

        private void Mano2_Click(object sender, EventArgs e)
        {
            if (accion == 1)
            {
                M_PictureBox_Click(sender, e);
                player2.URL = Path.GetFullPath(@"..\..\Resources\carta.wav");
            }
        }

        private void Mano3_Click(object sender, EventArgs e)
        {
            if (accion == 1)
            {
                M_PictureBox_Click(sender, e);
                player2.URL = Path.GetFullPath(@"..\..\Resources\carta.wav");
            }
        }

        private void Mano4_Click(object sender, EventArgs e)
        {
            if (accion == 1)
            {
                M_PictureBox_Click(sender, e);
                player2.URL = Path.GetFullPath(@"..\..\Resources\carta.wav");
            }
        }

        private void Mano5_Click(object sender, EventArgs e)
        {
            if (accion == 1)
            {
                M_PictureBox_Click(sender, e);
                player2.URL = Path.GetFullPath(@"..\..\Resources\carta.wav");
            }
        }

        private void Mano6_Click(object sender, EventArgs e)
        {
            if (accion == 1)
            {
                M_PictureBox_Click(sender, e);
                player2.URL = Path.GetFullPath(@"..\..\Resources\carta.wav");
            }
        }

        private void Mano7_Click(object sender, EventArgs e)
        {
            if (accion == 1)
            {
                M_PictureBox_Click(sender, e);
                player2.URL = Path.GetFullPath(@"..\..\Resources\carta.wav");
            }
        }

        private void Mano8_Click(object sender, EventArgs e)
        {
            if (accion == 1)
            {
                M_PictureBox_Click(sender, e);
                player2.URL = Path.GetFullPath(@"..\..\Resources\carta.wav");
            }
        }

        private void Mano9_Click(object sender, EventArgs e)
        {
            if (accion == 1)
            {
                M_PictureBox_Click(sender, e);
                player2.URL = Path.GetFullPath(@"..\..\Resources\carta.wav");
            }
        }

        private void Mano10_Click(object sender, EventArgs e)
        {
            if (accion == 1)
            {
                M_PictureBox_Click(sender, e);
                player2.URL = Path.GetFullPath(@"..\..\Resources\carta.wav");
            }
        }
    }
}