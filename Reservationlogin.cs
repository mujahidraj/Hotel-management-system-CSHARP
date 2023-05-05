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

    public partial class Reservationlogin : Form
    {
      
        public Reservationlogin()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=RAJ;Initial Catalog=EMPLOYEE_DETAILS;Integrated Security=True");

        private void Reservationlogin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Homepage homepage2 = new Homepage();
            homepage2.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string username, password;

            username = textBox1.Text;
            password = textBox2.Text;

            try
            {
                string querry = " select * from EMPLOYEEINFO2 where Email = '" + textBox1.Text + "' and employeeID = '" + textBox2.Text + "' and Dept = '" + "Reservation" + "';";
                SqlDataAdapter sda = new SqlDataAdapter(querry, conn);

                DataTable dtable = new DataTable();
                sda.Fill(dtable);

                if (dtable.Rows.Count > 0)
                {
                    username = textBox1.Text;
                    password = textBox2.Text;

                    MessageBox.Show("Login Success! Welcome Reservator", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    Reservation reservation = new Reservation();
                    reservation.Show();
                }
                else
                {
                    MessageBox.Show("Wrong Information! or you are not Reservator", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void button5_Click(object sender, EventArgs e)
        {

            Help help1 = new Help();
            help1.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string message = "\t Please go to the admin \n\t panel with admin";
            string title = "Forgot password : Yes \n";
            MessageBox.Show(message, title);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string message = "\t\t Thank you ! \n\t Sign in with your username and password.";
            string title = "Forgot password : no \n";
            MessageBox.Show(message, title);

        }
    }
}
