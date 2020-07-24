using _04.WildFarm.Interfaces;
using _04.WildFarm.Models.Food;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Models.Animal
{
    public abstract class Animal : IAnimal
    {

        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
            this.FoodEaten = 0;

        }
        public string Name { get; private set; }

        public double Weight { get; protected set; }
        public double FoodEaten { get; private set; }

        public virtual void Feed(IFood food)
        {

            this.FoodEaten += food.Quantity;
        }

        public abstract string ProduceSound();
        // public abstract void Feed(Food food)

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, ";
        }

    }
}
