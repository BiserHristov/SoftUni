using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._SetsOfElements
{
    class SetsOfElements
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var firstSet = new HashSet<int>();
            var secondSet = new HashSet<int>();

            for (int i = 0; i < size[0] + size[1]; i++)
            {

                int number = int.Parse(Console.ReadLine());
                if (i < size[0])
                {
                    firstSet.Add(number);
                }
                else
                {
                    secondSet.Add(number);
                }
            }

            firstSet.IntersectWith(secondSet);

            Console.WriteLine(string.Join(' ',firstSet));
        }
    }
}
