using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.KnightsOfHonor
{
    public class KnightsOfHonor
    {
        public static void Main()
        {
            Action<List<string>> print = (x) => Console.WriteLine(string.Join(Environment.NewLine,x.Select(z=>$"Sir {z}")));

            List<string> names = Console.ReadLine()
                  .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                  .ToList();

            print(names);
        }
    }
}
