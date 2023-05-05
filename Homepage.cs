using System.ComponentModel;
using System.Runtime.InteropServices;

namespace HOTELMANAGEMENTSYSTEM
{
    public partial class Homepage : Form
    {

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(

           int nLeft,
           int nTop,
           int nRight,
           int nbutton,
           int nWidthEllipse,
           int nHeightEllipse

           );
        public Homepage()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            kitchenlogin kitchenlogin = new kitchenlogin();
            kitchenlogin.Show();
        }

        private void Homepage_Load(object sender, EventArgs e)
        {
            button1.Region = Region.FromHrgn(CreateRoundRectRgn
               (0, 0, button1.Width, button1.Height, 30, 30));
            button2.Region = Region.FromHrgn(CreateRoundRectRgn
                   (0, 0, button2.Width, button2.Height, 30, 30));
            button3.Region = Region.FromHrgn(CreateRoundRectRgn
                  (0, 0, button3.Width, button3.Height, 30, 30));
            button4.Region = Region.FromHrgn(CreateRoundRectRgn
                  (0, 0, button4.Width, button4.Height, 30, 30));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Reservationlogin reservationlogin = new Reservationlogin();
            reservationlogin.ShowDialog();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            About about = new About();
            about.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            adminlogin admin_login = new adminlogin();
            admin_login.Show();
        }
    }
}