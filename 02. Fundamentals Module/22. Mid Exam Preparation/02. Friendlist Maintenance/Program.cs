using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Friendlist_Maintenance
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(s => s.Trim())
                .ToList();

            string line = Console.ReadLine();

            while (line != "Report")
            {
                List<string> command = line.Split().ToList();
                string action = command[0];
                if (action == "Blacklist")
                {
                    string name = command[1];
                    if (!list.Contains(name))
                    {
                        Console.WriteLine($"{name} was not found.");
                    }
                    else
                    {
                        list[list.IndexOf(name)] = "Blacklisted";
                        Console.WriteLine($"{name} was blacklisted.");
                    }

                }
                else if (action == "Error")
                {
                    int index = int.Parse(command[1]);

                    if (list[index] != "Blacklisted" && list[index] != "Lost")
                    {
                        string name = list[index];
                        list[index] = "Lost";
                        Console.WriteLine($"{name} was lost due to an error.");
                    }
                }
                else if (action == "Change")
                {
                    int index = int.Parse(command[1]);
                    string newName = command[2];
                    if (index >= 0 && index <= list.Count - 1)
                    {
                        string currentName = list[index];
                        list[index] = newName;
                        Console.WriteLine($"{currentName} changed his username to {newName}.");
                    }
                }

                line = Console.ReadLine();

            }
            int blacklistedCount = list.Where(x => x.Contains("Blacklisted")).Count();
            int lostCount = list.Where(x => x.Contains("Lost")).Count();

            Console.WriteLine($"Blacklisted names: {blacklistedCount}");
            Console.WriteLine($"Lost names: {lostCount}");
            Console.WriteLine(string.Join(' ',list ));

        }
    }
}
