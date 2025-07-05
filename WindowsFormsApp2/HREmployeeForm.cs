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
    public partial class HREmployeeForm : Form
    {
        public CloseUserControl closeControl;

        public HREmployeeForm()
        {
            InitializeComponent();
            InitializeCloseControl();
        }
        private Timer colorTimer = new Timer();
        public void InitializeCloseControl()
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
                MySqlDataAdapter adapter = new MySqlDataAdapter("select * from employee;", connection);
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
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {
            HRDashboardForm form = new HRDashboardForm();
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

        private void HREmployeeForm_Load(object sender, EventArgs e)
        {
            LoadData();
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int empID;
            if (int.TryParse(textBox1.Text, out empID))
            {
                LoadEmployeeData(empID);
            }
            else
            {
                MessageBox.Show("Please enter a valid Employee ID.");
            }
           

            }
        private void LoadEmployeeData(int empID)
        {
            string connectionString = "server=localhost;database=mydb;uid=root;pwd=Hassnoo01;";
            string sql = "SELECT * FROM employee WHERE Emp_ID = @EmpID;";

            using (MySqlConnection cn = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@EmpID", empID);

                try
                {
                    cn.Open();
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(dr);

                        if (dt.Rows.Count > 0)
                        {
                            dataGridView1.DataSource = dt;
                        }
                        else
                        {
                            MessageBox.Show("Employee not found.");
                            dataGridView1.DataSource = null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DeleteEmployee form = new DeleteEmployee();
            form.Show();
        }

        private void EnableFormControls()
        {
            label4.Enabled = true;
            label3.Enabled = true;
            label13.Enabled = true;
            label12.Enabled = true;
            label11.Enabled = true;
            label10.Enabled = true;
            label9.Enabled = true;
            label1.Enabled = true;

        }

        private void DisableFormControls()
        {
            label1.Enabled = false;
            label4.Enabled = false;
            label3.Enabled = false;
            label13.Enabled = false;
            label12.Enabled = false;
            label11.Enabled = false;
            label10.Enabled = false;
            label9.Enabled = false;
          

        }


        private void CloseControl_OkayButtonClicked(object sender, EventArgs e)
        {
            EnableFormControls();
            closeControl.Visible = false;  // Hide the control
            this.BackColor = SystemColors.ControlLightLight;  // Revert back to original color
        }
        private void CloseBtnClick(object sender, EventArgs e)
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
    }
}
