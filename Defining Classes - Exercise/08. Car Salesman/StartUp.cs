using System;
using System.Collections.Generic;


namespace CarSalesman
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int engineLines = int.Parse(Console.ReadLine());
            List<Engine> engines = new List<Engine>();

            for (int i = 0; i < engineLines; i++)
            {
                string[] engineInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Engine engine = new Engine(engineInfo[0], int.Parse(engineInfo[1]));
                if (engineInfo.Length > 2)
                {
                    int displacement;

                    bool isDigit = int.TryParse(engineInfo[2], out displacement);

                    if (isDigit)
                    {
                        engine.Displacement = displacement;
                    }
                    else
                    {
                        engine.Efficiency = engineInfo[2];
                    }

                    if (engineInfo.Length > 3)
                    {
                        engine.Efficiency = engineInfo[3];
                    }
                }

                engines.Add(engine);

                //"{model} {power} {displacement} {efficiency}"
            }

            int carLines = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for (int i = 0; i < carLines; i++)
            {
                string[] carInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string engineModel = carInfo[1];
                Engine engine = engines.Find(x => x.Model == carInfo[1]);
                Car car = new Car(carInfo[0], engine);
                if (carInfo.Length > 2)
                {
                    int weight;

                    bool isDigit = int.TryParse(carInfo[2], out weight);

                    if (isDigit)
                    {
                        car.Weight = weight;
                    }
                    else
                    {
                        car.Color = carInfo[2];
                    }

                    if (carInfo.Length > 3)
                    {
                        car.Color = carInfo[3];
                    }
                }
                cars.Add(car);

                //"{model} {engine} {weight} {color}".
            }
            foreach (var car in cars)
            {
                Console.WriteLine(car.ToString());
            }              
        }
    }
}