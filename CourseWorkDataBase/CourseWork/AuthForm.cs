using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class AuthForm : Form
    {
        public AuthForm()
        {
            InitializeComponent();
        }


        public string userName
        {
            get { return UserName.Text; }
            set { UserName.Text = value; }
        }

        public string password
        {
            get { return Password.Text; }
            set { Password.Text = value; }
        }

        public Button login
        {
            get { return Login; }
        }


        private void Login_Click_1(object sender, EventArgs e)
        {

        }
    }
}
