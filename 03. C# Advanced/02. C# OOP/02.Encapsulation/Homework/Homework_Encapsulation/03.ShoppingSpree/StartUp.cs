using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            List<Product> products = new List<Product>();

            string[] input = Console.ReadLine().Split(new char[] { '=', ';' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < input.Length; i += 2)
            {
                try
                {
                    var person = new Person(input[i], decimal.Parse(input[i + 1]));
                    persons.Add(person);
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                    return;
                }
               
            }
      
            input = Console.ReadLine().Split(new char[] { '=', ';' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < input.Length; i += 2)
            {
                try
                {
                    var product = new Product(input[i], decimal.Parse(input[i + 1]));
                    products.Add(product);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }


            string command = string.Empty;

            while ((command = Console.ReadLine()) != "END")
            {
                input = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string personName = input[0];
                string productName = input[1];

                Person person = persons.FirstOrDefault(x => x.Name == personName);
                if (person != null)
                {
                    var product = products.FirstOrDefault(x => x.Name == productName);
                    if (person.Money >= product.Cost)
                    {
                        person.Money -= product.Cost;
                        person.Products.Add(product);
                        Console.WriteLine($"{personName} bought {productName}");

                    }
                    else
                    {
                        Console.WriteLine($"{personName} can't afford {productName}");
                    }

                }
            }

            foreach (var person in persons)
            {
                Console.WriteLine(person);
            }

        }
    }
}
