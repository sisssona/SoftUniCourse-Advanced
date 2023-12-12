using System;
using System.Linq;
using System.Collections.Generic;

namespace _1.TilesMaster
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> whiteTiles = new(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Queue<int> greyTiles = new(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Dictionary<string, int> locations = new Dictionary<string, int>()
            {
                { "Sink", 40 },
                {"Oven", 50 },
                {"Countertop", 60 },
                {"Wall", 70 }
            };
            Dictionary<string, int> locationForTheTiles = new Dictionary<string, int>();
            int largerTile = 0;
            while (true)
            {
                if (!whiteTiles.Any() || !greyTiles.Any())
                {
                    break;
                }
                bool isFitting = false;
                //if the area of whiteTiles match the area of the grey tile
                if (whiteTiles.Peek() == greyTiles.Peek())
                {
                    largerTile = whiteTiles.Peek() + greyTiles.Peek();
                    foreach (var item in locations)
                    {
                        //if the area of the newly formed tile match the necessary area tail for any of the locations
                        if (item.Value == largerTile)
                        {
                            if (!locationForTheTiles.ContainsKey(item.Key))
                            {
                                locationForTheTiles.Add(item.Key, 1);
                            }
                            else
                            {
                                locationForTheTiles[item.Key]++;
                            }
                            isFitting = true;
                            break;
                        }
                    }
                    if (!isFitting)
                    {
                        //the new tile will be used for floor. Both tiles are removed from the sequences
                        if (!locationForTheTiles.ContainsKey("Floor"))
                        {
                            locationForTheTiles.Add("Floor", 1);
                        }
                        else
                        {
                            locationForTheTiles["Floor"]++;
                        }
                    }
                    if (whiteTiles.Any())
                    {
                        whiteTiles.Pop();
                    }
                    if (greyTiles.Any())
                    {
                        greyTiles.Dequeue();
                    }
                }
                else
                {
                    if (whiteTiles.Any())
                    {
                        int decreasedWhiteTile = whiteTiles.Peek() / 2;
                        whiteTiles.Pop();
                        whiteTiles.Push(decreasedWhiteTile);
                    }
                    if (greyTiles.Any())
                    {
                        int newPositionOfTheGreyTile = greyTiles.Peek();
                        greyTiles.Dequeue();
                        greyTiles.Enqueue(newPositionOfTheGreyTile);
                    }
                }
            }
            if (whiteTiles.Count == 0)
            {
                Console.WriteLine($"White tiles left: none");
            }
            else
            {
                foreach (var item in whiteTiles)
                {
                    Console.WriteLine($"White tiles left: {string.Join(", ", whiteTiles)}");
                    break;
                }
            }
            if (greyTiles.Count == 0)
            {
                Console.WriteLine($"Grey tiles left: none");
            }
            else
            {
                foreach (var item in greyTiles)
                {
                    Console.WriteLine($"Grey tiles left: {string.Join(", ", greyTiles)}");
                    break;
                }
                
            }
            foreach (var item in locationForTheTiles.OrderByDescending(t => t.Value).ThenBy(t => t.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
