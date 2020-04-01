using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Fundamentals_MidExam
{
    class BonusScoringSystem
    {
        static void Main()
        {
            int studentsCount = int.Parse(Console.ReadLine());
            double lecturesCount = double.Parse(Console.ReadLine());
            double initialBonus = double.Parse(Console.ReadLine());
            int maxBonus = 0;
            double maxAttendances = 0;

            for (int i = 0; i < studentsCount; i++)
            {
                double studentAttendance = double.Parse(Console.ReadLine());
                int totalBonus = (int)Math.Ceiling((studentAttendance / lecturesCount) * (5 + initialBonus));
                if (totalBonus > maxBonus)
                {
                    maxBonus = totalBonus;
                    maxAttendances = studentAttendance;

                }
            }

            Console.WriteLine($"Max Bonus: {maxBonus}.");
            Console.WriteLine($"The student has attended {maxAttendances} lectures.");


        }
    }
}
