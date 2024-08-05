using System;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace WillsCoffeShop
{
    public partial class admin_EmployeeDetails : Window
    {
        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\User\\Documents\\employeeInfo.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False";

        public admin_EmployeeDetails()
        {
            InitializeComponent();
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
            admin_HomePage adminHomePage = new admin_HomePage();
            adminHomePage.Show();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string ID = EmployeeIDTextBox.Text;
            string firstName = FirstNameTextBox.Text;
            string lastName = LastNameTextBox.Text;
            string contact = PhoneNumberTextBox.Text;
            string address = AddressesTextBox.Text;
            string email = EmailAddressTextBox.Text;
            DateTime? dob = DOBDatePicker.SelectedDate;
            DateTime? dateOfJoining = DateofJoining.SelectedDate;
            string salary = SalaryTextBox.Text;
            string gender = (GenderComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

            if (string.IsNullOrWhiteSpace(ID) || string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(contact) || string.IsNullOrWhiteSpace(email))
            {
                ShowCustomMessage("Please fill in all required fields.", 2000);
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO employeeTable (Employee_ID, Employee_FirstName, Employee_LastName, Address, Contact, Email_Address, Date_of_Birth, Salary, Gender, Date_of_Joining) " +
                               "VALUES (@ID, @FirstName, @LastName, @Address, @Contact, @Email, @DateOfBirth, @Salary, @Gender, @DateOfJoining)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", ID);
                command.Parameters.AddWithValue("@FirstName", firstName);
                command.Parameters.AddWithValue("@LastName", lastName);
                command.Parameters.AddWithValue("@Address", address);
                command.Parameters.AddWithValue("@Contact", contact);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@DateOfBirth", dob.HasValue ? (object)dob.Value : DBNull.Value);
                command.Parameters.AddWithValue("@Salary", salary);
                command.Parameters.AddWithValue("@Gender", gender);
                command.Parameters.AddWithValue("@DateOfJoining", dateOfJoining.HasValue ? (object)dateOfJoining.Value : DBNull.Value);

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
            string gender = (GenderComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            DateTime? dob = DOBDatePicker.SelectedDate;
            DateTime? dateOfJoining = DateofJoining.SelectedDate;
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
                string currentEmail = reader["Email_Address"].ToString();
                DateTime? currentDOB = reader["Date_of_Birth"] as DateTime?;
                DateTime? currentDateOfJoining = reader["Date_of_Joining"] as DateTime?;
                string currentSalary = reader["Salary"].ToString();
                reader.Close();

                // Build update query dynamically
                string query = "UPDATE employeeTable SET ";
                bool firstParamAdded = false;

                if (!string.IsNullOrEmpty(firstName))
                {
                    query += "Employee_FirstName = @FirstName";
                    firstParamAdded = true;
                }
                if (!string.IsNullOrEmpty(lastName))
                {
                    query += (firstParamAdded ? ", " : "") + "Employee_LastName = @LastName";
                    firstParamAdded = true;
                }
                if (!string.IsNullOrEmpty(address))
                {
                    query += (firstParamAdded ? ", " : "") + "Address = @Address";
                    firstParamAdded = true;
                }
                if (!string.IsNullOrEmpty(contact))
                {
                    query += (firstParamAdded ? ", " : "") + "Contact = @Contact";
                    firstParamAdded = true;
                }
                if (!string.IsNullOrEmpty(email))
                {
                    query += (firstParamAdded ? ", " : "") + "Email_Address = @Email";
                    firstParamAdded = true;
                }
                if (dob.HasValue)
                {
                    query += (firstParamAdded ? ", " : "") + "Date_of_Birth = @DateOfBirth";
                    firstParamAdded = true;
                }
                if (dateOfJoining.HasValue)
                {
                    query += (firstParamAdded ? ", " : "") + "Date_of_Joining = @DateOfJoining";
                    firstParamAdded = true;
                }
                if (!string.IsNullOrEmpty(salary))
                {
                    query += (firstParamAdded ? ", " : "") + "Salary = @Salary";
                    firstParamAdded = true;
                }
                if (!string.IsNullOrEmpty(gender))
                {
                    query += (firstParamAdded ? ", " : "") + "Gender = @Gender";
                }

                query += " WHERE Employee_ID = @EmployeeId";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@EmployeeId", employeeId);
                if (!string.IsNullOrEmpty(firstName)) command.Parameters.AddWithValue("@FirstName", firstName);
                if (!string.IsNullOrEmpty(lastName)) command.Parameters.AddWithValue("@LastName", lastName);
                if (!string.IsNullOrEmpty(address)) command.Parameters.AddWithValue("@Address", address);
                if (!string.IsNullOrEmpty(contact)) command.Parameters.AddWithValue("@Contact", contact);
                if (!string.IsNullOrEmpty(email)) command.Parameters.AddWithValue("@Email", email);
                if (dob.HasValue) command.Parameters.AddWithValue("@DateOfBirth", dob.Value);
                if (dateOfJoining.HasValue) command.Parameters.AddWithValue("@DateOfJoining", dateOfJoining.Value);
                if (!string.IsNullOrEmpty(salary)) command.Parameters.AddWithValue("@Salary", salary);
                if (!string.IsNullOrEmpty(gender)) command.Parameters.AddWithValue("@Gender", gender);

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

        private void GenderComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
