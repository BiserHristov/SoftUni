using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.AppliedArithmetics
{
    public class AppliedArithmetics
    {
        public static void Main()
        {
            List<int> numbers = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();


            Func<List<int>, List<int>> addFunc = x => x.Select(n => n += 1).ToList();
            Func<List<int>, List<int>> multiplyFunc = x => x.Select(n => n *= 2).ToList();
            Func<List<int>, List<int>> subtractFunc = x => x.Select(n => n -= 1).ToList();
            Action<List<int>> print = x => Console.WriteLine(string.Join(' ', x));

            string command = Console.ReadLine();


            while (command != "end")
            {
                switch (command)
                {
                    case "add":
                        numbers = addFunc(numbers);
                        break;
                    case "multiply":
                        numbers = multiplyFunc(numbers);
                        break;
                    case "subtract":
                        numbers = subtractFunc(numbers);
                        break;
                    case "print":
                        print(numbers);
                        break;
                    default:
                        break;

                }

                command = Console.ReadLine();
            }

        }
    }
}
