
using _01.Vehicles.Factories;
using _01.Vehicles.Models.Core.Contracts;
using _01.Vehicles.Models.IO.Contracts;

using System;
using System.Linq;

namespace _01.Vehicles.Models.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private VehicleFactory factory;

        public Engine()
        {
            this.factory = new VehicleFactory();

        }
        public Engine(IReader reader, IWriter writer)
            : this()
        {

            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            Vehicle car = GetVehicle();
            Vehicle truck = GetVehicle();

            int count = int.Parse(this.reader.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] input = this.reader.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = input[0];
                string vehicleType = input[1];

                if (command == "Drive")
                {
                    double distance = double.Parse(input[2]);


                    if (vehicleType == "Car")
                    {
                        this.writer.WriteLine(car.Drive(distance));
                    }
                    else if (vehicleType == "Truck")
                    {
                        this.writer.WriteLine(truck.Drive(distance));
                    }

                }
                else if (command == "Refuel")
                {
                    double litres = double.Parse(input[2]);

                    if (vehicleType == "Car")
                    {
                        car.Refuel(litres);
                    }
                    else if (vehicleType == "Truck")
                    {
                        truck.Refuel(litres);
                    }

                }


            }


            this.writer.WriteLine(car.ToString());
            this.writer.WriteLine($"Truck: {truck.FuelQuantity:F2}");
        }

        private Vehicle GetVehicle()
        {
            string[] input = this.reader.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            string type = input[0];
            double fuelQnty = double.Parse(input[1]);
            double fuelConsumption = double.Parse(input[2]);
            return this.factory.ProduceVehicle(type, fuelQnty, fuelConsumption);
        }


    }
}
