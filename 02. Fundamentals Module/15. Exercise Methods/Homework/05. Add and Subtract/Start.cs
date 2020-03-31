using System;

namespace _05._Add_and_Subtract
{
    class Start
    {
        //        5.	Add and Subtract
        //You will receive 3 integers.Write a method Sum to get the sum of the first two integers and Subtract method that subtracts the third integer from the result from the Sum method.

        static void Main()
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());
            int sumResult = Sum(firstNumber, secondNumber);
            int substractResult = Substract(sumResult, thirdNumber);

            Console.WriteLine(substractResult);


        }

        static int Sum(int first, int second)
        {
            return first + second;
        }

        static int Substract(int result, int number)
        {

            return result - number;
        }
    }
}
