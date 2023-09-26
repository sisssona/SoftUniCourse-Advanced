namespace _9._Miner__not_included_in_final_score_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            string[] directions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            char[,] matrix = new char[size, size];

            int currRow = 0;
            int currCol = 0;
            int countCoal = 0;

            for (int row = 0; row <= size - 1; row++) //всички редове от първия до последния
            {
                char[] symbol = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                for (int col = 0; col <= size - 1; col++)
                {
                    matrix[row, col] = symbol[col];
                    if (symbol[col] == 's')
                    {
                        currRow = row;
                        currCol = col;
                    }
                    else if (symbol[col] == 'c')
                    {
                        countCoal++;
                    }
                }
            }
            foreach (string direction in directions)
            {
                switch (direction)
                {
                    case "left":
                        if (currCol - 1 >= 0 && currCol - 1 <= size - 1)
                        {
                            currCol--;
                            char currentElement = matrix[currRow, currCol];
                            if (currentElement == 'e')
                            {
                                Console.WriteLine($"Game over! ({currRow}, {currCol})");
                                return;
                            }
                            else if (currentElement == 'c')
                            {
                                matrix[currRow, currCol] = '*';
                                countCoal--;
                                if (countCoal == 0)
                                {
                                    Console.WriteLine($"You collected all coals! ({currRow}, {currCol})");
                                    return;
                                }
                            }
                        }
                        break;
                    case "right":
                        if (currCol + 1 >= 0 && currCol + 1 <= size - 1)
                        {
                            currCol++;
                            char currentElement = matrix[currRow, currCol];
                            if (currentElement == 'e')
                            {
                                Console.WriteLine($"Game over! ({currRow}, {currCol})");
                                return;
                            }
                            else if (currentElement == 'c')
                            {
                                matrix[currRow, currCol] = '*';
                                countCoal--;
                                if (countCoal == 0)
                                {
                                    Console.WriteLine($"You collected all coals! ({currRow}, {currCol})");
                                    return;
                                }
                            }
                        }
                        break;
                    case "up":
                        if (currRow - 1 >= 0 && currRow - 1 <= size - 1)
                        {
                            currRow--;
                            char currentElement = matrix[currRow, currCol];
                            if (currentElement == 'e')
                            {
                                Console.WriteLine($"Game over! ({currRow}, {currCol})");
                                return;
                            }
                            else if (currentElement == 'c')
                            {
                                matrix[currRow, currCol] = '*';
                                countCoal--;
                                if (countCoal == 0)
                                {
                                    Console.WriteLine($"You collected all coals! ({currRow}, {currCol})");
                                    return;
                                }
                            }
                        }                               
                        break;
                    case "down":
                        if (currRow + 1 >= 0 && currRow + 1 <= size - 1)
                        {
                            currRow++;
                            char currentElement = matrix[currRow, currCol];
                            if (currentElement == 'e')
                            {
                                Console.WriteLine($"Game over! ({currRow}, {currCol})");
                                return;
                            }
                            else if (currentElement == 'c')
                            {
                                matrix[currRow, currCol] = '*';
                                countCoal--;
                                if (countCoal == 0)
                                {
                                    Console.WriteLine($"You collected all coals! ({currRow}, {currCol})");
                                    return;
                                }
                            }
                        }                                   
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine($"{countCoal} coals left. ({currRow}, {currCol})");
        }
    }
}