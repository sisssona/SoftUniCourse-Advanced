namespace _02._Sets_of_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> firstSet = new();
            HashSet<int> second = new();
            int[] count = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            for (int i = 0; i < count[0]; i++)
            {
                firstSet.Add(int.Parse(Console.ReadLine()));
            }
            for (int i = 0; i < count[1]; i++)
            {
                second.Add(int.Parse(Console.ReadLine()));
            }
            firstSet.IntersectWith(second);
            Console.WriteLine(string.Join(" ", firstSet));
        }
    }
}