using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.PeriodicTable
{
    class PeriodicTable
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            var sortedSet = new SortedSet<string>();

            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                for (int j = 0; j < input.Length; j++)
                {
                    sortedSet.Add(input[j]);
                }
            }

            Console.WriteLine(string.Join(' ', sortedSet));
        }
    }
}
