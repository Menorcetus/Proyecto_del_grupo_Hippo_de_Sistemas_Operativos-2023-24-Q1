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
    public partial class login_form : Form
    {
        User user;
        Socket server;
        public login_form(User user, Socket server)
        {
            InitializeComponent();
            this.user = user;
            this.server = server;
            if (server == null)
            {
                MessageBox.Show("No estas conectado al servidor, conectate antes de continuar");
            }
        }

        public User GetUser()
        {
            return user;
        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            user.Name = user_box.Text;
            user.Password = pass_box.Text;
            user.register = false;
            if(server != null)
            {
                string mensaje = "2/" + user.Name + "/" + user.Password;
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                //Recibimos la respuesta del servidor
                byte[] msg2 = new byte[80];
                server.Receive(msg2);


                mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                string resultado = mensaje.Split('/')[0];
                if(resultado == "Se ha iniciado sesion")
                {
                    user.Name = mensaje.Split('/')[1];
                    user.Email = mensaje.Split('/')[2];
                    // faltan cosas a implementar pero de momento esta bien asi
                    Principal_Logged principal_Logged = new Principal_Logged(user, server);
                    principal_Logged.Show();

                }
                MessageBox.Show(resultado);
                Close();
            }
            else
            {
                MessageBox.Show("Aun no te has conectado cabezon");
            }

        }
    }
}
