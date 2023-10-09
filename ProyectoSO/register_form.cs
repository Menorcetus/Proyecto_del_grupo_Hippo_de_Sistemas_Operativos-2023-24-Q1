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
    public partial class register_form : Form
    {
        User user;
        
        public register_form(User user)
        {
            InitializeComponent();
            this.user = user;
      
        }

        private void register_btn_Click(object sender, EventArgs e)
        {
            user.Email = mail_box.Text;
            user.Password = pass_box.Text;
            user.Name = user_box.Text;
            user.register = true;
           
        }
    }
}
