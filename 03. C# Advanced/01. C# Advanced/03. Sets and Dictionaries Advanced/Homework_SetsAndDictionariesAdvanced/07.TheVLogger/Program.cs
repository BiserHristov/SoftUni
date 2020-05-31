using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TheVLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            //<person <followers>
            //Dictionary<string, List<string>> followers = new Dictionary<string, List<string>>();
            //Dictionary<string, int> following = new Dictionary<string, int>();
            Dictionary<string, Dictionary<string, List<string>>> dict = new Dictionary<string, Dictionary<string, List<string>>>();

            while (input[0] != "Statistics")
            {
                string command = input[1];

                if (command == "joined")
                {
                    if (dict.ContainsKey(input[0]))
                    {
                        continue;
                    }

                    dict.Add(input[0], new Dictionary<string, List<string>>());
                    dict[input[0]].Add("following", new List<string>());
                    dict[input[0]].Add("followers", new List<string>());
                }
                //<person <followers, following>>
                else if (command == "followed")
                {
                    //bool areExisting = true;
                    if (!dict.ContainsKey(input[0]) || !dict.ContainsKey(input[2]))
                    {
                        input = Console.ReadLine()
                                 .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                        continue;
                    }

                    // bool isNotFollowingHimself = true;
                    if (input[0] == input[2])
                    {
                        input = Console.ReadLine()
                                  .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                        continue;
                    }

                    // bool isNotAlreadyFollowing = true;
                    if (dict[input[0]]["following"].Contains(input[2]))
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

           // var maxCount = followers.Max(x => x.Value.Count);
            Console.WriteLine($"The V-Logger has a total of {dict.Keys.Count} vloggers in its logs.");
        }
    }
}
