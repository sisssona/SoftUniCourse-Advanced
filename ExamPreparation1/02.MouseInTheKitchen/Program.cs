namespace _02.MouseInTheKitchen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];
            char[,] matrix = new char[rows, cols];
            int mouseRow = 0;
            int mouseCol = 0;
            int cheeseCount = 0;

            for (int row = 0; row < rows; row++)
            {
                string currentRow = Console.ReadLine();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentRow[col];
                    if (matrix[row,col] == 'M')
                    {
                        mouseRow = row;
                        mouseCol = col;
                        matrix[mouseRow, mouseCol] = '*';
                    }
                    if (matrix[row,col] == 'C')
                    {
                        cheeseCount++;
                    }
                }
            }
            string input;
            while ((input = Console.ReadLine()) != "danger")
            {
                if (input == "left")
                {
                    if (mouseCol == 0)
                    {
                        Console.WriteLine("No more cheese for tonight!");
                        break;
                    }
                    if (matrix[mouseRow,mouseCol - 1] == '@')
                    {
                        continue;
                    }
                    mouseCol--;
                }
                else if (input == "right")
                {
                    if (mouseCol == cols-1)
                    {
                        Console.WriteLine("No more cheese for tonight!");
                        break;
                    }
                    if (matrix[mouseRow, mouseCol + 1] == '@')
                    {
                        continue;
                    }
                    mouseCol++;
                }
                else if (input == "up")
                {
                    if (mouseRow == 0)
                    {
                        Console.WriteLine("No more cheese for tonight!");
                        break;
                    }
                    if (matrix[mouseRow-1, mouseCol] == '@')
                    {
                        continue;
                    }
                    mouseRow--;
                }
                else if (input == "down")
                {
                    if (mouseRow == rows -1)
                    {
                        Console.WriteLine("No more cheese for tonight!");
                        break;
                    }
                    if (matrix[mouseRow + 1, mouseCol] == '@')
                    {
                        continue;
                    }
                    mouseRow++;
                }
                if (matrix[mouseRow,mouseCol] == 'C')
                {
                    cheeseCount--;
                    matrix[mouseRow, mouseCol] = '*';
                    if (cheeseCount == 0)
                    {
                        Console.WriteLine("Happy mouse! All the cheese is eaten, good night!");
                        break;
                    }
                }
                if (matrix[mouseRow,mouseCol] == 'T')
                {
                    Console.WriteLine("Mouse is trapped!");
                    break;
                }
            }
            if (input == "danger")
            {
                Console.WriteLine("Mouse will come back later!");
            }
            matrix[mouseRow, mouseCol] = 'M';

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row,col]);
                }
                Console.WriteLine();
            }
        }
    }
}