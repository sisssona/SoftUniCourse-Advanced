namespace _01._Count_Same_Values_in_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<double> values = Console.ReadLine()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                        .Select(double.Parse)
                        .ToList();
            Dictionary<double, int> countValues = new Dictionary<double, int>();
       
            foreach (var value in values)
            {
                if (!countValues.ContainsKey(value))
                {
                    countValues.Add(value, 1);
                }
                else
                {
                    countValues[value]++;
                }
            }
            foreach (var item in countValues)
            {
                Console.WriteLine($"{item.Key} - {item.Value} times");
            }
        }
    }
}