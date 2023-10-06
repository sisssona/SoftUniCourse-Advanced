using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManufacturer
{
    public class Engine
    {
        public Engine(int horsePowr, double cubicCapacity)
        {
            this.HorsePower = horsePowr;
            this.CubicCapacity = cubicCapacity;
        }
        private int horsePower;

        public int HorsePower
        {
            get { return this.horsePower; }
            set { this.horsePower = value; }
        }
        private double cubicCapacity;

        public double CubicCapacity
        {
            get { return this.cubicCapacity; }
            set { this.cubicCapacity = value; }
        }


    }
}
