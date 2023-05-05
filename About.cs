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
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void About_Load(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string message = "\t\tDevelopers \n Name :   1.Moizuddin Mohammad Mujahid Rashid \n\t 2.Asmaul Husna Mayad \n\t 3. Farhanaz Kamrun";
            string title = "Developer";
            MessageBox.Show(message, title);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Homepage homepage3 = new Homepage();
            homepage3.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}
