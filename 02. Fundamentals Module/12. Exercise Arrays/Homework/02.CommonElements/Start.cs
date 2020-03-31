using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.CommonElements
{
    class Start
    {
        static void Main()
        {
            //            2.Common Elements
            //Write a program, which prints common elements in two arrays. You have to compare the elements of the second array to the elements of the first

            string[] first = Console.ReadLine().Split();
            string[] second = Console.ReadLine().Split();

            for (int i = 0; i < second.Length; i++)
            {
                for (int j = 0; j < first.Length; j++)
                {
                    if (second[i] == first[j])
                    {
                        Console.Write(second[i] + " ");
                    }

                }

            }
        }
    }
}
