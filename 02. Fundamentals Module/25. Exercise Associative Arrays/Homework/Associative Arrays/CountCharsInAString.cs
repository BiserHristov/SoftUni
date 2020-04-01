using System;
using System.Collections.Generic;
using System.Linq;

namespace Associative_Arrays
{
    class Program
    {
        static void Main()
        {
            List<string> line = Console.ReadLine().Split().ToList();
            string word = string.Join("", line);

            Dictionary<string, int> dict = new Dictionary<string, int>();

            foreach (char ch in word)
            {
                if (dict.ContainsKey(ch.ToString()))
                {
                    dict[ch.ToString()]++;
                }
                else
                {
                    dict[ch.ToString()] = 1;
                }
            }

            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key}" + " -> " + $"{item.Value}");

            }

        }
    }
}
