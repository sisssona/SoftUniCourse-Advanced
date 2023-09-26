using System.Drawing;

namespace _2._Squares_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = dimensions[0]; //брой на редове
            int cols = dimensions[1]; // брой на колони

            char[,] matrix = new char[rows, cols];
            for (int row = 0; row <= rows - 1; row++) //всички редове от първия до последния
            {
                char[] symbol = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                for (int col = 0; col <= cols - 1; col++)
                {
                    matrix[row, col] = symbol[col];
                }
            }
            //брой на матриците 2х2
            int count = 0; //брой на матрици
            for (int row = 0; row < rows-1; row++)
            {
                for (int col = 0; col < cols-1; col++)
                {
                    int element = matrix[row, col];
                    //дали съвпада с този в дясно
                    bool isEqualRight = element == matrix[row, col+1];
                    //дали съвпада с този отдолу
                    bool isEqualToDown = element == matrix[row+1, col];   
                    //дали съвпада с този по диагонал
                    bool isEqualDiagonal = element == matrix[row + 1, col+1];
                    if (isEqualRight && isEqualToDown && isEqualDiagonal)
                    {
                        count++;
                    }
                }
            }
            Console.WriteLine(count);
        }
    }
}