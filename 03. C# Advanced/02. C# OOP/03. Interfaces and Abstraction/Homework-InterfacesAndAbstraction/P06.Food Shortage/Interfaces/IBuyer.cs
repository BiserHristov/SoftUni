using System;
using System.Collections.Generic;
using System.Text;

namespace _06.FoodShortage.Interfaces
{
    public interface IBuyer : INameable
    {
        void BuyFood();
        int Food { get; }
    }
}
