using System;

namespace DateModifier
{
    public class Program
    {
        static void Main(string[] args)
        {
            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine(); 
            DateModifier dateModifier = new DateModifier();
            int difference = dateModifier.DifferenceInTheDaysBetweenTwoDates(firstDate, secondDate);
            Console.WriteLine(difference);
        }
    }
}