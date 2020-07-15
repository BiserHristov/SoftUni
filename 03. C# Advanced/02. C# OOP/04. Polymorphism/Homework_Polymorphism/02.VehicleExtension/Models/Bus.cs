using System;
using System.Collections.Generic;
using System.Text;

namespace _02.VehicleExtension.Models
{
    public class Bus : Vehicle
    {
        private const double FUEL_INCREASE_COEFICIENT = 1.4;
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public string DriveEmpty(double distance)
        {
           return base.Drive(distance);
        }
        public override string Drive(double distance)
        {
            this.FuelConsumption += FUEL_INCREASE_COEFICIENT;
            return base.Drive(distance);
        }
    }
}
