using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.LettersChangeNumbers
{
    class LettersChangeNumbers
    {
        static void Main()
        {
            List<string> list = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .ToList();
            decimal totalSum = 0;

            for (int i = 0; i < list.Count; i++)
            {
                decimal currentSum = 0;
                decimal number = long.Parse(list[i].Substring(1, list[i].Length - 2));
                int position = char.ToUpper(list[i][0]) - 'A' + 1;

                if (char.IsUpper(list[i][0]))
                {

                    currentSum += number / position;
                }
                else
                {
                    currentSum += number * position;
                }

                position = char.ToUpper(list[i][list[i].Length - 1]) - 'A' + 1;

                if (char.IsUpper(list[i][list[i].Length - 1]))
                {
                    currentSum -= position;
                }
                else
                {
                    currentSum += position;
                }

                totalSum += currentSum;
            }

            Console.WriteLine($"{totalSum:F2}");
        }
    }
}
