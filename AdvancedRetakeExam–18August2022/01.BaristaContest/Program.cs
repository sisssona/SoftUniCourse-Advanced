namespace _01.BaristaContest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> coffee = new(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> milk = new(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            int sum = 0;
            Dictionary<string, int> coffeeProduct = new Dictionary<string, int>();
            Dictionary<string, int> coffeeList = new Dictionary<string, int>()
            {
                {"Cortado", 50 },
                {"Espresso", 75 },
                {"Capuccino", 100 },
                {"Americano", 150 },
                {"Latte", 200 },
            };
            bool isMade = false;

            while (coffee.Any() && milk.Any())
            {
                isMade = false;
                sum = coffee.Peek() + milk.Peek();

                foreach (var coffeeDrink in coffeeList)
                {
                    if (sum == coffeeDrink.Value)
                    {
                        if (!coffeeProduct.ContainsKey(coffeeDrink.Key))
                        {
                            coffeeProduct.Add(coffeeDrink.Key, 1);
                        }
                        else
                        {
                            coffeeProduct[coffeeDrink.Key]++;
                        }
                        coffee.Dequeue();
                        milk.Pop();
                        isMade = true;
                        break;
                    }

                }

                if (!isMade)
                {
                    if (coffee.Any())
                    {
                        coffee.Dequeue();
                    }
                    if (milk.Any())
                    {
                        int newMilk = milk.Pop() - 5;
                        milk.Push(newMilk);
                    }
                }
            }
            //first line
            var firstLine = coffee.Count == 0 && milk.Count == 0
                ? "Nina is going to win! She used all the coffee and milk!"
                : "Nina needs to exercise more! She didn't use all the coffee and milk!";
            Console.WriteLine(firstLine);
            //second line
            var coffeeLeft = coffee.Count == 0 ? "none" : String.Join(", ", coffee);
            Console.WriteLine($"Coffee left: {coffeeLeft}");
            //third line
            var milkLeft = milk.Count == 0 ? "none" : String.Join(", ", milk);
            Console.WriteLine($"Milk left: {milkLeft}");

            //fourth line
            foreach (var drink in coffeeProduct.OrderBy(x => x.Value).ThenByDescending(x => x.Key))
            {
                Console.WriteLine($"{drink.Key}: {drink.Value}");
            }
        }
    }
}