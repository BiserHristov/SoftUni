using _02.VehicleExtension.Models;
using System;

namespace _02.VehicleExtension.Factories
{
    public class VehicleFactory
    {
        public Vehicle ProduceVehicle(string type, double fuelQty, double fuelConsumption)
        {
            Vehicle vehicle = null;

            if (type == "Car")
            {
                vehicle = new Car(fuelQty, fuelConsumption);

            }
            else if (type == "Truck")
            {
                vehicle = new Truck(fuelQty, fuelConsumption);

            }

            if (vehicle != null)
            {
                return vehicle;
            }
            else
            {
                throw new ArgumentException("Invalid type!");
            }
        }
    }
}
