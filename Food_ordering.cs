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
    public partial class Food_ordering : Form
    {
        public Food_ordering()
        {
            InitializeComponent();
        }
        double friesp = 80.0, burgerp = 150.0, pizzap = 200.0, pastap = 180.0, noodlesp = 120.0, swarmap = 90.0, meatballp = 25.0;
        double cokep = 40.0, dewp = 35.0, chocoshakep = 140.0, mintshakep = 100.0, dougnautp = 30.0, icecreamp = 70.0, puddingp = 50.0;
        double friestp, burgertp, pizzatp, pastatp, noodlestp, swarmatp, meatballtp, coketp, dewtp, chocoshaketp, mintshaketp, dougnauttp, icecreamtp, puddingtp, tax, total;


        private void Food_ordering_Load(object sender, EventArgs e)
        {
            label25.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
            var dt1 = DateTime.Now;
            string dates = dt1.ToString("dddd, dd MMMM yyyy");
            label24.Text = dates;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox8.Checked == true)
            {
                textBox8.Enabled = true;
            }
            if (checkBox8.Checked == false)
            {
                textBox8.Enabled = false;
                textBox8.Text = "0";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(richTextBox1.Text + " Subtotal: " + label21.Text + "; VAT: " + label22.Text + "; Total: " + label23.Text, new Font("Century Gothic", 17, FontStyle.Regular), Brushes.Blue, new Point(130));

        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }
        double subtotal = 0;

        private void button1_Click(object sender, EventArgs e)
        {

            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            checkBox7.Checked = false;
            checkBox8.Checked = false;
            checkBox9.Checked = false;
            checkBox10.Checked = false;
            checkBox11.Checked = false;
            checkBox12.Checked = false;
            checkBox13.Checked = false;
            checkBox14.Checked = false;
            richTextBox1.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var dt1 = DateTime.Now;
            string dates = dt1.ToString("dddd, dd MMMM yyyy");
            friestp = friesp * Convert.ToDouble(textBox1.Text);
            burgertp = burgerp * Convert.ToDouble(textBox2.Text);
            pizzatp = pizzap * Convert.ToDouble(textBox3.Text);
            pastatp = pastap * Convert.ToDouble(textBox4.Text);
            noodlestp = noodlesp * Convert.ToDouble(textBox5.Text);
            swarmatp = swarmap * Convert.ToDouble(textBox6.Text);
            meatballtp = meatballp * Convert.ToDouble(textBox7.Text);
            coketp = cokep * Convert.ToDouble(textBox8.Text);
            dewtp = dewp * Convert.ToDouble(textBox9.Text);
            chocoshaketp = chocoshakep * Convert.ToDouble(textBox10.Text);
            mintshaketp = mintshakep * Convert.ToDouble(textBox11.Text);
            dougnauttp = dougnautp * Convert.ToDouble(textBox12.Text);
            icecreamtp = icecreamp * Convert.ToDouble(textBox13.Text);
            puddingtp = puddingp * Convert.ToDouble(textBox14.Text);
            richTextBox1.Clear();
            richTextBox1.AppendText(Environment.NewLine);
            richTextBox1.AppendText("\t INN CONTROL FAST FOOD" + Environment.NewLine);
            richTextBox1.AppendText(" =====================" + Environment.NewLine);
            richTextBox1.AppendText("" + dates + "\t" + label25.Text + Environment.NewLine);
            richTextBox1.AppendText(Environment.NewLine);
            richTextBox1.AppendText(Environment.NewLine);
            int count = 0;
            if (checkBox1.Checked == true)
            {
                count++;
                richTextBox1.AppendText("\t" + Convert.ToString(count) + ".Fries:" + friestp + " TAKA" + Environment.NewLine);
                subtotal = subtotal + friestp;
                label18.Text = "" + Convert.ToString(subtotal) + " taka/-";
            }
            if (checkBox2.Checked == true)
            {
                count++;
                richTextBox1.AppendText("\t" + Convert.ToString(count) + ".  Burger:" + burgertp + " TAKA" + Environment.NewLine);
                subtotal = subtotal + burgertp;
                label18.Text = "" + Convert.ToString(subtotal) + " taka/-";
            }
            if (checkBox3.Checked == true)
            {
                count++;
                richTextBox1.AppendText("\t" + Convert.ToString(count) + ".  Pizza:" + pizzatp + " TAKA" + Environment.NewLine);
                subtotal = subtotal + pizzatp;
                label18.Text = "" + Convert.ToString(subtotal) + " taka/-";
            }
            if (checkBox4.Checked == true)
            {
                count++;
                richTextBox1.AppendText("\t" + Convert.ToString(count) + ".  Pasta:" + pastatp + " TAKA" + Environment.NewLine);
                subtotal = subtotal + pastatp;
                label18.Text = "" + Convert.ToString(subtotal) + " taka/-";
            }
            if (checkBox5.Checked == true)
            {
                count++;
                richTextBox1.AppendText("\t" + Convert.ToString(count) + ".  Noodles:" + noodlestp + " TAKA" + Environment.NewLine);
                subtotal = subtotal + noodlestp;
                label18.Text = "" + Convert.ToString(subtotal) + " taka/-";
            }
            if (checkBox6.Checked == true)
            {
                count++;
                richTextBox1.AppendText("\t" + Convert.ToString(count) + ".  Swarma:" + swarmatp + " TAKA" + Environment.NewLine);
                subtotal = subtotal + swarmatp;
                label18.Text = "" + Convert.ToString(subtotal) + " taka/-";
            }
            if (checkBox7.Checked == true)
            {
                count++;
                richTextBox1.AppendText("\t" + Convert.ToString(count) + ".  Meat-Balls:" + meatballtp + " TAKA" + Environment.NewLine);
                subtotal = subtotal + meatballtp;
                label18.Text = "" + Convert.ToString(subtotal) + " taka/-";
            }
            if (checkBox8.Checked == true)
            {
                count++;
                richTextBox1.AppendText("\t" + Convert.ToString(count) + ".  Coka-Cola:" + coketp + " TAKA" + Environment.NewLine);
                subtotal = subtotal + coketp;
                label18.Text = "" + Convert.ToString(subtotal) + " taka/-";
            }
            if (checkBox9.Checked == true)
            {
                count++;
                richTextBox1.AppendText("\t" + Convert.ToString(count) + ".  Mountain-Dew:" + dewtp + " TAKA" + Environment.NewLine);
                subtotal = subtotal + dewtp;
                label18.Text = "" + Convert.ToString(subtotal) + " taka/-";
            }
            if (checkBox10.Checked == true)
            {
                count++;
                richTextBox1.AppendText("\t" + Convert.ToString(count) + ".  ChocoShake:" + chocoshaketp + " TAKA" + Environment.NewLine);
                subtotal = subtotal + chocoshaketp;
                label18.Text = "" + Convert.ToString(subtotal) + " taka/-";
            }
            if (checkBox11.Checked == true)
            {
                count++;
                richTextBox1.AppendText("\t" + Convert.ToString(count) + ".  MintShake:" + mintshakep + " TAKA" + Environment.NewLine);
                subtotal = subtotal + mintshakep;
                label18.Text = "" + Convert.ToString(subtotal) + " taka/-";
            }
            if (checkBox12.Checked == true)
            {
                count++;
                richTextBox1.AppendText("\t" + Convert.ToString(count) + ".  Dougnauts:" + dougnautp + " TAKA" + Environment.NewLine);
                subtotal = subtotal + dougnautp;
                label18.Text = "" + Convert.ToString(subtotal) + " taka/-";
            }
            if (checkBox13.Checked == true)
            {
                count++;
                richTextBox1.AppendText("\t" + Convert.ToString(count) + ".  Ice -Cream:" + icecreamtp + " TAKA" + Environment.NewLine);
                subtotal = subtotal + icecreamtp;
                label18.Text = "" + Convert.ToString(subtotal) + " taka/-";
            }
            if (checkBox14.Checked == true)
            {
                count++;
                richTextBox1.AppendText("\t" + Convert.ToString(count) + ".  Pudding:" + puddingtp + " TAKA" + Environment.NewLine);
                subtotal = subtotal + puddingtp;
                label18.Text = "" + Convert.ToString(subtotal) + " taka/-";
            }
            tax = subtotal * 0.10;
            total = subtotal + tax;
            label19.Text = Convert.ToString(tax) + " taka/-";
            label20.Text = Convert.ToString(total) + " taka/-";
            richTextBox1.AppendText(Environment.NewLine);
            richTextBox1.AppendText(Environment.NewLine);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label25.Text = DateTime.Now.ToLongTimeString();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox1.Enabled = true;
            }
            if (checkBox1.Checked == false)
            {
                textBox1.Enabled = false;
                textBox1.Text = "0";
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                textBox2.Enabled = true;
            }
            if (checkBox2.Checked == false)
            {
                textBox2.Enabled = false;
                textBox2.Text = "0";
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                textBox3.Enabled = true;
            }
            if (checkBox3.Checked == false)
            {
                textBox3.Enabled = false;
                textBox3.Text = "0";
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                textBox4.Enabled = true;
            }
            if (checkBox4.Checked == false)
            {
                textBox4.Enabled = false;
                textBox4.Text = "0";
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true)
            {
                textBox5.Enabled = true;
            }
            if (checkBox5.Checked == false)
            {
                textBox5.Enabled = false;
                textBox5.Text = "0";
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked == true)
            {
                textBox6.Enabled = true;
            }
            if (checkBox6.Checked == false)
            {
                textBox6.Enabled = false;
                textBox6.Text = "0";
            }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked == true)
            {
                textBox7.Enabled = true;
            }
            if (checkBox7.Checked == false)
            {
                textBox7.Enabled = false;
                textBox7.Text = "0";
            }
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox9.Checked == true)
            {
                textBox9.Enabled = true;
            }
            if (checkBox9.Checked == false)
            {
                textBox9.Enabled = false;
                textBox9.Text = "0";
            }
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox10.Checked == true)
            {
                textBox10.Enabled = true;
            }
            if (checkBox10.Checked == false)
            {
                textBox10.Enabled = false;
                textBox10.Text = "0";
            }
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox11.Checked == true)
            {
                textBox11.Enabled = true;
            }
            if (checkBox11.Checked == false)
            {
                textBox11.Enabled = false;
                textBox11.Text = "0";
            }
        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox12.Checked == true)
            {
                textBox12.Enabled = true;
            }
            if (checkBox12.Checked == false)
            {
                textBox12.Enabled = false;
                textBox12.Text = "0";
            }
        }

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox13.Checked == true)
            {
                textBox13.Enabled = true;
            }
            if (checkBox13.Checked == false)
            {
                textBox13.Enabled = false;
                textBox13.Text = "0";
            }
        }

        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox14.Checked == true)
            {
                textBox14.Enabled = true;
            }
            if (checkBox14.Checked == false)
            {
                textBox14.Enabled = false;
                textBox14.Text = "0";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Homepage homepage1 = new Homepage();
            homepage1.Show();
        }
    }
}
