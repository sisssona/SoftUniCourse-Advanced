using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethodString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> items = new();
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                string item = Console.ReadLine();
                items.Add(item);
            }
            int[] indices = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Swap(indices[0], indices[1], items);

            foreach (string item in items)
            {
                Console.WriteLine($"{item.GetType()}: {item}");
            }
        }
        static void Swap<T>(int first, int second, List<T> items)
        {
            T temp = items[first];
            items[first] = items[second];
            items[second] = temp;
        }
    }
}