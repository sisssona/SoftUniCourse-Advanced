namespace _02.NavyBattle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] battlefield = new char[n, n];
            int startRow = 0;
            int startCol = 0;
            int countMines = 0;
            int countBattles = 0;

            for (int row = 0; row < n; row++)
            {
                string newRows = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    battlefield[row, col] = newRows[col];
                    if (battlefield[row, col] == 'S')
                    {
                        startRow = row;
                        startCol = col;
                        battlefield[row, col] = '-';
                    }
                }
            }

            while (true)
            {
                string command = Console.ReadLine().ToLower();
                if (command == "up")
                {
                    startRow--;
                }
                if (command == "down")
                {
                    startRow++;
                }
                if (command == "left")
                {
                    startCol--;
                }
                if (command == "right")
                {
                    startCol++;
                }
                if (battlefield[startRow, startCol] == '*')
                {
                    countMines++;
                    battlefield[startRow, startCol] = '-';
                    if (countMines == 3)
                    {
                        Console.WriteLine($"Mission failed, U-9 disappeared! Last known coordinates [{startRow}, {startCol}]!");
                        break;
                    }
                }
                if (battlefield[startRow, startCol] == 'C')
                {
                    countBattles++;
                    battlefield[startRow, startCol] = '-';
                    if (countBattles == 3)
                    {
                        Console.WriteLine("Mission accomplished, U-9 has destroyed all battle cruisers of the enemy!");
                        break;
                    }
                }

            }
            battlefield[startRow, startCol] = 'S';
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(battlefield[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}