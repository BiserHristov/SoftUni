using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06.VehicleCatalogue
{
    class Program
    {
        static void Main()
        {
            //            You have to create a vehicle catalogue.You will store only two types of vehicles – a car and a truck.Until you receive the “End” command you will be receiving lines of input in the following format:
            //            { typeOfVehicle}
            //            { model}
            //            { color}
            //            { horsepower}
            //            After the “End” command, you will start receiving models of vehicles.Print the data for every received vehicle in the following format:
            //Type: { typeOfVehicle}
            //            Model: { modelOfVehicle}
            //            Color: { colorOfVehicle}
            //            Horsepower: { horsepowerOfVehicle}

            //            When you receive the command “Close the Catalogue”, print the average horsepower for the cars and for the trucks in the following format:
            //{ typeOfVehicles}
            //            have average horsepower of { averageHorsepower}.
            //The average horsepower is calculated by dividing the sum of the horsepower of all vehicles from the certain type by the total count of vehicles from the same type.Round the answer to the 2nd digit after the decimal separator.

            string command = Console.ReadLine();
            List<Vehicle> allVehicles = new List<Vehicle>();

            while (command != "End")
            {
                List<string> line = command.Split().ToList();
                string type = line[0];
                string model = line[1];
                string color = line[2];
                double horsePower = double.Parse(line[3]);

                Vehicle vehicle = new Vehicle(type, model, color, horsePower);
                allVehicles.Add(vehicle);

                command = Console.ReadLine();
            }

            string currentModel = Console.ReadLine();
            while (currentModel != "Close the Catalogue")
            {
                Vehicle vehicle = allVehicles.Find(x => x.Model == currentModel);
                Console.WriteLine(vehicle.ToString());

                currentModel = Console.ReadLine();
            }

            List<double> carHorsePowers = allVehicles
                .Where(x => x.Type == "car")
                .Select(x => x.HorsePower)
                .ToList();


            List<double> trucksHorsePowers = allVehicles
                .Where(x => x.Type == "truck")
                .Select(x => x.HorsePower)
                .ToList();

            double averageCarHorsePower = carHorsePowers.Count > 0 ? carHorsePowers.Average() : 0;
            double averageTruckHorsePower = trucksHorsePowers.Count > 0 ? trucksHorsePowers.Average() : 0;

            Console.WriteLine($"Cars have average horsepower of: {averageCarHorsePower:F2}.");
            Console.WriteLine($"Trucks have average horsepower of: {averageTruckHorsePower:F2}.");
        }
    }

    class Vehicle
    {
        public Vehicle(string type, string model, string color, double horsePower)
        {
            this.Type = type;
            this.Model = model;
            this.Color = color;
            this.HorsePower = horsePower;
        }

        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public double HorsePower { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Type: {char.ToUpper(this.Type[0]) + this.Type.Substring(1)}");
            sb.AppendLine($"Model: {char.ToUpper(this.Model[0]) + this.Model.Substring(1)}");
            sb.AppendLine($"Color: {this.Color}");
            sb.Append($"Horsepower: {this.HorsePower}");

            return sb.ToString();
        }
    }
}
