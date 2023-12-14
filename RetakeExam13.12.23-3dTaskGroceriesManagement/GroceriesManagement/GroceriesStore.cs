using System.Text;

namespace GroceriesManagement
{
    public class GroceriesStore
    {
        public GroceriesStore(int capacity)
        {
            Capacity = capacity;
            Turnover = 0;
            Stall = new List<Product>();
        }

        public int Capacity { get; private set; }
        public double Turnover { get; private set; }
        public List<Product> Stall { get; private set; }
        public int Count => Stall.Count;

        public void AddProduct(Product product)
        {
            if (!Stall.Any(p => p.Name == product.Name))
            {
                if (Count < Capacity)
                {
                    Stall.Add(product);
                }
            }
        }
        public bool RemoveProduct(string name)
        {
            var productToRemove = Stall.FirstOrDefault(p => p.Name == name);
            if (productToRemove == null)
            {
                return false;
            }
            Stall.Remove(productToRemove);
            return true;
        }
        public string SellProduct(string name, double quantity)
        {
            Product product = Stall.FirstOrDefault(p => p.Name == name);
            if (product != null)
            {
                double productsPrice = product.Price * quantity;
                Turnover += productsPrice;
                return $"{product.Name} - {productsPrice:F2}$.";
            }
            else
            {
                return "Product not found";
            }
        }
        public string GetMostExpensive()
        {
            Product productMostExpensive = Stall.OrderByDescending(p => p.Price).First();
            return productMostExpensive.ToString();
        }
        public string CashReport()
        {
            return $"Total Turnover: {Turnover:F2}$";
        }
        public string PriceList()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Groceries Price List:");
            foreach (Product product in Stall)
            {
                sb.AppendLine(product.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}
