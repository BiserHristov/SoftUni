using _04.BorderControl.Interfaces;
using _04.BorderControl.Models;
using System;
using System.Collections.Generic;

namespace _04.BorderControl.Core
{
    public class Engine
    {
        private List<IIdentifiable> inhabitans;
        public Engine()
        {
            this.inhabitans = new List<IIdentifiable>();
        }
        public void Run()
        {
            string[] args = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            while (args[0] != "End")
            {
                if (args.Length == 3)
                {
                    this.inhabitans.Add(new Citizen(args[0], int.Parse(args[1]), args[2]));
                }
                else
                {
                    this.inhabitans.Add(new Robot(args[0], args[1]));
                }

                args = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            string lastDigits = Console.ReadLine();

            foreach (var inhabitant in inhabitans)
            {
                
                if (inhabitant.Id.EndsWith(lastDigits))
                {
                    Console.WriteLine(inhabitant.Id);
                }
                
            }
        }
    }
}
