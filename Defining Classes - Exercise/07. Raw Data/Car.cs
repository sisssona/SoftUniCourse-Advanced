using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RawData
{
    public class Car
    {
		public Car(string model, int speed, int power, int weight, string type, double tirePressure1, int tireAge1,
           double tirePressure2, int tireAge2, double tirePressure3, int tireAge3, double tirePressure4, int tireAge4)
		{
			Model= model;
			Engine= new Engine(speed, power);
			Cargo = new Cargo(type, weight);
			Tire = new Tires[4];
			Tire[0] = new Tires(tireAge1, tirePressure1);
			Tire[1] = new Tires(tireAge2, tirePressure2);
			Tire[2] = new Tires(tireAge3, tirePressure3);
			Tire[3] = new Tires(tireAge4, tirePressure4);
        }
		private string model;

		public string Model
		{
			get { return model; }
			set { model = value; }
		}
		private Engine engine;

		public Engine Engine
		{
			get { return engine; }
			set { engine = value; }
		}
		private Cargo cargo;

		public Cargo Cargo
		{
			get { return cargo; }
			set { cargo = value; }
		}
		private Tires[] tire;

		public Tires[] Tire
		{
			get { return tire; }
			set { tire = value; }
		}




	}
}
