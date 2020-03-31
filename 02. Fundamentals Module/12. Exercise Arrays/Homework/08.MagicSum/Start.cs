using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.MagicSum
{
    class Start
    {
        static void Main()
        {
            //            8.Magic Sum
            //Write a program, which prints all unique pairs in an array of integers whose sum is equal to a given number.

            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int magicSum = int.Parse(Console.ReadLine());

            for (int i = 0; i <= arr.Length - 1; i++)
            {
                for (int j = i + 1; j <= arr.Length - 1; j++)
                {
                    if (arr[i] + arr[j] == magicSum)
                    {
                        Console.WriteLine(arr[i] + " " + arr[j]);
                    }
                }
            }
        }
    }
}
