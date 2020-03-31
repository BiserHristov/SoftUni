using System;

namespace _09._Palindrome_Integers
{
    class Start
    {
        static void Main()
        {
            //            9.Palindrome Integers
            //A palindrome is a number which reads the same backward as forward, such as 323 or 1001.Write a program which reads a positive integer numbers until you receive "End", for each number print whether the number is palindrome or not.


            string line = Console.ReadLine();

            while (line != "END")
            {
                bool palindrome = IsItPalindrome(line);

                if (palindrome)
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }

                line = Console.ReadLine();
            }


        }

        static bool IsItPalindrome(string input)
        {
            bool isEqual = true;
            int endIndex = (input.Length / 2) - 1;

            for (int i = 0; i <= endIndex; i++)
            {
                if (input[i] - '0' != input[input.Length - 1 - i] - '0')
                {
                    isEqual = false;
                    break;

                }
            }

            return isEqual;
        }
    }
}
