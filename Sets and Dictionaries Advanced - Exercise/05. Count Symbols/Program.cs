namespace _05._Count_Symbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
           string text = Console.ReadLine();

            Dictionary<char, int> keyValuePairs= new Dictionary<char, int>();

            foreach (char element in text)
            {
                if (!keyValuePairs.ContainsKey(element))
                {
                    keyValuePairs.Add(element, 0);
                }
                keyValuePairs[element]++;
            }
            foreach (var item in keyValuePairs.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}