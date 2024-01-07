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

            if(mail_box.Text == "")
            {
                Correo.ForeColor = Color.Red;
            }
            if (pass_box.Text == "")
            {
                PasswordLbl.ForeColor = Color.Red;
            }
            if (user_box.Text == "")
            {
                NombreLbl.ForeColor = Color.Red;
            }
            if (server != null && user.Email != "" && user.Password != "" && user.Name != "")
            {
                string mensaje = "1/" + user.Name + "/" + user.Email + "/" + user.Password;
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
            else
            {
                MessageBox.Show("Faltan campos por rellenar");
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

        private void user_box_TextChanged(object sender, EventArgs e)
        {
            NombreLbl.ForeColor = Color.Black;
            PasswordLbl.ForeColor = Color.Black;
            Correo.ForeColor = Color.Black;
        }

        private void user_box_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '/')
            {
                e.Handled = true;
            }
        }
    }
}
