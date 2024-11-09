using Inventory_System.IRepository;
using Inventory_System.Model;
using System.Collections.Generic;
using System.Linq;

namespace Inventory_System.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly List<ProductsModel> _products = new();

        public void AddProduct(ProductsModel product)
        {
            _products.Add(product);
        }

        public bool UpdateStockQuantity(string name, int newStockQuantity)
        {
            var product = _products.FirstOrDefault(p => p.Name == name);
            if (product != null)
            {
                product.StockQuantity = newStockQuantity;
                return true;
            }
            return false;
        }

        public List<ProductsModel> GetProductsByCategory(string category)
        {
            return _products.Where(p => p.Category == category).ToList();
        }

        public double GetTotalInventoryValue()
        {
            return _products.Sum(p => p.GetTotalValue());
        }
    }
}
