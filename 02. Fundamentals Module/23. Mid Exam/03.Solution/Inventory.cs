using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace _03.Solution
{
    class Inventory
    {
        static void Main()
        {
            List<string> items = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .ToList();

            string line = Console.ReadLine();

            while (line != "Craft!")
            {
                List<string> command = line.Split(" - ").ToList();
                string action = command[0];

                if (action == "Collect")
                {
                    string item = command[1];
                    if (!items.Contains(item))
                    {
                        items.Add(item);
                    }
                }
                else if (action == "Drop")
                {
                    string item = command[1];
                    if (items.Contains(item))
                    {
                        items.Remove(item);
                    }

                }
                else if (action == "Combine Items")
                {
                    List<string> oldNewItem = command[1].Split(':').ToList();
                    string oldItem = oldNewItem[0];
                    string newItem = oldNewItem[1];
                    int oldItemIndex = items.IndexOf(oldItem);

                    if (oldItemIndex == items.Count - 1)
                    {
                        items.Add(newItem);

                    }
                    else if (oldItemIndex >= 0 && oldItemIndex < items.Count - 1)
                    {
                        items.Insert(oldItemIndex + 1, newItem);
                    }
                }
                else if (action== "Renew")
                {
                    string item = command[1];

                    if (items.Contains(item))
                    {
                        items.Remove(item);
                        items.Add(item);

                    }
                }

                line = Console.ReadLine();

            }

            Console.WriteLine(string.Join(", ", items));
        }
    }
}
