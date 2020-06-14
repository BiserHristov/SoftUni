using System;

namespace _03._2DRectangleArea
{
    class TwoDRectangleArea
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            double sideaA = Math.Abs(x1 - x2);
            double sideB = Math.Abs(y2 - y1);
            double area = sideaA * sideB;
            double periemter = (sideaA + sideB) * 2;
            Console.WriteLine($"{area:F2}");
            Console.WriteLine($"{periemter:F2}");
        }
    }
}
