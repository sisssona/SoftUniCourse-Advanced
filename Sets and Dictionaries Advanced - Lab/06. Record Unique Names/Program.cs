﻿namespace _06._Record_Unique_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> uniqueNames = new HashSet<string>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                uniqueNames.Add(name);
            }
            foreach (var name in uniqueNames)
            {
                Console.WriteLine(name);
            }
        }
    }
}