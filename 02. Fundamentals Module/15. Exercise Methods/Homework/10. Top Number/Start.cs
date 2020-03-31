using System;

namespace _10._Top_Number
{
    class Start
    {
        static void Main()
        {
            //            10.Top Number
            //A top number is an integer that holds the following properties:
            //•	Its sum of digits is divisible by 8, e.g. 8, 16, 88.
            //•	Holds at least one odd digit, e.g. 232, 707, 87578.
            //Write a program to print all master numbers in the range[1…n].


            int input = int.Parse(Console.ReadLine());

            PrintTopNumberInRange(input);
        }

        static void PrintTopNumberInRange(int number)
        {

            for (int i = 1; i <= number; i++)
            {
                if (IsDivisibleToEight(i) &&
                    HaveOddDigit(i))
                {
                    Console.WriteLine(i); ;
                }
            }
        }
        static bool IsDivisibleToEight(int number)
        {

            bool result = false;
            int sum = 0;
            while (number!=0)
            {
                int digit = number % 10;
                if (digit >= 0)
                {
                    sum += digit;

                }

                number /= 10;
            }

            if (sum % 8 == 0)
            {
                result = true;
            }
            return result;

        }

        static bool HaveOddDigit(int number)
        {
            bool result = false;
            string numberAsString = number.ToString();
            for (int i = 0; i < numberAsString.Length; i++)
            {
                if ((numberAsString[i] - '0') % 2 != 0)
                {
                    result = true;
                    break;
                }
            }

            return result;

        }
    }

}
