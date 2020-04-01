using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.InboxManager
{
    class InboxManager
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();

            string line = Console.ReadLine();

            while (line != "Statistics")
            {
                List<string> input = line
                    .Split("->", StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Trim())
                    .ToList();

                string command = input[0];
                string username = input[1];

                if (command == "Add")
                {
                    if (dict.ContainsKey(username))
                    {
                        Console.WriteLine($"{ username} is already registered");
                    }
                    else
                    {
                        dict.Add(username, new List<string>());
                    }
                }
                else if (command == "Send")
                {
                    if (dict.ContainsKey(username))
                    {
                        dict[username].Add(input[2]);
                    }

                }
                else if (command == "Delete")
                {
                    if (!dict.ContainsKey(username))
                    {
                        Console.WriteLine($"{username} not found!");
                    }
                    else
                    {
                        dict.Remove(username);
                    }
                }

                line = Console.ReadLine();

               
            }

            var ordered = dict
                   .OrderByDescending(x => x.Value.Count)
                   .ThenBy(x => x.Key)
                   .ToList();

            Console.WriteLine($"Users count: {dict.Values.Count}");

            foreach (var user in ordered)
            {
                Console.WriteLine($"{user.Key}");

                foreach (var mail in user.Value)
                {
                    Console.WriteLine($" - {mail}");

                }
            }
        }
    }
}
