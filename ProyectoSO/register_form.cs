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
    public partial class register_form : Form
    {
        User user;
        Socket server;

        public register_form(User user, Socket server)
        {
            InitializeComponent();
            this.user = user;
            this.server = server;
            if (server == null )
            {
                MessageBox.Show("No estas conectado al servidor, conectate antes de continuar");
            }
      
        }
        public User GetUser()
        {
            return user;
        }

        private void register_btn_Click(object sender, EventArgs e)
        {
            user.Email = mail_box.Text;
            user.Password = pass_box.Text;
            user.Name = user_box.Text;
            user.register = true;
            if(server != null )
            {
                string mensaje = "1/" + user.Name + "/" + user.Email + "/" + user.Password;
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);


                //Recibimos la respuesta del servidor
                byte[] msg2 = new byte[80];
                server.Receive(msg2);


                mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                MessageBox.Show(mensaje);
            }
            else
            {
                MessageBox.Show("Sigues sin conectarte...");
            }
           
        }
    }
}
