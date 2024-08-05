using System;
using System.Collections.Generic;
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
    /// Interaction logic for admin_HomePage.xaml
    /// </summary>
    public partial class admin_HomePage : Window
    {
        public admin_HomePage()
        {
            InitializeComponent();
        }

        private void ProductDetailsButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Product Details button clicked.");
            admin_ProductDetails adProdDetails = new admin_ProductDetails();    
            adProdDetails.Show();   
        }

        private void ReportDetailsButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Report Details button clicked.");
            admin_PayrollDetails adPayDetails = new admin_PayrollDetails(); 
            adPayDetails.Show();    
        }

        private void EmployeeDetailsButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Employee Details button clicked.");
            admin_EmployeeDetails adEmployeeDetails = new admin_EmployeeDetails();
            adEmployeeDetails.Show();    
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Logout button clicked.");
            this.Close();
            MainWindow loginWindow = new MainWindow();
            loginWindow.Show();
        }

        private void TicketButton_Click(object sender, RoutedEventArgs e)
        {
            admin_TicketPage admin_TicketPage = new admin_TicketPage();
            admin_TicketPage.Show();    
        }
    }
}
