using System;
using System.Linq;

namespace _08.CustomComparator
{
    public class CustomComparator
    {
        public static void Main()
        {
            int[] nums = new int[] { 6, 7, 2, 9, 10, 3 };
           nums= nums.Select((x, y) => x.CompareTo(y)).ToArray();

            Console.WriteLine(string.Join(' ',nums));
        }
    }
}
