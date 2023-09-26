using System.Numerics;

namespace _3._Maximal_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] rowsAndCols = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int rows = rowsAndCols[0];
            int cols = rowsAndCols[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row <= rows - 1; row++)
            {
                int[] elements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col <= cols - 1; col++)
                {
                    matrix[row, col] = elements[col];
                }
            }
            //find maximal sum of its elements 3x3

            int maxSum = 0;
            int startRow = 0;
            int startCol = 0;
            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    int sum = 0;
                    for (int i = row; i < row + 3; i++)
                    {
                        for (int j = col; j < col + 3; j++)
                        {
                            sum += matrix[i, j];
                        }
                    }
                    if (maxSum < sum)
                    {
                        maxSum = sum;
                        startRow = row;
                        startCol = col;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");
            for (int row = startRow; row < startRow + 3; row++)
            {
                for (int col = startCol; col < startCol + 3; col++)
                {
                    Console.Write(matrix[row,col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}