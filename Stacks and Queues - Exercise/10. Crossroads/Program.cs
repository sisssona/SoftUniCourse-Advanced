namespace _10._Crossroads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int greenLightSeconds = int.Parse(Console.ReadLine());  
            int freeWindowSeconds = int.Parse(Console.ReadLine());

            string command = Console.ReadLine();
            int passedCars = 0;

            Queue<string> cars = new Queue<string>();

            while (command != "END")
            {
                if (command != "green")
                {
                    cars.Enqueue(command);
                    command= Console.ReadLine();
                    continue;
                }
                int currentGreenLightSeconds = greenLightSeconds;
                while (cars.Count > 0 && currentGreenLightSeconds > 0)
                {
                    string currentCar = cars.Dequeue();
                    if (currentGreenLightSeconds - currentCar.Length > 0)
                    {
                        currentGreenLightSeconds -= currentCar.Length;
                        passedCars++;
                        continue;
                    }
                    else if (currentGreenLightSeconds + freeWindowSeconds - currentCar.Length >= 0)
                    {
                        passedCars++;
                        break;
                    }
                    else
                    {
                        char hittedSymbol = currentCar[currentGreenLightSeconds + freeWindowSeconds];
                        Console.WriteLine("A crash happened!");
                        Console.WriteLine($"{currentCar} was hit at {hittedSymbol}.");
                        Environment.Exit(0); // return / use flags - boolean -> true or false
                    }
                }
                command= Console.ReadLine();
            }
            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{passedCars} total cars passed the crossroads.");
        }
    }
}