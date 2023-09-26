namespace _5._Snake_Moves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];

            string snake = Console.ReadLine();
            Queue<char> queue = new Queue<char>();
            char[,] matrix = new char[rows, cols];

            for (int i = 0; i < snake.Length; i++)
            {
                queue.Enqueue(snake[i]);
            }
            for (int row = 0; row < rows; row++) //всички редове от първия до последния
            {
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = queue.Dequeue();
                    queue.Enqueue(matrix[row, col]);
                }
            }


            for (int row = 0; row < rows; row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        Console.Write(matrix[row, col]);
                    }
                }
                else
                {

                    for (int col = cols - 1; col >= 0; col--)
                    {
                        Console.Write(matrix[row, col]);
                    }
                }
                Console.WriteLine();
            }
        }
    }
}