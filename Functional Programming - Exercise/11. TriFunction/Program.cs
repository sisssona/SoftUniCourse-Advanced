namespace _11._TriFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string, int, bool> checkEqualOrLargerSumName = (name, sum) =>
            // name.Sum(ch => ch) >= sum;
           {
               int charSum = name.Sum(ch => ch);
               return charSum >= sum;
           };
            //we give names, sum and function that returns if the given sum of chars is bigger or equal
            Func<string[], int, Func<string, int, bool>, string> getFirstName = (names, sum, match) => //names.FirstOrDefault(name => match(name, sum));
            {
                foreach (var name in names) 
                {
                    if (match(name,sum))
                    {
                        return name;
                    }
                }
                return default;
            };
           int sum = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string foundName = getFirstName(names, sum, checkEqualOrLargerSumName);
            Console.WriteLine(foundName);
        }

    }
}