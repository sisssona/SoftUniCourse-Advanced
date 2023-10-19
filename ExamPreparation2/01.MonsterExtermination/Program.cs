
namespace _01.MonsterExtermination
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> monsterArmour = new(Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> soldierStrikingImpact = new(Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            int killedMonsters = 0;

            while (monsterArmour.Any() && soldierStrikingImpact.Any())
            {
                int firstMonsterArmor = monsterArmour.Dequeue();
                int lastSoldierStrike = soldierStrikingImpact.Pop();

                if (lastSoldierStrike >= firstMonsterArmor)
                {
                    killedMonsters++;
                    lastSoldierStrike -= firstMonsterArmor;
                    if (soldierStrikingImpact.Any())
                    {
                        int nextStrikeElement = soldierStrikingImpact.Pop();
                        nextStrikeElement += lastSoldierStrike;
                        soldierStrikingImpact.Push(nextStrikeElement);
                    }
                    else if (lastSoldierStrike > 0)
                    {
                        soldierStrikingImpact.Push(lastSoldierStrike);
                    }
                }
                else
                {
                    firstMonsterArmor -= lastSoldierStrike;
                    monsterArmour.Enqueue(firstMonsterArmor);
                }
            }
            if (!monsterArmour.Any())
            {
                Console.WriteLine("All monsters have been killed!");
            }
            if (!soldierStrikingImpact.Any())
            {
                Console.WriteLine("The soldier has been defeated.");
            }


            Console.WriteLine($"Total monsters killed: {killedMonsters}");

        }

    }
}