using System;

namespace _04.TailoringWorkshop
{
    class TailoringWorkshop
    {
        static void Main(string[] args)
        {
            int tables = int.Parse(Console.ReadLine());
            double tableLength = double.Parse(Console.ReadLine());
            double tableWidth = double.Parse(Console.ReadLine());



            double pokrivka = (tableLength + 0.6) * (tableWidth + 0.6);

            double kareSide = tableLength / 2;
            double kare = kareSide * kareSide;
            double cenaBG = (pokrivka * 7 * tables + kare * 9 * tables) * 1.85;
            double cenaUSD = pokrivka * 7 * tables + kare * 9 * tables;

            Console.WriteLine($"{cenaUSD:F2} USD");
            Console.WriteLine($"{cenaBG:F2} BGN");
        }
    }
}
