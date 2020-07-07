using System;
using System.Collections.Generic;
using System.Text;

namespace P04.PizzaCalories
{
    public class Pizza
    {
        private const int MIN_LENGTH = 1;
        private const int MAX_LENGTH = 15;
        private const int MIN_TOPPING_COUNT = 0;
        private const int MAX_TOPPING_COUNT = 10;
        private List<Topping> toppings;
        private string name;
        public Pizza(string name, Dough dough)
        {
            this.toppings = new List<Topping>();
            this.Name = name;
            this.Dough = dough;
        }
        private Dough dough;

        public Dough Dough
        {
            get { return this.dough; }
            set { this.dough = value; }
        }

        public string Name
        {
            get => this.name;
            set
            {
                if (string.IsNullOrWhiteSpace(value) ||
                    value.Length < MIN_LENGTH ||
                    value.Length > MAX_LENGTH)
                {
                    throw new ArgumentException($"Pizza name should be between {MIN_LENGTH} and {MAX_LENGTH} symbols.");
                }
                this.name = value;
            }
        }

        public int ToppingsCount => this.toppings.Count;
        public double TotalCalories => CalculateCalories();
        public void AddTopping(Topping topping)
        {
            if (this.ToppingsCount == MAX_TOPPING_COUNT)
            {
                throw new ArgumentException($"Number of toppings should be in range [{MIN_TOPPING_COUNT}..{MAX_TOPPING_COUNT}].");
            }
            this.toppings.Add(topping);
        }

        private double CalculateCalories()
        {
            double sum = 0;
            sum += this.Dough.CalculateCalories();
            foreach (var topping in this.toppings)
            {
                sum += topping.CalculateCalories();
            }

            return sum;
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.TotalCalories:F2} Calories.";
        }

    }
}
