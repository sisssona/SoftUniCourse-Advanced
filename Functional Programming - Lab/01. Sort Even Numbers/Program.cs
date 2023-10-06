﻿namespace _01._Sort_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
         List<int> evenNumbers = Console.ReadLine().Split(", ").Select(int.Parse).Where(x => x % 2 ==0).OrderBy(x => x).ToList();
            Console.WriteLine(String.Join(", ", evenNumbers));
        }
    }
}