using _02.VehicleExtension.Interfaces;
using System;
using System.Threading;

namespace _02.VehicleExtension.Models
{
    public abstract class Vehicle : IVehicle
    {
        private double fuelQuantity;
        protected Vehicle(double fuelQuantity, double fuelConsumption)
        {

            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;

        }
        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : this(fuelQuantity > tankCapacity ? 0 : fuelQuantity, fuelConsumption)
        {
            this.TankCapacity = tankCapacity;
        }

        public double FuelQuantity
        {
            get
            {
                return this.fuelQuantity;
            }
            protected set
            {


                this.fuelQuantity = value;

            }

        }

        public virtual double FuelConsumption { get; protected set; }

        public double TankCapacity { get; private set; }

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

