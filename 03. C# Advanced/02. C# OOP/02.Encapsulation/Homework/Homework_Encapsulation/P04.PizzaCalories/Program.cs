using System;

namespace P04.PizzaCalories
{
    class Program
    {
        static void Main(string[] args)
        {
            var dough = new Dough("White", "Chewy", 250);
            Console.WriteLine(dough.CalculateCalories());
        }
    }
}
