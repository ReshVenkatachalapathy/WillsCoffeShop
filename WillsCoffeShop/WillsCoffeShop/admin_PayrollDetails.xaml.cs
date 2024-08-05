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

    public partial class admin_PayrollDetails : Window
    {



        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\User\\Documents\\employeeInfo.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False";

        public admin_PayrollDetails()
        {
            InitializeComponent();
        }
        private void ShowCustomMessageBox(string message, int displayTimeInSeconds)
        {
            CustomMessageBox customMessageBox = new CustomMessageBox(message, displayTimeInSeconds);
            customMessageBox.Owner = this; 
            customMessageBox.Show();
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


        private void EmployeeIdTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void SalaryTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void PaymentPeriodTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void TotalHoursWorkedTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string query = "INSERT INTO PayrollTable (Employee_ID, [Employee_Name], Salary, [Total_Hours],[Payment_Period_From], [Payment_Period_To]) VALUES (@EmployeeID, @Name, @Salary, @TotalHoursWorked, @PaymentPeriodFrom, @PaymentPeriodTo)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeID", EmployeeIdTextBox.Text);
                    command.Parameters.AddWithValue("@Name", NameTextBox.Text);
                    command.Parameters.AddWithValue("@PaymentPeriodFrom", PaymentPeriodFromDatePicker.SelectedDate);
                    command.Parameters.AddWithValue("@PaymentPeriodTo", PaymentPeriodToDatePicker.SelectedDate);
                    command.Parameters.AddWithValue("@Salary", SalaryTextBox.Text);
                    command.Parameters.AddWithValue("@TotalHoursWorked", TotalHoursWorkedTextBox.Text);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Payroll details added successfully.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}");
                    }
                }
            }

        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            string query = "UPDATE PayrollTable SET Employee_Name = @Name, Salary = @Salary, Total_Hours = @TotalHoursWorked,Payment_Period_From = @PaymentPeriodFrom, Payment_Period_To = @PaymentPeriodTo WHERE Employee_ID = @EmployeeID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeID", EmployeeIdTextBox.Text);
                    command.Parameters.AddWithValue("@Name", NameTextBox.Text);
                    command.Parameters.AddWithValue("@PaymentPeriodFrom", PaymentPeriodFromDatePicker.SelectedDate);
                    command.Parameters.AddWithValue("@PaymentPeriodTo", PaymentPeriodToDatePicker.SelectedDate);
                    command.Parameters.AddWithValue("@Salary", SalaryTextBox.Text);
                    command.Parameters.AddWithValue("@TotalHoursWorked", TotalHoursWorkedTextBox.Text);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Payroll details updated successfully."); // 3 seconds
                        }
                        else
                        {
                            MessageBox.Show("Employee not found.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}");
                    }
                }
            }

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            string query = "DELETE FROM PayrollTable WHERE Employee_ID = @EmployeeID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeID", EmployeeIdTextBox.Text);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            ShowCustomMessageBox("Payroll details deleted successfully.", 3); // 3 seconds
                        }
                        else
                        {
                            ShowCustomMessageBox("Employee not found.", 5); // 5 seconds
                        }
                    }
                    catch (Exception ex)
                    {
                        ShowCustomMessageBox($"Error: {ex.Message}", 5); // 5 seconds
                    }
                }
            }

        }


    }

}
