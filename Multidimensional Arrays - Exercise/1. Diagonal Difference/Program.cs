namespace _1._Diagonal_Difference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int[,] matrix = new int[size, size];

            for (int row = 0; row <= size-1; row++) //всички редове от първия до последния
            {
                int[] numbers = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col <= size-1; col++)
                {
                    matrix[row,col] = numbers[col];
                }
            }
            //сума от числата на главния диагонал => номер на ред = номер на колоната
            int primaryDiagonal = 0;
            //сума от числата на второстепенния диагонал => номер на колоната = size - 1 - номер на ред
            int seconadaryDiagonal = 0;
            //ОБХОЖДАМЕ МАТРИЦАТА
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    int element = matrix[row,col]; //текущ елемент
                    if (row == col)
                    {
                        //елементът е на главния диагонал
                        primaryDiagonal += element;
                    }
                    if (col == size - 1 - row)
                    {
                        //елементът е на второстепенния диагонал
                        seconadaryDiagonal += element;
                    }
                }
            }
            Console.WriteLine(Math.Abs(primaryDiagonal - seconadaryDiagonal));
        }
    }
}