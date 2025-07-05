using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp2
{
    public sealed class DatabaseConnection
    {
        private static readonly DatabaseConnection instance = new DatabaseConnection();
        private MySqlConnection connection;

        private string connectionString = "server=localhost; uid=root; pwd=Hassnoo01; database=mydb";

        private DatabaseConnection()
        {
            connection = new MySqlConnection(connectionString);
        }

        public static DatabaseConnection Instance
        {
            get
            {
                return instance;
            }
        }

        public MySqlConnection Connection
        {
            get
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }
                return connection;
            }
        }

        public void CloseConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }

    public class DatabaseHelper
    {
        public bool VerifyLogin(string username, string password, string role, out int userId)
        {
            bool isAuthenticated = false;
            userId = -1;

            string query = "SELECT id FROM Authentication WHERE username = @username AND password = @password AND role = @role";

            using (MySqlCommand cmd = new MySqlCommand(query, DatabaseConnection.Instance.Connection))
            {
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password); // Ensure password is hashed in actual implementation
                cmd.Parameters.AddWithValue("@role", role);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        isAuthenticated = true;
                        userId = reader.GetInt32("id");
                    }
                }
            }

            return isAuthenticated;
        }
    }

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm1());
        }
    }
}
