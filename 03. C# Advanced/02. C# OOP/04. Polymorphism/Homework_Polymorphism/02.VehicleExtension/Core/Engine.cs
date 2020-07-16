using _02.VehicleExtension.Factories;
using _02.VehicleExtension.Models.Core.Contracts;
using _02.VehicleExtension.Models.IO.Contracts;

using System;
using System.Linq;

namespace _02.VehicleExtension.Models.Core
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

            Car car = (Car)GetVehicle();
            Truck truck = (Truck)GetVehicle();
            Bus bus =(Bus) GetVehicle();

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
                    else if (vehicleType == "Bus")
                    {
                        this.writer.WriteLine(bus.Drive(distance));
                    }

                }
              
                else if (command == "Refuel")
                {
                    try
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
                        else if (vehicleType == "Bus")
                        {
                            bus.Refuel(litres);
                        }
                    }
                    catch (ArgumentException ae)
                    {
                        this.writer.WriteLine(ae.Message);
                    }
 


                }
                else if (command == "DriveEmpty")
                {
                    double distance = double.Parse(input[2]);
                    this.writer.WriteLine(bus.DriveEmpty(distance));
                }


            }


            this.writer.WriteLine(car.ToString());
            this.writer.WriteLine(truck.ToString());
            this.writer.WriteLine(bus.ToString());

            

        }

        private Vehicle GetVehicle()
        {
            string[] input = this.reader.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            string type = input[0];
            double fuelQnty = double.Parse(input[1]);
            double fuelConsumption = double.Parse(input[2]);
            int tankCapacity = int.Parse(input[3]);

            return this.factory.ProduceVehicle(type, fuelQnty, fuelConsumption, tankCapacity);
        }


    }
}
