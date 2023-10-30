using System.Reflection.Metadata.Ecma335;

namespace _02.Help_A_Mole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[,] matrix = new string[n, n];
            int startRow = -1;
            int startCol = -1;
            int points = 0;

            for (int row = 0; row < n; row++)
            {
                string newRows = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    if (newRows[col].ToString() == "M")
                    {
                        startRow = row;
                        startCol = col;
                        matrix[row, col] = "-";
                        continue;
                    }
                    matrix[row, col] = newRows[col].ToString();
                }
            }

            string command;
            while (true)
            {
                command = Console.ReadLine();
                if (command == "End" || points >= 25)
                {
                    break;
                }
                if (OutofTheField(command, startRow, startCol, n))
                {
                    Console.WriteLine("Don't try to escape the playing field!");
                    continue;
                }
                else
                {
                    if (command == "up")
                    {
                        startRow--;
                    }
                    else if (command == "down")
                    {
                        startRow++;
                    }
                    else if (command == "left")
                    {
                        startCol--;
                    }
                    else if (command == "right")
                    {
                        startCol++;
                    }
                }
                if (Char.IsDigit(matrix[startRow, startCol][0]))
                {
                    points += int.Parse(matrix[startRow, startCol]);
                    matrix[startRow, startCol] = "-";
                    continue;

                }
                if (matrix[startRow, startCol] == "S")
                {
                    matrix[startRow, startCol] = "-";
                    points -= 3;
                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        for (int col = 0; col < matrix.GetLength(1); col++)
                        {
                            if (matrix[row,col] == "S")
                            {
                                startRow = row;
                                startCol = col;
                                matrix[startRow,startCol] = "-";    
                            }
                        }
                    }
                }

            }
            matrix[startRow, startCol] = "M";
            if (points >= 25)
            {
                Console.WriteLine("Yay! The Mole survived another game!");
                Console.WriteLine($"The Mole managed to survive with a total of {points} points.");
            }
            else
            {
                Console.WriteLine("Too bad! The Mole lost this battle!");
                Console.WriteLine($"The Mole lost the game with a total of {points} points.");
            }
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
        private static bool OutofTheField(string command, int startRow, int startCol, int n)
        {
            if (command == "up" && startRow == 0 || command == "down" && startRow == n - 1 ||
                command == "left" && startCol == 0 || command == "right" && startCol == n - 1)
            {
                return true;
            }
            return false;
        }
    }
}