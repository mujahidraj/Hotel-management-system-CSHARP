using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HOTELMANAGEMENTSYSTEM
{
    public partial class Help : Form
    {
        public Help()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            string message = "\t\tManage Your E_mail Account \n\t if you find any problem with your e-mail account, \n\t please contact with the admin resolve the  \n\t problem you are facing.Check your email.";
            string title = "E-mail Account manage.";
            MessageBox.Show(message, title);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            string message = "\t\tManage Your Information \n\t If you want to manage your information that you given \n\t during you're recruitment please go to the admin panel. \n\t Your log in information are hidden. ";
            string title = "Information Manage.";
            MessageBox.Show(message, title);
        }

        private void label4_Click(object sender, EventArgs e)
        {

            string message = "\t\t Sign Up process  \n\t You have to place your username at username box.  \n\t And password at password box . \n\tIf you put a valid information and if \n\t you are a valid department person .\n\t You will surely logged in. ";
            string title = "Sign up process.";
            MessageBox.Show(message, title);
        }

        private void label6_Click(object sender, EventArgs e)
        {

            string message = "\t\tCan't Sign In \n\t Please Contact with the admin panel. ";
            string title = "Can't Sign in.";
            MessageBox.Show(message, title);
        }

        private void label5_Click(object sender, EventArgs e)
        {
            string message = "\t\tAccount Recovery \n\t There ais no single way to recover your account, \n\t except contact with the admin panel. ";
            string title = "Account Recovery.";
            MessageBox.Show(message, title);
        }

        private void label7_Click(object sender, EventArgs e)
        {
            string message = "\t\tDepartment requirement \n\t If you are from the department ,\n\t where you want to sign in  \n\t you will surely logged in. \n\t otherwise you will not.";
            string title = "Department Requirement.";
            MessageBox.Show(message, title);
        }
    }
}
