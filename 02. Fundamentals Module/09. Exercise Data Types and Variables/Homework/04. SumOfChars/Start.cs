using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumOfChars
{
    class Start
    {
        static void Main()
        {
            //            4.Sum of Chars
            //Write a program, which sums the ASCII codes of n characters and prints the sum on the console.

            int lines = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = 1; i <= lines; i++)
            {
                sum += char.Parse(Console.ReadLine());
            }

            Console.WriteLine($"The sum equals: {sum}");

        }
    }
}
