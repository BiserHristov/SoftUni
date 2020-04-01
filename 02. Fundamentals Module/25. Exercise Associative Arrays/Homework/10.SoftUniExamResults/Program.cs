using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.SoftUniExamResults
{
    class Program
    {
        static void Main(string[] args)

        {
            string input = Console.ReadLine();

            Dictionary<string, Dictionary<string, int>> dict = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, int> submissions = new Dictionary<string, int>();


            while (input != "exam finished")
            {
                //2submission with same language and points?

                List<string> line = input
                        .Split('-', StringSplitOptions.RemoveEmptyEntries)
                        .ToList();

                string username = line[0];

                if (line[1] == "banned")
                {
                    if (dict.ContainsKey(username))
                    {
                        dict.Remove(username);
                    }

                    input = Console.ReadLine();
                    continue;
                }


                string language = line[1];
                int points = int.Parse(line[2]);

                if (dict.ContainsKey(username))
                {
                    if (dict[username].ContainsKey(language))
                    {
                        if (dict[username][language] < points)
                        {
                            dict[username][language] = points;
                    
                        }
                    }
                    else
                    {
                        dict[username].Add(language, points);
                    }


                }
                else
                {
                    dict.Add(username, new Dictionary<string, int>());
                    dict[username].Add(language, points);
             
                }

                if (submissions.ContainsKey(language))
                {
                    submissions[language]++;
                }
                else
                {
                    submissions.Add(language, 1);
                }



                input = Console.ReadLine();
            }

            dict = dict
                  .OrderByDescending(x => x.Value.Sum(y=>y.Value))
                  .ThenBy(x => x.Key)
                  .ToDictionary(y => y.Key, y => y.Value);

            Console.WriteLine("Results:");
            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key} | {item.Value.Max().Value}");
            }

            submissions = submissions
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .ToDictionary(y => y.Key, y => y.Value);

            Console.WriteLine("Submissions:");
            foreach (var item in submissions)
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
        }


    }
}
