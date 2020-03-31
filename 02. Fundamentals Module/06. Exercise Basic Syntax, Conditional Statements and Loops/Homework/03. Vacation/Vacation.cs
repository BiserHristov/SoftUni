using System;
using System.Globalization;

namespace BasicSyntaxConditionalStatementsAndLoops
{
    class Vacation
    {
        static void Main(string[] args)
        {
            int totalPeople = int.Parse(Console.ReadLine());
            string type = Console.ReadLine();
            string day = Console.ReadLine();

            decimal pricePerPerson = 0;

            if (type == "Students")
            {
                if (day == "Friday")
                {
                    pricePerPerson = 8.45M;
                }
                else if (day == "Saturday")
                {
                    pricePerPerson = 9.80M;
                }
                else if (day == "Sunday")
                {
                    pricePerPerson = 10.46M;
                }

                if (totalPeople >= 30)
                {
                    pricePerPerson *= 0.85M;
                }
            }

            else if (type == "Business")
            {
                if (day == "Friday")
                {
                    pricePerPerson = 10.90M;
                }
                else if (day == "Saturday")
                {
                    pricePerPerson = 15.60M;
                }
                else if (day == "Sunday")
                {
                    pricePerPerson = 16M;
                }

                if (totalPeople >= 100)
                {
                    totalPeople -= 10;
                }
            }

            else if (type == "Regular")
            {
                if (day == "Friday")
                {
                    pricePerPerson = 15M;
                }
                else if (day == "Saturday")
                {
                    pricePerPerson = 20M;
                }
                else if (day == "Sunday")
                {
                    pricePerPerson = 22.50M;
                }

                if (totalPeople >= 10 && totalPeople <= 20)
                {
                    pricePerPerson *= 0.95M;
                }
            }

            decimal price = pricePerPerson * totalPeople;

            Console.WriteLine($"Total price: {price:F2}");


        }
    }
}

