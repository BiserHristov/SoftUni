using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.TopIntegers
{
    class Start
    {
        static void Main()
        {

            //            5.Top Integers
            //Write a program to find all the top integers in an array. A top integer is an integer which is bigger than all the elements to its right. 


            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i <= arr.Length-1; i++)
            {
                bool isBigger = true;
                if (i==arr.Length-1)
                {
                    Console.Write(arr[i]);
                    break;
                }
                for (int j = i+1; j <= arr.Length-1; j++)
                {

                    if (arr[i]<=arr[j])
                    {
                        isBigger = false;
                        break;
                    }

                }

                if (isBigger)
                {
                    Console.Write(arr[i]+ " ");
                }


            }
           
        }
    }
}
