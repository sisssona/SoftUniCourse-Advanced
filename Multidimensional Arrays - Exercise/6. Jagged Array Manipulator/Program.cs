using System;

namespace _6._Jagged_Array_Manipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfRows = int.Parse(Console.ReadLine());
            double[][] matrix = new double[numberOfRows][];
            double element = 0;
            double[] rows = new double[numberOfRows];
            //add elements to the jaggedArray
            for (int row = 0; row < numberOfRows; row++)
            {
                rows = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
                for (int col = 0; col < rows.Length; col++)
                {
                    matrix[row] = rows;
                }
            }
            //compare the current row with the row below and write numbersOfRows not to be out of range
            for (int row = 0; row < numberOfRows - 1; row++)
            {
                if (matrix[row].Length == matrix[row + 1].Length)
                {
                    matrix[row] = matrix[row].Select(x => x * 2).ToArray();
                    matrix[row + 1] = matrix[row + 1].Select(x => x * 2).ToArray();
                }
                else if (matrix[row].Length != matrix[row + 1].Length)
                {
                    matrix[row] = matrix[row].Select(x => x / 2).ToArray();
                    matrix[row + 1] = matrix[row + 1].Select(x => x / 2).ToArray();
                }

            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input.ToLower() == "end")
                {
                    break;
                }
                string[] commands = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                // if there is not enough command value we do not enter in the ckecks
                if (commands.Length != 4)
                {
                    continue;
                }
                string command = commands[0];

                int row = int.Parse(commands[1]);
                int col = int.Parse(commands[2]);
                double value = double.Parse(commands[3]);
                if (command.ToLower() == "add")
                {

                    //check if the current indexes are not regular and continue to the next command
                    if (row < 0 || row >= matrix.Length || col < 0 || col >= matrix[row].Length)
                    {
                        continue;
                    }
                    matrix[row][col] += value;
                }
                else if (command.ToLower() == "subtract")
                {
                    if (row < 0 || row >= matrix.Length || col < 0 || col >= matrix[row].Length)
                    {
                        continue;
                    }
                    matrix[row][col] -= value;
                }

            }
            //print
            foreach (var row in matrix)
            {
                Console.Write(string.Join(" ", row));
                Console.WriteLine();
            }


        }
    }
}