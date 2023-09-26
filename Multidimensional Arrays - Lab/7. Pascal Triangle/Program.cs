﻿namespace _7._Pascal_Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            long[][] pascal = new long[n][];
            pascal[0] = new long[1] { 1 };

            for (int row = 1; row < n; row++)
            {
                pascal[row] = new long[row + 1];
                for (int col = 0; col < pascal[row].Length; col++)
                {
                    if (col < pascal[row - 1].Length)
                    {
                        //текущата клетка е плюс равна на клетката от предишния ред от същата колона
                        pascal[row][col] += pascal[row - 1][col];
                    }
                    if (col > 0)
                    {
                        //текущата клетка е плюс равна на клетката от предишния ред от предната колона
                        pascal[row][col] += pascal[row - 1][col - 1];
                    }

                }
            }
            for (int row = 0; row < pascal.Length; row++)
            {
                for (int col = 0; col < pascal[row].Length; col++)
                {
                    Console.Write($"{pascal[row][col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}