using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HOTELMANAGEMENTSYSTEM
{
    public partial class adminlogin : Form
    {
       
        public adminlogin()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=RAJ;Initial Catalog=EMPLOYEE_DETAILS;Integrated Security=True");

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Homepage homepage4 = new Homepage();
            homepage4.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username, password;

            username = textBox1.Text;
            password = textBox2.Text;

            try
            {
                string querry = " select * from EMPLOYEEINFO2 where Email = '" + textBox1.Text + "' and employeeID = '" + textBox2.Text + "' and Dept = '" + "Admin" + "';";
                SqlDataAdapter sda = new SqlDataAdapter(querry, conn);

                DataTable dtable = new DataTable();
                sda.Fill(dtable);

                if (dtable.Rows.Count > 0)
                {
                    username = textBox1.Text;
                    password = textBox2.Text;

                    MessageBox.Show("Login Success! Welcome Admin !", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    AdminPanel adminPanel = new AdminPanel();
                    adminPanel.Show();
                }
                else
                {
                    MessageBox.Show("Wrong Information! or you are not Admin here !", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Error!");
            }
            finally
            {
                conn.Close();
            }


        }

        private void button4_Click(object sender, EventArgs e)
        {

            Help help2 = new Help();
            help2.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string message = "\t Please go to the admin \n\t panel with admin";
            string title = "Forgot password : Yes \n";
            MessageBox.Show(message, title);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string message = "\t\t Thank you ! \n\t Sign in with your username and password.";
            string title = "Forgot password : no \n";
            MessageBox.Show(message, title);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void adminlogin_Load(object sender, EventArgs e)
        {
          
        }
    }
}
