namespace _2._Stack_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < input.Length; i++)
            {
                stack.Push(input[i]);
            }
            string commands;
            while ((commands = Console.ReadLine().ToLower()) != "end")
            {
                string[] commandInfo = commands.Split();
                string token = commandInfo[0].ToLower();
                if (token == "add")
                {
                    var number1 = int.Parse(commandInfo[1]);
                    var number2 = int.Parse(commandInfo[2]);
                    stack.Push(number1);
                    stack.Push(number2);
                }
                else if (token == "remove")
                {
                    var countRemoved = int.Parse(commandInfo[1]);
                    if (countRemoved <= stack.Count)
                    {
                        for (int i = 0; i < countRemoved; i++)
                        {
                            stack.Pop();
                        }
                    }
                }
            }
            var sum = stack.Sum();

            Console.WriteLine($"Sum: {sum}");
            

        }
    }
}