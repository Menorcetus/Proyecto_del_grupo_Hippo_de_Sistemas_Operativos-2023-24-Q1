using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoSO
{
    public partial class Principal_Logged : Form
    {
        User user;
        Socket server;
        Thread Esperar;
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
            dataGridConectados.RowCount = Convert.ToInt32(trozos[0]);
            if (Convert.ToInt32(trozos[0]) != 0)
            {
                for(int i = 0; i < Convert.ToInt32(trozos[0]); i++)
                {
                    dataGridConectados.Rows[i].Cells[0].Value = trozos[i + 1];
                    Jugador1ComboBox.Items.Add(trozos[i + 1]);
                }
            }
        }

        private void EnviarPartida_Click(object sender, EventArgs e)
        {
            if (Jugador1ComboBox.Text == this.user.Name)
            {
                MessageBox.Show("No te puedes invitar a ti mismo.");
                return;
            }
            if (Jugador1ComboBox.Text == null)
                {
                    MessageBox.Show("Te falta gente por invitar.");
                    return;
                }
            else
                { // Ahora si podemos invitar a un jugador: partida 1vs1
                    string mensaje = "3/" + this.user.Name + "/" + Jugador1ComboBox.Text;
                    byte[] msg = Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);

                    EnviadoLbl.Text = "Se ha enviado la invitacion";
                    EnviarPartida.Enabled = false;
                    EnviarPartida.Text = "Esperando jugadores";
                    // Possible forma de hacer una lobby?
                    //ThreadStart ts = delegate { EsperarInvitados(); };
                    //Esperar = new Thread(ts);
                    //Esperar.Start();

                    DGVInvitados.RowCount = 1;
                    DGVInvitados.Rows[0].Cells[0].Value = Jugador1ComboBox.Text;
                    Jugador1ComboBox.Enabled = false;

                }
        }

        internal void ResponderInvitacion(string mensaje)
        {
            string[] trozos = mensaje.Split('/');
            string host = trozos[0];
            string pregunta = string.Format("¿Quieres jugar en la partida de {0}?", host);

            DialogResult QuieroJugar = MessageBox.Show(pregunta, "Confirmacion", MessageBoxButtons.YesNo);
            if (QuieroJugar == DialogResult.Yes)
            {
                // Enviar mensaje de aceptar partida
                string respuesta = "5/" + "/1/" + user.Name + "/" + host;
                byte[] msg = Encoding.ASCII.GetBytes(respuesta);
                server.Send(msg);
            }
            else
            {
                // Enviar mensaje de NO aceptar partida
                string respuesta = "5/" + "/0/" + user.Name + "/" + host;
                byte[] msg = Encoding.ASCII.GetBytes(respuesta);
                server.Send(msg);
            }

        }

        internal void MostrarRespuesta(string mensaje)
        {
            string[] trozos = mensaje.Split('/');
            string respuesta = trozos[0];
            string jugador = trozos[1];
            if (respuesta == "1")
            {
                // MessageBox.Show("%s ha aceptado la partida", jugador);
                DGVInvitados.Rows[0].Cells[1].Value = true;
            }
            else if(respuesta == "0")
            {
                MessageBox.Show("{0} No ha aceptado la partida, la partida se va a cancelar.", jugador);
                DGVInvitados.RowCount = 0;
                EnviarPartida.Text = "Invitar";
                EnviarPartida.Enabled = true;
                Jugador1ComboBox.Enabled = true;
            }

        }

        private void crearPartidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (crearPartidaToolStripMenuItem.Checked == false)
                CrearPartida.Visible = false;
            else if (crearPartidaToolStripMenuItem.Checked == true)
                CrearPartida.Visible = true;
        }
    }
}
