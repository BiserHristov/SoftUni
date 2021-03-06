﻿namespace _01.Vehicles.Models
{
    public class Car : Vehicle
    {

        private const double FUEL_INCREASE_COEFICIENT = 0.9;
        public Car(double quantity, double fuelConsumption)
            : base(quantity, fuelConsumption)
        {
        }

        public override double FuelConsumption
        {
            get
            {
                return base.FuelConsumption;
            }
            protected set
            {
                base.FuelConsumption = value + FUEL_INCREASE_COEFICIENT;
            }
        }

        
    }
}
