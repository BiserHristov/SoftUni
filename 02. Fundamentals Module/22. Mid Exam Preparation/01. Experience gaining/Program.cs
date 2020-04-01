using System;

namespace _01._Experience_gaining
{
    class Program
    {
        static void Main(string[] args)
        {
            double neededExperience = double.Parse(Console.ReadLine());
            int battles = int.Parse(Console.ReadLine());

            double sumExp = 0;
            int battlesCount = 0;

            for (int i = 1; i <= battles; i++)
            {
                double currentExp = double.Parse(Console.ReadLine());
                battlesCount++;
                if (i % 3 == 0)
                {
                    sumExp += currentExp * 0.15;

                }
                else if (i % 5 == 0)
                {
                    sumExp -= currentExp * 0.1;
                }

                sumExp += currentExp;
                if (sumExp >= neededExperience)
                {
                    break;
                }
            }

            if (sumExp>=neededExperience)
            {
                Console.WriteLine($"Player successfully collected his needed experience for {battlesCount} battles.");
            }
            else
            {
                Console.WriteLine($"Player was not able to collect the needed experience, {(neededExperience-sumExp):F2} more needed.");
            }
        }
    }
}
