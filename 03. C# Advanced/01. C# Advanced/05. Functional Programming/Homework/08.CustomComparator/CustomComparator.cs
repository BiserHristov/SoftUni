using System;
using System.Linq;

namespace _08.CustomComparator
{
    public class CustomComparator
    {
        public static void Main()
        {
            int[] nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Func<int, int, int> sortFunc = (x, y) => x.CompareTo(y);
            Action<int[], int[]> print = (x, y) => Console.WriteLine($"{string.Join(' ', x)} {string.Join(' ', y)} ");
            int[] evenNumbers = nums.Where(x => x % 2 == 0).ToArray();
            int[] oddNumbers = nums.Where(x => x % 2 != 0).ToArray();

            Array.Sort(evenNumbers, new Comparison<int>(sortFunc));
            Array.Sort(oddNumbers, new Comparison<int>(sortFunc));

            print(evenNumbers, oddNumbers);
        }
    }
}
