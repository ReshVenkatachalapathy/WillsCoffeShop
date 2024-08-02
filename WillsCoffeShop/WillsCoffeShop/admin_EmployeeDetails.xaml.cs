using System;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace WillsCoffeShop
{
    public partial class EmployeeDetails : Window
    {
        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\User\\Documents\\employeeInfo.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False";

        public EmployeeDetails()
        {
            InitializeComponent();
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Logging out...");
            this.Close();
            MainWindow loginWindow = new MainWindow();
            loginWindow.Show();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Going back to the previous page...");
            this.Close();
            admin_HomePage adminHomePage = new admin_HomePage();
            adminHomePage.Show();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string firstName = FirstNameTextBox.Text;
            string lastName = LastNameTextBox.Text;
            string contact = PhoneNumberTextBox.Text;
            string address = AddressesTextBox.Text;
            string email = EmailAddressTextBox.Text;
            string country = (GenderComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            DateTime? dob = DOBDatePicker.SelectedDate;
            DateTime? dateOfJoining = DateofJoining.SelectedDate;
            string salary = SalaryTextBox.Text;

            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(contact) || string.IsNullOrWhiteSpace(email))
            {
                ShowCustomMessage("Please fill in all required fields.", 2000);
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO employeeTable (Employee_FirstName, Employee_LastName, Address, Contact, Email_address, Date_Of_Birth, Country, Salary) " +
                               "VALUES (@FirstName, @LastName, @Address, @Contact, @Email, @DateOfBirth, @Country, @Salary)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@FirstName", firstName);
                command.Parameters.AddWithValue("@LastName", lastName);
                command.Parameters.AddWithValue("@Address", address);
                command.Parameters.AddWithValue("@Contact", contact);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@DateOfBirth", dob.HasValue ? (object)dob.Value : DBNull.Value);
                command.Parameters.AddWithValue("@Country", country);
                command.Parameters.AddWithValue("@Salary", salary);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    ShowCustomMessage("Employee added successfully.", 2000);
                }
                catch (Exception ex)
                {
                    ShowCustomMessage($"Error: {ex.Message}", 4000);
                }
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            string employeeId = EmployeeIDTextBox.Text;
            string firstName = FirstNameTextBox.Text;
            string lastName = LastNameTextBox.Text;
            string contact = PhoneNumberTextBox.Text;
            string address = AddressesTextBox.Text;
            string email = EmailAddressTextBox.Text;
            string country = (GenderComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            DateTime? dob = DOBDatePicker.SelectedDate;
            string salary = SalaryTextBox.Text;

            if (string.IsNullOrWhiteSpace(employeeId))
            {
                ShowCustomMessage("Please fill in employee ID and other required fields to update.", 2000);
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Fetch current values
                string selectQuery = "SELECT * FROM employeeTable WHERE Employee_ID = @EmployeeId";
                SqlCommand selectCommand = new SqlCommand(selectQuery, connection);
                selectCommand.Parameters.AddWithValue("@EmployeeId", employeeId);

                SqlDataReader reader = selectCommand.ExecuteReader();
                if (!reader.HasRows)
                {
                    ShowCustomMessage("No employee found with the specified ID.", 2000);
                    return;
                }

                reader.Read();
                string currentFirstName = reader["Employee_FirstName"].ToString();
                string currentLastName = reader["Employee_LastName"].ToString();
                string currentContact = reader["Contact"].ToString();
                string currentAddress = reader["Address"].ToString();
                string currentEmail = reader["Email_address"].ToString();
                string currentCountry = reader["Country"].ToString();
                DateTime? currentDOB = reader["Date_Of_Birth"] as DateTime?;
                string currentSalary = reader["Salary"].ToString();
                reader.Close();

                // Update query with only modified values
                string query = "UPDATE employeeTable SET " +
                               "Employee_FirstName = @FirstName, " +
                               "Employee_LastName = @LastName, " +
                               "Address = @Address, " +
                               "Contact = @Contact, " +
                               "Email_address = @Email, " +
                               "Date_Of_Birth = @DateOfBirth, " +
                               "Country = @Country, " +
                               "Salary = @Salary " +
                               "WHERE Employee_ID = @EmployeeId";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@EmployeeId", employeeId);
                command.Parameters.AddWithValue("@FirstName", string.IsNullOrEmpty(firstName) ? (object)DBNull.Value : firstName);
                command.Parameters.AddWithValue("@LastName", string.IsNullOrEmpty(lastName) ? (object)DBNull.Value : lastName);
                command.Parameters.AddWithValue("@Address", string.IsNullOrEmpty(address) ? (object)DBNull.Value : address);
                command.Parameters.AddWithValue("@Contact", string.IsNullOrEmpty(contact) ? (object)DBNull.Value : contact);
                command.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(email) ? (object)DBNull.Value : email);
                command.Parameters.AddWithValue("@DateOfBirth", dob.HasValue ? (object)dob.Value : (object)DBNull.Value);
                command.Parameters.AddWithValue("@Country", string.IsNullOrEmpty(country) ? (object)DBNull.Value : country);
                command.Parameters.AddWithValue("@Salary", string.IsNullOrEmpty(salary) ? (object)DBNull.Value : salary);

                try
                {
                    command.ExecuteNonQuery();
                    ShowCustomMessage("Employee updated successfully.", 2000);
                }
                catch (Exception ex)
                {
                    ShowCustomMessage($"Error: {ex.Message}", 4000);
                }
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            string employeeId = EmployeeIDTextBox.Text;

            if (string.IsNullOrWhiteSpace(employeeId))
            {
                ShowCustomMessage("Please enter an Employee ID.", 2000);
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM employeeTable WHERE Employee_ID = @EmployeeId";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@EmployeeId", employeeId);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        ShowCustomMessage("Employee deleted successfully.", 2000);
                    }
                    else
                    {
                        ShowCustomMessage("No employee found with the specified ID.", 2000);
                    }
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
    }
}
