using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace _01.ApocalypsePreparation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> textiles = new(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> medicaments = new(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            int sum = 0;
            Dictionary<string, int> healingItems = new();
            string patch = "Patch";
            string bandage = "Bandage";
            string medKit = "MedKit";

            while (textiles.Any() && medicaments.Any())
            {
                int firstTextile = textiles.Peek();
                int lastMedicament = medicaments.Peek();
                sum = firstTextile + lastMedicament;
                if (sum == 30)
                {
                    textiles.Dequeue();
                    medicaments.Pop();
                    if (!healingItems.ContainsKey(patch))
                    {
                        healingItems.Add(patch, 1);
                    }
                    else
                    {
                        healingItems[patch]++;
                    }
                }
                else if (sum == 40)
                {
                    textiles.Dequeue();
                    medicaments.Pop();
                    if (!healingItems.ContainsKey(bandage))
                    {
                        healingItems.Add(bandage, 1);
                    }
                    else
                    {
                        healingItems[bandage]++;
                    }
                }
                else if (sum == 100)
                {
                    textiles.Dequeue();
                    medicaments.Pop();
                    if (!healingItems.ContainsKey(medKit))
                    {
                        healingItems.Add(medKit, 1);
                    }
                    else
                    {
                        healingItems[medKit]++;
                    }
                }
                else if (sum > 100)
                {
                    textiles.Dequeue();
                    medicaments.Pop();
                    int nextValueMedicament = medicaments.Pop();
                    nextValueMedicament += sum - 100;
                    medicaments.Push(nextValueMedicament);
                    if (!healingItems.ContainsKey(medKit))
                    {
                        healingItems.Add(medKit, 1);
                    }
                    else
                    {
                        healingItems[medKit]++;
                    }
                }
                else
                {
                    textiles.Dequeue();
                    int medicamentsValue = medicaments.Pop();
                    medicamentsValue += 10;
                    medicaments.Push(medicamentsValue);
                }
            }

            if (!textiles.Any() && !medicaments.Any())
            {
                Console.WriteLine("Textiles and medicaments are both empty.");
            }
            else if (!textiles.Any())
            {
                Console.WriteLine("Textiles are empty.");
            }
            else if (!medicaments.Any())
            {
                Console.WriteLine("Medicaments are empty.");
            }


            if (healingItems.Any())
            {
                foreach (var item in healingItems.OrderByDescending(a => a.Value).ThenBy(n => n.Key))
                {
                    Console.WriteLine($"{item.Key} - {item.Value}");
                }
            }
            if (medicaments.Any())
            {
                Console.WriteLine($"Medicaments left: {string.Join(", ", medicaments)}");
            }
            if (textiles.Any())
            {
                Console.WriteLine($"Textiles left: {string.Join(", ", textiles)}");
            }
        }
    }
}