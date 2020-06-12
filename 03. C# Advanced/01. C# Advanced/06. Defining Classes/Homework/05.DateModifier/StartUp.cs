using System;

namespace _05.DateModifier
{
    public class StartUp
    {
        public static void Main()
        {
            string firstDate = Console.ReadLine();
            string lastDate = Console.ReadLine();

            double days = DateModifier.CalculateDifference(firstDate, lastDate);
            Console.WriteLine(days);

        }
    }
}
