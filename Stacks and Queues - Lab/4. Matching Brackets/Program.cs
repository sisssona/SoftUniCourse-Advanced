namespace _4._Matching_Brackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
           string expression = Console.ReadLine();
            Stack<int> openingBracket = new Stack<int>();
            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(') 
                {
                openingBracket.Push(i);
                }
                if (expression[i] == ')')
                {
                  int openingBracketsIndex = openingBracket.Pop();
                    Console.WriteLine(expression.Substring(openingBracketsIndex, i - openingBracketsIndex + 1));
                }
            }
        }
    }
}