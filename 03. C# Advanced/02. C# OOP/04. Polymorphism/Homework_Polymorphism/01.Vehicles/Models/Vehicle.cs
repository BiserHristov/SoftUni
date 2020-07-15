using _01.Vehicles.Interfaces;

namespace _01.Vehicles.Models
{
    public abstract class Vehicle : IVehicle
    {
        protected Vehicle(double quantity, double fuelConsumption)
        {

            this.FuelQuantity = quantity;
            this.FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity { get; private set; }

        public virtual double FuelConsumption { get; protected set; }

        public string Drive(double distance)
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
            if (litres > 0)
            {
                this.FuelQuantity += litres;
            }
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }
    }



}

