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
    /// Interaction logic for reusable_Codes.xaml
    /// </summary>
    public partial class reusable_Codes : Window
    {
        public reusable_Codes()
        {
            InitializeComponent();
        }
        protected void Logout()
        {
            MessageBox.Show("Logging out...");
            this.Close();
            MainWindow loginWindow = new MainWindow();
            loginWindow.Show();
        }

        protected void GoBack()
        {
            MessageBox.Show("Going back to the previous page...");
            this.Close();
            admin_HomePage adminHomePage = new admin_HomePage();
            adminHomePage.Show();
        }
    }
}
