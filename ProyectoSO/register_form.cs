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
            if(server != null && user.Email != "" && user.Password != "" && user.Name != "")
            {
                string mensaje = "1/" + user.Name + "/" + user.Email + "/" + user.Password;
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
            else
            {
                MessageBox.Show("Sigues sin conectarte...");
            }
           
        }

        public void Respuesta(String mensaje)
        {
            if (mensaje == "Se ha registrado el usuario")
            {
                MessageBox.Show(mensaje);
                Close();
            }
            else
                MessageBox.Show(mensaje);
        }
    }
}
