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
    public partial class AdminPanel : Form
    {
        public AdminPanel()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Stuff stuff = new Stuff();
            stuff.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Homepage homepage = new Homepage();
            homepage.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Reservationedit reservationedit = new Reservationedit();
            reservationedit.Show();
        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {

        }
    }
}
