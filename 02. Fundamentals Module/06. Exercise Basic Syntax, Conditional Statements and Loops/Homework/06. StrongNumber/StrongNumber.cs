using System;
using System.Globalization;

namespace BasicSyntaxConditionalStatementsAndLoops
{
    class StrongNumber
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int copyNumber = number;
            int factorielSum = 0;

            while (copyNumber > 0)
            {
                int digit = copyNumber % 10;
                int factoriel = 1;
                for (int i = 1; i <= digit; i++)
                {
                    factoriel *= i;
                }
                factorielSum += factoriel;

                copyNumber /= 10;
            }

            if (factorielSum == number)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }

        }
    }
}

