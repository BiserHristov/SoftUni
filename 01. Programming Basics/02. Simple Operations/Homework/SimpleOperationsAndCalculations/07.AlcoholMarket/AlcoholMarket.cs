using System;

namespace _07.AlcoholMarket
{
    class AlcoholMarket
    {
        static void Main(string[] args)
        {
            double whiskeyPrice = double.Parse(Console.ReadLine());
            double beer = double.Parse(Console.ReadLine());
            double wine = double.Parse(Console.ReadLine());
            double rakia = double.Parse(Console.ReadLine());
            double whiskey = double.Parse(Console.ReadLine());

            double rakiaPrice = whiskeyPrice / 2;
            double winePrice = rakiaPrice - (rakiaPrice * 0.4);
            double beerPrice = rakiaPrice - (rakiaPrice * 0.8);
            double sum = beer * beerPrice + wine * winePrice + rakia * rakiaPrice + whiskey * whiskeyPrice;
            Console.WriteLine("{0:F2}", sum);

        }
    }
}
