using System;

namespace Methods
{
    class Start
    {
        //Write a method to print the smallest of three integer numbers.Use appropriate name for the method.
        static void Main()
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());

            int result = GetSmallest(firstNumber, secondNumber, thirdNumber);
            Console.WriteLine(result);
        }

        static int GetSmallest(int first, int second, int third)
        {
            int smallest = first;

            if (second < smallest)
            {
                smallest = second;
            }

            if (third < smallest)
            {
                smallest = third;
            }

            return smallest;
        }
    }
}
