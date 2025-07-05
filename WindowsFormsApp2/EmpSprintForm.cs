using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class EmpSprintForm : Form
    {
        private CloseUserControl closeControl;
        public EmpSprintForm()
        {
            InitializeComponent();
            InitializeCloseControl();
        }
        private Timer colorTimer = new Timer();
        private void InitializeCloseControl()
        {
            closeControl = new CloseUserControl();
            closeControl.Size = new Size(400, 100);  // Set appropriate size
            closeControl.Visible = false;  // Initially hidden

            closeControl.Anchor = AnchorStyles.None;
            closeControl.OkayButtonClicked += CloseControl_OkayButtonClicked; // Subscribe to the event
            CenterCloseControl();
            this.Controls.Add(closeControl);
            this.Resize += (s, e) => CenterCloseControl();
        }

        private void CenterCloseControl()
        {
            if (closeControl != null)
            {
                closeControl.Location = new Point((this.ClientSize.Width - closeControl.Width) / 2, (this.ClientSize.Height - closeControl.Height) / 2);
            }
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------------------

        private string connectionString = "server=localhost;database=mydb;uid=root;pwd=Hassnoo01;";
        private void LoadData()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter("select * from sprint;", connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    column.MinimumWidth = 80;  // Set the minimum width for columns
                }

                //Row height to fill the DataGridView
                int totalRowHeight = dataGridView1.ClientSize.Height - dataGridView1.ColumnHeadersHeight;
                int rowCount = dataTable.Rows.Count > 0 ? dataTable.Rows.Count : 1;
                int rowHeight = totalRowHeight / rowCount;

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.Height = rowHeight;
                }

                // Center text in cells
                dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                //Row header width
                dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            }
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------------------

        private void label1_Click(object sender, EventArgs e)
        {
            EmpDashboardForm form = new EmpDashboardForm();
            this.Close();
            form.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            EmpProjForm form = new EmpProjForm();
            this.Close();
            form.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            EmpTeamForm form = new EmpTeamForm();
            this.Close();
            form.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            EmpAttendanceForm form = new EmpAttendanceForm();
            this.Close();
            form.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            EmpEquipmentsForm form = new EmpEquipmentsForm();
            this.Close();
            form.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            EmpPersonalForm form = new EmpPersonalForm();
            this.Hide();
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void EnableFormControls()
        {
            label1.Enabled = true;
            label2.Enabled = true;
            label3.Enabled = true;
            label4.Enabled = true;
            label5.Enabled = true;
            label6.Enabled = true;

        }

        private void DisableFormControls()
        {
            label1.Enabled = false;
            label2.Enabled = false;
            label3.Enabled = false;
            label4.Enabled = false;
            label5.Enabled = false;
            label6.Enabled = false;

        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            DisableFormControls();
            this.BackColor = Color.LightGray;  // Dim background color

            closeControl.Visible = true;
            closeControl.BringToFront();

            colorTimer.Interval = 250;  // Duration for the temporary color change
            colorTimer.Tick += (timerSender, timerEventArgs) =>
            {
                this.BackColor = SystemColors.ControlLightLight;  // Revert back to original color
                colorTimer.Stop();
            };
            colorTimer.Start();
        }

        private void CloseControl_OkayButtonClicked(object sender, EventArgs e)
        {
            EnableFormControls();
            closeControl.Visible = false;  // Hide the control
            this.BackColor = SystemColors.ControlLightLight;  // Revert back to original color
        }

        private void EmpSprintForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

      

     
       
    }
}
