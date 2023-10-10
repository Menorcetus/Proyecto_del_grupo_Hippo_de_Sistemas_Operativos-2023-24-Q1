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
                mensaje = Encoding.ASCII.GetString(msg2).Split(',')[0];
                if (Convert.ToInt32(mensaje) == 0)
                {
                    MessageBox.Show("El usuario ha inciado sesión correctamente.");

                }
                //control de errores a revisar
                else
                {
                    MessageBox.Show("Error al iniciar sesión.");
                }
            }
            else
            {
                MessageBox.Show("Aun no te has conectado cabezon");
            }

        }
    }
}
