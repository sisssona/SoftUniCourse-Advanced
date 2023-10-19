namespace _02.DeliveryBoy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int columns = dimensions[1];
            char[,] matrix = new char[rows, columns];
            int boysRow = 0;
            int boysColumn = 0;
            int boysStartRow = 0;
            int boysStartCol = 0;
            for (int row = 0; row < rows; row++)
            {
                string currRow = Console.ReadLine();
                for (int col = 0; col < columns; col++)
                {
                    matrix[row, col] = currRow[col];
                    if (matrix[row, col] == 'B')
                    {
                        boysRow = row;
                        boysColumn = col;
                        boysStartRow = row;
                        boysStartCol = col;
                    }
                }
            }
            bool isOtsideTheMatrix = false;
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "up")
                {
                    if (boysRow == 0)
                    {
                        if (matrix[boysRow, boysColumn] == '-')
                        {
                            matrix[boysRow, boysColumn] = '.';
                        }
                        isOtsideTheMatrix = true;
                        Console.WriteLine("The delivery is late. Order is canceled.");
                        break;
                    }

                    if (matrix[boysRow - 1, boysColumn] == '*')
                    {
                        continue;
                    }
                    if (matrix[boysRow, boysColumn] != 'R')
                    {
                        matrix[boysRow, boysColumn] = '.';
                    }
                    boysRow--;
                }
                else if (input == "down")
                {
                    if (boysRow == matrix.GetLength(0) - 1)
                    {
                        if (matrix[boysRow, boysColumn] == '-')
                        {
                            matrix[boysRow, boysColumn] = '.';
                        }
                        isOtsideTheMatrix = true;
                        Console.WriteLine("The delivery is late. Order is canceled.");
                        break;
                    }
                    if (matrix[boysRow + 1, boysColumn] == '*')
                    {
                        continue;
                    }
                    if (matrix[boysRow, boysColumn] != 'R')
                    {
                        matrix[boysRow, boysColumn] = '.';
                    }
                    boysRow++;
                }
                if (input == "right")
                {
                    if (boysColumn == matrix.GetLength(1) - 1)
                    {
                        if (matrix[boysRow, boysColumn] == '-')
                        {
                            matrix[boysRow, boysColumn] = '.';
                        }
                        isOtsideTheMatrix = true;
                        Console.WriteLine("The delivery is late. Order is canceled.");
                        break;
                    }
                    if (matrix[boysRow, boysColumn + 1] == '*')
                    {
                        continue;
                    }
                    if (matrix[boysRow, boysColumn] != 'R')
                    {
                        matrix[boysRow, boysColumn] = '.';
                    }
                    boysColumn++;
                }
                if (input == "left")
                {
                    if (boysColumn == 0)
                    {
                        if (matrix[boysRow, boysColumn] == '-')
                        {
                            matrix[boysRow, boysColumn] = '.';
                        }
                        isOtsideTheMatrix = true;
                        Console.WriteLine("The delivery is late. Order is canceled.");
                        break;
                    }
                    if (matrix[boysRow, boysColumn - 1] == '*')
                    {
                        continue;
                    }
                    if (matrix[boysRow, boysColumn] != 'R')
                    {
                        matrix[boysRow, boysColumn] = '.';
                    }
                    boysColumn--;
                }
                if (matrix[boysRow, boysColumn] == 'P')
                {
                    Console.WriteLine("Pizza is collected. 10 minutes for delivery.");

                    matrix[boysRow, boysColumn] = 'R';

                    continue;
                }

                if (matrix[boysRow, boysColumn] == 'A')
                {
                    Console.WriteLine("Pizza is delivered on time! Next order...");

                    matrix[boysRow, boysColumn] = 'P';

                    break;
                }
            }
            if (isOtsideTheMatrix)
            {
                matrix[boysStartRow, boysStartCol] = ' ';
            }
            else
            {
                matrix[boysStartRow, boysStartCol] = 'B';
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
    }
    
}