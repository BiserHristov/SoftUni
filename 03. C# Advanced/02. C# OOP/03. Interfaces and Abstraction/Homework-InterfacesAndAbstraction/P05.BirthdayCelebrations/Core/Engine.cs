
using _05.BirthdayCelebrations.Interfaces;
using _05.BirthdayCelebrations.Models;
using System;
using System.Collections.Generic;

namespace _05.BirthdayCelebrations
{
    public class Engine
    {
        private List<IBirthable> inhabitans;
        public Engine()
        {
            this.inhabitans = new List<IBirthable>();
        }
        public void Run()
        {
            string[] args = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            while (args[0] != "End")
            {
                if (args[0] == "Citizen")
                {
                    string name = args[1];
                    string age = args[2];
                    string id = args[3];
                    string date = args[4];
                    Citizen citizen = new Citizen(name, age, id, date);
                    inhabitans.Add(citizen);
                }
                else if (args[0] == "Pet")
                {
                    string name = args[1];
                    string date = args[2];
                    Pet pet = new Pet(name, date);
                    inhabitans.Add(pet);
                }

                args = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            string year = Console.ReadLine();

            foreach (var inhabitant in inhabitans)
            {

                if (inhabitant.Birthdate.EndsWith(year))
                {
                    Console.WriteLine(inhabitant.Birthdate);
                }

            }
        }
    }
}
