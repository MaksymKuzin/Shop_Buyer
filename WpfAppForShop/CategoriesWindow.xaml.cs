using System.IO;
using System.Windows;
using BussinesLogic.Concrete;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;

namespace ShopWPF
{
    public partial class CategoriesWindow : Window
    {
        private readonly CategoryManager _categoryManager;

        public CategoriesWindow()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connectionString = configuration.GetConnectionString("Shop") ?? "";
        }

        private void LoadCategories()
        {
            var categories = _categoryManager.GetAllCategories();
            CategoriesGrid.ItemsSource = categories;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            // Повернення на головне вікно
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
