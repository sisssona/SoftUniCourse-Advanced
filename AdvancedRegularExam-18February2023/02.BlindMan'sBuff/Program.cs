namespace _02.BlindMan_sBuff
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];
            char[,] playground = new char[rows, cols];
            int startRowPosition = 0;
            int startColPosition = 0;
            int players = 0;
            int moveCount = 0;
            for (int row = 0; row < rows; row++)
            {
                char[] letters = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    playground[row, col] = letters[col];

                    if (playground[row, col] == 'B')
                    {
                        startRowPosition = row;
                        startColPosition = col;
                        playground[startRowPosition, startColPosition] = '-';
                    }
                }
            }
            string command;
            while ((command = Console.ReadLine()) != "Finish")
            {
                if (command == "up")
                {
                    if (startRowPosition == 0)
                    {
                        continue;
                    }
                    if (playground[startRowPosition - 1, startColPosition] == 'O')
                    {
                        continue;
                    }
                    startRowPosition--;
                }
                else if (command == "down")
                {
                    if (startRowPosition == playground.GetLength(0) - 1)
                    {
                        continue;
                    }
                    if (playground[startRowPosition + 1, startColPosition] == 'O')
                    {
                        continue;
                    }
                    startRowPosition++;
                }
                else if (command == "right")
                {
                    if (startColPosition == playground.GetLength(1) - 1)
                    {
                        continue;
                    }
                    if (playground[startRowPosition, startColPosition + 1] == 'O')
                    {
                        continue;
                    }
                    startColPosition++;
                }
                else if (command == "left")
                {
                    if (startColPosition == 0)
                    {
                        continue;
                    }
                    if (playground[startRowPosition, startColPosition - 1] == 'O')
                    {
                        continue;
                    }
                    startColPosition--;
                }
                if (playground[startRowPosition, startColPosition] == '-')
                {
                    moveCount++;
                }
                if (playground[startRowPosition, startColPosition] == 'P')
                {
                    players++;
                    moveCount++;
                    playground[startRowPosition, startColPosition] = '-';
                    if (players == 3)
                    {
                        break;
                    }
                }

            }
            Console.WriteLine("Game over!");
            Console.WriteLine($"Touched opponents: {players} Moves made: {moveCount}");
        }
    }
}