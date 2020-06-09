using System;
using System.Collections.Generic;
using System.Linq;

namespace Homework
{
    class FindEvensOrOdds
    {
        static void Main(string[] args)
        {
            int[] range = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string command = Console.ReadLine();
            int start = range[0];
            int end = range[1];

            Predicate<int> predicate = x => command == "even" ? x % 2 == 0 : x % 2 != 0;
            List<int> result = new List<int>();

            for (int i = start; i <= end; i++)
            {
                result.Add(i);
            }

            result = result.Where(x => predicate(x)).ToList();

            Console.WriteLine(string.Join(' ', result));

        }
    }
}
