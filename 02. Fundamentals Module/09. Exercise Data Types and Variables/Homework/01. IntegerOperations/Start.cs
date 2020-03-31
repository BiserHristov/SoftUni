using System;
using System.Globalization;

namespace IntegerOperations
{
    class Start
    {
        static void Main()
        {
//            1.Integer Operations
//Read four integer numbers.Add first to the second, divide(integer) the sum by the third number and multiply the result by the fourth number. Print the result.

            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());
            int fourthNumber = int.Parse(Console.ReadLine());

            int result = 0;
            result = firstNumber + secondNumber;
            result /= thirdNumber;
            result *= fourthNumber;

            Console.WriteLine(result);


        }

    }
}

