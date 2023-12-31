﻿using System;
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
    public partial class login_form : Form
    {
        User user = new User();
        Socket server;
        public login_form(Socket server)
        {
            InitializeComponent();
            this.server = server;
                        if (server == null)
            {
                MessageBox.Show("No estas conectado al servidor, conectate antes de continuar");
            }
        }

        public User GetUser()
        {
            return this.user;
        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            user.Name = user_box.Text;
            user.Password = pass_box.Text;
            user.register = false;
            if (user.Name == "")
            {
                UsuarioLbl.ForeColor = Color.Red;
            }
            if (user.Password == "")
            {
                PaswordLbl.ForeColor = Color.Red;
            }
            else if(server != null && user.Name != "" && user.Password != "")
            {
                string mensaje = "2/" + user.Name + "/" + user.Password;
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
            else
            {
                MessageBox.Show("Revisa las credenciales.", "Advertencia");
            }

        }

        public int Respuesta(String mensaje)
        {
            string[] trozos = mensaje.Split('/');
            if (trozos[0] == "Se ha iniciado sesion")
            {
                user.Name = trozos[1];
                user.Email = trozos[2];
            }
            if (trozos[0] == "Se ha iniciado sesion")
            {
                MessageBox.Show(mensaje.Split('/')[0]);
                return 0;
            }
            else if (trozos[0] == "El usuario ya esta conectado")
            {
                MessageBox.Show(trozos[0], "Advertencia");
                return 1;
            }
            else
            {
                MessageBox.Show("Revisa las credenciales.", "Advertencia");
                return 1;
            }
        }

        private void user_box_TextChanged(object sender, EventArgs e)
        {
            UsuarioLbl.ForeColor = Color.Black;
            PaswordLbl.ForeColor = Color.Black;
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
