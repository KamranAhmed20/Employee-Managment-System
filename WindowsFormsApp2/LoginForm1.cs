using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApp2
{
    public partial class LoginForm1 : Form
    {
        public LoginForm1 instance;
        public  string hassan;
        public LoginForm1()
        {
            instance = this;
            InitializeComponent();
            InitializeTextBoxEvents();
        }

        private Timer colorTimer = new Timer();

        private bool AuthenticateEmployee(string username, string password)
        {
            DatabaseHelper dbHelper = new DatabaseHelper();
            int userId;

            return dbHelper.VerifyLogin(username, password, "Employee", out userId);
        }

        private void Label4_Click(object sender, EventArgs e)
        {
            // Open the HR login form
            LoginForm2 form = new LoginForm2();
            this.Hide();
            form.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {

        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string username = EmpLoginTxt.Text;
            string password = EmpPassTxt.Text;

            // Authenticate employee login
            if (AuthenticateEmployee(username, password))
            {

                EmpDashboardForm empDashboard = new EmpDashboardForm();
                this.Hide();
                empDashboard.Show();

            }
            else
            {
                this.BackColor = Color.DarkRed;
                colorTimer.Interval = 250; //The duration is set to 0.25 second

                colorTimer.Tick += (timerSender, timerEventArgs) =>
                {
                    this.BackColor = SystemColors.Control; // Reverting to the original color
                    colorTimer.Stop();
                };

                colorTimer.Start();

                MessageBox.Show("Invalid Employee Login Credentials. Please try again.");
            }
        }

        private void InitializeTextBoxEvents()
        {
            EmpLoginTxt.Enter += TextBox_Enter;
            EmpPassTxt.Enter += TextBox_Enter;

            EmpLoginTxt.Leave += TextBox_Leave;
            EmpPassTxt.Leave += TextBox_Leave;

            EmpLoginTxt.Text = "Username";
            EmpPassTxt.Text = "Password";
            EmpPassTxt.UseSystemPasswordChar = false;
        }

        private void TextBox_Enter(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (textBox != null)
            {
                if (textBox == EmpLoginTxt && textBox.Text == "Username")
                {
                    textBox.Text = "";
                }

                if (textBox == EmpPassTxt && textBox.Text == "Password")
                {
                    textBox.Text = "";
                    textBox.UseSystemPasswordChar = true;
                }
            }
        }

        private void TextBox_Leave(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (textBox != null)
            {
                if (textBox == EmpLoginTxt && string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = "Username";
                }

                if (textBox == EmpPassTxt && string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = "Password";
                    textBox.UseSystemPasswordChar = false;
                }
            }
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
