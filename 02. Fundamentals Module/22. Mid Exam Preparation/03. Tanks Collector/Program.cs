using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Tanks_Collector
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(s => s.Trim())
                .ToList();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                List<string> line = Console.ReadLine()
                        .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                        .Select(s => s.Trim())
                        .ToList();
                string action = line[0];
                if (action == "Add")
                {
                    string tankName = line[1];
                    ; if (list.Contains(tankName))
                    {
                        Console.WriteLine("Tank is already bought");
                    }
                    else
                    {
                        list.Add(tankName);
                        Console.WriteLine("Tank successfully bought");
                    }
                }
                else if (action == "Remove")
                {
                    string tankName = line[1];
                    if (list.Contains(tankName))
                    {
                        list.Remove(tankName);
                        Console.WriteLine("Tank successfully sold");
                    }
                    else
                    {
                        Console.WriteLine("Tank not found");
                    }

                }
                else if (action == "Remove At")
                {
                    int index = int.Parse(line[1]);
                    if (index < 0 || index > list.Count - 1)
                    {
                        Console.WriteLine("Index out of range");
                    }
                    else
                    {
                        list.RemoveAt(index);
                        Console.WriteLine("Tank successfully sold");
                    }
                }
                else if (action == "Insert")
                {
                    int index = int.Parse(line[1]);
                    string tankName = line[2];
                    if (index < 0 || index > list.Count - 1)
                    {

                        Console.WriteLine("Index out of range");

                    }
                    else if (list.Contains(tankName))
                    {
                        Console.WriteLine("Tank is already bought");

                    }
                    else
                    {
                        list.Insert(index, tankName);
                        Console.WriteLine("Tank successfully bought");
                    }
                }



            }
            Console.WriteLine(string.Join(", ", list));
        }
    }
}