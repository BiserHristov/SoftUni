using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.SwapMethodString
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                list.Add(Console.ReadLine());

            }

            int[] indexes = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int firstIndex = indexes[0];
            int secondIndex = indexes[1];

            SwapElements(list, firstIndex, secondIndex);

            foreach (var item in list)
            {
                Console.WriteLine($"{item.GetType()}: {item}");
            }
        }

        static void SwapElements<T>(List<T> list, int firstIndex, int secondIndex)
        {
            var firstElement = list[firstIndex];

            list[firstIndex] = list[secondIndex];
            list[secondIndex] = firstElement;
        }
    }
}
