using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_6.Triples_of_Latin_Letters
{
    class Start
    {
        static void Main()
        {
            //Write a program to read an integer n and print all triples of the first n small Latin letters, ordered alphabetically:

            int n = int.Parse(Console.ReadLine());

            for (int firstLetter = 0; firstLetter < n; firstLetter++)
            {
                for (int secondLetter = 0; secondLetter < n; secondLetter++)
                {
                    for (int thirdLetter = 0; thirdLetter < n; thirdLetter++)
                    {
                        Console.WriteLine("{0}{1}{2}", (char)('a' + firstLetter), (char)('a' + secondLetter), (char)('a' + thirdLetter));
                    }
                }
            }
        }
    }
}
