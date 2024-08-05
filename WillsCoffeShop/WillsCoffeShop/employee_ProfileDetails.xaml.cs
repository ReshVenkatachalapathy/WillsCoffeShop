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
  
    public partial class employee_ProfileDetails : Window
    {


        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\User\\Documents\\employeeInfo.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False";
        private string _username;
        public employee_ProfileDetails(string username)
        {
            InitializeComponent();
            _username = username;
            UsernameLabel.Content = $"Logged in as: {_username}";
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            string firstName = FirstNameTextBox.Text;
            string lastName = LastNameTextBox.Text;
            string phoneNumber = PhoneNumberTextBox.Text;
            string address = AddressTextBox.Text;
            string email = EmailAddressTextBox.Text;
            string gender = (GenderComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            DateTime? dob = DOBDatePicker.SelectedDate;

            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) || string.IsNullOrWhiteSpace(email))
            {
                ShowCustomMessage("Please fill in all required fields.", 2000);
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE employeeTable SET Employee_FirstName = @FirstName, Employee_LastName = @LastName, Contact = @Contact, Address = @Address, " +
                               "Email_Address = @Email, Gender = @Gender, Date_of_Birth = @DateOfBirth " +
                               "WHERE Employee_ID = @EmployeeId";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@EmployeeId", "YourEmployeeId"); // Replace with the actual employee ID
                command.Parameters.AddWithValue("@FirstName", firstName);
                command.Parameters.AddWithValue("@LastName", lastName);
                command.Parameters.AddWithValue("@Contact", phoneNumber);
                command.Parameters.AddWithValue("@Address", address);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Gender", gender);
                command.Parameters.AddWithValue("@DateOfBirth", dob.HasValue ? (object)dob.Value : DBNull.Value);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    ShowCustomMessage("Employee profile updated successfully.", 2000);
                }
                catch (Exception ex)
                {
                    ShowCustomMessage($"Error: {ex.Message}", 4000);
                }
            }
        }

        private void ShowCustomMessage(string message, int duration)
        {
            CustomMessageBox messageBox = new CustomMessageBox(message, duration);
            messageBox.Show();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
