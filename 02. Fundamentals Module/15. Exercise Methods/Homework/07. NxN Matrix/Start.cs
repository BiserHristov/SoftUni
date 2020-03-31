using System;

namespace _07._NxN_Matrix
{
    class Start
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            PrintMatrix(number);

        }

        static void PrintMatrix(int number)
        {
            for (int i = 1; i <= number; i++)
            {
                for (int j = 1; j < number; j++)
                {
                    Console.Write(number + " ");
                }
                Console.WriteLine(number);
            }
           
        }
    }
}
