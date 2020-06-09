using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.ReverseAndExclude
{
    public class ReverseAndExclude
    {
        static void Main()
        {
            List<int> numbers = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();
            int divider = int.Parse(Console.ReadLine());

            Func<List<int>, int, List<int>> reverseAndExclude = (x, y) =>
            {
                List<int> result = new List<int>();
                result = x.Where(n => n % divider != 0).Reverse().ToList();

                return result;
            };

            Console.WriteLine(string.Join(' ', reverseAndExclude(numbers, divider)));
        }
    }
}
