using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.EvenTimes
{
    class EvenTimes
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            var dict = new Dictionary<int, int>();

            for (int i = 0; i < count; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (!dict.ContainsKey(number))
                {
                    dict.Add(number, 0);
                }

                dict[number]++;
            }
            foreach (var kvp in dict)
            {
                if (kvp.Value % 2 == 0)
                {
                    Console.WriteLine(kvp.Key);
                    return;
                }
            }

        }
    }
}
