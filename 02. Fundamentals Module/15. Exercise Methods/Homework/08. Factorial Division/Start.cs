using System;
using System.Numerics;

namespace _08._Factorial_Division
{
    class Start
    {
        static void Main()
        {
            //            8.Factorial Division
            //Read two integer numbers.Calculate factorial of each number.Divide the first result by the second and print the division formatted to the second decimal point.

            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            BigInteger firstFactoriel = CalculateFactoriel(firstNumber);
            BigInteger secondFactoriel = CalculateFactoriel(secondNumber);


            Console.WriteLine("{0:F2}", (double)firstFactoriel / (double)secondFactoriel);
        }

        static BigInteger CalculateFactoriel(int number)
        {
            BigInteger result = 1;

            if (number <= 0)
            {
                return result;
            }

            for (int i = 1; i <= number; i++)
            {
                result *= i;

            }

            return result;
        }


    }
}
