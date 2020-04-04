using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Task_3
{
    class Pirates
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            Dictionary<string, List<long>> city = new Dictionary<string, List<long>>();

            while (line != "Sail")
            {
                List<string> input = line
                    .Split("||", StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Trim())
                    .ToList();
                string name = input[0];
                long population = long.Parse(input[1]);
                long gold = long.Parse(input[2]);

                if (population > 0 && gold > 0)
                {


                    if (!city.ContainsKey(name))
                    {
                        city.Add(name, new List<long>());
                        city[name].Add(population);
                        city[name].Add(gold);

                    }
                    else
                    {
                        city[name][0] += population;
                        city[name][1] += gold;
                    }
                }

                line = Console.ReadLine();
            }

            line = Console.ReadLine();

            while (line != "End")
            {
                List<string> input = line
                    .Split("=>", StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Trim())
                    .ToList();

                string command = input[0];
                string town = input[1];

                if (command == "Plunder")
                {
                    long people = long.Parse(input[2]);
                    long gold = long.Parse(input[3]);


                    if (city.ContainsKey(town))
                    {
                        Console.WriteLine($"{town} plundered! {gold} gold stolen, {people} citizens killed.");
                        city[town][0] -= people;
                        city[town][1] -= gold;
                        if (city[town][0] <= 0 || city[town][1] <= 0)
                        {
                            city.Remove(town);
                            Console.WriteLine($"{town} has been wiped off the map!");

                        }
                    }
                }
                else if (command == "Prosper")
                {
                    long gold = long.Parse(input[2]);

                    if (gold < 0)
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");

                    }
                    else
                    {
                        city[town][1] += gold;
                        Console.WriteLine($"{gold} gold added to the city treasury. {town} now has {city[town][1]} gold.");
                    }
                }



                line = Console.ReadLine();
            }

            if (city.Count > 0)
            {
                var orderedList = city
               .OrderByDescending(x => x.Value[1])
               .ThenBy(k => k.Key)
               .ToList();

                Console.WriteLine($"Ahoy, Captain! There are {orderedList.Count} wealthy settlements to go to:");

                foreach (var kvp in orderedList)
                {
                    Console.WriteLine($"{kvp.Key} -> Population: {kvp.Value[0]} citizens, Gold: {kvp.Value[1]} kg");
                }
            }
            else
            {
                Console.WriteLine($"Ahoy, Captain! All targets have been plundered and destroyed!");
            }



        }
    }
}
