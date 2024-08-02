using System;
using System.Threading.Tasks;
using System.Windows;

namespace WillsCoffeShop
{
    public partial class CustomMessageBox : Window
    {
        public CustomMessageBox(string message, int displayTimeInSeconds)
        {
            InitializeComponent(); 
            MessageTextBlock.Text = message;
            CloseAfterDelay(displayTimeInSeconds);
        }

        private async void CloseAfterDelay(int seconds)
        {
            await Task.Delay(seconds * 1000);
            this.Close();
        }
    }
}
