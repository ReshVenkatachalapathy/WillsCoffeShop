using System;
using System.Data.SqlClient;
using System.Windows;

namespace WillsCoffeShop
{
    public partial class employee_ViewPayroll : Window
    {
        private string _username;
        private string _id;
        private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\User\\Documents\\employeeInfo.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False";

        public employee_ViewPayroll(string username)
        {
            InitializeComponent();
            _username = username;
            UsernameLabel.Content = $"Logged in as: {_username}";

            _id = GetUserIDFromDB(_username);
            LoadPayrollDetails();
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

        private void LoadPayrollDetails()
        {
            string query = "SELECT Employee_Id, Salary, Total_Hours, Payment_Period_From, Payment_Period_To FROM PayrollTable WHERE Employee_Id = @id";

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
                        EmpIDLabel.Content = reader["Employee_Id"].ToString();
                        AmtPaidLabel.Content = reader["Salary"].ToString();
                        HrsWorkedLabel.Content = reader["Total_Hours"].ToString();
                        PayPeriodFromLabel.Content = reader["Payment_Period_From"].ToString();
                        PayPeriodToLabel.Content = reader["Payment_Period_To"].ToString();

                       
                    }
                    else
                    {
                        // Clear fields if no data is found
                        EmpIDLabel.Content = "";
                        AmtPaidLabel.Content = "";
                        HrsWorkedLabel.Content = "";
                        PayPeriodFromLabel.Content = "";
                        PayPeriodToLabel.Content = "";
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Database connection error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void RaiseTicketButton_Click(object sender, RoutedEventArgs e)
        {
            employee_HelpTicket employee_HelpTicket = new employee_HelpTicket(_id);
            employee_HelpTicket.Show();
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

        private void CheckPayroll_Click(object sender, RoutedEventArgs e)
        {
            if (PaymentPeriodDatePicker.SelectedDate.HasValue)
            {
                DateTime selectedDate = PaymentPeriodDatePicker.SelectedDate.Value;
                string query = "SELECT Salary, Total_Hours FROM PayrollTable WHERE Employee_Id = @id AND Payment_Period_From <= @selectedDate AND Payment_Period_To >= @selectedDate";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id", _id);
                    command.Parameters.AddWithValue("@selectedDate", selectedDate);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            AmtPaidLabel.Content = reader["Salary"].ToString();
                            HrsWorkedLabel.Content = reader["Total_Hours"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("No payroll details found for the selected date.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                            EmpIDLabel.Content = "";
                            AmtPaidLabel.Content = "";
                            HrsWorkedLabel.Content = "";
                            PayPeriodFromLabel.Content = "";
                            PayPeriodToLabel.Content = "";
                        }
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Database connection error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a payment period date.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
