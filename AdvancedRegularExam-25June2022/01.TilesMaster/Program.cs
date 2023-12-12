namespace _01.TilesMaster
{
    public class Program
    {
        public static void Main()
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
            while (whiteTiles.Any() && greyTiles.Any())
            {
                if (whiteTiles.Peek() == greyTiles.Peek())
                {
                    largerTile = whiteTiles.Peek() + greyTiles.Peek();
                    foreach (var item in locations)
                    {
                        if (item.Value == largerTile)
                        {
                            if (!locationForTheTiles.ContainsKey(item.Key))
                            {
                                locationForTheTiles.Add(item.Key, 1);
                            }
                            else
                            {
                                locationForTheTiles[item.Key] = 1;
                            }
                            whiteTiles.Pop();
                            greyTiles.Dequeue();
                        }
                        else
                        {
                            if (!locationForTheTiles.ContainsKey("Floor"))
                            {
                                locationForTheTiles.Add("Floor", 1);
                            }
                            else
                            {
                                locationForTheTiles["Floor"] = 1;
                            }
                            int decreasedWhiteTile = whiteTiles.Peek() / 2;
                            whiteTiles.Pop();
                            whiteTiles.Push(decreasedWhiteTile);
                            int newPositionOfTheGreyTile = greyTiles.Peek();
                            greyTiles.Dequeue();
                            greyTiles.Enqueue(newPositionOfTheGreyTile);
                        }
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
                    Console.WriteLine($"White tiles left: {string.Join(" ", whiteTiles)}");
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
                    Console.WriteLine($"Grey tiles left: {string.Join(" ", greyTiles)}");
                }
            }
            foreach (var item in locationForTheTiles.OrderByDescending(t=>t.Value).ThenBy(t=>t.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }






    }
}