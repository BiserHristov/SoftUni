using System;
using System.Collections.Generic;
using System.Threading;

namespace _05.GenericCountMethodStrings
{
    public class GenericCountMethodDoubles
    {
        public static void Main()
        {
            int count = int.Parse(Console.ReadLine());

            var list = new List<double>();

            for (int i = 0; i < count; i++)
            {
                list.Add(double.Parse(Console.ReadLine()));
            }

            double value = double.Parse(Console.ReadLine());

            Console.WriteLine(GreaterElementsCount(list, value));


        }

        public static int GreaterElementsCount<T>(List<T> list, T element) where T : IComparable
        {
            int count = 0;

            foreach (var item in list)
            {
                if (item.CompareTo(element) > 0)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
