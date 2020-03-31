using System;
using System.Globalization;

namespace BasicSyntaxConditionalStatementsAndLoops
{
    class VendingMachine
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double coin = 0;
            double sum = 0;

            while (input != "Start")
            {
                coin = double.Parse(input);
                if (coin != 0.1 &&
                    coin != 0.2 &&
                    coin != 0.5 &&
                    coin != 1 &&
                    coin != 2)
                {
                    Console.WriteLine($"Cannot accept {coin}");
                }
                else
                {
                    sum += coin;
                }

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "End")
            {

                if (input != "Nuts" &&
                    input != "Water" &&
                    input != "Crisps" &&
                    input != "Soda" &&
                    input != "Coke")
                {
                    Console.WriteLine("Invalid product");
                }

                else if (input == "Nuts")
                {
                    if (sum - 2.0 >= 0)
                    {
                        sum -= 2.0;
                        Console.WriteLine($"Purchased {input.ToLower()}");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                else if (input == "Water")
                {
                    if (sum - 0.7 >= 0)
                    {
                        sum -= 0.7;
                        Console.WriteLine($"Purchased {input.ToLower()}");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                else if (input == "Crisps")
                {
                    if (sum - 1.5 >= 0)
                    {
                        sum -= 1.5;
                        Console.WriteLine($"Purchased {input.ToLower()}");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                else if (input == "Soda")
                {
                    if (sum - 0.8 >= 0)
                    {
                        sum -= 0.8;
                        Console.WriteLine($"Purchased {input.ToLower()}");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                else if (input == "Coke")
                {
                    if (sum - 1.0 >= 0)
                    {
                        sum -= 1.0;
                        Console.WriteLine($"Purchased {input.ToLower()}");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Change: {sum:F2}");
        }
    }
}

