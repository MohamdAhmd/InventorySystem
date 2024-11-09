using Inventory_System.Controller;
using Inventory_System.IRepository;
using Inventory_System.Repository;
using Inventory_System.Validator;
using Microsoft.Extensions.DependencyInjection;

namespace Inventory_System
{
    public class Program
    {
        public static void Main()
        {
            // Set up dependency injection
            var services = new ServiceCollection();
            services.AddSingleton<IProductRepository, ProductRepository>();
            services.AddSingleton<ProductsController>();

            var serviceProvider = services.BuildServiceProvider();
            var _productsController = serviceProvider.GetService<ProductsController>();
           
            while (true)
            {
                Console.WriteLine("\n---------------------------------");
                Console.WriteLine("--- Inventory Management System ---");
                Console.WriteLine("1. Add New Product");
                Console.WriteLine("2. Update Stock Quantity");
                Console.WriteLine("3. List Products by Category");
                Console.WriteLine("4. Display Total Inventory Value");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        _productsController.AddProduct();
                        break;
                    case "2":
                        _productsController.UpdateStockQuantity();
                        break;
                    case "3":
                        _productsController.ListProductsByCategory();
                        break;
                    case "4":
                        _productsController.DisplayTotalInventoryValue();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}
