using _04.WildFarm.Factories;
using _04.WildFarm.Interfaces;
using _04.WildFarm.Models.Animal;
using _04.WildFarm.Models.Food;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.WildFarm
{
    class Program
    {
        static void Main(string[] args)
        {

            AnimalFactory animalFactory = new AnimalFactory();
            FoodFactory foodFactory = new FoodFactory();
            StringBuilder sb = new StringBuilder();
            IAnimal animal = null;
            IFood food = null;
            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] animalArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                animal = animalFactory.ProduceAnimal(animalArgs);
                Console.WriteLine(animal.ProduceSound());

                string[] foodArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                food = foodFactory.ProduceFood(foodArgs);

                try
                {
                    animal.Feed(food);

                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }

                sb.AppendLine(animal.ToString());

                continue;
            }

            Console.WriteLine(sb.ToString().Trim());
        }
    }
}
