using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HOTELMANAGEMENTSYSTEM
{
    public partial class Reservationedit : Form
    {
        public Reservationedit()
        {
            InitializeComponent();
        }


        SqlConnection conn = new SqlConnection("Data Source=RAJ;Initial Catalog=RESERVATION_DETAILS;Integrated Security=True");
        public int userID;

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminPanel adminPanel = new AdminPanel();
            adminPanel.Show();
        }

        private void Reservationedit_Load(object sender, EventArgs e)
        {
            GetreservationRecord();
        }
        private void GetreservationRecord()
        {

            SqlCommand cmd = new SqlCommand("select * from reservationtable", conn);

            DataTable dt = new DataTable();

            conn.Open();

            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);

            conn.Close();

            dataGridView1.DataSource = dt;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            resetForm();
        }
        private void resetForm()
        {
            userID = 0;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
            textBox13.Clear();
            textBox14.Clear();
            textBox15.Clear();

            textBox1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (userID > 0)
            {
                SqlCommand cmd = new SqlCommand("update reservationtable set first_name=@first_name, last_name = @last_name, phone_number= @phone_number, email_address = @email_address, street_name = @street_name, city = @city,number_guest=@number_guest,room_type=@room_type,room_floor=@room_floor,room_number=@room_number,gender=@gender,food_bill=@food_bill,total_bill=@total_bill,payment_type=@payment_type,payment_number=@payment_number where userID = @userID", conn);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@first_name", textBox1.Text);
                cmd.Parameters.AddWithValue("@last_name", textBox2.Text);
                cmd.Parameters.AddWithValue("@phone_number", textBox3.Text);
                cmd.Parameters.AddWithValue("@email_address", textBox4.Text);
                cmd.Parameters.AddWithValue("@street_name", textBox5.Text);
                cmd.Parameters.AddWithValue("@city", textBox6.Text);
                cmd.Parameters.AddWithValue("@number_guest", textBox7.Text);
                cmd.Parameters.AddWithValue("@room_type", textBox8.Text);
                cmd.Parameters.AddWithValue("@room_floor", textBox9.Text);
                cmd.Parameters.AddWithValue("@room_number", textBox10.Text);
                cmd.Parameters.AddWithValue("@gender", textBox11.Text);
                cmd.Parameters.AddWithValue("@food_bill", textBox12.Text);
                cmd.Parameters.AddWithValue("@total_bill", textBox13.Text);
                cmd.Parameters.AddWithValue("@payment_type", textBox14.Text);
                cmd.Parameters.AddWithValue("@payment_number", textBox15.Text);
                cmd.Parameters.AddWithValue("@userID", this.userID);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Customer info updated successfully", "Updated!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetreservationRecord();

                resetForm();
            }
            else
            {
                MessageBox.Show("Please select a Customer first.", "Select?", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (userID > 0)
            {

                SqlCommand cmd = new SqlCommand("delete from reservationtable where userID = @userID", conn);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@userID", this.userID);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Customer is deleted from the database.", "Deleted!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetreservationRecord();

                resetForm();


            }
            else
                MessageBox.Show("Please select a Customer first.", "Select?", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            userID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);

            textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
            textBox6.Text = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
            textBox7.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            textBox8.Text = dataGridView1.SelectedRows[0].Cells[12].Value.ToString();
            textBox9.Text = dataGridView1.SelectedRows[0].Cells[13].Value.ToString();
            textBox10.Text = dataGridView1.SelectedRows[0].Cells[14].Value.ToString();
            textBox11.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox12.Text = dataGridView1.SelectedRows[0].Cells[28].Value.ToString();
            textBox13.Text = dataGridView1.SelectedRows[0].Cells[15].Value.ToString();
            textBox14.Text = dataGridView1.SelectedRows[0].Cells[16].Value.ToString();
            textBox15.Text = dataGridView1.SelectedRows[0].Cells[17].Value.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string message = "\t\tSorry ! \n\t You cant insert any reservation . \n\t Insertion is only valid for reservator. \n\tThank You !";
            string title = "Sorry!";
            MessageBox.Show(message, title);

        }
    }
}

