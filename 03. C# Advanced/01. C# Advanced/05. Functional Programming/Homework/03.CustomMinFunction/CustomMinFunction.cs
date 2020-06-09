using System;
using System.Linq;

namespace _03.CustomMinFunction
{
    public class CustomMinFunction
    {
        public static void Main()
        {
            Func<int[], int> findSmallest = x => x.Min();

            int[] array = Console.ReadLine()
                 .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();
                 
           Console.WriteLine( findSmallest(array));
        }
    }
}
