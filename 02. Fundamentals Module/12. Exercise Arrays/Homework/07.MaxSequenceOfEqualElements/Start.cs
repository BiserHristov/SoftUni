using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.MaxSequenceOfEqualElements
{
    class Start
    {
        static void Main()
        {
            //            7.Max Sequence of Equal Elements
            //Write a program that finds the longest sequence of equal elements in an array of integers. If several longest sequences exist, print the leftmost one.


            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int digit = 0;
            int maxcount = 1;
            int count = 1;

            for (int i = 0; i < arr.Length - 1; i++)
            {

                if (arr[i] == arr[i + 1])
                {
                    count++;

                    if (count > maxcount)
                    {
                        maxcount = count;
                        digit = arr[i];

                    }

                }
                else
                {
                    count = 1;
                }
            }

            for (int i = 0; i < maxcount; i++)
            {
                Console.Write(digit + " ");
            }
        }
    }
}
