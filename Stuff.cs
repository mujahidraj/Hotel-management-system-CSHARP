using System.Data;
using System.Data.SqlClient;


namespace HOTELMANAGEMENTSYSTEM
{
    public partial class Stuff : Form
    {
        public Stuff()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection("Data Source=RAJ;Initial Catalog=EMPLOYEE_DETAILS;Integrated Security=True");
        public int employeeID;

        private void Stuff_Load(object sender, EventArgs e)
        {
            GetemployeesRecord();
        }
        private void GetemployeesRecord()
        {

            SqlCommand cmd = new SqlCommand("select * from EMPLOYEEINFO2", conn);

            DataTable dt = new DataTable();

            conn.Open();

            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);

            conn.Close();

            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                SqlCommand cmd = new SqlCommand("insert into EMPLOYEEINFO2 values (@Email,@E_Name, @ID, @JOINdate, @Dept, @Salary,@E_Address,@Phoneno,@Blood)", conn);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@Email", textBox9.Text);
                cmd.Parameters.AddWithValue("@E_Name", textBox1.Text);
                cmd.Parameters.AddWithValue("@ID", textBox2.Text);
                cmd.Parameters.AddWithValue("@JOINdate", textBox3.Text);
                cmd.Parameters.AddWithValue("@Dept", textBox4.Text);
                cmd.Parameters.AddWithValue("@Salary", textBox5.Text);
                cmd.Parameters.AddWithValue("@E_Address", textBox6.Text);
                cmd.Parameters.AddWithValue("@Phoneno", textBox7.Text);
                cmd.Parameters.AddWithValue("Blood", textBox8.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("New employee is successfully inserted in the database", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetemployeesRecord();

                resetForm();
            }
        }
        private bool IsValid()
        {
            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("employee name is required", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            resetForm();
        }
        private void resetForm()
        {
            employeeID = 0;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();

            textBox1.Focus();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (employeeID > 0)
            {
                SqlCommand cmd = new SqlCommand("update EMPLOYEEINFO2 set Email=@Email, E_Name = @E_Name, ID = @ID, JOINdate = @JOINdate, Dept = @Dept, Salary = @Salary,E_Address=@E_Address,Phoneno=@Phoneno,Blood=@Blood where employeeID = @employeeID", conn);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@Email", textBox9.Text);
                cmd.Parameters.AddWithValue("@E_Name", textBox1.Text);
                cmd.Parameters.AddWithValue("@ID", textBox2.Text);
                cmd.Parameters.AddWithValue("@JOINdate", textBox3.Text);
                cmd.Parameters.AddWithValue("@Dept", textBox4.Text);
                cmd.Parameters.AddWithValue("@Salary", textBox5.Text);
                cmd.Parameters.AddWithValue("@E_Address", textBox6.Text);
                cmd.Parameters.AddWithValue("@Phoneno", textBox7.Text);
                cmd.Parameters.AddWithValue("@Blood", textBox8.Text);
                cmd.Parameters.AddWithValue("@employeeID", this.employeeID);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("employee info updated successfully", "Updated!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetemployeesRecord();

                resetForm();
            }
            else
            {
                MessageBox.Show("Please select a employee first.", "Select?", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (employeeID > 0)
            {

                SqlCommand cmd = new SqlCommand("delete from EMPLOYEEINFO2 where employeeID = @employeeID", conn);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@employeeID", this.employeeID);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("employee is deleted from the database.", "Deleted!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetemployeesRecord();

                resetForm();


            }
            else
                MessageBox.Show("Please select a Employee first.", "Select?", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            employeeID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);

            textBox1.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            textBox6.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            textBox7.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
            textBox8.Text = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
            textBox9.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminPanel adminPanel = new AdminPanel();
            adminPanel.Show();
        }
    }
}
