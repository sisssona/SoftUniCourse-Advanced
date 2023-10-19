namespace _01.TempleOfDoom
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] tools = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] substances = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            List<int> challenges = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            int firstTool = 0;
            int lastSubstance = 0;
            int resultMultiplicationToolSubstance = 0;
            Stack<int> stackSubstances = new Stack<int>();
            Queue<int> queueTools = new Queue<int>();
            for (int i = 0; i < substances.Length; i++)
            {
                stackSubstances.Push(substances[i]);
            }
            for (int i = 0; i < tools.Length; i++)
            {
                queueTools.Enqueue(tools[i]);
            }
            while (true)
            {
                if (!queueTools.Any() || !stackSubstances.Any())
                {
                    break;
                }
                firstTool = queueTools.FirstOrDefault();
                lastSubstance = stackSubstances.Peek();
                resultMultiplicationToolSubstance = firstTool * lastSubstance;
                if (challenges.Contains(resultMultiplicationToolSubstance))
                {
                    stackSubstances.Pop();
                    queueTools.Dequeue();
                    challenges.Remove(resultMultiplicationToolSubstance);
                }
                else
                {
                    firstTool += 1;
                    queueTools.Dequeue();
                    queueTools.Enqueue(firstTool);

                    lastSubstance -= 1;
                    stackSubstances.Pop();
                    if (lastSubstance > 0)
                    {
                        stackSubstances.Push(lastSubstance);

                    }

                }


                if ((!queueTools.Any() || !stackSubstances.Any()) && challenges.Any())
                {
                    Console.WriteLine("Harry is lost in the temple. Oblivion awaits him.");
                    break;
                }
                if (challenges.Count == 0)
                {
                    Console.WriteLine("Harry found an ostracon, which is dated to the 6th century BCE.");
                    break;

                }
            }
            if (queueTools.Any())
            {
                Console.WriteLine($"Tools: {string.Join(", ", queueTools)}");
            }
            if (stackSubstances.Any())
            {
                Console.WriteLine($"Substances: {string.Join(", ", stackSubstances)}");
            }
            if (challenges.Count > 0)
            {
                Console.WriteLine($"Challenges: {string.Join(", ", challenges)}");
            }
        }
    }

}

