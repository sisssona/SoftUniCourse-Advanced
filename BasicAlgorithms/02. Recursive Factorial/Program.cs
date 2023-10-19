namespace _02._Recursive_Factorial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(NFactorial(int.Parse(Console.ReadLine())));

            long NFactorial(int n)
            {
                if (n == 1) return 1;
                return n * NFactorial(n - 1);
            }
        }

    }
}