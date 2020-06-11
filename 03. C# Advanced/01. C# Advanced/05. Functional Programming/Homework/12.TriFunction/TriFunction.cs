using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.TriFunction
{
    public class TriFunction
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            List<string> names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Func<string, int, bool> isValid = (x, y) =>
              {

                  int sum = 0;
                  for (int i = 0; i < x.Length; i++)
                  {
                      sum += (int)x[i];
                  }
                  if (sum >= y)
                  {
                      return true;
                  }
                  return false;

              };
            Func<List<string>, Func<string, int, bool>, string> findResult = (x, y) => x.FirstOrDefault(s => y(s, number));

            string result = findResult(names,isValid);

            if (result != null)
            {
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine(String.Empty);
            }


        }
    }
}
