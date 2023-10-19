namespace SumOfCoins
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<int> coins = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            int sum = int.Parse(Console.ReadLine());

            ChooseCoins(coins, sum);
        }

        public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
        {
            coins = coins.OrderByDescending(x => x).ToList();

            Dictionary<int, int> takenCoins = new Dictionary<int, int>();
            int takenCoinsCount = 0;
            int currentSum = 0;
            while (currentSum != targetSum)
            {
                bool coinTaken = false;
                for (int i = 0; i < coins.Count; i++)
                {
                    if (currentSum + coins[i] <= targetSum)
                    {
                        if (!takenCoins.ContainsKey(coins[i]))
                        {
                            takenCoins.Add(coins[i], 0);
                        }
                        takenCoinsCount++;
                        takenCoins[coins[i]]++;
                        currentSum += coins[i];
                        coinTaken = true;
                        break;
                    }
                }
                if (!coinTaken)
                {
                    throw new InvalidOperationException();
                }
            }
            Console.WriteLine($"Number of coins to take: {takenCoinsCount}");
            foreach (var item in takenCoins)
            {
                Console.WriteLine($"{item.Value} coin(s) with value {item.Key}");
            }
            return takenCoins;
        }
    }
}