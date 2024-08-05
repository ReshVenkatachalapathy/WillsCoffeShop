using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
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

    public partial class employee_ProfileInformation : Window
    {
        private string _id;
        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\User\\Documents\\employeeInfo.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False";
        private string _username;

        public employee_ProfileInformation(string username)
        {
            InitializeComponent();
            _username = username;
            UsernameLabel.Content = $"Logged in as: {_username}";

            _id = GetUserIDFromDB(_username);
            MessageBox.Show(_id);
            LoadEmployeeDetails();
        }
        private string GetUserIDFromDB(string username)
        {
            string id = string.Empty;
            string query = "SELECT Employee_ID FROM Login_Details WHERE User_Name = @Username";

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
                        id = reader["Employee_ID"].ToString();
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Database connection error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            return id;
        }

        private void LoadEmployeeDetails()
        {
            string query = "SELECT Employee_ID, Employee_FirstName, Employee_LastName, Contact, Address, Email_Address, Gender, Date_of_Birth, Date_Of_Joining, Salary FROM employeeTable WHERE Employee_ID = @id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", _id);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        EmployeeIDLabel.Content = reader["Employee_ID"].ToString();
                        FirstNameLabel.Content = reader["Employee_FirstName"].ToString();
                        LastNameLabel.Content = reader["Employee_LastName"].ToString();
                        PhoneNumberLabel.Content = reader["Contact"].ToString();
                        AddressLabel.Content = reader["Address"].ToString();
                        EmailAddressLabel.Content = reader["Email_Address"].ToString();
                        GenderLabel.Content = reader["Gender"].ToString();
                        DOBLabel.Content = reader["Date_of_Birth"].ToString();
                        DateOfJoiningLabel.Content = reader["Date_Of_Joining"].ToString();
                        SalaryLabel.Content = reader["Salary"].ToString();
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Database connection error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow loginWindow = new MainWindow();
            loginWindow.Show();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            employee_HomePage empHmPg = new employee_HomePage(_username);
            empHmPg.Show();
        }




        private void ShowCustomMessage(string message, int duration)
        {
            CustomMessageBox messageBox = new CustomMessageBox(message, duration);
            messageBox.Show();
        }
    }
}
