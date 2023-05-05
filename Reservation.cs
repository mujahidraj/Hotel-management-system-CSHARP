
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace HOTELMANAGEMENTSYSTEM
{
    public partial class Reservation : Form
    {
        public Reservation()
        {
            InitializeComponent();
            CenterToScreen();
            dateTimePicker1.MinDate = DateTime.Now;
            dateTimePicker2.MinDate = DateTime.Today.AddDays(1);

            LoadForDataGridView();
            getChecked();



        }

        private string getval;

        public string Getval
        {
            get { return getval; }
            set { getval = value; }
        }

        public string towelS, cleaningS, surpriseS;

        public int foodBill;
        public string birthday = "";

        public string food_menu = "";
        public int totalAmount = 0;
        public int checkin = 0;
        public int foodStatus = 0;
        public Int32 id = 0;
        public Boolean taskFinder = false;
        public Boolean editClicked = false;
        public string FPayment, FCnumber;
        private double finalizedTotalAmount = 0.0;
        private string paymentType;
        private string paymentCardNumber;


        public int lunch = 0; public int breakfast = 0; public int dinner = 0;
        public string cleaning; public string towel;
        public string surprise;



        public void ClearAllTextBoxes(Control controls)
        {
            foreach (Control control in controls.Controls)
            {
                if (control is TextBox)
                {
                    ((TextBox)control).Clear();
                }
                if (control.HasChildren)
                {
                    ClearAllTextBoxes(control);
                }
            }
        }
        public void ClearAllComboBox(Control controls)
        {
            foreach (Control control in controls.Controls)
            {
                if (control == comboBox6)
                {
                    continue;
                }
                else if (control is ComboBox)
                {
                    ((ComboBox)control).SelectedIndex = -1;
                }
                if (control.HasChildren)
                {
                    ClearAllComboBox(control);
                }
            }
        }
        private void reset_reservation()
        {
            try
            {

                //button6.Items.Clear();
                checkBox1.Checked = false;
                checkBox3.Checked = false;

                ClearAllComboBox(this);
                ClearAllTextBoxes(this);

                ComboBoxItemsFromDataBase();

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString(), "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void frontend_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void ComboBoxItemsFromDataBase()
        {
            string query = "Select * from   reservationtable";
            SqlConnection connection = new SqlConnection("Data Source=RAJ;Initial Catalog=RESERVATION_DETAILS;Integrated Security=True");

            SqlCommand query_table = new SqlCommand(query, connection);
            SqlDataReader reader;
            try
            {
                connection.Open();
                reader = query_table.ExecuteReader();
                while (reader.Read())
                {
                    string userID = reader["userID"].ToString();
                    string first_name = reader["first_name"].ToString();
                    string last_name = reader["last_name"].ToString();
                    string phone_number = reader["phone_number"].ToString();


                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadForDataGridView()
        {
            SqlConnection connection = new SqlConnection("Data Source=RAJ;Initial Catalog=RESERVATION_DETAILS;Integrated Security=True");
            SqlCommand query = new SqlCommand("Select * from reservationtable", connection);
            try
            {
                connection.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = dataTable;
                dataGridView2.DataSource = bindingSource;
                dataAdapter.Update(dataTable);
                connection.Close();
            }
            catch (Exception)
            {
                MessageBox.Show(this, "Error loading data", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.None);
            }
        }





        private void getChecked()
        {
            List<string> TakenRoomList = new List<string>();

            string query = "Select room_number from reservationtable where check_in = '" + "True" + "';";
            SqlConnection connection = new SqlConnection("Data Source=RAJ;Initial Catalog=RESERVATION_DETAILS;Integrated Security=True");

            SqlCommand query_table = new SqlCommand(query, connection);

            SqlDataReader reader;
            try
            {
                connection.Open();
                reader = query_table.ExecuteReader();
                while (reader.Read())
                {
                    string room_number = reader["room_number"].ToString();
                    TakenRoomList.Add(room_number.Replace(" ", string.Empty));
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            foreach (string roomList in TakenRoomList)
            {
                if (comboBox8.Items.Contains(roomList))
                {

                    int temp = comboBox8.Items.IndexOf(roomList);
                    comboBox8.Items.RemoveAt(temp);
                }
            }
        }


        private void label15_Click(object sender, EventArgs e)
        {

        }

        public void button1_Click(object sender, EventArgs e)
        {

            Food food_menu = new Food();

            if (taskFinder)
            {
                if (breakfast > 0)
                {
                    food_menu.checkBox1.Checked = true;
                    food_menu.textBox1.Text = Convert.ToString(breakfast);
                }
                if (lunch > 0)
                {
                    food_menu.checkBox2.Checked = true;

                    food_menu.textBox2.Text = Convert.ToString(lunch);
                }
                if (dinner > 0)
                {
                    food_menu.checkBox3.Checked = true;
                    food_menu.textBox3.Text = Convert.ToString(dinner);
                }
                if (cleaning == "1")
                {
                    food_menu.checkBox4.Checked = true;
                }
                if (towel == "1")
                {
                    food_menu.checkBox5.Checked = true;
                }
                if (surprise == "1")
                {
                    food_menu.checkBox6.Checked = true;
                }
            }
            food_menu.ShowDialog();


            breakfast = food_menu.BreakfastQ;
            lunch = food_menu.LunchQ;
            dinner = food_menu.DinnerQ;

            cleaning = food_menu.Cleaning.Replace(" ", string.Empty) == "Cleaning" ? "1" : "0";
            towel = food_menu.Towel.Replace(" ", string.Empty) == "Towels" ? "1" : "0";

            surprise = food_menu.Surprise.Replace(" ", string.Empty) == "Sweetestsurprise" ? "1" : "0";

            if (breakfast > 0 || lunch > 0 || dinner > 0)
            {
                int bfast = 7 * breakfast;
                int Lnch = 15 * lunch;
                int di_ner = 15 * dinner;
                foodBill = bfast + Lnch + di_ner;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (breakfast == 0 && lunch == 0 && dinner == 0 && cleaning == "0" && towel == "0" && surprise == "0")
            {
                checkBox3.Checked = true;
            }
            button3.Enabled = true;

            Payment bill = new Payment();
            bill.totalamount = totalAmount;
            bill.foodBill = foodBill;
            if (taskFinder)
            {
                bill.comboBox1.SelectedItem = FPayment.Replace(" ", string.Empty);
                bill.textBox1.Text = FCnumber;
            }

            bill.ShowDialog();

            finalizedTotalAmount = bill.FinalTotalFinalized;
            paymentType = bill.PaymentType;
            paymentCardNumber = bill.PaymentCardNumber;


            if (!editClicked)
            {
                button1.Visible = true;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            birthday = (comboBox1.SelectedItem) + "-" + (comboBox2.SelectedIndex + 1) + "-" + textBox3.Text;
            Int32 getIDBack = 0;
            string query = "insert into reservationtable (first_name, last_name, birth_day, gender, phone_number, email_address, number_guest, street_name, city,division, district, room_type, room_floor,room_number, total_bill,payment_type, payment_number, arrival_date, leaving_date,check_in, break_fast, lunch, dinner, supply_status, cleaning, towel, s_surprise, food_bill) values('" + textBox1.Text +
              "', '" + textBox2.Text + "', '" + birthday + "', '" + comboBox3.SelectedItem + "', '" + textBox4.Text + "', '" + textBox5.Text +
              "', '" + (comboBox5.SelectedIndex + 1) + "', '" + textBox6.Text + "', '" + textBox7.Text +
              "', '" + comboBox4.SelectedItem + "', '" + textBox8.Text + "', '" + comboBox6.SelectedItem + "', '" + comboBox7.SelectedItem +
              "','" + comboBox8.SelectedItem + "', '" + finalizedTotalAmount + "', '" + paymentType +
              "','" + paymentCardNumber + "', '" + dateTimePicker1.Text + "', '" + dateTimePicker2.Text + "', '" + checkin + "', '" + breakfast + "','" + lunch + "','" + dinner + "', '" + Convert.ToInt32(foodStatus) + "', '" + Convert.ToInt32(cleaning) + "', '" + Convert.ToInt32(towel) + "', '" + Convert.ToInt32(surprise) + "','" + foodBill + "');";
            query += "SELECT CAST(scope_identity() AS int)";


            SqlConnection connection = new SqlConnection("Data Source=RAJ;Initial Catalog=RESERVATION_DETAILS;Integrated Security=True");

            SqlCommand query_table = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                getIDBack = (Int32)query_table.ExecuteScalar();

                string userID = Convert.ToString(getIDBack);

                MessageBox.Show(this, "Entry successfully inserted into database. " + "\n\n" +
                    "Provide this unique ID to the customer." + "\n\n" +
                "USER UNIQUE ID: " + userID, "Report", MessageBoxButtons.OK, MessageBoxIcon.Question);

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            ComboBoxItemsFromDataBase();
            LoadForDataGridView();
            reset_reservation();
            getChecked();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            birthday = (comboBox1.SelectedItem) + "-" + (comboBox2.SelectedIndex + 1) + "-" + textBox3.Text;
            // MessageBox.Show(Convert.ToString(cleaning) + " " + Convert.ToString(towel) + " " + Convert.ToString(surprise));
            string query = "update reservationtable set first_name ='" + textBox1.Text +
              "', last_name ='" + textBox2.Text + "', birth_day='" + birthday + "', gender='" + comboBox3.SelectedItem + "', phone_number='" + textBox4.Text + "', email_address='" + textBox5.Text +
              "', number_guest='" + (comboBox5.SelectedIndex + 1) + "', street_name='" + textBox6.Text + "', city='" + textBox7.Text +
              "', division='" + comboBox4.SelectedItem + "', district='" + textBox8.Text + "', room_type='" + comboBox6.SelectedItem + "', room_floor='" + comboBox7.SelectedItem +
              "', room_number='" + comboBox8.SelectedItem + "', total_bill='" + finalizedTotalAmount + "', payment_type='" + paymentType +
              "', payment_number='" + paymentCardNumber + "', arrival_date='" + dateTimePicker1.Text + "', leaving_date='" + dateTimePicker2.Text + "',check_in='" + checkin + "', break_fast='" + breakfast +
              "', lunch='" + lunch + "', dinner='" + dinner + "', supply_status='" + Convert.ToInt32(foodStatus) + "',cleaning='" + Convert.ToInt32(cleaning) + "',towel='" + Convert.ToInt32(towel) + "',s_surprise='" + Convert.ToInt32(surprise) + "',food_bill='" + foodBill + "' WHERE userID = '" + id + "';";

            SqlConnection connection = new SqlConnection("Data Source=RAJ;Initial Catalog=RESERVATION_DETAILS;Integrated Security=True");

            SqlCommand query_table = new SqlCommand(query, connection);
            SqlDataReader reader;
            try
            {
                connection.Open();
                string userID = Convert.ToString(id);
                reader = query_table.ExecuteReader();

                MessageBox.Show(this, "Entry successfully updated into database. For the UNIQUE USER ID of: " + "\n\n" +
                " " + userID, "Report", MessageBoxButtons.OK, MessageBoxIcon.Question);
                // SendSMS(id);
                while (reader.Read())
                {

                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            ComboBoxItemsFromDataBase();

            reset_reservation();
            LoadForDataGridView();
            getChecked();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (id > 0)
            {
                string query = "delete from reservationtable where userID = '" + id + "'";
                SqlConnection connection = new SqlConnection("Data Source=RAJ;Initial Catalog=RESERVATION_DETAILS;Integrated Security=True");

                SqlCommand query_table = new SqlCommand(query, connection);
                SqlDataReader reader;
                try
                {
                    connection.Open();
                    reader = query_table.ExecuteReader();

                    MessageBox.Show(this, "reservationtable For the UNIQUE USER ID of: " + "\n\n" +
                " " + id + " is DELETED.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    connection.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Selected ID doesn't exist." + ex.ToString(), "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show(this, "Selected ID doesn't exist.", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
            }
            ComboBoxItemsFromDataBase();
            LoadForDataGridView();
            reset_reservation();
            getChecked();

        }

        /*  private void button6_Click(object sender, EventArgs e)
          {
              editClicked = true;
              dateTimePicker1.MinDate = new DateTime(2014, 4, 1);
              dateTimePicker1.CustomFormat = "MM-dd-yyyy";
              dateTimePicker1.Format = DateTimePickerFormat.Custom;

              dateTimePicker2.MinDate = new DateTime(2014, 4, 1);
              dateTimePicker2.CustomFormat = "MM-dd-yyyy";
              dateTimePicker2.Format = DateTimePickerFormat.Custom;

              button4.Visible = false;
              button5.Visible = true;
              button6.Visible = true;
              button7.Visible = true;

              ComboBoxItemsFromDataBase();
              LoadForDataGridView();
              reset_reservation();

          }*/

        /*private void button7_Click(object sender, EventArgs e)
        {
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            button7.Visible = false;
            reset_reservation();

        }*/

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }





        private void tabPage1_Click(object sender, EventArgs e)
        {
            checkBox3.Enabled = false;
        }

        private void comboBox6_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox6.SelectedItem.Equals("Single"))
            {
                totalAmount = 149;
                comboBox7.SelectedItem = "1";
            }
            else if (comboBox6.SelectedItem.Equals("Double"))
            {
                totalAmount = 299;
                comboBox7.SelectedItem = "2";
            }
            else if (comboBox6.SelectedItem.Equals("Twin"))
            {
                totalAmount = 349;
                comboBox7.SelectedItem = "3";
            }
            else if (comboBox6.SelectedItem.Equals("Duplex"))
            {
                totalAmount = 399;
                comboBox7.SelectedItem = "4";
            }
            else if (comboBox6.SelectedItem.Equals("Suite"))
            {
                totalAmount = 499;
                comboBox7.SelectedItem = "5";
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox1.Text = "Checked in";
                checkin = 1;
            }
            else
            {
                checkin = 0;
                checkBox1.Text = "Check in ?";
            }

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                checkBox3.Text = "Food/Supply: Complete";
                foodStatus = 1;
            }
            else
            {
                foodStatus = 0;
                checkBox3.Text = "Food/Supply status?";
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source=RAJ;Initial Catalog=RESERVATION_DETAILS;Integrated Security=True");

            connection.Open();
            string query = "Select * from reservationtable where userID like '%" + textBox9.Text + "%' OR last_name like '%" + textBox9.Text + "%' OR first_name like '%" + textBox9.Text + "%' OR gender like '%" + textBox9.Text + "%' OR street_name like '%" + textBox9.Text + "%' OR city like '%" + textBox9.Text + "%' OR room_number like '%" + textBox9.Text + "%' OR room_type like '%" + textBox9.Text + "%' OR email_address like '%" + textBox9.Text + "%' OR phone_number like '%" + textBox9.Text + "%'";

            SqlCommand com = new SqlCommand(query, connection);
            SqlDataAdapter data_adapter = new SqlDataAdapter(query, connection);
            DataTable data_table = new DataTable();

            data_adapter.Fill(data_table);

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = data_table;
            dataGridView1.DataSource = bindingSource;
            data_adapter.Update(data_table);

            SqlDataReader reader;
            reader = com.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                button8.Location = new Point(752, 7);
                textBox9.Location = new Point(68, 7);
                textBox9.Visible = true;
                dataGridView1.Visible = true;
                label17.Visible = false;

            }
            else
            {
                dataGridView1.Visible = false;
                label17.Visible = true;
                textBox9.Visible = true;

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        /* private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
         {
             getChecked();
             string getQuerystring = comboBox9.Text.Substring(0, 4).Replace(" ", string.Empty);
             //  MessageBox.Show("ID+" + getQuerystring);
             string query = "Select * from reservationtable where Id= '" + getQuerystring + "'";

             SqlConnection connection = new SqlConnection("Data Source = RAJ; Initial Catalog = RESERVATION_DETAILS; Integrated Security = True");
             SqlCommand query_table = new SqlCommand(query, connection);
             SqlDataReader reader;
             try
             {
                 connection.Open();
                 reader = query_table.ExecuteReader();
                 while (reader.Read())
                 {
                     taskFinder = true;
                     string ID = reader["userID"].ToString();
                     string first_name = reader["first_name"].ToString();
                     string last_name = reader["last_name"].ToString();
                     string birth_day = reader["birth_day"].ToString();
                     string gender = reader["gender"].ToString();
                     string phone_number = reader["phone_number"].ToString();
                     string email_address = reader["email_address"].ToString();
                     string number_guest = reader["number_guest"].ToString();
                     string street_address = reader["street_address"].ToString();
                     string apt_suite = reader["apt_suite"].ToString();
                     string city = reader["city"].ToString();
                     string state = reader["state"].ToString();
                     string zip_code = reader["zip_code"].ToString();

                     string room_type = reader["room_type"].ToString();
                     string room_floor = reader["room_floor"].ToString();
                     string room_number = reader["room_number"].ToString();

                     string payment_type = reader["payment_type"].ToString();
                     string card_number = reader["card_number"].ToString();
                     string card_exp = reader["card_exp"].ToString();
                     string card_cvc = reader["card_cvc"].ToString();

                     string _cleaning = reader["cleaning"].ToString();
                     string _towel = reader["towel"].ToString();
                     string _surprise = reader["s_surprise"].ToString();
                     if (_cleaning == "True")
                     {
                         cleaning = "1";
                     }
                     else { cleaning = "0"; }

                     if (_towel == "True")
                     {
                         towel = "1";
                     }
                     else { towel = "0"; }
                     if (_surprise == "True")
                     {
                         surprise = "1";
                     }
                     else
                     {
                         surprise = "0";
                     }
                     comboBox8.Items.Add(room_number);
                     comboBox8.SelectedItem = room_number;

                     FPayment = payment_type; FCnumber = card_number;
                     // FCardCVC = card_cvc; FcardExpOne = card_exp.Substring(0, card_exp.IndexOf('/'));
                     //FcardExpTwo = card_exp.Substring(card_exp.Length - Math.Min(2, card_exp.Length));
                     string check_in = reader["check_in"].ToString();

                     string supply_status = reader["supply_status"].ToString();
                     string food_billD = reader["food_bill"].ToString();

                     string arrival_date = Convert.ToDateTime(reader["arrival_time"]).ToString("MM-dd-yyyy").Replace(" ", string.Empty);
                     dateTimePicker1.Value = Convert.ToDateTime(arrival_date);

                     string leaving_date = Convert.ToDateTime(reader["leaving_time"]).ToString("MM-dd-yyyy").Replace(" ", string.Empty);
                     dateTimePicker2.Value = Convert.ToDateTime(leaving_date);
                     dateTimePicker1.Value.ToShortDateString();
                     dateTimePicker2.Value.ToShortDateString();

                     string _breakfast = reader["break_fast"].ToString();
                     string _lunch = reader["lunch"].ToString();
                     string _dinner = reader["dinner"].ToString();

                     double Num;
                     bool isNum = double.TryParse(_lunch, out Num);
                     if (isNum)
                     {
                         lunch = Int32.Parse(_lunch);
                     }
                     else
                     {
                         lunch = 0;
                     }
                     isNum = double.TryParse(_breakfast, out Num);
                     if (isNum)
                     {
                         breakfast = Int32.Parse(_breakfast);
                     }
                     else
                     {
                         breakfast = 0;
                     }
                     isNum = double.TryParse(_dinner, out Num);
                     if (isNum)
                     {
                         dinner = Int32.Parse(_dinner);
                     }
                     else
                     {
                         dinner = 0;
                     }



                     foodBill = Convert.ToInt32(food_billD);

                     if (supply_status == "True")
                     {
                         checkBox3.Checked = true;
                     }
                     else
                     {
                         checkBox3.Checked = false;
                     }


                     textBox1.Text = first_name;
                     textBox2.Text = last_name;
                     textBox4.Text = phone_number;
                     comboBox3.SelectedItem = gender;

                     comboBox1.SelectedItem = birth_day.Substring(0, birth_day.IndexOf('-'));
                     comboBox2.SelectedItem = birth_day.Substring(birth_day.IndexOf('-') + 1, 2);
                     textBox3.Text = birth_day.Substring(birth_day.Length - Math.Min(4, birth_day.Length));

                     textBox4.Text = email_address;
                     comboBox5.SelectedItem = number_guest;
                     textBox6.Text = street_address;

                     textBox7.Text = city;
                     comboBox4.SelectedItem = state;
                     textBox8.Text = zip_code;
                     comboBox6.SelectedItem = room_type.Replace(" ", string.Empty);
                     comboBox7.SelectedItem = room_floor.Replace(" ", string.Empty);
                     comboBox8.SelectedItem = room_number.Replace(" ", string.Empty);

                     if (check_in == "True")
                     {
                         checkBox1.Checked = true;
                     }
                     else
                     {
                         checkBox1.Checked = false;
                     }


                     id = Convert.ToInt32(ID);
                 }
                 connection.Close();
             }
             catch (Exception ex)
             {
                 MessageBox.Show("COMBOBOX Selection: + " + ex.Message);
             }
         }*/

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            Homepage homepage = new Homepage();
            homepage.Show();
        }

        private void Reservation_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
