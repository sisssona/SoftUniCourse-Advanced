using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main()
        {
            List<Tire[]> tires = new List<Tire[]>();
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();

            string command;
            while ((command = Console.ReadLine()) != "No more tires")
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var newTire1 = new Tire(int.Parse(tokens[0]), double.Parse(tokens[1]));
                var newTire2 = new Tire(int.Parse(tokens[2]), double.Parse(tokens[3]));
                var newTire3 = new Tire(int.Parse(tokens[4]), double.Parse(tokens[5]));
                var newTire4 = new Tire(int.Parse(tokens[6]), double.Parse(tokens[7]));
                tires.Add(new Tire[] { newTire1, newTire2, newTire3, newTire4 });

            }
            while ((command = Console.ReadLine()) != "Engines done")
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var newEngine = new Engine(int.Parse(tokens[0]), double.Parse(tokens[1]));
                engines.Add(newEngine);
            }

            while ((command = Console.ReadLine()) != "Show special")
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string make = tokens[0];
                string model = tokens[1];
                int year = int.Parse(tokens[2]);
                int fuelQuantity = int.Parse(tokens[3]);
                int fuelConsumption = int.Parse(tokens[4]);
                Engine engine = engines[int.Parse(tokens[5])];
                Tire[] tire = tires[int.Parse(tokens[6])];
                Car car = new Car(make, model, year, fuelQuantity, fuelConsumption,engine,tire);
                cars.Add(car);

            }
            cars = cars
               .Where(x => x.Year >= 2017 && x.Engine.HorsePower > 330 && x.Tire.Sum(y => y.Pressure) >= 9 && x.Tire.Sum(y => y.Pressure) <= 10).ToList();

            if (cars.Any())
            {
                foreach (var car in cars)
                {
                    car.Drive20Kilometers(car.FuelQuantity, car.FuelConsumption);
                    Console.WriteLine(car.WhoAmI());
                }
            }
          





        }
    }
}
