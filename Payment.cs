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
    public partial class Payment : Form
    {
        public Payment()
        {
            InitializeComponent();
            CenterToParent();
        }
        public int totalamount = 0;
        public int foodBill = 0;
        private double finalTotalFinalized = 0.0;
        private string paymentType = " ";
        double totalWithTax;
        double FinalTotal;


        public double FinalTotalFinalized
        {
            get { return finalTotalFinalized; }
            set { finalTotalFinalized = value; }
        }

        public string PaymentType
        {
            get { return paymentType; }
            set { paymentType = value; }
        }
        private string payment_Number = "0";

        public string PaymentCardNumber
        {
            get { return payment_Number; }
            set { payment_Number = value; }
        }




        private void Payment_Load(object sender, EventArgs e)
        {

            totalWithTax = Convert.ToDouble(totalamount) * 0.07;
            FinalTotal = Convert.ToDouble(totalamount) + totalWithTax + foodBill;
            label3.Text = "=" + Convert.ToString(totalamount) + " Tk";
            label5.Text = "=" + Convert.ToString(foodBill) + " Tk";
            label7.Text = "=" + Convert.ToString(totalWithTax) + " Tk";
            label10.Text = "=" + Convert.ToString(FinalTotal) + " Tk";
            FinalTotalFinalized = FinalTotal;

        }

        private void nextButton_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                PaymentType = comboBox1.Text;
                PaymentCardNumber = textBox1.Text;
                FinalTotalFinalized = FinalTotal;

                this.Hide();
            }
            catch (Exception)
            {
                MessageBox.Show(this, "Error Closing the window", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}