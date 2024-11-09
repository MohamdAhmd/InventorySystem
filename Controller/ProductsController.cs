using Inventory_System.IRepository;
using Inventory_System.Model;
using Inventory_System.Repository;
using Inventory_System.Validator;

namespace Inventory_System.Controller
{
    public class ProductsController
    {
        private readonly IProductRepository _productRepository;
        InputValidator _inputValidator = new InputValidator();

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void AddProduct()
        {
            string name, category;
            double price;
            int stockQuantity;

            name = _inputValidator.ValidateStringInput("\nEnter product name: ", 5);
            category = _inputValidator.ValidateStringInput("Enter product category: ", 5);
            price = _inputValidator.ValidatedoubleInput("Enter product price: ",  0);
            stockQuantity = _inputValidator.ValidateIntInput("Enter stock quantity: ", 0);

            var product = new ProductsModel(name, category, price, stockQuantity);
            _productRepository.AddProduct(product);
            Console.WriteLine("Product added successfully.");
        }

        public void UpdateStockQuantity()
        {
            var name = _inputValidator.ValidateStringInput("Enter product name: ", 5);
            var newStockQuantity = _inputValidator.ValidateIntInput("Enter new stock quantity: ", 0);

            bool success = _productRepository.UpdateStockQuantity(name, newStockQuantity);
            Console.WriteLine(success ? "Stock quantity updated successfully." : "Product not found.");
        }

        public void ListProductsByCategory()
        {
            var category = _inputValidator.ValidateStringInput("Enter category to list products: ",5);
            var products = _productRepository.GetProductsByCategory(category);

            if (products.Any())
            {
                Console.WriteLine($"\nProducts in category '{category}':");
                foreach (var product in products)
                {
                    Console.WriteLine($"Name: {product.Name}, Price: {product.Price:C}, Stock: {product.StockQuantity}");
                }
            }
            else
            {
                Console.WriteLine("No products found in this category.");
            }
        }

        public void DisplayTotalInventoryValue()
        {
            double totalValue = _productRepository.GetTotalInventoryValue();
            Console.WriteLine($"\nTotal Inventory Value: {totalValue:C}");
        }
    }
}
