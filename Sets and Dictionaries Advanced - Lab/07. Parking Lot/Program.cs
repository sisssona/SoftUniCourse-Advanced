namespace _07._Parking_Lot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> parking = new HashSet<string>();
            string input;
            while ((input = Console.ReadLine())!= "END")
            {
                string[] tokens = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string direction = tokens[0];
                string carNumber = tokens[1];
                if (direction == "IN")
                {
                    parking.Add(carNumber);
                }
                if (direction == "OUT")
                {
                    parking.Remove(carNumber);
                }
            }
            if (parking.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            else
            {
                foreach (var carNum in parking)
                {
                    Console.WriteLine(carNum);
                }
            }
        }
    }
}