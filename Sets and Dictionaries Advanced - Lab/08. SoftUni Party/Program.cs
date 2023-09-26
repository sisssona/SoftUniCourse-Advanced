namespace _08._SoftUni_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> peopleWhoCame = new HashSet<string>();
            HashSet<string> all = new HashSet<string>();
            string input;
            while ((input = Console.ReadLine()) != "PARTY") 
            {
            all.Add(input);
            }
            while ((input = Console.ReadLine()) != "END")
            {
                peopleWhoCame.Add(input);
                all.Remove(input);
            }
            Console.WriteLine(all.Count);
            foreach (var peopleWhoDidntCome in all.OrderByDescending(x => char.IsDigit(x[0])))
            {
                Console.WriteLine(peopleWhoDidntCome);
            }
        }
    }
}