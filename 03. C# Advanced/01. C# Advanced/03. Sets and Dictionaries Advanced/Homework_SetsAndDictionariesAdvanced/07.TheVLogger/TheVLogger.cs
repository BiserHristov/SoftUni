using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TheVLogger
{
    class TheVLogger
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            //person <"followers"/"following", List of followers/following
            Dictionary<string, Dictionary<string, List<string>>> dict = new Dictionary<string, Dictionary<string, List<string>>>();

            while (input[0] != "Statistics")
            {
                string command = input[1];

                if (command == "joined")
                {
                    if (dict.ContainsKey(input[0]))
                    {
                        input = Console.ReadLine()
             .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                        continue;
                    }

                    dict.Add(input[0], new Dictionary<string, List<string>>());
                    dict[input[0]].Add("following", new List<string>());
                    dict[input[0]].Add("followers", new List<string>());
                }
                else if (command == "followed")
                {
                    if (!dict.ContainsKey(input[0]) || !dict.ContainsKey(input[2]))
                    {
                        input = Console.ReadLine()
                                 .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                        continue;
                    }

                    if (input[0] == input[2])
                    {
                        input = Console.ReadLine()
                                  .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                        continue;
                    }

                    if (dict[input[2]]["followers"].Contains(input[0]))
                    {
                        input = Console.ReadLine()
                                   .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                        continue;
                    }

                    dict[input[0]]["following"].Add(input[2]);
                    dict[input[2]]["followers"].Add(input[0]);
                }

                input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            dict = dict
                .OrderByDescending(x => x.Value["followers"].Count)
                .ThenBy(x => x.Value["following"].Count)
                .ToDictionary(x => x.Key, y => y.Value);

            Console.WriteLine($"The V-Logger has a total of {dict.Keys.Count} vloggers in its logs.");
            int counter = 1;
            foreach (var kvp in dict)
            {
                Console.WriteLine($"{counter}. {kvp.Key} : {kvp.Value["followers"].Count} followers, {kvp.Value["following"].Count} following");
                if (counter == 1)
                {
                    foreach (var item in kvp.Value["followers"].OrderBy(x=>x))
                    {
                        Console.WriteLine($"*  {item}");
                    }
                }
                counter++;
            }
        }
    }
}
