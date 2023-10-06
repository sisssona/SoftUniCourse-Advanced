using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;

namespace RawData
{
    public class Program
    {
        static void Main(string[] args)
        {
           int numberOfCars = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for (int i = 0; i < numberOfCars; i++)
            {
                string[] carInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Car car = new Car(carInfo[0], int.Parse(carInfo[1]), int.Parse(carInfo[2]), int.Parse(carInfo[3]), carInfo[4],
                    double.Parse(carInfo[5]), int.Parse(carInfo[6]), double.Parse(carInfo[7]), int.Parse(carInfo[8]), double.Parse(carInfo[9]),
                   int.Parse(carInfo[10]), double.Parse(carInfo[11]), int.Parse(carInfo[12]));
                cars.Add(car);
                //"{model} {engineSpeed} {enginePower} {cargoWeight} {cargoType} {tire1Pressure} {tire1Age} {tire2Pressure}
                //{tire2Age} {tire3Pressure} {tire3Age} {tire4Pressure} {tire4Age}"
            }
            string command = Console.ReadLine();
            if (command == "fragile")
            {
                foreach (Car car in cars.Where(c => c.Cargo.Type == "fragile" && c.Tire.Any(p => p.Pressure < 1))) 
                {
                    Console.Write($"{car.Model} ");
                    Console.WriteLine();
                }
            }
            else if (command == "flammable")
            {
                foreach (Car car in cars.Where(c => c.Cargo.Type == "flammable" && c.Engine.Power > 250))
                {
                    Console.Write($"{car.Model} ");
                    Console.WriteLine();
                }
            }

            //•	"fragile" - print all cars, whose cargo is "fragile" and have a pressure of a single tire < 1.
            //	"flammable" - print all cars, whose cargo is "flammable" and have engine power > 250.

        }
    }
}