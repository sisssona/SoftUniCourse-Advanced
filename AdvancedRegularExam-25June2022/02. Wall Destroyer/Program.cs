using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace _02._Wall_Destroyer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            int vankoRow = 0;
            int vankoCol = 0;
            int countOfHoles = 0;
            int countOfRods = 0;
            bool isElectrocuted = false;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                    if (matrix[row, col] == 'V')
                    {
                        vankoRow = row;
                        vankoCol = col;
                        matrix[row, col] = '*';
                        countOfHoles++;
                    }
                }
            }
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                if ((command == "up" && vankoRow == 0) ||
                            (command == "down" && vankoRow == matrix.GetLength(0) - 1) ||
                            (command == "left" && vankoCol == 0) ||
                            (command == "right" && vankoCol == matrix.GetLength(1) - 1))
                {
                    continue;
                }
                if (command == "up" && matrix[vankoRow - 1, vankoCol] == 'R' ||
                    command == "down" && matrix[vankoRow + 1, vankoCol] == 'R' ||
                    command == "left" && matrix[vankoRow, vankoCol - 1] == 'R' ||
                    command == "right" && matrix[vankoRow, vankoCol + 1] == 'R')
                {
                    countOfRods++;
                    ReturnToPreviousPosition(command, matrix, vankoRow, vankoCol);
                    continue;
                }

                if (command == "up")
                {
                    vankoRow--;
                }
                else if (command == "down")
                {
                    vankoRow++;
                }
                else if (command == "left")
                {
                    vankoCol--;
                }
                else if (command == "right")
                {
                    vankoCol++;
                }
                if (matrix[vankoRow, vankoCol] == '-')
                {
                    matrix[vankoRow, vankoCol] = '*';
                    countOfHoles++;
                }
                else if (matrix[vankoRow, vankoCol] == '*')
                {
                    Console.WriteLine($"The wall is already destroyed at position [{vankoRow}, {vankoCol}]!");
                }
                else if (matrix[vankoRow, vankoCol] == 'C')
                {
                    matrix[vankoRow, vankoCol] = 'E';
                    countOfHoles++;
                    Console.WriteLine($"Vanko got electrocuted, but he managed to make {countOfHoles} hole(s).");
                    isElectrocuted = true;
                    break;
                }
            }
            if (!isElectrocuted)
            {
                Console.WriteLine($"Vanko managed to make {countOfHoles} hole(s) and he hit only {countOfRods} rod(s).");
                matrix[vankoRow, vankoCol] = 'V';
            }
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
        private static void ReturnToPreviousPosition(string command, char[,] matrix, int vankoRow, int vankoCol)
        {
            if (command == "up" && matrix[vankoRow - 1, vankoCol] == 'R')
            {
                matrix[vankoRow, vankoCol] = matrix[vankoRow, vankoCol];
            }
            else if (command == "down" && matrix[vankoRow + 1, vankoCol] == 'R')
            {
                matrix[vankoRow, vankoCol] = matrix[vankoRow, vankoCol];
            }
            else if (command == "left" && matrix[vankoRow, vankoCol - 1] == 'R')
            {
                matrix[vankoRow, vankoCol] = matrix[vankoRow, vankoCol];
            }
            else if (command == "right" && matrix[vankoRow, vankoCol + 1] == 'R')
            {
                matrix[vankoRow, vankoCol] = matrix[vankoRow, vankoCol];
            }
            Console.WriteLine("Vanko hit a rod!");
        }
    }
}