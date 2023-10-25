namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> fuel = new(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Queue<int> consumptionIndex = new(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Queue<int> necessaryAmountOfFuel = new(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            int subtract = 0;
            int count = 0;
            List<string> altitudes = new List<string>();

            while (fuel.Any() && consumptionIndex.Any() && necessaryAmountOfFuel.Any())
            {
                subtract = fuel.Peek() - consumptionIndex.Peek();

                if (subtract >= necessaryAmountOfFuel.Peek())
                {
                    fuel.Pop();
                    consumptionIndex.Dequeue();
                    necessaryAmountOfFuel.Dequeue();
                    count++;
                    altitudes.Add($"Altitude {count}");
                    Console.WriteLine($"John has reached: Altitude {count}");
                }
                else
                {
                    Console.WriteLine($"John did not reach: Altitude {count+1}");
                    break;
                }
            }
            if (count == 0)
            {
                Console.WriteLine("John failed to reach the top.");
                Console.WriteLine("John didn't reach any altitude.");
            }

           else if (fuel.Any())
            {
                Console.WriteLine("John failed to reach the top.");
                Console.Write($"Reached altitudes: {string.Join(", ", altitudes)}");
           
               
            }
            else
            {
                Console.WriteLine("John has reached all the altitudes and managed to reach the top!");
            }


        }
    }
}