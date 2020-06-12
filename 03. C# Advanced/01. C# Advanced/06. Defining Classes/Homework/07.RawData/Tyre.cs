using System;
using System.Collections.Generic;
using System.Text;

namespace _07.RawData
{
    public class Tyre
    {
        private int age;
        private double pressure;

        public Tyre(double pressure, int age)
        {
            this.Pressure = pressure;
            this.Age = age;

        }
        public double Pressure
        {
            get { return this.pressure; }
            set { this.pressure = value; }
        }

        public int Age
        {
            get { return this.age; }
            set { this.age = value; }
        }

    }
}
