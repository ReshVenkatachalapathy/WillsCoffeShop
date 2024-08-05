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
    /// <summary>
    /// Interaction logic for employee_HelpTicket.xaml
    /// </summary>
    public partial class employee_HelpTicket : Window
    {
        private string _employeeId;
        private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\User\\Documents\\employeeInfo.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False";

        public employee_HelpTicket(string employeeId)
        {
            InitializeComponent();
            _employeeId = employeeId;
            EmpIDLabel.Content = _employeeId;
        }

        public employee_HelpTicket()
        {
        }

        private void SubmitTicketButton_Click(object sender, RoutedEventArgs e)
        {
            string reason = ReasonTextBox.Text;
            string description = DescriptionTextBox.Text;
            string date = DatePicker.SelectedDate.HasValue ? DatePicker.SelectedDate.Value.ToString("yyyy-MM-dd") : string.Empty;
            string ticketUrgency = UrgencyComboBox.SelectedItem != null ? (UrgencyComboBox.SelectedItem as ComboBoxItem).Content.ToString() : string.Empty;
            string status = "New"; // Assuming default status is "New"

            string query = "INSERT INTO empTickets (Employee_Id, Description, Reason, Date, Ticket_Imp, Status) " +
                           "VALUES (@EmployeeId, @Description, @Reason, @Date, @TicketImp, @Status)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@EmployeeId", _employeeId);
                    command.Parameters.AddWithValue("@Description", description);
                    command.Parameters.AddWithValue("@Reason", reason);
                    command.Parameters.AddWithValue("@Date", date);
                    command.Parameters.AddWithValue("@TicketImp", ticketUrgency);
                    command.Parameters.AddWithValue("@Status", status);

                    command.ExecuteNonQuery();
                    MessageBox.Show("Ticket submitted successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Database connection error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            // Navigate back to the previous page, if needed
          
            employee_ViewPayroll viewPayroll = new employee_ViewPayroll(_employeeId); // Modify as necessary
            viewPayroll.Show();
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow loginWindow = new MainWindow();
            loginWindow.Show();
        }
    }
}