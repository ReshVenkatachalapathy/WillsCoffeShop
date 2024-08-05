using System;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;


namespace WillsCoffeShop
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;
            string userType = (UserTypeComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(userType))
            {
                MessageBox.Show("Please enter all fields.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (ValidateCredentials(username, password, userType))
            {
                MessageBox.Show("Login successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                if (userType.ToLower() == "admin")
                {
                    admin_HomePage adHmePg = new admin_HomePage();
                    adHmePg.Show();
                }
                else
                {
                    employee_HomePage employeeHomePage = new employee_HomePage(username);
                    employeeHomePage.Show();
                }
                this.Close(); // Close the login window
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool ValidateCredentials(string username, string password, string userType)
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\User\\Documents\\employeeInfo.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False";
            string query = "SELECT COUNT(1) FROM Login_Details WHERE User_Name = @Username AND Password = @Password AND User_Type = @UserType";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);
                    command.Parameters.AddWithValue("@UserType", userType);

                    int result = Convert.ToInt32(command.ExecuteScalar());
                    return result == 1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Database connection error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            UsernameTextBox.Clear();
            PasswordBox.Clear();
            UserTypeComboBox.SelectedIndex = -1;
        }
    }
}
