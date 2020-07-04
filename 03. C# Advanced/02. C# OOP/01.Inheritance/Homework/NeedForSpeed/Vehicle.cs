using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {
        public const double DEFAULT_FUEL_CONSUMPTION = 1.25;
        public Vehicle(int horsePower, double fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;
        }
        public int HorsePower { get; set; }
        public double Fuel { get; set; }
        public virtual double FuelConsumption => DEFAULT_FUEL_CONSUMPTION;

        public virtual void Drive(double kilometers)
        {
            double fuelAfterDrive = this.Fuel - kilometers * this.FuelConsumption;
            if (fuelAfterDrive >= 0)
            {
                this.Fuel = fuelAfterDrive;
            }
        }
    }
}
