using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.ArrayRotation
{
    class Start
    {
        static void Main()
        {

            //            4.Array Rotation
            //Write a program that receives an array and number of rotations you have to perform(first element goes at the end) Print the resulting array.

            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rotations = int.Parse(Console.ReadLine());

            for (int i = 0; i < rotations; i++)
            {
                int firstElement = array[0];

                for (int j = 1; j <= array.Length - 1; j++)
                {
                    array[j - 1] = array[j];
                }

                array[array.Length - 1] = firstElement;
            }

            Console.WriteLine(string.Join(" ", array));

        }
    }
}
