using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManufacturer
{
    public class Car
    {
        public Car()
        {
            //this.Make = "VW";
            //this.Model = "Golf";
            //this.Year = 2025;
            //this.FuelConsumption = 10;
            //this.FuelQuantity = 200;
        }
        public Car(string make, string model, int year) : this()
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
        }
        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption) : this(make, model, year)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }
        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption, Engine engine, Tire[] tire)
           : this(make, model, year, fuelQuantity, fuelConsumption)
        {
            this.Engine = engine;
            this.Tire = tire;
        }
        private string make;

        public string Make
        {
            get { return this.make; }
            set { this.make = value; }
        }
        private string model;

        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }
        private int year;

        public int Year
        {
            get { return this.year; }
            set { this.year = value; }
        }
        private double fuelQuantity;

        public double FuelQuantity
        {
            get { return this.fuelQuantity; }
            set { this.fuelQuantity = value; }
        }
        private double fuelConsumption;

        public double FuelConsumption
        {
            get { return this.fuelConsumption; }
            set { this.fuelConsumption = value; }
        }
        private Engine engine;
        public Engine Engine
        {
            get { return this.engine; }
            set { this.engine = value; }
        }
        private Tire[] tire;
        public Tire[] Tire
        {
            get { return this.tire; }
            set { this.tire = value; }
        }


        public void Drive(double distance)
        {
            if (distance * fuelConsumption > fuelQuantity)
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
            else
            {
                this.fuelQuantity -= distance * fuelConsumption;
            }
        }
        public double Drive20Kilometers(double fuelQuantity, double fuelConsumption)
        {
            this.fuelQuantity -= (this.FuelConsumption / 100) * 20;

            return this.fuelQuantity;
        }
        public string WhoAmI()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"Make: {this.Make}");
            result.AppendLine($"Model: {this.Model}");
            result.AppendLine($"Year: {this.Year}");
            result.AppendLine($"HorsePowers: {this.Engine.HorsePower}");
            result.AppendLine($"FuelQuantity: {this.FuelQuantity}");

            return result.ToString().Trim();
        }


    }
}

