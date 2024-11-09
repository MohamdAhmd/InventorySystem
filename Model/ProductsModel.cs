namespace Inventory_System.Model
{
    public class ProductsModel
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public int StockQuantity { get; set; }

        public ProductsModel(string name, string category, double price, int stockQuantity)
        {
            Name = name;
            Category = category;
            Price = price;
            StockQuantity = stockQuantity;
        }

        public double GetTotalValue() => Price * StockQuantity;
    }
}
