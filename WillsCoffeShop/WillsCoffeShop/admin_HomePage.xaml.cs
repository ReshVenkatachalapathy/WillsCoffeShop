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
            admin_EmployeeDetails adEmpDetails = new admin_EmployeeDetails();       
            adEmpDetails.Show();    
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Logout button clicked.");
            // Implement the logout functionality here
            // For example, close the AdminHomePage window and show the login window
            this.Close();
            MainWindow loginWindow = new MainWindow();
            loginWindow.Show();
        }
    }
}
