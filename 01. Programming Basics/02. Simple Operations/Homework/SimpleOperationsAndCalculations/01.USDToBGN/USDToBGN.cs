using System;

namespace _01.USDToBGN
{
    class USDToBGN
    {
        static void Main(string[] args)
        {
            double usd = double.Parse(Console.ReadLine());
            const double bgnPerUsd = 1.79549;
            double bgn = usd * bgnPerUsd;
            Console.WriteLine($"{bgn:F2}");
        }
    }
}
