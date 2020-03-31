using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.EqualSums
{
    class Start
    {
        static void Main()
        {
            //            6.Equal Sums
            //Write a program that determines if there exists an element in the array such that the sum of the elements on its left is equal to the sum of the elements on its right(there will never be more than 1 element like that). If there are no elements to the left / right, their sum is considered to be 0.Print the index that satisfies the required condition or "no" if there is no such index.



            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int index = -1;

            for (int i = 0; i <= arr.Length - 1; i++)
            {
                int leftSum = 0;
                int rightSum = 0;

                if (i == 0)
                {
                    for (int j = 1; j <= arr.Length - 1; j++)
                    {
                        rightSum += arr[j];
                    }

                    if (leftSum == rightSum)
                    {
                        index = 0;
                        break;

                    }
                }
                else if (i == arr.Length - 1)
                {
                    for (int m = 0; m < arr.Length - 1; m++)
                    {
                        leftSum += arr[m];
                    }


                    if (leftSum == rightSum)
                    {
                        index = arr.Length - 1;
                        break;

                    }

                }

                else
                {

                    for (int j = 0; j < i; j++)
                    {
                        leftSum += arr[j];
                    }

                    for (int k = i + 1; k <= arr.Length - 1; k++)
                    {
                        rightSum += arr[k];
                    }

                    if (leftSum == rightSum)
                    {
                        index = i;
                        break;

                    }
                }
            }

            if (index < 0)
            {
                Console.WriteLine("no");
            }
            else
            {
                Console.WriteLine(index);
            }
        }
    }
}
