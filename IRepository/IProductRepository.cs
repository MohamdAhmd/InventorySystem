using Inventory_System.Model;
using System.Collections.Generic;

namespace Inventory_System.IRepository
{
    public interface IProductRepository
    {
        void AddProduct(ProductsModel product);
        bool UpdateStockQuantity(string productName, int quantity);
        List<ProductsModel> GetProductsByCategory(string category);
        double GetTotalInventoryValue();
    }
}
