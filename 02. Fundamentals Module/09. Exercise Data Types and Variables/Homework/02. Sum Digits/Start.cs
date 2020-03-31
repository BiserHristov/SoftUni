using System;

namespace SumDigits
{
    class Start
    {
        static void Main()
        {
            //          2.Sum Digits
            //You will be given a single integer. Your task is to find the sum of its digits.

            string input = Console.ReadLine();
            int sum = 0;

            for (int i = input.Length - 1; i >= 0; i--)
            {
                sum += (int)Char.GetNumericValue(input[i]);
            }

            Console.WriteLine(sum);

        }
    }
}
