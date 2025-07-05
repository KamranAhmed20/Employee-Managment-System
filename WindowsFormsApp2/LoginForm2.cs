using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApp2
{
    public partial class LoginForm2 : Form
    {
        public LoginForm2()
        {
            InitializeComponent();
            InitializeTextBoxEvents();
        }

        private Timer colorTimer = new Timer();

        private bool AuthenticateHR(string username, string password)
        {
            DatabaseHelper dbHelper = new DatabaseHelper();
            int userId;

            return dbHelper.VerifyLogin(username, password, "HR", out userId);
        }


        private void Label4_Click(object sender, EventArgs e)
        {
            // Open the Employee login form
            LoginForm1 form = new LoginForm1();
            this.Hide();
            form.Show();
        }


        private void button4_Click(object sender, EventArgs e)
        {
            string username = HRLoginTxt.Text;
            string password = HRPassTxt.Text;

            // Authenticate HR login
            if (AuthenticateHR(username, password))
            {

                HRDashboardForm form = new HRDashboardForm();
                this.Hide();
                form.Show();
            }
            else
            {

                this.BackColor = Color.DarkRed;
                colorTimer.Interval = 250; // The duration is set to 0.25 second

                colorTimer.Tick += (timerSender, timerEventArgs) =>
                {
                    this.BackColor = SystemColors.Control; // Reverting to the original color
                    colorTimer.Stop(); // Stop the timer after the color is reverted
                };

                colorTimer.Start();

                MessageBox.Show("Invalid HR Login Credentials. Please try again.");
            }
        }

        private void InitializeTextBoxEvents()
        {
            HRLoginTxt.Enter += TextBox_Enter;
            HRPassTxt.Enter += TextBox_Enter;

            HRLoginTxt.Leave += TextBox_Leave;
            HRPassTxt.Leave += TextBox_Leave;

            HRLoginTxt.Text = "Username";
            HRPassTxt.Text = "Password";
            HRPassTxt.UseSystemPasswordChar = false;
        }

        private void TextBox_Enter(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (textBox != null)
            {
                if (textBox == HRLoginTxt && textBox.Text == "Username")
                {
                    textBox.Text = "";
                }

                if (textBox == HRPassTxt && textBox.Text == "Password")
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
                if (textBox == HRLoginTxt && string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = "Username";
                }

                if (textBox == HRPassTxt && string.IsNullOrWhiteSpace(textBox.Text))
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
