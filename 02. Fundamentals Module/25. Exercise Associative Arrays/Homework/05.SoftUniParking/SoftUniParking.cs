using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05.SoftUniParking
{
    class SoftUniParking
    {
        public static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            Dictionary<string, string> dict = new Dictionary<string, string>();

            for (int i = 0; i < count; i++)
            {
                List<string> line = Console.ReadLine()
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                        .ToList();

                string command = line[0];
                string user = line[1];

                if (command == "register")
                {

                    string plate = line[2];

                    if (!dict.ContainsKey(user))
                    {
                        dict.Add(user, plate);
                       Console.WriteLine($"{user} registered {plate} successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {dict[user]}");
                    }
                }
                else if (command == "unregister")
                {
                    if (dict.ContainsKey(user))
                    {
                        dict.Remove(user);
                        Console.WriteLine($"{user} unregistered successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: user {user} not found");
                    }

                }

                


            }

            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key} => {item.Value}");
            }
        
        }
    }
}
