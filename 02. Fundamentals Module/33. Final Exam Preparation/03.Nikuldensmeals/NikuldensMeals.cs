using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Nikuldensmeals
{
    class NikuldensMeals
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();

            string line = Console.ReadLine();
            int unlikedMeals = 0;

            while (line != "Stop")
            {
                List<string> input = line
                    .Split("-", StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Trim())
                    .ToList();

                string command = input[0];
                string guest = input[1];
                string meal = input[2];

                if (command=="Like")
                {
                    if (!dict.ContainsKey(guest))
                    {
                        dict.Add(guest, new List<string>());
                        dict[guest].Add(meal);
                    }
                    else if (!dict[guest].Contains(meal))
                    {
                        dict[guest].Add(meal);

                    }

                }
                else if (command=="Unlike")
                {
                    if (!dict.ContainsKey(guest))
                    {
                        Console.WriteLine($"{guest} is not at the party.");
                    }
                    else if (!dict[guest].Contains(meal))
                    {
                        Console.WriteLine($"{guest} doesn't have the {meal} in his/her collection.");
                    }
                    else
                    {
                        unlikedMeals++;
                        dict[guest].Remove(meal);
                        Console.WriteLine($"{guest} doesn't like the {meal}.");

                    }
                }


                line = Console.ReadLine();
            }

            var orderedList = dict
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key)
                .ToList();

            foreach (var kvp in orderedList)
            {
                Console.WriteLine($"{kvp.Key}: {string.Join(", ", kvp.Value)}");
                
            }
            Console.WriteLine($"Unliked meals: {unlikedMeals}");
        }
    }
}
