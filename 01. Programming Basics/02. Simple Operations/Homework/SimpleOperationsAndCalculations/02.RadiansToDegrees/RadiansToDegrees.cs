using System;

namespace _02.RadiansToDegrees
{
    class RadiansToDegrees
    {
        static void Main(string[] args)
        {
            double radians = double.Parse(Console.ReadLine());
            const double bgnPerUsd = 1.79549;
            double radius = radians * 180 / Math.PI;
            Console.WriteLine(Math.Round(radius));
        }
    }
}
