using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using DAL.Interface;
using DAL.Concrete;
using DTO;
using BussinesLogic.Concrete;
using BussinesLogic.Interface;

IConfiguration configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

string connectionString = configuration.GetConnectionString("Shop") ?? "";

var productManager = new ProductManager(new ProductDal(connectionString));
var categoryManager = new CategoryManager(new CategoryDal(connectionString));
var cartItemManager = new CartItemManager(new CartItemDal(connectionString));

while (true)
{
    Console.Clear();
    Console.WriteLine("1. Select a category");
    Console.WriteLine("2. Search for a product");
    Console.WriteLine("3. View cart");
    Console.WriteLine("4. Exit");
    Console.Write("Choose an option: ");
    var choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            var categories = categoryManager.GetCategories();
            Console.WriteLine("Categories:");
            foreach (var category in categories)
            {
                Console.WriteLine($"{category.CategoryId}. {category.Name}");
            }

            Console.Write("Select a category ID to view products: ");
            if (int.TryParse(Console.ReadLine(), out int categoryId))
            {
                var products = productManager.GetProductsByCategory(categoryId);
                Console.WriteLine($"Products in category {categoryId}:");
                foreach (var product in products)
                {
                    Console.WriteLine($"ID: {product.ProductId}, Name: {product.Name}, Price: {product.Price}");
                }

                Console.Write("Enter product ID to add to cart: ");
                if (int.TryParse(Console.ReadLine(), out int productId))
                {
                    var cartItem = new CartItemDto { ProductId = productId, Quantity = 1, UserId = 1 }; 
                    cartItemManager.AddToCart(cartItem);
                    Console.WriteLine("Product added to cart.");
                }
            }
            Console.ReadLine();
            break;

        case "2":
            Console.Write("Enter product name to search: ");
            var productName = Console.ReadLine();
            var searchResults = productManager.SearchProductsByName(productName);
            Console.WriteLine("Search results:");
            foreach (var product in searchResults)
            {
                Console.WriteLine($"ID: {product.ProductId}, Name: {product.Name}, Price: {product.Price}");
            }
            Console.ReadLine();
            break;

        case "3":
            var userId = 1;
            var cartItems = cartItemManager.GetCartItemsByUserId(userId);
            Console.WriteLine("Your cart:");
            foreach (var item in cartItems)
            {
                Console.WriteLine($"ID: {item.CartItemId}, Product ID: {item.ProductId}, Quantity: {item.Quantity}");
            }
            Console.ReadLine();
            break;

        case "4":
            Environment.Exit(0);
            break;

        default:
            Console.WriteLine("Invalid option. Please try again.");
            Console.ReadLine();
            break;
    }
}

