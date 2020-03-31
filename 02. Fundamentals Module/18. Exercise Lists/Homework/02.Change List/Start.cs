using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Change_List
{
    class Program
    {
        static void Main()
        {
            //            Write a program, which reads a list of integers from the console and receives commands, which manipulate the list.Your program may receive the following commands:
            //•	Delete { element} – delete all elements in the array, which are equal to the given element.
            //•	Insert { element}
            //            { position} – insert an element and the given position.
            //You should stop the program when you receive the command "end".Print the numbers in the array separated by a single whitespace.

            List<int> list = Console.ReadLine()
                            .Split()
                            .Select(int.Parse)
                            .ToList();
            List<string> command = Console.ReadLine().Split().ToList();

            while (command[0] != "end")
            {
                if (command[0] == "Delete")
                {
                    int searchIndex = list.IndexOf(int.Parse(command[1]));
                    while (searchIndex >= 0)
                    {
                        list.RemoveAt(searchIndex);
                        searchIndex= list.IndexOf(int.Parse(command[1]));
                    }
                }
                else if (command[0]=="Insert")
                {
                    list.Insert(int.Parse(command[2]), int.Parse(command[1]));
                }

                command = Console.ReadLine().Split().ToList();
            }

            Console.WriteLine(string.Join(" ", list));
        }
    }
}
