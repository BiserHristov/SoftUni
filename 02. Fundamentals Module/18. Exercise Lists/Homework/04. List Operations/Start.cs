using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._List_Operations
{
    class Start
    {
        static void Main()
        {
            //            You will be given a list of integer numbers on the first line of input.You will be receiving operations you have to apply on the list until you receive the "End" command.The possible commands are:
            //•	Add { number} – add number at the end.
            //•	Insert { number}
            //            { index} – insert number at given index.
            //•	Remove { index} – remove at index.
            //•	Shift left { count} – first number becomes last ‘count’ times.
            //•	Shift right { count} – last number becomes first ‘count’ times.
            //Note: there is a possibility that the given index is outside of the bounds of the array.In that case print "Invalid index"

            List<int> list = Console.ReadLine()
                            .Split()
                            .Select(int.Parse)
                            .ToList();
            List<string> command = Console.ReadLine().Split().ToList();

            while (command[0] != "End")
            {
                if (command[0] == "Add")
                {
                    list.Add(int.Parse(command[1]));
                }
                else if (command[0] == "Insert")
                {
                    int number = int.Parse(command[1]);
                    int index = int.Parse(command[2]);

                    if (IsValid(index, list.Count - 1))
                    {
                        Insert(list, number, index);
                    }
                    else
                    {
                        Console.WriteLine("Invalid index");
                    }

                }
                else if (command[0] == "Remove")
                {
                    int index = int.Parse(command[1]);

                    if (IsValid(index, list.Count - 1))
                    {
                         list.RemoveAt(int.Parse(command[1]));
                    }
                    else
                    {
                        Console.WriteLine("Invalid index");
                    }
                }
                else if (command[0] + " " + command[1] == "Shift left")
                {
                    for (int i = 0; i < int.Parse(command[2]); i++)
                    {
                        int firstNumber = list[0];
                        list.RemoveAt(0);
                        list.Add(firstNumber);
                    }
                }
                else if (command[0] + " " + command[1] == "Shift right")
                {
                    for (int i = 0; i < int.Parse(command[2]); i++)
                    {
                        int lastNumber = list[list.Count - 1];
                        list.RemoveAt(list.Count - 1);
                        list.Insert(0, lastNumber);
                    }
                }

                command = Console.ReadLine().Split().ToList();
            }

            Console.WriteLine(string.Join(" ", list));
        }

        public static void Insert(List<int> list, int number, int index)
        {


            list.Insert(index, number);

        }

        public static bool IsValid(int searchIndex, int end)
        {
            if (searchIndex < 0 || searchIndex > end)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
