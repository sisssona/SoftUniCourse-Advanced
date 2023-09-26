namespace _01._Unique_Usernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> usernames = new();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string username = Console.ReadLine();
                usernames.Add(username);
            }
            foreach (string username in usernames)
            {
                Console.WriteLine(username);
            }
        }
    }
}