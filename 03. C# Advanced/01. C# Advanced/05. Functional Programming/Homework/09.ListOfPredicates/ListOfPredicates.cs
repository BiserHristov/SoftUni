using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _09.ListOfPredicates
{
    public class ListOfPredicates
    {
        public static void Main()
        {
            int end = int.Parse(Console.ReadLine());

            List<int> dividers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> numbers = new List<int>();
            Func<int, List<int>, bool> isDividable = (x, y) =>
            {
                bool isValid = true;
                foreach (var item in y)
                {
                    if (x % item != 0)
                    {
                        isValid = false;
                        break;
                    }
                }

                return isValid;
            };

            for (int i = 1; i <= end; i++)
            {
                numbers.Add(i);
            }

            numbers = numbers.Where(x => isDividable(x,dividers)).ToList();

            Console.WriteLine(string.Join(' ',numbers));
        }
    }
}
