namespace _02.TheSquirrel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] field = new char[n, n];
            string[] directions = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            int hazelnutsCount = 0;
            int startRowPosition = 0;
            int startColPosition = 0;
            bool isOnTrapOrOutOfField = false;
            for (int row = 0; row < n; row++)
            {
                string fieldChars = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    field[row, col] = fieldChars[col];
                    if (field[row, col] == 's')
                    {
                        startRowPosition = row;
                        startColPosition = col;
                        field[startRowPosition, startColPosition] = '*';
                    }

                }
            }
            for (int i = 0; i < directions.Length; i++)
            {
                if (directions[i] == "left")
                {
                    if (startColPosition == 0)
                    {
                        isOnTrapOrOutOfField|= true;
                        Console.WriteLine("The squirrel is out of the field.");
                        break;
                    }
                    if (field[startRowPosition, startColPosition - 1] == '*')
                    {
                        startColPosition--;
                        continue;
                    }
                    startColPosition--;


                }
                else if (directions[i] == "right")
                {
                    if (startColPosition == field.GetLength(0) - 1)
                    {
                        isOnTrapOrOutOfField|= true;
                        Console.WriteLine("The squirrel is out of the field.");
                        break;
                    }
                    if (field[startRowPosition, startColPosition + 1] == '*')
                    {
                       startColPosition++;
                        continue;
                    }
                    startColPosition++;
                }
                else if (directions[i] == "up")
                {

                    if (startRowPosition == 0)
                    {
                        isOnTrapOrOutOfField= true;
                        Console.WriteLine("The squirrel is out of the field.");
                        break;
                    }
                    if (field[startRowPosition - 1, startColPosition] == '*')
                    {
                        startRowPosition--;
                        continue;
                    }
                    startRowPosition--;
                }
                else if (directions[i] == "down")
                {
                    if (startRowPosition == field.GetLength(1) - 1)
                    {
                        isOnTrapOrOutOfField= true;
                        Console.WriteLine("The squirrel is out of the field.");
                        break;
                    }
                    if (field[startRowPosition + 1, startColPosition] == '*')
                    {
                       startRowPosition++;
                        continue;
                    }
                    startRowPosition++;
                }
                if (field[startRowPosition, startColPosition] == 't')
                {
                    isOnTrapOrOutOfField= true;
                    Console.WriteLine("Unfortunately, the squirrel stepped on a trap...");
                    break;
                }
                if (field[startRowPosition, startColPosition] == 'h')
                {
                    hazelnutsCount++;
                    if (hazelnutsCount == 3)
                    {
                        Console.WriteLine("Good job! You have collected all hazelnuts!");
                        field[startRowPosition, startColPosition] = '*';
                        break;
                    }
                }
                field[startRowPosition, startColPosition] = 's';
            }
            if (hazelnutsCount < 3 && !isOnTrapOrOutOfField)
            {
                Console.WriteLine("There are more hazelnuts to collect.");
            }
            // 
            Console.WriteLine($"Hazelnuts collected: {hazelnutsCount}");

        }
    }
}