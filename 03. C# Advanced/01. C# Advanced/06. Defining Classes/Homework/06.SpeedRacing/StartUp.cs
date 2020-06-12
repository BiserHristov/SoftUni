using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.SpeedRacing
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = input[0];
                double fuelAmount = double.Parse(input[1]);
                double fuelConsumption = double.Parse(input[2]);
                Car car = new Car(model, fuelAmount, fuelConsumption);
                cars.Add(car);


            }

            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] input = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = input[1];
                double distance = double.Parse(input[2]);
                Car car = cars.Where(c => c.Model == model).FirstOrDefault();
                car.MoveDistance(distance);

                command = Console.ReadLine();
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.TravelledDistance}");
            }


        }
    }
}
