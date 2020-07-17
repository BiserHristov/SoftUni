using System;
using System.Linq;

namespace P04.PizzaCalories
{
    class Program
    {
        static void Main(string[] args)
        {
            string pizzaName = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Skip(1)
                .Take(1)
                .FirstOrDefault();

            string[] doughArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string flourType = doughArgs[1];
            string bakingTechnique = doughArgs[2];
            int weight = int.Parse(doughArgs[3]);
            try
            {

                var dough = new Dough(flourType, bakingTechnique, weight);
                var pizza = new Pizza(pizzaName, dough);

                string line = Console.ReadLine();

                while (line != "END")
                {
                    string[] toppingArgs = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    string toppingType = toppingArgs[1];
                    double toppingWeight = double.Parse(toppingArgs[2]);
                    var topping = new Topping(toppingType, toppingWeight);
                    pizza.AddTopping(topping);

                    line = Console.ReadLine();
                }

                Console.WriteLine(pizza);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
