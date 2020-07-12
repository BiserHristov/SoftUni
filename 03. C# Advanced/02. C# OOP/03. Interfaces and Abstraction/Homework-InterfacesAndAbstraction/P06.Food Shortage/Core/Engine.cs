
using _06.FoodShortage.Interfaces;
using _06.FoodShortage.Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace _06.FoodShortage
{
    public class Engine
    {
        private List<IBuyer> inhabitans;
        public Engine()
        {
            this.inhabitans = new List<IBuyer>();
        }
        public void Run()
        {
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] args = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (args.Length == 4)
                {
                    string name = args[0];
                    string age = args[1];
                    string id = args[2];
                    string date = args[3];
                    Citizen citizen = new Citizen(name, age, id, date);
                    inhabitans.Add(citizen);
                }
                else if (args.Length == 3)
                {
                    string name = args[0];
                    string age = args[1];
                    string group = args[2];
                    Rebel rebel = new Rebel(name, age, group);
                    inhabitans.Add(rebel);
                }
            }

            string currentName = Console.ReadLine();
            int sum = 0;

            while (currentName != "End")
            {
                IBuyer inhabitant = inhabitans.Where(x => x.Name == currentName).FirstOrDefault();

                if (inhabitant != null)
                {
                    int currentFood = inhabitant.Food;
                    inhabitant.BuyFood();
                    sum += inhabitant.Food - currentFood;
                }

                currentName = Console.ReadLine();
            }

            Console.WriteLine(sum);

        }
    }
}
