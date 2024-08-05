using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WillsCoffeShop
{
    public partial class admin_TicketPage : Window
    {
        private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\User\\Documents\\employeeInfo.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False";
        public ObservableCollection<HelpTicket> Tickets { get; set; }

        public admin_TicketPage()
        {
            InitializeComponent();
            DataContext = this;
            LoadTickets();
        }

        public ICommand EditCommand => new RelayCommand<HelpTicket>(EditTicket);
        public ICommand DeleteCommand => new RelayCommand<HelpTicket>(DeleteTicket);
        public ICommand SaveCommand => new RelayCommand(SaveChanges);

        private void LoadTickets()
        {
            Tickets = new ObservableCollection<HelpTicket>();

            string query = "SELECT * FROM empTickets";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Tickets.Add(new HelpTicket
                        {
                            Employee_Id = reader["Employee_Id"] as int?,
                            Description = reader["Description"] as string,
                            Reason = reader["Reason"] as string,
                            Date = reader["Date"] as string,
                            Ticket_Imp = reader["Ticket_Imp"] as string,
                            Status = reader["Status"] as string
                        });
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Database connection error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            TicketsDataGrid.ItemsSource = Tickets;
        }

        private void EditTicket(HelpTicket ticket)
        {
            var row = (DataGridRow)TicketsDataGrid.ItemContainerGenerator.ContainerFromItem(ticket);
            if (row != null)
            {
                TicketsDataGrid.BeginEdit();
            }
        }

        private void DeleteTicket(HelpTicket ticket)
        {
            MessageBoxResult result = MessageBox.Show($"Are you sure you want to delete the ticket for Employee ID: {ticket.Employee_Id}?", "Delete Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                string query = "DELETE FROM empTickets WHERE Employee_Id = @Employee_Id AND Date = @Date";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Employee_Id", ticket.Employee_Id);
                    command.Parameters.AddWithValue("@Date", ticket.Date);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Tickets.Remove(ticket);
                            MessageBox.Show("Ticket deleted successfully.", "Deleted", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else
                        {
                            MessageBox.Show("No ticket found to delete.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Database connection error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }


        private void SaveChanges()
        {
            foreach (var ticket in Tickets)
            {
                // Ensure Employee_Id and Date are not null
                if (ticket.Employee_Id == null || ticket.Date == null)
                    continue;

                // Retrieve updated values from the DataGrid
                var row = (DataGridRow)TicketsDataGrid.ItemContainerGenerator.ContainerFromItem(ticket);
                if (row != null)
                {
                    var descriptionCell = TicketsDataGrid.Columns[1].GetCellContent(row) as TextBox;
                    var reasonCell = TicketsDataGrid.Columns[2].GetCellContent(row) as TextBox;
                    var ticketImpCell = TicketsDataGrid.Columns[3].GetCellContent(row) as TextBox;
                    var statusCell = TicketsDataGrid.Columns[4].GetCellContent(row) as TextBox;

                    // Update ticket properties with the new values
                    if (descriptionCell != null)
                        ticket.Description = descriptionCell.Text;

                    if (reasonCell != null)
                        ticket.Reason = reasonCell.Text;

                    if (ticketImpCell != null)
                        ticket.Ticket_Imp = ticketImpCell.Text;

                    if (statusCell != null)
                        ticket.Status = statusCell.Text;
                }

                // Update the database with the new values
                string query = "UPDATE empTickets SET Description = @Description, Reason = @Reason, Ticket_Imp = @Ticket_Imp, Status = @Status WHERE Employee_Id = @Employee_Id AND Date = @Date";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Description", ticket.Description);
                    command.Parameters.AddWithValue("@Reason", ticket.Reason);
                    command.Parameters.AddWithValue("@Ticket_Imp", ticket.Ticket_Imp);
                    command.Parameters.AddWithValue("@Status", ticket.Status);
                    command.Parameters.AddWithValue("@Employee_Id", ticket.Employee_Id);
                    command.Parameters.AddWithValue("@Date", ticket.Date);
                    MessageBox.Show(ticket.Description + ticket.Reason + ticket.Ticket_Imp + ticket.Status + ticket.Employee_Id + ticket.Date);
                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected == 0)
                        {
                            MessageBox.Show($"No ticket found to update for Employee ID: {ticket.Employee_Id}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Database connection error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            MessageBox.Show("Tickets updated successfully.", "Updated", MessageBoxButton.OK, MessageBoxImage.Information);
        }


        public class HelpTicket
        {
            public int? Employee_Id { get; set; }
            public string Description { get; set; }
            public string Reason { get; set; }
            public string Date { get; set; }
            public string Ticket_Imp { get; set; }
            public string Status { get; set; }
        }

        public class RelayCommand<T> : ICommand
        {
            private readonly Action<T> _execute;
            private readonly Predicate<T> _canExecute;

            public RelayCommand(Action<T> execute, Predicate<T> canExecute = null)
            {
                _execute = execute ?? throw new ArgumentNullException(nameof(execute));
                _canExecute = canExecute;
            }

            public bool CanExecute(object parameter)
            {
                return _canExecute == null || _canExecute((T)parameter);
            }

            public void Execute(object parameter)
            {
                _execute((T)parameter);
            }

            public event EventHandler CanExecuteChanged
            {
                add { CommandManager.RequerySuggested += value; }
                remove { CommandManager.RequerySuggested -= value; }
            }
        }

        public class RelayCommand : ICommand
        {
            private readonly Action _execute;
            private readonly Func<bool> _canExecute;

            public RelayCommand(Action execute, Func<bool> canExecute = null)
            {
                _execute = execute ?? throw new ArgumentNullException(nameof(execute));
                _canExecute = canExecute;
            }

            public bool CanExecute(object parameter)
            {
                return _canExecute == null || _canExecute();
            }

            public void Execute(object parameter)
            {
                _execute();
            }

            public event EventHandler CanExecuteChanged
            {
                add { CommandManager.RequerySuggested += value; }
                remove { CommandManager.RequerySuggested -= value; }
            }
        }
    }
}
