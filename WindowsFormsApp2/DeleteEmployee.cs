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
    public partial class DeleteEmployee : Form
    {
        public DeleteEmployee()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int empID;
            if (int.TryParse(textBox1.Text, out empID))
            {
                DeleteEmployeeData(empID);
            }
            else
            {
                MessageBox.Show("Please enter a valid Employee ID.");
            }
        }
        private void DeleteEmployeeData(int empID)
        {
            string connectionString = "server=localhost;database=mydb;uid=root;pwd=Hassnoo01;";
            string sql = "DELETE FROM employee WHERE Emp_ID = @EmpID;";

            using (MySqlConnection cn = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@EmpID", empID);

                try
                {
                    cn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Employee record deleted successfully.");
                       // dataGridView.DataSource = null;
                    }
                    else
                    {
                        MessageBox.Show("Employee not found or could not be deleted.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
