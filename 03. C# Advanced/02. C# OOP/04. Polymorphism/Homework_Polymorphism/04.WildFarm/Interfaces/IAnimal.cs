using _04.WildFarm.Models.Food;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Interfaces
{
    public interface IAnimal
    {
        string Name { get; }
        double  Weight { get; }
        double FoodEaten { get; }
        string ProduceSound();
        void Feed(IFood food);

    }
}
