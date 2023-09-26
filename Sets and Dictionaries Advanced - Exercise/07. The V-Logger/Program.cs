namespace _07._The_V_Logger
{
    internal class Program
    {
        static void Main(string[] args)
        { //in key i add the vloggers, first place in the value dictionary is how many vloggers do the key vlogger has and second place is how many does he follows 
            List<string> input = new List<string>();
            Dictionary<string, Dictionary<string, HashSet<string>>> vloggers = new Dictionary<string, Dictionary<string, HashSet<string>>>();
            string vloggerNameJoined = "";
            while (true)
            {
                input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
                if (input[0] == "Statistics")
                {
                    break;
                }
                //if input is long 4 it is 	"{vloggername}" joined The V-Logger "
                if (input.Count == 4)
                {
                    vloggerNameJoined = input[0];
                    if (!vloggers.ContainsKey(vloggerNameJoined))
                    {
                        vloggers.Add(vloggerNameJoined, new Dictionary<string, HashSet<string>>());
                        //the key is followed by someone
                        vloggers[vloggerNameJoined].Add("followers", new HashSet<string>());
                        //one of the key follows another person
                        vloggers[vloggerNameJoined].Add("following", new HashSet<string>());
                    }
                }
                //if the input is 3 - •	"{vloggername} followed {vloggername}" 
                else
                {
                    string vloggerName = input[0];
                    string vloggerName2 = input[2];
                    //if vloggers have key with the same name and have key with the other vloggerName && both names are different
                    if (vloggers.ContainsKey(vloggerName) && vloggers.ContainsKey(vloggerName2) && vloggerName != vloggerName2)
                    {
                        //the first vlogger is folloeing the second
                        vloggers[vloggerName]["following"].Add(vloggerName2);
                        //the second vlogger is following the first, so he is follower
                        vloggers[vloggerName2]["followers"].Add(vloggerName);
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            int count = 1;
            Console.WriteLine($"The V-Logger has a total of {vloggers.Count()} vloggers in its logs.");
            Dictionary<string, Dictionary<string, HashSet<string>>> orderedVloggers = vloggers
                                                                    .OrderByDescending(v => v.Value["followers"].Count)
                                                                    .ThenBy(v => v.Value["following"].Count)
                                                                    .ToDictionary(v => v.Key, v => v.Value);
            foreach (var vlogger in orderedVloggers)
            {
                Console.WriteLine($"{count}. {vlogger.Key} : {vlogger.Value["followers"].Count} followers, {vlogger.Value["following"].Count} following");
                if (count == 1)
                {
                    //Try SortedSet for vloggers 
                    List<string> orderedFollowers = vlogger.Value["followers"]
                        .OrderBy(f => f)
                        .ToList();

                    foreach (var follower in orderedFollowers)
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }

                count++;
            }
        }

    }
}