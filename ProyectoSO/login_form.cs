using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoSO
{
    public partial class login_form : Form
    {
        User user;
        public login_form(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            user.Name = user_box.Text;
            user.Password = pass_box.Text;
            user.register = false;
        }
    }
}
