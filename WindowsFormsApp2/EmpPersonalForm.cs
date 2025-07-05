using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp2
{
    public partial class EmpPersonalForm : Form
    {
        private LogoutUserControl logoutControl;
        private Timer colorTimer = new Timer();

        public EmpPersonalForm()
        {
            InitializeComponent();
            InitializeLogoutControl();
        }

        private void InitializeLogoutControl()
        {
            logoutControl = new LogoutUserControl();
            logoutControl.Size = new Size(450, 150);  // Set appropriate size
            logoutControl.Visible = false;  // Initially hidden

            logoutControl.Anchor = AnchorStyles.None;
            CenterLogoutControl();
            this.Controls.Add(logoutControl);
            this.Resize += (s, e) => CenterLogoutControl();

            logoutControl.LogoutConfirmed += LogoutConfirmed;
            logoutControl.LogoutCancelled += LogoutCancelled;
        }

        private void CenterLogoutControl()
        {
            if (logoutControl != null)
            {
                logoutControl.Location = new Point((this.ClientSize.Width - logoutControl.Width) / 2, (this.ClientSize.Height - logoutControl.Height) / 2);
            }
        }

        private void LogoutConfirmed(object sender, EventArgs e)
        {
            LoginForm1 loginForm = new LoginForm1();
            this.Hide();
            loginForm.Show();

            EnableFormControls();
        }

        private void LogoutCancelled(object sender, EventArgs e)
        {
            logoutControl.Visible = false;
            this.BackColor = SystemColors.ControlLightLight;
            colorTimer.Stop();

            EnableFormControls();
        }

        private void EnableFormControls()
        {
            label1.Enabled = true;
            label2.Enabled = true;
            label3.Enabled = true;
            label4.Enabled = true;
            label5.Enabled = true;
            label6.Enabled = true;
            label8.Enabled = true;
         
        }

        private void DisableFormControls()
        {
            label1.Enabled = false;
            label2.Enabled = false;
            label3.Enabled = false;
            label4.Enabled = false;
            label5.Enabled = false;
            label6.Enabled = false;
            label8.Enabled = false;
          
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DisableFormControls();
            this.BackColor = Color.LightGray;  // Dim background color

            logoutControl.Visible = true;
            logoutControl.BringToFront();

            colorTimer.Interval = 250;  // Duration for the temporary color change
            colorTimer.Tick += (timerSender, timerEventArgs) =>
            {
                this.BackColor = SystemColors.ControlLightLight;  // Revert back to original color
                colorTimer.Stop();
            };
            colorTimer.Start();
        }

        private void label8_Click(object sender, EventArgs e)
        {
        }

        private void label14_Click(object sender, EventArgs e)
        {
        }
                private string connectionString = "server=localhost;database=mydb;uid=root;pwd=Hassnoo01;";

        private void Form8_Load(object sender, EventArgs e)
        {
            //int employeeId = employee.Emp_Id;

            // Connection string to your MySQL database
            string connectionString = "server=localhost;database=mydb;uid=root;pwd=Hassnoo01;";

            // SQL query to fetch data for the specific employee
            string sql = "SELECT * FROM employee";

            using (MySqlConnection cn = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand(sql, cn);
              //  cmd.Parameters.AddWithValue("@EmpId", employeeId);

                try
                {
                    cn.Open();
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            label37.Text = dr["Emp_name"].ToString();
                            label35.Text = dr["Emp_ID"].ToString();
                            label34.Text = dr["Emp_Fname"].ToString();
                            label33.Text = dr["Emp_CNIC"].ToString();
                            label32.Text = Convert.ToDateTime(dr["Emp_DOB"]).ToString("yyyy-MM-dd");
                            label31.Text = dr["Emp_Gender"].ToString();
                            label30.Text = dr["Emp_Phone"].ToString();
                            label29.Text = dr["Emp_Address"].ToString();
                            label27.Text = dr["Emp_Designation"].ToString();
                            label24.Text = dr["Emp_Position"].ToString();
                            label7.Text = dr["dept_id"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("No data found for the specified employee ID.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            EmpDashboardForm form = new EmpDashboardForm();
            this.Hide();
            form.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            EmpProjForm form = new EmpProjForm();
            this.Hide();
            form.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            EmpTeamForm form = new EmpTeamForm();
            this.Hide();
            form.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            EmpSprintForm form = new EmpSprintForm();
            this.Hide();
            form.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            EmpAttendanceForm form = new EmpAttendanceForm();
            this.Hide();
            form.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            EmpEquipmentsForm form = new EmpEquipmentsForm();
            this.Hide();
            form.Show();
        }
    }
}
