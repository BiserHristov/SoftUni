using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.CarsSalesman
{
    public class StartUp
    {
        public static void Main(string[] args)
        {

            int engineCount = int.Parse(Console.ReadLine());
            List<Engine> engineList = new List<Engine>();

            for (int i = 0; i < engineCount; i++)
            {
                string[] data = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string model = data[0];
                int power = int.Parse(data[1]);
                int displacement = 0;
                string efficiency = string.Empty;
                Engine engine = new Engine(model, power);

                if (data.Length == 4)
                {
                    displacement = int.Parse(data[2]);
                    efficiency = data[3];
                    engine.Displacement = displacement;
                    engine.Efficiency = efficiency;
                }
                else if (data.Length == 3)
                {
                    if (int.TryParse(data[2], out displacement))
                    {
                        engine.Displacement = displacement;
                    }
                    else
                    {
                        engine.Efficiency = data[2];
                    }
                }

                engineList.Add(engine);

            }


            int carCout = int.Parse(Console.ReadLine());
            List<Car> carList = new List<Car>();

            for (int i = 0; i < carCout; i++)
            {
                string[] data = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string carModel = data[0];
                string engineModel = data[1];
                int weight = -1;
                string color = string.Empty;
                Engine engine = engineList.Where(e => e.Model == engineModel).FirstOrDefault();
                Car car = new Car(carModel, engine);

                if (data.Length == 4)
                {
                    weight = int.Parse(data[2]);
                    color = data[3];
                    car.Weight = weight;
                    car.Color = color;
                }
                else if (data.Length == 3)
                {

                    if (int.TryParse(data[2], out weight))
                    {
                        car.Weight = weight;
                    }
                    else
                    {
                        car.Color = data[2];
                    }

                }

                carList.Add(car);

            }

            foreach (var car in carList)
            {
                Console.WriteLine(car.ToString());
            }
        }
    }
}
