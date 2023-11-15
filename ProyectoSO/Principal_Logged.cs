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
    public partial class Principal_Logged : Form
    {
        User user;
        Socket server;
        public Principal_Logged(User user, Socket server)
        {
            InitializeComponent();
            this.user = user;
            this.server = server;
            Bienvenida.Text = "Bienvenido " + user.Name;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void logOutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Quieres cerrar la session?","Confirmacion",MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string mensaje = "4/" + user.Name;
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
                Close();
            }
        }

        private void conectadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Legacy version
            //Grid_Form_Conectados Gform = new Grid_Form_Conectados(user, server);
            //Gform.Show();
            // Ahora podemos iterer su visulizacion con un click
            if (conectadosToolStripMenuItem.Checked == false)
                panelConectados.Visible = false;
            else if(conectadosToolStripMenuItem.Checked == true)
                panelConectados.Visible = true;

        }

        public void Tabla(string mensaje)
        {
            string[] trozos = mensaje.Split('/');
            Jugador1ComboBox.Items.Clear();
            Jugador2ComboBox.Items.Clear();
            Jugador3ComboBox.Items.Clear();
            dataGridConectados.RowCount = Convert.ToInt32(trozos[0]);
            if (Convert.ToInt32(trozos[0]) != 0)
            {
                for(int i = 0; i < Convert.ToInt32(trozos[0]); i++)
                {
                    dataGridConectados.Rows[i].Cells[0].Value = trozos[i + 1];
                    Jugador1ComboBox.Items.Add(trozos[i + 1]);
                    Jugador2ComboBox.Items.Add(trozos[i + 1]);
                    Jugador3ComboBox.Items.Add(trozos[i + 1]);
                }
            }
        }

        private void ModeComboBox_TextChanged(object sender, EventArgs e)
        {
            if(ModeComboBox.Text == "2")
            {
                LabelInvitado1.Visible = true;
                Jugador1ComboBox.Visible = true;
                Jugador1ComboBox.Enabled = true;

                LabelInvitado2.Visible = false;
                Jugador2ComboBox.Visible = false;
                Jugador2ComboBox.Enabled = false;

                LabelInvitado3.Visible = false;
                Jugador3ComboBox.Visible = false;
                Jugador3ComboBox.Enabled = false;

            }
            else if(ModeComboBox.Text == "4")
            {
                LabelInvitado1.Visible = true;
                Jugador1ComboBox.Visible = true;
                Jugador1ComboBox.Enabled = true;

                LabelInvitado2.Visible = true;
                Jugador2ComboBox.Visible = true;
                Jugador2ComboBox.Enabled = true;

                LabelInvitado3.Visible = true;
                Jugador3ComboBox.Visible = true;
                Jugador3ComboBox.Enabled = true;
            }

        }

        private void EnviarPartida_Click(object sender, EventArgs e)
        {
            if ((Jugador1ComboBox.Text == this.user.Name) || (Jugador2ComboBox.Text == this.user.Name) || (Jugador3ComboBox.Text == this.user.Name))
            {
                MessageBox.Show("No te puedes invitar a ti mismo.");
                return;
            }
            if (ModeComboBox.Text == null)
            {
                MessageBox.Show("Selecciona cuantos jugadores quieres.");
                return;
            }

            if (ModeComboBox.Text == "2")
            {
                if ((Jugador1ComboBox.Text == null))
                {
                    MessageBox.Show("Te falta gente por invitar.");
                    return;
                }
                else
                { // Ahora si podemos invitar a un jugador: partida 1vs1
                    string mensaje = "3/1/" + this.user.Name + "/" + Jugador1ComboBox.Text;
                    byte[] msg = Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
                    MessageBox.Show("Se ha enviado la invitacion.");

                }
            }
            else if (ModeComboBox.Text == "4")
            {
                if ((Jugador1ComboBox.Text == null) || (Jugador2ComboBox.Text == null) || (Jugador3ComboBox.Text == null))
                {
                    MessageBox.Show("Te falta gente por invitar.");
                    return;
                }
                else if ((Jugador1ComboBox.Text == Jugador2ComboBox.Text) ||
                         (Jugador1ComboBox.Text == Jugador3ComboBox.Text) ||
                         (Jugador2ComboBox.Text == Jugador3ComboBox.Text))
                {
                    MessageBox.Show("No puedes invitar mas de una vez a la misma persona.");
                    return;
                }
                else
                { //  Ahora si podemos invitar a tres jugadores: partida 2vs2
                    string mensaje = "3/3/" + this.user.Name + "/" + Jugador1ComboBox.Text + "/" + Jugador2ComboBox.Text + "/" + Jugador3ComboBox.Text;
                    byte[] msg = Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
                    MessageBox.Show("Se ha enviado la invitacion.");
                }
            }
        }

        internal void ResponderInvitacion(string mensaje)
        {
            string[] trozos = mensaje.Split('/');
            string partida = trozos[0];
            string host = trozos[1];
            string pregunta = string.Format("¿Quieres jugar en la partida {0} de {1}?", partida, host);

            DialogResult QuieroJugar = MessageBox.Show(pregunta, "Confirmacion", MessageBoxButtons.YesNo);
            if (QuieroJugar == DialogResult.Yes)
            {
                // Enviar mensaje de aceptar partida
                string respuesta = "5/" + partida + "/1/" + user.Name;
                byte[] msg = Encoding.ASCII.GetBytes(respuesta);
                server.Send(msg);
            }
            else
            {
                // Enviar mensaje de NO aceptar partida
                string respuesta = "5/" + partida + "/0/" + user.Name;
                byte[] msg = Encoding.ASCII.GetBytes(respuesta);
                server.Send(msg);
            }

        }

        internal void MostrarRespuesta(string mensaje)
        {
            MessageBox.Show(mensaje);

        }
    }
}
