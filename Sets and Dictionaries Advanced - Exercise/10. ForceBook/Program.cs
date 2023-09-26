namespace _10._ForceBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, SortedSet<string>> sideUsers = new();

            string command;
            while ((command = Console.ReadLine()) != "Lumpawaroo")
            {
                if (command.Contains('|'))
                {
                    string[] tokens = command.Split(" | ", StringSplitOptions.RemoveEmptyEntries);
                    string side = tokens[0];
                    string user = tokens[1];
                    if (!sideUsers.Values.Any(u => u.Contains(user)))
                    {
                        if (!sideUsers.ContainsKey(side))
                        {
                            sideUsers.Add(side, new SortedSet<string>());
                        }
                        sideUsers[side].Add(user);
                    }
                }
                else
                {
                    string[] tokens = command.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                    string side = tokens[1];
                    string user = tokens[0];
                    foreach (var sideuser in sideUsers)
                    {
                        if (sideuser.Value.Contains(user))
                        {
                            sideuser.Value.Remove(user);
                            break;
                        }
                    }
                    if (!sideUsers.ContainsKey(side))
                    {
                        sideUsers.Add(side, new SortedSet<string>());
                    }
                    sideUsers[side].Add(user);
                    Console.WriteLine($"{user} joins the {side} side!");
                }
            }
            //IOrderedEnumerable<KeyValuePair<string, SortedSet<string>>> orderedSidesUsers = sideUsers.OrderByDescending(su => su.Value.Count);
            foreach (var sideUser in sideUsers.OrderByDescending(su => su.Value.Count))
            {
                if (sideUser.Value.Any())
                {
                    Console.WriteLine($"Side: {sideUser.Key}, Members: {sideUser.Value.Count}");
                }
                foreach (var user in sideUser.Value)
                {
                    Console.WriteLine($"! {user}");
                }
            }
        }
    }
}