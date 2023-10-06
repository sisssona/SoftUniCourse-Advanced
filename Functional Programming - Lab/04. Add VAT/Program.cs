namespace _04._Add_VAT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Func<string, double> parser = s => double.Parse(s);
            //Func<double, double> vat = n => n * 1.2;
            //List<double> numbers = Console.ReadLine().Split(", ").Select(parser).Select(vat).ToList();
            //foreach (var item in numbers )
            //{
            //    Console.WriteLine($"{item:f2}");
            //}
            double[] prices = Console.ReadLine()
 .Split(new string[] { ", " },
 StringSplitOptions.RemoveEmptyEntries)
 .Select(double.Parse)
 .Select(n => n * 1.2)
 .ToArray();
            foreach (var price in prices)
                Console.WriteLine($"{price:f2}");
        }
    }
}