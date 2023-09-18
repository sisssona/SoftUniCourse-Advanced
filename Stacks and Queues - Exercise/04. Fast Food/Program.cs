namespace _04._Fast_Food
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int foodQuantity = int.Parse(Console.ReadLine());
            int[] orders = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> foodOrders = new Queue<int>(orders);    // add it to the constructor
            Console.WriteLine(foodOrders.Max());

            while (foodOrders.Count > 0 && foodQuantity > 0)
            {
                int currentOrder = foodOrders.Peek();
                if (foodQuantity - currentOrder >= 0)
                {
                   foodQuantity -= foodOrders.Dequeue();
                }
                else
                {
                    break;
                }
            }
            if (foodOrders.Count == 0) 
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: {string.Join(" ", foodOrders)}");
            }
        }
    }
}