using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._House_Party
{
    class Program
    {
        static void Main()
        {
            //            Write a program that keeps track of guests, that are going to a house party. On the first line of input, you are going to receive the number of commands you are going to receive.On the next lines you are going to receive one of the following messages:
            //-"{name} is going!"
            //- "{name} is not going!"
            //If you receive the first message, you have to add the person if he / she is not in the list and if he / she is in the list print on the console: "{name} is already in the list!".If you receive the second message, you have to remove the person if he / she is in the list and if not print: "{name} is not in the list!".At the end print all the guests.

            int count = int.Parse(Console.ReadLine());
            List<string> names = new List<string>();

            for (int i = 0; i < count; i++)
            {
                List<string> line = Console.ReadLine().Split().ToList();

                if (names.IndexOf(line[0]) < 0 && line.IndexOf("not") < 0)
                {
                    names.Add(line[0]);
                }
                else if (names.IndexOf(line[0]) >= 0 && line.IndexOf("not") < 0)
                {
                    Console.WriteLine($"{line[0]} is already in the list!");
                }
                else if (names.IndexOf(line[0]) >= 0 && line.IndexOf("not") > 0)
                {
                    names.Remove(line[0]);
                }
                else if (names.IndexOf(line[0]) < 0 && line.IndexOf("not") > 0)
                {
                    Console.WriteLine($"{line[0]} is not in the list!");
                }
            }

            foreach (string name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
