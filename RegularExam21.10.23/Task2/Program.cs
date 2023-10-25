using System.Data;
using System.Drawing;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[,] fishingArea = new string[n, n];
            int startRow = -1;
            int startCol = -1;
            int amount = 0;
            for (int row = 0; row < n; row++)
            {
                string positions = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {

                    if (positions[col].ToString() == "S")
                    {
                        startRow = row;
                        startCol = col;
                        fishingArea[row, col] = "-";
                        continue;
                    }
                    fishingArea[row, col] = positions[col].ToString();
                }
            }

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "collect the nets")
                {
                    break;
                }
                if (IsOutOfTheArea(command, startRow, startCol, n))
                {
                    if (command == "up" || command == "down")
                    {
                        startRow = ResetRow(n, command);
                    }

                    if (command == "left" || command == "right")
                    {
                        startCol = ResetCol(n, command);
                    }
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
                    else
                    {
                        startCol++;
                    }
                }

                if (Char.IsDigit(fishingArea[startRow, startCol][0]))
                {
                    amount += int.Parse(fishingArea[startRow, startCol]);
                    fishingArea[startRow, startCol] = "-";
                    continue;

                }
                if (fishingArea[startRow, startCol] == "W")
                {
                    Console.WriteLine($"You fell into a whirlpool! The ship sank and you lost the fish you caught. Last coordinates of the ship: [{startRow},{startCol}]");
                    Environment.Exit(0);
                    return;
                }
            }

            if (amount >= 20)
            {
                Console.WriteLine("Success! You managed to reach the quota!");
            }
            else
            {
                int neededFishAmount = 20 - amount;
                Console.WriteLine($"You didn't catch enough fish and didn't reach the quota! You need {neededFishAmount} tons of fish more.");
            }
            if (amount > 0)
            {
                Console.WriteLine($"Amount of fish caught: {amount} tons.");
            }
            fishingArea[startRow, startCol] = "S";

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(fishingArea[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static int ResetCol(int n, string command)
        {
            if (command == "left")
            {
                return n - 1;
            }
            return 0;
        }

        private static int ResetRow(int n, string command)
        {
            if (command == "up")
            {
                return n - 1;
            }
            return 0;
        }

        private static bool IsOutOfTheArea(string command, int startRow, int startCol, int n)
        {
            if (command == "up" && startRow == 0 ||
                command == "down" && startRow == n - 1 ||
                command == "left" && startCol == 0 ||
                command == "right" && startCol == n - 1)
            {
                return true;
            }
            return false;
        }
    }
}