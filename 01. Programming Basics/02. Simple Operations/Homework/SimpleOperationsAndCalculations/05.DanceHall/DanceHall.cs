using System;

namespace _05.DanceHall
{
    class DanceHall
    {
        static void Main(string[] args)
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double garderobSide = double.Parse(Console.ReadLine());

            double hallArea = length * width;
            double freeSpace = hallArea - (garderobSide * garderobSide) - (hallArea / 10);

            double dancers = Math.Floor(freeSpace / 0.7040);

            Console.WriteLine($"{dancers}");
            //Console.WriteLine( $"{cenaBG:F2} BGN");
        }
    }
}
