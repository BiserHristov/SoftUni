using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Append_Arrays
{
    class AppendArrays
    {
        static void Main()
        {
            //            7.Append Arrays
            //Write a program to append several arrays of numbers.
            //	Arrays are separated by '|'.
            //	Values are separated by spaces(' ', one or several).
            //	Order the arrays from the last to the first, and their values from left to right.

            List<string> line = Console.ReadLine().Split("|").ToList();
            List<int> result = new List<int>();

            for (int i = line.Count - 1; i >= 0; i--)
            {
                List<int> current = line[i].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
                result.AddRange(current);
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
