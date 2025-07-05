using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class HRDashboardForm : Form
    {
        private LogoutUserControl logoutControl;
        private Timer colorTimer = new Timer();

        public HRDashboardForm()
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
             label9.Enabled = true;
            label10.Enabled = true;
            label11.Enabled = true;
            label12.Enabled = true;
            label13.Enabled = true;
            label14.Enabled = true;
            pictureBox4.Enabled = true;
        }

        private void DisableFormControls()
        {
            label1.Enabled = false;
            label2.Enabled = false;
            label3.Enabled = false;
            label4.Enabled = false;
            label9.Enabled = false;
            label10.Enabled = false;
            label11.Enabled = false;
            label12.Enabled = false;
            label13.Enabled = false;
            label14.Enabled = false;
            pictureBox4.Enabled = false;
        }

        private void LogoutBtnClick(object sender, EventArgs e)
        {
            DisableFormControls();
            this.BackColor = Color.LightGray;  // Dim background color

            logoutControl.Visible = true;
            logoutControl.BringToFront();  // Bring the logout control to the front

            colorTimer.Interval = 250;  // Duration for the temporary color change
            colorTimer.Tick += (timerSender, timerEventArgs) =>
            {
                this.BackColor = SystemColors.ControlLightLight;  // Revert back to original color
                colorTimer.Stop();
            };
            colorTimer.Start();
        }

        
        private void label13_Click(object sender, EventArgs e)
        {
            
        }

        private void label12_Click(object sender, EventArgs e)
        {
            HREmployeeForm form = new HREmployeeForm();
            this.Close();
            form.Show();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            HRTeamsForm form = new HRTeamsForm();
            this.Close();
            form.Show();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            HRProjectForm form = new HRProjectForm();
            this.Close();
            form.Show();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            HRAttendForm form = new HRAttendForm();
            this.Close();
            form.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            HRIssued_equip form = new HRIssued_equip();
            this.Close();
            form.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            HRDeptform form = new HRDeptform();
            this.Close();
            form.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            HRIssues form = new HRIssues();
            this.Close();
            form.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
           
        }

        private void label14_Click(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {
        
        }
    }
}
