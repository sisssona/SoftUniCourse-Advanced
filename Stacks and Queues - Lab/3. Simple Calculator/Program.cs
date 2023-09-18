using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace _3._Simple_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            Stack<string> stack = new Stack<string>();

            for (int i = input.Length - 1; i >= 0; i--)
            {
                stack.Push(input[i]);
            }
            while (stack.Count >= 3)
            {
                int sum = 0;

                int number = int.Parse(stack.Pop());
                var operation = stack.Pop();
                int secondNum = int.Parse(stack.Pop());

                if (operation == "+")
                {
                    sum = number + secondNum;
                }
                else if (operation == "-")
                {
                    sum = number - secondNum;
                }
                stack.Push(sum.ToString());
            }
            Console.WriteLine(stack.Pop());

        }
    }
}



