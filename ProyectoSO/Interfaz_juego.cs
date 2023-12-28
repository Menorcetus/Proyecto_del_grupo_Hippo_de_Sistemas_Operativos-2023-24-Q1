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
        public PictureBox[] Mano = new PictureBox[10];
        public Carta[] ManoCartas = new Carta[10];
        public Carta[] CartasArt = new Carta[9];
        public Carta[] CartasRan = new Carta[9];
        public Carta[] CartasMel = new Carta[9];
        public Color borderColor;
        public Carta cartaselecc;
        int numCartas;
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
            picturebox.BackColor = Color.FromArgb(128, Color.White);
        }

        private void T_PictureBox_Click(object sender, EventArgs e)
        {
            PictureBox picBox = (PictureBox)sender;
            ManoCartas[DameCartaMano(cartaselecc.picture)].picture.Visible = false;
            picBox.BackColor = Color.Transparent;
            picBox.BackgroundImage = ManoCartas[DameCartaMano(cartaselecc.picture)].picture.Image;
            cartaselecc = null;

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
            if (cartaselecc != null)
            {
                if (cartaselecc.tipo == 3 || cartaselecc.tipo == 4)
                    T_PictureBox_Click(sender, e);
            }
        }

        private void Art2_Click(object sender, EventArgs e)
        {
            if (cartaselecc != null)
            {
                if (cartaselecc.tipo == 3 || cartaselecc.tipo == 4)
                    T_PictureBox_Click(sender, e);
            }
        }

        private void Art3_Click(object sender, EventArgs e)
        {
            if (cartaselecc != null)
            {
                if (cartaselecc.tipo == 3 || cartaselecc.tipo == 4)
                    T_PictureBox_Click(sender, e);
            }
        }

        private void Art4_Click(object sender, EventArgs e)
        {
            if (cartaselecc != null)
            {
                if (cartaselecc.tipo == 3 || cartaselecc.tipo == 4)
                    T_PictureBox_Click(sender, e);
            }
        }

        private void Art5_Click(object sender, EventArgs e)
        {
            if (cartaselecc != null)
            {
                if (cartaselecc.tipo == 3 || cartaselecc.tipo == 4)
                    T_PictureBox_Click(sender, e);
            }
        }

        private void Art6_Click(object sender, EventArgs e)
        {
            if (cartaselecc != null)
            {
                if (cartaselecc.tipo == 3 || cartaselecc.tipo == 4)
                    T_PictureBox_Click(sender, e);
            }
        }

        private void Art7_Click(object sender, EventArgs e)
        {
            if (cartaselecc != null)
            {
                if (cartaselecc.tipo == 3 || cartaselecc.tipo == 4)
                    T_PictureBox_Click(sender, e);
            }
        }

        private void Art8_Click(object sender, EventArgs e)
        {
            if (cartaselecc != null)
            {
                if (cartaselecc.tipo == 3 || cartaselecc.tipo == 4)
                    T_PictureBox_Click(sender, e);
            }
        }

        private void Art9_Click(object sender, EventArgs e)
        {
            if (cartaselecc != null)
            {
                if (cartaselecc.tipo == 3 || cartaselecc.tipo == 4)
                    T_PictureBox_Click(sender, e);
            }
        }

        // Rango:

        private void Ran1_Click(object sender, EventArgs e)
        {
            if (cartaselecc != null)
            {
                if (cartaselecc.tipo == 2 || cartaselecc.tipo == 4)
                    T_PictureBox_Click(sender, e);
            }
        }

        private void Ran2_Click(object sender, EventArgs e)
        {
            if (cartaselecc != null)
            {
                if (cartaselecc.tipo == 2 || cartaselecc.tipo == 4)
                    T_PictureBox_Click(sender, e);
            }
        }

        private void Ran3_Click(object sender, EventArgs e)
        {
            if (cartaselecc != null)
            {
                if (cartaselecc.tipo == 2 || cartaselecc.tipo == 4)
                    T_PictureBox_Click(sender, e);
            }
        }

        private void Ran4_Click(object sender, EventArgs e)
        {
            if (cartaselecc != null)
            {
                if (cartaselecc.tipo == 2 || cartaselecc.tipo == 4)
                    T_PictureBox_Click(sender, e);
            }
        }

        private void Ran5_Click(object sender, EventArgs e)
        {
            if (cartaselecc != null)
            {
                if (cartaselecc.tipo == 2 || cartaselecc.tipo == 4)
                    T_PictureBox_Click(sender, e);
            }
        }

        private void Ran6_Click(object sender, EventArgs e)
        {
            if (cartaselecc != null)
            {
                if (cartaselecc.tipo == 2 || cartaselecc.tipo == 4)
                    T_PictureBox_Click(sender, e);
            }
        }

        private void Ran7_Click(object sender, EventArgs e)
        {
            if (cartaselecc != null)
            {
                if (cartaselecc.tipo == 2 || cartaselecc.tipo == 4)
                    T_PictureBox_Click(sender, e);
            }
        }

        private void Ran8_Click(object sender, EventArgs e)
        {
            if (cartaselecc != null)
            {
                if (cartaselecc.tipo == 2 || cartaselecc.tipo == 4)
                    T_PictureBox_Click(sender, e);
            }
        }

        private void Ran9_Click(object sender, EventArgs e)
        {
            if (cartaselecc != null)
            {
                if (cartaselecc.tipo == 2 || cartaselecc.tipo == 4)
                    T_PictureBox_Click(sender, e);
            }
        }

        // Melee:

        private void Mel1_Click(object sender, EventArgs e)
        {
            if (cartaselecc != null)
            {
                if (cartaselecc.tipo == 1 || cartaselecc.tipo == 4)
                    T_PictureBox_Click(sender, e);
            }
        }

        private void Mel2_Click(object sender, EventArgs e)
        {
            if (cartaselecc != null)
            {
                if (cartaselecc.tipo == 1 || cartaselecc.tipo == 4)
                    T_PictureBox_Click(sender, e);
            }
        }

        private void Mel3_Click(object sender, EventArgs e)
        {
            if (cartaselecc != null)
            {
                if (cartaselecc.tipo == 1 || cartaselecc.tipo == 4)
                    T_PictureBox_Click(sender, e);
            }
        }

        private void Mel4_Click(object sender, EventArgs e)
        {
            if (cartaselecc != null)
            {
                if (cartaselecc.tipo == 1 || cartaselecc.tipo == 4)
                    T_PictureBox_Click(sender, e);
            }
        }

        private void Mel5_Click(object sender, EventArgs e)
        {
            if (cartaselecc != null)
            {
                if (cartaselecc.tipo == 1 || cartaselecc.tipo == 4)
                    T_PictureBox_Click(sender, e);
            }
        }

        private void Mel6_Click(object sender, EventArgs e)
        {
            if (cartaselecc != null)
            {
                if (cartaselecc.tipo == 1 || cartaselecc.tipo == 4)
                    T_PictureBox_Click(sender, e);
            }
        }

        private void Mel7_Click(object sender, EventArgs e)
        {
            if (cartaselecc != null)
            {
                if (cartaselecc.tipo == 1 || cartaselecc.tipo == 4)
                    T_PictureBox_Click(sender, e);
            }
        }

        private void Mel8_Click(object sender, EventArgs e)
        {
            if (cartaselecc != null)
            {
                if (cartaselecc.tipo == 1 || cartaselecc.tipo == 4)
                    T_PictureBox_Click(sender, e);
            }
        }

        private void Mel9_Click(object sender, EventArgs e)
        {
            if (cartaselecc != null)
            {
                if (cartaselecc.tipo == 1 || cartaselecc.tipo == 4)
                    T_PictureBox_Click(sender, e);
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

        private void Art1_MouseLeave(object sender, MouseEventArgs e)
        {
            PictureBox picturebox = (PictureBox)sender;
            if (picturebox.BackgroundImage == null)
            {
                T_PictureBox_MouseLeaving(sender, e);
            }
        }

        private void Art2_MouseLeave(object sender, MouseEventArgs e)
        {
            PictureBox picturebox = (PictureBox)sender;
            if (picturebox.BackgroundImage == null)
            {
                T_PictureBox_MouseLeaving(sender, e);
            }
        }

        private void Art3_MouseLeave(object sender, MouseEventArgs e)
        {
            PictureBox picturebox = (PictureBox)sender;
            if (picturebox.BackgroundImage == null)
            {
                T_PictureBox_MouseLeaving(sender, e);
            }
        }

        private void Art4_MouseLeave(object sender, MouseEventArgs e)
        {
            PictureBox picturebox = (PictureBox)sender;
            if (picturebox.BackgroundImage == null)
            {
                T_PictureBox_MouseLeaving(sender, e);
            }
        }

        private void Art5_MouseLeave(object sender, MouseEventArgs e)
        {
            PictureBox picturebox = (PictureBox)sender;
            if (picturebox.BackgroundImage == null)
            {
                T_PictureBox_MouseLeaving(sender, e);
            }
        }

        private void Art6_MouseLeave(object sender, MouseEventArgs e)
        {
            PictureBox picturebox = (PictureBox)sender;
            if (picturebox.BackgroundImage == null)
            {
                T_PictureBox_MouseLeaving(sender, e);
            }
        }

        private void Art7_MouseLeave(object sender, MouseEventArgs e)
        {
            PictureBox picturebox = (PictureBox)sender;
            if (picturebox.BackgroundImage == null)
            {
                T_PictureBox_MouseLeaving(sender, e);
            }
        }

        private void Art8_MouseLeave(object sender, MouseEventArgs e)
        {
            PictureBox picturebox = (PictureBox)sender;
            if (picturebox.BackgroundImage == null)
            {
                T_PictureBox_MouseLeaving(sender, e);
            }
        }

        private void Art9_MouseLeave(object sender, MouseEventArgs e)
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

        private void Ran1_MouseLeave(object sender, MouseEventArgs e)
        {
            PictureBox picturebox = (PictureBox)sender;
            if (picturebox.BackgroundImage == null)
            {
                T_PictureBox_MouseLeaving(sender, e);
            }
        }

        private void Ran2_MouseLeave(object sender, MouseEventArgs e)
        {
            PictureBox picturebox = (PictureBox)sender;
            if (picturebox.BackgroundImage == null)
            {
                T_PictureBox_MouseLeaving(sender, e);
            }
        }

        private void Ran3_MouseLeave(object sender, MouseEventArgs e)
        {
            PictureBox picturebox = (PictureBox)sender;
            if (picturebox.BackgroundImage == null)
            {
                T_PictureBox_MouseLeaving(sender, e);
            }
        }

        private void Ran4_MouseLeave(object sender, MouseEventArgs e)
        {
            PictureBox picturebox = (PictureBox)sender;
            if (picturebox.BackgroundImage == null)
            {
                T_PictureBox_MouseLeaving(sender, e);
            }
        }

        private void Ran5_MouseLeave(object sender, MouseEventArgs e)
        {
            PictureBox picturebox = (PictureBox)sender;
            if (picturebox.BackgroundImage == null)
            {
                T_PictureBox_MouseLeaving(sender, e);
            }
        }

        private void Ran6_MouseLeave(object sender, MouseEventArgs e)
        {
            PictureBox picturebox = (PictureBox)sender;
            if (picturebox.BackgroundImage == null)
            {
                T_PictureBox_MouseLeaving(sender, e);
            }
        }

        private void Ran7_MouseLeave(object sender, MouseEventArgs e)
        {
            PictureBox picturebox = (PictureBox)sender;
            if (picturebox.BackgroundImage == null)
            {
                T_PictureBox_MouseLeaving(sender, e);
            }
        }

        private void Ran8_MouseLeave(object sender, MouseEventArgs e)
        {
            PictureBox picturebox = (PictureBox)sender;
            if (picturebox.BackgroundImage == null)
            {
                T_PictureBox_MouseLeaving(sender, e);
            }
        }

        private void Ran9_MouseLeave(object sender, MouseEventArgs e)
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

        private void Mel1_MouseLeave(object sender, MouseEventArgs e)
        {
            PictureBox picturebox = (PictureBox)sender;
            if (picturebox.BackgroundImage == null)
            {
                T_PictureBox_MouseLeaving(sender, e);
            }
        }

        private void Mel2_MouseLeave(object sender, MouseEventArgs e)
        {
            PictureBox picturebox = (PictureBox)sender;
            if (picturebox.BackgroundImage == null)
            {
                T_PictureBox_MouseLeaving(sender, e);
            }
        }

        private void Mel3_MouseLeave(object sender, MouseEventArgs e)
        {
            PictureBox picturebox = (PictureBox)sender;
            if (picturebox.BackgroundImage == null)
            {
                T_PictureBox_MouseLeaving(sender, e);
            }
        }

        private void Mel4_MouseLeave(object sender, MouseEventArgs e)
        {
            PictureBox picturebox = (PictureBox)sender;
            if (picturebox.BackgroundImage == null)
            {
                T_PictureBox_MouseLeaving(sender, e);
            }
        }

        private void Mel5_MouseLeave(object sender, MouseEventArgs e)
        {
            PictureBox picturebox = (PictureBox)sender;
            if (picturebox.BackgroundImage == null)
            {
                T_PictureBox_MouseLeaving(sender, e);
            }
        }

        private void Mel6_MouseLeave(object sender, MouseEventArgs e)
        {
            PictureBox picturebox = (PictureBox)sender;
            if (picturebox.BackgroundImage == null)
            {
                T_PictureBox_MouseLeaving(sender, e);
            }
        }

        private void Mel7_MouseLeave(object sender, MouseEventArgs e)
        {
            PictureBox picturebox = (PictureBox)sender;
            if (picturebox.BackgroundImage == null)
            {
                T_PictureBox_MouseLeaving(sender, e);
            }
        }

        private void Mel8_MouseLeave(object sender, MouseEventArgs e)
        {
            PictureBox picturebox = (PictureBox)sender;
            if (picturebox.BackgroundImage == null)
            {
                T_PictureBox_MouseLeaving(sender, e);
            }
        }

        private void Mel9_MouseLeave(object sender, MouseEventArgs e)
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
            M_PictureBox_Click(sender,e);
        }

        private void Mano2_Click(object sender, EventArgs e)
        {
            M_PictureBox_Click(sender, e);
        }

        private void Mano3_Click(object sender, EventArgs e)
        {
            M_PictureBox_Click(sender, e);
        }

        private void Mano4_Click(object sender, EventArgs e)
        {
            M_PictureBox_Click(sender, e);
        }

        private void Mano5_Click(object sender, EventArgs e)
        {
            M_PictureBox_Click(sender, e);
        }

        private void Mano6_Click(object sender, EventArgs e)
        {
            M_PictureBox_Click(sender, e);
        }

        private void Mano7_Click(object sender, EventArgs e)
        {
            M_PictureBox_Click(sender, e);
        }

        private void Mano8_Click(object sender, EventArgs e)
        {
            M_PictureBox_Click(sender, e);
        }

        private void Mano9_Click(object sender, EventArgs e)
        {
            M_PictureBox_Click(sender, e);
        }

        private void Mano10_Click(object sender, EventArgs e)
        {
            M_PictureBox_Click(sender, e);
        }
    }
}