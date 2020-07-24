using _04.WildFarm.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Models.Animal.Birds
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingsize) : base(name, weight, wingsize)
        {
        }

        public override void Feed(IFood food)
        {
            this.Weight +=food.Quantity* 0.35;
            base.Feed(food);
        }

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
