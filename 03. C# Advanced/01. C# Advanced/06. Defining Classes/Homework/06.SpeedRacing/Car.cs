using System;
using System.Collections.Generic;
using System.Text;

namespace _06.SpeedRacing
{
    public class Car
    {
        private string model;
        private double fuelAmount;
        private double fuelConsumptionPerKm;
        private double travelledDistance;

        public Car(string model, double fuelAmount, double fuelConsumptionPerKm)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKm = fuelConsumptionPerKm;
            this.TravelledDistance = 0;
        }
        public double TravelledDistance
        {
            get { return this.travelledDistance; }
            set { this.travelledDistance = value; }
        }

        public double FuelConsumptionPerKm
        {
            get { return this.fuelConsumptionPerKm; }
            set { this.fuelConsumptionPerKm = value; }
        }

        public double FuelAmount
        {
            get { return this.fuelAmount; }
            set { fuelAmount = value; }
        }


        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }


        public void MoveDistance(double distance)
        {
            if (distance * this.FuelConsumptionPerKm > this.FuelAmount)
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
            else
            {
                this.FuelAmount -= distance * this.FuelConsumptionPerKm;
                this.TravelledDistance += distance;
            }
        }
    }
}
