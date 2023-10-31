using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoSO
{
    public partial class Grid_Form_Conectados : Form
    {
        User user;
        Socket server;
        public Grid_Form_Conectados(User user, Socket server)
        {

            this.user = user;
            this.server = server;
            InitializeComponent();

        }

        private void Grid_Form_Conectados_Load(object sender, EventArgs e)
        {
            if (server != null)
            {
                string mensaje = "3/";
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                //Recibimos la respuesta del servidor
                byte[] msg2 = new byte[80];
                server.Receive(msg2);

                //formato de mensaje NumeroConectados/Nombre/Nombre/Nombre--> NumeroCon/Nombre/Jugando/Nombre/Jugando/..
                mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                string resultado = mensaje.Split('/')[0]; //numero
                int i = 0;
                dataGridConectados.RowCount = Convert.ToInt32(resultado);
                dataGridConectados.ColumnCount = 2;
                dataGridConectados.Columns[0].HeaderText = "Usuario";
                dataGridConectados.Columns[0].HeaderText = "Jugando";
                while (i < Convert.ToInt32(resultado))
                {
                    dataGridConectados.Rows[i].Cells[0].Value = mensaje.Split('/')[i];
                    i++;
                    //dataGridConectados.Rows[i].Cells[1].Value = mensaje.Split('/')[i];
                    //Habrá que separar otra vez y poner un if en funcion de si es 1 o 0
                    i++;
                }


            }



        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (server != null)
            {
                string mensaje = "3/";
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                //Recibimos la respuesta del servidor
                byte[] msg2 = new byte[80];
                server.Receive(msg2);

                //formato de mensaje NumeroConectados/Nombre/Nombre/Nombre--> NumeroCon/Nombre/Jugando/Nombre/Jugando/..
                mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                string resultado = mensaje.Split('/')[0]; //numero
                int i = 0;
                dataGridConectados.RowCount = Convert.ToInt32(resultado);
                dataGridConectados.ColumnCount = 2;
                dataGridConectados.Columns[0].HeaderText = "Usuario";
                dataGridConectados.Columns[0].HeaderText = "Jugando";
                while (i < Convert.ToInt32(resultado))
                {
                    dataGridConectados.Rows[i].Cells[0].Value = mensaje.Split('/')[i];
                    i++;
                    //dataGridConectados.Rows[i].Cells[1].Value = mensaje.Split('/')[i];
                    //Habrá que separar otra vez y poner un if en funcion de si es 1 o 0
                    i++;
                }


            }


        }
    }
}
