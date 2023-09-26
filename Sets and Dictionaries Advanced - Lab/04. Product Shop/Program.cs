namespace _04._Product_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string, double>> shops = new();

            string command = "";

            while ((command = Console.ReadLine()) != "Revision")
            {
                string[] tokens = command.Split(", ",StringSplitOptions.RemoveEmptyEntries);
                string shop = tokens[0];
                string product = tokens[1];
                double price = double.Parse(tokens[2]);
                if (!shops.ContainsKey(shop))
                {
                    shops.Add(shop, new Dictionary<string, double>());
                    shops[shop].Add(product, price);
                }
                else 
                {
                    shops[shop].Add(product, price);
                }
            }
            foreach (var shop in shops)
            {
                Console.WriteLine($"{shop.Key}->");
                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}