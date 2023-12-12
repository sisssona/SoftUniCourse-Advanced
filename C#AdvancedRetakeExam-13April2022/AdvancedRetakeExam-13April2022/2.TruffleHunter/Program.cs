using System;
using System.Drawing;
using System.Linq;

namespace _2.TruffleHunter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];
            int blackTruffleCount = 0;
            int whiteTruffleCount = 0;
            int summerTruffleCount = 0;
            int trufflesCount = 0;

            for (int rows = 0; rows < n; rows++)
            {
                char[] newRows = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();
                for (int cols = 0; cols < n; cols++)
                {
                    matrix[rows, cols] = newRows[cols];

                }
            }
            string input;
            int row = 0;
            int col = 0;
            while ((input = Console.ReadLine()) != "Stop the hunt")
            {
                string[] command = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (command[0] == "Collect")
                {
                    row = int.Parse(command[1]);
                    col = int.Parse(command[2]);
                    if (matrix[row, col] == 'B')
                    {
                        blackTruffleCount++;
                        matrix[row, col] = '-';
                    }
                    else if (matrix[row, col] == 'W')
                    {
                        whiteTruffleCount++;
                        matrix[row, col] = '-';
                    }
                    else if (matrix[row, col] == 'S')
                    {
                        summerTruffleCount++;
                        matrix[row, col] = '-';
                    }
                }
                if (command[0] == "Wild_Boar")
                {
                    row = int.Parse(command[1]);
                    col = int.Parse(command[2]);
                    string direction = command[3];
                    if (direction == "up")
                    {
                        while (row >= 0)
                        {
                            if (matrix[row, col] == 'S' || matrix[row, col] == 'W' || matrix[row, col] == 'B')
                            {
                                matrix[row, col] = '-';
                                trufflesCount++;
                            }
                            else
                            {
                                break; 
                            }
                            row -= 2;
                        }
                    }
                    if (direction == "down")
                    {
                        while (row < matrix.GetLength(0))
                        {
                            if (matrix[row, col] == 'S' || matrix[row, col] == 'W' || matrix[row, col] == 'B')
                            {
                                matrix[row, col] = '-';
                                trufflesCount++;
                            }
                            else
                            {
                                break; 
                            }
                            row += 2;
                        }
                    }
                    if (direction == "left")
                    {
                        while (col >= 0)
                        {
                            if (matrix[row, col] == 'S' || matrix[row, col] == 'W' || matrix[row, col] == 'B')
                            {
                                matrix[row, col] = '-';
                                trufflesCount++;
                            }
                            else
                            {
                                break; 
                            }
                            col -= 2;
                        }
                    }
                    if (direction == "right")
                    {
                        while (col < matrix.GetLength(1))
                        {
                            if (matrix[row, col] == 'S' || matrix[row, col] == 'W' || matrix[row, col] == 'B')
                            {
                                matrix[row, col] = '-';
                                trufflesCount++;
                            }
                            else
                            {
                                break; 
                            }
                            col += 2;
                        }
                    }
                }
            }
            Console.WriteLine($"Peter manages to harvest {blackTruffleCount} black, {summerTruffleCount} summer, and {whiteTruffleCount} white truffles.");
            Console.WriteLine($"The wild boar has eaten {trufflesCount} truffles.");

            for (int rows = 0; rows < n; rows++)
            {
                for (int cols = 0; cols < n; cols++)
                {
                    Console.Write(matrix[rows, cols] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
