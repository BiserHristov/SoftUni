using _02.VehicleExtension.Interfaces;
using System;

namespace _02.VehicleExtension.Models
{
    public abstract class Vehicle : IVehicle
    {
        private double fuelQuantity;
        protected Vehicle(double fuelQuantity, double fuelConsumption, int tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;

        }
        

        public double FuelQuantity
        {
            get
            {
                return this.fuelQuantity;
            }
            protected set
            {
                if (value > this.TankCapacity)
                {
                    this.fuelQuantity = 0;
                }
                else
                {

                    this.fuelQuantity = value;
                }


            }

        }

        public  double FuelConsumption { get; protected set; }

        public int TankCapacity { get; private set; }

        public virtual string Drive(double distance)
        {
            if (this.FuelQuantity - distance * this.FuelConsumption >= 0)
            {
                this.FuelQuantity -= distance * this.FuelConsumption;
                return $"{this.GetType().Name} travelled {distance} km";

            }

            return $"{this.GetType().Name} needs refueling";
        }


        public virtual void Refuel(double litres)
        {
            if (litres <= 0)
            {
                throw new ArgumentException($"Fuel must be a positive number");
            }

            if (this.fuelQuantity + litres > this.TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {litres} fuel in the tank");
            }

            this.FuelQuantity += litres;

        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }
    }



}

