using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.GenericSwapMethodIntegers
{
    public class GenericSwapMethodIntegers
    {
        public static void Main(string[] args)
        {
            List<int> list = new List<int>();
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                list.Add(int.Parse(Console.ReadLine()));

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

        public static void SwapElements<T>(List<T> list, int firstIndex, int secondIndex)
        {
            var firstelement = list[firstIndex];
            list[firstIndex] = list[secondIndex];
            list[secondIndex] = firstelement;
        }
    }
}
