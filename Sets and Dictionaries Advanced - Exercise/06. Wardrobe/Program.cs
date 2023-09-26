namespace _06._Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> colorClothes = new();
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                string[] tokens = Console.ReadLine().Split(new string[] { " -> ", "," }, StringSplitOptions.RemoveEmptyEntries);
                string color = tokens[0];
                if (!colorClothes.ContainsKey(color))
                {
                    colorClothes.Add(color, new Dictionary<string, int>());
                }
                for (int j = 1; j < tokens.Length; j++)
                {
                    string currWear = tokens[j];
                    if (!colorClothes[color].ContainsKey(currWear))
                    {
                        colorClothes[color].Add(currWear, 0);
                    }
                    colorClothes[color][currWear]++;
                }
            }
            string[] findParams = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            foreach (var colorCloth in colorClothes)
            {
                Console.WriteLine($"{colorCloth.Key} clothes:");
                foreach (var wearCount in colorCloth.Value)
                {
                    string color = findParams[0];
                    string wear = findParams[1];    
                    string printItem = $"* {wearCount.Key} - {wearCount.Value}";
                    if (colorCloth.Key == color && wearCount.Key == wear)
                    {
                        printItem += " (found!)";
                    }
                    Console.WriteLine(printItem);
                }
            }
        }
    }
}