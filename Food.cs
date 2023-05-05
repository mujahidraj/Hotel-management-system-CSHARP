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
    public partial class Food : Form
    {
        public Food()
        {
            InitializeComponent();
        }
        private int lunchQ;

        public int LunchQ
        {
            get { return lunchQ; }
            set { lunchQ = value; }
        }
        private int breakfastQ;

        public int BreakfastQ
        {
            get { return breakfastQ; }
            set { breakfastQ = value; }
        }
        private int dinnerQ;

        public int DinnerQ
        {
            get { return dinnerQ; }
            set { dinnerQ = value; }
        }

        private string cleaning = "";

        public string Cleaning
        {
            get { return cleaning; }
            set { cleaning = value; }
        }
        private string towel = "";

        public string Towel
        {
            get { return towel; }
            set { towel = value; }
        }

        private string surprise = "";

        public string Surprise
        {
            get { return surprise; }
            set { surprise = value; }
        }

        private void nextButton_Click(object sender, EventArgs e)
        {

        }

        private void breakfastCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox1.Enabled = true;
            }
        }

        private void lunchCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                textBox2.Enabled = true;
            }
        }

        private void dinnerCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                textBox3.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                BreakfastQ = Convert.ToInt32(textBox1.Text);
            }
            if (checkBox2.Checked)
            {
                LunchQ = Convert.ToInt32(textBox2.Text);
            }
            if (checkBox3.Checked)
            {
                DinnerQ = Convert.ToInt32(textBox3.Text);
            }
            if (checkBox4.Checked)
            {
                Cleaning = checkBox4.Text;
            }
            if (checkBox5.Checked)
            {
                Towel = checkBox5.Text;
            }
            if (checkBox6.Checked)
            {
                Surprise = checkBox5.Text;
            }

            this.Hide();
        }
    }
}