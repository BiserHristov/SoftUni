using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Beverages
{
    public class Coffee : HotBeverage
    {
        private const double COFFEE_MILLILITERS = 50;
        private const decimal COFFE_PRICE = 3.50M;
        public Coffee(string name, double caffeine) : base(name, COFFE_PRICE, COFFEE_MILLILITERS)
        {
            this.Caffeine = caffeine;
        }

        public double Caffeine { get; set; }
    }
}
