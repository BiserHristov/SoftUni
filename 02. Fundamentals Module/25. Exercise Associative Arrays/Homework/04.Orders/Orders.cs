using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace _04.Orders
{
    class Orders
    {
        static void Main(string[] args)
        {
            List<string> line = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Dictionary<string, List<decimal>> dict = new Dictionary<string, List<decimal>>();

            while (line[0] != "buy")
            {
                string product = line[0];
                decimal price = decimal.Parse(line[1], CultureInfo.InvariantCulture);
                decimal quantity = decimal.Parse(line[2], CultureInfo.InvariantCulture);

                if (dict.ContainsKey(product))
                {
                    dict[product][1] += quantity;

                    if (dict[product][0] != price)
                    {
                        dict[product][0] = price;
                    }

                }
                else
                {
                    dict.Add(product, new List<decimal>());
                    dict[product].Add(price);
                    dict[product].Add(quantity);
                }


                line = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                     .ToList();
            }

            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key} -> {(item.Value[0] * item.Value[1]):F2}");
            }
        }
    }
}
