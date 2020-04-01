using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.CompanyUsers
{
    class CompanyUsers
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, List<string>> dict = new SortedDictionary<string, List<string>>();

            List<string> line = Console.ReadLine()
                .Split(" -> ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            while (line[0] != "End")
            {
                string name = line[0];
                string iD = line[1];

                if (dict.ContainsKey(name))
                {
                    if (!dict[name].Contains(iD))
                    {
                        dict[name].Add(iD);

                    }
                    
                }
                else
                {
                    dict.Add(name, new List<string>());
                    dict[name].Add(iD);
                }

                line = Console.ReadLine()
                .Split(" -> ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            }

            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key}");
                foreach (var id in item.Value)
                {
                    Console.WriteLine($"-- {id}");
                }
            }


        }
    }
}
