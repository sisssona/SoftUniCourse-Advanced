using System;

namespace ThreeupleType
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] personsTokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] drinkTokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] bankTokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Threeuple<string, string, string> nameAddress = new($"{personsTokens[0]} {personsTokens[1]}", personsTokens[2], string.Join(" ",personsTokens[3..])); //take all the tokens from the 3d to the end
            Threeuple<string, int, bool> nameBeer = new(drinkTokens[0], int.Parse(drinkTokens[1]), drinkTokens[2] == "drunk");
            Threeuple<string, double, string> bank = new(bankTokens[0], double.Parse(bankTokens[1]), bankTokens[2]);

            Console.WriteLine(nameAddress);
            Console.WriteLine(nameBeer);
            Console.WriteLine(bank);
        }
    }
}