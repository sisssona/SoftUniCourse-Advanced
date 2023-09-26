namespace _4._Symbol_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int rows = n;
            int cols = n;
            int[,] matrix = new int[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                string rowsSymbols = Console.ReadLine();
                for (int col = 0; col < cols; col++)
                {
                    char currSymbol = rowsSymbols[col];
                    matrix[row, col] = currSymbol;
                }
            }
            bool isFound = false;
            char symbol = char.Parse(Console.ReadLine());
            int symbolInteger = symbol;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row, col] == symbol)
                    {
                        Console.WriteLine($"{(row, col)}");
                        isFound = true;
                        return;
                    }

                }

            }

            if (isFound == false)
            {
                Console.WriteLine($"{symbol} does not occur in the matrix");
            }


        }
    }
}