using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Judge
{
    class Judge
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, Dictionary<string, int>> dict = new Dictionary<string, Dictionary<string, int>>();


            while (input != "no more time")
            {
                List<string> line = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries).ToList();
                string username = line[0];
                string contest = line[1];
                int points = int.Parse(line[2]);

                if (!dict.ContainsKey(username))
                {
                    dict.Add(username, new Dictionary<string, int>());
                    dict[username].Add(contest, points);
                }
                else
                {
                    if (!dict[username].ContainsKey(contest))
                    {
                        dict[username].Add(contest, points);
                    }
                    else
                    {
                        if (dict[username][contest] < points)
                        {
                            dict[username][contest] = points;
                        }
                    }

                }

                input = Console.ReadLine();
            }



            Dictionary<string, Dictionary<string, int>> contestUserPoints = new Dictionary<string, Dictionary<string, int>>();
           
            foreach (var item in dict)
            {
                foreach (var contest in item.Value.Keys)
                {
                    if (!contestUserPoints.ContainsKey(contest))
                    {
                        contestUserPoints.Add(contest, new Dictionary<string, int>());
                        contestUserPoints[contest].Add(item.Key, item.Value[contest]);
                    }
                    else
                    {
                        contestUserPoints[contest].Add(item.Key, item.Value[contest]);
                    }

                }
            }
            //user(contest,points)

        

            foreach (var item in contestUserPoints)
            {
                int counter = 1;

                Console.WriteLine($"{item.Key}: {item.Value.Keys.Count()} participants");

                var orderedList = item.Value
                    .OrderByDescending(x => x.Value)
                    .ThenBy(x => x.Key)
                    .ToDictionary(x => x.Key, x => x.Value);

                foreach (var user in orderedList)
                {
                    Console.WriteLine($"{counter}. {user.Key} <::> {user.Value}");
                    counter++;
                }


            }

     


            Dictionary<string, int> namePoints = new Dictionary<string, int>();

            foreach (var item in dict)
            {

                if (!namePoints.ContainsKey(item.Key))
                {
                    namePoints.Add(item.Key, 0);

                }
                namePoints[item.Key] += item.Value.Values.Sum();
            }

            Console.WriteLine("Individual standings:");
            int individualCounter = 1;
            foreach (var item in namePoints.OrderByDescending(x => x.Value).ThenBy(k => k.Key))
            {
                Console.WriteLine($"{individualCounter}. {item.Key} -> {item.Value}");
                individualCounter++;

            }



        }
    }
}
