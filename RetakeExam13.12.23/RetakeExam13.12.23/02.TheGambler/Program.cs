using System.Numerics;

namespace _02.TheGambler
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] gameBoard = new char[n, n];
            int startRow = 0;
            int startCol = 0;
            double initialAmount = 100;
            bool isJackpotWon = false;

            for (int row = 0; row < n; row++)
            {
                string newRows = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    gameBoard[row, col] = newRows[col];
                    if (gameBoard[row, col] == 'G')
                    {
                        startRow = row;
                        startCol = col;
                        gameBoard[row, col] = '-';
                    }
                }
            }

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                if (command == "up" && startRow == 0 || command == "down" && startRow == n - 1 ||
                                      command == "left" && startCol == 0 || command == "right" && startCol == n - 1)
                {
                    Console.WriteLine("Game over! You lost everything!");
                    break;
                }
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
                if (gameBoard[startRow, startCol] == 'W')
                {
                    initialAmount += 100;
                    gameBoard[startRow, startCol] = '-';
                }
                else if (gameBoard[startRow, startCol] == 'P')
                {
                    initialAmount -= 200;
                    if (initialAmount <= 0)
                    {
                        Console.WriteLine("Game over! You lost everything!");
                        break;
                    }
                    gameBoard[startRow, startCol] = '-';
                }
                else if (gameBoard[startRow, startCol] == 'J')
                {
                    isJackpotWon = true;
                    initialAmount += 100000;
                    gameBoard[startRow, startCol] = '-';
                    break;
                }


            }

            if (isJackpotWon)
            {
                Console.WriteLine("You win the Jackpot!");
                Console.WriteLine($"End of the game. Total amount: {initialAmount}$");

            }
            if (!isJackpotWon && initialAmount > 0)
            {
                Console.WriteLine($"End of the game. Total amount: {initialAmount}$");
            }



            gameBoard[startRow, startCol] = 'G';
            if (initialAmount > 0)
            {
                for (int row = 0; row < n; row++)
                {
                    for (int col = 0; col < n; col++)
                    {
                        Console.Write(gameBoard[row, col]);
                    }
                    Console.WriteLine();
                }

            }
        }
    }
}