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

    public partial class admin_ProductDetails : Window
    {
        public admin_ProductDetails()
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
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\User\\Documents\\employeeInfo.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False";
            string query = "INSERT INTO ProductTable (Item_ID, Item_Name, Item_Description, Item_Price) VALUES (@ItemID, @ItemName, @ItemDescription, @ItemPrice)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ItemID", ItemIdTextBox.Text);
                    command.Parameters.AddWithValue("@ItemName", ItemNameTextBox.Text);
                    command.Parameters.AddWithValue("@ItemDescription", ItemDescriptionTextBox.Text);
                    command.Parameters.AddWithValue("@ItemPrice", ItemPriceTextBox.Text);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Product added successfully.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}");
                    }
                }
            }

        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\User\\Documents\\employeeInfo.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False";

            string query = "UPDATE ProductTable SET Item_Name = @ItemName, Item_Description = @ItemDescription, Item_Price = @ItemPrice WHERE Item_ID = @ItemID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ItemID", ItemIdTextBox.Text);
                    command.Parameters.AddWithValue("@ItemName", ItemNameTextBox.Text);
                    command.Parameters.AddWithValue("@ItemDescription", ItemDescriptionTextBox.Text);
                    command.Parameters.AddWithValue("@ItemPrice", ItemPriceTextBox.Text);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Product updated successfully.");
                        }
                        else
                        {
                            MessageBox.Show("Product not found.");
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
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\User\\Documents\\employeeInfo.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False";
            string query = "DELETE FROM ProductTable WHERE Item_ID = @ItemID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ItemID", ItemIdTextBox.Text);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Product deleted successfully.");
                        }
                        else
                        {
                            MessageBox.Show("Product not found.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}");
                    }
                }
            }

        }

        private void ItemIdTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
