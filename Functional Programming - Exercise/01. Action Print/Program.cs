namespace _01._Action_Print
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string[]> print = (string[] strings) =>
            {
                foreach (string s in strings)
                {
                    Console.WriteLine(string.Join(Environment.NewLine, s));
                }
            };
            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            print(names);
        }
    }
}