using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.ZigZagArrays
{
    class Start
    {
        static void Main()
        {
            //            3.Zig - Zag Arrays
            //Write a program which creates 2 arrays.You will be given an integer n.On the next n lines you get 2 integers.Form 2 arrays as shown below.

            int lines = int.Parse(Console.ReadLine());
            int[] first = new int[lines];
            int[] second = new int[lines];

            for (int i = 0; i < lines; i++)
            {
                int[] currentLine = Console.ReadLine().Split().Select(int.Parse).ToArray();

                if (i % 2 == 0)
                {
                    first[i] = currentLine[0];
                    second[i] = currentLine[1];
                }
                else
                {
                    second[i] = currentLine[0];
                    first[i] = currentLine[1];
                }
            }

            Console.WriteLine(string.Join(" ", first));
            Console.WriteLine(string.Join(" ", second));
        }
    }
}
