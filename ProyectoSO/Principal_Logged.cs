using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;


namespace ProyectoSO
{
    public partial class Principal_Logged : Form
    {
        User user;
        Socket server;
        Thread Esperar;
        WindowsMediaPlayer player;

        public Principal_Logged(User user, Socket server, WindowsMediaPlayer player)
        {
            InitializeComponent();
            this.user = user;
            this.server = server;
            Bienvenida.Text = "Bienvenido " + user.Name;
            this.player = player;
            player.URL = "logged.wav";
            player.settings.setMode("loop", true);
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
                player.controls.stop();
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

        private void Jugador1ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelecctionarLablel.ForeColor = Color.Black;
        }

        private void TurnosComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CartasLbl.ForeColor = Color.Black;
        }

        private void EnviarPartida_Click(object sender, EventArgs e)
        {
            if (Jugador1ComboBox.Text == this.user.Name)
                {
                    EnviadoLbl.Text = "No te puedes invitar a ti mismo.";
                    SelecctionarLablel.ForeColor = Color.Red;
                    return;
                }
            if (CartasComboBox.Text == "")
                {
                    EnviadoLbl.Text = "Selecciona el numero de cartas.";
                    CartasLbl.ForeColor = Color.Red;
                    return;
                }
            if (Jugador1ComboBox.Text == "")
                {
                    EnviadoLbl.Text = "Tienes que invitar a alguien";
                    SelecctionarLablel.ForeColor = Color.Red;
                    return;
                }
            else
                { // Ahora si podemos invitar a un jugador: partida 1vs1
                    string mensaje = "3/" + this.user.Name + "/" + Jugador1ComboBox.Text + "/" + CartasComboBox.Text;
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
                    CartasComboBox.Enabled = false;

                }
        }

        internal void ResponderInvitacion(string mensaje)
        {
            string[] trozos = mensaje.Split('/');
            string host = trozos[0];
            string num_cartas = trozos[1];
            string pregunta = string.Format("¿Quieres jugar en la partida de {0}? Sera con baraja de {1} caratas.", host, num_cartas);

            DialogResult QuieroJugar = MessageBox.Show(pregunta, "Confirmacion", MessageBoxButtons.YesNo);
            if (QuieroJugar == DialogResult.Yes)
            {
                // Enviar mensaje de aceptar partida
                player.controls.stop();
                string respuesta = "5/" + "1/" + user.Name + "/" + host + "/" + num_cartas;
                byte[] msg = Encoding.ASCII.GetBytes(respuesta);
                server.Send(msg);

            }
            else
            {
                // Enviar mensaje de NO aceptar partida
                string respuesta = "5/" + "0/" + user.Name + "/" + host;
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

        private void galeríaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string mensaje = "10/" + user.Name;
            byte[] msg = Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }

        private void darseDeBajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string pregunta = string.Format("¿Quieres eliminar la cuenta con usuario {0}",this.user.Name);
            DialogResult Delete = MessageBox.Show(pregunta, "Confirmacion", MessageBoxButtons.YesNo);
            if (Delete == DialogResult.Yes)
            {
                // Enviar mensaje de aceptar partida
                MessageBox.Show("El usuario se ha eliminado correctamente");
                string respuesta = "11/" + user.Name;
                byte[] msg = Encoding.ASCII.GetBytes(respuesta);
                server.Send(msg);
                player.controls.stop();
                Close();
            }
        }

        private void consultasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (consultasToolStripMenuItem.Checked == true)
            {
                panelconsultas1.Visible = true;
                panelconsultas2.Visible = true;
                panelconsultas3.Visible = true;
            }
            else if (consultasToolStripMenuItem.Checked == false)
            {
                panelconsultas1.Visible = false;
                panelconsultas2.Visible = false;
                panelconsultas3.Visible = false;
            }

        }

        private void buscarenfrentadosBtn_Click(object sender, EventArgs e)
        {
            string mensaje = "12/" + user.Name;
            byte[] msg = Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }

        internal void LlenarEnfrentados(string mensaje)
        {
            foreach (DataGridViewRow row in EnfrentadosDGV.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    // Clear the content of each cell
                    cell.Value = null; // Or use an empty string: ""
                }
            }
            string[] trozos = mensaje.Split('/');
            if (trozos[0] == "-1")
            {
                MessageBox.Show("Aun no has jugado contra nadie.");
            }
            else
            {
                EnfrentadosDGV.RowCount = 0;
                for (int i = 0; i < trozos.Length; i++)
                {
                    EnfrentadosDGV.Rows.Add(trozos[i]);
                }
            }
        }

        private void Buscar2_Click(object sender, EventArgs e)
        {
            if (RivalBox.Text != "")
            {
                string mensaje = "13/" + user.Name + "/" + RivalBox.Text;
                byte[] msg = Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
            else
                MessageBox.Show("Introduce un usuario.");
            
        }

        internal void LlenarResultadosRival(string mensaje)
        {
            foreach (DataGridViewRow row in ResultadosDGV.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    // Clear the content of each cell
                    cell.Value = null; // Or use an empty string: ""
                }
            }
            string[] trozos = mensaje.Split('/');
            if (trozos[0] == "-1")
            {
                MessageBox.Show("Aun no has jugado contra ese jugador.");
            }
            else
            {
                ResultadosDGV.RowCount = 0;
                for (int i = 0; i < trozos.Length / 2; i++)
                {
                    ResultadosDGV.Rows.Add(trozos[2 * i], trozos[2 * i + 1]);
                }
            }
        }

        private void Periodo_btn_Click(object sender, EventArgs e)
        {

                string mensaje = "14/" + this.dateTimePickerInit.Text + "/" + this.dateTimePickerEnd.Text;
                byte[] msg = Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

        }

        internal void LlenarPeriodos(string mensaje)
        {
            foreach (DataGridViewRow row in Periodo_DGV.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    // Clear the content of each cell
                    cell.Value = null; // Or use an empty string: ""
                }
            }
            string[] trozos = mensaje.Split('/');
            if (trozos[0] == "-1")
            {
                MessageBox.Show("No se han encontrado partidas en ese intervalo.");
            }
            else
            {
                Periodo_DGV.RowCount = 0;
                for (int i = 0; i < trozos.Length / 3; i++)

                {
                    Periodo_DGV.Rows.Add(trozos[3 * i], trozos[3 * i + 1] + " --> " + Convert.ToInt32(trozos[3 * i + 2]), trozos[3 * i + 3] + " --> " + Convert.ToInt32(trozos[3 * i + 4]));
                }
            }        
        }

        private void manualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process proceso = new Process();
            proceso.StartInfo.FileName = "Manual_Juego.pdf"; // en el bin\Debug
            proceso.Start();
        }
    }
}
