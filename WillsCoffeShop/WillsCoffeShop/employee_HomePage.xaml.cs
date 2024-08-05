using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace WillsCoffeShop
{
    public partial class employee_HomePage : Window
    {
        private string _username;
        private string _name;
        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\User\\Documents\\employeeInfo.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False";

        public employee_HomePage(string username)
        {
            InitializeComponent();
            _username = username;
            _name = GetUserNameFromDB(_username);

            UserLoggedinName.Content = $"Welcome User, {_name}";
            UsernameLabel.Content = $"Logged in as, {_username}";
        }

        private string GetUserNameFromDB(string username)
        {
            string name = string.Empty;
            string query = "SELECT Name FROM Login_Details WHERE User_Name = @Username";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Username", username);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        name = reader["Name"].ToString();
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Database connection error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            return name;
        }

        private void ViewPayrollButton_Click(object sender, RoutedEventArgs e)
        {
            employee_ViewPayroll employee_ViewPayroll = new employee_ViewPayroll(_username);
            employee_ViewPayroll.Show();
            this.Close();
        }

        private void ViewProfileButton_Click(object sender, RoutedEventArgs e)
        {
            employee_ProfileDetails employee_ProfileDetails = new employee_ProfileDetails(_username);
            employee_ProfileDetails.Show();
            this.Close();
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow loginWindow = new MainWindow();
            loginWindow.Show();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            // Implement navigation logic for back button if needed
        }
    }
}
