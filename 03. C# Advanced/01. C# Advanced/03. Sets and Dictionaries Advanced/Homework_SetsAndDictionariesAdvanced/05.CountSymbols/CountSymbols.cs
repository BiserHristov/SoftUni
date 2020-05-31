using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

namespace _05.CountSymbols
{
    class CountSymbols
    {
        static void Main()
        {
            string text = Console.ReadLine();
            SortedDictionary<char, int> dict = new SortedDictionary<char, int>();

            for (int i = 0; i < text.Length; i++)
            {
                if (!dict.ContainsKey(text[i]))
                {
                    dict.Add(text[i], 0);
                }
                dict[text[i]]++;
            }
            foreach (var kvp in dict)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} time/s");
            }
        }
    }
}
