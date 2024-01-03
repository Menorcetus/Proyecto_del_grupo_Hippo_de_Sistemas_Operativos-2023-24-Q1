﻿using System;
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
        

        public Interfaz_juego(User user, Socket server, int ID_partida, int accion)
        {
            InitializeComponent();
            this.user = user;
            this.server = server;
            this.ID_partida = ID_partida;
            this.accion = accion;
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
            }

            else
            {
                turno.Text = "¡Turno del contrincante!";
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
            // Falta implementar
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
        }

        private void PedirMazo_btn_Click(object sender, EventArgs e)
        {
            string mensaje = "7/" + this.ID_partida + "/" + this.user.Name;
            byte[] msg = Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            //PedirMazo_btn.Enabled = false;
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
            else
                MessageBox.Show("Error");
        }

        private void T_PictureBox_MouseOverCorrect(object sender, EventArgs e)
        {
            PictureBox picturebox = (PictureBox)sender;
            picturebox.BackColor = Color.FromArgb(128, Color.Yellow);
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
            picBox.BackgroundImage = ManoCartas[DameCartaMano(cartaselecc.picture)].picture.Image;
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
                                                    + "/" + this.FuerzaMel_M + "/" + this.FuerzaRan_M + "/" + this.FuerzaArt_M + DistribucionCartas;

            byte[] msg = Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
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
            FuerzaArt_lbl.Text = Convert.ToString(FuerzaArt);
            FuerzaRan_lbl.Text = Convert.ToString(FuerzaRan);
            FuerzaMel_lbl.Text = Convert.ToString(FuerzaMel);
            FuerzaArt_M_lbl.Text = Convert.ToString(FuerzaArt_M);
            FuerzaRan_M_lbl.Text = Convert.ToString(FuerzaRan_M);
            FuerzaMel_M_lbl.Text = Convert.ToString(FuerzaMel_M);
            // Si se cambia el texto significa que se ha colocado una carta, para que se el contrincante sea consciente se auto envia un mensaje al servidor.
            if (turno.Text == "¡Turno del contrincante!")
            {
                string DistribucionCartas = DistribuirCartas(CartasArt, CartasRan, CartasMel);
                string mensaje = "8/" + this.ID_partida + "/" + this.user.Name + "/" + this.FuerzaMel + "/" + this.FuerzaRan + "/" + this.FuerzaArt
                                                        + "/" + this.FuerzaMel_M + "/" + this.FuerzaRan_M + "/" + this.FuerzaArt_M + DistribucionCartas;

                byte[] msg = Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
        }

        //=============================================================================================================
        // Acciones pasar por encima de carta

        private void Mano10_MouseMove(object sender, MouseEventArgs e)
        {
            this.Mano10.Size = new System.Drawing.Size(80, 160);
            this.Mano10.BringToFront();
            ChangePictureBoxBorderColor(Mano10, Color.Yellow);
        }

        private void Mano10_MouseLeave(object sender, EventArgs e)
        {
            this.Mano10.Size = new System.Drawing.Size(48, 96);
            ClearPictureBoxBorderColor(Mano10);
        }

        private void Mano9_MouseMove(object sender, MouseEventArgs e)
        {
            this.Mano8.Size = new System.Drawing.Size(80, 160);
            this.Mano8.BringToFront();
            ChangePictureBoxBorderColor(Mano8, Color.Yellow);
        }

        private void Mano9_MouseLeave(object sender, EventArgs e)
        {
            this.Mano8.Size = new System.Drawing.Size(48, 96);
            ClearPictureBoxBorderColor(Mano8);
        }

        private void Mano8_MouseMove(object sender, MouseEventArgs e)
        {
            this.Mano7.Size = new System.Drawing.Size(80, 160);
            this.Mano7.BringToFront();
            ChangePictureBoxBorderColor(Mano7, Color.Yellow);
        }

        private void Mano8_MouseLeave(object sender, EventArgs e)
        {
            this.Mano7.Size = new System.Drawing.Size(48, 96);
            ClearPictureBoxBorderColor(Mano7);
        }

        private void Mano7_MouseLeave(object sender, EventArgs e)
        {
            this.Mano6.Size = new System.Drawing.Size(48, 96);
            ClearPictureBoxBorderColor(Mano6);

        }

        private void Mano7_MouseMove(object sender, MouseEventArgs e)
        {
            this.Mano6.Size = new System.Drawing.Size(80, 160);
            this.Mano6.BringToFront();
            ChangePictureBoxBorderColor(Mano6, Color.Yellow);
        }

        private void Mano6_MouseMove(object sender, MouseEventArgs e)
        {
            this.Mano5.Size = new System.Drawing.Size(80, 160);
            this.Mano5.BringToFront();
            ChangePictureBoxBorderColor(Mano5, Color.Yellow);
        }

        private void Mano6_MouseLeave(object sender, EventArgs e)
        {
            this.Mano5.Size = new System.Drawing.Size(48, 96);
            ClearPictureBoxBorderColor(Mano5);
        }

        private void Mano5_MouseMove(object sender, MouseEventArgs e)
        {
            this.Mano9.Size = new System.Drawing.Size(80, 160);
            this.Mano9.BringToFront();
            ChangePictureBoxBorderColor(Mano9, Color.Yellow);
        }

        private void Mano5_MouseLeave(object sender, EventArgs e)
        {
            this.Mano9.Size = new System.Drawing.Size(48, 96);
            ClearPictureBoxBorderColor(Mano9);
        }
        private void Mano4_MouseMove(object sender, MouseEventArgs e)
        {
            this.Mano4.Size = new System.Drawing.Size(80, 160);
            this.Mano4.BringToFront();
            ChangePictureBoxBorderColor(Mano4, Color.Yellow);
        }

        private void Mano4_MouseLeave(object sender, EventArgs e)
        {
            this.Mano4.Size = new System.Drawing.Size(48, 96);
            ClearPictureBoxBorderColor(Mano4);
        }

        private void Mano3_MouseMove(object sender, MouseEventArgs e)
        {
            this.Mano3.Size = new System.Drawing.Size(80, 160);
            this.Mano3.BringToFront();
            ChangePictureBoxBorderColor(Mano3, Color.Yellow);
        }

        private void Mano3_MouseLeave(object sender, EventArgs e)
        {
            this.Mano3.Size = new System.Drawing.Size(48, 96);
            ClearPictureBoxBorderColor(Mano3);
        }

        private void Mano2_MouseMove(object sender, MouseEventArgs e)
        {
            this.Mano2.Size = new System.Drawing.Size(80, 160);
            this.Mano2.BringToFront();
            ChangePictureBoxBorderColor(Mano2, Color.Yellow);
        }

        private void Mano2_MouseLeave(object sender, EventArgs e)
        {
            this.Mano2.Size = new System.Drawing.Size(48, 96);
            ClearPictureBoxBorderColor(Mano2);
        }

        private void Mano1_MouseLeave(object sender, EventArgs e)
        {
            this.Mano1.Size = new System.Drawing.Size(48, 96);
            ClearPictureBoxBorderColor(Mano1);
        }

        private void Mano1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Mano1.Size = new System.Drawing.Size(80, 160);
            this.Mano1.BringToFront();
            ChangePictureBoxBorderColor(Mano1, Color.Yellow);
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
            }   
        }

        private void Mano2_Click(object sender, EventArgs e)
        {
            if (accion == 1)
            {
                M_PictureBox_Click(sender, e);
            }
        }

        private void Mano3_Click(object sender, EventArgs e)
        {
            if (accion == 1)
            {
                M_PictureBox_Click(sender, e);
            }
        }

        private void Mano4_Click(object sender, EventArgs e)
        {
            if (accion == 1)
            {
                M_PictureBox_Click(sender, e);
            }
        }

        private void Mano5_Click(object sender, EventArgs e)
        {
            if (accion == 1)
            {
                M_PictureBox_Click(sender, e);
            }
        }

        private void Mano6_Click(object sender, EventArgs e)
        {
            if (accion == 1)
            {
                M_PictureBox_Click(sender, e);
            }
        }

        private void Mano7_Click(object sender, EventArgs e)
        {
            if (accion == 1)
            {
                M_PictureBox_Click(sender, e);
            }
        }

        private void Mano8_Click(object sender, EventArgs e)
        {
            if (accion == 1)
            {
                M_PictureBox_Click(sender, e);
            }
        }

        private void Mano9_Click(object sender, EventArgs e)
        {
            if (accion == 1)
            {
                M_PictureBox_Click(sender, e);
            }
        }

        private void Mano10_Click(object sender, EventArgs e)
        {
            if (accion == 1)
            {
                M_PictureBox_Click(sender, e);
            }
        }
    }
}