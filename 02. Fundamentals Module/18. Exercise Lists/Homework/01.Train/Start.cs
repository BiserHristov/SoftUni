using System;
using System.Collections.Generic;
using System.Linq;

namespace Lists
{
    class Start
    {
        static void Main()
        {
            //            You will receive a list of wagons(integers) on the first line. Every integer represents the number of passengers that are currently in each of the wagons. On the next line, you will get the max capacity of each wagon(a single integer). Until you receive "end" you will be given two types of input:
            //•	Add { passengers} – add a wagon to the end with the given number of passengers.
            //•	{ passengers}
            //            -find an existing wagon to fit every passenger, starting from the first wagon.
            //At the end print the final state of the train(each of the wagons, separated by a space).

            List<int> wagons = Console.ReadLine()
                                        .Split()
                                        .Select(int.Parse)
                                        .ToList();
            int maxCount = int.Parse(Console.ReadLine());

            List<string> command = Console.ReadLine().Split().ToList();

            while (command[0] != "end")
            {
                if (command.Count == 2)
                {
                    wagons.Add(int.Parse(command[1]));

                }
                else
                {
                    for (int i = 0; i < wagons.Count; i++)
                    {
                        if (int.Parse(command[0]) + wagons[i] <= maxCount)
                        {
                            wagons[i] += int.Parse(command[0]);
                            break;
                        }
                    }
                }

                command = Console.ReadLine().Split().ToList();

            }

            Console.WriteLine(string.Join(" ", wagons));
        }
    }
}
