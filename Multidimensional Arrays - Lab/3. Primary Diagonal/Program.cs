namespace _3._Primary_Diagonal
{
    internal class Program
    {
        static void Main(string[] args)
        {
           int size = int.Parse(Console.ReadLine());
            int rows = size;
            int cols = size;
            int[,] matrix = new int[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                int[] rowValues = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowValues[col];
                }
            }
            int sum = 0;
            //for (int row = 0; row < rows; row++)
            //{            
            //        sum += matrix[row, row];                
            //}
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                sum += matrix[i, i];
            }
            //Обратен диагонал
            //for (int i = 0; i < matrix.GetLength(0); i++)
            //{
            //    sum += matrix[i, matrix.GetLength(1) - i - 1];
            //}
            Console.WriteLine(sum);
        }
    }
}