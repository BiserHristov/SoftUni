using System;
using System.Collections.Generic;
using System.Linq;

namespace BiscuitFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> cards = Console.ReadLine().Split(':', StringSplitOptions.RemoveEmptyEntries).ToList();

            List<string> result = new List<string>();

            string line = Console.ReadLine();

            while (line != "Ready")
            {
                List<string> command = line.Split().ToList();

                string action = command[0];

                if (action == "Add")
                {
                    if (!cards.Contains(command[1]))
                    {
                        Console.WriteLine("Card not found.");
                        line = Console.ReadLine();
                        continue;
                    }

                    result.Add(command[1]);
                }
                else if (action == "Insert")
                {
                    if (!cards.Contains(command[1]) || int.Parse(command[2]) < 0 || int.Parse(command[2]) > result.Count - 1)
                    {
                        Console.WriteLine("Error!");
                        line = Console.ReadLine();
                        continue;
                    }
                    result.Insert(int.Parse(command[2]), command[1]);
                }
                else if (action=="Remove")
                {
                    if (!result.Contains(command[1]))
                    {
                        Console.WriteLine("Card not found.");
                        line = Console.ReadLine();
                        continue;
                    }
                    result.Remove(command[1]);
                }
                else if (action=="Swap")
                {
                    int index1 = result.IndexOf(command[1]);
                    string cardName = result[index1];
                    int index2 = result.IndexOf(command[2]);
                    string cardName2 = result[index2];

                    result[index1] = cardName2;
                    result[index2] = cardName;
                    line = Console.ReadLine();
                    continue;


                }
                else if (action== "Shuffle")
                {
                    result.Reverse();
                    line = Console.ReadLine();
                    continue;
                }
                line = Console.ReadLine();

            }

            Console.WriteLine(string.Join(' ', result));
        }
    }
}
