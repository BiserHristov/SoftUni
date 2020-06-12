using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.RawData
{
    public class StartUp
    {
        public static void Main()
        {
            int count = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                //"{model} {engineSpeed} {enginePower} {cargoWeight} {cargoType} " +
                //    "{tire1Pressure} {tire1Age} {tire2Pressure} {tire2Age} {tire3Pressure} {tire3Age} {tire4Pressure} {tire4Age}"
                string model = input[0];
                int engineSpeed = int.Parse(input[1]);
                int enginePower = int.Parse(input[2]);
                int cargoWeight = int.Parse(input[3]);
                string cargoType = input[4];
                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoWeight, cargoType);
                Car car = new Car(model, engine, cargo);

                for (int j = 5; j < 13; j += 2)
                {

                    Tyre tyre = new Tyre(double.Parse(input[j]), int.Parse(input[j + 1]));
                    car.Tyres.Add(tyre);
                }

                cars.Add(car);
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                cars = cars
                    .Where(c => c.Cargo.Type == command)
                    .Where(x => x.Tyres.Any(p => p.Pressure < 1))
                    .ToList();
                    
                    

            }
            else if (command == "flamable")
            {
                cars = cars
                  .Where(c => c.Cargo.Type == command)
                  .Where(x => x.Engine.Power > 250)
                  .ToList();
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car.Model);
            }
        }
    }
}
