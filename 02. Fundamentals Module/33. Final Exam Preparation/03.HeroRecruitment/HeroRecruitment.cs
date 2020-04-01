using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.HeroRecruitment
{
    class HeroRecruitment
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();

            Dictionary<string, List<string>> heros = new Dictionary<string, List<string>>();

            while (line != "End")
            {
                List<string> input = line
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Trim())
                    .ToList();
                string command = input[0];
                string heroName = input[1];

                if (command == "Enroll")
                {
                    if (!heros.ContainsKey(heroName))
                    {
                        heros.Add(heroName, new List<string>());
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} is already enrolled.");
                    }

                }
                else if (command == "Learn")
                {
                    string spellName = input[2];

                    if (!heros.ContainsKey(heroName))
                    {
                        Console.WriteLine($"{heroName} doesn't exist.");
                    }
                    else if (heros[heroName].Contains(spellName))
                    {
                        Console.WriteLine($"{heroName} has already learnt {spellName}.");
                    }
                    else
                    {
                        heros[heroName].Add(spellName);
                    }

                }
                else if (command == "Unlearn")
                {
                    string spellName = input[2];

                    if (!heros.ContainsKey(heroName))
                    {
                        Console.WriteLine($"{heroName} doesn't exist.");
                    }
                    else if (!heros[heroName].Contains(spellName))
                    {
                        Console.WriteLine($"{heroName} doesn't know {spellName}.");
                    }
                    else
                    {
                        //remove all
                        heros[heroName].Remove(spellName);
                    }
                }

                line = Console.ReadLine();
            }

            var sorted = heros
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key)
                .ToList();

            Console.WriteLine("Heros:");
            foreach (var hero in sorted)
            {
                
                Console.Write($"== {hero.Key}: {string.Join(", ", hero.Value)}\n");

            }

        }
    }
}
