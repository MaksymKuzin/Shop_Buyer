using System.Windows;

namespace ShopWPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Обробник для переходу на сторінку категорій
        private void ViewCategories_Click(object sender, RoutedEventArgs e)
        {
            // Відкриваємо вікно з категоріями
            CategoriesWindow categoriesWindow = new CategoriesWindow();
            categoriesWindow.Show();
            this.Close(); // Закриваємо основне вікно
        }

        // Обробник для переходу на сторінку продуктів
        private void ViewProducts_Click(object sender, RoutedEventArgs e)
        {
            // Відкриваємо вікно з продуктами
            ProductsWindow productsWindow = new ProductsWindow();
            productsWindow.Show();
            this.Close(); // Закриваємо основне вікно
        }

        // Обробник для переходу на сторінку кошика
        private void ViewCart_Click(object sender, RoutedEventArgs e)
        {
            // Відкриваємо вікно кошика
            CartWindow cartWindow = new CartWindow();
            cartWindow.Show();
            this.Close(); // Закриваємо основне вікно
        }
    }
}
